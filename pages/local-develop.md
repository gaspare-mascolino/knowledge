# Local development configuration  

## Maven configuration  
The DevOps pipeline make use of the DevOps Nexus repository in order to store and retrieve maven artifacts.
  
In order to be able to have the same behaviour, the following nodes should be added to the local maven settings.xml:  

```
<server>
	<id>nexus3-prod-group</id>
	<username>guest</username>
	<password>nexus</password>
</server>

<mirror>
	<id>nexus3-prod-group</id>
	<mirrorOf>nexus3-prod-group</mirrorOf>
	<url>https://nexus3.nex.intranet.unicreditgroup.eu/repository/maven-group/</url>
</mirror>

<repository>
	<id>nexus3-prod-group</id>
	<url>https://nexus3.nex.intranet.unicreditgroup.eu/repository/maven-group/</url>
</repository> 
```

## NPM configuration  
The DevOps pipeline make use of the DevOps Nexus repository in order to store and retrieve npm artifacts.
  
In order to be able to have the same behaviour, the following configuration should be added to your local [.npmrc file](https://docs.npmjs.com/cli/v6/configuring-npm/npmrc/):

```
cafile=<path to certificate file>  _ex . /etc/ssl/certs/ca-certificates.crt_
always-auth=true
_auth="Z3Vlc3Q6bmV4dXM="
registry=https://nexus3.nex.intranet.unicreditgroup.eu/repository/npm-group/
```