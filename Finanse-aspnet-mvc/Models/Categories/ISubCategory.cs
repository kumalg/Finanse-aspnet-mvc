using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanse_aspnet_mvc.Models.Categories {
    interface ISubCategory : ICategoryBase {
        int ParentCategoryId { get; set; }
    }
}
