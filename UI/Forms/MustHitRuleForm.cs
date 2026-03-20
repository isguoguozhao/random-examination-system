using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class MustHitRuleForm : Form
    {
        private readonly MustHitRuleService _mustHitRuleService;
        private readonly CommandGroupService _commandGroupService;
        private readonly TaskPlanService _taskPlanService;
        private List<ExamMustHitRule> _rules;

        public MustHitRuleForm()
        {
            InitializeComponent();
            _mustHitRuleService = new MustHitRuleService();
            _commandGroupService = new CommandGroupService();
            _taskPlanService = new TaskPlanService();
            _rules = new List<ExamMustHitRule>();
        }

        private void MustHitRuleForm_Load(object sender, EventArgs e)
        {
            LoadRules();
            InitializeFilters();
        }

        private void InitializeFilters()
        {
            // 类型筛选
            cmbType.Items.Add("全部");
            cmbType.Items.Add("指挥组");
            cmbType.Items.Add("任务");
            cmbType.SelectedIndex = 0;

            // 级别筛选
            cmbLevel.Items.Add("全部");
            cmbLevel.Items.Add("绝对必抽");
            cmbLevel.Items.Add("优先必抽");
            cmbLevel.SelectedIndex = 0;
        }

        private void LoadRules()
        {
            try
            {
                _rules = _mustHitRuleService.GetAllRules();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载规则失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            var filteredRules = _rules;

            // 应用类型筛选
            if (cmbType.SelectedIndex > 0)
            {
                string type = cmbType.SelectedIndex == 1 ? "Group" : "Task";
                filteredRules = filteredRules.Where(r => r.TargetType == type).ToList();
            }

            // 应用级别筛选
            if (cmbLevel.SelectedIndex > 0)
            {
                int level = cmbLevel.SelectedIndex;
                filteredRules = filteredRules.Where(r => r.MustHitLevel == level).ToList();
            }

            dgvRules.DataSource = null;
            dgvRules.DataSource = filteredRules.Select(r => new
            {
                r.Id,
                类型 = r.TargetType == "Group" ? "指挥组" : "任务",
                对象名称 = GetTargetName(r),
                必抽级别 = r.MustHitLevel == 1 ? "绝对必抽" : "优先必抽",
                固定位置 = r.FixedPosition,
                开始时间 = r.StartTime?.ToString("yyyy-MM-dd HH:mm") ?? "无限制",
                结束时间 = r.EndTime?.ToString("yyyy-MM-dd HH:mm") ?? "无限制",
                状态 = r.Status == 1 ? "启用" : "停用"
            }).ToList();

            // 隐藏Id列
            if (dgvRules.Columns["Id"] != null)
                dgvRules.Columns["Id"].Visible = false;
        }

        private string GetTargetName(ExamMustHitRule rule)
        {
            try
            {
                if (rule.TargetType == "Group")
                {
                    var group = _commandGroupService.GetById(rule.TargetId);
                    return group?.GroupName ?? $"指挥组({rule.TargetId})";
                }
                else
                {
                    var task = _taskPlanService.GetById(rule.TargetId);
                    return task?.TaskName ?? $"任务({rule.TargetId})";
                }
            }
            catch
            {
                return $"未知({rule.TargetId})";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new MustHitRuleEditForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRules();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRules.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要编辑的规则", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = (int)dgvRules.SelectedRows[0].Cells["Id"].Value;
            var rule = _rules.FirstOrDefault(r => r.Id == id);
            if (rule == null)
            {
                MessageBox.Show("未找到选中的规则", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var form = new MustHitRuleEditForm(rule))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRules();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRules.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的规则", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = (int)dgvRules.SelectedRows[0].Cells["Id"].Value;
            var rule = _rules.FirstOrDefault(r => r.Id == id);
            if (rule == null) return;

            if (MessageBox.Show($"确定要删除这条必抽规则吗？\n类型：{(rule.TargetType == "Group" ? "指挥组" : "任务")}\n对象：{GetTargetName(rule)}", 
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_mustHitRuleService.Delete(id))
                    {
                        LogService.AddLog("必抽规则", "删除", $"删除必抽规则：类型={rule.TargetType}, 对象ID={rule.TargetId}");
                        LoadRules();
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRules();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dgvRules_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
