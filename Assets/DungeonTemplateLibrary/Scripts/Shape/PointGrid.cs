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

using DTL.Range;
using DTL.Util;

namespace DTL.Shape {
  public class PointGrid : RectBaseWithValue<PointGrid>, IDrawer<int> {
    public bool Draw(int[,] matrix) {
      return DrawNormal(matrix);
    }

    public int[,] Create(int[,] matrix) {
      Draw(matrix);
      return matrix;
    }

    public bool DrawNormal(int[,] matrix) {
      var endX = this.CalcEndX(MatrixUtil.GetX(matrix));
      var endY = this.CalcEndY(MatrixUtil.GetY(matrix));
      for (var row = this.startX; row < endX; row += 2) {
        for (var col = this.startY; col < endX; col += 2) {
          matrix[row, col] = this.drawValue;
        }
      }

      return true;
    }

    public RectBaseWithValue() { } // = default();

    public RectBaseWithValue(int drawValue, MatrixRange matrixRange) : base(drawValue, matrixRange) {
    }

    public RectBaseWithValue(int drawValue, uint startX, uint startY, uint width, uint height) : base(drawValue, startX, startY, width,
      height) {
      }

    public RectBaseWithValue(int drawValue) : base(drawValue) {}
  }
}