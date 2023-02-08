using FluentValidation.Results;
using RezervationTestCase.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Extnesions
{
    public static class ValidationExtension
    {
        public  static List<ValidationError> GetValidationErrors(this ValidationResult result)
        {
            var list = new List<ValidationError>();
            foreach (var error in result.Errors)
            {
                list.Add(new(error.ErrorCode, error.ErrorMessage));
            }
            return list;
        }
    }
}
