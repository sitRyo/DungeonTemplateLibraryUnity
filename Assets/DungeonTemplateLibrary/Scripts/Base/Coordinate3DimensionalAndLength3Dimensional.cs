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
using System.Xml.Schema;

namespace DTL.Base {
    public class Coordinate3DimensionalAndLength3Dimensional<T> :
        IEquatable<Coordinate3DimensionalAndLength3Dimensional<T>>,
        IComparable<Coordinate3DimensionalAndLength3Dimensional<T>>
        where T : IComparable<T>, IEquatable<T> {

        // for generics arithmetic operations.
        // NOTE! throws new NotSupportedException() when T is not support generic arithmetic operations(Now, only supports primitive type (like int, double...))
        public static GenericOperations<T> genericOperations = new GenericOperations<T>();

        private T x { get; set; }
        private T y { get; set; }
        private T z { get; set; }
        private T w { get; set; }
        private T h { get; set; }
        private T d { get; set; }

        public Coordinate3DimensionalAndLength3Dimensional() { } // default

        public Coordinate3DimensionalAndLength3Dimensional(T x, T y, T z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Coordinate3DimensionalAndLength3Dimensional(T x, T y, T z, T l) : this(x, y, z) {
            this.w = l;
            this.h = l;
            this.d = l;
        }

        public Coordinate3DimensionalAndLength3Dimensional(T x, T y, T z, T w, T h, T d) : this(x, y, z) {
            this.w = w;
            this.h = h;
            this.d = d;
        }

        public bool Equals(Coordinate3DimensionalAndLength3Dimensional<T> others) {
            if (others == null || !this.GetType().Equals(others.GetType())) {
                return false;
            }

            return (x.Equals(others.x) && y.Equals(others.y) && z.Equals(others.z) && w.Equals(others.w) &&
                    h.Equals(others.h) && d.Equals(others.d));
        }

        public override bool Equals(object obj) {
            return this.Equals(obj);
        }

        public int CompareTo(Coordinate3DimensionalAndLength3Dimensional<T> other) {
            var vol1 = genericOperations.Multiply(w, genericOperations.Multiply(h, d));
            var vol2 = genericOperations.Multiply(other.w, genericOperations.Multiply(other.h, other.d));

            return genericOperations.CastToInt(genericOperations.Subtract(vol1, vol2));
        }

        public static bool operator ==(Coordinate3DimensionalAndLength3Dimensional<T> rhs,
            Coordinate3DimensionalAndLength3Dimensional<T> lhs) {
            return lhs != null && lhs.Equals(rhs);
        }

        public static bool operator !=(Coordinate3DimensionalAndLength3Dimensional<T> rhs,
            Coordinate3DimensionalAndLength3Dimensional<T> lhs) {
            return lhs != null && !lhs.Equals(rhs);
        }

        public static bool operator >(Coordinate3DimensionalAndLength3Dimensional<T> rhs,
            Coordinate3DimensionalAndLength3Dimensional<T> lhs) {
            if (lhs == null || rhs == null) {
                return false;

            }
            var vol1 = genericOperations.Multiply(lhs.w, genericOperations.Multiply(lhs.h, lhs.d));
            var vol2 = genericOperations.Multiply(rhs.w, genericOperations.Multiply(rhs.h, rhs.d));

            return vol1.CompareTo(vol2) > 0;
        }

        public static bool operator <(Coordinate3DimensionalAndLength3Dimensional<T> rhs,
            Coordinate3DimensionalAndLength3Dimensional<T> lhs) {
            if (lhs == null || rhs == null) {
                return false;

            }
            var vol1 = genericOperations.Multiply(lhs.w, genericOperations.Multiply(lhs.h, lhs.d));
            var vol2 = genericOperations.Multiply(rhs.w, genericOperations.Multiply(rhs.h, rhs.d));

            return vol1.CompareTo(vol2) < 0;
        }

        public static bool operator >=(Coordinate3DimensionalAndLength3Dimensional<T> rhs,
            Coordinate3DimensionalAndLength3Dimensional<T> lhs) {
            if (lhs == null || rhs == null) {
                return false;

            }
            var vol1 = genericOperations.Multiply(lhs.w, genericOperations.Multiply(lhs.h, lhs.d));
            var vol2 = genericOperations.Multiply(rhs.w, genericOperations.Multiply(rhs.h, rhs.d));

            return vol1.CompareTo(vol2) >= 0;
        }

        public static bool operator <=(Coordinate3DimensionalAndLength3Dimensional<T> rhs,
            Coordinate3DimensionalAndLength3Dimensional<T> lhs) {
            if (lhs == null || rhs == null) {
                return false;

            }
            var vol1 = genericOperations.Multiply(lhs.w, genericOperations.Multiply(lhs.h, lhs.d));
            var vol2 = genericOperations.Multiply(rhs.w, genericOperations.Multiply(rhs.h, rhs.d));

            return vol1.CompareTo(vol2) <= 0;
        }

    }
}

