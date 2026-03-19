using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
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
