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

namespace DTL.Base {
    /*#######################################################################################
        [概要] 'Coordinate3Dimensional' は3次元の座標を表すクラス。
        [Summary] 'Coordinate3Dimensional' represents 3D coordinates.
    #######################################################################################*/
    public class Coordinate3Dimensional<T> : IEquatable<Coordinate3Dimensional<T>> where T : struct {
        private T x { get; set; }
        private T y { get; set; }
        private T z { get; set; }

        public Coordinate3Dimensional(T x, T y, T z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public bool Equals(Coordinate3Dimensional<T> others) {
            if (others == null || this.GetType().Equals(others.GetType())) {
                return false;
            }

            return (EqualityComparer<T>.Default.Equals(x, others.x) && 
                    EqualityComparer<T>.Default.Equals(y, others.y) && 
                    EqualityComparer<T>.Default.Equals(z, others.z));
        }

        public override bool Equals(object obj) {
            return Equals(obj);
        }

        public static bool operator ==(Coordinate3Dimensional<T> lhs, Coordinate3Dimensional<T> rhs) {
            return lhs != null && lhs.Equals(rhs);
        }

        public static bool operator !=(Coordinate3Dimensional<T> lhs, Coordinate3Dimensional<T> rhs) {
            return lhs == null || !lhs.Equals(rhs);
        }
    }
}