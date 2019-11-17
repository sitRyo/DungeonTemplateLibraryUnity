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
using DTL.Util;

public class GeneratePerlinIslandTerrain : MonoBehaviour {
    public int depth = 50;
    public int height = 200;
    public int width = 200;
    public double frequency = 6.0;
    public uint octaves = 8;
    public int maxHeight = 150;

    private Terrain terrain;
    private PerlinIsland perlinIsland;

    public List<Texture2D> texture2D = new List<Texture2D>();

    void Start() {
        perlinIsland = new PerlinIsland(frequency, octaves, maxHeight);
        this.terrain = GetComponent<Terrain>();
        TerrainUtil terrainUtil = new TerrainUtil(terrain, texture2D, perlinIsland, height, width, depth);
        terrainUtil.Draw();
    }
}