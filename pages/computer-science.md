## **Cyber security**

## **Docker**

Docker is an open platform for developing, shipping, and running applications. Docker enables you to separate your applications from your infrastructure so you can deliver software quickly. With Docker, you can manage your infrastructure in the same ways you manage your applications. By taking advantage of Docker’s methodologies for shipping, testing, and deploying code quickly, you can significantly reduce the delay between writing code and running it in production.

Docker provides the ability to package and run an application in a loosely isolated environment called a container. The isolation and security allow you to run many containers simultaneously on a given host. Containers are lightweight and contain everything needed to run the application, so you do not need to rely on what is currently installed on the host. You can easily share containers while you work, and be sure that everyone you share with gets the same container that works in the same way.

Docker provides tooling and a platform to manage the lifecycle of your containers:

- Develop your application and its supporting components using containers.
- The container becomes the unit for distributing and testing your application.
- When you’re ready, deploy your application into your production environment, as a container or an orchestrated service. This works the same whether your production environment is a local data center, a cloud provider, or a hybrid of the two.

**Commands:**

**Build**

Build a docker image

```bash
build .             // the docker file is into this directory
```

```bash
build -t <NAME>     // tags our image
```

**Logs**

```bash
logs <NAME>     // shown the logs of the container
```

```bash
logs --details <NAME>     // show extra details provided to logs
```

```bash
logs -f <NAME>  // follow log output
```

```bash
logs --tail <NUMBER>  // number of line to show from the end
```

```bash
logs --timestamps <NAME> // show timestamps
```

**Run**

Run a docker image

```bash
run -d              // run the container in detached mode (in the background)
```

```bash
run -p 80:80        // map port 80 of the host to port 80 in the container
```

**List images**
```bash
image ls                    // show the images.
```
**List containers**
```bash
ps                          // show the active containers.
```

**Push containers**
```bash
push <container-id>         // push the container.
```

**Remove container**
```bash
rm <container-id>           // remove container, you can use flag -f to force it.
```

**Remove container**
```bash
stop <container-id>         // stop container.
```

## **Git**

Git is software for tracking changes in any set of files, usually used for coordinating work among programmers collaboratively developing source code during software development. Its goals include speed, data integrity, and support for distributed, non-linear workflows (thousands of parallel branches running on different systems).

**Commands:**

**Add**

Moves changes from the working directory to the staging area. This gives you the opportunity to prepare a snapshot before committing it to the official history.

```bash
add <directory>     // stage all changes in <directory>. 
```

```bash
add <file>          // stage all changes in <file>. 
```

```bash
add .               // stage all changes. 
```

```bash
add -p              // interactive staging session to choose portions of file. 
```


**Branch**

This command is your general-purpose branch administration tool. It lets you create isolated development environments within a single repository.

```bash
branch -a           // list all remote branches. 
```

```bash
branch -m <branch>  // rename the current branch to ＜branch＞.
```

```bash
branch <branch>     // create a new branch without checkout. 
```

```bash
branch -d <branch>  // delete the specified local branch if it hasn't unmerged changes.
```

```bash
branch -D <branch>  // delete the specified local branch.
```

**Checkout**

In addition to checking out old commits and old file revisions, git checkout is also the means to navigate existing branches.

```bash
checkout -b ＜new-branch＞ // simultaneously creates and checks out, -b branch before checkout.
```

```bash
checkout -b ＜new-branch＞ ＜existing-branch＞ // bases new-branch from existing-branch
```

```bash
checkout ＜branchname＞     // switching branches is a straightforward operation
```

```bash
checkout ＜commit-code＞     // checkout to the commit selected
```

**Clean**

Removes untracked files from the working directory

```bash
clean -n        // will show you which files are going to be removed without actually removing them.
```

```bash
clean -f        // initiates the actual deletion of untracked files from the current directory.
```

**Clone**

Creates a copy of an existing Git repository. 

```bash
clone <repo url>        // copy of an existing Git repository.
```

**Commit**

Takes the staged snapshot and commits it to the project history.

```bash
commit -m       // commit with message
```
**Config**

```bash
config --global user.name <name>
```

```bash
config --local user.email <email>
```

**Diff** 

Show changes between commits, commit and working tree, etc

```bash
diff <branch-name>
```

**Fetch**

Fetching downloads a branch from another repository, along with all of its associated commits and files.

```bash
fetch
```

**Log**

Lets you explore the previous revisions of a project. It provides several formatting options for displaying committed snapshots.

```bash
log --oneline      // condense each commit to a single line.
```

```bash
log --stat      // include which files were altered and the relative number of lines that were modified.
```

```bash
log -n <limit>      // will display only n commits.
```

```bash
log -p              // shows the full diff of each commit.
```

```bash
log <file>          // shows all the commits for <file>.
```

**Merge**

A powerful way to integrate changes from divergent branches.

```bash
merge <branch-name>    // to integrate a branch into another
```

**Pull**

It downloads a branch from a remote repository, then immediately merges it into the current branch.

```bash
pull <branch-name>    // to integrate a branch into another
```

**Push**

It lets you move a local branch to another repository.

```bash
push origin --delete <branhc-name>   // delete a branch from the repository
```

**Rebase**

Rebasing lets you move branches around, which helps you avoid unnecessary merge commits.

```bash
rebase <base>   // rebase to the base
```

```bash
rebase-i        // rebase with interactive application
```

**Reflog**

Git keeps track of updates to the tip of branches using a mechanism called reflog.

```bash
reflog show HEAD      // show history of HEAD
```

- ``` reset     // current HEAD to the specified state ((--hard) CODE push --force).```
- ``` restore   // restore working tree files.```
- ``` rm        // remove files from the working tree and from the index.```
- ``` status    // summary of which files have changes that are staged.```

**Remote**

A convenient tool for administering remote connections.

```bash
remote -v   // include the URL of each connection.
```

**Reset**

Undoes changes to files in the working directory.

```bash
reset --hard <commit-id>    // reset to the commit
```

**Revert**

Undoes a committed snapshot. When you discover a faulty commit, reverting is a safe and easy way to completely remove it from the code base.

**Stash**

```bash
stash apply        // to apply the stash
```
**Status**

Displays the state of the working directory and the staged snapshot.

### Git-crypt
Git-crypt enables transparent encryption and decryption of files in a git repository. Files which you choose to protect are encrypted when committed, and decrypted when checked out. git-crypt lets you freely share a repository containing a mix of public and private content. git-crypt gracefully degrades, so developers without the secret key can still clone and commit to a repository with encrypted files. This lets you store your secret material (such as keys or passwords) in the same repository as your code, without requiring you to lock down your entire repository.

**Commands:**

```bash
add-gpg-user ${KEY_ID}      // to insert the key of a new user
```

```bash
init        // to initialize the repository
```

```bash
-k       // to show local key
```

```bash
lock        // to lock the repository
```

```bash
unlock        // to unlock the repository
```

**Notes**

**Become a trusted user**

If you are a new user in the context of git-crypt, meaning you aren't a trusted one yet, you'll need to run these steps:

- Generate a GPG key (if don't already have one): gpg --full-generate-key
- Get the key ID: gpg --list-keys
- Export your public key: gpg --armor --output pubkey.gpg --export <key ID>
- Send both the key ID and the pubkey.gpg to an already trusted user

**Trust a new user**

If you are a trusted user, you have to: 

- Import the pubkey of the user to insert: gpg --import pubkey.gpg
- Edit the key: gpg --edit–key ${KEY_ID} 
- ```> fpr```
- ```> trust``` (5)
- ```> save```
- ```> quit```
- Insert the key on the repo: git-crypt add-gpg-user --trusted ${KEY_ID}

**Notes**

**Configuration**

Default configuration:
```bash
git config --global user.name "Gaspare Mascolino"
git config --global user.email EMAIL
git config --global --list
```

Use ``` rm ~/.gitconfig ``` for reset.

**Remove .DS_Store**

Remove .DS_Store from a repo:
```bash
find . -name .DS_Store -print0 | xargs -0 git rm -f --ignore-unmatch
echo .DS_Store >> .gitignore
git add .gitignore
git commit -m '.DS_Store banished!'
```
**Rename branch**

```bash
git branch -m <new_name>
git push origin -u <new_name>
git push origin --delete <old_name>
```
**Revert branch**

To revert a branch to a specific commit:
```bash
git reset --hard <commit_id>
git push --force
```

## **Terminal**

Terminals, also known as command lines or consoles, allow us to accomplish and automate tasks on a computer without the use of a graphical user interface. Using a terminal allows us to send simple text commands to our computer to do things like navigate through a directory or copy a file, and form the basis for many more complex automations and programming skills.

### Mac

Shortcut: (⌘ + space + "ter")

Mac uses Z shell, there are 2 foundamentals file (path: Users/username):

- .zshrc (run control) -> file of declarations or commands that it interprets on startup.
- .zshenv -> contains exported variables that should be available to other programs.

**Commands:**

- cat -> Lets you view the content of a text file.
- cd -> Change directory. Allows you to move in your disk from one location to another.
- chown -> Changes the owner and / or assigned group of one or more files and directories.
- cp -> Copies a file from one location to another. If you want to copy a folder, use the ‘-R’ flag.
- du -> Shows you the Disk Usage, a useful command to find out how much space is occupied by a folder. It is usually used with the -hs flag to only show totals in human-readable form.
- find -> Find a file. If you want search every file (.) by name use the flag -name
- grep -> Filters a text file on the keyword you specify.
- less -> Lets you view the content of a text file.
- ls -> List the files and folders of the location currently opened in terminal. Many times used as ls -a which shows hidden files as well as it converts file-sizes to a human-readable form.
- man -> Displays the manual page of any supported command. This little built-in utility shows you all available information about a specific command including all the arguments and flags you can use.
- mkdir -> Creates a new folder under the currently opened location. Note that you can create only a single new folder. If you want to create a hierarchy of folders you can use the -p parameter.
- more -> Lets you view the content of a text file.
- nano -> Lets you to edit a file.
- ps ->  Used to list the currently running processes
- pwd -> Find out the location/name of the folder currently opened in your terminal window.
- rm -> Delete file
- rmdir -> Delete folder
- vim -> Lets you to edit a file.
- wc -> word count
- xargs -> Accept the pipe input such as text or file. It's default is echo.
- | -> Allow to merge two or more commands