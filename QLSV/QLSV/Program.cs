using System;
using System.Windows.Forms;

namespace QLSV
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());  // Bắt đầu chương trình với form đăng nhập
        }
    }
}
