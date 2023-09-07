namespace CoolooAI.CpuGpuTemperature
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            mill_label = new Label();
            minute_label = new Label();
            label5 = new Label();
            second_label = new Label();
            label3 = new Label();
            hour_label = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            memo_used_label = new Label();
            label2 = new Label();
            memory_label = new Label();
            gpu_temp_label = new Label();
            gpu_used_label = new Label();
            gpu_label = new Label();
            cpu_temp_label = new Label();
            cpu_used_label = new Label();
            cpu_label = new Label();
            watcher_timer = new System.Windows.Forms.Timer(components);
            count_timer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.WindowText;
            textBox1.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(42, 417);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(685, 178);
            textBox1.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Red;
            button1.Location = new Point(762, 7);
            button1.Name = "button1";
            button1.Size = new Size(31, 34);
            button1.TabIndex = 1;
            button1.Text = "❌";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(memo_used_label);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(memory_label);
            panel1.Controls.Add(gpu_temp_label);
            panel1.Controls.Add(gpu_used_label);
            panel1.Controls.Add(gpu_label);
            panel1.Controls.Add(cpu_temp_label);
            panel1.Controls.Add(cpu_used_label);
            panel1.Controls.Add(cpu_label);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 412);
            panel1.TabIndex = 2;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.MouseLeave += panel1_MouseLeave;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.arrow_down;
            pictureBox2.Location = new Point(702, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(20, 10);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(mill_label);
            panel2.Controls.Add(minute_label);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(second_label);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(hour_label);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(11, 236);
            panel2.Name = "panel2";
            panel2.Size = new Size(766, 150);
            panel2.TabIndex = 3;
            panel2.Click += panel2_Click;
            panel2.DoubleClick += panel2_DoubleClick;
            // 
            // mill_label
            // 
            mill_label.AutoSize = true;
            mill_label.Font = new Font("Consolas", 26F, FontStyle.Bold, GraphicsUnit.Point);
            mill_label.ForeColor = SystemColors.ActiveCaption;
            mill_label.Location = new Point(515, 40);
            mill_label.Name = "mill_label";
            mill_label.Size = new Size(114, 61);
            mill_label.TabIndex = 2;
            mill_label.Text = "999";
            mill_label.Click += mill_label_Click;
            mill_label.DoubleClick += mill_label_DoubleClick;
            // 
            // minute_label
            // 
            minute_label.AutoSize = true;
            minute_label.Font = new Font("Consolas", 26F, FontStyle.Bold, GraphicsUnit.Point);
            minute_label.ForeColor = SystemColors.ActiveCaption;
            minute_label.Location = new Point(229, 40);
            minute_label.Name = "minute_label";
            minute_label.Size = new Size(85, 61);
            minute_label.TabIndex = 2;
            minute_label.Text = "59";
            minute_label.Click += mill_label_Click;
            minute_label.DoubleClick += mill_label_DoubleClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(315, 40);
            label5.Name = "label5";
            label5.Size = new Size(56, 61);
            label5.TabIndex = 2;
            label5.Text = ":";
            label5.Click += mill_label_Click;
            label5.DoubleClick += mill_label_DoubleClick;
            // 
            // second_label
            // 
            second_label.AutoSize = true;
            second_label.Font = new Font("Consolas", 26F, FontStyle.Bold, GraphicsUnit.Point);
            second_label.ForeColor = SystemColors.ActiveCaption;
            second_label.Location = new Point(372, 40);
            second_label.Name = "second_label";
            second_label.Size = new Size(85, 61);
            second_label.TabIndex = 2;
            second_label.Text = "59";
            second_label.Click += mill_label_Click;
            second_label.DoubleClick += mill_label_DoubleClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(172, 40);
            label3.Name = "label3";
            label3.Size = new Size(56, 61);
            label3.TabIndex = 2;
            label3.Text = ":";
            label3.Click += mill_label_Click;
            label3.DoubleClick += mill_label_DoubleClick;
            // 
            // hour_label
            // 
            hour_label.AutoSize = true;
            hour_label.Font = new Font("Consolas", 26F, FontStyle.Bold, GraphicsUnit.Point);
            hour_label.ForeColor = SystemColors.ActiveCaption;
            hour_label.Location = new Point(86, 40);
            hour_label.Name = "hour_label";
            hour_label.Size = new Size(85, 61);
            hour_label.TabIndex = 2;
            hour_label.Text = "12";
            hour_label.Click += mill_label_Click;
            hour_label.DoubleClick += mill_label_DoubleClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Consolas", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(458, 40);
            label7.Name = "label7";
            label7.Size = new Size(56, 61);
            label7.TabIndex = 2;
            label7.Text = ":";
            label7.Click += mill_label_Click;
            label7.DoubleClick += mill_label_DoubleClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._00107_2964551981;
            pictureBox1.Location = new Point(9, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // memo_used_label
            // 
            memo_used_label.AutoSize = true;
            memo_used_label.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            memo_used_label.ForeColor = SystemColors.ButtonFace;
            memo_used_label.Location = new Point(398, 172);
            memo_used_label.Name = "memo_used_label";
            memo_used_label.Size = new Size(60, 26);
            memo_used_label.TabIndex = 0;
            memo_used_label.Text = "Memo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(56, 16);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 0;
            label2.Text = "Memo";
            // 
            // memory_label
            // 
            memory_label.AutoSize = true;
            memory_label.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            memory_label.ForeColor = SystemColors.ButtonFace;
            memory_label.Location = new Point(56, 172);
            memory_label.Name = "memory_label";
            memory_label.Size = new Size(60, 26);
            memory_label.TabIndex = 0;
            memory_label.Text = "Memo";
            // 
            // gpu_temp_label
            // 
            gpu_temp_label.AutoSize = true;
            gpu_temp_label.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            gpu_temp_label.ForeColor = SystemColors.ButtonFace;
            gpu_temp_label.Location = new Point(683, 118);
            gpu_temp_label.Name = "gpu_temp_label";
            gpu_temp_label.Size = new Size(48, 26);
            gpu_temp_label.TabIndex = 0;
            gpu_temp_label.Text = "GPU";
            // 
            // gpu_used_label
            // 
            gpu_used_label.AutoSize = true;
            gpu_used_label.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            gpu_used_label.ForeColor = SystemColors.ButtonFace;
            gpu_used_label.Location = new Point(398, 118);
            gpu_used_label.Name = "gpu_used_label";
            gpu_used_label.Size = new Size(48, 26);
            gpu_used_label.TabIndex = 0;
            gpu_used_label.Text = "GPU";
            // 
            // gpu_label
            // 
            gpu_label.AutoSize = true;
            gpu_label.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            gpu_label.ForeColor = SystemColors.ButtonFace;
            gpu_label.Location = new Point(56, 118);
            gpu_label.Name = "gpu_label";
            gpu_label.Size = new Size(48, 26);
            gpu_label.TabIndex = 0;
            gpu_label.Text = "GPU";
            // 
            // cpu_temp_label
            // 
            cpu_temp_label.AutoSize = true;
            cpu_temp_label.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cpu_temp_label.ForeColor = SystemColors.ButtonFace;
            cpu_temp_label.Location = new Point(684, 64);
            cpu_temp_label.Name = "cpu_temp_label";
            cpu_temp_label.Size = new Size(48, 26);
            cpu_temp_label.TabIndex = 0;
            cpu_temp_label.Text = "CPU";
            // 
            // cpu_used_label
            // 
            cpu_used_label.AutoSize = true;
            cpu_used_label.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cpu_used_label.ForeColor = SystemColors.ButtonFace;
            cpu_used_label.Location = new Point(399, 64);
            cpu_used_label.Name = "cpu_used_label";
            cpu_used_label.Size = new Size(48, 26);
            cpu_used_label.TabIndex = 0;
            cpu_used_label.Text = "CPU";
            // 
            // cpu_label
            // 
            cpu_label.AutoSize = true;
            cpu_label.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cpu_label.ForeColor = SystemColors.ButtonFace;
            cpu_label.Location = new Point(56, 64);
            cpu_label.Name = "cpu_label";
            cpu_label.Size = new Size(48, 26);
            cpu_label.TabIndex = 0;
            cpu_label.Text = "CPU";
            // 
            // watcher_timer
            // 
            watcher_timer.Interval = 1000;
            watcher_timer.Tick += watcher_timer_Tick;
            // 
            // count_timer
            // 
            count_timer.Interval = 50;
            count_timer.Tick += count_timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 412);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private Panel panel1;
        private Label memory_label;
        private Label gpu_label;
        private Label cpu_label;
        private Label memo_used_label;
        private Label gpu_used_label;
        private Label cpu_used_label;
        private Label gpu_temp_label;
        private Label cpu_temp_label;
        private System.Windows.Forms.Timer watcher_timer;
        private Label label2;
        private PictureBox pictureBox1;
        private Label mill_label;
        private Label label7;
        private Label second_label;
        private Label label5;
        private Label minute_label;
        private Label label3;
        private Label hour_label;
        private System.Windows.Forms.Timer count_timer;
        private Panel panel2;
        private PictureBox pictureBox2;
    }
}