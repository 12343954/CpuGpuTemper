using LibreHardwareMonitor.Hardware;
using System.Diagnostics;

namespace CoolooAI.CpuGpuTemperature
{
    public partial class Form1 : Form
    {
        bool exit = false;
        bool is_started = false;

        Point mPoint;

        Computer computer;
        UpdateVisitor updateVisitor;

        Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            hour_label.Text = "0";
            minute_label.Text = "00";
            second_label.Text = "00";
            mill_label.Text = "000";

            computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                //IsMotherboardEnabled = true,
                //IsControllerEnabled = true,
                //IsNetworkEnabled = true,
                //IsStorageEnabled = true
            };
            updateVisitor = new UpdateVisitor();

            stopwatch = new Stopwatch();

            this.timer1.Enabled = true;
            this.watcher_timer.Enabled = true;
            this.label2.Visible = false;

            Task.Run(() =>
            {
                Monitor();
            });
        }

        public void Monitor()
        {
            computer.Open();
            computer.Accept(updateVisitor);

            var cpu = computer.Hardware.Where(p => p.HardwareType == HardwareType.Cpu).FirstOrDefault();
            var gpu = computer.Hardware.Where(p => p.HardwareType == HardwareType.GpuNvidia
                                                    || p.HardwareType == HardwareType.GpuAmd
                                                    || p.HardwareType == HardwareType.GpuIntel).FirstOrDefault();
            var memory = computer.Hardware.Where(p => p.HardwareType == HardwareType.Memory).FirstOrDefault();

            Invoke(new Action(() =>
            {
                cpu_label.Text = cpu?.Name;
                gpu_label.Text = gpu?.Name;
                memory_label.Text = memory?.Name;
            }));
        }

        void Loop()
        {
            if (exit) return;

            Task.Run(() =>
            {
                if (exit) return;
                if (computer == null) return;

                computer.Accept(updateVisitor);

                var cpu = computer.Hardware.Where(p => p.HardwareType == HardwareType.Cpu).FirstOrDefault();
                var gpu = computer.Hardware.Where(p => p.HardwareType == HardwareType.GpuNvidia
                                                        || p.HardwareType == HardwareType.GpuAmd
                                                        || p.HardwareType == HardwareType.GpuIntel).FirstOrDefault();
                var memory = computer.Hardware.Where(p => p.HardwareType == HardwareType.Memory).FirstOrDefault();

                var gpu_total = gpu?.Sensors.Where(p => p.Name == "GPU Memory Total").FirstOrDefault()?.Value;
                var gpu_used = gpu?.Sensors.Where(p => p.Name == "GPU Memory Used").FirstOrDefault()?.Value;

                var memo_used = memory?.Sensors.Where(p => p.Name == "Memory Used").FirstOrDefault()?.Value;
                var memo_avail = memory?.Sensors.Where(p => p.Name == "Memory Available").FirstOrDefault()?.Value;

                Invoke(new Action(() =>
                {
                    cpu_temp_label.Text = $"{cpu?.Sensors.Where(p => p.Name == "Core Max").Where(p => p.SensorType == SensorType.Temperature).FirstOrDefault()?.Value}бу";
                    gpu_temp_label.Text = $"{gpu?.Sensors.Where(p => p.Name == "GPU Core").ToList().Where(p => p.SensorType == SensorType.Temperature).FirstOrDefault()?.Value}бу";

                    cpu_used_label.Text = $"{cpu?.Sensors.Where(p => p.Name == "CPU Total").Where(p => p.SensorType == SensorType.Load).FirstOrDefault()?.Value?.ToInt()}%";

                    gpu_used_label.Text = $"{Math.Round(gpu_used / 1024 ?? 0, 0)}GB/{Math.Round((gpu_total / 1024) ?? 0, 0)}GB ({(gpu_used / gpu_total)?.ToString("P")})";

                    memo_used_label.Text = $"{Math.Round(memo_used ?? 0, 0)}GB/{(Math.Round((memo_used + memo_avail) ?? 0, 0))}GB ({(memo_used / (memo_used + memo_avail))?.ToString("P")})";
                }));

            });

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.BringToFront();
            this.TopMost = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            //button1.Visible = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //button1.Visible = false;
        }

        private void watcher_timer_Tick(object sender, EventArgs e)
        {
            //label2.Text = (counter++).ToString();
            Loop();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            computer.Close();
        }

        private void startCounter()
        {
            is_started = !is_started;

            if (is_started)
            {
                stopwatch.Start();
                count_timer.Start();
            }
            else
            {
                stopwatch.Stop();
                count_timer.Stop();
            }
        }

        private void count_timer_Tick(object sender, EventArgs e)
        {
            hour_label.Text = stopwatch.Elapsed.Hours.ToString();
            minute_label.Text = stopwatch.Elapsed.Minutes.ToString().PadLeft(2, '0');
            second_label.Text = stopwatch.Elapsed.Seconds.ToString().PadLeft(2, '0');
            mill_label.Text = stopwatch.Elapsed.Milliseconds.ToString();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            startCounter();
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            count_timer.Stop();
            hour_label.Text = "0";
            minute_label.Text = "00";
            second_label.Text = "00";
            mill_label.Text = "000";
        }

        private void mill_label_Click(object sender, EventArgs e)
        {
            startCounter();
        }

        private void mill_label_DoubleClick(object sender, EventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            count_timer.Stop();
            hour_label.Text = "0";
            minute_label.Text = "00";
            second_label.Text = "00";
            mill_label.Text = "000";
        }
    }
}