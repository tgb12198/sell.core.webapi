using sell.webapi.Common.Enum;
using sell.webapi.IRepository;
using sell.webapi.IServices;
using sell.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            list.Result.ToList().ForEach(p =>
            {
                userList.Add(
                    new UserInfo
                    {
                        UserId = p.UserId,
                        UserName = p.UserName,
                        UserPwd = p.UserPwd,
                        UserPhone = p.UserPhone,
                        UserFlag = (EnumValid)p.UserFlag,
                        UserGender = p.UserGender,
                        CreateTime = p.CreateTime,
                        UpdateTime = p.UpdateTime
                    });
            });
            return userList;
        }
    }
}
