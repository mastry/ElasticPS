using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ElasticPS.Util
{
    class EsRequest
    {
        private readonly WebRequest _request;

        public EsRequest(string verb, params string[] requestUri)
        {
            var fullUri = requestUri.Aggregate((s1, s2) => s1.EndsWith("/") ? $"{s1}{s2}" : $"{s1}/{s2}" );
            _request = WebRequest.Create(fullUri);
            _request.Method = verb;
        }

        /// <summary>
        /// Sends a request to an Elasticsearch cluster.
        /// </summary>
        /// <param name="_request">The <seealso cref="WebRequest"/> object to use for the request.</param>
        /// <param name="content">The content of the request (typically this is JSON).</param>
        /// <returns></returns>
        public EsResponse Send(string content = "")
        {
            _request.ContentType = "application/json";
            _request.ContentLength = Encoding.UTF8.GetByteCount(content);

            //-- Set the request content
            if (_request.ContentLength > 0)
            {
                using (var stream = _request.GetRequestStream())
                {
                    stream.Write(Encoding.UTF8.GetBytes(content), 0, (int)_request.ContentLength);
                }
            }

            //-- Send the request and capture the response.
            HttpWebResponse response = null;
            try
            {
                response = _request.GetResponse() as HttpWebResponse;
            }
            catch (System.Net.WebException wex)
            {
                // WebRequest will (annoyingly) throw an exception if the return code indicates an error.
                // So we catch it and pull the response.
                response = wex.Response as HttpWebResponse;
            }

            //-- Return the response stream and response code as a JsonResponse
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return new EsResponse(response.StatusCode, json);
                }
            }
        }
    }
}
