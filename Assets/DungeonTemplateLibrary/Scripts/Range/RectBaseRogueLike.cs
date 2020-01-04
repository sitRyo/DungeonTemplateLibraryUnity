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

using DTL.Base;
using DTL.Shape;
using DTL.Util;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Range {
    /*#######################################################################################
        [概要] "dtl名前空間"とは"DungeonTemplateLibrary"の全ての機能が含まれる名前空間である。
        [Summary] The "dtl" is a namespace that contains all the functions of "DungeonTemplateLibrary".
    #######################################################################################*/

    public class RectBaseRogueLike<TDerived> : BasicRect<RectBaseRogueLike<TDerived>>
        where TDerived : RectBaseRogueLike<TDerived> {
        public RogueLikeList rogueLikeList { get; protected set; }
        public uint maxWay { get; protected set; } = 20;
        protected MatrixRange roomRange = new MatrixRange(3, 3, 3, 3);
        protected MatrixRange wayRange = new MatrixRange(3, 3, 12, 12);

        /* Get Member Value */

        public int outsideWall {
            get { return this.rogueLikeList.outsideWallId; }
            protected set { this.rogueLikeList.outsideWallId = value; }
        }

        public int insideWall {
            get { return this.rogueLikeList.insideWallId; }
            protected set { this.rogueLikeList.insideWallId = value; }
        }

        public int room {
            get { return this.rogueLikeList.insideWallId; }
            protected set { this.rogueLikeList.roomId = value; }
        }

        public int entrance {
            get { return this.rogueLikeList.entranceId; }
            protected set { this.rogueLikeList.entranceId = value; }
        }

        public int way {
            get { return this.rogueLikeList.wayId; }
            protected set { this.rogueLikeList.wayId = value; }
        }

        public int wall {
            get { return this.rogueLikeList.outsideWallId; }
            protected set { this.rogueLikeList.outsideWallId = value; }
        }

        /* for method chaining */

        public TDerived GetOutsideWall(ref int value) {
            value = this.outsideWall;
            return (TDerived) this;
        }

        public TDerived GetInsideWall(ref int value) {
            value = this.insideWall;
            return (TDerived) this;
        }

        public TDerived GetRoom(ref int value) {
            value = this.room;
            return (TDerived) this;
        }

        public TDerived GetEntrance(ref int value) {
            value = this.entrance;
            return (TDerived) this;
        }

        public TDerived GetWay(ref int value) {
            value = this.way;
            return (TDerived) this;
        }

        public TDerived GetWall(ref int value) {
            value = this.wall;
            return (TDerived) this;
        }

        public TDerived GetMaxWay(ref uint value) {
            value = this.maxWay;
            return (TDerived) this;
        }

        public RogueLikeList GetValue() {
            return this.rogueLikeList;
        }

        public TDerived SetOutsideWall(ref int value) {
            this.outsideWall = value;
            return (TDerived) this;
        }

        public TDerived SetInsideWall(ref int value) {
            this.insideWall = value;
            return (TDerived) this;
        }

        public TDerived SetRoom(ref int value) {
            this.room = value;
            return (TDerived) this;
        }

        public TDerived SetEntrance(ref int value) {
            this.entrance = value;
            return (TDerived) this;
        }

        public TDerived SetWay(ref int value) {
            this.way = value;
            return (TDerived) this;
        }

        public TDerived SetWall(ref int value) {
            this.wall = value;
            return (TDerived) this;
        }

        public TDerived SetMaxWay(ref uint value) {
            this.maxWay = value;
            return (TDerived) this;
        }

        public TDerived SetValue(RogueLikeList rogueLikeList) {
            this.rogueLikeList = rogueLikeList;
            return (TDerived) this;
        }

        /* Clear */
        public TDerived ClearOutsideWall() {
            this.rogueLikeList.outsideWallId = 0;
            return (TDerived) this;
        }

        public TDerived ClearInsideWall() {
            this.rogueLikeList.insideWallId = 0;
            return (TDerived) this;
        }

        public TDerived ClearRoom() {
            this.rogueLikeList.roomId = 0;
            return (TDerived) this;
        }

        public TDerived ClearEntrance() {
            this.rogueLikeList.entranceId = 0;
            return (TDerived) this;
        }

        public TDerived ClearWall() {
            ClearInsideWall();
            ClearOutsideWall();
            return (TDerived) this;
        }

        public TDerived ClearMaxWay() {
            this.maxWay = 0;
            return (TDerived) this;
        }

        public TDerived ClearValue() {
            this.rogueLikeList = new RogueLikeList();
            ClearMaxWay();
            return (TDerived) this;
        }

        public TDerived Clear() {
            this.ClearRange();
            this.ClearValue();
            return (TDerived) this;
        }

        /* Constructors */

        public RectBaseRogueLike() {
        } // = default();

        public RectBaseRogueLike(MatrixRange matrixRange) : base(matrixRange) {
        }

        public RectBaseRogueLike(uint startX, uint startY, uint width, uint height) : base(startX, startY, width,
            height) {
        }

        public RectBaseRogueLike(RogueLikeList drawValue) {
            this.rogueLikeList = drawValue;
        }

        public RectBaseRogueLike(RogueLikeList drawValue, uint maxWay) {
            this.rogueLikeList = drawValue;
            this.maxWay = maxWay;
        }

        public RectBaseRogueLike(RogueLikeList drawValue, uint maxWay, MatrixRange roomRange) {
            this.rogueLikeList = drawValue;
            this.maxWay = maxWay;
            this.roomRange = roomRange;
        }

        public RectBaseRogueLike(RogueLikeList drawValue, uint maxWay, MatrixRange roomRange, MatrixRange wayRange) {
            this.rogueLikeList = drawValue;
            this.maxWay = maxWay;
            this.roomRange = roomRange;
            this.wayRange = wayRange;
        }

        public RectBaseRogueLike(int outsideWallId, int insideWallId, int roomId, int entranceId, int wayId) {
            this.rogueLikeList = new RogueLikeList(outsideWallId, insideWallId, roomId, entranceId, wayId);
        }

        public RectBaseRogueLike(int outsideWallId, int insideWallId, int roomId, int entranceId, int wayId,
            uint maxWay) {
            this.rogueLikeList = new RogueLikeList(outsideWallId, insideWallId, roomId, entranceId, wayId);
            this.maxWay = maxWay;
        }


        public RectBaseRogueLike(int outsideWallId, int insideWallId, int roomId, int entranceId, int wayId,
            uint maxWay, MatrixRange roomRange) {
            this.rogueLikeList = new RogueLikeList(outsideWallId, insideWallId, roomId, entranceId, wayId);
            this.maxWay = maxWay;
            this.roomRange = roomRange;
        }

        public RectBaseRogueLike(int outsideWallId, int insideWallId, int roomId, int entranceId, int wayId,
            uint maxWay, MatrixRange roomRange, MatrixRange wayRange) {
            this.rogueLikeList = new RogueLikeList(outsideWallId, insideWallId, roomId, entranceId, wayId);
            this.maxWay = maxWay;
            this.roomRange = roomRange;
            this.wayRange = wayRange;
        }

        public RectBaseRogueLike(MatrixRange matrixRange, RogueLikeList drawValue, uint maxWay) : base(matrixRange) {
            this.rogueLikeList = drawValue;
            this.maxWay = maxWay;
        }

        public RectBaseRogueLike(MatrixRange matrixRange, RogueLikeList drawValue, uint maxWay, MatrixRange roomRange) :
            base(matrixRange) {
            this.rogueLikeList = drawValue;
            this.roomRange = roomRange;
            this.maxWay = maxWay;
        }

        public RectBaseRogueLike(MatrixRange matrixRange, RogueLikeList drawValue, uint maxWay, MatrixRange roomRange,
            MatrixRange wayRange) : base(matrixRange) {
            this.rogueLikeList = drawValue;
            this.roomRange = roomRange;
            this.wayRange = wayRange;
            this.maxWay = maxWay;
        }

        public RectBaseRogueLike(uint startX, uint startY, uint width, uint height, RogueLikeList drawValue,
            uint maxWay) : base(startX, startY, width, height) {
            this.rogueLikeList = drawValue;
            this.maxWay = maxWay;
        }

        public RectBaseRogueLike(uint startX, uint startY, uint width, uint height, RogueLikeList drawValue,
            uint maxWay, MatrixRange roomRange) : base(startX, startY, width, height) {
            this.rogueLikeList = drawValue;
            this.maxWay = maxWay;
            this.roomRange = roomRange;
        }

        public RectBaseRogueLike(uint startX, uint startY, uint width, uint height, RogueLikeList drawValue,
            uint maxWay, MatrixRange roomRange, MatrixRange wayRange) : base(startX, startY, width, height) {
            this.rogueLikeList = drawValue;
            this.maxWay = maxWay;
            this.roomRange = roomRange;
            this.wayRange = wayRange;
        }
    }
}