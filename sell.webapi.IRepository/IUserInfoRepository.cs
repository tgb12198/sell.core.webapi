using sell.webapi.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sell.webapi.IRepository
{
     public interface IUserInfoRepository
    {
        Task<IEnumerable<UserInfoTable>> GetAllList();

        #region 增加
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        Task<bool> AddUserInfo(UserInfoTable userinfo);
        #endregion


        #region  修改
        /// <summary>
        ///修改个人信息
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        Task<bool> UpdateUserInfo(UserInfoTable userinfo);
        #endregion

        /// <summary>
        /// 根据Id获取用户数据
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        UserInfoTable GetUserInfoById(int UserId);

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<UserInfoTable>> GetUserInfoList(int PageIndex, int PageSize);
    }
}
