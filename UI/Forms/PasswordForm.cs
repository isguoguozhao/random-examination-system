using System;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class PasswordForm : Form
    {
        private readonly UserService _userService;

        public PasswordForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldPassword))
            {
                MessageBox.Show("请输入旧密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("请输入新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("两次输入的新密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("新密码长度不能少于6位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (_userService.ChangePassword(CurrentUser.CurrentUserId, oldPassword, newPassword))
            {
                LogService.AddLog("系统", "修改密码", $"用户 {CurrentUser.CurrentUserName} 修改了密码");
                MessageBox.Show("密码修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("旧密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPassword.Clear();
                txtOldPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
