using System;

namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 必抽规则实体
    /// </summary>
    public class ExamMustHitRule
    {
        /// <summary>
        /// 规则ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// 目标类型（Group-指挥组，Task-任务）
        /// </summary>
        public string TargetType { get; set; }

        /// <summary>
        /// 目标ID（指挥组ID或任务方案ID）
        /// </summary>
        public int TargetId { get; set; }

        /// <summary>
        /// 必抽级别（1-第一优先级，2-第二优先级...）
        /// </summary>
        public int MustHitLevel { get; set; }

        /// <summary>
        /// 固定位置（0-不固定，1-第一位，2-第二位...）
        /// </summary>
        public int FixedPosition { get; set; }

        /// <summary>
        /// 规则开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 规则结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 状态（0-禁用，1-启用）
        /// </summary>
        public int Status { get; set; }
    }
}
