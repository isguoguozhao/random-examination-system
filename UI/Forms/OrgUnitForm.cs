using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class OrgUnitForm : Form
    {
        private readonly OrgUnitService _orgUnitService;
        private List<OrgUnit> _orgUnits;

        public OrgUnitForm()
        {
            InitializeComponent();
            ModernTechTheme.ApplyTheme(this);
            _orgUnitService = new OrgUnitService();
            LoadOrgUnits();
        }

        private void LoadOrgUnits()
        {
            _orgUnits = _orgUnitService.GetAll();
            BuildTree();
            BindGrid();
        }

        private void BuildTree()
        {
            treeOrgUnit.Nodes.Clear();
            var rootNodes = _orgUnits.FindAll(u => u.ParentId == null || u.ParentId == 0);
            foreach (var root in rootNodes)
            {
                var node = new TreeNode(root.UnitName) { Tag = root };
                AddChildNodes(node, root.Id);
                treeOrgUnit.Nodes.Add(node);
            }
            treeOrgUnit.ExpandAll();
        }

        private void AddChildNodes(TreeNode parentNode, int parentId)
        {
            var children = _orgUnits.FindAll(u => u.ParentId == parentId);
            foreach (var child in children)
            {
                var node = new TreeNode(child.UnitName) { Tag = child };
                AddChildNodes(node, child.Id);
                parentNode.Nodes.Add(node);
            }
        }

        private void BindGrid()
        {
            dgvOrgUnit.DataSource = null;
            dgvOrgUnit.AutoGenerateColumns = false;
            dgvOrgUnit.Columns.Clear();
            
            // 手动添加列并设置中文标题
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "编号",
                Width = 60
            });
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitName",
                DataPropertyName = "UnitName",
                HeaderText = "单位名称",
                Width = 150
            });
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitShortName",
                DataPropertyName = "UnitShortName",
                HeaderText = "单位简称",
                Width = 100
            });
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitCode",
                DataPropertyName = "UnitCode",
                HeaderText = "单位编码",
                Width = 100
            });
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ParentId",
                DataPropertyName = "ParentId",
                HeaderText = "上级单位编号",
                Width = 100
            });
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitType",
                DataPropertyName = "UnitType",
                HeaderText = "单位类型",
                Width = 100
            });
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "状态",
                Width = 60
            });
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Remark",
                DataPropertyName = "Remark",
                HeaderText = "备注",
                Width = 150
            });
            dgvOrgUnit.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreateTime",
                DataPropertyName = "CreateTime",
                HeaderText = "创建时间",
                Width = 140
            });
            
            dgvOrgUnit.DataSource = _orgUnits;
        }

        private void treeOrgUnit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is OrgUnit selectedUnit)
            {
                var filtered = _orgUnits.FindAll(u => u.Id == selectedUnit.Id || u.ParentId == selectedUnit.Id);
                dgvOrgUnit.DataSource = null;
                dgvOrgUnit.DataSource = filtered;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int? parentId = null;
            if (treeOrgUnit.SelectedNode?.Tag is OrgUnit selectedUnit)
            {
                parentId = selectedUnit.Id;
            }

            using (var form = new OrgUnitEditForm(null, parentId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadOrgUnits();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrgUnit.CurrentRow?.DataBoundItem is OrgUnit unit)
            {
                using (var form = new OrgUnitEditForm(unit, null))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadOrgUnits();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrgUnit.CurrentRow?.DataBoundItem is OrgUnit unit)
            {
                if (MessageBox.Show($"确定要删除单位 \"{unit.UnitName}\" 吗？", "确认删除", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_orgUnitService.Delete(unit.Id))
                    {
                        LogService.AddLog("单位管理", "删除单位", $"删除单位：{unit.UnitName}");
                        LoadOrgUnits();
                    }
                    else
                    {
                        MessageBox.Show("删除失败，该单位可能已被使用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrgUnits();
        }
    }
}
