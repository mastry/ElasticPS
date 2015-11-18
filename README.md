#ElasticPS
A [PowerShell](https://technet.microsoft.com/en-us/library/bb978526.aspx) module for managing [Elasticsearch](https://www.elastic.co/) clusters.

##System Requirements
* .Net Framework 4.6+
* PowerShell version 4+
* Elasticsearch 2+

##Build
ElasticPS was built with Visual Studio 2015 Community (it should build fine in other editions of Visual Studio). If you plan to use ElasticPS in production, don't forget to change the build configuration to `Release`.

##Install
ElasticPS is a binary PowerShell module (`ElasticPS.dll`). Please refer to the [PowerShell documentation](https://technet.microsoft.com/en-us/library/dd878350%28v=vs.85%29.aspx) to determine the best installation method for your environment.

The samples below assume that `ElasticPS.dll` is in the current folder, and you have the following import statement:
```
Import-Module ElasticPS.dll
```

If you have installed the module in one of the standard locations according to the PowerShell documentation, then you will just need:
```
Import-Module ElasticPS
``` 
Notice that `.dll` was dropped.

##Common Usage Examples
This is very early in the devleopment process, so expect everything to change. Frequently.

###Checking Cluster Health
```
Get-EsClusterHealth http://1.2.3.4:9200

cluster_name                     : logging
status                           : green
number_of_nodes                  : 5
number_of_data_nodes             : 5
active_primary_shards            : 0
active_shards                    : 0
relocating_shards                : 0
unassigned_shards                : 0
delayed_unassigned_shards        : 0
number_of_pending_tasks          : 0
number_of_in_flight_fetch        : 0
task_max_waiting_in_queue_millis : 0
active_shards_percent_as_number  : 100
```
Each of the above cluster health metrics is a property on the returned object, so if you just want to the `status` (for example) you can access that property directly:
```PowerShell
# Replace the IP address with one from your own cluster
$health = Get-EsClusterHealth http://1.2.3.4:9200

switch( $health.status )
{
    "green" 
    {
        Write-Host "All is well ;)"
    }
    
    "yellow" 
    {
        Write-Host "We are not doing well folks...." 
    }

    "red" 
    {
        Write-Host "Uh oh...." 
    }

    default
    {
        Write-Host "Apparently there has been a glitch in the matrix. Again." 
    }
}
``` 