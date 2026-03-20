using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;
using OfficeOpenXml;
using System.IO;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class LogForm : Form
    {
        private readonly LogService _logService;
        private readonly UserService _userService;
        private List<SysLog> _logs;
        private int _currentPage;
        private int _pageSize;
        private int _totalCount;

        public LogForm()
        {
            InitializeComponent();
            _logService = new LogService();
            _userService = new UserService();
            _logs = new List<SysLog>();
            _currentPage = 1;
            _pageSize = 50;
            _totalCount = 0;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            InitializeFilters();
            LoadLogs();
            CheckAdminPermission();
        }

        private void InitializeFilters()
        {
            // 模块筛选
            cmbModule.Items.Add("全部");
            cmbModule.Items.Add("系统");
            cmbModule.Items.Add("单位管理");
            cmbModule.Items.Add("人员管理");
            cmbModule.Items.Add("指挥组管理");
            cmbModule.Items.Add("任务方案管理");
            cmbModule.Items.Add("抽考活动");
            cmbModule.Items.Add("必抽规则");
            cmbModule.Items.Add("用户管理");
            cmbModule.SelectedIndex = 0;

            // 操作类型筛选
            cmbOperationType.Items.Add("全部");
            cmbOperationType.Items.Add("登录");
            cmbOperationType.Items.Add("退出");
            cmbOperationType.Items.Add("新增");
            cmbOperationType.Items.Add("编辑");
            cmbOperationType.Items.Add("删除");
            cmbOperationType.Items.Add("导入");
            cmbOperationType.Items.Add("导出");
            cmbOperationType.Items.Add("打印");
            cmbOperationType.Items.Add("抽考");
            cmbOperationType.SelectedIndex = 0;

            // 用户筛选
            LoadUsers();

            // 时间范围默认值
            dtpStartTime.Value = DateTime.Now.AddDays(-7);
            dtpEndTime.Value = DateTime.Now;
        }

        private void LoadUsers()
        {
            cmbUser.Items.Add("全部");
            var users = _userService.GetAll();
            foreach (var user in users)
            {
                cmbUser.Items.Add(user.UserName);
            }
            cmbUser.SelectedIndex = 0;
        }

        private void CheckAdminPermission()
        {
            // 只有管理员可以清空日志
            btnClear.Visible = CurrentUser.IsAdmin;
        }

        private void LoadLogs()
        {
            try
            {
                string moduleName = cmbModule.SelectedIndex > 0 ? cmbModule.SelectedItem.ToString() : null;
                string operationType = cmbOperationType.SelectedIndex > 0 ? cmbOperationType.SelectedItem.ToString() : null;
                string userName = cmbUser.SelectedIndex > 0 ? cmbUser.SelectedItem.ToString() : null;
                DateTime? startTime = dtpStartTime.Checked ? dtpStartTime.Value : (DateTime?)null;
                DateTime? endTime = dtpEndTime.Checked ? dtpEndTime.Value : (DateTime?)null;

                _logs = _logService.QueryLogs(moduleName, operationType, userName, startTime, endTime);
                _totalCount = _logs.Count;

                RefreshGrid();
                UpdatePagination();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载日志失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            // 分页显示
            var pageData = _logs.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            dgvLogs.DataSource = null;
            dgvLogs.DataSource = pageData.Select(l => new
            {
                l.Id,
                操作时间 = l.OperationTime.ToString("yyyy-MM-dd HH:mm:ss"),
                用户名 = l.UserName,
                模块 = l.ModuleName,
                操作类型 = l.OperationType,
                操作内容 = l.OperationContent
            }).ToList();

            // 隐藏Id列
            if (dgvLogs.Columns["Id"] != null)
                dgvLogs.Columns["Id"].Visible = false;

            // 调整列宽
            if (dgvLogs.Columns["操作内容"] != null)
                dgvLogs.Columns["操作内容"].Width = 300;
        }

        private void UpdatePagination()
        {
            int totalPages = (_totalCount + _pageSize - 1) / _pageSize;
            if (totalPages < 1) totalPages = 1;

            lblPagination.Text = $"第 {_currentPage} 页 / 共 {totalPages} 页 (共 {_totalCount} 条记录)";

            btnFirst.Enabled = _currentPage > 1;
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;
            btnLast.Enabled = _currentPage < totalPages;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            LoadLogs();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Excel文件|*.xlsx";
                dialog.FileName = $"操作日志_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("操作日志");

                        // 表头
                        worksheet.Cells[1, 1].Value = "操作时间";
                        worksheet.Cells[1, 2].Value = "用户名";
                        worksheet.Cells[1, 3].Value = "模块";
                        worksheet.Cells[1, 4].Value = "操作类型";
                        worksheet.Cells[1, 5].Value = "操作内容";

                        // 数据
                        for (int i = 0; i < _logs.Count; i++)
                        {
                            var log = _logs[i];
                            worksheet.Cells[i + 2, 1].Value = log.OperationTime.ToString("yyyy-MM-dd HH:mm:ss");
                            worksheet.Cells[i + 2, 2].Value = log.UserName;
                            worksheet.Cells[i + 2, 3].Value = log.ModuleName;
                            worksheet.Cells[i + 2, 4].Value = log.OperationType;
                            worksheet.Cells[i + 2, 5].Value = log.OperationContent;
                        }

                        // 自动调整列宽
                        worksheet.Cells.AutoFitColumns();

                        // 保存
                        FileInfo file = new FileInfo(dialog.FileName);
                        package.SaveAs(file);
                    }

                    MessageBox.Show("导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("只有管理员可以清空日志", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确定要清空所有操作日志吗？此操作不可恢复！", "警告", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (_logService.ClearAll())
                    {
                        LogService.AddLog("系统", "清空日志", "管理员清空了所有操作日志");
                        _currentPage = 1;
                        LoadLogs();
                        MessageBox.Show("日志已清空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("清空失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"清空失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            RefreshGrid();
            UpdatePagination();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                RefreshGrid();
                UpdatePagination();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (_totalCount + _pageSize - 1) / _pageSize;
            if (_currentPage < totalPages)
            {
                _currentPage++;
                RefreshGrid();
                UpdatePagination();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int totalPages = (_totalCount + _pageSize - 1) / _pageSize;
            _currentPage = totalPages;
            RefreshGrid();
            UpdatePagination();
        }
    }
}
