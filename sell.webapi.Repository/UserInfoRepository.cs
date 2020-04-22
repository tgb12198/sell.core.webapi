using sell.webapi.DataBase;
using sell.webapi.Entity;
using sell.webapi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sell.webapi.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        public IDbContext _dbContext;
        public UserInfoRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<bool> AddUserInfo(UserInfo userinfo)
        {
            string query = "insert into user(user_id, user_name,user_pwd,user_phone,user_gender,user_flag,create_time,update_time) values(@user_id,@user_name,@user_pwd,@user_phone,@user_gender,@user_flag,@create_time,@update_time)";
            int row = await _dbContext.Update<UserInfo>(query, userinfo);

            return row > 0 ? true : false;
        }

        public async Task<IEnumerable<UserInfo>> GetAllList()
        {
            var query = "select user_id UserId, user_name UserName,user_pwd UserPwd,user_phone UserPhone,user_gender UserGender,user_flag UserFlag,create_time CreateTime,update_time UpdateTime from user_info";
            var list = await _dbContext.Select<UserInfo>(query);
            return list;
        }

        public UserInfo GetUserInfoById(int userId)
        {
            var query = string.Format("select user_id, user_name,user_pwd,user_phone,user_gender,user_flag,create_time,update_time from user_info where user_id=@userId");
            var user = _dbContext.SelectFirst<UserInfo>(query, new { UserId = userId });
            return user;
        }

        public async Task<IEnumerable<UserInfo>> GetUserInfoList(int pageIndex, int pageSize)
        {
            var sql = string.Format("select user_id, user_name,user_pwd,user_phone,user_gender,user_flag,create_time,update_time from user_info limit @start,@end");
            var list = await _dbContext.Select<UserInfo>(sql, new { start = (pageIndex - 1) * pageSize, end = pageSize });
            return list;
        }

        public async Task<bool> UpdateUserInfo(UserInfo userinfo)
        {
            var sql = string.Format("update user_info set user_name=@userName,user_pwd=@userPwd,user_phone=@userPhone,user_gender=@userGender,user_flag=@userFlag,create_time=@createTime,update_time=@updateTime where user_id=@userId");
            var row = await _dbContext.Update<UserInfo>(sql, userinfo);
            return row > 0 ? true : false;
        }
    }
}
