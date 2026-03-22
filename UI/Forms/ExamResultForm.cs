using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common;
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
            ModernTechTheme.ApplyTheme(this);
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
            dgvGroupResult.AutoGenerateColumns = false;
            dgvGroupResult.Columns.Clear();
            
            // 手动添加列并设置中文标题
            dgvGroupResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "编号",
                Width = 60
            });
            dgvGroupResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ActivityId",
                DataPropertyName = "ActivityId",
                HeaderText = "活动编号",
                Width = 80
            });
            dgvGroupResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CommandGroupId",
                DataPropertyName = "CommandGroupId",
                HeaderText = "指挥组编号",
                Width = 100
            });
            dgvGroupResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GroupName",
                DataPropertyName = "GroupName",
                HeaderText = "指挥组名称",
                Width = 150
            });
            dgvGroupResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IsHit",
                DataPropertyName = "IsHit",
                HeaderText = "是否抽中",
                Width = 80
            });
            dgvGroupResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HitOrder",
                DataPropertyName = "HitOrder",
                HeaderText = "抽中顺序",
                Width = 80
            });
            dgvGroupResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreateTime",
                DataPropertyName = "CreateTime",
                HeaderText = "创建时间",
                Width = 140
            });
            
            dgvGroupResult.DataSource = _groupResults;
        }

        private void BindTaskResults()
        {
            dgvTaskResult.DataSource = null;
            dgvTaskResult.AutoGenerateColumns = false;
            dgvTaskResult.Columns.Clear();
            
            // 手动添加列并设置中文标题
            dgvTaskResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "编号",
                Width = 60
            });
            dgvTaskResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ActivityId",
                DataPropertyName = "ActivityId",
                HeaderText = "活动编号",
                Width = 80
            });
            dgvTaskResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TaskPlanId",
                DataPropertyName = "TaskPlanId",
                HeaderText = "任务方案编号",
                Width = 100
            });
            dgvTaskResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TaskName",
                DataPropertyName = "TaskName",
                HeaderText = "任务名称",
                Width = 150
            });
            dgvTaskResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IsHit",
                DataPropertyName = "IsHit",
                HeaderText = "是否抽中",
                Width = 80
            });
            dgvTaskResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HitOrder",
                DataPropertyName = "HitOrder",
                HeaderText = "抽中顺序",
                Width = 80
            });
            dgvTaskResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreateTime",
                DataPropertyName = "CreateTime",
                HeaderText = "创建时间",
                Width = 140
            });
            
            dgvTaskResult.DataSource = _taskResults;
        }

        private void BindFinalResults()
        {
            dgvFinalResult.DataSource = null;
            dgvFinalResult.AutoGenerateColumns = false;
            dgvFinalResult.Columns.Clear();
            
            // 手动添加列并设置中文标题
            dgvFinalResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "编号",
                Width = 60
            });
            dgvFinalResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ActivityId",
                DataPropertyName = "ActivityId",
                HeaderText = "活动编号",
                Width = 80
            });
            dgvFinalResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Content1TaskName",
                DataPropertyName = "Content1TaskName",
                HeaderText = "考核内容1任务",
                Width = 150
            });
            dgvFinalResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Content1CommanderName",
                DataPropertyName = "Content1CommanderName",
                HeaderText = "考核内容1指挥员",
                Width = 150
            });
            dgvFinalResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Content2TaskName",
                DataPropertyName = "Content2TaskName",
                HeaderText = "考核内容2任务",
                Width = 150
            });
            dgvFinalResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Content2CommanderName",
                DataPropertyName = "Content2CommanderName",
                HeaderText = "考核内容2指挥员",
                Width = 150
            });
            dgvFinalResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DrawTime",
                DataPropertyName = "DrawTime",
                HeaderText = "抽考时间",
                Width = 140
            });
            dgvFinalResult.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreateTime",
                DataPropertyName = "CreateTime",
                HeaderText = "创建时间",
                Width = 140
            });
            
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
