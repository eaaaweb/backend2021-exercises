using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson11.Infrastructure
{

    public class FutureDateAttribute : Attribute, IModelValidator
    {
        public bool IsRequired => true;
        public string ErrorMessage { get; set; } = "Please enter a date in the future";

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            DateTime? value = context.Model as DateTime?;

            if (!value.HasValue || value <= DateTime.Now)
            {
                return new List<ModelValidationResult> {
                        new ModelValidationResult("", ErrorMessage)
                    };
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }

}