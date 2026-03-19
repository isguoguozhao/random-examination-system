namespace 单位抽考win7软件.UI.Forms
{
    partial class ExamResultForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.dgvGroupResult = new System.Windows.Forms.DataGridView();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.dgvTaskResult = new System.Windows.Forms.DataGridView();
            this.tabFinal = new System.Windows.Forms.TabPage();
            this.dgvFinalResult = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExportWord = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupResult)).BeginInit();
            this.tabTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskResult)).BeginInit();
            this.tabFinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalResult)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(88, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "抽考结果";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGroup);
            this.tabControl.Controls.Add(this.tabTask);
            this.tabControl.Controls.Add(this.tabFinal);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.Location = new System.Drawing.Point(0, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 400);
            this.tabControl.TabIndex = 1;
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.dgvGroupResult);
            this.tabGroup.Location = new System.Drawing.Point(4, 29);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(892, 367);
            this.tabGroup.TabIndex = 0;
            this.tabGroup.Text = "指挥组抽取结果";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // dgvGroupResult
            // 
            this.dgvGroupResult.AllowUserToAddRows = false;
            this.dgvGroupResult.AllowUserToDeleteRows = false;
            this.dgvGroupResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroupResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.dgvGroupResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupResult.Location = new System.Drawing.Point(3, 3);
            this.dgvGroupResult.Name = "dgvGroupResult";
            this.dgvGroupResult.ReadOnly = true;
            this.dgvGroupResult.RowTemplate.Height = 25;
            this.dgvGroupResult.Size = new System.Drawing.Size(886, 361);
            this.dgvGroupResult.TabIndex = 0;
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.dgvTaskResult);
            this.tabTask.Location = new System.Drawing.Point(4, 29);
            this.tabTask.Name = "tabTask";
            this.tabTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabTask.Size = new System.Drawing.Size(892, 367);
            this.tabTask.TabIndex = 1;
            this.tabTask.Text = "任务分配结果";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // dgvTaskResult
            // 
            this.dgvTaskResult.AllowUserToAddRows = false;
            this.dgvTaskResult.AllowUserToDeleteRows = false;
            this.dgvTaskResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaskResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.dgvTaskResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaskResult.Location = new System.Drawing.Point(3, 3);
            this.dgvTaskResult.Name = "dgvTaskResult";
            this.dgvTaskResult.ReadOnly = true;
            this.dgvTaskResult.RowTemplate.Height = 25;
            this.dgvTaskResult.Size = new System.Drawing.Size(886, 361);
            this.dgvTaskResult.TabIndex = 0;
            // 
            // tabFinal
            // 
            this.tabFinal.Controls.Add(this.dgvFinalResult);
            this.tabFinal.Location = new System.Drawing.Point(4, 29);
            this.tabFinal.Name = "tabFinal";
            this.tabFinal.Size = new System.Drawing.Size(892, 367);
            this.tabFinal.TabIndex = 2;
            this.tabFinal.Text = "最终结果汇总";
            this.tabFinal.UseVisualStyleBackColor = true;
            // 
            // dgvFinalResult
            // 
            this.dgvFinalResult.AllowUserToAddRows = false;
            this.dgvFinalResult.AllowUserToDeleteRows = false;
            this.dgvFinalResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFinalResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.dgvFinalResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinalResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFinalResult.Location = new System.Drawing.Point(0, 0);
            this.dgvFinalResult.Name = "dgvFinalResult";
            this.dgvFinalResult.ReadOnly = true;
            this.dgvFinalResult.RowTemplate.Height = 25;
            this.dgvFinalResult.Size = new System.Drawing.Size(892, 367);
            this.dgvFinalResult.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Controls.Add(this.btnPrint);
            this.panelBottom.Controls.Add(this.btnExportWord);
            this.panelBottom.Controls.Add(this.btnExportExcel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 450);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(900, 50);
            this.panelBottom.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(780, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(560, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExportWord
            // 
            this.btnExportWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.btnExportWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportWord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportWord.ForeColor = System.Drawing.Color.White;
            this.btnExportWord.Location = new System.Drawing.Point(340, 10);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(90, 30);
            this.btnExportWord.TabIndex = 1;
            this.btnExportWord.Text = "导出Word";
            this.btnExportWord.UseVisualStyleBackColor = false;
            this.btnExportWord.Click += new System.EventHandler(this.btnExportWord_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(120, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(90, 30);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "导出Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // ExamResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = global::单位抽考win7软件.Properties.Resources.LOGO;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ExamResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "抽考结果";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupResult)).EndInit();
            this.tabTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskResult)).EndInit();
            this.tabFinal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalResult)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.DataGridView dgvGroupResult;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.DataGridView dgvTaskResult;
        private System.Windows.Forms.TabPage tabFinal;
        private System.Windows.Forms.DataGridView dgvFinalResult;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportWord;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}
