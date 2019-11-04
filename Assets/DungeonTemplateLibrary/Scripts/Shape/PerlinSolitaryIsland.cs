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
using DTL.Random;
using DTL.Range;
using DTL.Util;

namespace DTL.Shape {
    public class PerlinSolitaryIsland : RectBasePerlinSolitary<PerlinSolitaryIsland>, IDrawer<int> {
        private XorShift128 rand = new XorShift128();

        public bool Draw(int[,] matrix) {
            return DrawNormal(matrix);
        }

        private bool DrawNormal(int[,] matrix) {
            if (this.mountainProportion < 0.0 || this.mountainProportion > 1.0) return false;
            if (this.truncatedProportion <= 0.0 || this.truncatedProportion > 1.0) return false;
            uint endX = CalcEndX(MatrixUtil.GetX(matrix));
            uint endY = CalcEndY(MatrixUtil.GetY(matrix));
            uint midX = endX / 2;
            uint midY = endY / 2;

            int perlinHeight = (int) ((double) (maxHeight - minHeight) * (1.0 - mountainProportion));
            int truncatedHeight = (int) ((double) (maxHeight - minHeight) * mountainProportion);
            int pyramidHeight = (int) (truncatedHeight / truncatedProportion);

            PerlinNoise perlinNoise = new PerlinNoise();
            double frequencyX = (endX - this.startX) / this.frequency;
            double frequencyY = (endX - this.startY) / this.frequency;

            for (var row = startY; row < endY; ++row) {
                var row2 = row > midY ? endY - row - 1 : row;
                for (var col = startX; col < endX; ++col) {
                    var col2 = col > midX ? endX - col - 1 : col;
                    int setValue = Math.Min((int) ((pyramidHeight * row2) / midY),
                        (int) ((pyramidHeight * col2) / midX));
                    matrix[row, col] = this.minHeight + ((setValue > truncatedHeight) ? truncatedHeight : setValue) +
                                       (int) (perlinHeight * perlinNoise.OctaveNoise(this.octaves, col / frequencyX,
                                                  row / frequencyY));
                }
            }

            return true;
        }

        public bool DrawNormalize(float[,] matrix) {
            int[,] convertedMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            // I cannot use LINQ for 2 dim array. Please tell me how to use LINQ for 2 dim array...orz
            for (int y = 0; y < MatrixUtil.GetY(matrix); ++y) {
                for (int x = 0; x < MatrixUtil.GetX(matrix); ++x) {
                    convertedMatrix[y, x] = (int)matrix[y, x];
                }
            }
            DrawNormal(convertedMatrix);
            Normalize(convertedMatrix, matrix);
            return true;
        }

        private void Normalize(int[,] matrix, float[,] retMatrix) {
            // use maxHeight from derived class.
            for (int y = 0; y < MatrixUtil.GetY(matrix); ++y) {
                for (int x = 0; x < MatrixUtil.GetX(matrix); ++x) {
                    retMatrix[y, x] = (float)matrix[y, x] / maxHeight;
                }
            }
        }
    }
}