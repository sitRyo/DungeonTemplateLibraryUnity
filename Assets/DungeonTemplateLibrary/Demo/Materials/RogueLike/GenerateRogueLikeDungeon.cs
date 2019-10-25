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

using UnityEngine;
using DTL.Shape;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

public class GenerateRogueLikeDungeon : MonoBehaviour {
    private readonly int height = 32;
    private readonly int width = 48;

    RogueLike rogueLike = new RogueLike(0, 1, 2, 3, 4, 20,
        new MatrixRange(3, 3, 2, 2), new MatrixRange(3, 3, 4, 4));

    void Start() {
        int[,] matrix = new int[height, width];
        rogueLike.Draw(matrix);
        ConsoleDraw(matrix);
    }

    private void ConsoleDraw(int[,] matrix) {
        string s = "\n";
        for (int i = 0; i < height; ++i) {
            for (int j = 0; j < width; ++j)
                s += matrix[i, j].ToString();
            s += "\n";
        }
        Debug.Log(s);
    }

}