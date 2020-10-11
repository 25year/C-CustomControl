using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CustomControl.ColorService.ColorEnum;

namespace CustomControl.Shape.Circle.Fill
{
    class Circle_Fill_Service
    {
        /// <summary>
        /// 渲染圖形
        /// </summary>
        /// <param name="e"></param>
        /// <param name="RectangleWidth">寬</param>
        /// <param name="RectangleHeight">高</param>
        /// <param name="FirstColor">底色</param>
        /// <param name="SecondColor">其他色</param>
        /// <param name="Angle">角度</param>
        /// <param name="IsTransparent">透明</param>
        /// <param name="brushEnum">渲染顏色種類</param>
        /// <param name="graphicsPathCut">如果透明要回傳圖形路徑</param>
        public void Draw(PaintEventArgs e, float RectangleWidth, float RectangleHeight, Color FirstColor, Color SecondColor, float Angle, bool IsTransparent,   BrushEnum brushEnum, out GraphicsPath graphicsPathCut)
        {
            graphicsPathCut = null;

            #region 減少圖形不平滑
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            #endregion
          dynamic brush = new SolidBrush(FirstColor);
            switch (brushEnum)
            {

                case BrushEnum.LinearGradientBrush:
                    brush = new LinearGradientBrush(new RectangleF(0, 0, RectangleWidth, RectangleHeight), FirstColor, SecondColor, Angle);
                    break;
                //case BrushEnum.TextureBrush:
                //    break;
                //case BrushEnum.HatchBrush:
                //    break;
                //case BrushEnum.PathGradientBrush:
                //    break;
                default:
                    brush = new SolidBrush(FirstColor);
                    break;
            }


            //渲染圓並填滿顏色
            using (GraphicsPath graphicsPath = new GraphicsPath()){
                AddRoundedRectangle(graphicsPath, new RectangleF(1, 1, RectangleWidth - 2, RectangleHeight - 2));
                e.Graphics.FillPath(brush, graphicsPath);
            }

            //如果透明就將圓的矩形放大1切除此矩形以外的區域
            if (IsTransparent)
            {
                graphicsPathCut = new GraphicsPath();

                AddRoundedRectangle(graphicsPathCut, new RectangleF(0, 0, RectangleWidth, RectangleHeight));

            }


        }
        /// <summary>
        /// 渲染出圓形
        /// </summary>
        /// <param name="gp">路徑</param>
        /// <param name="rectangleF">矩形大小</param>
        public void AddRoundedRectangle(GraphicsPath gp, RectangleF rectangleF)
        {

            gp.AddArc(rectangleF, 0, 360);
            gp.CloseFigure();
        }
    }
}
