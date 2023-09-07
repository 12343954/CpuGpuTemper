using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CoolooAI.CpuGpuTemperature
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (RunningInstance())
            {
                return;
            }


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            Application.Run(new Form2());
        }

        public static bool RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            var p = Process.GetProcessesByName(current.ProcessName).FirstOrDefault(x => x.Id != current.Id);
            if (p != null)
            {
                SetForegroundWindow(p.MainWindowHandle);
                SendMessage(p.MainWindowHandle, WM_SYSCOMMAND, SC_RESTORE, 0);
                return true;
            }

            return false;
        }


        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_RESTORE = 0xF120;
    }
}