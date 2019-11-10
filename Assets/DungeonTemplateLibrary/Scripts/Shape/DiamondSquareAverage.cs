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

namespace DTL.Shape {
    public static class DiamondSquareAverage {

        // Diamond Square
        public static void CreateDiamondSquareAverage<TRand>(int[,] matrix_, uint startX, uint startY,
            uint x_, uint y_, uint size_, int t1_, int t2_, int t3_, int t4_, int maxValue_, int addAltitude_,
            TRand rand, Func<int, int> func) where TRand : IRandomable {
            // 再起の終了処理
            if (size_ == 0) return;
            int vertexRand = (int) rand.Next((uint) addAltitude_);
            int vertexHeight = (int) rand.Next((uint) (t1_ / 4 + t2_ / 4 + t3_ / 4 + t4_ / 4));
            matrix_[startY + y_, startX + x_] = vertexHeight + vertexRand;

            int s1 = (int) rand.Next((uint) (t1_ / 2 + t2_ / 2));
            int s2 = (int) rand.Next((uint) (t1_ / 2 + t3_ / 2));
            int s3 = (int) rand.Next((uint) (t2_ / 2 + t4_ / 2));
            int s4 = (int) rand.Next((uint) (t3_ / 2 + t4_ / 2));

            matrix_[startY + y_ + size_, startX + x_] = s3;
            matrix_[startY + y_ - size_, startX + x_] = s2;
            matrix_[startY + y_, startX + x_ + size_] = s4;
            matrix_[startY + y_, startX + x_ - size_] = s1;
            size_ /= 2;

            CreateDiamondSquareAverage(matrix_, startX, startY, x_ - size_, y_ - size_, size_, t1_, s1, s2,
                matrix_[startY + y_, startX + x_], maxValue_, func(addAltitude_), rand, func);
            CreateDiamondSquareAverage(matrix_, startX, startY, x_ - size_, y_ + size_, size_, s1, t2_,
                matrix_[startY + y_, startX + x_], s3, maxValue_, func(addAltitude_), rand, func);
            CreateDiamondSquareAverage(matrix_, startX, startY, x_ + size_, y_ - size_, size_, s2,
                matrix_[startY + y_, startX + x_], t3_, s4, maxValue_, func(addAltitude_), rand, func);
            CreateDiamondSquareAverage(matrix_, startX, startY, x_ + size_, y_ + size_, size_,
                matrix_[startY + y_, startX + x_], s3, s4, t4_, maxValue_, func(addAltitude_), rand, func);
        }
    }
}