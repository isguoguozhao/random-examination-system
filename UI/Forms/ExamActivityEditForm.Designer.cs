namespace 单位抽考win7软件.UI.Forms
{
    partial class ExamActivityEditForm
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
            this.panelBasic = new System.Windows.Forms.Panel();
            this.numDrawCount = new System.Windows.Forms.NumericUpDown();
            this.lblDrawCount = new System.Windows.Forms.Label();
            this.dtpExamDate = new System.Windows.Forms.DateTimePicker();
            this.lblExamDate = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblBatch = new System.Windows.Forms.Label();
            this.txtActivityName = new System.Windows.Forms.TextBox();
            this.lblActivityName = new System.Windows.Forms.Label();
            this.panelAdvanced = new System.Windows.Forms.Panel();
            this.numAvoidDays = new System.Windows.Forms.NumericUpDown();
            this.lblAvoidDays = new System.Windows.Forms.Label();
            this.chkEnableAvoidRecent = new System.Windows.Forms.CheckBox();
            this.chkEnableMustHit = new System.Windows.Forms.CheckBox();
            this.lblAdvanced = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndStart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDrawCount)).BeginInit();
            this.panelAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAvoidDays)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBasic
            // 
            this.panelBasic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(200)))));
            this.panelBasic.Controls.Add(this.numDrawCount);
            this.panelBasic.Controls.Add(this.lblDrawCount);
            this.panelBasic.Controls.Add(this.dtpExamDate);
            this.panelBasic.Controls.Add(this.lblExamDate);
            this.panelBasic.Controls.Add(this.txtBatch);
            this.panelBasic.Controls.Add(this.lblBatch);
            this.panelBasic.Controls.Add(this.txtActivityName);
            this.panelBasic.Controls.Add(this.lblActivityName);
            this.panelBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasic.Location = new System.Drawing.Point(0, 0);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(500, 150);
            this.panelBasic.TabIndex = 0;
            // 
            // numDrawCount
            // 
            this.numDrawCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numDrawCount.Location = new System.Drawing.Point(100, 110);
            this.numDrawCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDrawCount.Name = "numDrawCount";
            this.numDrawCount.Size = new System.Drawing.Size(80, 23);
            this.numDrawCount.TabIndex = 7;
            this.numDrawCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDrawCount
            // 
            this.lblDrawCount.AutoSize = true;
            this.lblDrawCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDrawCount.Location = new System.Drawing.Point(20, 113);
            this.lblDrawCount.Name = "lblDrawCount";
            this.lblDrawCount.Size = new System.Drawing.Size(68, 17);
            this.lblDrawCount.TabIndex = 6;
            this.lblDrawCount.Text = "抽取数量：";
            // 
            // dtpExamDate
            // 
            this.dtpExamDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpExamDate.Location = new System.Drawing.Point(100, 77);
            this.dtpExamDate.Name = "dtpExamDate";
            this.dtpExamDate.Size = new System.Drawing.Size(200, 23);
            this.dtpExamDate.TabIndex = 5;
            // 
            // lblExamDate
            // 
            this.lblExamDate.AutoSize = true;
            this.lblExamDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamDate.Location = new System.Drawing.Point(20, 80);
            this.lblExamDate.Name = "lblExamDate";
            this.lblExamDate.Size = new System.Drawing.Size(68, 17);
            this.lblExamDate.TabIndex = 4;
            this.lblExamDate.Text = "抽考日期：";
            // 
            // txtBatch
            // 
            this.txtBatch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBatch.Location = new System.Drawing.Point(100, 45);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(200, 23);
            this.txtBatch.TabIndex = 3;
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBatch.Location = new System.Drawing.Point(20, 48);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(44, 17);
            this.lblBatch.TabIndex = 2;
            this.lblBatch.Text = "批次：";
            // 
            // txtActivityName
            // 
            this.txtActivityName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtActivityName.Location = new System.Drawing.Point(100, 15);
            this.txtActivityName.Name = "txtActivityName";
            this.txtActivityName.Size = new System.Drawing.Size(300, 23);
            this.txtActivityName.TabIndex = 1;
            // 
            // lblActivityName
            // 
            this.lblActivityName.AutoSize = true;
            this.lblActivityName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblActivityName.Location = new System.Drawing.Point(20, 18);
            this.lblActivityName.Name = "lblActivityName";
            this.lblActivityName.Size = new System.Drawing.Size(68, 17);
            this.lblActivityName.TabIndex = 0;
            this.lblActivityName.Text = "活动名称：";
            // 
            // panelAdvanced
            // 
            this.panelAdvanced.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.panelAdvanced.Controls.Add(this.numAvoidDays);
            this.panelAdvanced.Controls.Add(this.lblAvoidDays);
            this.panelAdvanced.Controls.Add(this.chkEnableAvoidRecent);
            this.panelAdvanced.Controls.Add(this.chkEnableMustHit);
            this.panelAdvanced.Controls.Add(this.lblAdvanced);
            this.panelAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdvanced.Location = new System.Drawing.Point(0, 150);
            this.panelAdvanced.Name = "panelAdvanced";
            this.panelAdvanced.Size = new System.Drawing.Size(500, 120);
            this.panelAdvanced.TabIndex = 1;
            // 
            // numAvoidDays
            // 
            this.numAvoidDays.Enabled = false;
            this.numAvoidDays.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numAvoidDays.Location = new System.Drawing.Point(280, 70);
            this.numAvoidDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numAvoidDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAvoidDays.Name = "numAvoidDays";
            this.numAvoidDays.Size = new System.Drawing.Size(80, 23);
            this.numAvoidDays.TabIndex = 4;
            this.numAvoidDays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblAvoidDays
            // 
            this.lblAvoidDays.AutoSize = true;
            this.lblAvoidDays.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAvoidDays.Location = new System.Drawing.Point(200, 73);
            this.lblAvoidDays.Name = "lblAvoidDays";
            this.lblAvoidDays.Size = new System.Drawing.Size(80, 17);
            this.lblAvoidDays.TabIndex = 3;
            this.lblAvoidDays.Text = "避免天数：";
            // 
            // chkEnableAvoidRecent
            // 
            this.chkEnableAvoidRecent.AutoSize = true;
            this.chkEnableAvoidRecent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEnableAvoidRecent.Location = new System.Drawing.Point(20, 72);
            this.chkEnableAvoidRecent.Name = "chkEnableAvoidRecent";
            this.chkEnableAvoidRecent.Size = new System.Drawing.Size(147, 21);
            this.chkEnableAvoidRecent.TabIndex = 2;
            this.chkEnableAvoidRecent.Text = "避免近期已抽中单位";
            this.chkEnableAvoidRecent.UseVisualStyleBackColor = true;
            this.chkEnableAvoidRecent.CheckedChanged += new System.EventHandler(this.chkEnableAvoidRecent_CheckedChanged);
            // 
            // chkEnableMustHit
            // 
            this.chkEnableMustHit.AutoSize = true;
            this.chkEnableMustHit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkEnableMustHit.Location = new System.Drawing.Point(20, 40);
            this.chkEnableMustHit.Name = "chkEnableMustHit";
            this.chkEnableMustHit.Size = new System.Drawing.Size(99, 21);
            this.chkEnableMustHit.TabIndex = 1;
            this.chkEnableMustHit.Text = "启用必抽规则";
            this.chkEnableMustHit.UseVisualStyleBackColor = true;
            // 
            // lblAdvanced
            // 
            this.lblAdvanced.AutoSize = true;
            this.lblAdvanced.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAdvanced.Location = new System.Drawing.Point(20, 15);
            this.lblAdvanced.Name = "lblAdvanced";
            this.lblAdvanced.Size = new System.Drawing.Size(68, 17);
            this.lblAdvanced.TabIndex = 0;
            this.lblAdvanced.Text = "高级设置：";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnSaveAndStart);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 270);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(500, 50);
            this.panelBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(360, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAndStart
            // 
            this.btnSaveAndStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnSaveAndStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveAndStart.ForeColor = System.Drawing.Color.White;
            this.btnSaveAndStart.Location = new System.Drawing.Point(200, 10);
            this.btnSaveAndStart.Name = "btnSaveAndStart";
            this.btnSaveAndStart.Size = new System.Drawing.Size(120, 30);
            this.btnSaveAndStart.TabIndex = 1;
            this.btnSaveAndStart.Text = "保存并开始抽考";
            this.btnSaveAndStart.UseVisualStyleBackColor = false;
            this.btnSaveAndStart.Click += new System.EventHandler(this.btnSaveAndStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(60, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ExamActivityEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(500, 320);
            this.Controls.Add(this.panelAdvanced);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBasic);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::单位抽考win7软件.Properties.Resources.LOGO;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExamActivityEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "抽考活动创建";
            this.panelBasic.ResumeLayout(false);
            this.panelBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDrawCount)).EndInit();
            this.panelAdvanced.ResumeLayout(false);
            this.panelAdvanced.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAvoidDays)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelBasic;
        private System.Windows.Forms.Label lblActivityName;
        private System.Windows.Forms.TextBox txtActivityName;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private System.Windows.Forms.Label lblExamDate;
        private System.Windows.Forms.NumericUpDown numDrawCount;
        private System.Windows.Forms.Label lblDrawCount;
        private System.Windows.Forms.Panel panelAdvanced;
        private System.Windows.Forms.Label lblAdvanced;
        private System.Windows.Forms.CheckBox chkEnableMustHit;
        private System.Windows.Forms.CheckBox chkEnableAvoidRecent;
        private System.Windows.Forms.NumericUpDown numAvoidDays;
        private System.Windows.Forms.Label lblAvoidDays;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveAndStart;
        private System.Windows.Forms.Button btnCancel;
    }
}
