using ApiClient.Abstracts;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ApiClient
{
    //Class to handle communication with the lights
    public class LightClient : ClientBase
    {
        public LightClient(string host) : base(host)
        { }

        public override async Task<object> GetJobs()
        {
            return await MakeRequest("/api/settings/jobs", null, "GET");
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
}