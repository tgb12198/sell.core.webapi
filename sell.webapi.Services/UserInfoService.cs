using sell.webapi.Common.Enum;
using sell.webapi.Common.Utils;
using sell.webapi.Entity;
using sell.webapi.IRepository;
using sell.webapi.IServices;
using sell.webapi.Models;
using System.Collections.Generic;
using System.Linq;

namespace sell.webapi.Services.Services
{
    public class UserInfoService : IUserInfoService
    {
        public IUserInfoRepository _userInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            this._userInfoRepository = userInfoRepository;
        }
        public IEnumerable<UserInfo> GetAllList()
        {
            var list = _userInfoRepository.GetAllList();
            var userList = new List<UserInfo>();
            //list.Result.ToList().ForEach(p =>
            //{
            //    userList.Add(
            //        new UserInfo
            //        {
            //            UserId = p.UserId,
            //            UserName = p.UserName,
            //            UserPwd = p.UserPwd,
            //            UserPhone = p.UserPhone,
            //            UserFlag = (EnumValid)p.UserFlag,
            //            UserGender = p.UserGender,
            //            CreateTime = p.CreateTime,
            //            UpdateTime = p.UpdateTime
            //        });
            //});

            list.Result.ToList().ForEach(p =>
            {
                var model = new UserInfo();
                userList.Add(CopyHelper.CopyTo<UserInfo, UserInfoTable>(model, p));
            });
            return userList;
        }
    }
}
