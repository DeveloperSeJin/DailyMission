using System;
using System.Windows.Forms;

namespace MyHomeworkApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // 폼 실행
            Application.Run(new Form1());
        }
    }
}
