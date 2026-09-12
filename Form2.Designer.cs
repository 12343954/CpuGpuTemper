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
            gpu_temp = new TemperatureBar();
            cpu_temp = new TemperatureBar();
            button2 = new Button();
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
            formsPlot1.Location = new Point(7, 95);
            formsPlot1.Margin = new Padding(7, 6, 7, 6);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(456, 386);
            formsPlot1.TabIndex = 0;
            formsPlot1.Visible = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // formsPlot2
            // 
            formsPlot2.Location = new Point(516, 95);
            formsPlot2.Margin = new Padding(7, 6, 7, 6);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(456, 386);
            formsPlot2.TabIndex = 1;
            formsPlot2.Visible = false;
            // 
            // formsPlot3
            // 
            formsPlot3.Location = new Point(1015, 95);
            formsPlot3.Margin = new Padding(7, 6, 7, 6);
            formsPlot3.Name = "formsPlot3";
            formsPlot3.Size = new Size(456, 386);
            formsPlot3.TabIndex = 2;
            formsPlot3.Visible = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(gpu_temp);
            panel1.Controls.Add(cpu_temp);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(loading_img);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(formsPlot1);
            panel1.Controls.Add(formsPlot3);
            panel1.Controls.Add(formsPlot2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1524, 533);
            panel1.TabIndex = 3;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // gpu_temp
            // 
            gpu_temp.BackColor = Color.Black;
            gpu_temp.Font = new Font("Segoe UI", 9F);
            gpu_temp.Location = new Point(1459, 117);
            gpu_temp.Margin = new Padding(4);
            gpu_temp.Name = "gpu_temp";
            gpu_temp.Orientation = Orientation.Vertical;
            gpu_temp.Size = new Size(30, 290);
            gpu_temp.TabIndex = 8;
            // 
            // cpu_temp
            // 
            cpu_temp.BackColor = Color.Black;
            cpu_temp.Font = new Font("Segoe UI", 9F);
            cpu_temp.Location = new Point(451, 117);
            cpu_temp.Margin = new Padding(4);
            cpu_temp.Name = "cpu_temp";
            cpu_temp.Orientation = Orientation.Vertical;
            cpu_temp.Size = new Size(30, 290);
            cpu_temp.TabIndex = 7;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.Black;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 64);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(1405, 5);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(48, 41);
            button2.TabIndex = 6;
            button2.Text = "__";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // loading_img
            // 
            loading_img.BackgroundImageLayout = ImageLayout.Center;
            loading_img.Image = Properties.Resources.giphy;
            loading_img.Location = new Point(604, 122);
            loading_img.Margin = new Padding(4);
            loading_img.Name = "loading_img";
            loading_img.Size = new Size(307, 307);
            loading_img.SizeMode = PictureBoxSizeMode.Zoom;
            loading_img.TabIndex = 5;
            loading_img.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._00107_2964551981;
            pictureBox1.Location = new Point(-4, 0);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.Black;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 64);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Red;
            button1.Location = new Point(1472, 11);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(37, 41);
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
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1524, 533);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
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
        private Button button2;
        private TemperatureBar cpu_temp;
        private TemperatureBar gpu_temp;
    }
}