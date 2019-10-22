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
using UnityEngine;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Range {
    /*#######################################################################################
        [概要] "dtl名前空間"とは"DungeonTemplateLibrary"の全ての機能が含まれる名前空間である。
        [Summary] The "dtl" is a namespace that contains all the functions of "DungeonTemplateLibrary".
    #######################################################################################*/

    public class RectBaseSimpleRogueLike {
        public uint startX { get; set; } = 0;
        public uint startY { get; set; } = 0;
        public uint width { get; set; } = 0;
        public uint height { get; set; } = 0;

        public int roomValue { get; set; }
        public int roadValue { get; set; }

        public uint divisionMin { get; private set; } = 3;
        public uint divisionRandMax { get; private set; } = 4;
        public uint roomMinX { get; private set; } = 5;
        public uint roomRandMaxX { get; private set; } = 2;
        public uint roomMinY { get; private set; } = 5;
        public uint roomRandMaxY { get; private set; } = 2;

        // 消去 (clear) //
        public RectBaseSimpleRogueLike ClearRoom() {
            roomValue = 0;
            return this;
        }

        public RectBaseSimpleRogueLike ClearWay() {
            roadValue = 0;
            return this;
        }

        public RectBaseSimpleRogueLike ClearRoad() {
            roadValue = 0;
            return this;
        }

        public RectBaseSimpleRogueLike ClearValue() {
            ClearRoom();
            ClearRoad();
            return this;
        }

        // 代入 (setter returns own instance) //

        public RectBaseSimpleRogueLike SetRoom(int roomValue) {
            this.roomValue = roomValue;
            return this;
        }

        public RectBaseSimpleRogueLike SetWay(int roadValue) {
            this.roadValue = roadValue;
            return this;
        }

        public RectBaseSimpleRogueLike SetRoad(int roadValue) {
            this.roadValue = roadValue;
            return this;
        }

        public RectBaseSimpleRogueLike SetRugueLike(uint divisionMin, uint divisionRandMax, uint roomMinX,
            uint roomRandMaxX, uint roomMinY, uint roomRandMaxY) {
            this.divisionMin = divisionMin;
            this.divisionRandMax = divisionRandMax;
            this.roomMinX = roomMinX;
            this.roomRandMaxX = roomRandMaxX;
            this.roomMinY = roomMinY;
            this.roomRandMaxY = roomRandMaxY;
            return this;
        }

        /* Constructors */
        public RectBaseSimpleRogueLike() { } // = default();

        public RectBaseSimpleRogueLike(int roomValue) {
            this.roomValue = roomValue;
        }

        public RectBaseSimpleRogueLike(int roomValue, int roadValue) {
            this.roomValue = roomValue;
            this.roadValue = roadValue;
        }

        public RectBaseSimpleRogueLike(int roomValue, int roadValue, uint divisionMin,
            uint divisionRandMax, uint roomMinX, uint roomRandMaxX, uint roomMinY, uint roomRandMaxY) {
            this.roomValue = roomValue;
            this.roadValue = roadValue;
            this.divisionMin = divisionMin;
            this.divisionRandMax = divisionRandMax;
            this.roomMinX = roomMinX;
            this.roomRandMaxX = roomRandMaxX;
            this.roomMinY = roomMinY;
            this.roomRandMaxY = roomRandMaxY;
        }

        public RectBaseSimpleRogueLike(MatrixRange matrixRange) {
            this.startX = (uint)matrixRange.x;
            this.startY = (uint)matrixRange.y;
            this.width = (uint)matrixRange.w;
            this.height = (uint)matrixRange.h;
        }

        public RectBaseSimpleRogueLike(MatrixRange matrixRange, int roomValue) : this(matrixRange) {
            this.roomValue = roomValue;
        }

        public RectBaseSimpleRogueLike(MatrixRange matrixRange, int roomValue, int roadValue) : this(matrixRange, roomValue) {
            this.roadValue = roadValue;
        }

        public RectBaseSimpleRogueLike(MatrixRange matrixRange, int roomValue, int roadValue, uint divisionMin,
            uint divisionRandMax, uint roomMinX, uint roomRandMaxX, uint roomMinY, uint roomRandMaxY)
            : this(matrixRange, roomValue, roadValue) {
            this.roomValue = roomValue;
            this.roadValue = roadValue;
            this.divisionMin = divisionMin;
            this.divisionRandMax = divisionRandMax;
            this.roomMinX = roomMinX;
            this.roomRandMaxX = roomRandMaxX;
            this.roomMinY = roomMinY;
            this.roomRandMaxY = roomRandMaxY;
        }

        // Vector2とかを引数に取るコンストラクタがあってもいいかもしれない
        // 使い方を要検討.
    }
}

