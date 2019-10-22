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

    public class Coordinate2DimensionalAndLength2Dimensional : 
        IEquatable<Coordinate2DimensionalAndLength2Dimensional>,
        IComparable<Coordinate2DimensionalAndLength2Dimensional> {

        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }

        public Coordinate2DimensionalAndLength2Dimensional() { } 

        public Coordinate2DimensionalAndLength2Dimensional(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Coordinate2DimensionalAndLength2Dimensional(int x, int y, int w) : this(x, y) {
            this.w = w;
        }

        public Coordinate2DimensionalAndLength2Dimensional(int x, int y, int w, int h) : this(x, y, w) {
            this.h = h;
        }

        // Check 'Value Equation'
        public bool Equals(Coordinate2DimensionalAndLength2Dimensional others) {
            if (others == null || !this.GetType().Equals(others.GetType())) {
                return false;
            }

            return (x.Equals(others.x) && y.Equals(others.y) && w.Equals(others.w) && h.Equals(others.h));
        }

        public override bool Equals(Object obj) {
            return this.Equals(obj);
        }

        public int CompareTo(Coordinate2DimensionalAndLength2Dimensional other) {
            return w * h - other.w * other.h;
        }

        public static bool operator ==(Coordinate2DimensionalAndLength2Dimensional lhs,
            Coordinate2DimensionalAndLength2Dimensional rhs) {
            return lhs != null && lhs.Equals(rhs);
        }

        public static bool operator !=(Coordinate2DimensionalAndLength2Dimensional lhs,
            Coordinate2DimensionalAndLength2Dimensional rhs) {
            return lhs != null && !lhs.Equals(rhs);
        }

        public static bool operator >(Coordinate2DimensionalAndLength2Dimensional lhs,
            Coordinate2DimensionalAndLength2Dimensional rhs) {
            return lhs != null && rhs != null && lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(Coordinate2DimensionalAndLength2Dimensional lhs,
            Coordinate2DimensionalAndLength2Dimensional rhs) {
            return lhs != null && rhs != null && lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(Coordinate2DimensionalAndLength2Dimensional lhs,
            Coordinate2DimensionalAndLength2Dimensional rhs) {
            return lhs != null && rhs != null && lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(Coordinate2DimensionalAndLength2Dimensional lhs,
            Coordinate2DimensionalAndLength2Dimensional rhs) {
            return lhs != null && rhs != null && lhs.CompareTo(rhs) <= 0;
        }

    }
}