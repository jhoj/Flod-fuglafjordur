using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flóð
{
    static class Program
    {
        private static Flóð flóð;
        private static Mutex mutex = new Mutex(true, "the-lock");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //this mutex lock is used to prevent multiple instances of opening on this computer.
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(flóð = Flóð.getInstance());                
            }
            else
            {
                //display if the program is running.
                Console.WriteLine("Program is already running.");
            }
        }
    }
}
