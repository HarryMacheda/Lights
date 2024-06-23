using LightJobs.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace RaspberryPiLights.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : Controller
    {

        [Route("currentjob")]
        [HttpGet]
        public string Get()
        {
            try
            {
                return JsonConvert.SerializeObject(LightJobManager.CurrentJob);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                HttpContext.Response.ContentType = "application/json";
                return JsonConvert.SerializeObject(ex);
            }
        }

        [Route("stop")]
        [HttpPost]
        public async Task<string> Stop()
        {
            try {
                if (await LightJobManager.StopCurrentJob())
                {
                    return JsonConvert.SerializeObject(LightJobManager.CurrentJob);
                }

                throw new Exception(JsonConvert.SerializeObject(LightJobManager.CurrentJob));
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                HttpContext.Response.ContentType = "application/json";
                return JsonConvert.SerializeObject(ex);
            }
        }

        [Route("startjob")]
        [HttpPost]
        public async Task<string> StartJob(string job, params object[] args)
        {
            Type? dataType = Type.GetType(job);
            LightJob jobClass = (LightJob)Activator.CreateInstance(dataType);
            jobClass.Initiate(args);

            await LightJobManager.QueueJob(jobClass);
            Task.Run(() => { LightJobManager.StartJob(); });

            return JsonConvert.SerializeObject(LightJobManager.CurrentJob);
        }
    }
}
