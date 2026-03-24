using System;

namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 最终结果映射实体
    /// </summary>
    public class ExamActivityFinalResult
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
        /// 排序号
        /// </summary>
        public int SortNo { get; set; }

        /// <summary>
        /// 指挥组结果ID
        /// </summary>
        public int GroupResultId { get; set; }

        /// <summary>
        /// 指挥组名称（非数据库字段，用于显示）
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 任务结果ID
        /// </summary>
        public int TaskResultId { get; set; }

        /// <summary>
        /// 任务方案名称（非数据库字段，用于显示）
        /// </summary>
        public string TaskPlanName { get; set; }

        /// <summary>
        /// 考核内容1任务（非数据库字段，用于显示）
        /// </summary>
        public string Content1TaskName { get; set; }

        /// <summary>
        /// 考核内容1指挥员（非数据库字段，用于显示）
        /// </summary>
        public string Content1CommanderName { get; set; }

        /// <summary>
        /// 考核内容2任务（非数据库字段，用于显示）
        /// </summary>
        public string Content2TaskName { get; set; }

        /// <summary>
        /// 考核内容2指挥员（非数据库字段，用于显示）
        /// </summary>
        public string Content2CommanderName { get; set; }

        /// <summary>
        /// 抽考时间（非数据库字段，用于显示）
        /// </summary>
        public DateTime DrawTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
