using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CustomControl.ColorService.ColorEnum;

namespace CustomControl.Shape.Circle
{
    public class CircleClass
    {
        [Category("Data")]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        /// <summary>
        /// 當作底色
        /// </summary>
        public Color FirstColor { get; set; }
        [Category("Data")]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        /// <summary>
        /// 如果Brush需要2種顏色就會使用到
        /// </summary>
        public Color SecondColor { get; set; }
        [Category("Data")]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        /// <summary>
        /// 顏色漸層角度
        /// </summary>
        public float Angle { get; set; }
        [Category("Data")]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        /// <summary>
        /// 是否透明
        /// </summary>
        public Boolean IsTransparent { get; set; }
        [Category("Data")]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        /// <summary>
        /// 是否非正圓
        /// </summary>
        public Boolean IsEllipse { get; set; }
        [Category("Data")]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]

        /// <summary>
        /// Brush種類
        /// </summary>  

        public BrushEnum FillBrush { get; set; }




        #region 渲染寬度
        private float _RectangleWidth;
        [Category("Data")]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public float RectangleWidth
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
                OnCallControlInvalidate();
            }
        }
        #endregion 渲染寬度

        #region 渲染高度
        private float _RectangleHeight;
        [Category("Data")]
        [Description("asdf")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public float RectangleHeight
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
                OnCallControlInvalidate();
            }
        }
        #endregion 渲染高度

        public event EventHandler CallControlInvalidate = null;

        protected virtual void OnCallControlInvalidate()
        {
            CallControlInvalidate?.Invoke(this, null) ;
        }

        public CircleClass()
        {
            this.Angle = 180;
            this.FirstColor = Color.White;
            this.SecondColor = Color.Black;
            this.IsTransparent = true;
            this.IsEllipse = false;
            this.FillBrush = BrushEnum.LinearGradientBrush;
        }
    }
}
