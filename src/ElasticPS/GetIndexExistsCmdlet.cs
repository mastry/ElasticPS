using ElasticPS.Util;
using System.Net.Http;
using System;
using System.Management.Automation;
using System.Net;

namespace ElasticPS
{
    [Cmdlet(VerbsCommon.Get, "EsIndexExists")]
    public class GetIndexExistsCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0)]
        public string Name { get; set; } = string.Empty;

        [Parameter(Mandatory = true, Position = 1)]
        public string Uri { get; set; }

        protected override void BeginProcessing()
        {
            var request = new EsRequest(HttpMethod.Head, Uri, Name);

            var response = request.Send();
            WriteObject(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
