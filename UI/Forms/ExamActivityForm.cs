using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class ExamActivityForm : Form
    {
        private readonly ExamService _examService;
        private List<ExamActivity> _activities;

        public ExamActivityForm()
        {
            InitializeComponent();
            ModernTechTheme.ApplyTheme(this);
            _examService = new ExamService();
            LoadActivities();
        }

        private void LoadActivities()
        {
            _activities = _examService.GetAllActivities();
            BindGrid();
        }

        private void BindGrid()
        {
            dgvActivity.DataSource = null;
            dgvActivity.AutoGenerateColumns = false;
            dgvActivity.Columns.Clear();
            
            // 手动添加列并设置中文标题
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "编号",
                Width = 60
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ActivityName",
                DataPropertyName = "ActivityName",
                HeaderText = "活动名称",
                Width = 150
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BatchNo",
                DataPropertyName = "BatchNo",
                HeaderText = "批次号",
                Width = 100
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Batch",
                DataPropertyName = "Batch",
                HeaderText = "批次",
                Width = 100
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ExamDate",
                DataPropertyName = "ExamDate",
                HeaderText = "抽考日期",
                Width = 120
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DrawGroupCount",
                DataPropertyName = "DrawGroupCount",
                HeaderText = "抽指挥组数量",
                Width = 120
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DrawTaskCount",
                DataPropertyName = "DrawTaskCount",
                HeaderText = "抽任务数量",
                Width = 100
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DrawCount",
                DataPropertyName = "DrawCount",
                HeaderText = "抽选数量",
                Width = 100
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AllowRepeat",
                DataPropertyName = "AllowRepeat",
                HeaderText = "允许重复",
                Width = 80
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EnableMustHit",
                DataPropertyName = "EnableMustHit",
                HeaderText = "启用必抽",
                Width = 80
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EnableAvoidRecent",
                DataPropertyName = "EnableAvoidRecent",
                HeaderText = "启用近期回避",
                Width = 100
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AvoidDays",
                DataPropertyName = "AvoidDays",
                HeaderText = "回避天数",
                Width = 80
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "状态",
                Width = 60
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedBy",
                DataPropertyName = "CreatedBy",
                HeaderText = "创建人",
                Width = 100
            });
            dgvActivity.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedTime",
                DataPropertyName = "CreatedTime",
                HeaderText = "创建时间",
                Width = 140
            });
            
            dgvActivity.DataSource = _activities;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ExamActivityEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadActivities();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvActivity.CurrentRow?.DataBoundItem is ExamActivity activity)
            {
                using (var form = new ExamActivityEditForm(activity))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadActivities();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要编辑的活动！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvActivity.CurrentRow?.DataBoundItem is ExamActivity activity)
            {
                if (MessageBox.Show($"确定要删除活动 \"{activity.ActivityName}\" 吗？", "确认删除",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_examService.DeleteActivity(activity.Id))
                    {
                        LogService.AddLog("抽考活动", "删除活动", $"删除活动：{activity.ActivityName}");
                        LoadActivities();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的活动！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvActivity.CurrentRow?.DataBoundItem is ExamActivity activity)
            {
                using (var form = new ExamDrawForm(activity))
                {
                    form.ShowDialog(this);
                    LoadActivities();
                }
            }
            else
            {
                MessageBox.Show("请选择要开始抽考的活动！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewResult_Click(object sender, EventArgs e)
        {
            if (dgvActivity.CurrentRow?.DataBoundItem is ExamActivity activity)
            {
                using (var form = new ExamResultForm(activity))
                {
                    form.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("请选择要查看结果的活动！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadActivities();
        }
    }
}
