namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 指挥组成员实体
    /// </summary>
    public class CommandGroupMember
    {
        /// <summary>
        /// 成员ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 指挥组ID
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 人员ID
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// 人员姓名（非数据库字段，用于显示）
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// 成员角色
        /// </summary>
        public string MemberRole { get; set; }

        /// <summary>
        /// 角色（别名）
        /// </summary>
        public string Role { get { return MemberRole; } set { MemberRole = value; } }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
