# Git

Git is software for tracking changes in any set of files, usually used for coordinating work among programmers collaboratively developing source code during software development. Its goals include speed, data integrity, and support for distributed, non-linear workflows (thousands of parallel branches running on different systems).
#### Comands

##### add
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


##### branch
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

##### checkout
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

##### clean
Removes untracked files from the working directory

```bash
clean -n        // will show you which files are going to be removed without actually removing them.
```

```bash
clean -f        // initiates the actual deletion of untracked files from the current directory.
```

##### clone
Creates a copy of an existing Git repository. 

```bash
clone <repo url>        // copy of an existing Git repository.
```

##### commit
Takes the staged snapshot and commits it to the project history.

```bash
commit -m       // commit with message
```
##### config

```bash
config --global user.name <name>
```

```bash
config --local user.email <email>
```

##### diff 
Show changes between commits, commit and working tree, etc

```bash
diff <branch-name>
```

##### fetch
Fetching downloads a branch from another repository, along with all of its associated commits and files.

##### log
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

##### merge
A powerful way to integrate changes from divergent branches.

```bash
merge <branch-name>    // to integrate a branch into another
```

##### pull
It downloads a branch from a remote repository, then immediately merges it into the current branch.

```bash
pull <branch-name>    // to integrate a branch into another
```

##### push
It lets you move a local branch to another repository.

```bash
push origin --delete <branhc-name>   // delete a branch from the repository
```

##### rebase
Rebasing lets you move branches around, which helps you avoid unnecessary merge commits.

```bash
rebase <base>   // rebase to the base
```

```bash
rebase-i        // rebase with interactive application
```

##### reflog
Git keeps track of updates to the tip of branches using a mechanism called reflog.

```bash
reflog show HEAD      // show history of HEAD
```

- ``` reset     // current HEAD to the specified state ((--hard) CODE push --force).```
- ``` restore   // restore working tree files.```
- ``` rm        // remove files from the working tree and from the index.```
- ``` status    // summary of which files have changes that are staged.```

##### remote
A convenient tool for administering remote connections.

```bash
remote -v   // include the URL of each connection.
```

##### reset
Undoes changes to files in the working directory.

```bash
reset --hard <commit-id>    // reset to the commit
```

##### revert
Undoes a committed snapshot. When you discover a faulty commit, reverting is a safe and easy way to completely remove it from the code base.

##### stash

```bash
stash apply        // to apply the stash
```
##### status
Displays the state of the working directory and the staged snapshot.

#### Git-crypt
Git-crypt enables transparent encryption and decryption of files in a git repository. Files which you choose to protect are encrypted when committed, and decrypted when checked out. git-crypt lets you freely share a repository containing a mix of public and private content. git-crypt gracefully degrades, so developers without the secret key can still clone and commit to a repository with encrypted files. This lets you store your secret material (such as keys or passwords) in the same repository as your code, without requiring you to lock down your entire repository.

If you are a new user in the context of git-crypt, meaning you aren't a trusted one yet, you'll need to run these steps:

- generate a GPG key (if don't already have one): gpg --full-generate-key
- get the key ID: gpg --list-keys
- export your public key: gpg --armor --output pubkey.gpg --export <key ID>
- send both the key ID and the pubkey.gpg to an already trusted user


#### Notes

##### Configuration
Default configuration:
```bash
git config --global user.name "Gaspare Mascolino"
git config --global user.email EMAIL
git config --global --list
```

Use ``` rm ~/.gitconfig ``` for reset.

##### Remove .DS_Store
Remove .DS_Store from a repo:
```bash
find . -name .DS_Store -print0 | xargs -0 git rm -f --ignore-unmatch
echo .DS_Store >> .gitignore
git add .gitignore
git commit -m '.DS_Store banished!'
```
##### Rename branch
Default configuration:
```bash
git config --global user.name "Gaspare Mascolino"
git config --global user.email EMAIL
git config --global --list
```
##### Revert branch
To revert a branch to a specific commit:
```bash
git branch -m <new_name>
git push origin -u <new_name>
git push origin --delete <old_name>
```