namespace elipse
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawElipse = new System.Windows.Forms.Button();
            this.machiningCAM = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxXPos = new System.Windows.Forms.TextBox();
            this.textBoxYPos = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.xMovPostive = new System.Windows.Forms.Button();
            this.xMovNegative = new System.Windows.Forms.Button();
            this.constantSpeedMovementGroupBox = new System.Windows.Forms.GroupBox();
            this.zMovNegative = new System.Windows.Forms.Button();
            this.zMovPostive = new System.Windows.Forms.Button();
            this.yMovNegative = new System.Windows.Forms.Button();
            this.yMovPostive = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.speedChange = new System.Windows.Forms.TrackBar();
            this.textBoxZPos = new System.Windows.Forms.TextBox();
            this.timerSpeed = new System.Windows.Forms.Timer(this.components);
            this.pointMoventGroupBox = new System.Windows.Forms.GroupBox();
            this.zMovRelative = new System.Windows.Forms.Button();
            this.yMovRelative = new System.Windows.Forms.Button();
            this.xMovRelative = new System.Windows.Forms.Button();
            this.textBoxPos = new System.Windows.Forms.TextBox();
            this.absolutePositionGroupBox = new System.Windows.Forms.GroupBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.doDrawButton = new System.Windows.Forms.Button();
            this.writeGroupBox = new System.Windows.Forms.GroupBox();
            this.textBoxMovY = new System.Windows.Forms.TextBox();
            this.textBoxMovX = new System.Windows.Forms.TextBox();
            this.textBoxHight = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.write = new System.Windows.Forms.Button();
            this.timerDrawTrack = new System.Windows.Forms.Timer(this.components);
            this.timerSpeedCurve = new System.Windows.Forms.Timer(this.components);
            this.timerButtonClick = new System.Windows.Forms.Timer(this.components);
            this.textBoxLaser = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pictureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.constantSpeedMovementGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedChange)).BeginInit();
            this.pointMoventGroupBox.SuspendLayout();
            this.absolutePositionGroupBox.SuspendLayout();
            this.writeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawElipse
            // 
            this.drawElipse.Location = new System.Drawing.Point(11, 17);
            this.drawElipse.Name = "drawElipse";
            this.drawElipse.Size = new System.Drawing.Size(128, 23);
            this.drawElipse.TabIndex = 1;
            this.drawElipse.Text = "drawElipse";
            this.drawElipse.UseVisualStyleBackColor = true;
            this.drawElipse.Click += new System.EventHandler(this.drawElipse_Click);
            // 
            // machiningCAM
            // 
            this.machiningCAM.Location = new System.Drawing.Point(13, 46);
            this.machiningCAM.Name = "machiningCAM";
            this.machiningCAM.Size = new System.Drawing.Size(128, 23);
            this.machiningCAM.TabIndex = 2;
            this.machiningCAM.Text = "machiningCAM";
            this.machiningCAM.UseVisualStyleBackColor = true;
            this.machiningCAM.Click += new System.EventHandler(this.machiningCAM_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxXPos
            // 
            this.textBoxXPos.Location = new System.Drawing.Point(6, 24);
            this.textBoxXPos.Name = "textBoxXPos";
            this.textBoxXPos.Size = new System.Drawing.Size(64, 25);
            this.textBoxXPos.TabIndex = 3;
            this.textBoxXPos.Text = "X:";
            // 
            // textBoxYPos
            // 
            this.textBoxYPos.Location = new System.Drawing.Point(76, 24);
            this.textBoxYPos.Name = "textBoxYPos";
            this.textBoxYPos.Size = new System.Drawing.Size(64, 25);
            this.textBoxYPos.TabIndex = 4;
            this.textBoxYPos.Text = "Y:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureGroupBox
            // 
            this.pictureGroupBox.Controls.Add(this.pictureBox2);
            this.pictureGroupBox.Controls.Add(this.pictureBox1);
            this.pictureGroupBox.Location = new System.Drawing.Point(380, 12);
            this.pictureGroupBox.Name = "pictureGroupBox";
            this.pictureGroupBox.Size = new System.Drawing.Size(509, 506);
            this.pictureGroupBox.TabIndex = 5;
            this.pictureGroupBox.TabStop = false;
            this.pictureGroupBox.Text = "pictureBox";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(16, 430);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 64);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // xMovPostive
            // 
            this.xMovPostive.Location = new System.Drawing.Point(23, 51);
            this.xMovPostive.Name = "xMovPostive";
            this.xMovPostive.Size = new System.Drawing.Size(33, 23);
            this.xMovPostive.TabIndex = 6;
            this.xMovPostive.Text = "X+";
            this.xMovPostive.UseVisualStyleBackColor = true;
            this.xMovPostive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xMovPostive_MouseDown);
            this.xMovPostive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xMovPostive_MouseUp);
            // 
            // xMovNegative
            // 
            this.xMovNegative.Location = new System.Drawing.Point(86, 51);
            this.xMovNegative.Name = "xMovNegative";
            this.xMovNegative.Size = new System.Drawing.Size(33, 23);
            this.xMovNegative.TabIndex = 7;
            this.xMovNegative.Text = "X-";
            this.xMovNegative.UseVisualStyleBackColor = true;
            this.xMovNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xMovNegative_MouseDown);
            this.xMovNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xMovNegative_MouseUp);
            // 
            // constantSpeedMovementGroupBox
            // 
            this.constantSpeedMovementGroupBox.Controls.Add(this.zMovNegative);
            this.constantSpeedMovementGroupBox.Controls.Add(this.zMovPostive);
            this.constantSpeedMovementGroupBox.Controls.Add(this.yMovNegative);
            this.constantSpeedMovementGroupBox.Controls.Add(this.yMovPostive);
            this.constantSpeedMovementGroupBox.Controls.Add(this.xMovPostive);
            this.constantSpeedMovementGroupBox.Controls.Add(this.xMovNegative);
            this.constantSpeedMovementGroupBox.Location = new System.Drawing.Point(10, 231);
            this.constantSpeedMovementGroupBox.Name = "constantSpeedMovementGroupBox";
            this.constantSpeedMovementGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.constantSpeedMovementGroupBox.Size = new System.Drawing.Size(286, 128);
            this.constantSpeedMovementGroupBox.TabIndex = 8;
            this.constantSpeedMovementGroupBox.TabStop = false;
            this.constantSpeedMovementGroupBox.Text = "constantSpeedMovementBox";
            // 
            // zMovNegative
            // 
            this.zMovNegative.Location = new System.Drawing.Point(121, 80);
            this.zMovNegative.Name = "zMovNegative";
            this.zMovNegative.Size = new System.Drawing.Size(33, 23);
            this.zMovNegative.TabIndex = 11;
            this.zMovNegative.Text = "Z-";
            this.zMovNegative.UseVisualStyleBackColor = true;
            this.zMovNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zMovNegative_MouseDown);
            this.zMovNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zMovNegative_MouseUp);
            // 
            // zMovPostive
            // 
            this.zMovPostive.Location = new System.Drawing.Point(121, 24);
            this.zMovPostive.Name = "zMovPostive";
            this.zMovPostive.Size = new System.Drawing.Size(33, 23);
            this.zMovPostive.TabIndex = 10;
            this.zMovPostive.Text = "Z+";
            this.zMovPostive.UseVisualStyleBackColor = true;
            this.zMovPostive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zMovPostive_MouseDown);
            this.zMovPostive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zMovPostive_MouseUp);
            // 
            // yMovNegative
            // 
            this.yMovNegative.Location = new System.Drawing.Point(53, 24);
            this.yMovNegative.Name = "yMovNegative";
            this.yMovNegative.Size = new System.Drawing.Size(33, 23);
            this.yMovNegative.TabIndex = 9;
            this.yMovNegative.Text = "Y-";
            this.yMovNegative.UseVisualStyleBackColor = true;
            this.yMovNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yMovNegative_MouseDown);
            this.yMovNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yMovNegative_MouseUp);
            // 
            // yMovPostive
            // 
            this.yMovPostive.Location = new System.Drawing.Point(53, 80);
            this.yMovPostive.Name = "yMovPostive";
            this.yMovPostive.Size = new System.Drawing.Size(33, 23);
            this.yMovPostive.TabIndex = 8;
            this.yMovPostive.Text = "Y+";
            this.yMovPostive.UseVisualStyleBackColor = true;
            this.yMovPostive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yMovPostive_MouseDown);
            this.yMovPostive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yMovPostive_MouseUp);
            // 
            // home
            // 
            this.home.Location = new System.Drawing.Point(153, 115);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(65, 23);
            this.home.TabIndex = 15;
            this.home.Text = "HOME";
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // stop
            // 
            this.stop.ForeColor = System.Drawing.Color.Blue;
            this.stop.Location = new System.Drawing.Point(153, 86);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(65, 23);
            this.stop.TabIndex = 14;
            this.stop.Text = "STOP";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(13, 113);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(126, 25);
            this.textBoxSpeed.TabIndex = 13;
            this.textBoxSpeed.Text = "SPEED (mm/s)";
            // 
            // speedChange
            // 
            this.speedChange.LargeChange = 15;
            this.speedChange.Location = new System.Drawing.Point(11, 144);
            this.speedChange.Maximum = 15;
            this.speedChange.Minimum = 1;
            this.speedChange.Name = "speedChange";
            this.speedChange.Size = new System.Drawing.Size(187, 56);
            this.speedChange.SmallChange = 0;
            this.speedChange.TabIndex = 12;
            this.speedChange.Value = 10;
            this.speedChange.Scroll += new System.EventHandler(this.speedChange_Scroll);
            // 
            // textBoxZPos
            // 
            this.textBoxZPos.Location = new System.Drawing.Point(146, 24);
            this.textBoxZPos.Name = "textBoxZPos";
            this.textBoxZPos.Size = new System.Drawing.Size(64, 25);
            this.textBoxZPos.TabIndex = 9;
            this.textBoxZPos.Text = "Z:";
            // 
            // timerSpeed
            // 
            this.timerSpeed.Interval = 20;
            this.timerSpeed.Tick += new System.EventHandler(this.timerSpeed_Tick);
            // 
            // pointMoventGroupBox
            // 
            this.pointMoventGroupBox.Controls.Add(this.zMovRelative);
            this.pointMoventGroupBox.Controls.Add(this.yMovRelative);
            this.pointMoventGroupBox.Controls.Add(this.xMovRelative);
            this.pointMoventGroupBox.Controls.Add(this.textBoxPos);
            this.pointMoventGroupBox.Location = new System.Drawing.Point(11, 379);
            this.pointMoventGroupBox.Name = "pointMoventGroupBox";
            this.pointMoventGroupBox.Size = new System.Drawing.Size(285, 139);
            this.pointMoventGroupBox.TabIndex = 10;
            this.pointMoventGroupBox.TabStop = false;
            this.pointMoventGroupBox.Text = "pointMoventBox";
            // 
            // zMovRelative
            // 
            this.zMovRelative.Location = new System.Drawing.Point(187, 84);
            this.zMovRelative.Name = "zMovRelative";
            this.zMovRelative.Size = new System.Drawing.Size(33, 23);
            this.zMovRelative.TabIndex = 18;
            this.zMovRelative.Text = "Z";
            this.zMovRelative.UseVisualStyleBackColor = true;
            this.zMovRelative.Click += new System.EventHandler(this.zMovRelative_Click);
            // 
            // yMovRelative
            // 
            this.yMovRelative.Location = new System.Drawing.Point(187, 55);
            this.yMovRelative.Name = "yMovRelative";
            this.yMovRelative.Size = new System.Drawing.Size(33, 23);
            this.yMovRelative.TabIndex = 17;
            this.yMovRelative.Text = "Y";
            this.yMovRelative.UseVisualStyleBackColor = true;
            this.yMovRelative.Click += new System.EventHandler(this.yMovRelative_Click);
            // 
            // xMovRelative
            // 
            this.xMovRelative.Location = new System.Drawing.Point(187, 26);
            this.xMovRelative.Name = "xMovRelative";
            this.xMovRelative.Size = new System.Drawing.Size(33, 23);
            this.xMovRelative.TabIndex = 16;
            this.xMovRelative.Text = "X";
            this.xMovRelative.UseVisualStyleBackColor = true;
            this.xMovRelative.Click += new System.EventHandler(this.xMovRelative_Click);
            // 
            // textBoxPos
            // 
            this.textBoxPos.Location = new System.Drawing.Point(27, 24);
            this.textBoxPos.Name = "textBoxPos";
            this.textBoxPos.Size = new System.Drawing.Size(126, 25);
            this.textBoxPos.TabIndex = 14;
            this.textBoxPos.Text = "POS (mm)";
            // 
            // absolutePositionGroupBox
            // 
            this.absolutePositionGroupBox.Controls.Add(this.textBoxXPos);
            this.absolutePositionGroupBox.Controls.Add(this.textBoxYPos);
            this.absolutePositionGroupBox.Controls.Add(this.textBoxZPos);
            this.absolutePositionGroupBox.Location = new System.Drawing.Point(153, 12);
            this.absolutePositionGroupBox.Name = "absolutePositionGroupBox";
            this.absolutePositionGroupBox.Size = new System.Drawing.Size(221, 78);
            this.absolutePositionGroupBox.TabIndex = 11;
            this.absolutePositionGroupBox.TabStop = false;
            this.absolutePositionGroupBox.Text = "absolutePositionBox";
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(11, 75);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(65, 23);
            this.drawButton.TabIndex = 16;
            this.drawButton.Text = "DRAW";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // doDrawButton
            // 
            this.doDrawButton.Location = new System.Drawing.Point(82, 75);
            this.doDrawButton.Name = "doDrawButton";
            this.doDrawButton.Size = new System.Drawing.Size(65, 23);
            this.doDrawButton.TabIndex = 17;
            this.doDrawButton.Text = "DO";
            this.doDrawButton.UseVisualStyleBackColor = true;
            this.doDrawButton.Click += new System.EventHandler(this.doDrawButton_Click);
            // 
            // writeGroupBox
            // 
            this.writeGroupBox.Controls.Add(this.textBoxMovY);
            this.writeGroupBox.Controls.Add(this.textBoxMovX);
            this.writeGroupBox.Controls.Add(this.textBoxHight);
            this.writeGroupBox.Controls.Add(this.textBoxWidth);
            this.writeGroupBox.Controls.Add(this.write);
            this.writeGroupBox.Location = new System.Drawing.Point(229, 96);
            this.writeGroupBox.Name = "writeGroupBox";
            this.writeGroupBox.Size = new System.Drawing.Size(145, 129);
            this.writeGroupBox.TabIndex = 18;
            this.writeGroupBox.TabStop = false;
            this.writeGroupBox.Text = "writeBox";
            // 
            // textBoxMovY
            // 
            this.textBoxMovY.Location = new System.Drawing.Point(75, 84);
            this.textBoxMovY.Name = "textBoxMovY";
            this.textBoxMovY.Size = new System.Drawing.Size(64, 25);
            this.textBoxMovY.TabIndex = 22;
            this.textBoxMovY.Text = "Y:";
            // 
            // textBoxMovX
            // 
            this.textBoxMovX.Location = new System.Drawing.Point(75, 53);
            this.textBoxMovX.Name = "textBoxMovX";
            this.textBoxMovX.Size = new System.Drawing.Size(64, 25);
            this.textBoxMovX.TabIndex = 21;
            this.textBoxMovX.Text = "X:";
            // 
            // textBoxHight
            // 
            this.textBoxHight.Location = new System.Drawing.Point(7, 84);
            this.textBoxHight.Name = "textBoxHight";
            this.textBoxHight.Size = new System.Drawing.Size(64, 25);
            this.textBoxHight.TabIndex = 10;
            this.textBoxHight.Text = "hight:";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(7, 53);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(64, 25);
            this.textBoxWidth.TabIndex = 20;
            this.textBoxWidth.Text = "width:";
            // 
            // write
            // 
            this.write.Location = new System.Drawing.Point(6, 24);
            this.write.Name = "write";
            this.write.Size = new System.Drawing.Size(65, 23);
            this.write.TabIndex = 19;
            this.write.Text = "WRITE";
            this.write.UseVisualStyleBackColor = true;
            this.write.Click += new System.EventHandler(this.write_Click);
            // 
            // timerDrawTrack
            // 
            this.timerDrawTrack.Interval = 20;
            this.timerDrawTrack.Tick += new System.EventHandler(this.timerDrawTrack_Tick);
            // 
            // timerSpeedCurve
            // 
            this.timerSpeedCurve.Interval = 10;
            this.timerSpeedCurve.Tick += new System.EventHandler(this.timerSpeedCurve_Tick);
            // 
            // timerButtonClick
            // 
            this.timerButtonClick.Enabled = true;
            this.timerButtonClick.Interval = 10;
            this.timerButtonClick.Tick += new System.EventHandler(this.timerButtonClick_Tick);
            // 
            // textBoxLaser
            // 
            this.textBoxLaser.Location = new System.Drawing.Point(13, 200);
            this.textBoxLaser.Name = "textBoxLaser";
            this.textBoxLaser.Size = new System.Drawing.Size(116, 25);
            this.textBoxLaser.TabIndex = 19;
            this.textBoxLaser.Text = "Laser: CLOSE";
            this.textBoxLaser.Click += new System.EventHandler(this.textBoxLaser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 551);
            this.Controls.Add(this.textBoxLaser);
            this.Controls.Add(this.writeGroupBox);
            this.Controls.Add(this.doDrawButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.home);
            this.Controls.Add(this.absolutePositionGroupBox);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.pointMoventGroupBox);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.constantSpeedMovementGroupBox);
            this.Controls.Add(this.speedChange);
            this.Controls.Add(this.pictureGroupBox);
            this.Controls.Add(this.machiningCAM);
            this.Controls.Add(this.drawElipse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pictureGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.constantSpeedMovementGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedChange)).EndInit();
            this.pointMoventGroupBox.ResumeLayout(false);
            this.pointMoventGroupBox.PerformLayout();
            this.absolutePositionGroupBox.ResumeLayout(false);
            this.absolutePositionGroupBox.PerformLayout();
            this.writeGroupBox.ResumeLayout(false);
            this.writeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button drawElipse;
        private System.Windows.Forms.Button machiningCAM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxXPos;
        private System.Windows.Forms.TextBox textBoxYPos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox pictureGroupBox;
        private System.Windows.Forms.Button xMovPostive;
        private System.Windows.Forms.Button xMovNegative;
        private System.Windows.Forms.GroupBox constantSpeedMovementGroupBox;
        private System.Windows.Forms.Button zMovNegative;
        private System.Windows.Forms.Button zMovPostive;
        private System.Windows.Forms.Button yMovNegative;
        private System.Windows.Forms.Button yMovPostive;
        private System.Windows.Forms.TrackBar speedChange;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.TextBox textBoxZPos;
        private System.Windows.Forms.Timer timerSpeed;
        private System.Windows.Forms.GroupBox pointMoventGroupBox;
        private System.Windows.Forms.TextBox textBoxPos;
        private System.Windows.Forms.Button zMovRelative;
        private System.Windows.Forms.Button yMovRelative;
        private System.Windows.Forms.Button xMovRelative;
        private System.Windows.Forms.GroupBox absolutePositionGroupBox;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button doDrawButton;
        private System.Windows.Forms.GroupBox writeGroupBox;
        private System.Windows.Forms.Button write;
        private System.Windows.Forms.Timer timerDrawTrack;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timerSpeedCurve;
        private System.Windows.Forms.TextBox textBoxHight;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxMovY;
        private System.Windows.Forms.TextBox textBoxMovX;
        private System.Windows.Forms.Timer timerButtonClick;
        private System.Windows.Forms.TextBox textBoxLaser;
    }
}

