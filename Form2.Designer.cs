namespace CoolooAI.CpuGpuTemperature
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            formsPlot1 = new ScottPlot.FormsPlot();
            timer1 = new System.Windows.Forms.Timer(components);
            formsPlot2 = new ScottPlot.FormsPlot();
            formsPlot3 = new ScottPlot.FormsPlot();
            panel1 = new Panel();
            loading_img = new PictureBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            topShow_timer2 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loading_img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.BackColor = Color.Transparent;
            formsPlot1.Location = new Point(6, 79);
            formsPlot1.Margin = new Padding(6, 5, 6, 5);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(380, 322);
            formsPlot1.TabIndex = 0;
            formsPlot1.Visible = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // formsPlot2
            // 
            formsPlot2.Location = new Point(426, 79);
            formsPlot2.Margin = new Padding(6, 5, 6, 5);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(380, 322);
            formsPlot2.TabIndex = 1;
            formsPlot2.Visible = false;
            // 
            // formsPlot3
            // 
            formsPlot3.Location = new Point(846, 79);
            formsPlot3.Margin = new Padding(6, 5, 6, 5);
            formsPlot3.Name = "formsPlot3";
            formsPlot3.Size = new Size(380, 322);
            formsPlot3.TabIndex = 2;
            formsPlot3.Visible = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(loading_img);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(formsPlot1);
            panel1.Controls.Add(formsPlot3);
            panel1.Controls.Add(formsPlot2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1270, 444);
            panel1.TabIndex = 3;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // loading_img
            // 
            loading_img.BackgroundImageLayout = ImageLayout.Center;
            loading_img.Image = Properties.Resources.giphy;
            loading_img.Location = new Point(503, 102);
            loading_img.Name = "loading_img";
            loading_img.Size = new Size(256, 256);
            loading_img.SizeMode = PictureBoxSizeMode.Zoom;
            loading_img.TabIndex = 5;
            loading_img.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._00107_2964551981;
            pictureBox1.Location = new Point(2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.Black;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 64);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Red;
            button1.Location = new Point(1234, 4);
            button1.Name = "button1";
            button1.Size = new Size(31, 34);
            button1.TabIndex = 3;
            button1.Text = "❌";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // topShow_timer2
            // 
            topShow_timer2.Tick += topShow_timer2_Tick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1270, 444);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            FormClosing += Form2_FormClosing;
            MouseDown += Form2_MouseDown;
            MouseMove += Form2_MouseMove;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)loading_img).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Timer timer1;
        private ScottPlot.FormsPlot formsPlot2;
        private ScottPlot.FormsPlot formsPlot3;
        private Panel panel1;
        private System.Windows.Forms.Timer topShow_timer2;
        private Button button1;
        private PictureBox pictureBox1;
        private PictureBox loading_img;
    }
}