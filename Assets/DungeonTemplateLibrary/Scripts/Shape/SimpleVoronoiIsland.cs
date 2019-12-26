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

using DTL.Util;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Shape {
    public class SimpleVoronoiIsland : IDrawer<int> {
        private VoronoiDiagram voronoiDiagram;
        public int landValue { get; set; }
        public int seaValue { get; set; }

        public bool Draw(int[,] matrix) {
            return this.voronoiDiagram.Draw(matrix);
        }

        /* ダンジョン行列生成 (Create Dungeon Matrix) */

        public int[,] Create(int[,] matrix) {
            this.Draw(matrix);
            return matrix;
        }

        /* Clear */
        SimpleVoronoiIsland ClearPointX() {
            this.voronoiDiagram.ClearPointX();
            return this;
        }

        SimpleVoronoiIsland ClearPointY() {
            this.voronoiDiagram.ClearPointY();
            return this;
        }

        SimpleVoronoiIsland ClearWidth() {
            this.voronoiDiagram.ClearWidth();
            return this;
        }

        SimpleVoronoiIsland ClearHeight() {
            this.voronoiDiagram.ClearHeight();
            return this;
        }

        SimpleVoronoiIsland ClearValue() {
            this.voronoiDiagram.ClearHeight();
            return this;
        }

        SimpleVoronoiIsland ClearPoint() {
            this.ClearPointX();
            this.ClearPointY();
            return this;
        }

        SimpleVoronoiIsland ClearRange() {
            this.ClearPointX();
            this.ClearPointY();
            this.ClearWidth();
            this.ClearHeight();
            return this;
        }

        SimpleVoronoiIsland Clear() {
            this.ClearRange();
            this.ClearValue();
            return this;
        }


        /* Constructors */
        public SimpleVoronoiIsland() {
            voronoiDiagram = new VoronoiDiagram();
        } // default

        public SimpleVoronoiIsland(int voronoiNum) {
            voronoiDiagram = new VoronoiDiagram();
            voronoiDiagram.drawValue = voronoiNum;
        }

        public SimpleVoronoiIsland(int voronoiNum, double probabilityValue) {
            voronoiDiagram = new VoronoiDiagram();
            voronoiDiagram.drawValue = voronoiNum;
            voronoiDiagram.probabilityValue = probabilityValue;
        }

        public SimpleVoronoiIsland(int voronoiNum, double probabilityValue, int landValue) {
            voronoiDiagram = new VoronoiDiagram();
            voronoiDiagram.drawValue = voronoiNum;
            voronoiDiagram.probabilityValue = probabilityValue;
            voronoiDiagram.landValue = landValue;
        }

        public SimpleVoronoiIsland(int voronoiNum, double probabilityValue, int landValue, int seaValue) {
            voronoiDiagram = new VoronoiDiagram();
            voronoiDiagram.drawValue = voronoiNum;
            voronoiDiagram.probabilityValue = probabilityValue;
            voronoiDiagram.landValue = landValue;
            voronoiDiagram.seaValue = seaValue;
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange) {
            voronoiDiagram = new VoronoiDiagram(matrixRange);
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange, int voronoiNum) {
            voronoiDiagram = new VoronoiDiagram(matrixRange);
            voronoiDiagram.drawValue = voronoiNum;
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange, int voronoiNum, double probabilityValue) {
            voronoiDiagram = new VoronoiDiagram(matrixRange);
            voronoiDiagram.drawValue = voronoiNum;
            voronoiDiagram.probabilityValue = probabilityValue;
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange, int voronoiNum, double probabilityValue, int landValue) {
            voronoiDiagram = new VoronoiDiagram(matrixRange);
            voronoiDiagram.drawValue = voronoiNum;
            voronoiDiagram.probabilityValue = probabilityValue;
            voronoiDiagram.landValue = landValue;
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange, int voronoiNum, double probabilityValue, int landValue, int seaValue) {
            voronoiDiagram = new VoronoiDiagram(matrixRange);
            voronoiDiagram.drawValue = voronoiNum;
            voronoiDiagram.probabilityValue = probabilityValue;
            voronoiDiagram.landValue = landValue;
            voronoiDiagram.seaValue = seaValue;
        }

    }
}