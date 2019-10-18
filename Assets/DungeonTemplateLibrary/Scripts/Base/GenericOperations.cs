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
using System.Linq;
using System.Linq.Expressions;

namespace DTL.Base {
    /*#######################################################################################
        [概要] 'GenericOperations' はジェネリックによる四則演算を動的生成するクラス。
        [Summary] 'GenericOperations' generates four arithmetic operations for generics.
    #######################################################################################*/

    public class GenericOperations<T> {
        private Type[] availableTypes = new Type[] {
            typeof(int), typeof(uint), typeof(short), typeof(ushort), typeof(long), typeof(ulong),
            typeof(byte), typeof(decimal), typeof(double)
        };

        public GenericOperations() {
            if (!availableTypes.Contains(typeof(T))) {
                throw new NotSupportedException();
            }

            GenerateArithmeticMethods();
            GeneratedCastMethods();
        }

        private void GenerateArithmeticMethods() {
            var p1 = Expression.Parameter(typeof(T));
            var p2 = Expression.Parameter(typeof(T));

            Add = Expression.Lambda<Func<T, T, T>>(Expression.Add(p1, p2), p1, p2).Compile();
            Subtract = Expression.Lambda<Func<T, T, T>>(Expression.Subtract(p1, p2), p1, p2).Compile();
            Multiply = Expression.Lambda<Func<T, T, T>>(Expression.Multiply(p1, p2), p1, p2).Compile();
            Divide = Expression.Lambda<Func<T, T, T>>(Expression.Divide(p1, p2), p1, p2).Compile();
        }

        private void GeneratedCastMethods() {
            var p = Expression.Parameter(typeof(T));
            CastToInt = Expression.Lambda<Func<T, int>>(Expression.ConvertChecked(p, typeof(int)), p).Compile();
        }



        public Func<T, T, T> Add { get; private set; }
        public Func<T, T, T> Subtract { get; private set; }
        public Func<T, T, T> Multiply { get; private set; }
        public Func<T, T, T> Divide { get; private set; }

        public Func<T, int> CastToInt { get; private set; }
    }
}