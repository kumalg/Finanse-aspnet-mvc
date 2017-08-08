using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finanse_aspnet_mvc.Models.Categories {
    public interface ICategoryBase {
        int Id { get; set; }
        string Name { get; set; }
        string ColorKey { get; set; }
        string IconKey { get; set; }
        bool VisibleInIncomes { get; set; }
        bool VisibleInExpenses { get; set; }
        bool CantDelete { get; set; }
    }
}