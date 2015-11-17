using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ElasticPS.Util
{
    public class EsErrorRootCause
    {
        public string type { get; set; }
        public string reason { get; set; }
    }

    public class EsError
    {
        public EsErrorRootCause[] root_cause { get; set; }
        public string type { get; set; }
        public string reason { get; set; }
    }

    public class EsErrorResponse
    {
        public EsError error { get; set; }
        public HttpStatusCode status { get; set; }

        public static EsErrorResponse Parse(string content)
        {
            var ser = new JavaScriptSerializer();
            var error = ser.Deserialize<EsErrorResponse>(content);
            return error;
        }
    }
}