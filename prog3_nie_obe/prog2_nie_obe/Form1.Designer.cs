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
            this.txtPerspective = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            this.lblZ = new System.Windows.Forms.Label();
            this.trkZ = new System.Windows.Forms.TrackBar();
            this.lblY = new System.Windows.Forms.Label();
            this.trkY = new System.Windows.Forms.TrackBar();
            this.lblX = new System.Windows.Forms.Label();
            this.trkX = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.togglePerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrMove = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkX)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 140);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(801, 478);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPerspective);
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.Controls.Add(this.lblZ);
            this.groupBox1.Controls.Add(this.trkZ);
            this.groupBox1.Controls.Add(this.lblY);
            this.groupBox1.Controls.Add(this.trkY);
            this.groupBox1.Controls.Add(this.lblX);
            this.groupBox1.Controls.Add(this.trkX);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 107);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "X, Y, Z values of the View Reference Point (Eyeball) looking at (0,0,0) with Y up" +
    "";
            // 
            // txtPerspective
            // 
            this.txtPerspective.AutoSize = true;
            this.txtPerspective.Location = new System.Drawing.Point(663, 16);
            this.txtPerspective.Name = "txtPerspective";
            this.txtPerspective.Size = new System.Drawing.Size(24, 13);
            this.txtPerspective.TabIndex = 7;
            this.txtPerspective.Text = "text";
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(666, 47);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(451, 26);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(35, 13);
            this.lblZ.TabIndex = 5;
            this.lblZ.Text = "label3";
            // 
            // trkZ
            // 
            this.trkZ.Location = new System.Drawing.Point(486, 56);
            this.trkZ.Maximum = 25;
            this.trkZ.Minimum = -25;
            this.trkZ.Name = "trkZ";
            this.trkZ.Size = new System.Drawing.Size(174, 45);
            this.trkZ.TabIndex = 4;
            this.trkZ.Value = 5;
            this.trkZ.Scroll += new System.EventHandler(this.trkZ_Scroll);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(242, 26);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(35, 13);
            this.lblY.TabIndex = 3;
            this.lblY.Text = "label2";
            // 
            // trkY
            // 
            this.trkY.Location = new System.Drawing.Point(277, 56);
            this.trkY.Maximum = 25;
            this.trkY.Minimum = -25;
            this.trkY.Name = "trkY";
            this.trkY.Size = new System.Drawing.Size(174, 45);
            this.trkY.TabIndex = 2;
            this.trkY.Value = 5;
            this.trkY.Scroll += new System.EventHandler(this.trkY_Scroll);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(33, 26);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(35, 13);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "label1";
            // 
            // trkX
            // 
            this.trkX.Location = new System.Drawing.Point(68, 56);
            this.trkX.Maximum = 25;
            this.trkX.Minimum = -25;
            this.trkX.Name = "trkX";
            this.trkX.Size = new System.Drawing.Size(174, 45);
            this.trkX.TabIndex = 0;
            this.trkX.Value = 5;
            this.trkX.Scroll += new System.EventHandler(this.trkX_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(825, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // togglePerspectiveToolStripMenuItem
            // 
            this.togglePerspectiveToolStripMenuItem.Name = "togglePerspectiveToolStripMenuItem";
            this.togglePerspectiveToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.togglePerspectiveToolStripMenuItem.Text = "Toggle Perspective";
            this.togglePerspectiveToolStripMenuItem.Click += new System.EventHandler(this.togglePerspectiveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tmrMove
            // 
            this.tmrMove.Enabled = true;
            this.tmrMove.Interval = 1;
            this.tmrMove.Tick += new System.EventHandler(this.tmrMove_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 629);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Adam Nielsen - Grant Oberhauser - Program 2";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkX)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trkX;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.TrackBar trkZ;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TrackBar trkY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.ToolStripMenuItem togglePerspectiveToolStripMenuItem;
        private System.Windows.Forms.Label txtPerspective;
        private System.Windows.Forms.Timer tmrMove;
    }
}

