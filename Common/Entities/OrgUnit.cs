using System;

namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 单位实体
    /// </summary>
    public class OrgUnit
    {
        /// <summary>
        /// 单位ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// 单位简称
        /// </summary>
        public string UnitShortName { get; set; }

        /// <summary>
        /// 单位编码
        /// </summary>
        public string UnitCode { get; set; }

        /// <summary>
        /// 上级单位ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 单位类型
        /// </summary>
        public string UnitType { get; set; }

        /// <summary>
        /// 状态（0-禁用，1-启用）
        /// </summary>
        public int Status { get; set; }

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
