using System;
using System.Collections.Generic;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class PersonEditForm : Form
    {
        private readonly PersonService _personService;
        private readonly OrgUnitService _orgUnitService;
        private Person _person;
        private List<OrgUnit> _orgUnits;

        public PersonEditForm(Person person)
        {
            InitializeComponent();
            _personService = new PersonService();
            _orgUnitService = new OrgUnitService();
            _person = person;

            LoadOrgUnits();

            if (_person != null)
            {
                LoadData();
            }
            else
            {
                _person = new Person();
                chkStatus.Checked = true;
            }
        }

        private void LoadOrgUnits()
        {
            _orgUnits = _orgUnitService.GetAll();
            cmbOrgUnit.DataSource = null;
            cmbOrgUnit.DisplayMember = "UnitName";
            cmbOrgUnit.ValueMember = "Id";
            cmbOrgUnit.DataSource = _orgUnits;
        }

        private void LoadData()
        {
            txtName.Text = _person.Name;
            cmbGender.Text = _person.Gender;
            cmbOrgUnit.SelectedValue = _person.UnitId;
            txtPostName.Text = _person.PostName;
            txtPhone.Text = _person.Phone;
            chkStatus.Checked = _person.Status == 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (cmbOrgUnit.SelectedValue == null)
            {
                MessageBox.Show("请选择所属单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOrgUnit.Focus();
                return;
            }

            _person.Name = txtName.Text.Trim();
            _person.Gender = cmbGender.Text;
            _person.UnitId = (int)cmbOrgUnit.SelectedValue;
            _person.PostName = txtPostName.Text.Trim();
            _person.Phone = txtPhone.Text.Trim();
            _person.Status = chkStatus.Checked ? 1 : 0;

            if (_person.Id == 0)
            {
                int newId = _personService.Add(_person);
                if (newId > 0)
                {
                    LogService.AddLog("人员管理", "新增人员", $"新增人员：{_person.Name}");
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
                if (_personService.Update(_person))
                {
                    LogService.AddLog("人员管理", "修改人员", $"修改人员：{_person.Name}");
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
