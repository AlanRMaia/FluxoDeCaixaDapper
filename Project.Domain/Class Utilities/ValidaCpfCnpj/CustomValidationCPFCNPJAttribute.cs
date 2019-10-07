using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using Project.Domain.Class_Utilities.ValidaCpfCnpj;

namespace Project.Domain.Class_Utilities.ValidaCpfCnpj
{
	public class CustomValidationCPFCNPJAttribute : ValidationAttribute,  IClientValidatable
	{
		public CustomValidationCPFCNPJAttribute()
		{

		}

		public override bool IsValid(object value)
		{
			if (value == null || string.IsNullOrEmpty(value.ToString()))
				return true;

			bool valido = CpfCnpjUtils.IsValid(value.ToString());
			return valido;
		}

		
		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
			ModelMetadata metadata, ControllerContext context)
		{
			yield return new ModelClientValidationRule
			{
				ErrorMessage = this.FormatErrorMessage(null),
				ValidationType = "customvalidationcpfcnpj"
			};

		}

	}
}
