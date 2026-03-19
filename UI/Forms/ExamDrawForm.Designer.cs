namespace 单位抽考win7软件.UI.Forms
{
    partial class ExamDrawForm
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
            this.lblStep = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelResult = new System.Windows.Forms.Panel();
            this.lblResultTask = new System.Windows.Forms.Label();
            this.lblResultGroup = new System.Windows.Forms.Label();
            this.lblResultTitle = new System.Windows.Forms.Label();
            this.lblAnimation = new System.Windows.Forms.Label();
            this.lstCandidates = new System.Windows.Forms.ListBox();
            this.lblCandidate = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.panelTop.Controls.Add(this.lblStep);
            this.panelTop.Controls.Add(this.progressBar);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(700, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStep.Location = new System.Drawing.Point(600, 15);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(70, 22);
            this.lblStep.TabIndex = 2;
            this.lblStep.Text = "第 1/3 步";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(20, 50);
            this.progressBar.Maximum = 3;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(660, 20);
            this.progressBar.TabIndex = 1;
            this.progressBar.Value = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(145, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "第一步：抽取指挥组";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.panelMain.Controls.Add(this.panelResult);
            this.panelMain.Controls.Add(this.lblAnimation);
            this.panelMain.Controls.Add(this.lstCandidates);
            this.panelMain.Controls.Add(this.lblCandidate);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(700, 320);
            this.panelMain.TabIndex = 1;
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.lblResultTask);
            this.panelResult.Controls.Add(this.lblResultGroup);
            this.panelResult.Controls.Add(this.lblResultTitle);
            this.panelResult.Location = new System.Drawing.Point(150, 60);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(400, 200);
            this.panelResult.TabIndex = 3;
            this.panelResult.Visible = false;
            // 
            // lblResultTask
            // 
            this.lblResultTask.AutoSize = true;
            this.lblResultTask.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResultTask.Location = new System.Drawing.Point(20, 120);
            this.lblResultTask.Name = "lblResultTask";
            this.lblResultTask.Size = new System.Drawing.Size(106, 21);
            this.lblResultTask.TabIndex = 2;
            this.lblResultTask.Text = "任务方案：";
            // 
            // lblResultGroup
            // 
            this.lblResultGroup.AutoSize = true;
            this.lblResultGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResultGroup.Location = new System.Drawing.Point(20, 70);
            this.lblResultGroup.Name = "lblResultGroup";
            this.lblResultGroup.Size = new System.Drawing.Size(90, 21);
            this.lblResultGroup.TabIndex = 1;
            this.lblResultGroup.Text = "指挥组：";
            // 
            // lblResultTitle
            // 
            this.lblResultTitle.AutoSize = true;
            this.lblResultTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResultTitle.Location = new System.Drawing.Point(140, 20);
            this.lblResultTitle.Name = "lblResultTitle";
            this.lblResultTitle.Size = new System.Drawing.Size(88, 26);
            this.lblResultTitle.TabIndex = 0;
            this.lblResultTitle.Text = "抽考结果";
            // 
            // lblAnimation
            // 
            this.lblAnimation.AutoSize = true;
            this.lblAnimation.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAnimation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.lblAnimation.Location = new System.Drawing.Point(150, 120);
            this.lblAnimation.Name = "lblAnimation";
            this.lblAnimation.Size = new System.Drawing.Size(0, 64);
            this.lblAnimation.TabIndex = 2;
            this.lblAnimation.Visible = false;
            // 
            // lstCandidates
            // 
            this.lstCandidates.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstCandidates.FormattingEnabled = true;
            this.lstCandidates.ItemHeight = 20;
            this.lstCandidates.Location = new System.Drawing.Point(20, 40);
            this.lstCandidates.Name = "lstCandidates";
            this.lstCandidates.Size = new System.Drawing.Size(660, 264);
            this.lstCandidates.TabIndex = 1;
            // 
            // lblCandidate
            // 
            this.lblCandidate.AutoSize = true;
            this.lblCandidate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCandidate.Location = new System.Drawing.Point(20, 15);
            this.lblCandidate.Name = "lblCandidate";
            this.lblCandidate.Size = new System.Drawing.Size(93, 20);
            this.lblCandidate.TabIndex = 0;
            this.lblCandidate.Text = "候选指挥组：";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnConfirm);
            this.panelBottom.Controls.Add(this.btnDraw);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 400);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(700, 60);
            this.panelBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(480, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(300, 12);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 35);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraw.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDraw.ForeColor = System.Drawing.Color.White;
            this.btnDraw.Location = new System.Drawing.Point(120, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(100, 35);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "开始抽取";
            this.btnDraw.UseVisualStyleBackColor = false;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // ExamDrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(700, 460);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::单位抽考win7软件.Properties.Resources.LOGO;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExamDrawForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "抽考抽取";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblCandidate;
        private System.Windows.Forms.ListBox lstCandidates;
        private System.Windows.Forms.Label lblAnimation;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.Label lblResultGroup;
        private System.Windows.Forms.Label lblResultTask;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}
