namespace SOSOrganizationManager
{
    partial class MapViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapViewer));
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox2 = new TextBox();
            button4 = new Button();
            menuStrip1 = new MenuStrip();
            changeBackgroundToolStripMenuItem = new ToolStripMenuItem();
            britanniaOSIEasyOnTheEyesToolStripMenuItem = new ToolStripMenuItem();
            britanniaOSIColorToolStripMenuItem = new ToolStripMenuItem();
            britanniaOSIBWToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            britanniaOSIDefaultColorToolStripMenuItem = new ToolStripMenuItem();
            dToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(874, 788);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Aqua;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(56, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 22);
            textBox1.TabIndex = 1;
            textBox1.Text = "##o##'N,##o##'E";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F);
            button1.ForeColor = Color.Navy;
            button1.Location = new Point(201, 114);
            button1.Name = "button1";
            button1.Size = new Size(60, 23);
            button1.TabIndex = 2;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.Navy;
            button2.Location = new Point(56, 114);
            button2.Name = "button2";
            button2.Size = new Size(63, 23);
            button2.TabIndex = 3;
            button2.Text = "Copy";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.ForeColor = Color.Navy;
            button3.Location = new Point(281, 114);
            button3.Name = "button3";
            button3.Size = new Size(123, 23);
            button3.TabIndex = 4;
            button3.Text = "Convert to X, Y";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Aqua;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(281, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(123, 22);
            textBox2.TabIndex = 5;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // button4
            // 
            button4.ForeColor = Color.Navy;
            button4.Location = new Point(127, 114);
            button4.Name = "button4";
            button4.Size = new Size(67, 23);
            button4.TabIndex = 7;
            button4.Text = "Auto-Sort";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 10F);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { changeBackgroundToolStripMenuItem, dToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(874, 32);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // changeBackgroundToolStripMenuItem
            // 
            changeBackgroundToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { britanniaOSIEasyOnTheEyesToolStripMenuItem, britanniaOSIColorToolStripMenuItem, britanniaOSIBWToolStripMenuItem, toolStripSeparator1, britanniaOSIDefaultColorToolStripMenuItem });
            changeBackgroundToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            changeBackgroundToolStripMenuItem.ForeColor = Color.Navy;
            changeBackgroundToolStripMenuItem.Image = SOS_Organization_Manager.Properties.Resources._0012;
            changeBackgroundToolStripMenuItem.Margin = new Padding(554, 0, 10, 0);
            changeBackgroundToolStripMenuItem.Name = "changeBackgroundToolStripMenuItem";
            changeBackgroundToolStripMenuItem.Size = new Size(217, 28);
            changeBackgroundToolStripMenuItem.Text = "Change Background Display";
            // 
            // britanniaOSIEasyOnTheEyesToolStripMenuItem
            // 
            britanniaOSIEasyOnTheEyesToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            britanniaOSIEasyOnTheEyesToolStripMenuItem.Name = "britanniaOSIEasyOnTheEyesToolStripMenuItem";
            britanniaOSIEasyOnTheEyesToolStripMenuItem.Size = new Size(271, 22);
            britanniaOSIEasyOnTheEyesToolStripMenuItem.Text = "Britannia (OSI) - Easy-On-The-Eyes";
            britanniaOSIEasyOnTheEyesToolStripMenuItem.Click += britanniaOSIEasyOnTheEyesToolStripMenuItem_Click;
            // 
            // britanniaOSIColorToolStripMenuItem
            // 
            britanniaOSIColorToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            britanniaOSIColorToolStripMenuItem.Name = "britanniaOSIColorToolStripMenuItem";
            britanniaOSIColorToolStripMenuItem.Size = new Size(271, 22);
            britanniaOSIColorToolStripMenuItem.Text = "Britannia (OSI) - Gray Scale";
            britanniaOSIColorToolStripMenuItem.Click += britanniaOSIColorToolStripMenuItem_Click;
            // 
            // britanniaOSIBWToolStripMenuItem
            // 
            britanniaOSIBWToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            britanniaOSIBWToolStripMenuItem.Name = "britanniaOSIBWToolStripMenuItem";
            britanniaOSIBWToolStripMenuItem.Size = new Size(271, 22);
            britanniaOSIBWToolStripMenuItem.Text = "Britannia (OSI) - Gray Scale (Inverted)";
            britanniaOSIBWToolStripMenuItem.Click += britanniaOSIBWToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(268, 6);
            // 
            // britanniaOSIDefaultColorToolStripMenuItem
            // 
            britanniaOSIDefaultColorToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            britanniaOSIDefaultColorToolStripMenuItem.Name = "britanniaOSIDefaultColorToolStripMenuItem";
            britanniaOSIDefaultColorToolStripMenuItem.Size = new Size(271, 22);
            britanniaOSIDefaultColorToolStripMenuItem.Text = "Britannia (OSI) - Default Color";
            britanniaOSIDefaultColorToolStripMenuItem.Click += britanniaOSIDefaultColorToolStripMenuItem_Click;
            // 
            // dToolStripMenuItem
            // 
            dToolStripMenuItem.Image = SOS_Organization_Manager.Properties.Resources._0011;
            dToolStripMenuItem.Name = "dToolStripMenuItem";
            dToolStripMenuItem.Size = new Size(36, 28);
            dToolStripMenuItem.Click += dToolStripMenuItem_Click;
            // 
            // MapViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 820);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MapViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SOS Organization Manager ";
            TopMost = true;
            Load += MapViewer_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox2;
        private Button button4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem changeBackgroundToolStripMenuItem;
        private ToolStripMenuItem britanniaOSIColorToolStripMenuItem;
        private ToolStripMenuItem britanniaOSIBWToolStripMenuItem;
        private ToolStripMenuItem britanniaOSIDefaultColorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem britanniaOSIEasyOnTheEyesToolStripMenuItem;
        private ToolStripMenuItem dToolStripMenuItem;
    }
}
