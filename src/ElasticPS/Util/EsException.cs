using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticPS.Util
{
    public class EsException : Exception
    {
        private readonly EsErrorResponse _esError;

        public EsException(string content) : base(content)
        {
            this._esError = EsErrorResponse.Parse(content);
        }

        public System.Net.HttpStatusCode StatusCode { get { return _esError.status; } }
        public string Reason { get { return _esError.error.reason; } }
        public string Type { get { return _esError.error.type; } }

        public override string ToString()
        {
            return $"{Type}: {Reason}";
        }
    }
}