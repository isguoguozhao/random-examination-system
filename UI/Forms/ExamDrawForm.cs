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
        private readonly CommandGroupService _commandGroupService;
        private readonly TaskPlanService _taskPlanService;
        private ExamActivity _activity;
        private int _currentStep;
        private List<CommandGroup> _candidateGroups;
        private List<TaskPlan> _candidateTaskPlans;
        private CommandGroup _selectedGroup;
        private TaskPlan _selectedTaskPlan;
        private bool _isDrawing;
        private Thread _drawThread;

        public ExamDrawForm(ExamActivity activity)
        {
            InitializeComponent();
            _examService = new ExamService();
            _commandGroupService = new CommandGroupService();
            _taskPlanService = new TaskPlanService();
            _activity = activity;
            _currentStep = 1;
            LoadCandidates();
            UpdateUI();
        }

        private void LoadCandidates()
        {
            _candidateGroups = _commandGroupService.GetDrawableGroups();
            _candidateTaskPlans = _taskPlanService.GetAll();
        }

        private void UpdateUI()
        {
            lblStep.Text = $"第 {_currentStep}/3 步";
            progressBar.Value = _currentStep;

            switch (_currentStep)
            {
                case 1:
                    lblTitle.Text = "第一步：抽取指挥组";
                    lblCandidate.Text = "候选指挥组：";
                    BindCandidates(_candidateGroups);
                    break;
                case 2:
                    lblTitle.Text = "第二步：抽取任务方案";
                    lblCandidate.Text = "候选任务方案：";
                    BindCandidates(_candidateTaskPlans);
                    break;
                case 3:
                    lblTitle.Text = "第三步：确认结果";
                    ShowFinalResult();
                    break;
            }
        }

        private void BindCandidates<T>(List<T> candidates)
        {
            lstCandidates.DataSource = null;
            lstCandidates.DataSource = candidates;
        }

        private void ShowFinalResult()
        {
            lstCandidates.Visible = false;
            lblAnimation.Visible = false;
            panelResult.Visible = true;

            lblResultGroup.Text = $"指挥组：{_selectedGroup?.GroupName}";
            lblResultTask.Text = $"任务方案：{_selectedTaskPlan?.PlanName}";
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (_isDrawing) return;

            _isDrawing = true;
            btnDraw.Enabled = false;
            btnConfirm.Enabled = false;

            lblAnimation.Visible = true;
            lstCandidates.Visible = false;

            _drawThread = new Thread(DrawAnimation);
            _drawThread.IsBackground = true;
            _drawThread.Start();
        }

        private void DrawAnimation()
        {
            Random random = new Random();
            int count = 0;
            int maxCount = 30;

            while (count < maxCount)
            {
                this.Invoke(new Action(() =>
                {
                    if (_currentStep == 1 && _candidateGroups.Count > 0)
                    {
                        int index = random.Next(_candidateGroups.Count);
                        lblAnimation.Text = _candidateGroups[index].GroupName;
                    }
                    else if (_currentStep == 2 && _candidateTaskPlans.Count > 0)
                    {
                        int index = random.Next(_candidateTaskPlans.Count);
                        lblAnimation.Text = _candidateTaskPlans[index].PlanName;
                    }
                }));

                Thread.Sleep(100);
                count++;
            }

            this.Invoke(new Action(() =>
            {
                _isDrawing = false;
                btnDraw.Enabled = true;
                btnConfirm.Enabled = true;

                if (_currentStep == 1 && _candidateGroups.Count > 0)
                {
                    int index = random.Next(_candidateGroups.Count);
                    _selectedGroup = _candidateGroups[index];
                    lblAnimation.Text = _selectedGroup.GroupName;
                }
                else if (_currentStep == 2 && _candidateTaskPlans.Count > 0)
                {
                    int index = random.Next(_candidateTaskPlans.Count);
                    _selectedTaskPlan = _candidateTaskPlans[index];
                    lblAnimation.Text = _selectedTaskPlan.PlanName;
                }
            }));
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_currentStep < 3)
            {
                _currentStep++;
                UpdateUI();
            }
            else
            {
                SaveResult();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SaveResult()
        {
            if (_selectedGroup != null && _selectedTaskPlan != null)
            {
                var result = new ExamActivityGroupResult
                {
                    ActivityId = _activity.Id,
                    GroupId = _selectedGroup.Id,
                    GroupName = _selectedGroup.GroupName,
                    TaskPlanId = _selectedTaskPlan.Id,
                    TaskPlanName = _selectedTaskPlan.PlanName,
                    DrawTime = DateTime.Now
                };

                _examService.SaveGroupResult(result);
                LogService.AddLog("抽考活动", "抽取结果", $"活动：{_activity.ActivityName}，抽取指挥组：{_selectedGroup.GroupName}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_isDrawing)
            {
                _drawThread?.Abort();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isDrawing && _drawThread != null && _drawThread.IsAlive)
            {
                _drawThread.Abort();
            }
            base.OnFormClosing(e);
        }
    }
}
