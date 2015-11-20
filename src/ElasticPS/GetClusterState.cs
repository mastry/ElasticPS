using ElasticPS.Util;
using System.Net.Http;
using System.Management.Automation;
using System.Web.Script.Serialization;

namespace ElasticPS
{
    [Cmdlet(VerbsCommon.Get, "EsClusterState")]
    public class GetClusterState : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Uri { get; set; }

        [Parameter]
        public SwitchParameter Local { get; set; }

        protected override void BeginProcessing()
        {
            var request = new EsRequest(HttpMethod.Get, Uri, $"_cluster/state?local={Local.ToString().ToLower()}");

            var response = request.Send();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                WriteDebug("!!!");
                var result = ser.Deserialize<EsClusterStateResponse>(response.Content);
                WriteObject(result);
            }
            else
            {
                WriteObject(new EsException(response.Content));
            }
        }
    }
}
