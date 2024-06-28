using Microsoft.AspNetCore.Mvc;
using ManagerApi.Config;
using Newtonsoft.Json;

namespace ManagerApi.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class SettingsController : Controller
    {

        [Route("devices")]
        [HttpGet]
        public object GetDevices()
        {

            return Settings.Clients;
        }
    }
}
