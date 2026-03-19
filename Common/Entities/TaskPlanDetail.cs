namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 任务方案明细实体
    /// </summary>
    public class TaskPlanDetail
    {
        /// <summary>
        /// 明细ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 任务方案ID
        /// </summary>
        public int TaskPlanId { get; set; }

        /// <summary>
        /// 单位ID（非数据库字段，用于编辑）
        /// </summary>
        public int OrgUnitId { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// 单位名称（别名）
        /// </summary>
        public string OrgUnitName { get { return UnitName; } set { UnitName = value; } }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string TaskDesc { get; set; }

        /// <summary>
        /// 任务描述（别名）
        /// </summary>
        public string TaskDescription { get { return TaskDesc; } set { TaskDesc = value; } }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNo { get; set; }
    }
}
