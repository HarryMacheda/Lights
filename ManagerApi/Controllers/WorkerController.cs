using Microsoft.AspNetCore.Mvc;
using ManagerApi.Config;
using Newtonsoft.Json;
using ApiClient.Abstracts;
using System.Security.Cryptography.Xml;
using System.Reflection.Metadata.Ecma335;

namespace ManagerApi.Controllers
{
    [ApiController]
    [Route("api/worker")]
    public class WorkerController : Controller
    {

        private ClientBase CheckWorkerID(string workerId)
        {
            if (Settings.Clients == null || Settings.Clients.Count == 0)
            {
                throw new Exception("No Workers are connected");
            }

            ClientBase client = Settings.Clients.FirstOrDefault((x) => x.ID == workerId);

            if (client == null || client.ID != workerId)
            {
                throw new Exception("Worker for give id " + workerId + " does not exist");
            }
            return client;
        }


        [Route("routes/{workerId}")]
        [HttpGet]
        public async Task<object> GetDevices(string workerId)
        {
            ClientBase client = CheckWorkerID(workerId);

            var jobs = await client.GetJobs();

            return jobs;
        }

        [Route("currentjob/{workerId}")]
        [HttpGet]
        public async Task<object> GetCurrentJob(string workerId)
        {

            ClientBase client = CheckWorkerID(workerId);

            var job = await client.GetCurrentJob();

            return job;
        }


        [Route("stopJob/{workerId}")]
        [HttpPost]
        public async Task<object> StopCurrentJob(string workerId)
        {

            ClientBase client = CheckWorkerID(workerId);

            var job = await client.StopCurrentJob();

            return job;
        }


        [Route("startjob/{workerId}/{job}")]
        [HttpPost]
        public async Task<object> GetCurrentJob(string workerId, string job, params object[] args)
        {

            ClientBase client = CheckWorkerID(workerId);

            var response = await client.StartJob(job, args);

            return response;
        }

    }
}
