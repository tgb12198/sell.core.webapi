﻿using System;
using System.Collections.Generic;
using System.Text;

namespace sell.webapi.Common.Comm
{
    public class BaseResponse<T>
    {
        /// <summary>
        /// 0:成功；1：失败
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }
}
