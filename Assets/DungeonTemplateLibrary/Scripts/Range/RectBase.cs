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

using DTL.Base;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Range {
    public class RectBase<TDerived> : BasicRect<RectBase<TDerived>> where TDerived : RectBase<TDerived> {
        public TDerived Clear() {
            this.ClearRange();
            return (TDerived) this;
        }

        public RectBase() {
        } // = default()

        public RectBase(MatrixRange matrixRange) : base(matrixRange) {
        }

        public RectBase(uint startX, uint startY, uint width, uint height) : base(startX, startY, width, height) {
        }
    }
}