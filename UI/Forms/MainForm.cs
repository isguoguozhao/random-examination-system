using System;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class MainForm : Form
    {
        private Timer _timer;

        public MainForm()
        {
            InitializeComponent();
            InitializeLogo();
            InitializeMdiBackground();
            InitializeTimer();
            UpdateUserInfo();
            CheckPermissions();
        }

        private void InitializeMdiBackground()
        {
            // 在窗体加载时设置MDI背景颜色
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 设置MDI背景为纯色，不显示任何图标
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(230, 240, 210);
                    break;
                }
            }
        }

        private void InitializeLogo()
        {
            try
            {
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "LOGO.png");
                if (System.IO.File.Exists(logoPath))
                {
                    // 创建LOGO面板
                    panelLogo = new Panel();
                    panelLogo.Dock = DockStyle.Top;
                    panelLogo.Height = 80;
                    panelLogo.BackColor = Color.FromArgb(200, 220, 180);

                    // 创建LOGO图片框
                    picLogo = new PictureBox();
                    picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    picLogo.Height = 70;
                    picLogo.Width = 70;
                    picLogo.Top = 5;
                    picLogo.Left = 10;
                    picLogo.Image = Image.FromFile(logoPath);

                    // 创建系统名称标签
                    Label lblSystemName = new Label();
                    lblSystemName.Text = "单位抽考系统";
                    lblSystemName.Font = new Font("微软雅黑", 16, FontStyle.Bold);
                    lblSystemName.AutoSize = true;
                    lblSystemName.Left = 90;
                    lblSystemName.Top = 25;
                    lblSystemName.ForeColor = Color.FromArgb(80, 100, 60);

                    panelLogo.Controls.Add(picLogo);
                    panelLogo.Controls.Add(lblSystemName);

                    // 将LOGO面板插入到菜单栏和工具栏之间
                    this.Controls.Add(panelLogo);
                    this.Controls.SetChildIndex(panelLogo, this.Controls.Count - 2);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"加载LOGO失败: {ex.Message}");
            }
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
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void UpdateUserInfo()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblUserInfo.Text = $"当前用户：{CurrentUser.UserName} ({CurrentUser.RoleName})";
            }
        }

        private void CheckPermissions()
        {
            if (!CurrentUser.IsAdmin)
            {
                menuSystemManage.Visible = false;
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
