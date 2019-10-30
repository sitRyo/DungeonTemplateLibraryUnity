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
using DTL.Random;
using DTL.Util;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Shape {
    public class PerlinIsland : RectBasePerlin<PerlinIsland>, IDrawer<int> {
        private XorShift128 rand = new XorShift128();

        public bool Draw(int[,] matrix) {
            return DrawNormal(matrix);
        }

        private bool DrawNormal(int[,] matrix) {
            uint endX = CalcEndX(MatrixUtil.GetX(matrix));
            uint endY = CalcEndY(MatrixUtil.GetY(matrix));

            PerlinNoise perlin = new PerlinNoise((int) rand.Next());

            double frequencyX = (endX - startX) / frequency;
            double frequencyY = (endY - startY) / frequency;

//            Debug.Log(frequencyX + " " + maxHeight);

            for (uint row = startY; row < endY; ++row) {
                for (uint col = startX; col < endX; ++col) {
                    matrix[row, col] = minHeight + minHeight + (int)((double)(maxHeight - minHeight) *
                                       perlin.OctaveNoise(octaves, (col / frequencyX),
                                           (row / frequencyY)));
                }
            }

            return true;
        }

        public PerlinIsland() {
        } // = default()

        public PerlinIsland(uint startX, uint startY, uint width, uint height) : base(startX, startY, width, height) {
        }

        public PerlinIsland(double frequency) {
            this.frequency = frequency;
        }

        public PerlinIsland(double frequency, uint octaves) : base(frequency, octaves) {
        }

        public PerlinIsland(double frequency, uint octaves, int maxHeight) {
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
        }

        public PerlinIsland(double frequency, uint octaves, int maxHeight, int minHeight) : base(frequency, octaves,
            maxHeight, minHeight) {
        }

        public PerlinIsland(MatrixRange matrixRange, double frequency) : base(matrixRange, frequency) {
        }

        public PerlinIsland(MatrixRange matrixRange, double frequency, uint octaves) : base(matrixRange, frequency,
            octaves) {
        }

        public PerlinIsland(MatrixRange matrixRange, double frequency, uint octaves, int maxHeight) : base(
            matrixRange, frequency, octaves, maxHeight) {
        }

        public PerlinIsland(MatrixRange matrixRange, double frequency, uint octaves, int maxHeight, int minHeight) :
            base(matrixRange, frequency, octaves, maxHeight, minHeight) {
        }

        public PerlinIsland(uint startX, uint startY, uint width, uint height, double frequency) : base(startX, startY,
            width, height, frequency) {
        }

        public PerlinIsland(uint startX, uint startY, uint width, uint height, double frequency, uint octaves) : base(
            startX, startY, width, height, frequency, octaves) {
        }

        public PerlinIsland(uint startX, uint startY, uint width, uint height, double frequency, uint octaves,
            int maxHeight) : base(startX, startY, width, height, frequency, octaves, maxHeight) {
        }

        public PerlinIsland(uint startX, uint startY, uint width, uint height, double frequency, uint octaves,
            int maxHeight, int minHeight) : base(startX, startY, width, height, frequency, octaves, maxHeight,
            minHeight) {
        }
    }
}