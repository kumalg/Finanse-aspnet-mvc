using Newtonsoft.Json;

namespace Finanse_aspnet_mvc.Models.Helpers {
    public class JsonHelper {
        public static string ToJsonString(object model) {
            var jsSettings = new JsonSerializerSettings {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(model, Formatting.None, jsSettings);
        }
    }
}