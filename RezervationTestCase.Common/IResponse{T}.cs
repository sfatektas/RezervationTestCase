using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Common
{
    public interface IResponse<T> : IResponse
    {
        public T Data { get; set; }

        public List<ValidationError> ValidationErrors { get; set; }
    }

    public class ValidationError
    {
        public ValidationError(string errorType, string errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string ErrorType { get; set; }

        public string ErrorMessage { get; set; }
    }
}
