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

namespace DTL.Random {

    /* Xorshift: generates random numbers */
    public class XorShift128 {
        private System.Random rand;

        private uint x = 31419265;
        private uint y = 358979323;
        private uint z = 846264338;
        private uint w;

        public uint Min() {
            return System.UInt32.MinValue;
        }

        public uint Max() {
            return System.UInt32.MaxValue;
        }

        public uint Next() {
            var t = x ^ (x << 11);
            x = y;
            y = z;
            z = w;
            return w = (w ^ (w >> 19)) ^ (t ^ (t << 8));
        }

        // Generate random number between [min, max). Note! max >= min
        public uint Next(uint min, uint max) {
            return min + Next() % (max - min);
        }

        public XorShift128(uint? w = null) {
            if (w == null) {
                rand = new System.Random();
                w = (uint)rand.Next();
            }
            else {
                rand = new System.Random((int)w);
                w = (uint) rand.Next();
            }
        }
    }
}