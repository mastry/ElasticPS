using ElasticPS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ElasticPS
{
    [Cmdlet(VerbsCommon.Get, "EsClusterHealth")]
    public class GetClusterHealth : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Uri { get; set; }

        protected override void BeginProcessing()
        {
            if (!Uri.EndsWith("/"))
                Uri += "/";

            var request = new EsRequest("GET", $"{Uri}_cluster/health");

            var response = request.Send();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var result = ser.Deserialize<EsCluserHealthResponse>(response.Content);
                WriteObject(result);
            }
            else
            {
                //TODO - Need an EsError type
                WriteObject(response);
            }
        }
    }
}
