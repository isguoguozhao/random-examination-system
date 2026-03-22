namespace 单位抽考win7软件.UI.Forms
{
    partial class TaskPlanEditForm
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.lblPlanName = new System.Windows.Forms.Label();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.btnRemoveDetail = new System.Windows.Forms.Button();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.cmbOrgUnit = new System.Windows.Forms.ComboBox();
            this.lblOrgUnit = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.lblDetails = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelBasic.SuspendLayout();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBasic
            // 
            this.panelBasic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.panelBasic.Controls.Add(this.txtDescription);
            this.panelBasic.Controls.Add(this.lblDescription);
            this.panelBasic.Controls.Add(this.txtPlanName);
            this.panelBasic.Controls.Add(this.lblPlanName);
            this.panelBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasic.Location = new System.Drawing.Point(0, 0);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(700, 100);
            this.panelBasic.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDescription.Location = new System.Drawing.Point(100, 45);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(500, 45);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDescription.Location = new System.Drawing.Point(20, 48);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 17);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "方案描述：";
            // 
            // txtPlanName
            // 
            this.txtPlanName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPlanName.Location = new System.Drawing.Point(100, 15);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.Size = new System.Drawing.Size(300, 23);
            this.txtPlanName.TabIndex = 1;
            // 
            // lblPlanName
            // 
            this.lblPlanName.AutoSize = true;
            this.lblPlanName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPlanName.Location = new System.Drawing.Point(20, 18);
            this.lblPlanName.Name = "lblPlanName";
            this.lblPlanName.Size = new System.Drawing.Size(68, 17);
            this.lblPlanName.TabIndex = 0;
            this.lblPlanName.Text = "方案名称：";
            // 
            // panelDetail
            // 
            this.panelDetail.BackColor = System.Drawing.Color.White;
            this.panelDetail.Controls.Add(this.btnRemoveDetail);
            this.panelDetail.Controls.Add(this.btnAddDetail);
            this.panelDetail.Controls.Add(this.cmbOrgUnit);
            this.panelDetail.Controls.Add(this.lblOrgUnit);
            this.panelDetail.Controls.Add(this.dgvDetails);
            this.panelDetail.Controls.Add(this.lblDetails);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetail.Location = new System.Drawing.Point(0, 100);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(700, 300);
            this.panelDetail.TabIndex = 1;
            // 
            // btnRemoveDetail
            // 
            this.btnRemoveDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveDetail.ForeColor = System.Drawing.Color.White;
            this.btnRemoveDetail.Location = new System.Drawing.Point(600, 60);
            this.btnRemoveDetail.Name = "btnRemoveDetail";
            this.btnRemoveDetail.Size = new System.Drawing.Size(80, 40);
            this.btnRemoveDetail.TabIndex = 7;
            this.btnRemoveDetail.Text = "移除";
            this.btnRemoveDetail.UseVisualStyleBackColor = false;
            this.btnRemoveDetail.Click += new System.EventHandler(this.btnRemoveDetail_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnAddDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddDetail.ForeColor = System.Drawing.Color.White;
            this.btnAddDetail.Location = new System.Drawing.Point(600, 15);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(80, 40);
            this.btnAddDetail.TabIndex = 6;
            this.btnAddDetail.Text = "添加";
            this.btnAddDetail.UseVisualStyleBackColor = false;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // cmbOrgUnit
            // 
            this.cmbOrgUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrgUnit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbOrgUnit.FormattingEnabled = true;
            this.cmbOrgUnit.Location = new System.Drawing.Point(100, 30);
            this.cmbOrgUnit.Name = "cmbOrgUnit";
            this.cmbOrgUnit.Size = new System.Drawing.Size(200, 25);
            this.cmbOrgUnit.TabIndex = 3;
            // 
            // lblOrgUnit
            // 
            this.lblOrgUnit.AutoSize = true;
            this.lblOrgUnit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOrgUnit.Location = new System.Drawing.Point(20, 33);
            this.lblOrgUnit.Name = "lblOrgUnit";
            this.lblOrgUnit.Size = new System.Drawing.Size(44, 17);
            this.lblOrgUnit.TabIndex = 2;
            this.lblOrgUnit.Text = "单位：";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(20, 110);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 23;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(660, 180);
            this.dgvDetails.TabIndex = 1;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDetails.Location = new System.Drawing.Point(20, 10);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(80, 17);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "任务明细列表：";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 400);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(700, 50);
            this.panelBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(370, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(240, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TaskPlanEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBasic);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::单位抽考win7软件.Properties.Resources.LOGO;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskPlanEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务方案编辑";
            this.panelBasic.ResumeLayout(false);
            this.panelBasic.PerformLayout();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelBasic;
        private System.Windows.Forms.Label lblPlanName;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.ComboBox cmbOrgUnit;
        private System.Windows.Forms.Label lblOrgUnit;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnRemoveDetail;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
