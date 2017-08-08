using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Finanse_aspnet_mvc.Models.Helpers {
    public class AppSettingsHelper {
        public static string GetColor(string colorKey) {
            return ConfigurationManager.AppSettings[colorKey];
        }

        public static IEnumerable<KeyValuePair<string, string>> GetColors() {
            var colors = ConfigurationManager
                .AppSettings
                .AllKeys
                .Where(k => k.StartsWith("color_key"));

            var pairs = colors
                .Select(k => new KeyValuePair<string, string>
                    (k, ConfigurationManager.AppSettings[k]));

            return pairs;
        }

        public static string GetIcon(string iconKey) {
            return ConfigurationManager.AppSettings[iconKey];
        }
    }
}