
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

        public class Metadata
        {
            public string cluster_uuid { get; set; }
            public object templates { get; set; }
            public Dictionary<string,IndexMetadata> indices { get; set; }
        }

        public class IndexMetadata
        {
            public string state { get; set; }
            public Dictionary<string, IndexMetatdataSettings> settings { get; set; }
            public object mappings { get; set; }
            public string[] aliases { get; set; }
        }

        public class IndexMetatdataSettings
        {
            public string creation_date { get; set; }
            public string refresh_interval { get; set; }
            public string number_of_shards { get; set; }
            public int number_of_replicas { get; set; }
            public string uuid { get; set; }
            public IndexMetatdataSettingsVersion version { get; set; }
        }

        public class IndexMetatdataSettingsVersion
        {
            public int created { get; set; }
        }
        
        public string cluster_name { get; set; }
        public int version { get; set; }
        public string state_uuid { get; set; }
        public string master_node { get; set; }
        public Dictionary<string,EsClusterStateResponse.Node> nodes { get; set; }
        public Metadata metadata{ get; set; }
        public object routing_table { get; set; }
        public object routing_nodes { get; set; }

        //TODO: serializable types for routing_table, routing_nodes
    }
}