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

                List<WorkerSetting> connections = JsonConvert.DeserializeObject<List<WorkerSetting>>(settingsObject.Property("LightWorkers").Value.ToString());

                Clients = new List<ApiClient.Abstracts.ClientBase>();
                //Get the settings for all the LightClients
                foreach (WorkerSetting connect in connections)
                {
                    ClientBase client = new LightClient(connect.Host);
                    try
                    {
                        ApiClientSettings settings = await client.GetSettings();
                        client.ID = settings.AppId;
                    }
                    catch (Exception ex) {
                    }
                    finally
                    {
                        client.Name = connect.Name;
                        Clients.Add(client);
                    }
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

    public class WorkerSetting
    {
        public string Host { get; set; }
        public string Name { get; set; }
    }
}
