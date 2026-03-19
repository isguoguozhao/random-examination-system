using System;

namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 指挥组实体
    /// </summary>
    public class CommandGroup
    {
        /// <summary>
        /// 指挥组ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 指挥组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 指挥组编号/代码
        /// </summary>
        public string GroupCode { get; set; }

        /// <summary>
        /// 所属单位ID
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// 所属单位ID（别名）
        /// </summary>
        public int OrgUnitId { get { return UnitId; } set { UnitId = value; } }

        /// <summary>
        /// 指挥组编号
        /// </summary>
        public string GroupNo { get; set; }

        /// <summary>
        /// 状态（0-禁用，1-启用）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否启用（布尔值）
        /// </summary>
        public bool IsActive { get { return Status == 1; } set { Status = value ? 1 : 0; } }

        /// <summary>
        /// 是否可抽取（0-不可抽，1-可抽）
        /// </summary>
        public int CanDraw { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
