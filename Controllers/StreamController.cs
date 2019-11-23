using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace streaming.Controllers
{
    [Route("/api/stream")]
    public class StreamController : Controller
    {
        [HttpGet]
        public async Task Get()
        {
            for(var i = 0; i < 20; ++i)
            {
                var data = JsonSerializer.Serialize(new {i, type = "stream", now = System.DateTime.UtcNow});
                await Response.WriteAsync(data);
                await Task.Delay(2000);
            }
        }
    }
}
