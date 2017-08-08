using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace Finanse_aspnet_mvc.Models.Accounts {
    [Table("Accounts")]
    public abstract class AccountBase {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorKey { get; set; }

        private string _lastColorKey;
        private string _color;
        public string Color {
            get {
                if (_lastColorKey == ColorKey && !string.IsNullOrEmpty(_color))
                    return _color;
                return _color = ConfigurationManager.AppSettings[_lastColorKey = ColorKey];
            }
        }
    }
}