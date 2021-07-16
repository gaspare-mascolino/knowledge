## Prerequisites for Jenkins onboarding 👮‍✋

### General prerequisites

Jenkins pipeline configuration details can be found [here](rabbit-hole.md), but lets start from the prerequisites and technology stack supported until now

The **general prerequisites** are:

1. Have and application code officially registered in [AAM](http://sportelloud.intranet.unicredit.it/XA-AAM-PF/index.do)
1. Check if you are covered that by [Pipeline features](#jenkins-sefl-onboarding-features-and-roadmap)
1. Be aware of Mandatory steps and software quality [constraints](#jenkins-onboarding-constraints)
1. You need to be sure LDAP groups like below exists for your application

    - JYYXXX_DEVOPS_PM[^1]
    - JYYXXX_DEVOPS_DEV[^1]
    - JYYXXX_DEVOPS_GUEST[^1]

    if not follow the [guide](https://onboarding.devops.internal.unicreditgroup.eu/prerequisites/#ldap) to create them.

1. Ask for a provisioning using Ticket Online please follow dropdown menu *[Developer Topics -> Jenkins -> Onboarding request](https://webappars.intranet.unicreditgroup.eu/arsys/servlet/ViewFormServlet?form=UGIS:Global:TroubleTicket&view=GlobalBranchView_en&server=ars&mode=Submit&F536871059=59421)*

1. After a successfull provisionig follow the guide to setup your pipeline [here](rabbit-hole.md)

### Jenkins role model

As you may have already noticed, Jenkins is using the same LDAP groups as other DevOps tools. Please take a look at the details of the roles for every LDAP group.

|role|description|
| --- | --- |
|JYYXXX_DEVOPS_GUEST[^1]|can see results of the pipelines of the application. Can browse logs, relative artifacts and results of the scans|
|JYYXXX_DEVOPS_DEV[^1]|GUEST grants + after the commit in BitBucket the pipeline will execute CI part, CD part will not be executed - this profile cannot deploy even on Test environment|
|JYYXXX_DEVOPS_PM[^1]|DEV grants + on commit or PR merge the pipeline will run also th CD part - deploy on any environment|

### Jenkins onboarding constraints

The prerequisites for **Jenkins onboarding** are more strict. With Jenkins we deliver also other tools under the hood that deliver DevOps capability. It means you can deliver fast but you shouldn't forget then about the quality.

| Level | Requisite | Note |
| --- | --- | --- |
|Mandatory|Source Code in Bitbucket|Is it source code available for first commit on BitBucket|
|Mandatory|Developement with unit tests|Test coverage should be 60% for new commited code|
|Mandatory|Sonar scan without Blocker and Critical issues|Your asset should be free of Sonar issues of type Blocker and Critical based on the same rulesets available normally in central Sonar|
|Mandatory|No Critical or Major dependency vulnerabilities|OWASP dependency check will block the pipeline if vulnerabilities in 3rd party libraries are found in your project. Be ready to upgrade or refactor|
|Should have|Branching strategy in place|Do you apply already a branching strategy (GitFlow, Feature branch, …) take a look at the possibilities [here](https://www.atlassian.com/git/tutorials/comparing-workflows)|
|Should have|Test Automation (integration, e2e test) | You have possibility to launch automatic integration tests or e2e tests DevOps team can support you with [SBox selenium grid](selenium/selenium-grid.md) and [Nabu Java Selenium Framework](selenium/e2e-test-selenium.md) |

### Jenkins self-onboarding features and roadmap

DevOps Workflows Pipeline can support in self-onboarding following technology stack

| Language | Tool | Deploy to | Supported from end of | Available |
| --- | --- | --- | --- | --- |
|Java |||Q3 2020|✔️|
||Maven ||Q3 2020|✔️|
||Gradle||Q1 2021|✔️|
|||Gandalf deploy API|Q3 2020|✔️|
|JavaScript|npm||Q3 2020|✔️|
|JavaScript|yarn||Q3 2020|✔️|
||Docker||Q4 2020|✔️|
||helm|K8s cluster deploy[^2]|Q4 2020|✔️|
||ApiGateway Axway build|ApiGateway Axway deploy|Q2 2021||
|||Google Cloud Platform IaaS|Q2 2021|✔️|
|||Google Cloud Platform GKE|Q2 2021|✔️|
|||Azure IaaS|TBD||
|||Azure AKS|TBD||
||Sharepoint online|Cloud deploy O365|Q2 2021||
|Terraform||Cloud Azure|Q2 2021||
|Terraform||Google Cloud Platform|Q2 2021||
|Ansible||Cloud Azure|Q3 2021||
|Ansible||Google Cloud Platform|Q3 2021||
|||Windows server deploy|TBD||
||.Net||TBD||

## Pipeline CI/CD schema

Process schema

<p align="left">
  <a target="_blank" href="../images/pipeline-schema.png"><img width="800" src="../images/pipeline-schema.png"/></a>
</p>

Focus on tools

<p align="left">
  <a target="_blank" href="../images/pipeline-schema.png"><img width="800" src="../images/pipeline-schema-tools.png"></a>
</p>

## Pipeline CI/CD configuration example

In your source coce should be placed a standard Jenkinsfile in a `root folder` that is always the same:

```yaml
@Library('unicredit-devops-shared-library') _
init()
```

and under `devops` folder there should be a `configuration.yaml` that will set up you pipeline

```yaml
build:
 maven:
   phase: 'package'
   pomPath: 'development/sources/XXX-EBA/pom.xml'
publish_artifact:
  artifact: development/sources/XXX-EBA/XXX-EBA-EAR/target/XXX-EBA-EAR.ear
sonar:
  maven:
    args: "-Dsonar.coverage.exclusions=**/test-automation/** -Dsonar.exclusions=**/*.js,**/*.html,**/*.css"
    phase: 'sonar:sonar'
    pomPath: 'development/sources/XXX-EBA/pom.xml'
pre_install:
  db_migrations:
    liquibase:
      command: update
      commandParameters: -Doracle.jdbc.timezoneAsRegion=false
      credentialsId: XXXDB_Collaudo
      url: jdbc:oracle:thin:@myinstance0.internal.unicreditgroup.eu:1521/env0
      driverClass: oracle.jdbc.OracleDriver # N.B. Driver lib configured to be downloaded in classPathArtifacts key
      classPathArtifacts: #NB. classPathArtifacts can be declared in both following ways
        - fqan: com.oracle.jdbc:ojdbc8:12.2.0.1.0:jar
      changeLogFile: development/sql_scripts/changelog-master.xml
install:
  gandalf:
    environmentName: WAS-Collaudo
    deployTarget: 12345
    
mlxInfo:
  application: XXX
  subsystem: XXX-EBA_JAVAWEB
    
e2e_test_cd:
  maven:
   pomPath: 'development/sources/test-automation/pom.xml'
   profiles: UAT
   args:  liquibase:update
   phase: test
  
notifications:
  mail:
    triggers:
      - FAIL
    recipientsProviders: CulpritsRecipientProvider
```

If you need to have configuration depending on your branch please look [here](branch-aware.md)

you'll end up with the following in Jenkins:

<p align="left">
  <img width="800" src="../images/jenkins-pipeline-gui.png">
</p>

[^1]:Please note that `YY`, in the previous LDAP group names should be your Legal entity id (US, XL, ...) and `XXX` should be [AAM code](troubleshooting.md#-where-can-i-get-the-aam-of-my-application)
[^2]:Currently available K8s clusters are PULS, CEE Digital