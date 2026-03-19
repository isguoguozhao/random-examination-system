using System;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class ExamActivityEditForm : Form
    {
        private readonly ExamService _examService;
        private ExamActivity _activity;

        public ExamActivityEditForm(ExamActivity activity)
        {
            InitializeComponent();
            _examService = new ExamService();
            _activity = activity;

            if (_activity != null)
            {
                LoadData();
            }
            else
            {
                _activity = new ExamActivity();
                dtpExamDate.Value = DateTime.Now;
            }
        }

        private void LoadData()
        {
            txtActivityName.Text = _activity.ActivityName;
            txtBatch.Text = _activity.Batch;
            dtpExamDate.Value = _activity.ExamDate;
            numDrawCount.Value = _activity.DrawCount;
            chkEnableMustHit.Checked = _activity.EnableMustHit;
            chkEnableAvoidRecent.Checked = _activity.EnableAvoidRecent;
            numAvoidDays.Value = _activity.AvoidDays;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtActivityName.Text.Trim()))
            {
                MessageBox.Show("请输入活动名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActivityName.Focus();
                return;
            }

            _activity.ActivityName = txtActivityName.Text.Trim();
            _activity.Batch = txtBatch.Text.Trim();
            _activity.ExamDate = dtpExamDate.Value;
            _activity.DrawCount = (int)numDrawCount.Value;
            _activity.EnableMustHit = chkEnableMustHit.Checked;
            _activity.EnableAvoidRecent = chkEnableAvoidRecent.Checked;
            _activity.AvoidDays = (int)numAvoidDays.Value;

            if (_activity.Id == 0)
            {
                _activity.Id = _examService.AddActivity(_activity);
                if (_activity.Id > 0)
                {
                    LogService.AddLog("抽考活动", "新增活动", $"新增活动：{_activity.ActivityName}");
                }
            }
            else
            {
                if (_examService.UpdateActivity(_activity))
                {
                    LogService.AddLog("抽考活动", "修改活动", $"修改活动：{_activity.ActivityName}");
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSaveAndStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtActivityName.Text.Trim()))
            {
                MessageBox.Show("请输入活动名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtActivityName.Focus();
                return;
            }

            _activity.ActivityName = txtActivityName.Text.Trim();
            _activity.Batch = txtBatch.Text.Trim();
            _activity.ExamDate = dtpExamDate.Value;
            _activity.DrawCount = (int)numDrawCount.Value;
            _activity.EnableMustHit = chkEnableMustHit.Checked;
            _activity.EnableAvoidRecent = chkEnableAvoidRecent.Checked;
            _activity.AvoidDays = (int)numAvoidDays.Value;

            if (_activity.Id == 0)
            {
                _activity.Id = _examService.AddActivity(_activity);
                if (_activity.Id > 0)
                {
                    LogService.AddLog("抽考活动", "新增活动", $"新增活动：{_activity.ActivityName}");
                }
            }
            else
            {
                if (_examService.UpdateActivity(_activity))
                {
                    LogService.AddLog("抽考活动", "修改活动", $"修改活动：{_activity.ActivityName}");
                }
            }

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkEnableAvoidRecent_CheckedChanged(object sender, EventArgs e)
        {
            numAvoidDays.Enabled = chkEnableAvoidRecent.Checked;
        }
    }
}
