using System;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadLogo();
            LoadSavedAccount();
        }

        private void LoadLogo()
        {
            try
            {
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "LOGO.png");
                if (System.IO.File.Exists(logoPath))
                {
                    picLogo.Image = Image.FromFile(logoPath);
                }
            }
            catch (Exception ex)
            {
                // 如果加载LOGO失败，不显示错误，继续使用默认界面
                System.Diagnostics.Debug.WriteLine($"加载LOGO失败: {ex.Message}");
            }
        }

        private void LoadSavedAccount()
        {
            string savedAccount = Properties.Settings.Default.SavedAccount;
            if (!string.IsNullOrEmpty(savedAccount))
            {
                txtUsername.Text = savedAccount;
                chkRemember.Checked = true;
                txtPassword.Focus();
            }
            else
            {
                txtUsername.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            var user = _userService.Login(username, password);
            if (user != null)
            {
                var roles = _userService.GetUserRoles(user.Id);
                CurrentUser.Login(user, roles);

                if (chkRemember.Checked)
                {
                    Properties.Settings.Default.SavedAccount = username;
                }
                else
                {
                    Properties.Settings.Default.SavedAccount = "";
                }
                Properties.Settings.Default.Save();

                LogService.AddLog("登录", "用户登录", $"用户 {username} 登录系统");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}
