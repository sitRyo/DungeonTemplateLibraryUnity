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

    public class Coordinate2DimensionalAndLength2Dimensional<T> : 
        IEquatable<Coordinate2DimensionalAndLength2Dimensional<T>>,
        IComparable<Coordinate2DimensionalAndLength2Dimensional<T>> 
        where T : IComparable<T>, IEquatable<T> {

        // for generics arithmetic operations.
        // NOTE! throws new NotSupportedException() when T is not support generic arithmetic operations(Now, only supports primitive type (like int, double...))
        public static GenericOperations<T> genericOperations = new GenericOperations<T>();

        private T x { get; set; }
        private T y { get; set; }
        private T w { get; set; }
        private T h { get; set; }

        public Coordinate2DimensionalAndLength2Dimensional() {
            //            genericOperations = new GenericOperations<T>(); // throws new NotSupportedException();
        } // = default()

        public Coordinate2DimensionalAndLength2Dimensional(T x, T y) {
            this.x = x;
            this.y = y;
        }

        public Coordinate2DimensionalAndLength2Dimensional(T x, T y, T w) : this(x, y) {
            this.w = w;
        }

        public Coordinate2DimensionalAndLength2Dimensional(T x, T y, T w, T h) : this(x, y, w) {
            this.h = h;
        }

        // Check 'Value Equation'
        public bool Equals(Coordinate2DimensionalAndLength2Dimensional<T> others) {
            if (others == null || !this.GetType().Equals(others.GetType())) {
                return false;
            }

            return (x.Equals(others.x) && y.Equals(others.y) && w.Equals(others.w) && h.Equals(others.h));
        }

        public override bool Equals(Object obj) {
            return this.Equals(obj);
        }

        public int CompareTo(Coordinate2DimensionalAndLength2Dimensional<T> other) {
            return genericOperations.CastToInt(
                genericOperations.Subtract(
                genericOperations.Multiply(h, w),
                genericOperations.Multiply(other.h, other.w)));
        }

        public static bool operator ==(Coordinate2DimensionalAndLength2Dimensional<T> rhs,
            Coordinate2DimensionalAndLength2Dimensional<T> lhs) {
            return lhs != null && lhs.Equals(rhs);
        }

        public static bool operator !=(Coordinate2DimensionalAndLength2Dimensional<T> rhs,
            Coordinate2DimensionalAndLength2Dimensional<T> lhs) {
            return lhs != null && lhs.Equals(rhs);
        }

        public static bool operator >(Coordinate2DimensionalAndLength2Dimensional<T> rhs,
            Coordinate2DimensionalAndLength2Dimensional<T> lhs) {
            return lhs != null && rhs != null && genericOperations.Multiply(lhs.w, lhs.h)
                       .CompareTo(genericOperations.Multiply(rhs.w, rhs.h)) > 0;
        }

        public static bool operator <(Coordinate2DimensionalAndLength2Dimensional<T> rhs,
            Coordinate2DimensionalAndLength2Dimensional<T> lhs) {
            return lhs != null && rhs != null && genericOperations.Multiply(lhs.w, lhs.h)
                       .CompareTo(genericOperations.Multiply(rhs.w, rhs.h)) < 0;
        }

        public static bool operator >=(Coordinate2DimensionalAndLength2Dimensional<T> rhs,
            Coordinate2DimensionalAndLength2Dimensional<T> lhs) {
            return lhs != null && rhs != null && genericOperations.Multiply(lhs.w, lhs.h)
                       .CompareTo(genericOperations.Multiply(rhs.w, rhs.h)) >= 0;
        }

        public static bool operator <=(Coordinate2DimensionalAndLength2Dimensional<T> rhs,
            Coordinate2DimensionalAndLength2Dimensional<T> lhs) {
            return lhs != null && rhs != null && genericOperations.Multiply(lhs.w, lhs.h)
                       .CompareTo(genericOperations.Multiply(rhs.w, rhs.h)) <= 0;
        }

    }
}