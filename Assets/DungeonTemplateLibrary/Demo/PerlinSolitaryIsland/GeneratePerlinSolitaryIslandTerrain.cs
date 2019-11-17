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
using DTL.Util;
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
        perlinSolitaryIsland =
            new PerlinSolitaryIsland(truncatedProportion, mountainProportion, frequency, octaves, maxHeight);
        this.terrain = GetComponent<Terrain>();
        TerrainUtil terrainUtil = new TerrainUtil(terrain, texture2D, perlinSolitaryIsland, height, width, depth);
        terrainUtil.Draw();
    }
}