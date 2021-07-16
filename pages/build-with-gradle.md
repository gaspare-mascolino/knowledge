# Build with Gradle
In order to be able to run the pipeline using gradle,
some prerequisites should be matched:  

* there must be a  ```gradle.properties``` file
  
```
group = eu.unicredit.jxp
name = dummy-gradle-app-loppica
version = 1.0.0
```

This properties should be used by build.gradle to decide the group, name, version of the produced artifact. Build.gradle should **not** modify this values (as sometimes appens es. modifing version number using commit id) as these will be controlled by the pipeline
      
* There shuold be no ```repositories``` part as this is directly configured by the pipeline
    
* Your pipeline should integrate or use this code:
```groovy
plugins {
	id 'java'
	id "org.sonarqube" version "3.0"
	id 'jacoco'
    id 'project-report'
    id 'maven'
    id "org.owasp.dependencycheck" version "5.3.2"
}

test {
    finalizedBy jacocoTestReport
    testResultsDirName = prop("test_testResultsDirName",testResultsDirName)
    jacoco {
        destinationFile = file("${buildDir}/jacoco.exec")
    }
}

jacoco {
    toolVersion = "0.8.6"
    reportsDir = file(prop("jacoco_reportsDir",reportsDir))
}

jacocoTestReport {
    dependsOn test
    reports {
        xml.enabled true
    }
}

dependencyReport {
    outputFile = file(prop("dependencyReport_outputFile",outputFile))
}

dependencyCheck {
    failOnError false
    autoUpdate false
    suppressionFile 'devops/dependency-check-suppression.xml'
    outputDirectory = prop("dependencyCheck_outputDirectory",outputDirectory)
    formats = ['HTML','XML']
    data {
        directory=prop("dependencyCheck_data_directory",data.directory)
    }
}

uploadArchives {
    repositories {
        mavenDeployer {
            repository(url: prop('NEXUS_URL','http://url')) {
                authentication(userName: System.getProperty('USERNAME'), password: System.getProperty('PASSWORD'))
            }
            pom.version = project.getVersion()
            pom.artifactId = project.getName()
            pom.groupId = project.getGroup()
        }
    }
}

def prop(name, defaultValue){
    project.hasProperty(name) ?: defaultValue
}
```

As you can see this will setup crucial functionality for these steps:

* build
* dependency check
* sonar scan
* nexus publishing

