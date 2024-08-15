using ApiClient.Abstracts;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LightsFramework.JobParameters;

namespace ApiClient
{
    //Class to handle communication with the lights
    public class LightClient : ClientBase
    {
        public LightClient(string host) : base(host)
        { }

        public override async Task<object> GetJobs()
        {
            object response = await MakeRequest("/api/settings/jobs", null, "GET");
            JObject responseObject = JObject.Parse(response.ToString());

            JArray RunOnceJobs = (JArray)responseObject.GetValue("RunOnceJobs");
            JArray ContinuousJobs = (JArray)responseObject.GetValue("ContinuousJobs");


            return new
            {
                RunOnceJobs = RunOnceJobs.Select(jValue => jValue.ToObject<JobReturn>()).ToList(),
                ContinuousJobs = ContinuousJobs.Select(jValue => jValue.ToObject<JobReturn>()).ToList()
            };
        }

        public override async Task<ApiClientSettings> GetSettings()
        {
            object response = await MakeRequest("/api/settings", null, "GET");
            return JsonConvert.DeserializeObject<ApiClientSettings>(response.ToString());
        }
        public override async Task<object> GetCurrentJob()
        {
            return await MakeRequest("/api/jobs/currentjob", null, "GET");
        }

        public override async Task<object> StopCurrentJob()
        {
            return await MakeRequest("/api/jobs/stop", null, "POST");
        }
        public override async Task<object> StartJob(string job, object[] parameters)
        {
            return await MakeRequest("/api/jobs/startjob?job=" + job, parameters, "POST");
        }
    }


    public class JobReturn
    {
        public string Job { get; set; }
        public ApiArgument[] Arguments { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }

        public JobReturn() { }
    }

}