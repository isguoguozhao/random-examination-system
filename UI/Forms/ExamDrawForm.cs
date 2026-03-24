using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using 单位抽考win7软件.BLL.Services;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.UI.Forms
{
    public partial class ExamDrawForm : Form
    {
        private readonly ExamService _examService;
        private readonly TaskPlanService _taskPlanService;
        private readonly PersonService _personService;
        private ExamActivity _activity;
        private int _currentStep;
        private List<TaskPlan> _taskPlans;
        private List<Person> _persons;
        private TaskPlan _content1Task;
        private TaskPlan _content2Task;
        private Person _content1Commander;
        private Person _content2Commander;
        private bool _isDrawing;
        private Thread _drawThread;
        private Random _random;

        public ExamDrawForm(ExamActivity activity)
        {
            InitializeComponent();
            _examService = new ExamService();
            _taskPlanService = new TaskPlanService();
            _personService = new PersonService();
            _activity = activity;
            _currentStep = 1;
            _random = new Random();
            LoadData();
            UpdateUI();
        }

        private void LoadData()
        {
            _taskPlans = _taskPlanService.GetAll();
            _persons = _personService.GetAll();
        }

        private void UpdateUI()
        {
            lblStep.Text = _currentStep <= 4 ? $"第 {_currentStep}/4 步" : "完成";
            progressBar.Maximum = 4;
            progressBar.Value = _currentStep <= 4 ? _currentStep : 4;

            lstCandidates.Visible = false;
            lblCandidate.Visible = false;
            lblAnimation.Visible = true;
            panelResult.Visible = false;

            btnDraw.Visible = true;
            btnDraw.Enabled = true;
            btnStop.Visible = false;
            btnNext.Visible = false;
            btnConfirm.Visible = false;
            btnCancel.Visible = true;
            btnPrevious.Visible = _currentStep > 1 && _currentStep < 5;

            switch (_currentStep)
            {
                case 1:
                    lblTitle.Text = "第一步：抽取考核内容1的任务名称";
                    lblAnimation.Text = "";
                    break;
                case 2:
                    lblTitle.Text = "第二步：抽取考核内容2的任务名称";
                    lblAnimation.Text = "";
                    break;
                case 3:
                    lblTitle.Text = "第三步：抽取考核内容1的值班指挥员";
                    lblAnimation.Text = "";
                    break;
                case 4:
                    lblTitle.Text = "第四步：抽取考核内容2的值班指挥员";
                    lblAnimation.Text = "";
                    break;
                case 5:
                    ShowFinalResult();
                    break;
            }
        }

        private void ShowFinalResult()
        {
            lblTitle.Text = "最终抽取结果";
            lblStep.Text = "完成";
            progressBar.Value = 4;

            lblAnimation.Visible = false;
            panelResult.Visible = true;

            btnDraw.Visible = false;
            btnStop.Visible = false;
            btnNext.Visible = false;
            btnConfirm.Visible = true;
            btnCancel.Visible = true;
            btnPrevious.Visible = false;
            btnConfirm.Text = "完成";

            dgvResult.Rows.Clear();
            dgvResult.Columns.Clear();

            dgvResult.Columns.Add("序号", "序号");
            dgvResult.Columns.Add("考核内容", "考核内容");
            dgvResult.Columns.Add("姓名", "姓名");
            dgvResult.Columns.Add("部职别", "部职别");

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
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (_isDrawing) return;

            _isDrawing = true;
            btnDraw.Visible = false;
            btnStop.Visible = true;
            btnStop.Enabled = true;

            _drawThread = new Thread(DrawAnimation);
            _drawThread.IsBackground = true;
            _drawThread.Start();
        }

        private void DrawAnimation()
        {
            int count = 0;
            int maxCount = 100;

            while (_isDrawing && count < maxCount)
            {
                this.Invoke(new Action(() =>
                {
                    if (_currentStep == 1 || _currentStep == 2)
                    {
                        if (_taskPlans != null && _taskPlans.Count > 0)
                        {
                            int index = _random.Next(_taskPlans.Count);
                            lblAnimation.Text = _taskPlans[index].TaskName;
                        }
                    }
                    else if (_currentStep == 3 || _currentStep == 4)
                    {
                        if (_persons != null && _persons.Count > 0)
                        {
                            int index = _random.Next(_persons.Count);
                            lblAnimation.Text = _persons[index].Name;
                        }
                    }
                }));

                Thread.Sleep(50);
                count++;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_isDrawing) return;

            _isDrawing = false;
            _drawThread?.Join();

            btnStop.Visible = false;
            btnNext.Visible = true;
            btnStop.Enabled = false;
            btnNext.Enabled = true;

            PerformFinalDraw();
        }

        private void PerformFinalDraw()
        {
            switch (_currentStep)
            {
                case 1:
                    if (_taskPlans != null && _taskPlans.Count > 0)
                    {
                        int index = _random.Next(_taskPlans.Count);
                        _content1Task = _taskPlans[index];
                        lblAnimation.Text = _content1Task.TaskName;
                    }
                    break;
                case 2:
                    if (_taskPlans != null && _taskPlans.Count > 0)
                    {
                        int index = _random.Next(_taskPlans.Count);
                        _content2Task = _taskPlans[index];
                        lblAnimation.Text = _content2Task.TaskName;
                    }
                    break;
                case 3:
                    if (_persons != null && _persons.Count > 0)
                    {
                        int index = _random.Next(_persons.Count);
                        _content1Commander = _persons[index];
                        lblAnimation.Text = _content1Commander.Name;
                    }
                    break;
                case 4:
                    if (_persons != null && _persons.Count > 0)
                    {
                        int index = _random.Next(_persons.Count);
                        _content2Commander = _persons[index];
                        lblAnimation.Text = _content2Commander.Name;
                    }
                    break;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentStep >= 1 && _currentStep <= 4)
            {
                _currentStep++;
                UpdateUI();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_currentStep == 5)
            {
                SaveResult();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SaveResult()
        {
            DateTime now = DateTime.Now;

            ExamActivityTaskResult taskResult1 = null;
            ExamActivityTaskResult taskResult2 = null;

            if (_content1Task != null)
            {
                taskResult1 = new ExamActivityTaskResult
                {
                    ActivityId = _activity.Id,
                    TaskPlanId = _content1Task.Id,
                    SortNo = 1,
                    IsMustHit = 0,
                    DrawTime = now
                };
                _examService.SaveTaskResult(taskResult1);
            }

            if (_content2Task != null)
            {
                taskResult2 = new ExamActivityTaskResult
                {
                    ActivityId = _activity.Id,
                    TaskPlanId = _content2Task.Id,
                    SortNo = 2,
                    IsMustHit = 0,
                    DrawTime = now
                };
                _examService.SaveTaskResult(taskResult2);
            }

            if (taskResult1 != null && taskResult2 != null && _content1Commander != null && _content2Commander != null)
            {
                var finalResult = new ExamActivityFinalResult
                {
                    ActivityId = _activity.Id,
                    SortNo = 1,
                    GroupResultId = 0,
                    TaskResultId = 0,
                    Content1TaskName = _content1Task?.TaskName ?? "",
                    Content1CommanderName = _content1Commander?.Name ?? "",
                    Content2TaskName = _content2Task?.TaskName ?? "",
                    Content2CommanderName = _content2Commander?.Name ?? "",
                    DrawTime = now,
                    CreateTime = now
                };
                _examService.SaveFinalResult(finalResult);
            }

            LogService.AddLog("抽考活动", "抽取结果", $"活动：{_activity.ActivityName}，完成抽取");
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentStep > 1 && _currentStep < 5)
            {
                _currentStep--;
                UpdateUI();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isDrawing)
            {
                _isDrawing = false;
                _drawThread?.Abort();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isDrawing && _drawThread != null && _drawThread.IsAlive)
            {
                _isDrawing = false;
                _drawThread.Abort();
            }
            base.OnFormClosing(e);
        }
    }
}
