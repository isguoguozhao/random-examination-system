using System;
using System.Collections.Generic;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class MustHitRuleEditForm : Form
    {
        private readonly MustHitRuleService _mustHitRuleService;
        private readonly CommandGroupService _commandGroupService;
        private readonly TaskPlanService _taskPlanService;
        private ExamMustHitRule _rule;
        private bool _isEdit;

        public MustHitRuleEditForm()
        {
            InitializeComponent();
            _mustHitRuleService = new MustHitRuleService();
            _commandGroupService = new CommandGroupService();
            _taskPlanService = new TaskPlanService();
            _rule = new ExamMustHitRule();
            _isEdit = false;
        }

        public MustHitRuleEditForm(ExamMustHitRule rule)
        {
            InitializeComponent();
            _mustHitRuleService = new MustHitRuleService();
            _commandGroupService = new CommandGroupService();
            _taskPlanService = new TaskPlanService();
            _rule = rule;
            _isEdit = true;
        }

        private void MustHitRuleEditForm_Load(object sender, EventArgs e)
        {
            LoadTargetTypes();
            LoadTargetObjects();
            LoadMustHitLevels();

            if (_isEdit)
            {
                this.Text = "编辑必抽规则";
                LoadRuleData();
            }
            else
            {
                this.Text = "新增必抽规则";
                // 默认值
                cmbTargetType.SelectedIndex = 0;
                cmbMustHitLevel.SelectedIndex = 0;
                numFixedPosition.Value = 0;
                dtpStartTime.Checked = false;
                dtpEndTime.Checked = false;
                chkStatus.Checked = true;
            }
        }

        private void LoadTargetTypes()
        {
            cmbTargetType.Items.Clear();
            cmbTargetType.Items.Add("指挥组");
            cmbTargetType.Items.Add("任务");
        }

        private void LoadTargetObjects()
        {
            cmbTargetObject.DataSource = null;
            cmbTargetObject.Items.Clear();

            if (cmbTargetType.SelectedIndex == 0) // 指挥组
            {
                var groups = _commandGroupService.GetAll();
                cmbTargetObject.DisplayMember = "GroupName";
                cmbTargetObject.ValueMember = "Id";
                cmbTargetObject.DataSource = groups;
            }
            else // 任务
            {
                var tasks = _taskPlanService.GetAll();
                cmbTargetObject.DisplayMember = "TaskName";
                cmbTargetObject.ValueMember = "Id";
                cmbTargetObject.DataSource = tasks;
            }
        }

        private void LoadMustHitLevels()
        {
            cmbMustHitLevel.Items.Clear();
            cmbMustHitLevel.Items.Add("绝对必抽");
            cmbMustHitLevel.Items.Add("优先必抽");
        }

        private void LoadRuleData()
        {
            // 设置类型
            cmbTargetType.SelectedIndex = _rule.TargetType == "Group" ? 0 : 1;

            // 重新加载对象列表
            LoadTargetObjects();

            // 设置选中的对象
            for (int i = 0; i < cmbTargetObject.Items.Count; i++)
            {
                cmbTargetObject.SelectedIndex = i;
                if ((int)cmbTargetObject.SelectedValue == _rule.TargetId)
                {
                    break;
                }
            }

            // 设置级别
            cmbMustHitLevel.SelectedIndex = _rule.MustHitLevel - 1;

            // 设置固定位置
            numFixedPosition.Value = _rule.FixedPosition;

            // 设置时间
            if (_rule.StartTime.HasValue)
            {
                dtpStartTime.Value = _rule.StartTime.Value;
                dtpStartTime.Checked = true;
            }
            else
            {
                dtpStartTime.Checked = false;
            }

            if (_rule.EndTime.HasValue)
            {
                dtpEndTime.Value = _rule.EndTime.Value;
                dtpEndTime.Checked = true;
            }
            else
            {
                dtpEndTime.Checked = false;
            }

            // 设置状态
            chkStatus.Checked = _rule.Status == 1;
        }

        private void cmbTargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTargetObjects();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveRule();
            }
        }

        private bool ValidateInput()
        {
            if (cmbTargetObject.SelectedValue == null)
            {
                MessageBox.Show("请选择对象", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbMustHitLevel.SelectedIndex < 0)
            {
                MessageBox.Show("请选择必抽级别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 检查时间范围
            if (dtpStartTime.Checked && dtpEndTime.Checked)
            {
                if (dtpStartTime.Value > dtpEndTime.Value)
                {
                    MessageBox.Show("开始时间不能晚于结束时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void SaveRule()
        {
            try
            {
                _rule.TargetType = cmbTargetType.SelectedIndex == 0 ? "Group" : "Task";
                _rule.TargetId = (int)cmbTargetObject.SelectedValue;
                _rule.MustHitLevel = cmbMustHitLevel.SelectedIndex + 1;
                _rule.FixedPosition = (int)numFixedPosition.Value;
                _rule.StartTime = dtpStartTime.Checked ? dtpStartTime.Value : (DateTime?)null;
                _rule.EndTime = dtpEndTime.Checked ? dtpEndTime.Value : (DateTime?)null;
                _rule.Status = chkStatus.Checked ? 1 : 0;

                bool result;
                if (_isEdit)
                {
                    result = _mustHitRuleService.Update(_rule);
                    if (result)
                    {
                        LogService.AddLog("必抽规则", "编辑", $"编辑必抽规则：类型={_rule.TargetType}, 对象ID={_rule.TargetId}");
                    }
                }
                else
                {
                    int newId = _mustHitRuleService.Add(_rule);
                    result = newId > 0;
                    if (result)
                    {
                        LogService.AddLog("必抽规则", "新增", $"新增必抽规则：类型={_rule.TargetType}, 对象ID={_rule.TargetId}");
                    }
                }

                if (result)
                {
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
