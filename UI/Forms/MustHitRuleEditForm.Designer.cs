namespace 单位抽考win7软件.UI.Forms
{
    partial class MustHitRuleEditForm
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
            this.lblTargetType = new System.Windows.Forms.Label();
            this.cmbTargetType = new System.Windows.Forms.ComboBox();
            this.lblTargetObject = new System.Windows.Forms.Label();
            this.cmbTargetObject = new System.Windows.Forms.ComboBox();
            this.lblMustHitLevel = new System.Windows.Forms.Label();
            this.cmbMustHitLevel = new System.Windows.Forms.ComboBox();
            this.lblFixedPosition = new System.Windows.Forms.Label();
            this.numFixedPosition = new System.Windows.Forms.NumericUpDown();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFixedPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTargetType
            // 
            this.lblTargetType.AutoSize = true;
            this.lblTargetType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTargetType.Location = new System.Drawing.Point(30, 30);
            this.lblTargetType.Name = "lblTargetType";
            this.lblTargetType.Size = new System.Drawing.Size(68, 17);
            this.lblTargetType.TabIndex = 0;
            this.lblTargetType.Text = "规则类型：";
            // 
            // cmbTargetType
            // 
            this.cmbTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTargetType.FormattingEnabled = true;
            this.cmbTargetType.Location = new System.Drawing.Point(100, 27);
            this.cmbTargetType.Name = "cmbTargetType";
            this.cmbTargetType.Size = new System.Drawing.Size(200, 25);
            this.cmbTargetType.TabIndex = 1;
            this.cmbTargetType.SelectedIndexChanged += new System.EventHandler(this.cmbTargetType_SelectedIndexChanged);
            // 
            // lblTargetObject
            // 
            this.lblTargetObject.AutoSize = true;
            this.lblTargetObject.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTargetObject.Location = new System.Drawing.Point(30, 70);
            this.lblTargetObject.Name = "lblTargetObject";
            this.lblTargetObject.Size = new System.Drawing.Size(68, 17);
            this.lblTargetObject.TabIndex = 2;
            this.lblTargetObject.Text = "选择对象：";
            // 
            // cmbTargetObject
            // 
            this.cmbTargetObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetObject.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTargetObject.FormattingEnabled = true;
            this.cmbTargetObject.Location = new System.Drawing.Point(100, 67);
            this.cmbTargetObject.Name = "cmbTargetObject";
            this.cmbTargetObject.Size = new System.Drawing.Size(200, 25);
            this.cmbTargetObject.TabIndex = 3;
            // 
            // lblMustHitLevel
            // 
            this.lblMustHitLevel.AutoSize = true;
            this.lblMustHitLevel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMustHitLevel.Location = new System.Drawing.Point(30, 110);
            this.lblMustHitLevel.Name = "lblMustHitLevel";
            this.lblMustHitLevel.Size = new System.Drawing.Size(68, 17);
            this.lblMustHitLevel.TabIndex = 4;
            this.lblMustHitLevel.Text = "必抽级别：";
            // 
            // cmbMustHitLevel
            // 
            this.cmbMustHitLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMustHitLevel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMustHitLevel.FormattingEnabled = true;
            this.cmbMustHitLevel.Location = new System.Drawing.Point(100, 107);
            this.cmbMustHitLevel.Name = "cmbMustHitLevel";
            this.cmbMustHitLevel.Size = new System.Drawing.Size(200, 25);
            this.cmbMustHitLevel.TabIndex = 5;
            // 
            // lblFixedPosition
            // 
            this.lblFixedPosition.AutoSize = true;
            this.lblFixedPosition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFixedPosition.Location = new System.Drawing.Point(30, 150);
            this.lblFixedPosition.Name = "lblFixedPosition";
            this.lblFixedPosition.Size = new System.Drawing.Size(68, 17);
            this.lblFixedPosition.TabIndex = 6;
            this.lblFixedPosition.Text = "固定位置：";
            // 
            // numFixedPosition
            // 
            this.numFixedPosition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numFixedPosition.Location = new System.Drawing.Point(100, 148);
            this.numFixedPosition.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numFixedPosition.Name = "numFixedPosition";
            this.numFixedPosition.Size = new System.Drawing.Size(200, 23);
            this.numFixedPosition.TabIndex = 7;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartTime.Location = new System.Drawing.Point(30, 190);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(68, 17);
            this.lblStartTime.TabIndex = 8;
            this.lblStartTime.Text = "开始时间：";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStartTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(100, 186);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowCheckBox = true;
            this.dtpStartTime.Size = new System.Drawing.Size(200, 23);
            this.dtpStartTime.TabIndex = 9;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndTime.Location = new System.Drawing.Point(30, 230);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(68, 17);
            this.lblEndTime.TabIndex = 10;
            this.lblEndTime.Text = "结束时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEndTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(100, 226);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowCheckBox = true;
            this.dtpEndTime.Size = new System.Drawing.Size(200, 23);
            this.dtpEndTime.TabIndex = 11;
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkStatus.Location = new System.Drawing.Point(100, 270);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(51, 21);
            this.chkStatus.TabIndex = 12;
            this.chkStatus.Text = "启用";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(60, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(180, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MustHitRuleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(330, 380);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.numFixedPosition);
            this.Controls.Add(this.lblFixedPosition);
            this.Controls.Add(this.cmbMustHitLevel);
            this.Controls.Add(this.lblMustHitLevel);
            this.Controls.Add(this.cmbTargetObject);
            this.Controls.Add(this.lblTargetObject);
            this.Controls.Add(this.cmbTargetType);
            this.Controls.Add(this.lblTargetType);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::单位抽考win7软件.Properties.Resources.LOGO;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MustHitRuleEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "必抽规则编辑";
            this.Load += new System.EventHandler(this.MustHitRuleEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFixedPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTargetType;
        private System.Windows.Forms.ComboBox cmbTargetType;
        private System.Windows.Forms.Label lblTargetObject;
        private System.Windows.Forms.ComboBox cmbTargetObject;
        private System.Windows.Forms.Label lblMustHitLevel;
        private System.Windows.Forms.ComboBox cmbMustHitLevel;
        private System.Windows.Forms.Label lblFixedPosition;
        private System.Windows.Forms.NumericUpDown numFixedPosition;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
