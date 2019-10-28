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
using UnityEngine;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Range {
    public class RectBasePerlin<TDerived> : BasicRect<RectBasePerlin<TDerived>>
        where TDerived : RectBasePerlin<TDerived> {
        public double frequency { get; set; }
        public uint octaves { get; set; }
        public int minHeight { get; set; }
        public int maxHeight { get; set; }

        /* clear */
        public TDerived ClearValue() {
            this.frequency = 0.0;
            this.octaves = 0;
            this.maxHeight = 0;
            this.minHeight = 0;
            return (TDerived) (this);
        }

        public TDerived ClearFrequency() {
            this.frequency = 0.0;
            return (TDerived) (this);
        }

        public TDerived ClearOctaves() {
            this.octaves = 0;
            return (TDerived) (this);
        }

        public TDerived ClearMinHeight() {
            this.minHeight = 0;
            return (TDerived)(this);
        }

        public TDerived ClearMaxHeight() {
            this.maxHeight = 0;
            return (TDerived)(this);
        }

        public TDerived Clear() {
            this.ClearRange();
            this.ClearValue();
            return (TDerived)(this);
        }


        public RectBasePerlin() {
        } // = default()

        public RectBasePerlin(uint startX, uint startY, uint width, uint height) : base(startX, startY, width, height) {
        }

        public RectBasePerlin(double frequency) {
            this.frequency = frequency;
        }

        public RectBasePerlin(double frequency, uint octaves) {
            this.frequency = frequency;
            this.octaves = octaves;
        }

        public RectBasePerlin(double frequency, uint octaves, int maxHeight) {
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
        }

        public RectBasePerlin(double frequency, uint octaves, int maxHeight, int minHeight) {
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
            this.minHeight = minHeight;
        }

        public RectBasePerlin(MatrixRange matrixRange, double frequency) : base(matrixRange) {
            this.frequency = frequency;
        }

        public RectBasePerlin(MatrixRange matrixRange, double frequency, uint octaves) : base(matrixRange) {
            this.frequency = frequency;
            this.octaves = octaves;
        }

        public RectBasePerlin(MatrixRange matrixRange, double frequency, uint octaves, int maxHeight) : base(
            matrixRange) {
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
        }

        public RectBasePerlin(MatrixRange matrixRange, double frequency, uint octaves, int maxHeight, int minHeight) :
            base(matrixRange) {
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
            this.minHeight = minHeight;
        }

        public RectBasePerlin(uint startX, uint startY, uint width, uint height, double frequency) : base(startX,
            startY, width, height) {
            this.frequency = frequency;
        }

        public RectBasePerlin(uint startX, uint startY, uint width, uint height, double frequency, uint octaves) : base(
            startX, startY, width, height) {
            this.frequency = frequency;
            this.octaves = octaves;
        }

        public RectBasePerlin(uint startX, uint startY, uint width, uint height, double frequency, uint octaves,
            int maxHeight) : base(startX, startY, width, height) {
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
        }

        public RectBasePerlin(uint startX, uint startY, uint width, uint height, double frequency, uint octaves,
            int maxHeight, int minHeight) : base(startX, startY, width, height) {
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
            this.minHeight = minHeight;
        }
    }
}