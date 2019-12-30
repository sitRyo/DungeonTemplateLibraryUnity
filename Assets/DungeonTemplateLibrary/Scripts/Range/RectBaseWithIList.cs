/*#######################################################################################
	Copyright (c) 2017-2019 Kasugaccho
	Copyright (c) 2018-2019 As Project
	https://github.com/Kasugaccho/DungeonTemplateLibrary
	wanotaitei@gmail.com

	Distributed under the Boost Software License, Version 1.0. (See accompanying
	file LICENSE_1_0.txt or copy at http://www.boost.org/LICENSE_1_0.txt)
#######################################################################################*/

using System.Collections.Generic;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Range {

    public class RectBaseWithIList<TDerived> : 
        BasicRect<RectBaseWithIList<TDerived>> where TDerived : RectBaseWithIList<TDerived> {

        public IList<int> drawValue { get; private set; }

        TDerived GetValue(IList<int> value) {
            value = this.drawValue;
            return (TDerived) this;
        }
        
        TDerived ClearValue() {
            this.drawValue.Clear();
            return (TDerived) this;
        }

        TDerived Clear() {
            this.ClearValue();
            this.ClearRange();
            return (TDerived) this;
        }

        TDerived SetValue(IList<int> drawValue) {
            this.drawValue = drawValue;
            return (TDerived) this;
        }

        /* Constructors */
        public RectBaseWithIList() {} // default

        public RectBaseWithIList(IList<int> drawValue) {
            this.drawValue = drawValue;
        }

        public RectBaseWithIList(MatrixRange matrixRange, IList<int> drawValue) : base(matrixRange) {
            this.drawValue = drawValue;
        }
    }
}