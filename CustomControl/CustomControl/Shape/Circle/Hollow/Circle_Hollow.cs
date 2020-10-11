using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CustomControl.ColorService.ColorEnum;
using System.Drawing.Drawing2D;

namespace CustomControl.Shape.Circle.Hollow
{
    public partial class Circle_Hollow : UserControl
    {
        /// <summary>
        /// 當作底色
        /// </summary>
        public Color FirstColor { get; set; }
        /// <summary>
        /// 如果Brush需要2種顏色就會使用到
        /// </summary>
        public Color SecondColor { get; set; }
        /// <summary>
        /// 顏色漸層角度
        /// </summary>
        public float Angle { get; set; }
        /// <summary>
        /// 是否透明
        /// </summary>
        public Boolean IsTransparent { get; set; }
        /// <summary>
        /// 是否非正圓
        /// </summary>
        public Boolean IsEllipse { get; set; }

        /// <summary>
        /// Brush種類
        /// </summary>  

        public BrushEnum FillBrush { get; set; }


        #region 渲染寬度
        private float _RectangleWidth;
        private float RectangleWidth
        {
            get
            {
                return _RectangleWidth;
            }
            set
            {
                if (value <= 0)
                {
                    _RectangleWidth = 4;
                }
                else
                {
                    _RectangleWidth = value;
                }
                CheckRadius(_RectangleWidth);
                this.Invalidate();
            }
        }
        #endregion 渲染寬度

        #region 渲染高度
        private float _RectangleHeight;
        private float RectangleHeight
        {
            get
            {
                return _RectangleHeight;
            }
            set
            {
                if (value <= 0)
                {
                    _RectangleHeight = 4;
                }
                else
                {
                    _RectangleHeight = value;
                }
                CheckRadius(_RectangleHeight);
                this.Invalidate();
            }
        }
        #endregion 渲染高度

        #region 渲染外框寬度
        private float _CircleBorderWidth;
        public float CircleBorderWidth
        {
            get
            {
                return _CircleBorderWidth;
            }
            set
            {
                if (value <= 1)
                {
                    _CircleBorderWidth = 1;
                }
                else if (value > RectangleWidth && RectangleWidth > 4)
                {
                    _CircleBorderWidth = (RectangleWidth / 2) - 2;
                }
                else
                {
                    _CircleBorderWidth = value;
                }
                this.Invalidate();
            }
        }
        #endregion 渲染外框寬度

        /// <summary>
        /// 初始化元件
        /// </summary>
        public Circle_Hollow()
        {

            InitializeComponent();

            Angle = 180;
            FirstColor = Color.White;
            SecondColor = Color.Black;
            IsTransparent = true;
            IsEllipse = false;
            FillBrush = BrushEnum.LinearGradientBrush;
            RectangleHeight = this.Height;
            RectangleWidth = this.Width;
            CircleBorderWidth = 20;
            this.DoubleBuffered = true;
        }
        /// <summary>
        /// 當元件大小改變時
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            //如果是正圓就抓最短邊長
            if (!IsEllipse)
            {
                RectangleHeight = (this.Width >= this.Height) ? this.Height : this.Width;
                RectangleWidth = RectangleHeight;
            }
            else
            {
                RectangleHeight = this.Height;
                RectangleWidth = this.Width;

            }

            base.OnResize(e);

        }
        /// <summary>
        /// 渲染時
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {

            #region 減少圖形不平滑
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            #endregion

            dynamic brush = new SolidBrush(FirstColor);
            switch (FillBrush)
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
            //原始畫面大小
            RectangleF OrginSize = new RectangleF(0, 0, RectangleWidth, RectangleHeight);
            var size = e.Graphics.MeasureString(this.Name, this.Font);
            //渲染圓並填滿顏色

            #region 劃區帶有顏色的圓環
            GraphicsPath graphicsPath = new GraphicsPath();
            //先加入原始畫面大小縮小1的圓型
            AddRoundedRectangle(graphicsPath, RectangleF.Inflate(OrginSize, -1, -1));
            //先加入原始畫面大小縮小1+CircleBorderWidth的圓型
            AddRoundedRectangle(graphicsPath, RectangleF.Inflate(OrginSize, -1 - CircleBorderWidth, -1 - CircleBorderWidth));
            //填滿顏色
            e.Graphics.FillPath(brush, graphicsPath);
            GraphicsPath graphicsPathstring = new GraphicsPath();
            StringFormat format = StringFormat.GenericDefault;
            graphicsPathstring.AddString(this.Name, this.Font.FontFamily, (int)this.Font.Style, this.Font.Size,new PointF( RectangleWidth / 2 - size.Width / 2, (RectangleHeight - CircleBorderWidth) / 2), format);
            #endregion


            //如果透明就將圓的矩形放大1切除此矩形以外的區域
            if (IsTransparent)
            {
                //加入原始畫面大小縮小2+CircleBorderWidth的圓型，要多縮小1格避免有鋸齒
                GraphicsPath graphicsPathCut2 = new GraphicsPath();
                AddRoundedRectangle(graphicsPathCut2, RectangleF.Inflate(OrginSize, -2 - CircleBorderWidth, -2 - CircleBorderWidth));
                //graphicsPathCut2.AddPath(graphicsPathstring, false);
                //加入原始畫面大小
                GraphicsPath graphicsPathCut = new GraphicsPath();
                AddRoundedRectangle(graphicsPathCut, OrginSize);
                //留下外環
                graphicsPathCut.AddPath(graphicsPathCut2, false);
             
                this.Region = new Region(graphicsPathCut);
            }
            // Draw string to screen.

            e.Graphics.DrawString(this.Name, this.Font, brush, RectangleWidth / 2 - size.Width / 2, (RectangleHeight - CircleBorderWidth) / 2);
            base.OnPaint(e);


        }
        public void AddRoundedRectangle(GraphicsPath gp, RectangleF rectangleF)
        {

            gp.AddArc(rectangleF, 0, 360);
            gp.CloseFigure();
        }
        private void CheckRadius(float len)
        {
            if ((len / 2) - 1 <= CircleBorderWidth)
            {
                _CircleBorderWidth = (len / 2) - 2;
            }
        }

    }
}
