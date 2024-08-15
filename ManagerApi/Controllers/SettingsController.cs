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
            var clients = Settings.Clients;
            if (clients == null || clients.Count == 0 || clients[0].ID == null) {
                Settings.Initiate();
            }
            return Settings.Clients;
        }
    }
}
