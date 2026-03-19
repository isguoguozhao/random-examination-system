using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class CommandGroupEditForm : Form
    {
        private readonly CommandGroupService _commandGroupService;
        private readonly OrgUnitService _orgUnitService;
        private readonly PersonService _personService;
        private CommandGroup _commandGroup;
        private List<CommandGroupMember> _members;
        private List<OrgUnit> _orgUnits;
        private List<Person> _availablePersons;

        public CommandGroupEditForm(CommandGroup commandGroup)
        {
            InitializeComponent();
            _commandGroupService = new CommandGroupService();
            _orgUnitService = new OrgUnitService();
            _personService = new PersonService();
            _commandGroup = commandGroup;
            _members = new List<CommandGroupMember>();

            if (_commandGroup != null)
            {
                LoadData();
            }
            else
            {
                _commandGroup = new CommandGroup();
                chkIsActive.Checked = true;
                chkCanDraw.Checked = true;
            }

            LoadOrgUnits();
            LoadAvailablePersons();
        }

        private void LoadData()
        {
            txtGroupName.Text = _commandGroup.GroupName;
            txtGroupCode.Text = _commandGroup.GroupCode;
            bool isActive = _commandGroup.IsActive;
            chkIsActive.Checked = isActive;
            chkCanDraw.Checked = _commandGroup.CanDraw == 1;
            _members = _commandGroupService.GetMembers(_commandGroup.Id);
            BindMembersGrid();
        }

        private void LoadOrgUnits()
        {
            _orgUnits = _orgUnitService.GetAll();
            cmbOrgUnit.DataSource = null;
            cmbOrgUnit.DisplayMember = "UnitName";
            cmbOrgUnit.ValueMember = "Id";
            cmbOrgUnit.DataSource = _orgUnits;

            if (_commandGroup.OrgUnitId > 0)
            {
                cmbOrgUnit.SelectedValue = _commandGroup.OrgUnitId;
            }
        }

        private void LoadAvailablePersons()
        {
            _availablePersons = _personService.GetAll();
            lstAvailablePersons.DataSource = null;
            lstAvailablePersons.DisplayMember = "Name";
            lstAvailablePersons.ValueMember = "Id";
            lstAvailablePersons.DataSource = _availablePersons;
        }

        private void BindMembersGrid()
        {
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = _members;
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (lstAvailablePersons.SelectedItem is Person person)
            {
                if (_members.Exists(m => m.PersonId == person.Id))
                {
                    MessageBox.Show("该人员已在指挥组中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string role = cmbRole.Text;
                if (string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("请选择角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var member = new CommandGroupMember
                {
                    PersonId = person.Id,
                    PersonName = person.Name,
                    Role = role
                };

                _members.Add(member);
                BindMembersGrid();
            }
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow?.DataBoundItem is CommandGroupMember member)
            {
                _members.Remove(member);
                BindMembersGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGroupName.Text.Trim()))
            {
                MessageBox.Show("请输入指挥组名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGroupName.Focus();
                return;
            }

            if (cmbOrgUnit.SelectedValue == null)
            {
                MessageBox.Show("请选择所属单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOrgUnit.Focus();
                return;
            }

            _commandGroup.GroupName = txtGroupName.Text.Trim();
            _commandGroup.GroupCode = txtGroupCode.Text.Trim();
            _commandGroup.OrgUnitId = (int)cmbOrgUnit.SelectedValue;
            _commandGroup.IsActive = chkIsActive.Checked;
            _commandGroup.CanDraw = chkCanDraw.Checked ? 1 : 0;

            if (_commandGroup.Id == 0)
            {
                _commandGroup.Id = _commandGroupService.Add(_commandGroup);
                if (_commandGroup.Id > 0)
                {
                    _commandGroupService.SaveMembers(_commandGroup.Id, _members);
                    LogService.AddLog("指挥组管理", "新增指挥组", $"新增指挥组：{_commandGroup.GroupName}");
                }
            }
            else
            {
                if (_commandGroupService.Update(_commandGroup))
                {
                    _commandGroupService.SaveMembers(_commandGroup.Id, _members);
                    LogService.AddLog("指挥组管理", "修改指挥组", $"修改指挥组：{_commandGroup.GroupName}");
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
