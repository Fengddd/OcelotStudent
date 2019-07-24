using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OcelotChShiTwo.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "OcelotChShiTwo", "OcelotChShiTwo" };
        }

        /// <summary>
        /// 请求聚合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> AggregateRootOrder(int id)
        {
            var item = new Orders
            {
                Id = id,
                Content = $"{id}的订单明细",
            };
            return JsonConvert.SerializeObject(item);
        }

        public class Orders
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }

    }
}
