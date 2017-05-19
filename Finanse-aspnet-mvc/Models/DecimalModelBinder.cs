using System;
using System.Globalization;
using System.Web.Mvc;

namespace Finanse_aspnet_mvc.Models {
    public class DecimalModelBinder : DefaultModelBinder {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            return Decimal.Parse(valueProviderResult.AttemptedValue, CultureInfo.GetCultureInfo("en-US")); //null ? base.BindModel(controllerContext, bindingContext) : Convert.ToDecimal(valueProviderResult.AttemptedValue);
            // of course replace with your custom conversion logic
        }
    }
}