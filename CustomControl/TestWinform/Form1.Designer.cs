namespace TestWinform
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.circle_Hollow2 = new CustomControl.Shape.Circle.Hollow.Circle_Hollow();
            this.circle_Hollow1 = new CustomControl.Shape.Circle.Hollow.Circle_Hollow();
            this.SuspendLayout();
            // 
            // circle_Hollow2
            // 
            this.circle_Hollow2.Angle = 180F;
            this.circle_Hollow2.CircleBorderWidth = 20F;
            this.circle_Hollow2.FillBrush = CustomControl.ColorService.ColorEnum.BrushEnum.LinearGradientBrush;
            this.circle_Hollow2.FirstColor = System.Drawing.Color.White;
            this.circle_Hollow2.IsEllipse = false;
            this.circle_Hollow2.IsTransparent = true;
            this.circle_Hollow2.Location = new System.Drawing.Point(345, 97);
            this.circle_Hollow2.Name = "circle_Hollow2";
            this.circle_Hollow2.SecondColor = System.Drawing.Color.Black;
            this.circle_Hollow2.Size = new System.Drawing.Size(409, 312);
            this.circle_Hollow2.TabIndex = 1;
            // 
            // circle_Hollow1
            // 
            this.circle_Hollow1.Angle = 180F;
            this.circle_Hollow1.CircleBorderWidth = 20F;
            this.circle_Hollow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circle_Hollow1.FillBrush = CustomControl.ColorService.ColorEnum.BrushEnum.LinearGradientBrush;
            this.circle_Hollow1.FirstColor = System.Drawing.Color.White;
            this.circle_Hollow1.IsEllipse = false;
            this.circle_Hollow1.IsTransparent = true;
            this.circle_Hollow1.Location = new System.Drawing.Point(0, 0);
            this.circle_Hollow1.Name = "circle_Hollow1";
            this.circle_Hollow1.SecondColor = System.Drawing.Color.Black;
            this.circle_Hollow1.Size = new System.Drawing.Size(963, 541);
            this.circle_Hollow1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(963, 541);
            this.Controls.Add(this.circle_Hollow2);
            this.Controls.Add(this.circle_Hollow1);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.Shape.Circle.Hollow.Circle_Hollow circle_Hollow1;
        private CustomControl.Shape.Circle.Hollow.Circle_Hollow circle_Hollow2;
    }
}

