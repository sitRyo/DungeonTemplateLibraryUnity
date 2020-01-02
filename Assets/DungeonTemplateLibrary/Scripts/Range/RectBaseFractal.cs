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
    public class RectBaseFractal<TDerived> : BasicRect<RectBaseFractal<TDerived>> where TDerived : RectBaseFractal<TDerived> {
        public int minValue { get; protected set; }
        public int altitude { get; protected set; }
        public int addAltitude { get; protected set; }

        /* Getter */
        public int GetValue() {
            return this.altitude;
        }

        public int GetMinValue() {
            return this.minValue;
        }

        public int GetAddAltitude() {
            return this.addAltitude;
        }

        public int GetAltitude() {
            return this.altitude;
        }

        /* Setter */
        public TDerived SetValue(int value) {
            this.altitude = value;
            return (TDerived) this;
        }

        // AddAlititude, MinValueのSetterはなくて良いのか？

        /* Clear */

        public TDerived ClearMinValue() {
            this.minValue = 0;
            return (TDerived) this;
        }

        public TDerived ClearAltitude() {
            this.altitude = 0;
            return (TDerived) this;
        }

        public TDerived ClearAddAltitude() {
            this.addAltitude = 0;
            return (TDerived) this;
        }

        public TDerived ClearValue() {
            this.ClearMinValue();
            this.ClearAltitude();
            this.ClearAddAltitude();

            return (TDerived) this;
        }

        public TDerived Clear() {
            ClearRange();
            ClearValue();

            return (TDerived) this;
        }

        /* Constructors */
        public RectBaseFractal() { } // = default()

        public RectBaseFractal(uint startX, uint startY, uint width, uint height) :
            base(startX, startY, width, height) {

        }

        public RectBaseFractal(int minValue) {
            this.minValue = minValue;
        }

        public RectBaseFractal(int minValue, int altitude) {
            this.minValue = minValue;
            this.altitude = altitude;
        }

        public RectBaseFractal(int minValue, int altitude, int addAltitude) {
            this.minValue = minValue;
            this.altitude = altitude;
            this.addAltitude = addAltitude;
        }

        public RectBaseFractal(MatrixRange matrixRange, int minValue) : base(matrixRange) {
            this.minValue = minValue;
        }

        public RectBaseFractal(MatrixRange matrixRange, int minValue, int altitude) : base(matrixRange) {
            this.minValue = minValue;
            this.altitude = altitude;
        }

        public RectBaseFractal(MatrixRange matrixRange, int minValue, int altitude, int addAltitude) : base(matrixRange) {
            this.minValue = minValue;
            this.altitude = altitude;
            this.addAltitude = addAltitude;
        }

        public RectBaseFractal(uint startX, uint startY, uint width, uint height, int minValue) :
            base(startX, startY, width, height) {
            this.minValue = minValue;
        }

        public RectBaseFractal(uint startX, uint startY, uint width, uint height, int minValue, int altitude) :
            base(startX, startY, width, height) {
            this.minValue = minValue;
            this.altitude = altitude;
        }

        public RectBaseFractal(uint startX, uint startY, uint width, uint height, int minValue, int altitude, int addAltitude) :
            base(startX, startY, width, height) {
            this.minValue = minValue;
            this.altitude = altitude;
            this.addAltitude = addAltitude;
        }
    }
}


