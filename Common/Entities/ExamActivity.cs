using System;

namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 抽考活动实体
    /// </summary>
    public class ExamActivity
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string ActivityName { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 批次（别名）
        /// </summary>
        public string Batch { get { return BatchNo; } set { BatchNo = value; } }

        /// <summary>
        /// 抽取日期
        /// </summary>
        public DateTime ExamDate { get; set; }

        /// <summary>
        /// 抽取指挥组数量
        /// </summary>
        public int DrawGroupCount { get; set; }

        /// <summary>
        /// 抽取任务数量
        /// </summary>
        public int DrawTaskCount { get; set; }

        /// <summary>
        /// 抽取数量（别名，用于兼容）
        /// </summary>
        public int DrawCount { get { return DrawGroupCount; } set { DrawGroupCount = value; } }

        /// <summary>
        /// 是否允许重复抽取（0-不允许，1-允许）
        /// </summary>
        public int AllowRepeat { get; set; }

        /// <summary>
        /// 是否启用必抽
        /// </summary>
        public bool EnableMustHit { get; set; }

        /// <summary>
        /// 是否启用近期回避
        /// </summary>
        public bool EnableAvoidRecent { get; set; }

        /// <summary>
        /// 回避天数
        /// </summary>
        public int AvoidDays { get; set; }

        /// <summary>
        /// 状态（0-草稿，1-进行中，2-已完成，3-已取消）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
