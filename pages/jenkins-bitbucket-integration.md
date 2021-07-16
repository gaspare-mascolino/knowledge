# Jenkins and BitBucket integration

Jenkins and BitBucket are fully integrated.
The pipelines are created automatically when a Jenkinsfile is pushed into the root of a Bitbucket repository.

## Jenkins repositories and branches sync
Jenkins sync repositories and branches daily.
You can force the synchronization by pressing the `Scan organization folder now` button.  
In order to check the logs of the scan you can press `Scan Organization Folder Log` button.  
[//]: # (![Organization Folder](../images/organization-folder.png))
<p align="center">
  <img width="348" height="253" src="../images/organization-folder.png">
</p>

## Jenkins Accessibility & firewall rules

If your application server should be called directly by Jenkins or vice versa,
you should [submit a tufin request](https://tufin.internal.unicredit.eu/securechangeworkflow/login.html) 
based on which one is the source and which is the target:

### From Jenkins to your Servers

1. hit the **New request** button 
1. choose **New firewall request** and hit **Create** button
1. compile the form like this:

    | Field                                | Value |
    | -------------------------------------|-------|
    | Subject                              | JXP Prod to &lt;your application's AAM code&gt; |
    | Please select the subject reference  | AAM code |
    | Legal Entity Data Owner              | Ubis/Vts Architecture |

1. Fill the request details like this:

    | Field                        | Value |
    | -----------------------------|-------|
    | Source                       | 10.41.21.0/25 |
    | Destination                  | &lt;your servers or domain names&gt; |
    | Service/Application Identity | one or more ports of your service as in example ex. **TCP 4443** |

1. Leave the rest of the fields as default and hit the **Submit** button

### From your Servers to Jenkins

1. hit the **New request** button 
1. choose **New firewall request** and hit **Create** button
1. compile the form like this:

    | Field                                | Value |
    | -------------------------------------|-------|
    | Subject                              | &lt;your application's AAM code&gt; to JXP Prod |
    | Please select the subject reference  | AAM code |
    | Legal Entity Data Owner              | Ubis/Vts Architecture |

1. Fill the request details like this:

    | Field                        | Value |
    | -----------------------------|-------|
    | Source                       | &lt;your servers or domain names&gt; |
    | Destination                  | <ul><li>10.41.21.23</li><li>10.41.21.24</li><li>10.41.21.25</li></ul> |
    | Service/Application Identity | TCP 443 |

1. Leave the rest of the fields as default and hit the **Submit** button

## Pipeline configuration merge

In order to exclude _**devops/configuration.yaml**_ file to be merged between branches, pull requests etc
a git merge strategy must be used.

In details, you should create a .gitattributes file inside project root with the following content:

```
devops/configuration.yaml merge=ours
Jenkinsfile merge=ours
```

[More info](https://git-scm.com/docs/merge-strategies/2.4.9)


