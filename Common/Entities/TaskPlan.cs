namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 任务方案实体
    /// </summary>
    public class TaskPlan
    {
        /// <summary>
        /// 任务方案ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 方案名称（别名）
        /// </summary>
        public string PlanName { get { return TaskName; } set { TaskName = value; } }

        /// <summary>
        /// 考核内容
        /// </summary>
        public string ExamContent { get; set; }

        /// <summary>
        /// 方案描述（别名）
        /// </summary>
        public string Description { get { return ExamContent; } set { ExamContent = value; } }

        /// <summary>
        /// 任务类型
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// 难度等级
        /// </summary>
        public string DifficultyLevel { get; set; }

        /// <summary>
        /// 状态（0-禁用，1-启用）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否可抽取（0-不可抽，1-可抽）
        /// </summary>
        public int CanDraw { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
