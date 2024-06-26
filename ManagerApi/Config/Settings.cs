using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ApiClient;
using ApiClient.Abstracts;

namespace ManagerApi.Config
{
    public class Settings
    {

        public static List<ApiClient.Abstracts.ClientBase> Clients { get; set;}


        public static async void Initiate()
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/config/config.json"))
            {
                string json = r.ReadToEnd();
                var settingsObject = JsonConvert.DeserializeObject<JObject>(json);

                List<string> connections = JsonConvert.DeserializeObject<List<string>>(settingsObject.Property("LightWorkers").Value.ToString());

                Clients = new List<ApiClient.Abstracts.ClientBase>();
                //Get the settings for all the LightClients
                foreach (string connect in connections)
                {
                    ClientBase client = new LightClient(connect);
                    ApiClientSettings settings = await client.GetSettings();
                    client.ID = settings.AppId;
                    Clients.Add(client);
                }
            }
        }

        public static object GetSettings()
        {
            return new
            {
                Clients = Clients
            };
        }



    }
}
