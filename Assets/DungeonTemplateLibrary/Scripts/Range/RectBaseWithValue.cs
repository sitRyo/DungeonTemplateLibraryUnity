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

using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Range {
    public class RectBaseWithValue<TDerived> : BasicRect<RectBaseWithValue<TDerived>> where TDerived : RectBaseWithValue<TDerived> {
        public int drawValue { get; set; }

        public TDerived GetValue(ref int value) {
            value = (this.drawValue);
            return (TDerived) this;
        }

        public TDerived ClearValue() {
            drawValue = 0;
            return (TDerived) this;
        }

        public TDerived Clear() {
            this.ClearRange();
            this.ClearValue();
            return (TDerived) this;
        }

        // constructors

        public RectBaseWithValue() { } // = default();

        public RectBaseWithValue(int drawValue, MatrixRange matrixRange) : base(matrixRange) {
            this.drawValue = drawValue;
        }

        public RectBaseWithValue(int drawValue, uint startX, uint startY, uint width, uint height) : base(startX, startY, width,
            height) {
            this.drawValue = drawValue;
        }

        public RectBaseWithValue(int drawValue) {
            this.drawValue = drawValue;
        }
    }
}