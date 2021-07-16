
# It's a wild world out there
In order to grant us the possibility to be able to provide a proper service, your application must satisfy the following
 requirements (
 [🥈](prerequisites.md#ldap)
 [🥉](prerequisites.md#git-stuff-done)).

## LDAP 🥈

To proceed any further you need to have requested and obtained the following LDAP groups:

| Description | LDAP group |
|---|---|
| Product Manager | `JYYXXX_DEVOPS_PM`[^1] |
| Developer | `JYYXXX_DEVOPS_DEV`[^1] |
| Guest | `JYYXXX_DEVOPS_GUEST`[^1] |  

Where YY is the legal entity and XXX is the AAM code of the application.  

In order to obtain those, for each of the group, use [Archimede](https://archimede.internal.unicredit.eu/UC.QES.ELSA/default.aspx)
as the following sections suggest.

### Create the LDAP groups
First select the right voice from the menu
<p align="center">
  <img src="../images/archimede-group-create1.png">
</p>

just click on `Next`
<p align="center">
  <img src="../images/archimede-group-create2.png">
</p>

fill all the details required as per the table above
<p align="center">
  <img src="../images/archimede-group-create3.png">
</p>

<p align="center">
  <img src="../images/archimede-group-create4.png">
</p>

then click on `Next` and then, in the next window, on `Submit`. You should receive an email once the group will be
created.

For a detailed guide on how to use [Archimede](https://archimede.internal.unicredit.eu/UC.QES.ELSA/default.aspx) please 
refer to the [tool's documentation](https://archimede.internal.unicredit.eu/UC.QES.ELSA/guide/Archimede_User_Guide_ENG.pdf).

### Being assigned to an LDAP group
Depending on your role in the project you might want to be added to one of the LADP group that we requested the creation
for in the previous section.

Once identified which is the group that better represents your role inside the project you can request to join it 
through [Archimede](https://archimede.internal.unicredit.eu/UC.QES.ELSA/default.aspx) as follows.

First open the right voice from the menu and just click on `Next`
<p align="center">
  <img src="../images/archimede-group-join1.png">
</p>

then you can select the beneficiary of the request you're going to create.
If you are requesting to join the LDAP group for yourself just click on `Next`, otherwise use the search functionality
to identify the right beneficiary.
<p align="center">
  <img src="../images/archimede-group-join2.png">
</p>

In the next form you have to specify all the requested information and then click `Next`.
<p align="center">
  <img src="../images/archimede-group-join3.png">
</p>

In the last view just review your request and `Submit` it. Simple as that 🍋.

## Git (stuff done 😜) 🥉

!!! note
    Be aware that we are migrationg this documentation to  [Confluence](https://confluence.intranet.unicreditgroup.eu/pages/viewpage.action?pageId=41369627)

The tool we chose to bring git into the UniCredit DevOps world is [BitBucket](https://bitbucket.org/product).

The usage of BitBucket is a prerequisite to be eligible in order to use Jenkins as a tool to guide our travel towards 
Continuous Integration and forward, as described in this guide.

!!! note 
    **Even if you're not ready yet to harness the limitless power of a CI/CD (you don't know what you're missing!), 
    you can still use BitBucket (git) as SCM tool.**
    
As first thing, once you've decided that you want to move your project to BitBucket and finally started your trip and
embrace the current century, you need to be sure that the three LDAP group, as described in the 
[prerequisites section above](prerequisites.md#ldap), has been created.

### How to request a project on BitBucket

Once obtained the groups, in order to get your project to be created on BitBucket and start creating repositories on it,
**you need to** :

- Log-in in [BitBucket](https://bitbucket.internal.unicreditgroup.eu/) in order to register the LDAP groups in the platform

- Ask for a provisioning using Ticket Online please follow dropdown menu *[Developer Topics -> BitBucket Git -> Onboarding request](https://webappars.intranet.unicreditgroup.eu/arsys/servlet/ViewFormServlet?form=UGIS:Global:TroubleTicket&view=GlobalBranchView_en&server=ars&mode=Submit&F536871059=59417)*

!!! note 
    Please specify in the request:

    - estimation of users that will be new in Bitbucket (the license is based on active users)
    - AAM code of your application
    - confirm that [LDAP groups](#ldap-groups-and-bitbucket-permissions) are active (and not only requested) in ARCHIMEDE and users has already active the grants to the groups

- We will create a BitBucket project for you, the name will be the same of the APP CODE you specified in the e-mail. You might be contacted in order to better define the nitty gritty details

- Once that request will be evaded you can start log-in yourself using your LDAP credentials
[directly on BitBucket](https://bitbucket.internal.unicreditgroup.eu/).

### LDAP groups and BitBucket permissions

Each of the LDAP group you've been creating following the [this section](prerequisites.md#ldap) is tied with particular
permissions on BitBucket.
In order to request to be part of an already created LDAP group refer to
[the specific section above](prerequisites.md#being-assigned-to-an-ldap-group).

Here's a table describing what a user being part of one of them can do.

| LDAP group | Permissions |
|---|---|
| `JYYXXX_DEVOPS_PM`[^1] | Admin, Write, Read |
| `JYYXXX_DEVOPS_DEV`[^1] | Write, Read |
| `JYYXXX_DEVOPS_GUEST`[^1] | Read |

Where the permissions are defined as follows

| Permission | Description |
|---|---|
| Admin | Can administer the project and create new repositories. Administrators have complete access to all repositories in the project. Can Merge Pull Requests (PRs). |
| Write | Can push to any repository within the project. All activities permitted by read access are granted to write users as well. Cannot merge Pull Requests (PRs). |
| Read | Can clone, browse and fork any repository within the project. Can create and contribute to pull requests targeting any of these repositories. |

!!! warning
    We are working to disable settings/permissions editing on Project area because the roles management is up to Archimede and the settings are handled with scripts. In the meantime <span style="color: red;">**ADMIN ROLE MUST NOT CHANGE PROJECT SETTINGS/PERMISSIONS**. The punishment is the removal of the eligibility for the BitBucket usage 🤡.</span>

### BitBucket the client side

BitBucket is a server side Git repo, so in order to correctly interact with him every team member should have a local Git instance.

How to have one?
If you have an internally managed device on Windows 10 you can follow these steps:

1. Open `Software Center` application
<p align="center">
  <img src="../images/git-client-installation-1.png">
</p>

2. In the searchbox at top-right type `gitscm` and press `Enter` tp search for the Git client
<p align="center">
  <img src="../images/git-client-installation-2.png">
</p>

3. Open the application page, click on `Install` and wait for the installation to finish.
<p align="center">
  <img src="../images/git-client-installation-3.png">
</p>

!!! note
    If you have a Windows 7 device or an unmanaged device, we advise you to download the official one from [Git Download  page](https://git-scm.com/download/win) and use the Windows 64\-bit portable version.
    After the download and unzip, please read the README.portable file in order to understand how to use it properly.

### Jenkins and BitBucket integration pills 💊

Here some tips and tricks on how the integration between Jenkins and BitBucket has been defined.

#### Jenkinsfile(s)

As [described in this section](quick-start.md#create-the-jenkinsfile), once you'll add a `Jenkinsfile` to your project
on BitBucket with the content provided, Jenkins will identify that project (and specific branch) as "buildable" and will 
start to execute the pipeline (its content) automagically ✨.

!!! warning
    At any time in the future we will develop an automatic check on the content of this file in order to avoid 
    unintended custom script execution.
    Be aware that at the present time we actively check those files and, if you are onboarding your project by yourself,
    <span style="color: red;">**YOU MUST NOT COMMIT ANY Jenkinsfile in your repository**.
    The punishment is the removal of the eligibility for the BitBucket usage 🤡.</span>

#### Special branches

In order to guarantee a check on what is going to be pushed in production, for each repository, we
promoted a branch to be **NOT** writable by the users outside the `JYYXXX_DEVOPS_PM`[^1] LDAP group for each application.

All the pipelines running having [the correct configuration](rabbit-hole.md#create-pull-request) and generated by users
being part of the `JYYXXX_DEVOPS_DEV`[^1] or `JYYXXX_DEVOPS_GUEST`[^1] LDAP groups will trigger a creation on the branch
specified.

### Further and useful pointers

Here you can find some external articles you might find useful if you're new to Git.

#### [Git and the SDLC](https://www.atlassian.com/agile/software-development/git)

#### [Branching](https://www.atlassian.com/agile/software-development/branching)

#### [Git cheatsheet](https://www.digitalocean.com/community/tutorials/how-to-use-git-a-reference-guide)

#### [Git cheatsheet2](https://docs.gitlab.com/ee/gitlab-basics/start-using-git.html)

[^1]:Please note that `YY`, in the previous LDAP group names should be your Legal entity id (US, XL, ...) and `XXX` should be [AAM code](troubleshooting.md#-where-can-i-get-the-aam-of-my-application)
