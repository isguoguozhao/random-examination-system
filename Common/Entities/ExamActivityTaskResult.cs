using System;

namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 任务抽取结果实体
    /// </summary>
    public class ExamActivityTaskResult
    {
        /// <summary>
        /// 结果ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// 任务方案ID
        /// </summary>
        public int TaskPlanId { get; set; }

        /// <summary>
        /// 任务方案名称（非数据库字段，用于显示）
        /// </summary>
        public string TaskPlanName { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNo { get; set; }

        /// <summary>
        /// 是否必抽（0-否，1-是）
        /// </summary>
        public int IsMustHit { get; set; }

        /// <summary>
        /// 抽取时间
        /// </summary>
        public DateTime DrawTime { get; set; }
    }
}
