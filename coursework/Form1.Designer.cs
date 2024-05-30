namespace coursework
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
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            SelectFileButton = new ToolStripMenuItem();
            FindObjButton = new ToolStripMenuItem();
            SaveImgButton = new ToolStripMenuItem();
            pictureBox2 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            checkBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(391, 402);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { SelectFileButton, FindObjButton, SaveImgButton });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(810, 38);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // SelectFileButton
            // 
            SelectFileButton.Name = "SelectFileButton";
            SelectFileButton.Padding = new Padding(5);
            SelectFileButton.Size = new Size(59, 34);
            SelectFileButton.Text = "Open";
            SelectFileButton.Click += SelectFileButton_Click;
            // 
            // FindObjButton
            // 
            FindObjButton.Name = "FindObjButton";
            FindObjButton.Size = new Size(103, 34);
            FindObjButton.Text = "Find objects";
            FindObjButton.Click += FindObjButton_Click;
            // 
            // SaveImgButton
            // 
            SaveImgButton.Alignment = ToolStripItemAlignment.Right;
            SaveImgButton.Name = "SaveImgButton";
            SaveImgButton.Size = new Size(54, 34);
            SaveImgButton.Text = "Save";
            SaveImgButton.Click += SaveImgButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(409, 36);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(391, 402);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff;*.tif;*jfif";
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new Point(170, 9);
            checkBox.Margin = new Padding(0);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(230, 24);
            checkBox.TabIndex = 3;
            checkBox.Text = "show in a picture with borders";
            checkBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 450);
            Controls.Add(checkBox);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Object Locator";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem SelectFileButton;
        private ToolStripMenuItem FindObjButton;
        private ToolStripMenuItem SaveImgButton;
        private PictureBox pictureBox2;
        private OpenFileDialog openFileDialog1;
        private CheckBox checkBox;
    }
}
