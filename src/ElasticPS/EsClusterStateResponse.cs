
using System.Collections.Generic;

namespace ElasticPS
{
    public class EsClusterStateResponse
    {
        public class Node
        {
            public string name { get; set; }
            public string transport_address { get; set; }
            public object attributes { get; set; }
        }

        public string cluster_name { get; set; }
        public int version { get; set; }
        public string state_uuid { get; set; }
        public string master_node { get; set; }
        public Dictionary<string,EsClusterStateResponse.Node> nodes { get; set; }
        public object metadata{ get; set; }
        public object routing_table { get; set; }
        public object routing_nodes { get; set; }

        //TODO: serializable types for metadata, routing_table, routing_nodes
    }
}