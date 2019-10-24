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
using DTL.Random;

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

        public RogueLikeOutputNumber() {} // = default()

        public RogueLikeOutputNumber(int x, int y, int w, int h) {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
    }

    public class RogueLike : DTL.Range.RectBaseRogueLike<RogueLike> {
        private DTLRandom rand = new DTLRandom();

        enum Direction : uint {
            DirectionNorth,
            DirectionSouth,
            DirectionWest,
            DirectionEast,
            DirectionCount,
        }

        /* 基本処理 */

/*        public bool drawNormal(int[,] matrix) {
            if (this.roomRange.w < 1 || this.roomRange.h < 1 || this.wayRange.w < 1 || this.wayRange.h < 1)
                return false;

        }*/
    }

}


