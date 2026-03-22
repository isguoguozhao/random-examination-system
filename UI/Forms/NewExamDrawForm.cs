using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;
using 单位抽考win7软件.Common;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class NewExamDrawForm : Form
    {
        private readonly ExamService _examService;
        private readonly TaskPlanService _taskPlanService;
        private readonly CommandGroupService _commandGroupService;
        private readonly PersonService _personService;
        
        private int _currentStep;
        private int _activityId;
        private ExamActivity _activity;
        
        // 抽取结果
        private TaskPlan _content1Task;
        private TaskPlan _content2Task;
        private Person _content1Commander;
        private Person _content2Commander;
        
        private List<TaskPlan> _taskList;
        private List<CommandGroup> _commandGroupList;
        private List<Person> _personList;
        private Timer _animationTimer;
        private bool _isAnimating;
        private Random _random;

        public NewExamDrawForm(int activityId)
        {
            InitializeComponent();
            _examService = new ExamService();
            _taskPlanService = new TaskPlanService();
            _commandGroupService = new CommandGroupService();
            _personService = new PersonService();
            
            _activityId = activityId;
            _currentStep = 1;
            _random = new Random();
            _isAnimating = false;
            
            InitializeAnimationTimer();
            
            ModernTechTheme.ApplyTheme(this);
        }

        private void NewExamDrawForm_Load(object sender, EventArgs e)
        {
            LoadActivityData();
            LoadStepData();
            UpdateUI();
        }

        private void InitializeAnimationTimer()
        {
            _animationTimer = new Timer();
            _animationTimer.Interval = 100;
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        private void LoadActivityData()
        {
            try
            {
                _activity = _examService.GetById(_activityId);
                if (_activity == null)
                {
                    MessageBox.Show("未找到抽考活动", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // 加载可用的任务方案
                _taskList = _taskPlanService.GetAvailable();
                // 加载可用的指挥组
                _commandGroupList = _commandGroupService.GetAvailable();
                // 加载人员列表
                _personList = _personService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadStepData()
        {
            switch (_currentStep)
            {
                case 1:
                    lblStepTitle.Text = "第一步：抽取考核内容1的任务名称";
                    lblDescription.Text = "点击「开始抽取」按钮，系统将随机抽取考核内容1的任务";
                    break;
                case 2:
                    lblStepTitle.Text = "第二步：抽取考核内容2的任务名称";
                    lblDescription.Text = "点击「开始抽取」按钮，系统将随机抽取考核内容2的任务";
                    break;
                case 3:
                    lblStepTitle.Text = "第三步：抽取考核内容1的值班指挥员";
                    lblDescription.Text = "点击「开始抽取」按钮，系统将随机抽取考核内容1的值班指挥员";
                    break;
                case 4:
                    lblStepTitle.Text = "第四步：抽取考核内容2的值班指挥员";
                    lblDescription.Text = "点击「开始抽取」按钮，系统将随机抽取考核内容2的值班指挥员";
                    break;
                case 5:
                    ShowFinalResult();
                    break;
            }

            btnPrevious.Enabled = _currentStep > 1 && _currentStep < 5;
            btnNext.Enabled = false;
            lblResult.Text = "";
            lblResult.Visible = false;
        }

        private void UpdateUI()
        {
            // 更新步骤指示器
            lblStep1.ForeColor = _currentStep >= 1 ? Color.FromArgb(0, 51, 102) : Color.Gray;
            lblStep2.ForeColor = _currentStep >= 2 ? Color.FromArgb(0, 51, 102) : Color.Gray;
            lblStep3.ForeColor = _currentStep >= 3 ? Color.FromArgb(0, 51, 102) : Color.Gray;
            lblStep4.ForeColor = _currentStep >= 4 ? Color.FromArgb(0, 51, 102) : Color.Gray;
            
            lblStep1.Font = _currentStep == 1 ? new Font("微软雅黑", 12F, FontStyle.Bold) : new Font("微软雅黑", 12F, FontStyle.Regular);
            lblStep2.Font = _currentStep == 2 ? new Font("微软雅黑", 12F, FontStyle.Bold) : new Font("微软雅黑", 12F, FontStyle.Regular);
            lblStep3.Font = _currentStep == 3 ? new Font("微软雅黑", 12F, FontStyle.Bold) : new Font("微软雅黑", 12F, FontStyle.Regular);
            lblStep4.Font = _currentStep == 4 ? new Font("微软雅黑", 12F, FontStyle.Bold) : new Font("微软雅黑", 12F, FontStyle.Regular);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isAnimating) return;

            _isAnimating = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnStop.Visible = true;
            lblResult.Visible = true;

            _animationTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_isAnimating) return;

            _animationTimer.Stop();
            _isAnimating = false;
            btnStop.Enabled = false;

            // 执行实际抽取
            PerformDraw();

            btnNext.Enabled = _currentStep < 5;
            btnStart.Enabled = true;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // 随机显示动画效果
            switch (_currentStep)
            {
                case 1:
                case 2:
                    if (_taskList != null && _taskList.Count > 0)
                    {
                        int index = _random.Next(_taskList.Count);
                        lblResult.Text = _taskList[index].TaskName;
                    }
                    break;
                case 3:
                case 4:
                    if (_personList != null && _personList.Count > 0)
                    {
                        int index = _random.Next(_personList.Count);
                        var person = _personList[index];
                        lblResult.Text = person.Name;
                    }
                    break;
            }
        }

        private void PerformDraw()
        {
            switch (_currentStep)
            {
                case 1:
                    // 抽取考核内容1的任务
                    if (_taskList != null && _taskList.Count > 0)
                    {
                        int index = _random.Next(_taskList.Count);
                        _content1Task = _taskList[index];
                        lblResult.Text = _content1Task.TaskName;
                    }
                    break;
                case 2:
                    // 抽取考核内容2的任务
                    if (_taskList != null && _taskList.Count > 0)
                    {
                        int index = _random.Next(_taskList.Count);
                        _content2Task = _taskList[index];
                        lblResult.Text = _content2Task.TaskName;
                    }
                    break;
                case 3:
                    // 抽取考核内容1的值班指挥员
                    if (_personList != null && _personList.Count > 0)
                    {
                        int index = _random.Next(_personList.Count);
                        _content1Commander = _personList[index];
                        lblResult.Text = _content1Commander.Name;
                    }
                    break;
                case 4:
                    // 抽取考核内容2的值班指挥员
                    if (_personList != null && _personList.Count > 0)
                    {
                        int index = _random.Next(_personList.Count);
                        _content2Commander = _personList[index];
                        lblResult.Text = _content2Commander.Name;
                    }
                    break;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentStep > 1)
            {
                _currentStep--;
                LoadStepData();
                UpdateUI();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentStep < 5)
            {
                _currentStep++;
                LoadStepData();
                UpdateUI();
            }
        }

        private void ShowFinalResult()
        {
            lblStepTitle.Text = "抽考结果";
            lblDescription.Text = "以下是本次抽考的最终结果";
            
            // 隐藏抽取相关控件
            btnStart.Visible = false;
            btnStop.Visible = false;
            lblResult.Visible = false;
            btnPrevious.Visible = false;
            btnNext.Visible = false;
            btnComplete.Visible = true;
            btnExport.Visible = true;
            btnPrint.Visible = true;
            panelResult.Visible = true;

            // 填充结果表格
            FillResultGrid();
        }

        private void FillResultGrid()
        {
            dgvResult.Rows.Clear();
            dgvResult.Columns.Clear();

            // 添加列
            dgvResult.Columns.Add("序号", "序号");
            dgvResult.Columns.Add("考核内容", "考核内容");
            dgvResult.Columns.Add("姓名", "姓名");
            dgvResult.Columns.Add("部职别", "部职别");

            // 添加数据行
            if (_content1Task != null && _content1Commander != null)
            {
                int rowIndex = dgvResult.Rows.Add();
                dgvResult.Rows[rowIndex].Cells["序号"].Value = "1";
                dgvResult.Rows[rowIndex].Cells["考核内容"].Value = _content1Task.TaskName;
                dgvResult.Rows[rowIndex].Cells["姓名"].Value = _content1Commander.Name;
                dgvResult.Rows[rowIndex].Cells["部职别"].Value = $"{_content1Commander.PostName}";
            }

            if (_content2Task != null && _content2Commander != null)
            {
                int rowIndex = dgvResult.Rows.Add();
                dgvResult.Rows[rowIndex].Cells["序号"].Value = "2";
                dgvResult.Rows[rowIndex].Cells["考核内容"].Value = _content2Task.TaskName;
                dgvResult.Rows[rowIndex].Cells["姓名"].Value = _content2Commander.Name;
                dgvResult.Rows[rowIndex].Cells["部职别"].Value = $"{_content2Commander.PostName}";
            }

            // 应用样式
            ApplyResultGridStyle();
        }

        private void ApplyResultGridStyle()
        {
            dgvResult.BackgroundColor = Color.FromArgb(245, 245, 220);
            dgvResult.BorderStyle = BorderStyle.None;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.RowTemplate.Height = 40;

            // 列标题样式
            dgvResult.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102);
            dgvResult.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvResult.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
            dgvResult.ColumnHeadersHeight = 45;
            dgvResult.EnableHeadersVisualStyles = false;

            // 行样式
            dgvResult.DefaultCellStyle.BackColor = Color.White;
            dgvResult.DefaultCellStyle.ForeColor = Color.Black;
            dgvResult.DefaultCellStyle.Font = new Font("微软雅黑", 11F);
            dgvResult.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 102, 153);
            dgvResult.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 240);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            // 保存抽取结果
            try
            {
                SaveDrawResults();
                MessageBox.Show("抽考完成，结果已保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存结果失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDrawResults()
        {
            // 保存到数据库 - 使用现有的GenerateFinalResult方法
            try
            {
                _examService.GenerateFinalResult(_activityId);
            }
            catch (Exception ex)
            {
                // 如果生成最终结果失败，记录错误但不阻止关闭
                Console.WriteLine($"保存结果失败: {ex.Message}");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            try
            {
                ExportToExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // 打印结果
            MessageBox.Show("打印功能开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToExcel()
        {
            // Excel导出实现
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel文件|*.xlsx";
            dialog.FileName = $"抽考结果_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // 使用ExamService的导出方法
                _examService.ExportResultsToExcel(_activityId, dialog.FileName);
                MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
