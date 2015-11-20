using ElasticPS.Util;
using System.Net.Http;
using System.Management.Automation;
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
            var request = new EsRequest(HttpMethod.Get, Uri, "_cluster/health");

            var response = request.Send<EsCluserHealthResponse>();
            WriteObject(response);
        }
    }
}
