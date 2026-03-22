using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class TaskPlanForm : Form
    {
        private readonly TaskPlanService _taskPlanService;
        private List<TaskPlan> _taskPlans;

        public TaskPlanForm()
        {
            InitializeComponent();
            ModernTechTheme.ApplyTheme(this);
            _taskPlanService = new TaskPlanService();
            LoadTaskPlans();
        }

        private void LoadTaskPlans()
        {
            _taskPlans = _taskPlanService.GetAll();
            BindGrid();
        }

        private void BindGrid()
        {
            dgvTaskPlan.DataSource = null;
            dgvTaskPlan.AutoGenerateColumns = false;
            dgvTaskPlan.Columns.Clear();
            
            // 手动添加列并设置中文标题
            dgvTaskPlan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "编号",
                Width = 60
            });
            dgvTaskPlan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TaskName",
                DataPropertyName = "TaskName",
                HeaderText = "任务名称",
                Width = 150
            });
            dgvTaskPlan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ExamContent",
                DataPropertyName = "ExamContent",
                HeaderText = "考核内容",
                Width = 200
            });
            dgvTaskPlan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TaskType",
                DataPropertyName = "TaskType",
                HeaderText = "任务类型",
                Width = 100
            });
            dgvTaskPlan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DifficultyLevel",
                DataPropertyName = "DifficultyLevel",
                HeaderText = "难度等级",
                Width = 100
            });
            dgvTaskPlan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "状态",
                Width = 60
            });
            dgvTaskPlan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CanDraw",
                DataPropertyName = "CanDraw",
                HeaderText = "是否可抽",
                Width = 80
            });
            dgvTaskPlan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Remark",
                DataPropertyName = "Remark",
                HeaderText = "备注",
                Width = 150
            });
            
            dgvTaskPlan.DataSource = _taskPlans;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new TaskPlanEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTaskPlans();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTaskPlan.CurrentRow?.DataBoundItem is TaskPlan taskPlan)
            {
                using (var form = new TaskPlanEditForm(taskPlan))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadTaskPlans();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的任务方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTaskPlan.CurrentRow?.DataBoundItem is TaskPlan taskPlan)
            {
                if (MessageBox.Show($"确定要删除任务方案 \"{taskPlan.PlanName}\" 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_taskPlanService.Delete(taskPlan.Id))
                    {
                        LogService.AddLog("任务方案管理", "删除任务方案", $"删除任务方案：{taskPlan.PlanName}");
                        LoadTaskPlans();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的任务方案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTaskPlans();
        }
    }
}
