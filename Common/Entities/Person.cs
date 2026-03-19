namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 人员实体
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 所属单位ID
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// 职务名称
        /// </summary>
        public string PostName { get; set; }

        /// <summary>
        /// 职务/职位（别名）
        /// </summary>
        public string Position { get { return PostName; } set { PostName = value; } }

        /// <summary>
        /// 角色类型
        /// </summary>
        public string RoleType { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 状态（0-禁用，1-启用）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
