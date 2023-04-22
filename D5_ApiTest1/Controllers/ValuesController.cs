using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D5_ApiTest1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET /api/Values
        [HttpGet]
        public IEnumerable<string> Get() 
        {
            return new[] { "value1", "value2" };
        }

        // GET /api/Values/x
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value{id}";
        }

        // POST /api/Values
        [HttpPost]
        // public string Post(string value1, int value2)
        public string Post([FromBody]string value)
        {
            return $"POST: {value}";
        }

        // DELETE /api/Values/x
        [HttpDelete("{id}")]
        public string Delete(int id) 
        {
            return $"Do usunięcia: {id}";
        }

        // PUT /api/Values/x
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string data)
        {
            return $"PUT: {id}, {data}";
        }
    }
}
