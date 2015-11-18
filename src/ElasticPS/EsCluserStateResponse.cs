
namespace ElasticPS
{
    public class EsCluserStateResponse
    {
        public string cluster_name { get; set; }
        public int version { get; set; }
        public string state_uuid { get; set; }
        public string master_node { get; set; }
        public object nodes { get; set; }
        public object metadata{ get; set; }
        public object routing_table { get; set; }
        public object routing_nodes { get; set; }

        //TODO: serializable types for nodes, metadata, routing_table, routing_nodes
    }
}