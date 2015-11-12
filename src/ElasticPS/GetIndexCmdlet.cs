using ElasticPS.Util;
using System;
using System.Management.Automation;

namespace ElasticPS
{
    [Cmdlet(VerbsCommon.Get, "EsIndex")]
    public class GetIndexCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0)]
        public string Name { get; set; } = string.Empty;

        [Parameter(Mandatory = true, Position = 1)]
        public string Uri { get; set; }

        protected override void BeginProcessing()
        {
            if (!Uri.EndsWith("/"))
                Uri += "/";

            var request = new EsRequest("GET", Uri, Name);

            var response = request.Send();
            WriteObject(response);
        }
    }
}
