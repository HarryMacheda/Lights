using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace ApiClient.Abstracts
{
    public abstract class ClientBase
    {
        private string _host;

        public ClientBase(string host)
        {
            _host = host;
        }
        public string ID { get; set; }

        public abstract Task<object> GetJobs();
        public abstract Task<ApiClientSettings> GetSettings();
        public abstract Task<object> GetCurrentJob();

        public abstract Task<object> StopCurrentJob();
        public abstract Task<object> StartJob(string job, object[] parameters);

        internal async Task<object> MakeRequest(string endpoint, object[] parameters, string method)
        {
            HttpClient client = new HttpClient();


            HttpContent content = null;
            var json = JsonConvert.SerializeObject(parameters);
            content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            switch (method)
            {
                case "GET":
                    response = await client.GetAsync(_host + endpoint);
                    break;
                case "POST":
                    response = await client.PostAsync(_host + endpoint, content);
                    break;
                default: throw new Exception("Method not valid for request: " + method);
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

    }
}
