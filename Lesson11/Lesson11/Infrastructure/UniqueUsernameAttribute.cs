using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson11.Infrastructure
{


    public class UniqueUsernameAttribute : Attribute, IModelValidator
    {

        public bool IsRequired => true;
        public string ErrorMessage { get; set; } = "Please enter a date in the future";

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            string value = context.Model as string;

            if (!Users.UsernameIsUnique(value))
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