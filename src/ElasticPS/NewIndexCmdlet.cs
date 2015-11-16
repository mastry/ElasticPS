using ElasticPS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace ElasticPS
{
    [Cmdlet(VerbsCommon.New, "EsIndex")]
    public class NewIndexCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0)]
        public string Name { get; set; } = string.Empty;

        [Parameter(Mandatory = true, Position = 1)]
        public string Uri { get; set; }

        protected override void BeginProcessing()
        {
            if (!Uri.EndsWith("/"))
                Uri += "/";

            var request = new EsRequest("PUT", Uri, Name);

            var response = request.Send();
            WriteObject(response);
        }
    }
}
