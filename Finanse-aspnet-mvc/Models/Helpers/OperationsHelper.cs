using System.Collections.Generic;
using Finanse_aspnet_mvc.Models.Operations;
using Newtonsoft.Json;

namespace Finanse_aspnet_mvc.Models.Helpers {
    public class OperationsHelper {
        public static string ToJsonString(IEnumerable<Operation> operations) {
            var jsSettings = new JsonSerializerSettings {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(operations, Formatting.None, jsSettings);
        }
    }
}