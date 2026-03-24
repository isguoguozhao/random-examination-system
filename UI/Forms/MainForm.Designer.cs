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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblSystemTitle = new System.Windows.Forms.Label();
            this.panelUserInfo = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.panelLeftNav = new System.Windows.Forms.Panel();
            this.panelNavContent = new System.Windows.Forms.Panel();
            this.panelNavHeader = new System.Windows.Forms.Panel();
            this.lblNavTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelLeftNav.SuspendLayout();
            this.panelNavHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelTop.Controls.Add(this.lblCurrentTime);
            this.panelTop.Controls.Add(this.panelUserInfo);
            this.panelTop.Controls.Add(this.lblSystemTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 64;
            this.panelTop.Name = "panelTop";
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.AutoSize = true;
            this.lblSystemTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.lblSystemTitle.ForeColor = System.Drawing.Color.White;
            this.lblSystemTitle.Location = new System.Drawing.Point(24, 16);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Text = "单位抽考系统";
            // 
            // panelUserInfo
            // 
            this.panelUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserInfo.Height = 40;
            this.panelUserInfo.Location = new System.Drawing.Point(700, 12);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.Width = 300;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblCurrentUser.Location = new System.Drawing.Point(0, 10);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Text = "当前用户：";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCurrentTime.Location = new System.Drawing.Point(800, 24);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Text = "2024-01-01 00:00:00";
            // 
            // panelLeftNav
            // 
            this.panelLeftNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelLeftNav.Controls.Add(this.panelNavContent);
            this.panelLeftNav.Controls.Add(this.panelNavHeader);
            this.panelLeftNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftNav.Width = 260;
            this.panelLeftNav.Name = "panelLeftNav";
            // 
            // panelNavContent
            // 
            this.panelNavContent.AutoScroll = true;
            this.panelNavContent.BackColor = System.Drawing.Color.Transparent;
            this.panelNavContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNavContent.Name = "panelNavContent";
            // 
            // panelNavHeader
            // 
            this.panelNavHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelNavHeader.Controls.Add(this.lblNavTitle);
            this.panelNavHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNavHeader.Height = 80;
            this.panelNavHeader.Name = "panelNavHeader";
            // 
            // lblNavTitle
            // 
            this.lblNavTitle.AutoSize = true;
            this.lblNavTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.lblNavTitle.ForeColor = System.Drawing.Color.White;
            this.lblNavTitle.Location = new System.Drawing.Point(24, 28);
            this.lblNavTitle.Name = "lblNavTitle";
            this.lblNavTitle.Text = "导航菜单";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelLeftNav);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = global::单位抽考win7软件.Properties.Resources.LOGO;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单位抽考系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeftNav.ResumeLayout(false);
            this.panelNavHeader.ResumeLayout(false);
            this.panelNavHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Panel panelLeftNav;
        private System.Windows.Forms.Panel panelNavContent;
        private System.Windows.Forms.Panel panelNavHeader;
        private System.Windows.Forms.Label lblNavTitle;
    }
}
