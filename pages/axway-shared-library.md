# Unicredit DevOps Shared Library ApiGateway

## Introdution

This shared library is designed to guide build & deploy process of the projects based on Axway ApiGateway.

It consists of Jenkinsfile that is always fixed across all the project and configuration files in yaml format. These files should be placed in devops folder in the root of the project. Normally we have one file for the environment as test.yaml, qa.yaml and prod.yaml

## Jenkinsfile

Inside the Jenkinsfile we always specify 3 properties:

- target environment choosen from a list: TEST (default), QA, PROD
in deploy on QA or PROD you can specify additional properties
- Artifact version to be deployed in QA or PROD - leave empty to deploy the last artifact that passed succesfully TEST pipeline. In other case you should specify the version that is a short commit among the one found and consultable on  [Nexus3](https://nexus3.internal.unicreditgroup.eu)
- Custom api.env - leave empty in case you want to use api_<branch_name\>.env file depending on the built branch (default). Provide a name of the file to be used, the file should be placed in -ENVIRONMENTS repository accordingly in QA or PROD folder.

Jenkinsfile content, that should be **always** as following:

``` groovy
@Library('unicredit-devops-shared-axway') _

properties(
  [
    parameters(
      [
        choice(description: 'Pipeline target environment', choices: ['TEST','QA','PROD'], name: 'envLevel'),
        string(description: 'Artifact version to be deployed in QA or PROD - it should be a git short commit - version of the artifact in Nexus', name: 'version', defaultValue: ''),
        string(description: 'Custom api.env file name (otherwise it will be based upon application branch name)', name: 'apiEnvFile', defaultValue: '')
      ]
    )
  ]
)

stdPipeline(params.envLevel, params.envRepo, params.version, params.apiEnvFile)
```

## Configuration files

The config files are placed in **devops** folder in the root of the project. Normally we have one file for the environment as:

- all.yaml,
- test.yaml,
- qa.yaml,
- prod.yaml  

In the all.yaml we specify the webhook link generated from Mattermost (≡ -> Integrations -> incoming Webhooks). In the test.yaml we specify build details and deploy details in qa.yaml and prod.yaml we specify only details regarding deploy, because during these steps the pipeline is not building the artifact anymore.

QA and Prod deploy are triggered always manually by design due to optional manual step of Environment properties update in -ENVIRONMENTS repository.

Configuration parameters:

| Level | Parameter | Description | Possible values |
| --- | --- | --- | --- |
|Mandatory|SUBMODULE_COMMON|Name of the common submodule in your project| |
|Mandatory|SUBMODULE_API|List of the api submodules in your project| |
|Mandatory|SUBMODULE_SETTINGS|Name of the settings submodule in your project| |
|Mandatory|AXWAY_DEPLOY_TARGET|Project deploy target on the server| |
|Mandatory|GIT_TEST_REPO|Reporitory name in the same BitBucket Project that contains IT tests|'xxx-it-test' that indicates master branch or 'xxx-it-test@myBranch' with explicit branch to use|
|Optional|APIGATEWAY_VERSION|Version of API Gateway that is used to build and deploy; Check your server version|'7.5.3_SP10' (default), '7.5.3_SP13', '7.7.20200930' also named as '7.7', '7.7.20201130'|
|Optional|channel|mattermost channel to send pipeline communications| |
|Optional|AXWAY_SERVER|deployment server|'usclutl6fya.cloud.unicreditgroup.eu' (default test); 'uscluql6fw9.cloud.unicreditgroup.eu' (default qa); '10.248.210.250' (default prod)|
|Optional|AXWAY_SERVER_PORT|deployment port|8090 (default for all environments)|

Examples of each config file as below:

- all.yaml

``` yaml
args:
  mmEndpoint: "https://mattermost.devops.internal.unicreditgroup.eu/hooks/bhgby1nnuf8qicfs3bawxidozo"
  channel: '#jenkins-notifications'
```

- test.yaml

``` yaml
args:
  SUBMODULE_COMMON: 'xxx-sandbox-application-common'
  SUBMODULE_API: 
    - 'xxx-sandbox-application-api-1'
    - 'xxx-sandbox-application-api-2'
  SUBMODULE_SETTINGS: 'xxx-sandbox-application-settings'
  AXWAY_DEPLOY_TARGET: 'TEST_application'
  APIGATEWAY_VERSION: '7.5.3_SP13'
  GIT_TEST_REPO: 'xxx-sandbox-it-test'
  channel: '#my-onboard'
  AXWAY_SERVER: 'usclutl6fya.cloud.unicreditgroup.eu'
  AXWAY_SERVER_PORT: 8090
```

- qa.yaml

``` yaml
args:
  AXWAY_DEPLOY_TARGET: 'QA_application'  
  APIGATEWAY_VERSION: '7.5.3_SP13'
  GIT_TEST_REPO: 'xxx-sandbox-it-test@mybranch'
  channel: '#my-onboard'
  AXWAY_SERVER: 'uscluql6fw9.cloud.unicreditgroup.eu'
  AXWAY_SERVER_PORT: 8090
```

- prod.yaml

``` yaml
args:
  AXWAY_DEPLOY_TARGET: 'PROD_application'
  APIGATEWAY_VERSION: '7.5.3_SP13'
  channel: '#my-onboard'
  AXWAY_SERVER: 'myprodgateway.cloud.unicreditgroup.eu'
  AXWAY_SERVER_PORT: 8090
```
