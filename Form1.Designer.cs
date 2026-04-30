namespace SimplePaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAppName = new Label();
            btnLine = new Button();
            btnRectangle = new Button();
            btnCircle = new Button();
            cmbColor = new ComboBox();
            trbLineWidth = new TrackBar();
            trbZoom = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            picCanvas = new PictureBox();
            panelCanvas = new Panel();
            groupBox4 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbZoom).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            panelCanvas.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Sitka Banner", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.Blue;
            lblAppName.Location = new Point(27, 19);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(213, 53);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Simple Paint";
            // 
            // btnLine
            // 
            btnLine.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnLine.Image = Properties.Resources.IMG_8306;
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(15, 22);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(70, 64);
            btnLine.TabIndex = 1;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            // 
            // btnRectangle
            // 
            btnRectangle.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnRectangle.Image = Properties.Resources.IMG_8304;
            btnRectangle.ImageAlign = ContentAlignment.TopCenter;
            btnRectangle.Location = new Point(112, 22);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(70, 64);
            btnRectangle.TabIndex = 2;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnCircle
            // 
            btnCircle.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnCircle.Image = Properties.Resources.IMG_8305;
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(202, 22);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(70, 64);
            btnCircle.TabIndex = 3;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black 검정", "Red 빨강", "Blue 파랑", "Green 초록" });
            cmbColor.Location = new Point(6, 44);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(118, 29);
            cmbColor.TabIndex = 4;
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(15, 44);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(128, 45);
            trbLineWidth.TabIndex = 5;
            // 
            // trbZoom
            // 
            trbZoom.Location = new Point(19, 12);
            trbZoom.Maximum = 400;
            trbZoom.Minimum = 10;
            trbZoom.Name = "trbZoom";
            trbZoom.Size = new Size(129, 45);
            trbZoom.TabIndex = 13;
            trbZoom.TickFrequency = 10;
            trbZoom.Value = 100;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.FromArgb(255, 255, 192);
            btnOpenFile.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnOpenFile.ForeColor = SystemColors.ControlText;
            btnOpenFile.Location = new Point(622, 127);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(69, 67);
            btnOpenFile.TabIndex = 6;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.FromArgb(128, 255, 255);
            btnSaveFile.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnSaveFile.Location = new Point(697, 127);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(74, 67);
            btnSaveFile.TabIndex = 7;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCircle);
            groupBox1.Controls.Add(btnLine);
            groupBox1.Controls.Add(btnRectangle);
            groupBox1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            groupBox1.Location = new Point(13, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(301, 108);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "도형 선택";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbColor);
            groupBox2.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            groupBox2.Location = new Point(320, 86);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(130, 108);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "색 선택";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(trbLineWidth);
            groupBox3.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            groupBox3.Location = new Point(456, 86);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(149, 108);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "선 두께";
            // 
            // picCanvas
            // 
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Location = new Point(3, 3);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(752, 338);
            picCanvas.TabIndex = 11;
            picCanvas.TabStop = false;
            // 
            // panelCanvas
            // 
            panelCanvas.AutoScroll = true;
            panelCanvas.Controls.Add(picCanvas);
            panelCanvas.Location = new Point(13, 200);
            panelCanvas.Name = "panelCanvas";
            panelCanvas.Size = new Size(758, 344);
            panelCanvas.TabIndex = 12;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(trbZoom);
            groupBox4.Location = new Point(598, 550);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(170, 66);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "zoom in/zoom out";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(795, 628);
            Controls.Add(groupBox4);
            Controls.Add(panelCanvas);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(lblAppName);
            Name = "Form1";
            Text = "Simple Paint v1.0";
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbZoom).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            panelCanvas.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private Button btnLine;
        private Button btnRectangle;
        private Button btnCircle;
        private ComboBox cmbColor;
        private TrackBar trbLineWidth;
        private TrackBar trbZoom;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private PictureBox picCanvas;
        private Panel panelCanvas;
        private GroupBox groupBox4;
    }
}
