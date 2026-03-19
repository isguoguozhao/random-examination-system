namespace 单位抽考win7软件.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuBaseData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrgUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCommandGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTaskPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExamManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExamActivity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSystemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMustHitRule = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnOrgUnit = new System.Windows.Forms.ToolStripButton();
            this.btnPerson = new System.Windows.Forms.ToolStripButton();
            this.btnCommandGroup = new System.Windows.Forms.ToolStripButton();
            this.btnTaskPlan = new System.Windows.Forms.ToolStripButton();
            this.btnExamActivity = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUserInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.menuStrip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBaseData,
            this.menuExamManage,
            this.menuSystemManage});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuBaseData
            // 
            this.menuBaseData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOrgUnit,
            this.menuPerson,
            this.menuCommandGroup,
            this.menuTaskPlan});
            this.menuBaseData.Name = "menuBaseData";
            this.menuBaseData.Size = new System.Drawing.Size(83, 24);
            this.menuBaseData.Text = "基础数据";
            // 
            // menuOrgUnit
            // 
            this.menuOrgUnit.Name = "menuOrgUnit";
            this.menuOrgUnit.Size = new System.Drawing.Size(152, 24);
            this.menuOrgUnit.Text = "单位管理";
            this.menuOrgUnit.Click += new System.EventHandler(this.menuOrgUnit_Click);
            // 
            // menuPerson
            // 
            this.menuPerson.Name = "menuPerson";
            this.menuPerson.Size = new System.Drawing.Size(152, 24);
            this.menuPerson.Text = "人员管理";
            this.menuPerson.Click += new System.EventHandler(this.menuPerson_Click);
            // 
            // menuCommandGroup
            // 
            this.menuCommandGroup.Name = "menuCommandGroup";
            this.menuCommandGroup.Size = new System.Drawing.Size(152, 24);
            this.menuCommandGroup.Text = "指挥组管理";
            this.menuCommandGroup.Click += new System.EventHandler(this.menuCommandGroup_Click);
            // 
            // menuTaskPlan
            // 
            this.menuTaskPlan.Name = "menuTaskPlan";
            this.menuTaskPlan.Size = new System.Drawing.Size(152, 24);
            this.menuTaskPlan.Text = "任务方案管理";
            this.menuTaskPlan.Click += new System.EventHandler(this.menuTaskPlan_Click);
            // 
            // menuExamManage
            // 
            this.menuExamManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExamActivity});
            this.menuExamManage.Name = "menuExamManage";
            this.menuExamManage.Size = new System.Drawing.Size(83, 24);
            this.menuExamManage.Text = "抽考管理";
            // 
            // menuExamActivity
            // 
            this.menuExamActivity.Name = "menuExamActivity";
            this.menuExamActivity.Size = new System.Drawing.Size(152, 24);
            this.menuExamActivity.Text = "抽考活动";
            this.menuExamActivity.Click += new System.EventHandler(this.menuExamActivity_Click);
            // 
            // menuSystemManage
            // 
            this.menuSystemManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUser,
            this.menuMustHitRule,
            this.menuLog,
            this.toolStripSeparator1,
            this.menuChangePassword,
            this.menuExit});
            this.menuSystemManage.Name = "menuSystemManage";
            this.menuSystemManage.Size = new System.Drawing.Size(83, 24);
            this.menuSystemManage.Text = "系统管理";
            // 
            // menuUser
            // 
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(152, 24);
            this.menuUser.Text = "用户管理";
            this.menuUser.Click += new System.EventHandler(this.menuUser_Click);
            // 
            // menuMustHitRule
            // 
            this.menuMustHitRule.Name = "menuMustHitRule";
            this.menuMustHitRule.Size = new System.Drawing.Size(152, 24);
            this.menuMustHitRule.Text = "必抽设置";
            this.menuMustHitRule.Click += new System.EventHandler(this.menuMustHitRule_Click);
            // 
            // menuLog
            // 
            this.menuLog.Name = "menuLog";
            this.menuLog.Size = new System.Drawing.Size(152, 24);
            this.menuLog.Text = "操作日志";
            this.menuLog.Click += new System.EventHandler(this.menuLog_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuChangePassword
            // 
            this.menuChangePassword.Name = "menuChangePassword";
            this.menuChangePassword.Size = new System.Drawing.Size(152, 24);
            this.menuChangePassword.Text = "修改密码";
            this.menuChangePassword.Click += new System.EventHandler(this.menuChangePassword_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(152, 24);
            this.menuExit.Text = "退出系统";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(200)))));
            this.toolStrip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOrgUnit,
            this.btnPerson,
            this.btnCommandGroup,
            this.btnTaskPlan,
            this.btnExamActivity,
            this.toolStripSeparator2,
            this.btnExit});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1008, 27);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnOrgUnit
            // 
            this.btnOrgUnit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOrgUnit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrgUnit.Name = "btnOrgUnit";
            this.btnOrgUnit.Size = new System.Drawing.Size(73, 24);
            this.btnOrgUnit.Text = "单位管理";
            this.btnOrgUnit.Click += new System.EventHandler(this.menuOrgUnit_Click);
            // 
            // btnPerson
            // 
            this.btnPerson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPerson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(73, 24);
            this.btnPerson.Text = "人员管理";
            this.btnPerson.Click += new System.EventHandler(this.menuPerson_Click);
            // 
            // btnCommandGroup
            // 
            this.btnCommandGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCommandGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCommandGroup.Name = "btnCommandGroup";
            this.btnCommandGroup.Size = new System.Drawing.Size(88, 24);
            this.btnCommandGroup.Text = "指挥组管理";
            this.btnCommandGroup.Click += new System.EventHandler(this.menuCommandGroup_Click);
            // 
            // btnTaskPlan
            // 
            this.btnTaskPlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTaskPlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaskPlan.Name = "btnTaskPlan";
            this.btnTaskPlan.Size = new System.Drawing.Size(103, 24);
            this.btnTaskPlan.Text = "任务方案管理";
            this.btnTaskPlan.Click += new System.EventHandler(this.menuTaskPlan_Click);
            // 
            // btnExamActivity
            // 
            this.btnExamActivity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExamActivity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExamActivity.Name = "btnExamActivity";
            this.btnExamActivity.Size = new System.Drawing.Size(73, 24);
            this.btnExamActivity.Text = "抽考活动";
            this.btnExamActivity.Click += new System.EventHandler(this.menuExamActivity_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 24);
            this.btnExit.Text = "退出系统";
            this.btnExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.statusStrip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserInfo,
            this.lblTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 707);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(800, 17);
            this.lblUserInfo.Spring = true;
            this.lblUserInfo.Text = "当前用户：";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(193, 17);
            this.lblTime.Text = "2024-01-01 00:00:00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = global::单位抽考win7软件.Properties.Resources.LOGO;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单位抽考系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuBaseData;
        private System.Windows.Forms.ToolStripMenuItem menuOrgUnit;
        private System.Windows.Forms.ToolStripMenuItem menuPerson;
        private System.Windows.Forms.ToolStripMenuItem menuCommandGroup;
        private System.Windows.Forms.ToolStripMenuItem menuTaskPlan;
        private System.Windows.Forms.ToolStripMenuItem menuExamManage;
        private System.Windows.Forms.ToolStripMenuItem menuExamActivity;
        private System.Windows.Forms.ToolStripMenuItem menuSystemManage;
        private System.Windows.Forms.ToolStripMenuItem menuUser;
        private System.Windows.Forms.ToolStripMenuItem menuMustHitRule;
        private System.Windows.Forms.ToolStripMenuItem menuLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnOrgUnit;
        private System.Windows.Forms.ToolStripButton btnPerson;
        private System.Windows.Forms.ToolStripButton btnCommandGroup;
        private System.Windows.Forms.ToolStripButton btnTaskPlan;
        private System.Windows.Forms.ToolStripButton btnExamActivity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUserInfo;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox picLogo;
    }
}
