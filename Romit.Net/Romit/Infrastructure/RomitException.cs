using System;
using System.Net;

namespace Romit
{
    [Serializable]
    public class RomitException : ApplicationException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public RomitError RomitError { get; set; }

        public RomitException()
        {
        }

        public RomitException(HttpStatusCode httpStatusCode, RomitError romitError, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            RomitError = romitError;
        }
    }
}
