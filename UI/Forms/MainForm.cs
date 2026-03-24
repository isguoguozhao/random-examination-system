using System;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class MainForm : Form
    {
        private Timer _timer;
        private Button _currentSelectedButton;

        public MainForm()
        {
            InitializeComponent();
            InitializeNavigationMenu();
            InitializeUserInfo();
            InitializeTimer();
            UpdateUserInfo();
            CheckPermissions();
        }

        private void InitializeNavigationMenu()
        {
            int yPosition = 16;

            AddMenuGroupLabel("基础数据", ref yPosition);
            AddMenuItem("单位管理", menuOrgUnit_Click, ref yPosition);
            AddMenuItem("人员管理", menuPerson_Click, ref yPosition);
            AddMenuItem("指挥组管理", menuCommandGroup_Click, ref yPosition);
            AddMenuItem("任务方案管理", menuTaskPlan_Click, ref yPosition);

            AddMenuGroupLabel("抽考管理", ref yPosition);
            AddMenuItem("抽考活动", menuExamActivity_Click, ref yPosition);

            AddMenuGroupLabel("系统管理", ref yPosition, "menuSystemManage");
            AddMenuItem("用户管理", menuUser_Click, ref yPosition);
            AddMenuItem("必抽设置", menuMustHitRule_Click, ref yPosition);
            AddMenuItem("操作日志", menuLog_Click, ref yPosition);
            AddMenuItem("修改密码", menuChangePassword_Click, ref yPosition);
            AddMenuItem("退出系统", menuExit_Click, ref yPosition);
        }

        private void AddMenuGroupLabel(string text, ref int yPosition, string name = "")
        {
            var label = new Label
            {
                Text = text,
                Name = name,
                ForeColor = Color.Gray,
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                AutoSize = true,
                Left = 20,
                Top = yPosition
            };
            panelNavContent.Controls.Add(label);
            yPosition += 36;
        }

        private void AddMenuItem(string text, EventHandler clickHandler, ref int yPosition)
        {
            var btn = new Button
            {
                Text = text,
                Width = 228,
                Height = 48,
                Left = 16,
                Top = yPosition,
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                Font = new Font("微软雅黑", 12F, FontStyle.Regular),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(24, 0, 0, 0)
            };

            btn.Click += delegate (object sender, EventArgs e)
            {
                if (clickHandler != null)
                {
                    clickHandler(sender, e);
                }
            };

            panelNavContent.Controls.Add(btn);
            yPosition += 56;
        }

        private void InitializeUserInfo()
        {
            lblCurrentUser.Parent = panelUserInfo;
            lblCurrentTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
            UpdateTime();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            lblCurrentTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void UpdateUserInfo()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblCurrentUser.Text = $"当前用户：{CurrentUser.UserName} ({CurrentUser.RoleName})";
            }
        }

        private void CheckPermissions()
        {
            if (!CurrentUser.IsAdmin)
            {
                foreach (Control ctrl in panelNavContent.Controls)
                {
                    if (ctrl.Name == "menuSystemManage" || 
                        (ctrl is Button btn && (btn.Text == "用户管理" || btn.Text == "必抽设置" || btn.Text == "操作日志")))
                    {
                        ctrl.Visible = false;
                    }
                }
            }
        }

        private void menuOrgUnit_Click(object sender, EventArgs e)
        {
            OpenForm(new OrgUnitForm());
        }

        private void menuPerson_Click(object sender, EventArgs e)
        {
            OpenForm(new PersonForm());
        }

        private void menuCommandGroup_Click(object sender, EventArgs e)
        {
            OpenForm(new CommandGroupForm());
        }

        private void menuTaskPlan_Click(object sender, EventArgs e)
        {
            OpenForm(new TaskPlanForm());
        }

        private void menuExamActivity_Click(object sender, EventArgs e)
        {
            OpenForm(new ExamActivityForm());
        }

        private void menuUser_Click(object sender, EventArgs e)
        {
            OpenForm(new UserManageForm());
        }

        private void menuMustHitRule_Click(object sender, EventArgs e)
        {
            OpenForm(new MustHitRuleForm());
        }

        private void menuLog_Click(object sender, EventArgs e)
        {
            OpenForm(new LogForm());
        }

        private void menuChangePassword_Click(object sender, EventArgs e)
        {
            using (var form = new PasswordForm())
            {
                form.ShowDialog(this);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LogService.AddLog("系统", "用户退出", $"用户 {CurrentUser.UserName} 退出系统");
                CurrentUser.Logout();
                Application.Exit();
            }
        }

        private void OpenForm(Form form)
        {
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("确定要退出系统吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                LogService.AddLog("系统", "用户退出", $"用户 {CurrentUser.UserName} 退出系统");
            }
            base.OnFormClosing(e);
        }
    }
}
