using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace SqlIntegrationUI.UIUtilities;
public class TimeSpanModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask; // No value provided
        }

        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

        var value = valueProviderResult.FirstValue;

        // Handle parsing TimeSpan values
        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask; // No value entered
        }

        if (TimeSpan.TryParse(value, out var timeSpan))
        {
            bindingContext.Result = ModelBindingResult.Success(timeSpan);
        }
        else
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid TimeSpan format.");
        }

        return Task.CompletedTask;
    }
}