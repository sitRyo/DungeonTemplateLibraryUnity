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

using DTL.Random;

namespace DTL.Util {
    public static class ArrayUtil {


        static void Swap<T>(ref T a, ref T b) {
            T tmp;
            tmp = a;
            a = b;
            b = tmp;
        }

        public static T[] Shuffle<T>(T[] array) {
            int arrayLength = array.Length;
            XorShift128 rand = new XorShift128();
            for (int i = 0; i < arrayLength; ++i) {
                Swap(ref array[i], ref array[rand.Next(0, (uint)arrayLength)]);
            }

            return array;
        }

        // shuffle array from 0 to max - 1 =- [0, max)
        public static T[] Shuffle<T>(T[] array, uint max) {
            int arrayLength = array.Length;
            max = max > arrayLength ? (uint)arrayLength : max;
            XorShift128 rand = new XorShift128();
            for (int i = 0; i < max; ++i) {
                Swap(ref array[i], ref array[rand.Next(0, max)]);
            }

            return array;
        }
    }
}