# Integration test with the SoapUI Framework (DEPRECATED)

The following section will provide some information about the building the integration tests with 

* SoapUI Free a popular application to write and launch tests for SOAP and REST protocols and
* SoapUI Java Framework a testNG based java framework that helps to run your SoapUI tests inside CI/CD pipeline by Jenkins.

Normally you start to write your test in SoapUI interface and you are already able to launch it.
It's important to understand that Java Framework part is mandatory only if you want to launch your tests from CI/CD. In this case you should stick to the initial configuration that manages target test environment described in **SoapUI** section

## SoapUI

First of all, you will need to download [SoapUI]('https://www.soapui.org/downloads/'). The **Open Source** version is more than enough.  
For further information please refer to the SoapUI [documentation]('https://www.soapui.org/soapui-projects/soapui-projects.html').  

#### Structure of Test

We suggest you to organize your test cases in test suite, as shown in the image below:

<p>
    <img src="../images/soapui-struc-test.png">
</p>

* **TestSuite**: is a collection of TestCases that can be used for grouping functional tests into logical units. Any number of TestSuites can be created inside a SoapUI project to support massive testing scenarios.
* **TestCase**: is a collection of TestSteps that are assembled to test some specific aspect of your service(s).
* **TestStep**: is the "building blocks" of the tests. SoapUI offers different types of test steps, in the example above the `TEST_CASE_0_01` presents two _REST Request_ (Step_1 and Step_2) and one _Groovy Script_ (Groovy_Step).  

#### Create project's Custom Properties

At the **project level** you can add **Custom Properties**.  
In the example below we created the following custom properties in order to achieve an environment handling.

* `targetEnv`: The target environment to be tested. It can be *TEST*, *QUAL* or *PROD*.
* `env`: The custom properties used by the Setup Script. Leave it empty.
* `TEST`: Endpoint of the test's environment.
* `QUAL`: Endpoint of the quality's environment.
* `PROD`: Endpoint of the production's environment.

<p>
  <img src="../images/soapui-custom-prop.png">
</p>

Now, inside each test step, you can change the *Endpoint* with the custom properties created before (either `http://${#Project#env}` or `https://${#Project#env}`). The Setup Script will provide the desired endpoint.

<p>
  <img src="../images/soapui-endpoint.png">
</p>

#### Add Setup Script in the suites

In all the project's suites, add the following groovy script inside the tab *Setup Script*:

```groovy
def targetEnv = context.expand('${#Project#targetEnv}')
def envTest = context.expand('${#Project#envTest}')
def envProd = context.expand('${#Project#envProd}')
def envQual = context.expand('${#Project#envQual}')

switch (targetEnv.toUpperCase()) {
    case "PROD":
    testSuite.project.setPropertyValue("env", envProd);
    break;

    case "QUAL":
    testSuite.project.setPropertyValue("env", envQual);
    break;

    default:
    testSuite.project.setPropertyValue("env", envTest);
}
```

<p>
  <img src="../images/soapui-setup-script.png">
</p>

The script will handle how to run the tests against the desidered environment. Just remember to change the custom properties **targetEnv** with the desired value.

#### Add certificate for local run

SoapUI offers different ways to add a certificate to your requests. Here we'll show how to add it globally for all your request via the **SoapUI Settings** and how to create a **Load Script** that will set it up for you.  

To set up the certificate via the **SoapUI Settings** open Preferences > SSL Settings and:  

* for the KeyStore specify the full path to your certificate
* for the KeyStore Password add the keystore password

as shown in the image below:  

<p>
  <img src="../images/soapui-cert.png">
</p>

For further information please refer to the SoapUI [documentation]('https://www.soapui.org/docs/functional-testing/sending-https-requests.html')

Set up also the certificate via the **Load Script** at the **Project** level:

* Add two *Custom Properties* at the Project level: `cert` and `password`. On the first property add the full path to your certificate and on the last one the keystore password.
* Open the **Project View** and from the *Overview* tab click on the *Load Script* button and add the following script:

```groovy
import com.eviware.soapui.settings.SSLSettings
import com.eviware.soapui.SoapUI

def pathToKeystore = context.expand('${#Project#cert}')
SoapUI.settings.setString(SSLSettings.KEYSTORE, pathToKeystore)
SoapUI.settings.setString(SSLSettings.KEYSTORE_PASSWORD, context.expand('${#Project#password}'))
SoapUI.saveSettings()
```

<p>
  <img src="../images/soapui-loadscript.png">
</p>

## SoapUI Framework

### Getting started

The framework is built with Maven. You can generate it from Eclipse or IntelliJ, but in this section all examples have been made with Eclipse.

### Add Nexus as an Archetype Catalog

Make sure that nexus is already added as the Archetype catalog, which points to the UBIS Nexus production server.
You need to add the "unicredit-local" archetype repository:
```
http://guest:nexus@nexus.internal.unicreditgroup.eu:8081/nexus/content/repositories/unicredit-local/
```
In Eclipse, go to Windows-->Preferences --> Maven --> Archetypes-->Add Remote Catalog. Then Apply and close.

Currect Archetype - eu.unicredit.thx: *SOAPUI-FRAMEWORK-ARCHETYPE:1.0.6*

### Create your application from Maven Archetype

Select File new --> Maven Project from the Eclipse File menu.

Select "Next". In the New Maven Project dialog select *unicredit-local* as your Catalog and add SELENIUM into the filter.
Select the archetype SOAPUI-FRAMEWORK-ARCHETYPE and click 'Next'

Enter the Group Id in the following format: 
```
eu.unicredit.soapui
```
Enter inside the Artifact Id AAM code (3 characters) of your application in lowercase for example for application ABC would be abc: 
```
xxx
```
Package name will be generated. 
Leave additional properties of archetype like it is.

Select Finish
The new application will now be created into your local workspace with the following project structure.

#### Structure of the framework

```tree
 .
├── main
│   ├── java
│   │   └── eu
│   │       └── unicredit
│   │           └── soapui
│   │               └── xxx
│   │                   ├── config
│   │                   │   └── TestBase.java
│   │                   └── listeners
│   │                       └── CustomListener.java
│   └── resources
│       └── logback.xml
└── test
    ├── java
    │   └── eu
    │       └── unicredit
    │           └── soapui
    │               └── xxx
    │                   └── impl
    │                       └── SoapUiTestSuiteImplementation.java
    └── resources
        ├── SoapUiProject
        │   └── example-eg0-project.xml
        └── testng.xml
```

The class `SoapUiTestImplementation.java` tests the SoapUI project.  
All @Test methods will be executed by the framework.
The method name should be the same as the name of the SoapUI testcase in the SoapUI project.  
This means that all the TestCases should have different names also from different TestSuites.
In order to add a @Test method just copy - paste a method and change the name accordingly with the Test Case Name.

```java
@Test
private void ExampleTestCase() {
    parseTestSuite(new Throwable().getStackTrace()[0].getMethodName());
}
```

The folder `SoapUiProject` has to contain your SoapUI project `.xml` file, imported from the SoapUI application.

The TestNG configuration file `testng.xml` is already preconfigured and you don't have to modify it. It invokes the suite of the declared tests from the `SoapUiTestImplementation.java` class.  
Here we've defined:

* The `<suite>` tag where:
    + `name` : The name to use for a suite.
* The `<test>` tag where:
    + `name` : The name to use for a test.
    + `parallel="tests"` : TestNG will run all the `@Test`, of a test suite, in a separate thread. The parallelism can be setted also to the level of "methods" and "class", please check the TestNG documentation for more details.
    + `thread-count` : This sets the default maximum number of threads to use for running tests in parallel. It will only take effect if the parallel mode has been selected (for example, with the -parallel option). This can be overridden in the suite definition.
    + `preserve-order` : TestNG will run your tests in the order they are found in the XML file. If you want the classes and methods listed in this file to be run in an unpredictable order, set the preserve-order attribute to false.
* The `<class>` tag where is declared the class that contains the tests.

It looks like this (XXX is AAM code of your application):

```xml
<suite name="XXX Integration Test Suite">
    <listeners>
        <listener
            class-name="eu.unicredit.soapui.xxx.listeners.CustomListener" />
    </listeners>
    <test name="XXX Integration Test Suite" parallel="tests" thread-count="30" preserve-order="false">
        <classes>
            <class
                name="eu.unicredit.soapui.xxx.impl.SoapUiTestSuiteImplementation" />
        </classes>
    </test>
</suite>
```

### Running the suite

To run the suite, you need to create a configuration by right-clicking on the project name and selecting "Run As" in the project explorer tree. Into goals you can put the following command:

```shell
clean test -Denvironment=TEST
```
You can also run equivalent command against other than *TEST* target environments like: *QUAL* and *PROD*

### Form SoapUI project to SoapUI Framework

In the next section, we'll give you some guidelines on how to  integrate your SoapUI project in the UniCredit SoapUI Framework. The framework is necessary only if there is an interest on running the test suite in a CI/CD pipeline.

#### Import the SoapUI project into the framework

Copy the SoapUI project.xml into the framework's folder `SoapUiProject`.

#### Add test cases

Each test case inside your SoapUI interface has to be represented by the @Test method  (ex. MySoapUITestCase) inside the framework's class `SoapUiTestImplementation.java`. You need to edit only the method name and leave the body like it is. Note that each testcase has to have a different name (it's not a SoapUI constraint). You don't need to specify the TestSuite 
```java
@Test
private void MySoapUITestCase() {
    parseTestSuite(new Throwable().getStackTrace()[0].getMethodName());
}
```

#### SSL certificate management

In order to use the certificate, place it first inside Java key store (.jks) then set it up in the SoapUI project choosing the [Load Script](soapui-framework.md#add-certificate-for-local-run) solution.  
Then create a new folder inside the `SoapUiProject` one. Name it "cert" and store there your certificate.  

```tree
 .
├── .settings
├── _src
|   ├── main
|   └── _test
|       ├── java
|       |
|       └── _resources
|           └── _SoapUiProject
|               └── cert

```

Modify the `TestBase.java` by uncommenting the runLoadScript method, CERT and PASS static variables, as shown below. The method sets up the properties *cert* and *password* and run the Load Script, added in the SoapUI project, before running the test suite. In this way, the certificate will be added to the container's soapui setting and the request will be successful.  

```java
private static final String CERT = SOAPUI_PROJECT + File.separator + "cert" + File.separator + "myJavaKeyStore.jks";
private static final String PASS = "keystorepassword";

...

private void runLoadScript(WsdlProject project) {
    project.setPropertyValue("cert", CERT);
    project.setPropertyValue("password", PASS);
    try {
        project.runAfterLoadScript();
    } catch (Exception e) {
        LOGGER.error("Exception occurred.{} ", e.getMessage());
    }
}
```

#### Modify suite and test name in testng.xml

Modify the framework's file `testng.xml` with the correct suite and test name and with the desired parameters (eg: `parallel`, `thread-count`, ... ).  

### You are ready to GO!!!
