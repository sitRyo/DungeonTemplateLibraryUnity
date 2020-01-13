/*#######################################################################################
	Copyright (c) 2017-2019 Kasugaccho
	Copyright (c) 2018-2019 As Project
	https://github.com/Kasugaccho/DungeonTemplateLibrary
	wanotaitei@gmail.com

	Distributed under the Boost Software License, Version 1.0. (See accompanying
	file LICENSE_1_0.txt or copy at http://www.boost.org/LICENSE_1_0.txt)
#######################################################################################*/

using DTL.Base;
using UnityEngine;
using MatrixRange = DTL.Base.Coordinate2DimensionalAndLength2Dimensional;

namespace DTL.Range {
    public class RectBasePerlinSolitary<TDerived> : BasicRect<RectBasePerlinSolitary<TDerived>>
        where TDerived : RectBasePerlinSolitary<TDerived> {
        public double truncatedProportion { get; protected set; }
        public double mountainProportion { get; protected set; }
        public double frequency { get; protected set; }
        public uint octaves { get; protected set; }
        public int minHeight { get; protected set; }
        public int maxHeight { get; protected set; }

        /* Getter */
        public double GetTruncatedProportion() {
            return this.truncatedProportion;
        }

        public double GetMountainProportion() {
            return this.mountainProportion;
        }

        public double GetFrequency() {
            return this.frequency;
        }

        public double GetOctaves() {
            return this.octaves;
        }

        public int GetMinHeight() {
            return this.minHeight;
        }

        public int GetMaxHeight() {
            return this.maxHeight;
        }

        public double GetValue() {
            return this.frequency;
        }

        /* Setter */

        public TDerived SetTruncatedProportion(double truncatedProportion) {
            this.truncatedProportion = truncatedProportion;
            return (TDerived) this;
        }

        public TDerived SetMountainProportion(double mountainProportion) {
            this.mountainProportion = mountainProportion;
            return (TDerived) this;
        }

        public TDerived SetValue(double frequency) {
            this.frequency = frequency;
            return (TDerived) this;
        }

        public TDerived SetFrequency(double frequency) {
            this.frequency = frequency;
            return (TDerived) this;
        }

        public TDerived SetOctaves(uint octaves) {
            this.octaves = octaves;
            return (TDerived) this;
        }

        public TDerived SetMinHeight(int minHeight) {
            this.minHeight = minHeight;
            return (TDerived) this;
        }

        public TDerived SetMaxHeight(int maxHeight) {
            this.maxHeight = maxHeight;
            return (TDerived) this;
        }

        /* clear */

        public TDerived ClearValue() {
            this.frequency = 0.0;
            this.truncatedProportion = 0.0;
            this.mountainProportion = 0.0;
            this.octaves = 0;
            this.minHeight = 0;
            this.maxHeight = 0;
            return (TDerived) this;
        }

        public TDerived ClearTruncatedProportion() {
            this.truncatedProportion = 0.0;
            return (TDerived) this;
        }

        public TDerived ClearMountainProportion() {
            this.mountainProportion = 0.0;
            return (TDerived) this;
        }

        public TDerived ClearFrequency() {
            this.frequency = 0.0;
            return (TDerived) this;
        }

        public TDerived ClearOctaves() {
            this.octaves = 0;
            return (TDerived) this;
        }

        public TDerived ClaerMinHeight() {
            this.minHeight = 0;
            return (TDerived) this;
        }

        public TDerived ClearMaxHeight() {
            this.maxHeight = 0;
            return (TDerived) this;
        }

        public TDerived Clear() {
            this.ClearValue();
            this.ClearRange();
            return (TDerived) this;
        }

        /* constructors */

        public RectBasePerlinSolitary() {
        } // = default()

        public RectBasePerlinSolitary(uint startX, uint startY, uint width, uint height) : base(startX, startY, width,
            height) {
        }

        public RectBasePerlinSolitary(double truncatedProportion) {
            this.truncatedProportion = truncatedProportion;
        }

        public RectBasePerlinSolitary(double truncatedProportion, double mountainProportion) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
        }

        public RectBasePerlinSolitary(double truncatedProportion, double mountainProportion, double frequency) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
        }

        public RectBasePerlinSolitary(double truncatedProportion, double mountainProportion, double frequency,
            uint octaves) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
        }

        public RectBasePerlinSolitary(double truncatedProportion, double mountainProportion, double frequency,
            uint octaves, int maxHeight) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
        }

        public RectBasePerlinSolitary(double truncatedProportion, double mountainProportion, double frequency,
            uint octaves, int maxHeight, int minHeight) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
            this.minHeight = minHeight;
        }

        public RectBasePerlinSolitary(MatrixRange matrixRange, double truncatedProportion) : base(matrixRange) {
            this.truncatedProportion = truncatedProportion;
        }

        public RectBasePerlinSolitary(MatrixRange matrixRange, double truncatedProportion, double mountainProportion) :
            base(matrixRange) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
        }

        public RectBasePerlinSolitary(MatrixRange matrixRange, double truncatedProportion, double mountainProportion,
            double frequency) : base(matrixRange) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
        }

        public RectBasePerlinSolitary(MatrixRange matrixRange, double truncatedProportion, double mountainProportion,
            double frequency, uint octaves) : base(matrixRange) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
        }

        public RectBasePerlinSolitary(MatrixRange matrixRange, double truncatedProportion, double mountainProportion,
            double frequency, uint octaves, int maxHeight) : base(matrixRange) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
        }

        public RectBasePerlinSolitary(MatrixRange matrixRange, double truncatedProportion, double mountainProportion,
            double frequency, uint octaves, int maxHeight, int minHeight) : base(matrixRange) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
            this.minHeight = minHeight;
        }

        public RectBasePerlinSolitary(uint startX, uint startY, uint width, uint height, double truncatedProportion) :
            base(startX, startY, width, height) {
            this.truncatedProportion = truncatedProportion;
        }

        public RectBasePerlinSolitary(uint startX, uint startY, uint width, uint height, double truncatedProportion,
            double mountainProportion) : base(startX, startY, width, height) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
        }

        public RectBasePerlinSolitary(uint startX, uint startY, uint width, uint height, double truncatedProportion,
            double mountainProportion, double frequency) : base(startX, startY, width, height) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
        }

        public RectBasePerlinSolitary(uint startX, uint startY, uint width, uint height, double truncatedProportion,
            double mountainProportion, double frequency, uint octaves) : base(startX, startY, width, height) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
        }

        public RectBasePerlinSolitary(uint startX, uint startY, uint width, uint height, double truncatedProportion,
            double mountainProportion, double frequency, uint octaves, int maxHeight) : base(startX, startY, width,
            height) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
        }

        public RectBasePerlinSolitary(uint startX, uint startY, uint width, uint height, double truncatedProportion,
            double mountainProportion, double frequency, uint octaves, int maxHeight, int minHeight) : base(startX,
            startY, width, height) {
            this.truncatedProportion = truncatedProportion;
            this.mountainProportion = mountainProportion;
            this.frequency = frequency;
            this.octaves = octaves;
            this.maxHeight = maxHeight;
            this.minHeight = minHeight;
        }
    }
}