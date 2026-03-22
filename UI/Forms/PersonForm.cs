using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class PersonForm : Form
    {
        private readonly PersonService _personService;
        private readonly OrgUnitService _orgUnitService;
        private List<Person> _persons;
        private List<OrgUnit> _orgUnits;

        public PersonForm()
        {
            InitializeComponent();
            ModernTechTheme.ApplyTheme(this);
            _personService = new PersonService();
            _orgUnitService = new OrgUnitService();
            LoadOrgUnits();
            LoadPersons();
        }

        private void LoadOrgUnits()
        {
            _orgUnits = _orgUnitService.GetAll();
            cmbOrgUnit.DataSource = null;
            cmbOrgUnit.DisplayMember = "UnitName";
            cmbOrgUnit.ValueMember = "Id";
            cmbOrgUnit.DataSource = _orgUnits;
            cmbOrgUnit.SelectedIndex = -1;
        }

        private void LoadPersons()
        {
            _persons = _personService.GetAll();
            BindGrid();
        }

        private void BindGrid()
        {
            dgvPerson.DataSource = null;
            dgvPerson.AutoGenerateColumns = false;
            dgvPerson.Columns.Clear();
            
            // 手动添加列并设置中文标题
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "编号",
                Width = 60
            });
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                DataPropertyName = "Name",
                HeaderText = "姓名",
                Width = 100
            });
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Gender",
                DataPropertyName = "Gender",
                HeaderText = "性别",
                Width = 60
            });
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitId",
                DataPropertyName = "UnitId",
                HeaderText = "单位编号",
                Width = 80
            });
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PostName",
                DataPropertyName = "PostName",
                HeaderText = "部职别",
                Width = 120
            });
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoleType",
                DataPropertyName = "RoleType",
                HeaderText = "角色类型",
                Width = 100
            });
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Phone",
                DataPropertyName = "Phone",
                HeaderText = "电话",
                Width = 120
            });
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "状态",
                Width = 60
            });
            dgvPerson.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Remark",
                DataPropertyName = "Remark",
                HeaderText = "备注",
                Width = 150
            });
            
            dgvPerson.DataSource = _persons;
        }

        private void cmbOrgUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrgUnit.SelectedValue is int orgUnitId && orgUnitId > 0)
            {
                var filtered = _personService.GetByOrgUnit(orgUnitId);
                dgvPerson.DataSource = null;
                dgvPerson.DataSource = filtered;
            }
            else
            {
                BindGrid();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PersonEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadPersons();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPerson.CurrentRow?.DataBoundItem is Person person)
            {
                using (var form = new PersonEditForm(person))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadPersons();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPerson.CurrentRow?.DataBoundItem is Person person)
            {
                if (MessageBox.Show($"确定要删除人员 \"{person.Name}\" 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_personService.Delete(person.Id))
                    {
                        LogService.AddLog("人员管理", "删除人员", $"删除人员：{person.Name}");
                        LoadPersons();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Excel文件|*.xlsx;*.xls";
                dialog.Title = "选择要导入的Excel文件";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int count = _personService.ImportFromExcel(dialog.FileName);
                        MessageBox.Show($"成功导入 {count} 条人员记录！", "导入成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogService.AddLog("人员管理", "导入人员", $"从Excel导入人员，数量：{count}");
                        LoadPersons();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"导入失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPersons();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                var filtered = _persons.FindAll(p =>
                    p.Name.Contains(keyword) ||
                    (p.Position != null && p.Position.Contains(keyword)) ||
                    (p.Phone != null && p.Phone.Contains(keyword)));
                dgvPerson.DataSource = null;
                dgvPerson.DataSource = filtered;
            }
            else
            {
                BindGrid();
            }
        }
    }
}
