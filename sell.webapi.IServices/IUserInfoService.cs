using sell.webapi.Models;
using System;
using System.Collections.Generic;

namespace sell.webapi.IServices
{
    public interface IUserInfoService : IDependency
    {
        IEnumerable<UserInfo> GetAllList();
    }
}
