using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sell.webapi.Common.Comm;
using sell.webapi.IServices;
using sell.webapi.Models;

namespace sell.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IUserInfoService _userInfoService;

        public ValuesController(IUserInfoService userInfoService)
        {
            this._userInfoService = userInfoService;
        }

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public BaseResponse<IEnumerable<UserInfo>> GetAllList(int id = 0)
        {
            var list = _userInfoService.GetAllList();
            return new BaseResponse<IEnumerable<UserInfo>> { Code = 0, Message = "success", Data = list };
        }
    }
}
