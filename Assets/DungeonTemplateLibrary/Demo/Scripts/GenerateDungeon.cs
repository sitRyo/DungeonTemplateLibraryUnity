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

public class GenerateDungeon : MonoBehaviour { 

    private SimpleRogueLike simpleRougeLike = new SimpleRogueLike(1, 2, 3, 4, 5, 2, 5, 2);
    private int width = 48;
    private int height = 36;


    void Start() {
        int[,] matrix = new int[height, width];
        simpleRougeLike.Draw(matrix);
        string s = "\n";
        for (int i = 0; i < height; ++i) {
            for (int j = 0; j < width; ++j) 
                s += matrix[i, j].ToString();
            s += "\n";
        }
        Debug.Log(s);
    }
}
