# Application configuration
The application can be configured by placing a file named **_application.yaml_** 
in devops folder starting from the root of the project.

## Cluster configuration
By default a cluster is already defined and used for the deploy_ci stage.  
If the application requires to be installed on other k8s cluster,you can add it in the application.yaml configuration in order to be used in the pipeline :

```yaml
kubernetesClusters:
  my-cluster:
    url: "https://my-cluster-address:6443"
    credentialsId: "custom-kube-credentials" #Should be defined in Jenkins Platform
    namespace: "custom-namespace"
```

### Cluster credentials
In order to be able to install to the new cluster the user tujxpdepp01 should be granted as namespace admin.
In case of GKE the service account should be added in Jenkins as   
 **Google Service Account from private Key**

## Tool version
By default all the tools used in the pipeline are defined by the DevOps Team.  
In order to let you the possibility to use different tool version,
you have to ask preventively to the devops team to support the tool version by writing to 
<a href="mailto:usdevtecsupport@mailasp.internal">usdevtecsupport{at}mailasp.internal</a> .
A new docker image will be created and you'll be able to configure it 
in your application.yaml as follow:

```yaml
podSettings:
  mavenImage:
    name: 'maven-jenkins'
    version: '3.6.3-jdk-11-uid'
```  

### Following the updated list of the already supported versions:

#### Maven
```yaml
podSettings:
  mavenImage:
    name: 'maven-jenkins'
    version: one of the followings
```
 * 3.6.3-jdk-11-uid  

 * 3.3.9-jdk-8-uid  

 * ibm8-sdk-uid

#### NodeJS
```yaml
podSettings:
  nodeImage:
    name: 'node-jenkins'
    version: one of the followings
```
 * 8.10.0-uid  

 * 10.16.0-uid  

 * 10.23.0-uid  

 * 10.20.1-uid  

 * 12.18.2-uid  

 * 12.16.3-uid  

 * 13.14.0-uid  

 * 14.16.0-uid

#### Helm
```yaml
podSettings:
  helmImage:
    name: 'helm-jenkins'
    version: one of the followings
```
 * 3.2.0-uid  

 * 3.1.1-uid  

#### Liquibase
```yaml
podSettings:
  liquibaseImage:
    name: 'liquibase-jenkins'
    version: one of the followings
```
 * 3.8.8-uid
 
 * 4.2.0-uid

#### GitCrypt
```yaml
podSettings:
  gitCryptImage:
    name: 'git-crypt'
    version: one of the followings
```
 * 1.0.0-uid  

 * 1.0.1-uid    