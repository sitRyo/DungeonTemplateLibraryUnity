﻿/*#######################################################################################
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
using DTL.Util;
using DTL.Random;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Shape {
    public class SimpleVoronoiIsland : IDrawer<int> {
        private RandomBase rand = new RandomBase();
        private VoronoiDiagram voronoiDiagram;
        public int landValue { get; set; }
        public int seaValue { get; set; }
        public double probability { get; set; }

        bool isIsland(Pair point_, uint sx_, uint sy_, uint w_, uint h_, uint numerator_, uint denominator_) {
            return (int)point_.First > ((w_ - sx_) * numerator_ / denominator_ + sx_) &&
                   (int)point_.First < ((w_ - sx_) * (denominator_ - numerator_) / denominator_ + sx_) &&
                   (int)point_.Second > ((h_ - sy_) * numerator_ / denominator_ + sy_) &&
                   (int)point_.Second < ((h_ - sy_) * (denominator_ - numerator_) / denominator_ + sy_);
        }

        public bool Draw(int[,] matrix) {
            DTLDelegate.VoronoiDiagramDelegate voronoiDiagramDelegate =
                (ref Pair point, ref int color, uint startX, uint startY, uint w, uint h) => {
                    if ((this.isIsland(point, startX, startY, w, h, 2, 5) ||
                         this.isIsland(point, startX, startY, w, h, 1, 5)) &&
                        rand.Probability((this.probability)))
                        color = this.landValue;
                    else
                        color = this.seaValue;
                };

            return this.voronoiDiagram.Draw(matrix, voronoiDiagramDelegate);
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
            voronoiDiagram = new VoronoiDiagram(voronoiNum);
        }

        public SimpleVoronoiIsland(int voronoiNum, double probabilityValue) {
            voronoiDiagram = new VoronoiDiagram(voronoiNum);
            this.probability = probabilityValue;
        }

        public SimpleVoronoiIsland(int voronoiNum, double probabilityValue, int landValue) {
            voronoiDiagram = new VoronoiDiagram(voronoiNum);
            this.probability = probabilityValue;
            this.landValue = landValue;
        }

        public SimpleVoronoiIsland(int voronoiNum, double probabilityValue, int landValue, int seaValue) {
            voronoiDiagram = new VoronoiDiagram(voronoiNum);
            this.probability = probabilityValue;
            this.landValue = landValue;
            this.seaValue = seaValue;
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange) {
            voronoiDiagram = new VoronoiDiagram(matrixRange);
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange, int voronoiNum) {
            voronoiDiagram = new VoronoiDiagram(matrixRange, voronoiNum);
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange, int voronoiNum, double probabilityValue) {
            voronoiDiagram = new VoronoiDiagram(matrixRange, voronoiNum);
            this.probability = probabilityValue;
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange, int voronoiNum, double probabilityValue, int landValue) {
            voronoiDiagram = new VoronoiDiagram(matrixRange, voronoiNum);
            this.probability = probabilityValue;
            this.landValue = landValue;
        }

        public SimpleVoronoiIsland(MatrixRange matrixRange, int voronoiNum, double probabilityValue, int landValue, int seaValue) {
            voronoiDiagram = new VoronoiDiagram(matrixRange, voronoiNum);
            this.probability = probabilityValue;
            this.landValue = landValue;
            this.seaValue = seaValue;
        }

    }
}