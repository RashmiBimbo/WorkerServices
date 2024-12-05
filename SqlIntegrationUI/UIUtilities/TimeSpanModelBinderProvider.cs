using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace SqlIntegrationUI.UIUtilities;

public class TimeSpanModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(TimeSpan))
        {
            return new BinderTypeModelBinder(typeof(TimeSpanModelBinder));
        }

        return null;
    }
}
