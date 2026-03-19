namespace 单位抽考win7软件.UI.Forms
{
    partial class CommandGroupEditForm
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
            this.chkCanDraw = new System.Windows.Forms.CheckBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.cmbOrgUnit = new System.Windows.Forms.ComboBox();
            this.lblOrgUnit = new System.Windows.Forms.Label();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.panelMember = new System.Windows.Forms.Panel();
            this.btnRemoveMember = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lstAvailablePersons = new System.Windows.Forms.ListBox();
            this.lblAvailablePersons = new System.Windows.Forms.Label();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.lblMembers = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelBasic.SuspendLayout();
            this.panelMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBasic
            // 
            this.panelBasic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(200)))));
            this.panelBasic.Controls.Add(this.chkCanDraw);
            this.panelBasic.Controls.Add(this.chkIsActive);
            this.panelBasic.Controls.Add(this.cmbOrgUnit);
            this.panelBasic.Controls.Add(this.lblOrgUnit);
            this.panelBasic.Controls.Add(this.txtGroupCode);
            this.panelBasic.Controls.Add(this.lblGroupCode);
            this.panelBasic.Controls.Add(this.txtGroupName);
            this.panelBasic.Controls.Add(this.lblGroupName);
            this.panelBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasic.Location = new System.Drawing.Point(0, 0);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(700, 120);
            this.panelBasic.TabIndex = 0;
            // 
            // chkCanDraw
            // 
            this.chkCanDraw.AutoSize = true;
            this.chkCanDraw.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkCanDraw.Location = new System.Drawing.Point(450, 85);
            this.chkCanDraw.Name = "chkCanDraw";
            this.chkCanDraw.Size = new System.Drawing.Size(75, 21);
            this.chkCanDraw.TabIndex = 7;
            this.chkCanDraw.Text = "可抽取";
            this.chkCanDraw.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkIsActive.Location = new System.Drawing.Point(350, 85);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(75, 21);
            this.chkIsActive.TabIndex = 6;
            this.chkIsActive.Text = "启用";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbOrgUnit
            // 
            this.cmbOrgUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrgUnit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbOrgUnit.FormattingEnabled = true;
            this.cmbOrgUnit.Location = new System.Drawing.Point(100, 83);
            this.cmbOrgUnit.Name = "cmbOrgUnit";
            this.cmbOrgUnit.Size = new System.Drawing.Size(200, 25);
            this.cmbOrgUnit.TabIndex = 5;
            // 
            // lblOrgUnit
            // 
            this.lblOrgUnit.AutoSize = true;
            this.lblOrgUnit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOrgUnit.Location = new System.Drawing.Point(20, 86);
            this.lblOrgUnit.Name = "lblOrgUnit";
            this.lblOrgUnit.Size = new System.Drawing.Size(68, 17);
            this.lblOrgUnit.TabIndex = 4;
            this.lblOrgUnit.Text = "所属单位：";
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGroupCode.Location = new System.Drawing.Point(100, 50);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(200, 23);
            this.txtGroupCode.TabIndex = 3;
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGroupCode.Location = new System.Drawing.Point(20, 53);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(68, 17);
            this.lblGroupCode.TabIndex = 2;
            this.lblGroupCode.Text = "指挥组编号：";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGroupName.Location = new System.Drawing.Point(100, 17);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(200, 23);
            this.txtGroupName.TabIndex = 1;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGroupName.Location = new System.Drawing.Point(20, 20);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(68, 17);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "指挥组名称：";
            // 
            // panelMember
            // 
            this.panelMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.panelMember.Controls.Add(this.btnRemoveMember);
            this.panelMember.Controls.Add(this.btnAddMember);
            this.panelMember.Controls.Add(this.cmbRole);
            this.panelMember.Controls.Add(this.lblRole);
            this.panelMember.Controls.Add(this.lstAvailablePersons);
            this.panelMember.Controls.Add(this.lblAvailablePersons);
            this.panelMember.Controls.Add(this.dgvMembers);
            this.panelMember.Controls.Add(this.lblMembers);
            this.panelMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMember.Location = new System.Drawing.Point(0, 120);
            this.panelMember.Name = "panelMember";
            this.panelMember.Size = new System.Drawing.Size(700, 280);
            this.panelMember.TabIndex = 1;
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnRemoveMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveMember.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemoveMember.ForeColor = System.Drawing.Color.White;
            this.btnRemoveMember.Location = new System.Drawing.Point(320, 180);
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.Size = new System.Drawing.Size(60, 30);
            this.btnRemoveMember.TabIndex = 7;
            this.btnRemoveMember.Text = "<<";
            this.btnRemoveMember.UseVisualStyleBackColor = false;
            this.btnRemoveMember.Click += new System.EventHandler(this.btnRemoveMember_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnAddMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMember.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddMember.ForeColor = System.Drawing.Color.White;
            this.btnAddMember.Location = new System.Drawing.Point(320, 120);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(60, 30);
            this.btnAddMember.TabIndex = 6;
            this.btnAddMember.Text = ">>";
            this.btnAddMember.UseVisualStyleBackColor = false;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "指挥员",
            "副指挥",
            "参谋长",
            "参谋"});
            this.cmbRole.Location = new System.Drawing.Point(320, 80);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(100, 25);
            this.cmbRole.TabIndex = 5;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRole.Location = new System.Drawing.Point(320, 60);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(44, 17);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "角色：";
            // 
            // lstAvailablePersons
            // 
            this.lstAvailablePersons.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstAvailablePersons.FormattingEnabled = true;
            this.lstAvailablePersons.ItemHeight = 17;
            this.lstAvailablePersons.Location = new System.Drawing.Point(400, 40);
            this.lstAvailablePersons.Name = "lstAvailablePersons";
            this.lstAvailablePersons.Size = new System.Drawing.Size(280, 225);
            this.lstAvailablePersons.TabIndex = 3;
            // 
            // lblAvailablePersons
            // 
            this.lblAvailablePersons.AutoSize = true;
            this.lblAvailablePersons.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAvailablePersons.Location = new System.Drawing.Point(400, 20);
            this.lblAvailablePersons.Name = "lblAvailablePersons";
            this.lblAvailablePersons.Size = new System.Drawing.Size(80, 17);
            this.lblAvailablePersons.TabIndex = 2;
            this.lblAvailablePersons.Text = "可选人员列表：";
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(20, 40);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowTemplate.Height = 23;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(280, 225);
            this.dgvMembers.TabIndex = 1;
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMembers.Location = new System.Drawing.Point(20, 20);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(68, 17);
            this.lblMembers.TabIndex = 0;
            this.lblMembers.Text = "成员列表：";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
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
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(370, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(240, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CommandGroupEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.panelMember);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBasic);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::单位抽考win7软件.Properties.Resources.LOGO;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandGroupEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "指挥组编辑";
            this.panelBasic.ResumeLayout(false);
            this.panelBasic.PerformLayout();
            this.panelMember.ResumeLayout(false);
            this.panelMember.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelBasic;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.Label lblGroupCode;
        private System.Windows.Forms.ComboBox cmbOrgUnit;
        private System.Windows.Forms.Label lblOrgUnit;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.CheckBox chkCanDraw;
        private System.Windows.Forms.Panel panelMember;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Label lblAvailablePersons;
        private System.Windows.Forms.ListBox lstAvailablePersons;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnRemoveMember;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
