using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OcelotChShiFirst.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "OcelotChShiFirst", "OcelotChShiFirst" };
        }

        /// <summary>
        /// 请求聚合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> AggregateRootGoods(int id)
        {
            var item = new Goods
            {
                Id = id,
                Content = $"{id}的关联的商品明细",
            };
            return JsonConvert.SerializeObject(item);
        }
        public class Goods
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }
    }
}
