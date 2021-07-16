# Bitbucket - Jira integration

## New Branch visible in Jira issue

Branch in BitBucket can be visible in Jira. It can be done from Jira issue directly but also manually by indicating an issue Id.

Syntax:

```
(<branch prefix>/)<Jira issue id>-<your branch name>
```

Example: **JRA-34-my-branch** or **feature/JRA-34-my-branch**

## Commit visible in Jira issue

Add an Id of your Jira issue (User Story, Task, Sub-task, ...) to the commmit message.

Syntax:
```
<some text> <ISSUE_KEY> <some text>
```

Example: **JRA-34 corrected indent**

## Pull Request visible in Jira issue

Pull Request can be done directly from Jira issue if your branch is visible (look above). Once the Pull Request is created and titled as it should be it will be visible including also its status (open, merged)

Syntax:

```
<Jira issue id> <your branch name>
```

Example: **JRA-34 my pull request title** or **JRA 34 my pull request title**

!!! info
    - Jira view example
    <p align="center">
        <img src="../images/jira-integration.png" width="420" />
    </p>
    - BitBucket view example
    <p align="center">
        <img src="../images/jira-integration2.png" width="420" />
    </p>

!!! warning
    Jira issue id is case sensitive

## Reference

See more at [Atlasian reference](https://confluence.atlassian.com/bitbucket/use-smart-commits-298979931.html)