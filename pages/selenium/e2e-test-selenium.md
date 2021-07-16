# End to end testing with Nabu

The aim of writing automated tests (all kinds, from unit to e2e) is always one: improving the quality of the product under test,
writing suites that prove the correctness of the underlying code and ensure no regressions are introduced when fixing and evolving the application.

A key aspect of test automation is traceability, meaning your tests must produce reports that show which methods/features were covered, 
and that can be compared among different runs so to monitor the coverage evolution and identify *weak* parts of your code base.

---
## Getting started
[Selenium](https://www.selenium.dev/documentation/en/) is a project that aims to automate browser execution. 
It exposes an API that lets you interact with the browser through an interface called WebDriver,
so that you can write e2e tests to simulate the actions a real user would perform on your application.

At a very high level, mainly two things must be done when testing with Selenium:

1. Set up the ```webDriver```
1. Write the test

That's it! But why would we reinvent the wheel? To achieve these two goals we can use different frameworks that interact with each other:

1. A Selenium framework
1. A Testing framework

Nabu belongs to the first group: indeed it's a Selenium Framework that aims to simplify the overall e2e tests development, 
providing a fast way to have a fully working ```webDriver``` (bullet 1),
thus helping you focus just on the flow logic needed to test your application (bullet 2).

It's built on top of [JUnit 5](https://junit.org/junit5/docs/current/user-guide/) and leverages its features to make tests development easier:
using JUnit's [extension model](https://junit.org/junit5/docs/current/user-guide/#extensions) and [parameters resolution](https://junit.org/junit5/docs/current/user-guide/#extensions-parameter-resolution), 
Nabu takes care of creating all the stuff you may need, letting you focus just on writing tests.

### A deeper look into Nabu
Nabu is an internal project which is itself tested automatically and built with a DevOps pipeline,
thus compliant with all the quality constraints we expect from our clients.

Since we strongly believe in **transparency**, **quality** and **feedback**, we'd like you to see:

- [Nabu's source code](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse)
- [Nabu's sonar scan](https://sonar.devops.internal.unicreditgroup.eu/dashboard?id=eu.unicredit.thx%3ANABU)
- [Nabu's pipelines](https://jenkins.devops.internal.unicreditgroup.eu/job/THX/job/nabu/)

and hear your voice. See the [contacts](#contacts) section.

!!! info
    To check Nabu's source code and see its pipelines, you need to request the **THX DevOps - Guest** role on Archimede.
    Don't be shy! Join that role and give us your feedback, we really appreciate collaboration and suggestions 🙂
    
    Check the [prerequisites section](/prerequisites/#being-assigned-to-an-ldap-group) for more info on how to request a role.
    <p style="text-align: center">
        ![Thx Devops Guest Role](../images/selenium/archimede-thx-devops-guest.png)
    </p>

Enough said, let's start with a simple use case to see Nabu in action!

!!! info
    You need a JDK 1.8+ to use Nabu

---
## How to use Nabu
1. Create a new **Maven** (not plain java) project in your IDE. Once in the Archetype section, click on the ```Add archetype``` button and add these:
    - Group Id: ```eu.unicredit.thx```
    - Artifact Id: ```NABU-ARCHETYPE```
    - Version: ```1.0.1```
    
    ![Archetype](../images/selenium/archetype.png)

1. Select the newly inserted archetype and create the new project choosing the parameters of your test application.

    !!! info
        Eclipse sometimes throws an error saying it can't find the Archetype.  
        In that case, you can create the project from command line with:
   
            mvn archetype:generate -DarchetypeGroupId=eu.unicredit.thx -DarchetypeArtifactId=NABU-ARCHETYPE -DarchetypeVersion=1.0.1 -DgroupId=<YOUR GROUP ID> -DartifactId=<YOUR ARTIFACT ID>

    !!! tip
        To use the ```@Getter``` annotation you'll find in the example test, you need to install the [Lombok](https://projectlombok.org/) plugin, 
        without the need to specify the dependency, since it's provided by Nabu.
        
        Lombok helps you reduce the boilerplate code of java by providing a set of useful annotations. Check it out!
        
        Otherwise, if you're a _nostalgic_ developer, you can write boilerplate getter methods in vanilla Java and remove the ```@Getter``` annotation.

    !!! warning
        The archetype will fetch the ```LATEST``` Nabu version (check the generated ```pom.xml```).
        
        To avoid updating it automatically when a new version is released, it's better if you change it with the actual latest version number
        you can find in the [release notes](/selenium/release-notes).
    
1. Run the test in one of these two ways:
    - From your IDE - preferred during development since you can debug your tests and quickly choose which ones to run without changing the source code.
    
        ![Thx Devops Guest Role](../images/selenium/idea-running-conf.png)
        
        !!! warning
            The test failed but no stacktrace is shown in Eclipse? [Check this](#stacktrace).
        
    - With Maven: 

            mvn integration-test -Dwdm.proxy=http://username:password@proxymil.internal.unicredit.eu:80
            
    !!! warning
        When running with Maven, it's important that the name of your test classes ends with ```IT``` as in the example: ```HelloWorldIT```.
        These are indeed the [Maven conventions](http://maven.apache.org/surefire/maven-failsafe-plugin/examples/inclusion-exclusion.html) 
        if you want the failsafe plugin to include them automatically.
        
    !!! tip
        The default browser is ```chrome```. If you want to use another one, 
        you can switch browser with ```-Dbrowser=firefox``` or ```-Dbrowser=ie```

    !!! info
        As you probably noticed, you need to set the proxy in both cases, to let Nabu download the webDriver. 
        
        The easiest way to achieve this it is to pass the ```-Dwdm.proxy=``` directive to the JVM.
        
        The webDriver is downloaded just on the first local run: 
        once you have the right webDriver version based on your OS and the capabilities requested, the driver will be cached for 30 days 
        and the download will be skipped.
        
        Check the [WebDriverManager docs](https://github.com/bonigarcia/webdrivermanager/blob/master/README.md) for more info.

1. When the execution is finished, you'll find a html file under ```target/selenium/reports```. Open it in a browser! 

!!! warning
    Mind that the application under test in this example is SBox, which isn't managed by us. 
    Thus, if SBox developers change the UI, the test might fail!
    
    Nevertheless, we don't actually care about the test result here, we just want to see it running.

---
## Behind the scenes

Let's see what Nabu did under the hood when you ran the test.

As you probably noticed, you used some objects without even declaring them (```webDriver```, ```configuration```, ```nabuUtil``` and ```extentTest```). 
They are defined in the [NabuTest](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/util/NabuTest.java) 
class and its parent, the [BaseNabuTest](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/util/BaseNabuTest.java) class,
but to get how and when they are initialized we need to take a look at the fields declared in the interface implemented by the latter.

Indeed the [ExtensionsLoader](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/internal/ExtensionsLoader.java) 
interface will be loaded at runtime and its fields will be registered as tests extensions:
the first two are used to register hooks around tests execution (_beforeAll_, _onTestSuccess_, _onTestFailed_ etc.) 
while the others take care of resolving parameters like the ones we saw above.

Therefore, before actually starting the execution, all these parameters are initialized and stored 
in JUnit's ```extensionContext```. Then, in the ```NabuTest``` class the ```beforeAll``` and ```beforeEach``` hooks are executed 
and all those parameters are injected in protected fields you can directly use in your test classes.

!!! Info
    **Here's a recap of what happens from a boring technical point of view:**

    1. You start the test
    1. The JVM loads the ```NabuTest``` and ```BaseNabuTest``` classes in memory, since your class extends the former
    1. The JVM loads the ```ExtensionsLoader``` interface in memory, since ```BaseNabuTest``` implements it
    1. JUnit registers ```ExtensionsLoader```'s fields as tests extensions
    1. JUnit run the ```beforeAll``` and ```beforeEach``` hooks defined in ```NabuTest```
    1. Junit resolves the parameters defined as arguments of the hooks above
    1. ```NabuTest``` saves the values of the resolved parameters in protected fields
    1. Your test runs, leveraging on the injected objects

Let's now check how to configure Nabu and all of these objects.

It's worth noting that there are two different aspects of Nabu's configuration:

1. **Configuration related to the application under test**

    Regards things like the browser to use, the timeouts before throwing exceptions and so on: 
    you can configure default values which can be overridden for specific environments.
    
    !!! example
        - you want the browser to start full screen always, so you set this as default.
        - you want to set a page loading timeout to 2 seconds in all environments but ```test```, because in that environment the application is really slow.
        You will then set 2 seconds as default and override this value only for the ```test``` environment.
    
    This configuration is done via the ```configuration.yaml```. [Details here](#configuration)
    
1. **Configuration related to the system where Nabu runs**

    Regards things like where to store the report, where to put the downloaded files and whether to run in parallel or not.
    
    !!! example
        - in local, you might want to run one test at a time, while on a CI server with dedicated resources you might want to run them in parallel.
    
    This is achieved through ```system properties```. [Details here](#system-properties)

Bottom line: the ```system properties``` affect the client environment where Nabu runs, 
while the ```configuration.yaml``` affects the behavior of Nabu related to the target environment.

!!! example
    Ada and Bob both run the tests from their local machines targeting, let's say, the ```UAT``` environment. 
    Nabu's behavior will be the same from the application point of view, because the target environment is the same, 
    and its configuration is defined in the ```configuration.yaml```, which is versioned. 
    
    Ada wants to be as fast as possible, so she runs the tests in parallel.
    Bob wants to be fast as well, but unfortunately he has an old pc, and since he doesn't want it to explode, he decides to run the tests sequentially.
    They can achieve this through their own set of ```system properties```.

---
## Configuration

Following the *Convention over Configuration* paradigm, Nabu is fully configurable and comes with default values which you can find 
in the [configuration.default.yaml](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/resources/configuration.default.yaml). 
These are enough to run in local, as we did in the [example above](#how-to-use-nabu).

In case of need, you can provide a custom configuration placing a ```configuration.yaml``` file under ```src/test/resources```. 
Furthermore, to manage different configurations related to specific environments,
in the same folder you can specify a ```configuration-<ENV>.yaml``` file for each one.

To let Nabu pick the right environment-related configuration, you must run with the ```-Denv``` directive.
There's no need to repeat everything: the configuration files will be merged, 
so it's better to keep values that are common to all the environments in the base ```configuration.yaml```.

!!! example
    When running tests with ```-Denv=test```, Nabu will merge these three files in this order of precedence: 
    
    1. configuration-test.yaml
    1. configuration.yaml
    1. configuration.default.yaml

!!! info
    The values in the env-related yaml will take precedence over the general one, which will in turn take precedence over the default one.
    
    **None of these custom configuration files is mandatory: to keep your code clean, you should provide them only if you really need.**

    When running **without** the ```env``` flag, Nabu will apply the default ```local``` environment,
    which will have the same effect of running with ```-Denv=local```. This means that these three files, if present, will be merged: 
    
    1. configuration-local.yaml
    1. configuration.yaml
    1. configuration.default.yaml

!!! tip
    If your team needs to have different local configurations for each developer, you can add this line to the ```.gitignore```:
    
        src/test/resources/configuration-local.yaml 

There are five main objects that can be configured:

1. [Application](#application)
1. [Extent](#extent)
1. [Webdriver](#webdriver)
1. [Selenium Logs](#selenium-logs)
1. [Events](#events)

Let's now see them in detail! The default code snippet of each one is also provided, so that you can easily change it according to you needs.

!!! tip
    In your custom configuration, specify just the [yaml nodes](https://yaml.org/spec/1.2/spec.html#id2764044) you want to change. 
    All non-modified nodes will keep default values.
    
    For example, this is the default grid configuration:
    
        webdriver:
          grid:
            url: https://sbox.internal.unicreditgroup.eu/wd/hub/
            capabilities: {}
            
    if you need to add the token to run on SBox, you need to provide just that capabilities, without rewriting the url:
    
        webdriver:
          grid:
            capabilities:
              e34:token: <YOUR TOKEN> 

### Application

In this section you can specify the parameters related to the application under test.

    application:
      baseUrl: https://sbox.internal.unicreditgroup.eu/
      driversPath: ~/.m2/repository/webdriver

| Field                  | Type   | Description  |
| -----------------------|--------|--------------|
| baseUrl                | String | Your app's base url
| driversPath            | String | Path to drivers executables

### Extent

Here you can configure the [extent report](https://extentreports.com/), produced by collecting info Nabu gathers automatically during the run.

    extent:
      documentTitle: Selenium Report
      reportName: Selenium Report
      theme: STANDARD
      timeStampFormat: EEEE dd/MM/yyyy, hh:mm a (zzz)

| Field           | Type   | Description  |
| ----------------|--------|--------------|
| documentTitle   | String | Title of the html page
| reportName      | String | Name shown in the header of the report
| theme           | [Theme](http://extentreports.com/docs/javadoc/com/aventstack/extentreports/reporter/configuration/Theme.html) | Report's theme, can be ```STANDARD``` or ```DARK```
| timeStampFormat | String | Timestamp of each test's start time and end time

### WebDriver

The [webDriver](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/pojos/yamls/Webdriver.java) 
is a *pojo* that holds the configuration of other objects representing the browsers and the selenium grid.
See below for a detailed description of the fields you can set on each.

    webdriver:
      waitTimeout: 1
      pageLoadingWaitTimeout: 10
      downloadWaitTimeout: 15
      scriptWaitTimeout: 10
      deleteCookies: true
      defaultEventListenerEnabled: true
      grid:
      chrome:
      firefox:
      ie:
  
| Field                       | Type                                   | Description |
| ----------------------------|----------------------------------------|-------------|
| waitTimeout                 | int                                    | Seconds to wait when searching for an element
| pageLoadingWaitTimeout      | int                                    | Seconds to wait when loading a page
| downloadWaitTimeout         | int                                    | Seconds to wait when downloading a file
| scriptWaitTimeout           | int                                    | Seconds to wait when executing javascript
| deleteCookies               | boolean                                | Specifies if cookies must be deleted after each test |
| defaultEventListenerEnabled | boolean                                | Specifies if the default event listener is enabled |
| grid                        | [Grid](#grid)                          |  |
| chrome                      | [Chrome](#chrome)                      |  |
| firefox                     | [Firefox](#firefox)                    |  |
| ie                          | [InternetExplorer](#internet-explorer) |  |

!!! todo
    Add Edge support

#### Grid

    grid:
      url: https://sbox.internal.unicreditgroup.eu/wd/hub/
      capabilities: {}

| Field        | Type                      | Description  |
| -------------|---------------------------|--------------|
| url          | String                    | Url of the selenium grid
| capabilities | Map&lt;String, String&gt; | Map of capabilities to set when running on the grid

The following custom SBox capabilities are automatically added when running on a grid:

| Field                   | Type    | Description  |
| ------------------------|---------|--------------|
| e34:l_testName          | String  | Name of the current test
| e34:acceptInsecureCerts | boolean | set to true to avoid certs error on IE

!!! info
    If you want to run on SBox, you need to set the token as a grid capability.
    More info [here](#selenium-box-sbox)

#### Chrome

Chrome configuration. Possible values [here](https://chromedriver.chromium.org/capabilities)

    chrome:
      capabilities: {}
      arguments:
        - start-maximized
        - start-fullscreen
      experimentalOptions:
        useAutomationExtension: false
        prefs:
          download.prompt_for_download: false
          download.directory_upgrade: true
          safebrowsing.enabled: true

| Field               | Type                      |
| --------------------|---------------------------|
| capabilities        | Map&lt;String, Object&gt; |
| arguments           | List&lt;String&gt;        |
| experimentalOptions | Map&lt;String, Object&gt; |

#### Firefox

Firefox configuration. Possible values [here](https://developer.mozilla.org/en-US/docs/Web/WebDriver/Capabilities/firefoxOptions)

    firefox:
      binary: null
      args: []
      logLevel: INFO
      preferences:
        browser.download.folderList: 2
        browser.download.useDownloadDir: true
        browser.helperApps.neverAsk.saveToDisk: application/pdf
        pdfjs.disabled: true

| Field       | Type                      |
| ------------|---------------------------|
| binary      | String                    |
| args        | List&lt;String&gt;        |
| logLevel    | [FirefoxDriverLogLevel](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/firefox/FirefoxDriverLogLevel.html) |
| preferences | Map&lt;String, String&gt; |
          
#### Internet Explorer

Internet Explorer configuration. Possible values [here](https://github.com/SeleniumHQ/selenium/wiki/DesiredCapabilities#ie-specific)
Check also the [Internet Explorer paragraph](#internet-explorer-config) below.

    ie:
      capabilities: {}

| Field               | Type                      |
| --------------------|---------------------------|
| capabilities        | Map&lt;String, String&gt; |

### Selenium Logs

Selenium internal logging levels. [Javadoc](https://www.selenium.dev/selenium/docs/api/java/index.html?org/openqa/selenium/logging/LogType.html)

Each field is of type [java.util.logging.Level](https://docs.oracle.com/javase/8/docs/api/java/util/logging/Level.html).

    seleniumLogs:
      browser: SEVERE
      client: OFF
      driver: OFF
      performance: OFF
      profiler: OFF
      server: OFF

### Events

Events fired by the webDriver, automatically logged and added to the report.

Each field is of type [ch.qos.logback.classic.Level](http://logback.qos.ch/apidocs/ch/qos/logback/classic/Level.html).

    events:
      beforeAlertAccept: OFF
      afterAlertAccept: OFF
      afterAlertDismiss: OFF
      beforeAlertDismiss: OFF
      beforeNavigateTo: INFO
      afterNavigateTo: OFF
      beforeNavigateBack: OFF
      afterNavigateBack: OFF
      beforeNavigateForward: OFF
      afterNavigateForward: OFF
      beforeNavigateRefresh: OFF
      afterNavigateRefresh: OFF
      beforeFindBy: DEBUG
      afterFindBy: OFF
      beforeClickOn: DEBUG
      afterClickOn: OFF
      beforeChangeValueOf: DEBUG
      afterChangeValueOf: OFF
      beforeScript: OFF
      afterScript: OFF
      beforeSwitchToWindow: OFF
      afterSwitchToWindow: OFF
      onException: OFF
      beforeGetScreenshotAs: OFF
      afterGetScreenshotAs: OFF
      beforeGetText: OFF
      afterGetText: OFF

!!! warning
    The only supported values for ```events``` are: ```OFF```, ```DEBUG```, ```INFO```, ```WARN```.

---
## System properties

Here is the list of properties you can set as JVM directives. Each one must be written in the form ```-Dproperty=value```. 

!!! example
    ```-DreportName=myShinyReport.html```

| Name                                                  | Type    | Default Value                     | Description  |
| ------------------------------------------------------|---------|-----------------------------------|--------------|
| reportsFolder                                         | String  | target/selenium/reports           | Folder in which to save reports |
| reportName                                            | String  | report-[dd-MM-yyyy_HH-mm-ss].html | Full name (with .html extension) of the report. |
| env                                                   | String  | local                             | Environment under test |
| browser                                               | [Browser](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/enums/Browser.java) | chrome                            | Browser used in tests, can be: ```chrome```, ```firefox```, ```ie``` |
| downloadsFolder                                       | String  | target/downloads                  | Folder in which to store downloaded files |
| filesFolder                                           | String  | src/test/resources/files          | Folder where you put file to be check against the downloaded ones |
| grid                                                  | boolean | false                             | Set to ```true``` to run on a grid |
| logFilePath                                           | String  | target/selenium/logs              | Folder in which to save execution logs |
| logLevel                                              | Level   | INFO                              | Log level (org.slf4j.event.Level) |
| logColors                                             | boolean | true                              | Set to ```false``` to disable colored pattern in logs |
| junit.jupiter.execution.parallel.enabled              | boolean | false                             | Set to ```true``` to enable parallel run |
| junit.jupiter.execution.parallel.mode.default         | String  | same_thread                       | Set to ```concurrent``` to enable parallel execution of tests in same class |
| junit.jupiter.execution.parallel.mode.classes.default | String  | same_thread                       | Set to ```concurrent``` to enable parallel execution of test classes |
| downloadWebDriver                                     | boolean | true                              | Set to ```false``` to skip webDriver download |

!!! tip
    By default, a timestamp is appended to the report name. This is useful especially in CI environments, where you want to keep a history of all the executions.
    
    During development, it comes in handy to run with a fixed name like ```-DreportName=report.html```: in this way the report will be overwritten each time, 
    so that you can keep it open in a browser and just refresh the page.

---
## Environment Related Data

You may need to use different data on different environments. 
For example the user you must login with may differ from ```local``` to ```test``` environment.

To manage these differences, you can place a ```data.yaml``` file under the ```src/test/resources/data``` folder. 
In the same way as the ```configuration.yaml``` file, you can put in the base ```data.yaml``` the values that are the same across all the environments, 
and add a ```data-<ENV>.yaml``` for environment-specific data.

!!! example
    running tests with ```-Denv=local``` will make Nabu merge these three files in this order of precedence: 
    
    1. data-local.yaml
    1. data.yaml
    1. data.default.yaml

!!! tip
    If your team needs to have different local data for each developer, you can add this line to the ```.gitignore```:
    
        src/test/resources/configuration-local.yaml 

Here below you can see how your project structure would look like in case you have three environments (```local```, ```test```, ```uat```)
and you need to define custom configurations and data for each one: 

```
root
└─ src
|  └─ test
|     ├─ java
|     |  └─ eu.unicredit.xyz
|     |     ├─ models # Assuming your pojos go here
|     |     ├─ pages  # Assuming your pages go here
|     |     └─ tests  # Assuming your tests go here
|     └─ resources
|        ├─ data
|        |  ├─ data.yaml
|        |  ├─ data-local.yaml
|        |  ├─ data-test.yaml
|        |  └─ data-uat.yaml
|        ├─ configuration.yaml
|        ├─ configuration-local.yaml
|        ├─ configuration-test.yaml
|        └─ configuration-uat.yaml
├─ target
|  └─ selenium
|     |─ logs
|     |  └─ selenium.log
|     └─ reports
|        |─ screenshots
|        └─ report.html
└─ pom.xml
```

---
## Parallel Execution

If your test class extends ```NabuTest``` all test methods in it will share the same ```webDriver``` instance. If you want to avoid this behaviour 
and have a separate ```webDriver``` for each test, you should extend ```NabuTestParallel```. Let's see the implications of this:

- If a class extends ```NabuTest``` the test methods inside it will always run sequentially.
- If a class extends ```NabuTestParallel``` each test method inside it is eligible to run in parallel.

Depending on how you set the two ```system properties``` here below, you can have parallel classes and/or methods execution:

* junit.jupiter.execution.parallel.mode.default
* junit.jupiter.execution.parallel.mode.classes.default

Check the [system properties paragraph](#system-properties) to get how to set them and 
[JUnit's docs](https://junit.org/junit5/docs/current/user-guide/#writing-tests-parallel-execution) for more info  

!!! tip
    Mind that you can have some classes extending ```NabuTest``` and others extending ```NabuTestParallel``` at the same time, based on the tests inside them: 
    if they must run sequentially, for example because they affect the same section of the application and might cause race conditions,
    it's better for them to extend ```NabuTest```, so to share the same ```webDriver```. 
    
    In this way you ensure a serial run avoiding multple ```webDriver``` instantiation, which is indeed a heavy operation, resulting in a faster tests suite. 

---
## Reports

On each execution, Nabu produces two files: a log, and a html report.

### Log file

The log file will contain the same information you see in the console. 
It will be produced by default under the ```target/selenium/logs``` folder. 

It's generated using [Logback](http://logback.qos.ch/), 
and [here](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/resources/logback.xml) you can find its configuration.
Logs are rotated on a daily base, meaning the results of each execution occurred in the same day will be appended to the same file.

Among all the [slf4j log levels](http://www.slf4j.org/api/org/apache/log4j/Level.html),
Nabu leverages on the three below to provide you information with different granularity.
They are listed from the most inclusive, meaning each level will include all the others listed below it.

You can set it via the ```logLevel``` [system property](#system-properties).

| Level          | Description |
| ---------------|-------------|
| TRACE          | Internal Nabu's logging. Not recommended. |
| DEBUG          | Activate it to see what Nabu is doing behind the hood. |
| INFO (default) | Does this really need a description? |

!!! warning
    Changing the log level will affect the visibility of logs instructions you define in your tests as well.

!!! info
    By default, logs make use of a colored pattern, if you see some strange characters at the beginning of each line,
    you should check [this section](#logs).

### Html report

Nabu generates a html report using [Extent](https://extentreports.com/). By default, it will be produced under the ```target/selenium/reports``` folder.
You can see an example [here](../files/selenium/report.html).

As you can see in the screenshot here below, it's divided in three main sections:

![Report.html](../images/selenium/report.png)

1. The circle chart in the upper section shows the total number of tests executed, with partials on successful, skipped, failed etc...
1. The left column shows the list of all tests. For each one, you can see here the class name and the method name along with its status.
1. If you click on a test on the left column, in the right column appears the detail of that specific test execution.

You can customize its configuration by providing the values you can find [here](#extent).

#### Custom Look and Feel
You can also provide your own _Look and Feel_ by putting your css rules in a file named ```report.css``` in the ```src/test/resources/css``` folder.
Nabu will take care of loading it.

!!! example
    Providing this <a href="../../files/selenium/report.css" download>report.css</a>, when you take screenshots, the image will appear small on the right of the message,
    as you can see in the picture here below. This can be useful if you want to show a screenshot for each step you took in your test.

![Thx Devops Guest Role](../images/selenium/report-custom-laf.png)

---
## Objects injected by Nabu

There are several objects that Nabu injects automatically.
All of them have getters, so you can access their instance fields besides their methods in your tests.
This means you can use them in classes that extend ```NabuTest```, ```NabuTestParallel``` or ```NabuPage```:

- [webDriver](#webdriver-injected)
- [webDriverWaits](#webdriverwaits)
- [ngWebDriver](#ngwebdriver)
- [nabuUtil](#nabuutil)
- [configuration](#configuration-injected)
- [data](#data)
- [system properties](#systemproperties)
- [extentTest](#extenttest)
- [eventListener](#eventlistener)

### webDriver (injected)

An instance of EventFiringWebDriver, whose type is set by the ```browser``` system property 
and whose capabilities can be configured in the [webdriver](#webdriver) section of the ```configuration.yaml```.

Pojo [here](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/pojos/yamls/Webdriver.java).

### webDriverWaits

An object containing the reference to these [WebDriverWait](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/support/ui/WebDriverWait.html) objects:

- wait
- pageLoadingWait
- downloadWait
- scriptWait
- instantWait

These waits can be configured in the [application](#application) section of the ```configuration.yaml```.
They can come in handy when having to handle ExpectedConditions:

!!! example
    ```webDriverWaits.getWait().until(ExpectedConditions.invisibilityOf(spinner));```

Pojo [here](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/pojos/WebDriverWaits.java).

### ngWebDriver

Many applications nowadays make heavy use of _ajax_ requests to update the data shown in page.
The asynchronous nature of ajax calls make it hard to test the application with Selenium, since part of the DOM is usually rewritten 
as a consequence of the ajax callback, and this might in turn result in a ```StaleElementException```.
Check [this paragraph](#wait-sleep-and-exceptions) in the best practices section to understand how to manage this situation using ```ExpectedConditions```.

For Angular applications, Nabu injects also an instance of [ngWebDriver](https://github.com/paul-hammant/ngWebDriver).
Mind that the name is misleading: ngWebDriver is indeed a utility class that provides some utility methods to interact with an Angular application, 
not a real webDriver. This means that ```ngWebDriver``` doesn't replace ```webDriver```: you can work with both.

Mind also that NgWebDriver injects a lot of javascript code into the page, in order to inspect the status of the application from inside.
But injecting Javascript is a [bad practice](#javascript-injection).

In conclusion, you can test your Angular application by using just
the Java methods provided by the ```webDriver``` object, but in case you want to use ```ngWebDriver```, you can directly use the one injected by Nabu.

!!! info
    Don't be fooled by things like:
    
    - "...but my frontend is made in Angular, I cannot test it with Java"
    - "...but my frontend is made in Angular, and I get ```StaleElementException```"
    - "...but...".
    
    Those are just excuses: if your test is well written, you don't need anything else than the ```webDriver``` methods.
    Using ```ngWebDriver``` alone won't solve your problems. Good coding practices will.
    
    A test is just code. Good code means good test. 😉

### nabuUtil

An object that exposes some utility methods which you can call programmatically in your tests:

- ```infoWithScreenshot```: adds a screenshot to the report with a INFO message.
- ```debugWithScreenshot```: adds a screenshot to the report with a DEBUG message.
- ```errorWithScreenshot```: adds a screenshot to the report with an ERROR message.
- ```deleteDownloadsFolder```: automatically called in beforeAll hook.
- ```checkDownloadedFile```: checks a downloaded file using the ```downloadWaitTimeout```

    !!! example
        Assuming the application under test lets the user download a file named *dummy.pdf*, 
        to check whether the downloaded file is right, 
        put the expected file in the files folder (which defaults to ```src/test/resources/files```) and test it like this:   
        
            yourPage.getDummyPdfDownloadLink().click();
            assertTrue(nabuUtil.checkDownloadedFile(webDriverWaits, "dummy.pdf"));

Pojo [here](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/util/NabuUtil.java).

### configuration (injected)

An object that exposes Nabu's configuration, which are the values you provided explicitly merged with the defaults.
See the [configuration](#configuration) section.

Pojo [here](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/pojos/Configuration.java).

### data

An object that exposes the data specified in the ```data.yaml``` in an instance of the [Data](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/client/Data.java)
object. This object is made to be overridden from the client side. Indeed, you should create the ```eu.unicredit.thx.nabu.client``` package
and the ```Data``` class in it, providing just the fields and the getters.

!!! example
    if this is the content of your ```data.yaml```:
    
        tu:
          username: Ada
          password: secret
          
        key: value
        intKey: 123
        
    You should map it to this Data object:
    
        package eu.unicredit.thx.nabu.client;
        
        import lombok.Getter;
        
        @Getter
        public class Data {
            private Tu tu;
            private String key;
            private int intKey;
        
            @Getter
            public static class Tu {
                private String username;
                private String password;
            }
        }
        
    !!! tip
        This is just an example, if your data object gets complex, it's better for the ```Tu``` class and all the others you may need to be regular
        classes in their own files. 
    
    You can then retrieve the values in your tests like this:
    
        data.getTu().getUsername();
        data.getTu().getPassword();
        data.getKey();
        data.getIntKey();

### extentTest

An instance of [ExtentTest](http://extentreports.com/docs/javadoc/com/aventstack/extentreports/ExtentTest.html). 
You can call its methods to add info to the html report.

### eventListener

An instance of [WebDriverEventListener](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/support/events/WebDriverEventListener.html)
that is automatically registered on the ```webDriver``` to log events fired when interacting with the application under test.

The log level of each event can be configured as specified in the [events](#events) paragraph.

### systemProperties

An object that exposes the [system properties](#system-properties) used to run the tests.

---
## NabuPage

Each of your page extending ```NabuPage``` inherits these utility methods:

- ```public void open```:
    
    Executes a get call concatenating the ```baseUrl``` defined in the [application section](#application) of your configuration
    and the value of the ```@Endpoint``` annotation on the page itself.
    
    This method will call the ```waitForPageLoading``` before returning.
    
    !!! example
        If you have this configuration:
        
            application:
              baseUrl: https://my.app.unicreditgroup.eu/
              
        and your ```NabuPage``` is annotated with:
        
            @Endpoint("home-page")
            
        the ```open``` method will perform a ```GET https://my.app.unicreditgroup.eu/home-page```
    
- ```public void waitForPageLoading```
    
    The default implementation of this method prints a warning. You should override it providing some condition to be applied before considering a page loaded.
    
    !!! example
        You should provide some ```ExpectedConditions``` like the one here below:
        
            @FindBy(className = "spinner")
            private WebElement spinner;
            
            @Override
            public void waitForPageLoading() {
                webDriverWaits.getPageLoadingWait().until(webDriver -> !spinner.isDisplayed());
            }

- ```public boolean isLoaded```

    Checks if the current url matches the one defined by the concatenation of the ```baseUrl``` defined in the [application section](#application) 
    of your configuration and the value of the ```@Endpoint``` annotation on the page itself.
    
    !!! example
        If you have this configuration:
                
            application:
              baseUrl: https://my.app.unicreditgroup.eu/
              
        and your ```NabuPage``` is annotated with:
        
            @Endpoint("home-page")
            
        the ```isLoaded``` method will return true if the current url is ```https://my.app.unicreditgroup.eu/home-page```

---
## Custom Event Listener

By default, Nabu starts with an event listener that logs each event in both the logback appenders and the html report,
as specified by the [events node](#events) in your ```configuration.yaml```.
If you want to disable this event listener, you can set the ```defaultEventListenerEnabled``` flag to ```false``` in the [webdriver node](#webdriver).

Furthermore, you can register one or more custom event listeners to implement your own business logic upon events fired by the ```webDriver```.

!!! example
    Let's say you want to add a screenshot to the report before clicking on ```webElements```.
    You can create an ```WebDriverEventListener``` like the one here below, implementing just the ```beforeClickOn``` method.
    
        package eu.unicredit.xyz.listeners;
        
        import eu.unicredit.thx.nabu.interfaces.TakesScreenshots;
        import eu.unicredit.thx.nabu.util.NabuUtil;
        import lombok.Builder;
        import org.openqa.selenium.By;
        import org.openqa.selenium.OutputType;
        import org.openqa.selenium.WebDriver;
        import org.openqa.selenium.WebElement;
        import org.openqa.selenium.support.events.WebDriverEventListener;
        
        @Builder
        public class MyEventListener implements WebDriverEventListener {
        
            private NabuUtil nabuUtil;
            private TakesScreenshots takesScreenshots;
        
            @Override
            public void beforeAlertAccept(WebDriver webDriver) { }
        
            @Override
            public void afterAlertAccept(WebDriver webDriver) { }
        
            @Override
            public void afterAlertDismiss(WebDriver webDriver) { }
        
            @Override
            public void beforeAlertDismiss(WebDriver webDriver) { }
        
            @Override
            public void beforeNavigateTo(String s, WebDriver webDriver) { }
        
            @Override
            public void afterNavigateTo(String s, WebDriver webDriver) { }
        
            @Override
            public void beforeNavigateBack(WebDriver webDriver) { }
        
            @Override
            public void afterNavigateBack(WebDriver webDriver) { }
        
            @Override
            public void beforeNavigateForward(WebDriver webDriver) { }
        
            @Override
            public void afterNavigateForward(WebDriver webDriver) { }
        
            @Override
            public void beforeNavigateRefresh(WebDriver webDriver) { }
        
            @Override
            public void afterNavigateRefresh(WebDriver webDriver) { }
        
            @Override
            public void beforeFindBy(By by, WebElement webElement, WebDriver webDriver) { }
        
            @Override
            public void afterFindBy(By by, WebElement webElement, WebDriver webDriver) { }
        
            @Override
            public void beforeClickOn(WebElement webElement, WebDriver webDriver) {
                nabuUtil.infoWithScreenshot(takesScreenshots, "Clicking on " + extractSelectorFrom(webElement));
            }
        
            @Override
            public void afterClickOn(WebElement webElement, WebDriver webDriver) { }
        
            @Override
            public void beforeChangeValueOf(WebElement webElement, WebDriver webDriver, CharSequence[] charSequences) { }
        
            @Override
            public void afterChangeValueOf(WebElement webElement, WebDriver webDriver, CharSequence[] charSequences) { }
        
            @Override
            public void beforeScript(String s, WebDriver webDriver) { }
        
            @Override
            public void afterScript(String s, WebDriver webDriver) { }
        
            @Override
            public void beforeSwitchToWindow(String s, WebDriver webDriver) { }
        
            @Override
            public void afterSwitchToWindow(String s, WebDriver webDriver) { }
        
            @Override
            public void onException(Throwable throwable, WebDriver webDriver) { }
        
            @Override
            public <X> void beforeGetScreenshotAs(OutputType<X> outputType) { }
        
            @Override
            public <X> void afterGetScreenshotAs(OutputType<X> outputType, X x) { }
        
            @Override
            public void beforeGetText(WebElement webElement, WebDriver webDriver) { }
        
            @Override
            public void afterGetText(WebElement webElement, WebDriver webDriver, String s) { }
        
            protected String extractSelectorFrom(final WebElement webElement) {
                final String selector = webElement.toString().split("->\\s", 2)[1];
                return selector.substring(0, selector.length() - 1).replace("]]", "");
            }
        }
        
    You will then instantiate it in a ```@BeforeAll``` hook with the lines here below.
    
        webDriver.register(MyEventListener.builder()
                .nabuUtil(nabuUtil)
                .takesScreenshots(this)
                .build());

!!! tip
    If you need a reference to whatever is configured by Nabu, such as the ```configuration```, the ```extentTest```
    or [any other object automatically injected](#objects-injected-by-nabu) in your tests, 
    just declare them as instance fields in your custom event listener and pass the actual instance to the builder,
    in the same way as we did for ```nabuUtil``` in the above example.

---
## Best Practices

In this section you'll find some useful tips to apply as best practices, together with some other to avoid 
in order to write tests that are **fast**, **reliable** and **reusable**.

Mind that these are general practices that can be applied to any Selenium test, they aren't specifically related to Nabu. 
Still, it's worth mentioning them, since no framework will help you write better tests: it's all about code and how you write it. 

### Page Object Model

In the [example above](#how-to-use-nabu), our test involved two classes:

1. the test class itself
1. a class modeling the HomePage of SBox

We made this by following the [Page Object Model](https://www.selenium.dev/documentation/en/guidelines_and_recommendations/page_object_models/) 
design pattern, which consists in separating your code in two main categories:

1. **The tests classes** that will contain just the **flow logic** and the **assertions**.
1. **The pages** that will contain the **web elements** of the application and some **service methods**.

!!! example
    Let's say you want to test a page where you can search books. You should split your code like this, having one test class and one page:

    1. Test:
    
            searchPage.open();
            searchPage.searchBook("Moby Dick");
            
            assertEquals("Moby Dick", searchPage.getTitles().get(0).getText());
            assertEquals("20 €", searchPage.getPrices().get(0).getText());
            assertEquals("Novel", searchPage.getGenres().get(0).getText());   // "Novel" should actually be mapped to a Genre enum. Don't forget the basics! 
            assertEquals("Herman Melville", searchPage.getAuthors().get(0).getText());
            
    1. SearchPage:
    
            @FindBy(id = "searchInputField")
            private WebElement searchInputField;
            
            @FindBy(id = "searchButton")
            private WebElement searchButton;
            
            @FindBy(className = "title")
            private List<WebElement> titles;
            
            @FindBy(className = "price")
            private List<WebElement> prices;
            
            @FindBy(className = "genre")
            private List<WebElement> genres;
            
            @FindBy(className = "author")
            private List<WebElement> authors;
            
            // Service methods
            public void open() {
                webDriver.get("https://my-app/search-books");
            }
            
            public void searchBook(String title) {
                searchInputField.sendKeys(title);
                searchButton.click();
                
                waitForPageLoading();   // see below
            }

!!! tip
    Mind that a _page_ in this context doesn't have to be a one-to-one representation of a web page.
    
    For example, if your application has a menu bar which is displayed in every page, you can map its web elements to a separate page,
    avoiding redundant code.
    
    How you map your web pages to classes it's up to you and your specific needs.

### Wait, sleep and exceptions

When developing Selenium tests, one of the main things developers usually struggle with is the location of elements in the page:
often, the test fails because you asked the webDriver to do something on an element that isn't yet displayed or interactable with.

For example, you search the books and immediately want to check the results. If the search requires some time to be completed,
this will result in an error: Selenium will complain with something like "you asked me to click on a button, but I wasn't able to do that
because there was the spinner overlay above it".

The two main _enemies_ here are:

- **NoSuchElementException** tells that the requested element is not present in the DOM
- **StaleElementException** tells that the requested element is no more attached to the DOM

There are many bad practices that are often used as workarounds to these exceptions:

1. Raising the wait time. In Nabu this can be set in the [application](#application) section of the ```configuration.yaml```.
1. Using ```Thread.sleep()```.
1. Catching the exceptions above and implementing some retry logic in the catch block.

The reason to avoid these bad practices is that a Selenium test should mimic a real user navigating through your application.
A real user would never sleep for a fixed amount of time or clicking obsessively on a button until it works as expected.
Instead, a real user would wait for deterministic conditions to be satisfied before going on.
In the books search example, after searching for a title, the user would wait for the spinner to disappear before doing any other operation.

This is exactly what your test **must** do: check deterministic conditions before trying to locate and interact with elements 
that may not yet be in the page. In this way, your test will be robust.
You can achieve this by leveraging on [ExpectedConditions](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/support/ui/ExpectedConditions.html).

Integrating the books search example, you can implement a ```waitForPageLoading``` function, to be called after clicking the search button.

!!! example 
    
            @FindBy(id = "spinner")
            private WebElement spinner;
        
            public void waitForPageLoading() {
                webDriverWaits.getWait().until(ExpectedConditions.invisibilityOf(spinner));
            }

On the other hand, if you just go with workarounds, you test will surely break from time to time, becoming [flaky](https://docs.gitlab.com/ee/development/testing_guide/flaky_tests.html#whats-a-flaky-test).

Another negative aspect of those workarounds is that the performance of your test will get much worse.
You can imagine what applying a workaround that slows your test down will lead to in a suite made up of many tests:
you'll soon end up with an **hour-long running suite**!

So let's see in detail why the three practices above are bad and **must** be avoided:

1. If you raise the wait time, under the hood Selenium will continuously poll the element, resulting in a hidden sleep timeout.
1. ```Thread.sleep()``` is bad because a user would never sleep for a fixed amount of time.
1. Catching exception is nowadays considered a bad practice, because it breaks the normal flow of your code, 
resulting in a _de facto_ **jump instruction**. Moreover, both ```NoSuchElementException``` and ```StaleElementException``` are runtime exceptions, 
which are not even meant to be caught.

!!! tip
    Repeat with me:
    
    "**I will be a good developer**".
    
    "**I won't use workarounds**".
    
    "**I will write tests that are fast, reliable and reusable**". 😃
    
### Javascript injection

Selenium lets you inject javascript code in the application by calling the methods of the [JavascriptExecutor interface](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/JavascriptExecutor.html),
which is implemented by the [EventFiringWebDriver](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/support/events/EventFiringWebDriver.html) class,
so by the ```webDriver``` instance Nabu injects in your tests.

Even though this is permitted, it's a bad practice to run native javascript on the application, since in this way you're actually
changing the frontend code, thus changing the behavior of the application from the inside.

Always remember that a Selenium test should mimic the actions of a real user, and a real user (well, at least a non-developer user)
would never inject some random javascript code in the page.

### Data Driven Testing

[Data Driven Testing](https://en.wikipedia.org/wiki/Data-driven_testing) is a methodology that implies running the same test several times
by providing different set of inputs.

If we think about the [test pyramid](https://martinfowler.com/articles/practical-test-pyramid.html), we should have a large base of unit tests
and just few e2e. Unit tests are the ones where we should do DDT, covering edge cases as well. 
On the other hand, Selenium and e2e tests in general should be focused on testing functionalities at a high level, in a flow that involves 
different sections of the application.

!!! example
    Let's say you want to test a page where you can search books.
    
    You should test the ```search``` method with many unit tests, going for:
    
    - a key that returns 0 results
    - a key that returns 1 result
    - a key that returns many results
    - a key with special characters
    - an invalid key
    - no key (empty search)
    
    These will actually result in the execution of the same test with different inputs. So this is a so called Data Driven Test.
    
    You should avoid repeating all these cases with Selenium, but if you still need to test them, 
    maybe because you want to check how the UI changes upon different search results, it's better to avoid DDT anyway:
    this would indeed mean restarting the browser and redo all the steps that led you to the search page, 
    which may be a waste of time and resources.
    
    Instead of DDT, you should run a single e2e test that, once done all the steps (login and so on) to arrive at the search page, 
    tests the search functionality with different inputs.

If you still want to do Data Driven Testing, please refer to JUnit's [parameterized tests](https://junit.org/junit5/docs/current/user-guide/#writing-tests-parameterized-tests).

### Refactor is the way

The main goal of testing is to **raise the quality** of the product being tested.
Testing an application means that the application actually **is** testable.
At a high level, this means:

- for Unit Tests, the code must be well organized in single-responsibility classes and atomic methods.
- for E2E Tests, the presentation layer should be structured in a way that eases the location of elements with which to interact.

For what concerns unit tests, the ideal process is to develop new code in a [Test Driven](https://en.wikipedia.org/wiki/Test-driven_development) fashion.
This will help you write code that is itself testable, since you write the test as first thing, but is also easily mockable 
when testing other objects depending on it.

For what concerns e2e tests, since we are interacting with the full up&running application, it's all about the presentation layer.
You should always provide some unique locator that will let Selenium find the web elements easily.
Check the [locators paragraph](#locators) below.

If the two bullets above don't apply to the code you're testing, instead of struggling with horrible workarounds in order to test it,
you should be **ready to refactor** it.

This shouldn't be part of this documentation, but it's worth to say it: **refactoring to make your code testable is not a cost, it's an added value**.
If you test untestable code, you'll waste time struggling and producing tests that maybe covers your code, without bringing a real value.

!!! tip
    Repeat with me:
    
    "**I will be a good developer**".
    
    "**I won't use workarounds**".
    
    "**If the source code is untestable, I will refactor it**". 😃

### Locators

There are several ways to locate elements in Selenium, as specified by the ones provided by the [By](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/By.html) class.

The best way to locate an element is of course by using a unique locator like the html ```id``` attribute.
If you don't want to use ids, you should provide another unique locator, using for example the html [data- attributes](https://www.w3schools.com/tags/att_data-.asp).
The convention is to use the ```data-qa``` attribute. See also the [Using custom locators paragraph](#using-custom-locators) below.

One bad practice to avoid is to use the ```XPath``` locator: ```XPath``` is the slowest one, since Selenium has to traverse the DOM to find the element,
and it's not reliable: a locator like ```table > tr > td > div:nth-child(2) > a > span``` means your test will break if a frontend developer
makes even a small change on that html structure.

If you find yourself using ```XPath``` as locator, it means you should go back reading the [Refactor is the way](#refactor-is-the-way) paragraph!

#### Using custom locators

If you decided to use some custom locator, for instance some html [data- attribute](https://www.w3schools.com/tags/att_data-.asp),
you will then use the [css attribute selector](https://www.w3schools.com/cssref/sel_attribute_value.asp)
as argument of the ```@FindBy``` annotation.

Supposing you chose ```data-qa```:

    @FindBy(css = "[data-qa=search-input]")
    private WebElement searchInput;

To improve readability, you can also extend the [By](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/By.html) class,
providing a ```By.ByDataQa``` locator to be used like this:

    @FindBy(dataQa = "search-input")
    private WebElement searchInput;
    
This will help you avoid stupid typos in the string literal as well.

---
## Dependencies

Nabu brings with it some dependencies you might find useful:

- [Lombok](https://projectlombok.org/)
- [Hamcrest](http://hamcrest.org/JavaHamcrest/)
- [Apache Commons IO](http://commons.apache.org/proper/commons-io/)
- [Guava](https://github.com/google/guava)
- [Extent](https://extentreports.com/)
- [WebDriverManager](https://github.com/bonigarcia/webdrivermanager/blob/master/README.md)
- [NgWebDriver](https://github.com/paul-hammant/ngWebDriver)

!!! tip
    Check [Nabu's pom](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/pom.xml) for a full reference:
    you can use each of Nabu's dependency directly in your project, don't duplicate them in your pom. Be a *DRY* developer, not a *WET* one! 

---
## Running on a Grid

Selenium tests can run locally and remotely. While the former way is preferred when developing, the latter is useful in some other situations, for example:

- you want to run a test on a browser/version you don't have on your local machine (i.e. you are on linux and you need Internet Explorer...
it's your choice, I won't discuss...😃)
- in CI environments, where the machine where you run the tests doesn't have a graphic context, and you still want to run on a real browser

To run remotely you need to point to a *selenium grid*, which is nothing more than a server that accepts requests to run tests, 
and forwards them to *executor nodes* (machines where the browser, and so your test, will actually run). 

When you point to the grid, the capabilities you chose (so the webDriver) will be wrapped in a [RemoteWebDriver](https://www.selenium.dev/selenium/docs/api/java/org/openqa/selenium/remote/RemoteWebDriver.html)
instance that will communicate with the grid.

In this scenario, the actors involved in running a test are three:

- **the client** (i.e. your pc) that will execute the test and send webDriver instructions to the grid hub.
- **the grid hub** that will forward the instructions to an executor. This choice is based on the capabilities you requested.
- **the executor node** that will run the instructions on the browser and send the results back to the grid and in turn to the client.

![Grid](../images/selenium/grid.png)

Even if they're conceptually separated, all these three actors can actually run on the same machine. Indeed you can setup a local grid in few minutes:

1. download the [Selenium server (Grid)](https://www.selenium.dev/downloads/)
1. Start the grid hub running the jar you just downloaded with
    
        java -jar selenium-server-standalone.jar -role hub
        
1. Start the executor running the same jar with

        java -jar selenium-server-standalone.jar -role node -hub http://localhost:4444

At this point your local machine is the client, the hub and the executor at the same time.
You can find more info [here](https://www.selenium.dev/documentation/en/grid/setting_up_your_own_grid/).

### Selenium Box (SBox)

[SBox](https://sbox.internal.unicreditgroup.eu/ui/about) is the Unicredit's internal grid. To run your tests against it you need 
to point to ```https://sbox.internal.unicreditgroup.eu/wd/hub/```, which is the default grid url in Nabu.

!!! warning
    Sbox requires a token to ensure you are granted to run tests against it. Without providing a valid one, you'll get an error like:
    
    ```org.openqa.selenium.SessionNotCreatedException: A test token needs to be provided via the e34:token capability.```
    
    You can generate a token for your project [here](https://sbox.internal.unicreditgroup.eu/ui/test-projects/selfservice).
    Login with your LDAP credentials.
    
!!! warning
    If you get this error when running on SBox:
    
    ```sun.security.validator.ValidatorException: PKIX path building failed: sun.security.provider.certpath.SunCertPathBuilderException: unable to find valid certification path to requested target```

    It means the JRE you're using doesn't have the Unicredit's internal root CA in its path,
    so it doesn't trust the certificates received when calling internal tools such as SBox.
    
    To solve this error, replace the ```[JRE path]/lib/security/cacerts``` with [this one](../../files/cacerts).
    
    Watch out that if you're using a JDK, the path to the cacerts is ```[JDK path]/jre/lib/security/cacerts```

!!! info
    More information can be found in the [SBox documentation](https://sbox.internal.unicreditgroup.eu/ui/documentation). 

#### Firewall rules

If your application is new to SBox it might happen that your test environment is not reachable. 
In this case you should [submit a tufin request](https://tufin.internal.unicredit.eu/securechangeworkflow/login.html):

1. hit the **New request** button 
1. choose **New firewall request** and hit **Create** button
1. compile the form like this:

    | Field                                | Value |
    | -------------------------------------|-------|
    | Subject                              | THX Prod to &lt;your application's AAM code&gt; |
    | Please select the subject reference  | AAM code |
    | Legal Entity Data Owner              | Ubis/Vts Architecture |

1. Fill the request details like this:

    | Field                        | Value |
    | -----------------------------|-------|
    | Source                       | 10.58.170.0/23 |
    | Destination                  | &lt;your servers or domain names&gt; |
    | Service/Application Identity | one or more ports of your service as in example ex. **TCP 4443** |
    | Comment                      | THX is a Testing tool that's why Prod environment of THX should point to non production environments of the target application |

1. Leave the rest of the fields as default and hit the **Submit** button

---
## Internet Explorer Config

Here we are: of course Internet Explorer requires spending some words on it.

Indeed, we need some [further configuration](https://github.com/SeleniumHQ/selenium/wiki/InternetExplorerDriver#required-configuration)
to run Selenium on this browser.
Read the linked docs carefully and apply the bullets you can, like setting the zoom level at 100% on the browser.

Since we cannot change some settings directly from Internet Explorer, as shown in the picture here below,
we need to set some other keys in ```regedit```.
<p style="text-align: center">
    ![Internet Options](../images/selenium/internet-options.png)
</p>

The keys in the first table here below are related to the _Current User_, and they should do the work.
If they're not enough, apply also the ones in the second table.
    
!!! example
    Let's see together how to set the first key:
    
    1. Type ```win``` + ```r```.
    1. Type ```regedit``` and press ```enter```.
    1. Copy-paste the ```Key``` in the nav bar at the top of the Registry Editor
    1. If the key is already present, check its ```Type``` and ```Data``` columns:
        - if they don't match with the expected ones, double click on it to edit.
        - if they match, go on with the next key.
    1. If the key is not present, right click on the right panel and add a new one with the right values.
    
    ![Regedit](../images/selenium/regedit.png)

Current User:

| Key | Name | Type | Data |
|:----|:-----|:-----|:-----|
| Computer\HKEY_CURRENT_USER\Software\Policies\Microsoft\Internet Explorer\Main | Isolation | REG_SZ | PMIL
| Computer\HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\0 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\1 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\2 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\4 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\0 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\1 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\2 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\4 | 2500 | REG_DWORD | 0 |

Local Machine:

| Key | Name | Type | Data |
|:----|:-----|:-----|:-----|
| Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Internet Explorer\Main | Isolation | REG_SZ | PMIL |
| Computer\HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\0 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\1 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\2 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3 | 2500 | REG_DWORD | 0 |
| Computer\HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\4 | 2500 | REG_DWORD | 0 |

!!! warning
    Don't forget we are talking about Windows: you can't say it didn't work if you didn't restart your pc! 😃

---
## Eclipse IDE

If you use Eclipse to develop your tests, in this section you may find some useful tips.

### Stacktrace

When running JUnit tests, Eclipse won't show errors in the console by default.

To see what went wrong during the execution,
you need to select the failing test in the **JUnit view** (which should open by default when running JUnit configuration).
You'll see the stacktrace in the **Failure trace panel** in the bottom.
If you want to show the stacktrace in the console view, you need to click the small button highlighted in the screenshot below.

Unfortunately, there doesn't seem to be a way to set this as default.

![Eclipse stacktrace](../images/selenium/eclipse-stacktrace.png)

### Logs

The Eclipse's default console doesn't support colored patterns for logs. Since by default Nabu makes use of a colored pattern,
you will see some strange characters at the beginning of each line, like shown in the screenshot here below:

![Eclipse logs](../images/selenium/not-supported-colors-log.png)

To solve this issue and see a plain black and white log as here below,
simply set to ```false``` the ```logColors``` [system property](#system-properties).

![Eclipse black and wait logs](../images/selenium/no-colors-log.png)

!!! tip
    Mind that this is valid for each output terminal which doesn't support colors, like Jenkins' log, for instance.

---
## Apps using Nabu

Currently, these are the applications using Nabu to write E2E tests:

- [UB5 - PreSales Advisor Tool](https://mlx-us.intranet.unicredit.it/MLX-EBA-PF/home/application/applicationView.jsf?id=fdf2ff20-811f-4891-b423-46f06b3992fb)
- [OAC - openaccount.intranet.unicredit.it](https://mlx-us.intranet.unicredit.it/MLX-EBA-PF/home/application/applicationView.jsf?id=e6277005-5560-47d2-a2ae-94cf6b1993b9)
- [QRL - internet relaunch](https://mlx-us.intranet.unicredit.it/MLX-EBA-PF/home/application/applicationView.jsf?id=D100000000180034AB)
- [GT0 - CAD - SECURITIES](https://mlx-us.intranet.unicredit.it/MLX-EBA-PF/home/application/applicationView.jsf?id=D100000000780FB736)
- [UB4 - Underwriting Revolution Small Business](https://mlx-us.intranet.unicredit.it/MLX-EBA-PF/home/application/applicationView.jsf?id=1eed2c16-f0a7-4d83-9571-13dd2eba8c5e)
---
## Contacts

Feedback, suggestions, bug reports, lost your keys? Join the [Nabu team](https://teams.microsoft.com/l/team/19%3a564b2b90b3b444ec8cc8800073589bad%40thread.tacv2/conversations?groupId=c0a7bb9c-bb7d-404a-90e8-826632e0f706&tenantId=2cc49ce9-66a1-41ac-a96b-bdc54247696a)
and post in the proper channel:

- [Community Support Channel](https://teams.microsoft.com/l/channel/19%3a8f6ffd4780604b718df93572380f2908%40thread.tacv2/community-support?groupId=c0a7bb9c-bb7d-404a-90e8-826632e0f706&tenantId=2cc49ce9-66a1-41ac-a96b-bdc54247696a) for support requests.
- [Feedback Channel](https://teams.microsoft.com/l/channel/19%3ae79b072e4c084c1796f57919cec7c936%40thread.tacv2/feedback-nabu?groupId=c0a7bb9c-bb7d-404a-90e8-826632e0f706&tenantId=2cc49ce9-66a1-41ac-a96b-bdc54247696a) for feedbacks, suggestions, and improvements.

