namespace 单位抽考win7软件.Common.Entities
{
    /// <summary>
    /// 系统配置实体
    /// </summary>
    public class SysConfig
    {
        /// <summary>
        /// 配置ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 配置键
        /// </summary>
        public string ConfigKey { get; set; }

        /// <summary>
        /// 配置值
        /// </summary>
        public string ConfigValue { get; set; }

        /// <summary>
        /// 配置描述
        /// </summary>
        public string Description { get; set; }
    }
}
