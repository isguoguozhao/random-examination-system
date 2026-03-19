using System;
using System.Collections.Generic;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class UserManageForm : Form
    {
        private readonly UserService _userService;
        private List<SysUser> _users;

        public UserManageForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void UserManageForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            _users = _userService.GetAll();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _users;
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["Id"].HeaderText = "ID";
                dgvUsers.Columns["UserName"].HeaderText = "用户名";
                dgvUsers.Columns["RealName"].HeaderText = "真实姓名";
                dgvUsers.Columns["Phone"].HeaderText = "电话";
                dgvUsers.Columns["Email"].HeaderText = "邮箱";
                dgvUsers.Columns["Status"].HeaderText = "状态";
                dgvUsers.Columns["CreateTime"].HeaderText = "创建时间";
                dgvUsers.Columns["Password"].Visible = false;
                dgvUsers.Columns["LastLoginTime"].HeaderText = "最后登录时间";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new UserEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                    LogService.AddLog("用户管理", "新增用户", $"新增用户：{form.UserName}");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("请选择要编辑的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = dgvUsers.CurrentRow.DataBoundItem as SysUser;
            if (user != null)
            {
                using (var form = new UserEditForm(user))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadUsers();
                        LogService.AddLog("用户管理", "编辑用户", $"编辑用户：{user.UserName}");
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("请选择要删除的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = dgvUsers.CurrentRow.DataBoundItem as SysUser;
            if (user != null)
            {
                if (user.UserName == "admin")
                {
                    MessageBox.Show("不能删除系统管理员账号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"确定要删除用户 [{user.UserName}] 吗？", "确认删除", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_userService.Delete(user.Id))
                    {
                        LoadUsers();
                        LogService.AddLog("用户管理", "删除用户", $"删除用户：{user.UserName}");
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadUsers();
            }
            else
            {
                _users = _users.FindAll(u => 
                    u.UserName.Contains(keyword) || 
                    u.RealName.Contains(keyword));
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _users;
                FormatGrid();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
