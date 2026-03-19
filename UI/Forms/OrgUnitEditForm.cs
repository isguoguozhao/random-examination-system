using System;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class OrgUnitEditForm : Form
    {
        private readonly OrgUnitService _orgUnitService;
        private OrgUnit _orgUnit;
        private int? _parentId;

        public OrgUnitEditForm(OrgUnit orgUnit, int? parentId)
        {
            InitializeComponent();
            _orgUnitService = new OrgUnitService();
            _orgUnit = orgUnit;
            _parentId = parentId;

            if (_orgUnit != null)
            {
                txtUnitName.Text = _orgUnit.UnitName;
                txtUnitCode.Text = _orgUnit.UnitCode;
                txtUnitShortName.Text = _orgUnit.UnitShortName;
                txtRemark.Text = _orgUnit.Remark;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                MessageBox.Show("请输入单位名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitName.Focus();
                return;
            }

            if (_orgUnit == null)
            {
                // 新增
                _orgUnit = new OrgUnit
                {
                    UnitName = txtUnitName.Text.Trim(),
                    UnitCode = txtUnitCode.Text.Trim(),
                    UnitShortName = txtUnitShortName.Text.Trim(),
                    ParentId = _parentId ?? 0,
                    Status = 1,
                    Remark = txtRemark.Text.Trim(),
                    CreateTime = DateTime.Now
                };

                int newId = _orgUnitService.Add(_orgUnit);
                if (newId > 0)
                {
                    LogService.AddLog("单位管理", "新增单位", $"新增单位：{_orgUnit.UnitName}");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // 编辑
                _orgUnit.UnitName = txtUnitName.Text.Trim();
                _orgUnit.UnitCode = txtUnitCode.Text.Trim();
                _orgUnit.UnitShortName = txtUnitShortName.Text.Trim();
                _orgUnit.Remark = txtRemark.Text.Trim();

                if (_orgUnitService.Update(_orgUnit))
                {
                    LogService.AddLog("单位管理", "编辑单位", $"编辑单位：{_orgUnit.UnitName}");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
