using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class CommandGroupForm : Form
    {
        private readonly CommandGroupService _commandGroupService;
        private readonly OrgUnitService _orgUnitService;
        private List<CommandGroup> _commandGroups;
        private List<OrgUnit> _orgUnits;

        public CommandGroupForm()
        {
            InitializeComponent();
            _commandGroupService = new CommandGroupService();
            _orgUnitService = new OrgUnitService();
            LoadOrgUnits();
            LoadCommandGroups();
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

        private void LoadCommandGroups()
        {
            _commandGroups = _commandGroupService.GetAll();
            BindGrid();
        }

        private void BindGrid()
        {
            dgvCommandGroup.DataSource = null;
            dgvCommandGroup.AutoGenerateColumns = false;
            dgvCommandGroup.Columns.Clear();
            
            // 手动添加列并设置中文标题
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "编号",
                Width = 60
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GroupName",
                DataPropertyName = "GroupName",
                HeaderText = "指挥组名称",
                Width = 150
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GroupCode",
                DataPropertyName = "GroupCode",
                HeaderText = "指挥组代码",
                Width = 100
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitId",
                DataPropertyName = "UnitId",
                HeaderText = "单位编号",
                Width = 80
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GroupNo",
                DataPropertyName = "GroupNo",
                HeaderText = "指挥组编号",
                Width = 100
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "状态",
                Width = 60
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IsActive",
                DataPropertyName = "IsActive",
                HeaderText = "是否启用",
                Width = 80
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CanDraw",
                DataPropertyName = "CanDraw",
                HeaderText = "是否可抽",
                Width = 80
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Remark",
                DataPropertyName = "Remark",
                HeaderText = "备注",
                Width = 150
            });
            dgvCommandGroup.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreateTime",
                DataPropertyName = "CreateTime",
                HeaderText = "创建时间",
                Width = 140
            });
            
            dgvCommandGroup.DataSource = _commandGroups;
        }

        private void cmbOrgUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrgUnit.SelectedValue is int orgUnitId && orgUnitId > 0)
            {
                var filtered = _commandGroupService.GetByOrgUnit(orgUnitId);
                dgvCommandGroup.DataSource = null;
                dgvCommandGroup.DataSource = filtered;
            }
            else
            {
                BindGrid();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new CommandGroupEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCommandGroups();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCommandGroup.CurrentRow?.DataBoundItem is CommandGroup group)
            {
                using (var form = new CommandGroupEditForm(group))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadCommandGroups();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的指挥组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCommandGroup.CurrentRow?.DataBoundItem is CommandGroup group)
            {
                if (MessageBox.Show($"确定要删除指挥组 \"{group.GroupName}\" 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_commandGroupService.Delete(group.Id))
                    {
                        LogService.AddLog("指挥组管理", "删除指挥组", $"删除指挥组：{group.GroupName}");
                        LoadCommandGroups();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的指挥组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dgvCommandGroup.CurrentRow?.DataBoundItem is CommandGroup group)
            {
                if (MessageBox.Show($"确定要复制指挥组 \"{group.GroupName}\" 吗？", "确认复制",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int newId = _commandGroupService.Copy(group.Id);
                    if (newId > 0)
                    {
                        LogService.AddLog("指挥组管理", "复制指挥组", $"复制指挥组：{group.GroupName}");
                        LoadCommandGroups();
                    }
                    else
                    {
                        MessageBox.Show("复制失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要复制的指挥组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            if (dgvCommandGroup.CurrentRow?.DataBoundItem is CommandGroup group)
            {
                using (var form = new CommandGroupEditForm(group))
                {
                    form.ShowDialog(this);
                    LoadCommandGroups();
                }
            }
            else
            {
                MessageBox.Show("请选择要管理成员的指挥组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        int count = _commandGroupService.ImportFromExcel(dialog.FileName);
                        MessageBox.Show($"成功导入 {count} 条指挥组记录！", "导入成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogService.AddLog("指挥组管理", "导入指挥组", $"从Excel导入指挥组，数量：{count}");
                        LoadCommandGroups();
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
            LoadCommandGroups();
        }
    }
}
