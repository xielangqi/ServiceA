using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private HttpClient client;

        public ValuesController()
        {
            client = new HttpClient();
        }

        [HttpGet]
        [Route("list")]
        public List<string> List()
        {
            var list = new List<string>();
            for (var i = 0; i < 10; i++)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = httpClient.GetAsync($"http://10.100.145.46:5000/api/test/list").Result.Content.ReadAsStringAsync().Result;
                    list.Add(content);
                }
            }
            return list;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            var response = client.GetAsync($"http://localhost:54769/api/values/detail").Result;

            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

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
    }
}
