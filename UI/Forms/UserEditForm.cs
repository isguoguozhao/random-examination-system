using System;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class UserEditForm : Form
    {
        private readonly UserService _userService;
        private SysUser _user;
        public string UserName { get; private set; }

        public UserEditForm()
        {
            InitializeComponent();
            _userService = new UserService();
            _user = null;
            this.Text = "新增用户";
        }

        public UserEditForm(SysUser user)
        {
            InitializeComponent();
            _userService = new UserService();
            _user = user;
            this.Text = "编辑用户";
            LoadUserData();
        }

        private void LoadUserData()
        {
            if (_user != null)
            {
                txtUserName.Text = _user.UserName;
                txtUserName.ReadOnly = true;
                txtRealName.Text = _user.RealName;
                txtPhone.Text = _user.Phone;
                txtEmail.Text = _user.Email;
                chkStatus.Checked = _user.Status == 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_user == null)
                {
                    // 新增
                    var newUser = new SysUser
                    {
                        UserName = txtUserName.Text.Trim(),
                        Password = "admin", // 默认密码
                        RealName = txtRealName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Status = chkStatus.Checked ? 1 : 0,
                        CreateTime = DateTime.Now
                    };

                    int newId = _userService.Add(newUser);
                    if (newId > 0)
                    {
                        UserName = newUser.UserName;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // 编辑
                    _user.RealName = txtRealName.Text.Trim();
                    _user.Phone = txtPhone.Text.Trim();
                    _user.Email = txtEmail.Text.Trim();
                    _user.Status = chkStatus.Checked ? 1 : 0;

                    if (_userService.Update(_user))
                    {
                        UserName = _user.UserName;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRealName.Text))
            {
                MessageBox.Show("请输入真实姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRealName.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
