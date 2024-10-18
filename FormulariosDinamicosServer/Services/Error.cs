using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormulariosDinamicosServer.Services
{
    public class Error
    {
        public string message { get; private set; }
        public int statusCode { get; private set; }
        public Error(string Message, int StatusCode)
        {
            message = Message;
            statusCode = StatusCode;
        }
    }
}