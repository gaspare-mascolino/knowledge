
# Getting up and running 🏃‍‍‍‍‍💨

We are all pretty busy, we know that. So let's focus on the important stuff immediately.

What follows should be sufficient to get you from zero to...well...normal user in the blink of an eye (to become a hero
you'll need to do the extra mile 🙃).

## Prerequisites 👮‍✋

In order to access the functionalities offered by this set of tools your application must satisfy the following
requirements:

* You are working on an already defined application, so the APP CODE (3 chars) is already defined in [AAM](http://sportelloud.intranet.unicredit.it/XA-AAM-PF/index.do)
* Your appication is in the [list](supported-apps.md) of applications in the <u>"DevOps at scale" initiative</u>
* You must have <u>requested and obtained</u> through the LDAP groups required as [described here](prerequisites.md#ldap).  
* Your application must be hosted on [BitBucket](https://bitbucket.internal.unicreditgroup.eu) as described in 
[this section](prerequisites.md#git-stuff-done).

What about if your app is not in the [list](supported-apps.md)? Have a look at [self onboarding](self-onboarding.md) capabilities.

## A minimal configuration

Following this section you'll have a minimal but working configuration for starting using the pipelines.

### Create the `Jenkinsfile` (DEPRECATED)

!!! note
    Be aware that we are migrationg this documentation to  [Confluence](https://confluence.intranet.unicreditgroup.eu/pages/viewpage.action?pageId=27791316)

In the root folder of your repository create a file named `Jenkinsfile` with the following content:

```groovy
@Library('unicredit-devops-shared-library') _
init()
```

### Create the `devops/configuration.yaml` (DEPRECATED)

!!! note
    Be aware that we are migrationg this documentation to  [Confluence](https://confluence.intranet.unicreditgroup.eu/pages/viewpage.action?pageId=27791316)

Always in the root of your repository create a `devops` folder with a `configuration.yaml` file in it with the following
content:

```yaml
build:
  maven:
    args: '-U -DskipITs=true'
    phase: 'package'
sonar:
  maven:
    profiles: 'sonar'
    args: "-DskipTests=true"
    phase: 'sonar:sonar'
```

### Configure pom.xml (in case of Maven Java project)

In order to run quality checks with OWASP and Sonar the project POM must define specific profiles.
To define them you have 3 options:

1\. In case your project can contain a parent pom you can define the following which already contains the needed profiles

```xml
...
<parent>
    <groupId>eu.unicredit.jxp</groupId>
    <artifactId>devops-pom</artifactId>
    <version>1.0.0</version>
</parent>
...
```

2\. In case your project is based on XFrame you can add one of these parent POM depending on the version of XFrame used. They already contains the needed profiles.

```xml
...
<parent>
    <groupId>XFrame 2.2</groupId>
    <artifactId>X22S-EBA-BASE-JEE7</artifactId>
    <version>1.0.4-SNAPSHOT</version>
</parent>
...
```

or

```xml
...
<parent>
    <groupId>XFrame 2.1</groupId>
    <artifactId>X21S-EBA-BASE-JEE6</artifactId>
    <version>2.1.4-SNAPSHOT</version>
</parent>
...
```

3\. In case the two previous options are not applicable you can define the needed profiles directly in your `pom.xml` file
<details><summary>pom.xml</summary>
<p>

```xml
<profiles>
	<profile>
		<id>devops</id>
		<properties>
			<jacoco.outputDirectory>${project.reporting.outputDirectory}/jacoco</jacoco.outputDirectory>
			<sonar.junit.reportPaths>${project.build.directory}/surefire-reports</sonar.junit.reportPaths>
			<sonar.coverage.jacoco.xmlReportPaths>${jacoco.outputDirectory}/jacoco.xml</sonar.coverage.jacoco.xmlReportPaths>
		</properties>
		<build>
			<plugins>
				<plugin>
					<groupId>org.apache.maven.plugins</groupId>
					<artifactId>maven-surefire-plugin</artifactId>
					<version>2.22.2</version>
					<configuration>
						<reportsDirectory>${reportsDirectory}</reportsDirectory>
					</configuration>
				</plugin>
				<plugin>
					<groupId>org.jacoco</groupId>
					<artifactId>jacoco-maven-plugin</artifactId>
					<version>0.8.6</version>
					<executions>
						<execution>
							<id>pre-unit-test</id>
							<goals>
								<goal>prepare-agent</goal>
							</goals>
						</execution>
						<execution>
							<id>post-unit-test</id>
							<phase>test</phase>
							<goals>
								<goal>report</goal>
							</goals>
							<configuration>
								<outputDirectory>${jacoco.outputDirectory}</outputDirectory>
							</configuration>
						</execution>
					</executions>
				</plugin>
			</plugins>
		</build>
	</profile>
	<profile>
		<id>devops-owasp</id>
		<properties>
			<outputDirectory>${project.build.directory}</outputDirectory>
		</properties>
		<build>
			<plugins>
				<plugin>
					<groupId>org.owasp</groupId>
					<artifactId>dependency-check-maven</artifactId>
					<version>6.0.3</version>
					<configuration>
						<autoUpdate>false</autoUpdate>
						<skipProvidedScope>true</skipProvidedScope>
						<skipRuntimeScope>true</skipRuntimeScope>
						<failOnError>false</failOnError>
						<retireJsAnalyzerEnabled>false</retireJsAnalyzerEnabled>
						<assemblyAnalyzerEnabled>false</assemblyAnalyzerEnabled>
						<zipExtensions>jar,war,ear</zipExtensions>
						<outputDirectory>${outputDirectory}</outputDirectory>
						<suppressionFiles>
							<suppressionFile>devops/dependency-check-suppression.xml</suppressionFile>
						</suppressionFiles>
						<formats>
							<format>XML</format>
							<format>HTML</format>
						</formats>
					</configuration>
					<executions>
						<execution>
							<goals>
								<goal>aggregate</goal>
							</goals>
						</execution>
					</executions>
				</plugin>
			</plugins>
		</build>
	</profile>
</profiles>
```
</p>
</details>

That's it! You should now be able to run your first, but rough, pipeline!

If you want to try it out what you've been doing so far, now you should be able to connect to
[Jenkins](https://jenkins.devops.internal.unicreditgroup.eu/) and run a pipeline that should checkout your code, build it and
run the sonar analysis on it. That's something!