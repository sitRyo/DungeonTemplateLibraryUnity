/*#######################################################################################
    Copyright (c) 2017-2019 Kasugaccho
    Copyright (c) 2018-2019 As Project
    https://github.com/Kasugaccho/DungeonTemplateLibrary
    wanotaitei@gmail.com

    DungeonTemplateLibraryUnity
    https://github.com/sitRyo/DungeonTemplateLibraryUnity
    seriru.rcvmailer@gmail.com

    Distributed under the Boost Software License, Version 1.0. (See accompanying
    file LICENSE_1_0.txt or copy at http://www.boost.org/LICENSE_1_0.txt)
#######################################################################################*/

using System;
using DTL.Shape;
using DTL.Random;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class GeneratePerlinIslandTerrain : MonoBehaviour {

    public int depth = 50;
    public int height = 200;
    public int width = 200;
    public double frequency = 6.0;
    public uint octaves = 8;
    public int maxHeight = 150;

    private Terrain terrain;
    private PerlinIsland perlinIsland;
    private XorShift128 rand = new XorShift128();

    public List<Texture2D> texture2D = new List<Texture2D>();

    void Start () {
        this.terrain = GetComponent<Terrain>();
        var terrainData = terrain.terrainData;
        var matrix = new float[height, width];
        SetTerrain(terrainData);
        GeneratePerlinIsland(matrix);

        var textureMap = GetTexture(matrix, terrainData.alphamapWidth, terrainData.alphamapHeight);
        terrainData.SetHeights(0, 0, matrix);
        terrainData.SetAlphamaps(0, 0, textureMap);
        this.terrain.terrainData = terrainData;
    }

    private void SetTerrain(TerrainData terrainData) {
        terrainData.size = new Vector3(width, depth, height);
        var alphaMapResolution = Mathf.Max(height, width);
        var heightMapResolution = Mathf.Max(height, width);
        var splatPrototypeArray = this.SetSplatPrototypes();
        SetResolutions(terrainData, alphaMapResolution, heightMapResolution);
        terrainData.splatPrototypes = splatPrototypeArray;
    }

    private void GeneratePerlinIsland(float[,] matrix) {
        perlinIsland = new PerlinIsland(frequency, octaves, maxHeight);
        perlinIsland.DrawNormalize(matrix);
    }

    private void SetResolutions(TerrainData ter, int alpha, int height) {
        ter.alphamapResolution = alpha;
        ter.heightmapResolution = height;
    }

    private SplatPrototype[] SetSplatPrototypes() {
        var len = this.texture2D.Count;
        var splatPrototype = new SplatPrototype[len];
        for (int i = 0; i < len; ++i) {
            splatPrototype[i] = new SplatPrototype();
            splatPrototype[i].tileSize = Vector2.one;
            splatPrototype[i].texture = texture2D[i];
        }

        return splatPrototype;
    }

    private float[,,] GetTexture(float[,] matrix, int w, int h) {
        var map = new float[w, h, texture2D.Count];
        for (var y = 0; y < h; ++y) {
            for (var x = 0; x < h; ++x) {
                if (matrix[y, x] < 0.5f) {
                    map[y, x, 0] = 1f;
                }
                else if (matrix[y, x] < 0.65f) {
                    map[y, x, 1] = 1f;
                }
                else {
                    map[y, x, 2] = 1f;
                }
            }
        }

        return map;
    }
}
