using System;
using System.Windows.Forms;
using 单位抽考win7软件.DAL;
using 单位抽考win7软件.UI.Forms;

namespace 单位抽考win7软件
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 初始化数据库
            DatabaseInitializer.Initialize();

            Application.Run(new MainForm());
        }
    }
}
