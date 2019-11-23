using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace streaming.Controllers
{
    [Route("/api/sse")]
    public class ServerSentEventController : Controller
{
    [HttpGet]
    public async Task Get()
    {
        Response.Headers.Add("Content-Type", "text/event-stream");

        for(var i = 0; i < 20; ++i)
        {
            var data = JsonSerializer.Serialize(new {i, type = "sse", now = System.DateTime.UtcNow});
            await Response.WriteAsync($"data: {data}\r\r");
            await Task.Delay(2000);
        }
    }
}
}
