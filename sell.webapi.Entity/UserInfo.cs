using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace sell.webapi.Entity
{
    public class UserInfo
    {
        [Column("user_id")]
        public long UserId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("user_pwd")]
        public string UserPwd { get; set; }

        [Column("user_phone")]
        public string UserPhone { get; set; }

        [Column("user_gender")]
        public int UserGender { get; set; }

        [Column("user_flag")]
        public int UserFlag { get; set; }

        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        [Column("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}
