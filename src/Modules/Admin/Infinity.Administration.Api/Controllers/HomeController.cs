using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServiceServer_Example;
using Microsoft.AspNetCore.Mvc;

namespace Infinity.UI.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //var serverAddress = "https://localhost:5001";
            //var channel = GrpcChannel.ForAddress(serverAddress);

            //var client = new Greeter.GreeterClient(channel);

            //var reply = await client.SayHelloAsync(new HelloRequest { Name = "sam" });

            //return Ok(reply);

            return Ok("Good");
        }
    }
}