using sell.webapi.Common.Enum;
using sell.webapi.Entity.Mapper;
using System;

namespace sell.webapi.Entity
{
    public class UserInfoTable
    {
        [Column(Name ="user_id")]
        public long UserId { get; set; }

        [Column(Name = "user_name")]
        public string UserName { get; set; }

        [Column(Name = "user_pwd")]
        public string UserPwd { get; set; }

        [Column(Name = "user_phone")]
        public string UserPhone { get; set; }

        [Column(Name = "user_gender")]
        public int UserGender { get; set; }

        [Column(Name = "user_flag")]
        public int UserFlag { get; set; }

        [Column(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        [Column(Name = "update_time")]
        public DateTime UpdateTime { get; set; }

        public UserInfoTable()
        {
            this.UserName = string.Empty;
            this.UserPwd = string.Empty;
            this.UserPhone = string.Empty;
            this.UserGender = 0;
            this.UserId = EnumValid.Valid.GetHashCode();
            this.CreateTime = new DateTime(1900, 01, 01);
            this.UpdateTime = new DateTime(1900, 01, 01);
        }
    }
}
