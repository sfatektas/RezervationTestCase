using RezervationTestCase.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Common
{
    public class Response<T> : Response , IResponse<T>
    {
        public T Data { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }

        public Response(T data, ResponseType responseType) : base(responseType)
        {
            Data = data;
        }

        public Response(ResponseType responseType, string message , T data) : base(responseType, message)
        {
            Data = data;
        }

        public Response(ResponseType responseType, string message, T data , List<ValidationError> validationErrors) : this(responseType,message,data)
        {
            Data = data;
            ValidationErrors = validationErrors;

        }


    }
}
