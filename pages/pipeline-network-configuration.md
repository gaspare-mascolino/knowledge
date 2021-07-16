
# Pipeline network configuration ...  

## For Docker builds  

### Docker registries  
Only the registries specified in the following whitelist are accessible within Jenkins Pipeline, and all other registries are denied access by default.  
If the registry you'd like to use is not in the whitelist, Security and DevOps teams must be engaged well in advance so that they can approve and request the necessary firewall/proxy configurations.   
If needed a login must be provided in order to configure the pipelines.

**Given that this process is not directly in our hands, we expect the request to be processed in 2 weeks.**  

##### Docker registries - Whitelist
* dockerhub  

!!! danger
    The use of dockerhub must be limited and avoided if possible. The current plan supports 100 pull per 6 hours for overall the applications. Please in case of need create a base image to push in to the internal Nexus through the pipeline.
* registry.redhat.io  

#### Distro specific package repositories   
Only the repositories specified in the following whitelist are accessible within Jenkins Pipeline, and all other repositories are denied access by default.  
If the repository you'd like to use is not in the whitelist, DevOps teams must be engaged well in advance so that they can request the necessary firewall/proxy configurations.  
   
**Given that this process is not directly in our hands, we expect the request to be processed in 2 weeks.**  

##### Distro package repositories - Whitelist  
_Work in progress_  