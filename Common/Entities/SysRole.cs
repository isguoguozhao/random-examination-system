namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 角色实体
    /// </summary>
    public class SysRole
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 状态（0-禁用，1-启用）
        /// </summary>
        public int Status { get; set; }
    }
}
