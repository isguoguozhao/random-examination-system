using System;
using System.Collections.Generic;
using 单位抽考win7软件.Common.Entities;

namespace 单位抽考win7软件.BLL.Services
{
    /// <summary>
    /// 当前用户会话类（静态类）
    /// </summary>
    public static class CurrentUser
    {
        private static int _currentUserId;
        private static string _currentUserName;
        private static string _currentRealName;
        private static List<string> _currentRoles = new List<string>();
        private static DateTime _loginTime;

        /// <summary>
        /// 当前用户ID
        /// </summary>
        public static int CurrentUserId
        {
            get { return _currentUserId; }
        }

        /// <summary>
        /// 当前用户名
        /// </summary>
        public static string CurrentUserName
        {
            get { return _currentUserName; }
        }

        /// <summary>
        /// 当前用户真实姓名
        /// </summary>
        public static string CurrentRealName
        {
            get { return _currentRealName; }
        }

        /// <summary>
        /// 当前用户角色列表
        /// </summary>
        public static List<string> CurrentRoles
        {
            get { return new List<string>(_currentRoles); }
        }

        /// <summary>
        /// 当前用户名（简写）
        /// </summary>
        public static string UserName
        {
            get { return _currentUserName; }
        }

        /// <summary>
        /// 当前角色名称（取第一个角色）
        /// </summary>
        public static string RoleName
        {
            get { return _currentRoles.Count > 0 ? _currentRoles[0] : ""; }
        }

        /// <summary>
        /// 是否是管理员
        /// </summary>
        public static bool IsAdmin
        {
            get { return IsInRole("admin"); }
        }

        /// <summary>
        /// 登录时间
        /// </summary>
        public static DateTime LoginTime
        {
            get { return _loginTime; }
        }

        /// <summary>
        /// 是否已登录
        /// </summary>
        public static bool IsLoggedIn
        {
            get { return _currentUserId > 0; }
        }

        /// <summary>
        /// 登录
        /// </summary>
        public static void Login(SysUser user, List<string> roles)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _currentUserId = user.Id;
            _currentUserName = user.UserName;
            _currentRealName = user.RealName;
            _currentRoles = roles ?? new List<string>();
            _loginTime = DateTime.Now;
        }

        /// <summary>
        /// 登出
        /// </summary>
        public static void Logout()
        {
            _currentUserId = 0;
            _currentUserName = null;
            _currentRealName = null;
            _currentRoles.Clear();
            _loginTime = DateTime.MinValue;
        }

        /// <summary>
        /// 检查是否属于某角色
        /// </summary>
        public static bool IsInRole(string roleCode)
        {
            if (string.IsNullOrEmpty(roleCode))
                return false;

            return _currentRoles.Exists(r => r.Equals(roleCode, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 检查是否属于任意角色
        /// </summary>
        public static bool IsInAnyRole(params string[] roleCodes)
        {
            if (roleCodes == null || roleCodes.Length == 0)
                return false;

            foreach (var roleCode in roleCodes)
            {
                if (IsInRole(roleCode))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 检查是否属于所有角色
        /// </summary>
        public static bool IsInAllRoles(params string[] roleCodes)
        {
            if (roleCodes == null || roleCodes.Length == 0)
                return false;

            foreach (var roleCode in roleCodes)
            {
                if (!IsInRole(roleCode))
                    return false;
            }
            return true;
        }
    }
}
