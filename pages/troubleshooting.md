
# F.A.Q. & Troubleshooting 😠💔👨‍🚒

## 🤔↝ I'm logged into Jenkins but I am not seeing anything!
Be sure that you belongs to the right LDAP Group as explained in [previous section](/prerequisites/#ldap).
Otherwise you won't see anything.

---
## 🤔↝ Can pipeline or single stage be disabled for specific branch or branch group?
Sure! In order to disable the pipeline run for the code pushed in specific branch you can use one of the following solutions: 

* Edit the configuration of the pipeline by using the [filter section](/rabbit-hole/#skip-a-step-filter).
* Remove the Jenkinsfile from the branch

The first solution would be better because a filter can be specified in the way that the same pipeline configuration can be used in all the branches.
  
The second one will cause to have different files or code between different branches 

---
## 🤔↝ Why my new branch or repository is not visible in Jenkins?
The issue can be caused by:

* Missing **Jenkinsfile** in the root of the branch
* The **Jenkinsfile** is named differently ex. JenkinsFile,jenkinsfile etc.
* The **sync** between Jenkins and BitBucket was not done after the creation of the branch or repository.For further information read the [Jenkins and Bitbucket integration section](/jenkins-bitbucket-integration/#jenkins-repositories-and-branches-sync).

---
## 🤔↝ Why I cannot push to BitBucket and I get an “Authentication failed” error?

If you’ve change your LDAP password recently please update or delete all the values regarding BitBucket from **Windows** -> **Control panel** -> **Credential manager** -> **Windows Credentials**.
This should let git to take the new credentials or ask for your password again.

!!! info
    To avoid this in the future you can use BitBucket ssh token instead

---
## 🤔↝ How to handle the certificate related error with Git portable?

it's enough to set "git config --global http.sslBackend schannel"

---
## 🤔↝ I get an error when trying to push to BitBucket. How can I solve it?

On every incoming commit, BitBucket checks if the committer has a *valid* name and email.

In this context, *valid* means they must both be equal to the committer's **LDAP employee ID**, 
and that ID must have been assigned one of the [DevOps LDAP roles](/prerequisites/#being-assigned-to-an-ldap-group). 

Name and email are stored in your local git configuration, in the fields ```user.name``` and ```user.email```.
You can check yours by running ```git config -l```. 

If their value is not compliant, you will get an error like:

```
remote: - Bitbucket: 'c123456' != Commit: 'invalid@unicredit.eu'
remote:   Your email invalid@unicredit.eu is not present on Bitbucket Database. Please update it by running the command:
remote: git config --global user.email c123456@unicredit.eu
remote:
remote: In order to set the correct email to the previous commit run:
remote: git filter-branch --env-filter 'if [ "$GIT_COMMITTER_EMAIL" = "invalid@unicredit.eu" ]; then GIT_COMMITTER_NAME="c123456"; GIT_COMMITTER_EMAIL="c123456"; fi' -- --all
```

This contains **two** git commands needed to fix your local configuration and to amend the commits that are no more compliant.
Just paste in a shell the commands you actually got, run them, and then push as usual.

!!! info
    Email notifications from BitBucket will keep working after this change. Indeed, BitBucket will leverage on the ```userId@mailasp.internal``` alias.

!!! warning
    If you want to run the commands above in a Windows cmd/powershell, you'll need to use just quotation marks (no apostrophe) and escape the nested ones:
     
        git filter-branch --env-filter "if [ \"$GIT_COMMITTER_NAME\" = \"invalid@unicredit.eu\" ]; then GIT_COMMITTER_NAME=\"c123456\";  GIT_COMMITTER_EMAIL=\"c123456\"; fi" -- --all

---

## 🤔↝ I get an error when on push to BitBucket even if my git-client settings are correct

First of all check if your git-client settings are correct, as following:

```
$git config -l
user.name=c123456
user.email=c123456 
```

If this is true and you have problems the same, please check if you are still granted to push to this BitBucket Project -  in other words verify in Archimede if your user takes part of the correct LDAP group.

---
## 🤔↝ Why the pipeline is not able to download my docker image?

Only certain registries are allowed. For further informations, please take a look [here](/pipeline-network-configuration/#docker-registries)  

---
## 🤔↝ Why the pipeline is not able to download a package from a public linux distribution repository?

Only certain repositories are allowed. For further informations, please take a look [here](/pipeline-network-configuration/#distro-specific-package-repositories)

---
## 🤔↝ How do I suppress a Warning from Sonar?

In case you are sure a warning reported from Sonar can be ignored, depending on the language you are using you can ignore it by modifying your code as follows:

* **Java**: add `@SuppressWarning("<issue_id>")` with the `issue_id` you can find from sonar GUI as in the picture below. Beware that you should not suppress these warning from the Sonar GUI, as Sonar is configured as code and any modification would be lost upon restart.

<p align="center">
  <img src="../images/sonar-suppress-1.png">
</p>

* **Javascript**: as you can see [here](https://community.sonarsource.com/t/how-do-you-ignore-a-specific-rule-on-a-specific-line-in-javascript/23962/4) there is no way to suppress specific Sonar warnings directly from js code. 
So, if you are really sure a warning doesn't make sense the only options you have are: suppressing it from the GUI or disable all warnings by adding `// NOSONAR` immediately above the line generating the warning.

---
## 🤔↝ How to suppress a OWASP dependency-check false positive vulnerability?

If you really think a vulnerability spotted by the dependency-check plugin needs to be silenced (e.g. it's a false positive), you can do so by retrieving the suppression XML snippet from the report html (see [here](https://jeremylong.github.io/DependencyCheck/general/suppression.html)) and add it to the `devops/dependency-check-suppression.xml` file, which will be automatically loaded once the plugin is run.

The `devops/dependency-check-suppression.xml` file should look like this:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<suppressions xmlns="https://jeremylong.github.io/DependencyCheck/dependency-suppression.1.3.xsd">
   <suppress>
      <notes><![CDATA[
      file name: some.jar
      ]]></notes>
      <sha1>66734244CE86857018B023A8C56AE0635C56B6A1</sha1>
      <cpe>cpe:/a:apache:struts:2.0.0</cpe>
   </suppress>
</suppressions>
```

---
## 🤔↝ How to fix problems with OWASP or Sonar during the build?

Check if you have added the necessary profiles in you `pom.xml` file as described in [Quick Start section](/quick-start/#configure-pom-xml-in-case-of-maven-java-project)

If you already have done so, you can configure those profiles locally at project level adding the needed configuration as described in option 3 of previous link.
In the example below the project inherit mandatory profiles from the parent pom and then locally override some configurations to allow Concierge support:
<details><summary>pom.xml</summary>
<p>

```xml
...
<parent>
    <groupId>eu.unicredit.jxp</groupId>
    <artifactId>devops-pom</artifactId>
    <version>1.0.0</version>
</parent>
...
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
					<groupId>org.jacoco</groupId>
					<artifactId>jacoco-maven-plugin</artifactId>
					<version>0.8.5</version>
					<executions>
						<execution>
							<id>post-unit-test</id>
							<phase>test</phase>
							<goals>
								<goal>report</goal>
							</goals>
							<configuration>
								<outputDirectory>${jacoco.outputDirectory}</outputDirectory>
								<excludes>
									<exclude>eu/unicredit/jxp/concierge/swagger/**/*</exclude>
								</excludes>
							</configuration>
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

---
!!! bug
    Couldn't find what you're looking for? Help us improve this documentation by [getting in touch](contribution-info.md).  