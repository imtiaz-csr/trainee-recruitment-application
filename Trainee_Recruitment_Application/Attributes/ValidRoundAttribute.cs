using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trainee_Recruitment_Application.Attributes
{
    public class ValidRoundAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "round"
            };
            yield return rule;
        }

        public override bool IsValid(object value)
        {
            if (value.ToString() == "R45")
                return true;
            else return false;


        }
    }
}