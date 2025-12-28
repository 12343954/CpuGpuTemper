using LibreHardwareMonitor.Hardware;
using ScottPlot;
using System.Data;
using System.Diagnostics;

namespace CoolooAI.CpuGpuTemperature
{
    public partial class Form2 : Form
    {
        bool exit = false;

        string cpuName, gpuName, memoName;
        int cpuTemper, gpuTemper, memoTemper;

        List<double> cpuList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> gpuList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> memoList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Point mPoint;

        Computer computer;
        UpdateVisitor updateVisitor;

        List<double> dataX = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, };
        public Form2()
        {
            InitializeComponent();
            init();
        }


        void init()
        {
            topShow_timer2.Enabled = true;
            topShow_timer2.Start();

            //chart1
            formsPlot1.Configuration.LeftClickDragPan = false;
            formsPlot1.Configuration.RightClickDragZoom = false;
            formsPlot1.Configuration.ScrollWheelZoom = false;

            formsPlot2.Configuration.LeftClickDragPan = false;
            formsPlot2.Configuration.RightClickDragZoom = false;
            formsPlot2.Configuration.ScrollWheelZoom = false;

            formsPlot3.Configuration.LeftClickDragPan = false;
            formsPlot3.Configuration.RightClickDragZoom = false;
            formsPlot3.Configuration.ScrollWheelZoom = false;

            formsPlot1.Plot.Style(Style.Black);
            formsPlot1.Plot.XAxis.Label(label: "CPU", bold: true, fontName: "Microsoft Yahei UI");
            formsPlot1.Plot.XAxis.LabelStyle(fontName: "Consolas", fontSize: 20);

            formsPlot2.Plot.Style(Style.Black);
            formsPlot2.Plot.XAxis.Label(label: "MEMO", bold: true, fontName: "Microsoft Yahei UI");
            formsPlot2.Plot.XAxis.LabelStyle(fontName: "Consolas", fontSize: 20);

            formsPlot3.Plot.Style(Style.Black);
            formsPlot3.Plot.XAxis.Label(label: "GPU", bold: true, fontName: "Microsoft Yahei UI");
            formsPlot3.Plot.XAxis.LabelStyle(fontName: "Consolas", fontSize: 20);

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

            // timer1
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            Task.Run(() =>
            {
                Monitor();
            });

        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            Loop();
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
                cpuName = cpu?.Name?.Replace("Intel ", "")?.Replace("AMD ", "") ?? "CPU";
                memoName = memory?.Name?.Replace("Generic ", "") ?? "MEMO";
                gpuName = gpu?.Name?.Replace("NVIDIA ", "")?.Replace("GeForce ", "")?.Replace("AMD ", "")?.Replace("Radeon ", "").Replace("Intel(R) ", "") ?? "GPU";

                formsPlot1.Plot.XAxis.Label(cpuName);
                formsPlot2.Plot.XAxis.Label(memoName);
                formsPlot3.Plot.XAxis.Label(gpuName);

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

                cpuTemper = Convert.ToInt32(cpu?.Sensors.Where(p => p.Name == "Core Max").Where(p => p.SensorType == SensorType.Temperature).FirstOrDefault()?.Value);
                gpuTemper = Convert.ToInt32(gpu?.Sensors.Where(p => p.Name == "GPU Core").ToList().Where(p => p.SensorType == SensorType.Temperature).FirstOrDefault()?.Value);
                memoTemper = Convert.ToInt32(memo_used + memo_avail);


                cpuList.RemoveAt(0);
                cpuList.Add(Convert.ToDouble(cpu?.Sensors.Where(p => p.Name == "CPU Total").Where(p => p.SensorType == SensorType.Load).FirstOrDefault()?.Value));

                gpuList.RemoveAt(0);
                gpuList.Add(Math.Round(gpu_used / 1024 ?? 0, 0));

                memoList.RemoveAt(0);
                memoList.Add(Math.Round(memo_used ?? 0, 0));

                this?.Invoke(new Action(() =>
                {
                    formsPlot1.Plot.XAxis.Label($"{cpuName}\n{cpu?.Sensors.Where(p => p.Name == "CPU Total").Where(p => p.SensorType == SensorType.Load).FirstOrDefault()?.Value?.ToInt()}% {cpuTemper}°");
                    formsPlot2.Plot.XAxis.Label($"{memoName} {memoTemper}GB\n{Math.Round(memo_used ?? 0, 0)}GB ({(memo_used / (memo_used + memo_avail))?.ToString("P")})");
                    formsPlot3.Plot.XAxis.Label($"{gpuName} {Math.Round((gpu_total / 1024) ?? 0, 0)}GB\n{Math.Round(gpu_used / 1024 ?? 0, 0)}GB {gpuTemper}°");

                    formsPlot1.Plot.Clear();
                    formsPlot2.Plot.Clear();
                    formsPlot3.Plot.Clear();

                    formsPlot1.Plot.YAxis.SetInnerBoundary(0, 100);
                    formsPlot1.Plot.AddFill(dataX.ToArray(), cpuList.ToArray());
                    formsPlot1.Refresh();

                    formsPlot2.Plot.YAxis.SetInnerBoundary(0, memoTemper);
                    formsPlot2.Plot.AddFill(dataX.ToArray(), memoList.ToArray());
                    formsPlot2.Refresh();

                    formsPlot3.Plot.YAxis.SetInnerBoundary(0, Math.Round(gpu_total / 1024 ?? 0, 0));
                    formsPlot3.Plot.AddFill(dataX.ToArray(), gpuList.ToArray());
                    formsPlot3.Refresh();

                }));

                this?.Invoke(new Action(() =>
                {
                    if (!formsPlot1.Visible)
                    {
                        loading_img.Visible = false;
                        formsPlot1.Visible = true;
                        formsPlot2.Visible = true;
                        formsPlot3.Visible = true;
                    }
                }));

            });

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            topShow_timer2?.Stop();
            timer1?.Stop();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
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

        private void topShow_timer2_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.BringToFront();
            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
