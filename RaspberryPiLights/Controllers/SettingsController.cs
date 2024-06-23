using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Newtonsoft.Json;

namespace RaspberryPiLights.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class SettingsController : Controller
    {

        [Route("")]
        [HttpGet]
        public string GetSettings()
        {
            return JsonConvert.SerializeObject(Config.Settings.GetSettings());
        }

        [Route("jobs")]
        [HttpGet]
        public string Get()
        {
            try
            {   
                //Build the routes progromattically
                //we should split them into run once and continuous jobs
                List<Type> runOnce = new List<Type>();
                List<Type> continuous = new List<Type>();

                //Get all types in assembly
                var baseType = typeof(LightJobs.Abstracts.SingleRunLightJob);
                var assembly = Assembly.GetAssembly(baseType);
                runOnce.AddRange(assembly.GetTypes().Where(t => t.IsSubclassOf(baseType)));

                baseType = typeof(LightJobs.Abstracts.ContinuousLightJob);
                assembly = Assembly.GetAssembly(baseType);
                continuous.AddRange(assembly.GetTypes().Where(t => t.IsSubclassOf(baseType)));



                //Convert to json
                var data = new
                {
                    RunOnceJobs = runOnce.Select(type => Activator.CreateInstance(type)).ToList(),
                    ContinuousJobs = continuous.Select(type => Activator.CreateInstance(type)).ToList()
                };
                return JsonConvert.SerializeObject(data);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                HttpContext.Response.ContentType = "application/json";
                return JsonConvert.SerializeObject(ex);
            }
        }
    }
}
