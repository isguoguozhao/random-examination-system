using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class TaskPlanEditForm : Form
    {
        private readonly TaskPlanService _taskPlanService;
        private readonly OrgUnitService _orgUnitService;
        private TaskPlan _taskPlan;
        private List<TaskPlanDetail> _details;
        private List<OrgUnit> _orgUnits;

        public TaskPlanEditForm(TaskPlan taskPlan)
        {
            InitializeComponent();
            _taskPlanService = new TaskPlanService();
            _orgUnitService = new OrgUnitService();
            _taskPlan = taskPlan;
            _details = new List<TaskPlanDetail>();

            if (_taskPlan != null)
            {
                LoadData();
            }
            else
            {
                _taskPlan = new TaskPlan();
            }

            LoadOrgUnits();
        }

        private void LoadData()
        {
            txtPlanName.Text = _taskPlan.PlanName;
            txtDescription.Text = _taskPlan.Description;
            _details = _taskPlanService.GetDetails(_taskPlan.Id);
            BindDetailsGrid();
        }

        private void LoadOrgUnits()
        {
            _orgUnits = _orgUnitService.GetAll();
            cmbOrgUnit.DataSource = null;
            cmbOrgUnit.DisplayMember = "UnitName";
            cmbOrgUnit.ValueMember = "Id";
            cmbOrgUnit.DataSource = _orgUnits;
        }

        private void BindDetailsGrid()
        {
            dgvDetails.DataSource = null;
            dgvDetails.DataSource = _details;
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (cmbOrgUnit.SelectedValue == null)
            {
                MessageBox.Show("请选择单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTask.Text.Trim()))
            {
                MessageBox.Show("请输入担负任务！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detail = new TaskPlanDetail
            {
                OrgUnitId = (int)cmbOrgUnit.SelectedValue,
                OrgUnitName = ((OrgUnit)cmbOrgUnit.SelectedItem).UnitName,
                TaskDescription = txtTask.Text.Trim()
            };

            _details.Add(detail);
            BindDetailsGrid();
            txtTask.Clear();
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetails.CurrentRow?.DataBoundItem is TaskPlanDetail detail)
            {
                _details.Remove(detail);
                BindDetailsGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlanName.Text.Trim()))
            {
                MessageBox.Show("请输入方案名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlanName.Focus();
                return;
            }

            _taskPlan.PlanName = txtPlanName.Text.Trim();
            _taskPlan.Description = txtDescription.Text.Trim();
            _taskPlan.Status = 1;
            _taskPlan.CanDraw = 1;

            bool success = false;

            if (_taskPlan.Id == 0)
            {
                // 新增
                int newId = _taskPlanService.Add(_taskPlan);
                if (newId > 0)
                {
                    _taskPlan.Id = newId;
                    _taskPlanService.SaveDetails(_taskPlan.Id, _details);
                    LogService.AddLog("任务方案管理", "新增任务方案", $"新增任务方案：{_taskPlan.PlanName}");
                    success = true;
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // 修改
                if (_taskPlanService.Update(_taskPlan))
                {
                    _taskPlanService.SaveDetails(_taskPlan.Id, _details);
                    LogService.AddLog("任务方案管理", "修改任务方案", $"修改任务方案：{_taskPlan.PlanName}");
                    success = true;
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
