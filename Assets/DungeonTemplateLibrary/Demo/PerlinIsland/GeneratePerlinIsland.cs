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

using DTL.Range;
using UnityEngine;
using DTL.Shape;

public class GeneratePerlinIsland : MonoBehaviour {
    private const int height = 48;
    private const int width = 48;

    private PerlinIsland perlinIsland;

    private void Start () {
        var matrix = new int[height, width];
        perlinIsland = new PerlinIsland(6.0, 8, 63);
        perlinIsland.Draw(matrix);
        ConsoleDraw(matrix, height, width);
    }

    private void ConsoleDraw(int[,] matrix, int h, int w) {
        string relt = "\n";
        for (int i = 0; i < h; ++i) {
            string str = "";
            for (int j = 0; j < w; ++j) {
                str += matrix[i, j].ToString() + " ";
            }

            relt += str + "\n";
        }

        Debug.Log(relt);
    }

}
