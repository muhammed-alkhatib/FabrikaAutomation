using System;
using System.Windows.Forms;

namespace FabrikaAutomation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // شاشة الدخول أولاً
            Application.Run(new LoginForm());
        }
    }
}
