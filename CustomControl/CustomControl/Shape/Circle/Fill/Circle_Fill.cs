using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static CustomControl.ColorService.ColorEnum;
using CustomControl.ColorService;

namespace CustomControl.Shape.Circle.Fill
{
    public partial class Circle_Fill : UserControl
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
                this.Invalidate();
            }
        }
        #endregion 渲染高度

        /// <summary>
        /// 初始化元件
        /// </summary>
        public Circle_Fill()
        {
            InitializeComponent();
            Angle = 180;
            FirstColor = Color.White;
            SecondColor = Color.Black;
            IsTransparent = true;
            IsEllipse = false;
            FillBrush = BrushEnum.LinearGradientBrush;
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
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
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


            //渲染圓並填滿顏色
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                AddRoundedRectangle(graphicsPath, new RectangleF(1, 1, RectangleWidth - 2, RectangleHeight - 2));
                e.Graphics.FillPath(brush, graphicsPath);
                Console.WriteLine("graphicsPath");
            }

            //如果透明就將圓的矩形放大1切除此矩形以外的區域
            if (IsTransparent)
            {
                Console.WriteLine("IsTransparent");
                GraphicsPath graphicsPathCut = new GraphicsPath();

                AddRoundedRectangle(graphicsPathCut, new RectangleF(0, 0, RectangleWidth, RectangleHeight));
                this.Region = new Region(graphicsPathCut);
            }



            base.OnPaint(e);
        }
        public void AddRoundedRectangle(GraphicsPath gp, RectangleF rectangleF)
        {

            gp.AddArc(rectangleF, 0, 360);
            gp.CloseFigure();
        }

    }
}
