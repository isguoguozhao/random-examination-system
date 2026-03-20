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

            // 显示登录界面
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // 登录成功，显示主界面
                    Application.Run(new MainForm());
                }
                else
                {
                    // 登录失败或取消，退出程序
                    Application.Exit();
                }
            }
        }
    }
}
