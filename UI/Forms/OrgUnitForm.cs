using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
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
