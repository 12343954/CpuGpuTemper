using LibreHardwareMonitor.Hardware;

namespace CoolooAI.CpuGpuTemperature
{
    internal class HardwareMonitor
    {
        private Computer computer;
        private UpdateVisitor updateVisitor = new UpdateVisitor();

        public HardwareMonitor()
        {
            computer = new Computer
            {
                IsCpuEnabled = true  // 启用 CPU 监测
                                     // 可选启用其他：IsGpuEnabled = true, IsMemoryEnabled = true 等
            };
            computer.Open();  // 打开监测
        }

        public void Update()
        {
            computer.Accept(updateVisitor);  // 更新所有传感器数据
        }

        #region // CPU
        // ---------- CPU ----------
        public float? GetCpuTotalUsage()  // CPU 总体使用率
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Total"))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }

        public float? GetCpuMaxFrequency()  // CPU 最高当前频率（所有核心中最高的一个）
        {
            float? max = null;
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("Core"))
                        {
                            if (sensor.Value > max || max == null)
                                max = sensor.Value;
                        }
                    }
                }
            }
            return max;
        }

        public float? GetCpuPackageTemperature()
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    hardware.Update();  // 额外更新 CPU
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature &&
                            sensor.Name.Contains("Package"))  // 通常是 "CPU Package" 温度（整体封装温度，最常用）
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }

        // 可选：获取核心平均温度或其他
        public float? GetCpuCoreAverageTemperature()
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature &&
                            sensor.Name.Contains("Core Average"))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }
        #endregion

        #region //Memo
        public float? GetMemoryTotalGB()  // 内存总大小 (GB)
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Memory)
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Data && sensor.Name.Contains("Total"))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }

        public float? GetMemoryUsedGB()  // 当前已用内存 (GB)
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Memory)
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Data && sensor.Name.Contains("Used"))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }

        public float? GetMemoryUsagePercent()  // 内存使用率 (%)
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Memory)
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Memory"))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }

        public float? GetMemoryTemperature()
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Memory)
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature &&
                            (sensor.Name.Contains("Memory") ||
                             sensor.Name.Contains("DRAM") ||
                             sensor.Name.Contains("DIMM") ||
                             sensor.Name.Contains("Temperature")))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }
        #endregion

        #region //GPU
        // ---------- GPU ----------
        public float? GetGpuVramTotalMB()  // GPU 显存总大小 (MB)
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType.ToString().Contains("Gpu"))
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.SmallData && sensor.Name.Contains("Memory Total"))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }

        public float? GetGpuVramUsedMB()  // 当前显存占用 (MB)
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType.ToString().Contains("Gpu"))
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.SmallData && sensor.Name.Contains("Memory Used"))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }

        public float? GetGpuVramUsagePercent()  // 显存使用率 (%)
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType.ToString().Contains("Gpu"))
                {
                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Memory"))
                        {
                            return sensor.Value;
                        }
                    }
                }
            }
            return null;
        }
        #endregion
        public void Close()
        {
            computer.Close();
        }
    }
}


