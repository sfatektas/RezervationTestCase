using RezervationTestCase.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Common
{
    public class Response : IResponse
    {
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
        public Response(ResponseType responseType, string message) : this(responseType)
        {
            ResponseType = responseType;
            Message = message;
        }

        public ResponseType ResponseType { get; set; }

        public string Message { get; set; }
    }
}
