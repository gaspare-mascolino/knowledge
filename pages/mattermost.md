# Mattermost (DEPRECATED)

As a part of the tools offered, your team can also get access to a Mattermost instance that you can use to collaborate between the team members and connect other applications like Jenkins to receive notifications.

Upon request, you will be provided of a Mattermost Team only accessible by the members of your application's app code groups.

## Request a Mattermost Team

To get a Mattermost Team, first, the LDAP groups for your AAM code must be created. If you don't have them created yet, please refer to the [LDAP section on the prerequisites](prerequisites.md#ldap) for further details.

Once you have the LDAP groups created, <a href="mailto:USDevOpsTechSupport.unicreditservices@unicredit.eu?subject=Mattermost%20Team%20creation%20for%20%3CINSERT%20AAM%20CODE%20HERE%3E&body=Hi%20team!%20%0AMe%20and%20my%20collaborators%20want%20to%20start%20using%20Mattermost%20for%20our%20project.%20%20Could%20you%20please%20create%20a%20Team%20on%20Mattermost%20named%20after%20our%20project%3F%0A%0AThe%20application%20code%20is%20%3CINSERT%20AAM%20CODE%20HERE%3E%20(it%20should%20be%203%20alphanumeric%20digits).">
send us an email</a> with the request filled with all the required fields.

We will create a Mattermost Team for you, the name will be the same as the AAM CODE you specified in the e-mail.

The members of the `JUS<AAM CODE>_DEVOPS_PM` group will receive an invitation via mail from Mattermost once the request has been processed.

After the Mattermost Team has been created any member of the LDAP groups  `JUS<AAM CODE>_DEVOPS_{PM, DEV, GUEST}` will be able to log in and join the `<AAM CODE>` Team. All the team's membership and roles is managed entirely from LDAP groups.

> The information fromm LDAP is synced periodically. You might have to wait 1 hour maximum to see changes. You can try loging out and in again to force a refresh.

## What is included

The Mattermost Team will be provided with the following 3 channels by default:

- `Town Square`: this is the most general channel for on-topic conversations. PMs can also create new channels to group conversations by different topics.
- `Off-topic`: for off-topic conversations.
- `Jenkins Notifications`: you can connect this channel to Jenkins to receive notifications about the status of your pipelines. To do that you'll need to [create a token and configure an incoming webhook](rabbit-hole.md#generate-mattermost-token).

### Profiles and roles

The members of `JUS<AAM CODE>_DEVOPS_DEV` and `JUS<AAM CODE>_DEVOPS_GUEST` LDAP groups will join the Team automatically and will have "Team User" permisions. This includes:

- joining public channles
- posting messages to public channles
- sending direct messages to another user or groups
- reacting to messages
- edit you own messages

The members of the LDAP group `JUS<AAM CODE>_DEVOPS_PM` will have the "Team Admin" role that has the same permissions than "Team User" but can also:

- create and manage public channels
- manage webhooks

## Useful links

- Mattermost Production Instance: https://mattermost.devops.internal.unicreditgroup.eu
- Mattermost User's Guide: https://docs.mattermost.com/guides/user.html