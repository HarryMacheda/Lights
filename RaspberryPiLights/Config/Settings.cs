using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RaspberryPiLights.Config
{
    public class Settings
    {
        private static string _appId;
        
        public static string AppId { get { return _appId; } }


        public static void Initiate()
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/config/config.json"))
            {
                string json = r.ReadToEnd();
                var settingsObject =  JsonConvert.DeserializeObject<JObject>(json);

                _appId = settingsObject.Property("AppId").Value.ToString();

            }
        }

        public static object GetSettings()
        {
            return new
            {
                AppId = _appId
            };
        }
    }
}
