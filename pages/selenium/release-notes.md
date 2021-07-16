# Release Notes

Since Nabu is built with a Jenkins pipeline, each time a new patch version is released, a notification will be automatically pushed in
[this Mattermost channel](http://mmtdev01.internal.unicreditgroup.eu/devops/channels/release-notes-nabu).
Join it to be always up to date with the newest features!

!!! wip
    The notification message is just a placeholder, as of now. In the future it will be enriched with some info related to the release note.

## Nabu 1

### Version 1.1

#### 1.1.2
```Released on 28/07/2020```

- Injecting ```systemProperties``` pojo in NabuPages alongside the other [injected objects](e2e-test-selenium.md#objects-injected-by-nabu). 
- Better logging, introducing TRACE level. Check the [log file section](e2e-test-selenium.md#log-file).
- Added the ```logColors``` boolean system property to disable the color pattern. 
Useful when printing messages to consoles that don't interpret colors, like Eclipse's or Jenkins'. 
See [system properties](e2e-test-selenium.md#system-properties).
- Minor fixes and improvements.

---
#### 1.1.1
```Released on 29/06/2020```

- Added the ```defaultEventListenerEnabled``` flag in the [webdriver](e2e-test-selenium.md#webdriver) node of the ```configuration.yaml```.
- Added a log at INFO level in the ```afterAll``` hook that prints the path to the produced html report.
- Added ```systemPropertiesResolver``` to inject the [systemProperties](e2e-test-selenium.md#systemproperties) field in tests.

---
#### 1.1.0
```Released on 26/06/2020```

- Moved wait timeouts from [application](e2e-test-selenium.md#application) to [webdriver](e2e-test-selenium.md#webdriver) in the ```configuration.yaml```.
- The ```data.yaml``` is now unmarshalled into an instance of [data](e2e-test-selenium.md#data) object, instead of a regular HashMap. In this way,
  you can define complex pojos on client side, instead of managing plain strings. See the linked docs for details.
- It's now possible to define env-related files without providing the general ones, for instance:
  you can provide the ```data-preprod.yaml``` and/or ```configuration-preprod.yaml``` without providing ```data.yaml``` and ```configuration.yaml```
- Added ```@Endpoint``` annotation to specify a ```NabuPage```'s endpoint
- Smaller text in the left column of the html report
- Added ```e34:acceptInsecureCerts``` to [SBox capabilities](e2e-test-selenium.md#grid)

---
### Version 1.0

#### 1.0.11
```Released on 16/06/2020```

- Widened the visibility of ```eventListener``` field of [BaseNabuTest](https://bitbucket.internal.unicreditgroup.eu/projects/THX/repos/nabu/browse/src/main/java/eu/unicredit/thx/nabu/util/BaseNabuTest.java) 
to protected.
- Fixed minor bug on Firefox grid capabilities.

---
#### 1.0.10
```Released on 09/06/2020```

- Nabu's artifactId is now UPPERCASE, to match Gandalf subsystem rules:

        <dependency>
            <groupId>eu.unicredit.thx</groupId>
            <artifactId>NABU</artifactId>
            <version>1.0.10</version>
            <scope>test</scope>
        </dependency>

- Added the ```deleteCookies``` field to the [Webdriver pojo](e2e-test-selenium.md#webdriver).
It specifies if cookies must be deleted after each test, so to run each test with a clean session.

| Field         | Type    | Default |
| --------------|---------|---------|
| deleteCookies | boolean | true    |

- Added the ```scriptWaitTimeout``` field to the [Application pojo](e2e-test-selenium.md#application).
It specifies the number of seconds to wait when executing a javascript on the page. If that timeout is exceeded, a ScriptTimeoutException is thrown. 

| Field             | Type | Default |
| ------------------|------|---------|
| scriptWaitTimeout | int  | 10      |

---
