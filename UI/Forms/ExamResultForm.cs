using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class ExamResultForm : Form
    {
        private readonly ExamService _examService;
        private ExamActivity _activity;
        private List<ExamActivityGroupResult> _groupResults;
        private List<ExamActivityTaskResult> _taskResults;
        private List<ExamActivityFinalResult> _finalResults;

        public ExamResultForm(ExamActivity activity)
        {
            InitializeComponent();
            _examService = new ExamService();
            _activity = activity;
            LoadResults();
        }

        private void LoadResults()
        {
            _groupResults = _examService.GetGroupResults(_activity.Id);
            _taskResults = _examService.GetTaskResults(_activity.Id);
            _finalResults = _examService.GetFinalResults(_activity.Id);

            BindGroupResults();
            BindTaskResults();
            BindFinalResults();
        }

        private void BindGroupResults()
        {
            dgvGroupResult.DataSource = null;
            dgvGroupResult.DataSource = _groupResults;
        }

        private void BindTaskResults()
        {
            dgvTaskResult.DataSource = null;
            dgvTaskResult.DataSource = _taskResults;
        }

        private void BindFinalResults()
        {
            dgvFinalResult.DataSource = null;
            dgvFinalResult.DataSource = _finalResults;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel文件|*.xlsx";
                dialog.FileName = $"抽考结果_{_activity.ActivityName}_{DateTime.Now:yyyyMMdd}";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _examService.ExportResultsToExcel(_activity.Id, dialog.FileName);
                        MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogService.AddLog("抽考结果", "导出Excel", $"导出活动 {_activity.ActivityName} 的结果到Excel");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Word文件|*.docx";
                dialog.FileName = $"抽考结果_{_activity.ActivityName}_{DateTime.Now:yyyyMMdd}";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _examService.ExportResultsToWord(_activity.Id, dialog.FileName);
                        MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogService.AddLog("抽考结果", "导出Word", $"导出活动 {_activity.ActivityName} 的结果到Word");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                _examService.PrintResults(_activity.Id);
                LogService.AddLog("抽考结果", "打印结果", $"打印活动 {_activity.ActivityName} 的结果");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打印失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
