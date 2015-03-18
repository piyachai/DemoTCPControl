using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Win32;
using System.IO;
namespace DparkTerminal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [STAThread]
        static void Main()
        {

            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "DparkTerminal", out createdNew))
            {
                if (createdNew)
                {

//AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Application.Run(new fmLogin());

                    mutex.ReleaseMutex();
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }
    }
}
