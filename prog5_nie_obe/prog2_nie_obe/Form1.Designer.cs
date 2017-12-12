namespace prog3_nie_obe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.glControl1 = new OpenTK.GLControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.trkTime = new System.Windows.Forms.TrackBar();
            this.txtPerspective = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            this.trkZ = new System.Windows.Forms.TrackBar();
            this.trkY = new System.Windows.Forms.TrackBar();
            this.trkX = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.togglePerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrMove = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lightResetBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.globalAmbientNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lightXtxt = new System.Windows.Forms.TextBox();
            this.lightBlueBar = new System.Windows.Forms.TrackBar();
            this.lightYtxt = new System.Windows.Forms.TextBox();
            this.lightZtxt = new System.Windows.Forms.TextBox();
            this.lightGrnBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lightRedBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkX)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.globalAmbientNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightBlueBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightGrnBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightRedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(16, 203);
            this.glControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(792, 556);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtZ);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.trkTime);
            this.groupBox1.Controls.Add(this.txtPerspective);
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.Controls.Add(this.trkZ);
            this.groupBox1.Controls.Add(this.trkY);
            this.groupBox1.Controls.Add(this.trkX);
            this.groupBox1.Location = new System.Drawing.Point(16, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1068, 162);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "X, Y, Z values of the View Reference Point (Eyeball) looking at (0,0,0) with Y up" +
    "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ticker";
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(648, 20);
            this.txtZ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(132, 22);
            this.txtZ.TabIndex = 11;
            this.txtZ.TextChanged += new System.EventHandler(this.txtZ_TextChanged);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(369, 23);
            this.txtY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(132, 22);
            this.txtY.TabIndex = 10;
            this.txtY.TextChanged += new System.EventHandler(this.txtY_TextChanged);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(95, 23);
            this.txtX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(132, 22);
            this.txtX.TabIndex = 9;
            this.txtX.TextChanged += new System.EventHandler(this.txtX_TextChanged);
            // 
            // trkTime
            // 
            this.trkTime.Location = new System.Drawing.Point(79, 100);
            this.trkTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trkTime.Maximum = 100;
            this.trkTime.Name = "trkTime";
            this.trkTime.Size = new System.Drawing.Size(232, 56);
            this.trkTime.TabIndex = 8;
            this.trkTime.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // txtPerspective
            // 
            this.txtPerspective.AutoSize = true;
            this.txtPerspective.Location = new System.Drawing.Point(884, 20);
            this.txtPerspective.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtPerspective.Name = "txtPerspective";
            this.txtPerspective.Size = new System.Drawing.Size(30, 17);
            this.txtPerspective.TabIndex = 7;
            this.txtPerspective.Text = "text";
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(888, 58);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(100, 28);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // trkZ
            // 
            this.trkZ.Location = new System.Drawing.Point(648, 52);
            this.trkZ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trkZ.Maximum = 25;
            this.trkZ.Minimum = -25;
            this.trkZ.Name = "trkZ";
            this.trkZ.Size = new System.Drawing.Size(232, 56);
            this.trkZ.TabIndex = 4;
            this.trkZ.Value = 5;
            this.trkZ.Scroll += new System.EventHandler(this.trkZ_Scroll);
            // 
            // trkY
            // 
            this.trkY.Location = new System.Drawing.Point(369, 52);
            this.trkY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trkY.Maximum = 25;
            this.trkY.Minimum = -25;
            this.trkY.Name = "trkY";
            this.trkY.Size = new System.Drawing.Size(232, 56);
            this.trkY.TabIndex = 2;
            this.trkY.Value = 5;
            this.trkY.Scroll += new System.EventHandler(this.trkY_Scroll);
            // 
            // trkX
            // 
            this.trkX.Location = new System.Drawing.Point(95, 52);
            this.trkX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trkX.Maximum = 25;
            this.trkX.Minimum = -25;
            this.trkX.Name = "trkX";
            this.trkX.Size = new System.Drawing.Size(232, 56);
            this.trkX.TabIndex = 0;
            this.trkX.Value = 5;
            this.trkX.Scroll += new System.EventHandler(this.trkX_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.togglePerspectiveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // togglePerspectiveToolStripMenuItem
            // 
            this.togglePerspectiveToolStripMenuItem.Name = "togglePerspectiveToolStripMenuItem";
            this.togglePerspectiveToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.togglePerspectiveToolStripMenuItem.Text = "Toggle Perspective";
            this.togglePerspectiveToolStripMenuItem.Click += new System.EventHandler(this.togglePerspectiveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tmrMove
            // 
            this.tmrMove.Interval = 1;
            this.tmrMove.Tick += new System.EventHandler(this.tmrMove_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lightResetBtn);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.globalAmbientNum);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lightXtxt);
            this.groupBox2.Controls.Add(this.lightBlueBar);
            this.groupBox2.Controls.Add(this.lightYtxt);
            this.groupBox2.Controls.Add(this.lightZtxt);
            this.groupBox2.Controls.Add(this.lightGrnBar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lightRedBar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(853, 203);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(231, 543);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light Settings";
            // 
            // lightResetBtn
            // 
            this.lightResetBtn.Location = new System.Drawing.Point(63, 411);
            this.lightResetBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightResetBtn.Name = "lightResetBtn";
            this.lightResetBtn.Size = new System.Drawing.Size(100, 28);
            this.lightResetBtn.TabIndex = 20;
            this.lightResetBtn.Text = "Reset";
            this.lightResetBtn.UseVisualStyleBackColor = true;
            this.lightResetBtn.Click += new System.EventHandler(this.lightResetBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 346);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Global Ambient";
            // 
            // globalAmbientNum
            // 
            this.globalAmbientNum.DecimalPlaces = 1;
            this.globalAmbientNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.globalAmbientNum.Location = new System.Drawing.Point(120, 343);
            this.globalAmbientNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.globalAmbientNum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.globalAmbientNum.Name = "globalAmbientNum";
            this.globalAmbientNum.Size = new System.Drawing.Size(91, 22);
            this.globalAmbientNum.TabIndex = 17;
            this.globalAmbientNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.globalAmbientNum.ValueChanged += new System.EventHandler(this.globalAmbientNum_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 281);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Blue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 218);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Green";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "X -";
            // 
            // lightXtxt
            // 
            this.lightXtxt.Location = new System.Drawing.Point(63, 38);
            this.lightXtxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightXtxt.Name = "lightXtxt";
            this.lightXtxt.Size = new System.Drawing.Size(132, 22);
            this.lightXtxt.TabIndex = 7;
            this.lightXtxt.Text = "5";
            this.lightXtxt.TextChanged += new System.EventHandler(this.lightXtxt_TextChanged);
            // 
            // lightBlueBar
            // 
            this.lightBlueBar.LargeChange = 10;
            this.lightBlueBar.Location = new System.Drawing.Point(63, 281);
            this.lightBlueBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightBlueBar.Maximum = 255;
            this.lightBlueBar.Name = "lightBlueBar";
            this.lightBlueBar.Size = new System.Drawing.Size(139, 56);
            this.lightBlueBar.SmallChange = 5;
            this.lightBlueBar.TabIndex = 13;
            this.lightBlueBar.TickFrequency = 10;
            this.lightBlueBar.Value = 255;
            this.lightBlueBar.Scroll += new System.EventHandler(this.lightBlueBar_Scroll);
            // 
            // lightYtxt
            // 
            this.lightYtxt.Location = new System.Drawing.Point(63, 70);
            this.lightYtxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightYtxt.Name = "lightYtxt";
            this.lightYtxt.Size = new System.Drawing.Size(132, 22);
            this.lightYtxt.TabIndex = 7;
            this.lightYtxt.Text = "5";
            this.lightYtxt.TextChanged += new System.EventHandler(this.lightYtxt_TextChanged);
            // 
            // lightZtxt
            // 
            this.lightZtxt.Location = new System.Drawing.Point(63, 102);
            this.lightZtxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightZtxt.Name = "lightZtxt";
            this.lightZtxt.Size = new System.Drawing.Size(132, 22);
            this.lightZtxt.TabIndex = 8;
            this.lightZtxt.Text = "5";
            this.lightZtxt.TextChanged += new System.EventHandler(this.lightZtxt_TextChanged);
            // 
            // lightGrnBar
            // 
            this.lightGrnBar.LargeChange = 10;
            this.lightGrnBar.Location = new System.Drawing.Point(63, 218);
            this.lightGrnBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightGrnBar.Maximum = 255;
            this.lightGrnBar.Name = "lightGrnBar";
            this.lightGrnBar.Size = new System.Drawing.Size(139, 56);
            this.lightGrnBar.SmallChange = 5;
            this.lightGrnBar.TabIndex = 12;
            this.lightGrnBar.TickFrequency = 10;
            this.lightGrnBar.Value = 255;
            this.lightGrnBar.Scroll += new System.EventHandler(this.lightGrnBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y -";
            // 
            // lightRedBar
            // 
            this.lightRedBar.LargeChange = 10;
            this.lightRedBar.Location = new System.Drawing.Point(63, 155);
            this.lightRedBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lightRedBar.Maximum = 255;
            this.lightRedBar.Name = "lightRedBar";
            this.lightRedBar.Size = new System.Drawing.Size(139, 56);
            this.lightRedBar.SmallChange = 5;
            this.lightRedBar.TabIndex = 11;
            this.lightRedBar.TickFrequency = 10;
            this.lightRedBar.Value = 255;
            this.lightRedBar.Scroll += new System.EventHandler(this.lightRedBar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Z -";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 774);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Adam Nielsen - Grant Oberhauser - Program 2";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkX)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.globalAmbientNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightBlueBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightGrnBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightRedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trkX;
        private System.Windows.Forms.TrackBar trkZ;
        private System.Windows.Forms.TrackBar trkY;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.ToolStripMenuItem togglePerspectiveToolStripMenuItem;
        private System.Windows.Forms.Label txtPerspective;
        private System.Windows.Forms.Timer tmrMove;
        private System.Windows.Forms.TrackBar trkTime;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lightXtxt;
        private System.Windows.Forms.TextBox lightYtxt;
        private System.Windows.Forms.TextBox lightZtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar lightRedBar;
        private System.Windows.Forms.TrackBar lightGrnBar;
        private System.Windows.Forms.TrackBar lightBlueBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown globalAmbientNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button lightResetBtn;
    }
}

