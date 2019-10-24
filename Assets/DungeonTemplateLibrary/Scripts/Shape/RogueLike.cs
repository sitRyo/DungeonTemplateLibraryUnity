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
using System.Collections.Generic;
using System.Linq;
using DTL.Random;
using DTL.Util;

namespace DTL.Shape {
    /*#######################################################################################
        [概要] "dtl名前空間"とは"DungeonTemplateLibrary"の全ての機能が含まれる名前空間である。
        [Summary] The "dtl" is a namespace that contains all the functions of "DungeonTemplateLibrary".
    #######################################################################################*/

    class RogueLikeOutputNumber {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }

        public RogueLikeOutputNumber() {
        } // = default()

        public RogueLikeOutputNumber(int x, int y, int w, int h) {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
    }

    /* The type of array to store dungeon data is int[,] */

    public class RogueLike : DTL.Range.RectBaseRogueLike<RogueLike> {
        private DTLRandom rand = new DTLRandom();

        enum Direction : uint {
            North,
            South,
            West,
            East,
            Count,
        }

        private readonly uint directionCount = 4;

        /* 基本処理 */
        bool DrawNormal(int[,] matrix) {
            if (this.roomRange.w < 1 || this.roomRange.h < 1 || this.wayRange.w < 1 || this.wayRange.h < 1)
                return false;

            var endX = MatrixUtil.GetX(matrix);
            var endY = MatrixUtil.GetY(matrix);

            var sizeX = endX - this.startX;
            var sizeY = endY - this.startY;

            var roomRect = new List<RogueLikeOutputNumber>();
            var branchPoint = new List<RogueLikeOutputNumber>();
            var isWay = new List<bool>();

            // 最初の部屋を生成
            if (!MakeRoom(matrix, sizeX, sizeY, roomRect, branchPoint, isWay, (int)sizeX / 2, (int)sizeY / 2,
                (Direction) rand.Next(directionCount))) return false;

            // 機能配置
            for (uint i = 1; i < maxWay; ++i) {
                if (!createNext2(matrix, sizeX, sizeY, roomRect, branchPoint, isWay)) break;
            }

            return true;
        }

        private bool createNext2(int[,] matrix, uint sizeX, uint sizeY, List<RogueLikeOutputNumber> roomRect,
            List<RogueLikeOutputNumber> branchPoint, List<bool> isWay) {
            /* 0xffff = 65536 までループを回す */
            for (int i = 0, r = 0; i < 65536; ++i) {
                if (!branchPoint.Any()) break;

                r = rand.Next(branchPoint.Count());
                int x = rand.Next(branchPoint[r].x, branchPoint[r].x + branchPoint[r].w - 1);
                int y = rand.Next(branchPoint[r].y, branchPoint[r].y + branchPoint[r].h - 1);

                // 方角カウンタ
                for (int j = 0; j < (int) Direction.Count; ++j) {
                    if (!createNext(matrix, sizeX, sizeY, roomRect, branchPoint, isWay, isWay[r], x, y,
                        (Direction) j)) continue;
                    branchPoint.RemoveAt(r);
                    isWay.RemoveAt(r);
                    return true;
                }
            }

            return false;
        }

        private bool createNext(int[,] matrix, uint sizeX, uint sizeY, List<RogueLikeOutputNumber> roomRect,
            List<RogueLikeOutputNumber> branchPoint, List<bool> isWayList, bool isWay, int x_, int y_, Direction dir_) {
            int dx = 0;
            int dy = 0;

            switch (dir_) {
                case Direction.North:
                    dy = 1;
                    break;
                case Direction.South:
                    dy = -1;
                    break;
                case Direction.West:
                    dx = 1;
                    break;
                case Direction.East:
                    dx = -1;
                    break;
            }

            if (matrix[startX + x_ + dx, startY + y_ + dy] != rogueLikeList.roomId &&
                matrix[startX + x_ + dx, startY + y_ + dy] != rogueLikeList.wayId) return false;

            if (!isWay) {
                if (!makeWay(matrix, sizeX, sizeY, branchPoint, isWayList, x_, y_, dir_)) return false;
                if (matrix[startX + x_ + dx, startY + y_ + dy] == rogueLikeList.roomId)
                    matrix[x_, y_] = rogueLikeList.entranceId;
                else matrix[x_, y_] = rogueLikeList.wayId;
            }

            // 1/2
            if (rand.Probability(0.5)) {
                if (!MakeRoom(matrix, sizeX, sizeY, roomRect, branchPoint, isWayList, x_, y_, dir_)) return false;
                if (matrix[startX + x_ + dx, startY + y_ + dy] == rogueLikeList.roomId) {
                    matrix[x_, y_] = rogueLikeList.entranceId;
                }
                else {
                    matrix[x_, y_] = rogueLikeList.wayId;
                }

                return true;
            }

            // 通路を生成
            if (!makeWay(matrix, sizeX, sizeY, branchPoint, isWayList, x_, y_, dir_)) return false;
            if (matrix[startX + x_ + dx, startY + y_ + dy] == rogueLikeList.roomId) {
                matrix[x_, y_] = rogueLikeList.entranceId;
            }
            else {
                matrix[x_, y_] = rogueLikeList.wayId;
            }

            return true;
        }

        private bool makeWay(int[,] matrix, uint sizeX, uint sizeY, List<RogueLikeOutputNumber> branchPoint, List<bool> isWay,
            int x_, int y_, Direction dir_) {
            RogueLikeOutputNumber way = new RogueLikeOutputNumber();
            way.x = x_;
            way.y = y_;

            // 左右
            if (rand.Probability(0.5)) {
                way.w = rand.Next(wayRange.x, wayRange.x + wayRange.w - 1);
                way.h = 1;
                switch (dir_) {
                    case Direction.North:
                        way.y = y_ - 1;
                        if (rand.Probability(0.5)) way.x = x_ - way.w + 1;
                        break;
                    case Direction.South:
                        way.y = y_ + 1;
                        if (rand.Probability(0.5)) way.x = x_ - way.w + 1;
                        break;
                    case Direction.West:
                        way.x = x_ - way.x;
                        break;
                    case Direction.East:
                        way.x = x_ + 1;
                        break;
                }
            }

            // 上下
            if (rand.Probability(0.5)) {
                way.w = 1;
                way.h = rand.Next(wayRange.y, wayRange.y + wayRange.h - 1);

                switch (dir_) {
                    case Direction.North:
                        way.y = y_ - way.h;
                        break;
                    case Direction.South:
                        way.y = y_ + 1;
                        break;
                    case Direction.West:
                        way.x = x_ - 1;
                        if (rand.Probability(0.5))
                            way.y = y_ - way.h + 1;
                        break;
                    case Direction.East:
                        way.x = x_ + 1;
                        if (rand.Probability(0.5))
                            way.y = y_ - way.h + 1;
                        break;
                }
            }

            if (PlaceOutputNumber(matrix, sizeX, sizeY, way, rogueLikeList.wayId)) return false;
            if (dir_ != Direction.South && way.w != 1) {
                branchPoint.Add(new RogueLikeOutputNumber(way.x, way.y - 1, way.w, 1));
                isWay.Add(true);
            }

            if (dir_ != Direction.North && way.w != 1) {
                branchPoint.Add(new RogueLikeOutputNumber(way.x, way.y + way.h, way.w, 1));
                isWay.Add(true);
            }

            if (dir_ != Direction.East && way.h != 1) {
                branchPoint.Add(new RogueLikeOutputNumber(way.x - 1, way.y, 1, way.h));
                isWay.Add(true);
            }

            if (dir_ != Direction.West && way.h != 1) {
                branchPoint.Add(new RogueLikeOutputNumber(way.x + way.w, way.y, 1, way.h));
                isWay.Add(true);
            }

            return true;
        }

        private bool MakeRoom(int[,] matrix, uint sizeX, uint sizeY, List<RogueLikeOutputNumber> roomRect,
            List<RogueLikeOutputNumber> branchPoint, List<bool> isWay, int x_, int y_, Direction dir_,
            bool firstRoom = false) {
            var room = new RogueLikeOutputNumber();
            room.w = rand.Next(roomRange.x, roomRange.x + roomRange.w - 1);
            room.h = rand.Next(roomRange.y, roomRange.y + roomRange.h - 1);

            switch (dir_) {
                case Direction.North:
                    room.x = (int) x_ - room.w / 2;
                    room.y = (int) y_ - room.h;
                    break;
                case Direction.South:
                    room.x = (int) x_ - room.w / 2;
                    room.y = (int) y_ + 1;
                    break;
                case Direction.West:
                    room.x = (int) x_ - room.w;
                    room.y = (int) y_ - room.h / 2;
                    break;
                case Direction.East:
                    room.x = (int) x_ + 1;
                    room.y = (int) y_ + room.h / 2;
                    break;
            }

            if (PlaceOutputNumber(matrix, sizeX, sizeY, room, rogueLikeList.roomId)) {
                roomRect.Add(room);
                if (dir_ != Direction.South || firstRoom) {
                    branchPoint.Add(new RogueLikeOutputNumber(room.x, room.y - 1, room.w, 1));
                    isWay.Add(false);
                }

                if (dir_ != Direction.North || firstRoom) {
                    branchPoint.Add(new RogueLikeOutputNumber(room.x, room.y + room.h, room.w, 1));
                    isWay.Add(false);
                }

                if (dir_ != Direction.East || firstRoom) {
                    branchPoint.Add(new RogueLikeOutputNumber(room.x - 1, room.y, 1, room.h));
                    isWay.Add(false);
                }

                if (dir_ != Direction.West || firstRoom) {
                    branchPoint.Add(new RogueLikeOutputNumber(room.x + room.w, room.y, 1, room.h));
                    isWay.Add(false);
                }

                return true;
            }

            return false;
        }

        private bool PlaceOutputNumber(int[,] matrix, uint sizeX, uint sizeY, RogueLikeOutputNumber rect, int tile) {
            if (rect.x < 1 || rect.y < 1 || rect.x + rect.w > sizeX - 1 || rect.y + rect.h > sizeY - 1) return false;

            for (int y = rect.y; y < rect.y + rect.h; ++y) {
                for (int x = rect.x; x < rect.x + rect.w; ++x) {
                    if (matrix[startY + y, startX + x] != rogueLikeList.outsideWallId) return false;
                }
            }

            for (int y = rect.y - 1; y < rect.y + rect.h + 1; ++y) {
                for (int x = rect.x - 1; x < rect.x + rect.w + 1; ++x) {
                    if (y == rect.y - 1 || x == rect.x - 1 || y == rect.y + rect.h || x == rect.x + rect.w) {
                        matrix[y, x] = rogueLikeList.insideWallId;
                    }
                    else {
                        matrix[y, x] = tile;
                    }
                }
            }

            return true;
        }
    }
}