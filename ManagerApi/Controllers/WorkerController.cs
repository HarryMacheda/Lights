using Microsoft.AspNetCore.Mvc;

namespace ManagerApi.Controllers
{
    [ApiController]
    [Route("api/workers")]
    public class WorkerController : Controller
    {

        [Route("devices")]
        [HttpGet]
        public string GetDevices()
        {

            return "Devices";
        }
    }
}
