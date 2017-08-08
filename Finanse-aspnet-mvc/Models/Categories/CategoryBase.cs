using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace Finanse_aspnet_mvc.Models.Categories {
    [Table("Categories")]
    public abstract class CategoryBase: ICategoryBase {
        public int Id { get; set; }

        [StringLength(32)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string ColorKey { get; set; }
        public string IconKey { get; set; }
        public bool VisibleInIncomes { get; set; }
        public bool VisibleInExpenses { get; set; }
        public bool CantDelete { get; set; } = false;
        [Required]
        public string UserId { get; set; }

        private string _lastColorKey;
        private string _color;
        public string Color {
            get {
                if (_lastColorKey == ColorKey && !string.IsNullOrEmpty(_color))
                    return _color;
                return _color = ConfigurationManager.AppSettings[_lastColorKey = ColorKey];
            }
        }

        private string _lastIconKey;
        private string _icon;
        public string Icon {
            get {
                if (_lastIconKey == IconKey && !string.IsNullOrEmpty(_icon))
                    return _icon;
                return _icon = ConfigurationManager.AppSettings[_lastIconKey = IconKey];
            }
        }
    }
}