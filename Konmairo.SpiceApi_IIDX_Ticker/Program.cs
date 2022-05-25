using System;
using System.Windows.Forms;

namespace Konmairo.SpiceApi_IIDX_Ticker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IIDX_Ticker());
        }
    }
}
