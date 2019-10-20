using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTL.Shape;

public class GenerateDungeon : MonoBehaviour {
    private SimpleRogueLike simpleRougeLike = new SimpleRogueLike(1, 2, 3, 4, 5, 2, 5, 2);

    void Start() {
        int width = 36;
        int height = 48;
        int[,] matrix = new int[height, width];
        simpleRougeLike.Draw(matrix);
        string s = "\n";
        for (int i = 0; i < height; ++i) {

            for (int j = 0; j < width; ++j) {
                s += matrix[i, j].ToString();
//                if (matrix[i, j] == 1)
                //                  s += "#".ToString();
                //            else if (matrix[i, j] == 2) {
                //            s += "%".ToString();
                //          }
                //  else {
                //          s += "//";
                //    }
            }

            s += "\n";
        }
        Debug.Log(s);
    }


    void Update() {
        
    }
}
