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

using System.Collections.Generic;
using DTL.Shape;
using UnityEngine;

public class GeneratePerlinSolitaryIslandTerrain : MonoBehaviour {
    public int depth = 50;
    public int height = 48;
    public int width = 32;

    public double truncatedProportion = 0.8;
    public double mountainProportion = 0.4;
    public double frequency = 6.0;
    public uint octaves = 8;
    public int maxHeight = 60;
    public List<Texture2D> texture2D = new List<Texture2D>();

    private Terrain terrain;
    private PerlinSolitaryIsland perlinSolitaryIsland;
    
    private void Start() {
        this.terrain = GetComponent<Terrain>();
        var terrainData = terrain.terrainData;
        var matrix = new float[height, width];
        SetTerrain(terrainData);
        GenerateTerrain(matrix);

        var textureMap = GetTexture(matrix, terrainData.alphamapWidth, terrainData.alphamapHeight);
        terrainData.SetHeights(0, 0, matrix);
        terrainData.SetAlphamaps(0, 0, textureMap);
        this.terrain.terrainData = terrainData;
    }

    private void GenerateTerrain(float[,] matrix) {
        perlinSolitaryIsland = new PerlinSolitaryIsland(truncatedProportion, mountainProportion, frequency, octaves, maxHeight);
        perlinSolitaryIsland.DrawNormalize(matrix);
        Smooth(matrix, 2);
    }

    private void SetTerrain(TerrainData terrainData) {
        terrainData.size = new Vector3(width, depth, height);
        var alphaMapResolution = Mathf.Max(height, width);
        var heightMapResolution = Mathf.Max(height, width);
        var splatPrototypeArray = this.SetSplatPrototypes();
        SetResolutions(terrainData, alphaMapResolution, heightMapResolution);
        terrainData.splatPrototypes = splatPrototypeArray;
    }

    private void Smooth(float[,] heightMap, int iterationNum) {
        // Height = height
        // Width = width
        // 周囲のマスと自分の高さから平均化

        var dh = new[] { 1, -1, 0, 0 };
        var dw = new[] { 0, 0, 1, -1 };
        for (int iter = 0; iter < iterationNum; ++iter) {
            for (var h = 0; h < height; ++h) {
                for (var w = 0; w < width; ++w) {
                    // 配列の範囲内の8方向の高さを加算
                    var cumulative = 0;
                    float cumulativeValue = 0f;
                    for (int i = 0; i < 4; ++i) {
                        var nh = h + dh[i];
                        var nw = w + dw[i];

                        if (nh >= 0 && nw >= 0 && nh < height && nw < width) {
                            ++cumulative;
                            cumulativeValue += heightMap[nh, nw];
                        }
                    }

                    // 自分を足す
                    cumulativeValue += heightMap[h, w];
                    ++cumulative;
                    //                    Debug.Log(cumulativeValue);
                    heightMap[h, w] = (float)cumulativeValue / cumulative;
                }
            }
        }
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
                } else if (matrix[y, x] < 0.65f) {
                    map[y, x, 1] = 1f;
                } else {
                    map[y, x, 2] = 1f;
                }
            }
        }

        return map;
    }
}
