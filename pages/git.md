# Git

Git is software for tracking changes in any set of files, usually used for coordinating work among programmers collaboratively developing source code during software development. Its goals include speed, data integrity, and support for distributed, non-linear workflows (thousands of parallel branches running on different systems).

#### Setup

```bash
git config --global user.name "Gaspare Mascolino"
git config --global user.email EMAIL
git config --global --list
```

Use ``` rm ~/.gitconfig ``` for reset.

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

- ``` log       // commit history (-N)```
- git push origin --delete test
- reflog
- ``` reset     // current HEAD to the specified state ((--hard) CODE push --force).```
- ``` restore   // restore working tree files.```
- ``` rm        // remove files from the working tree and from the index.```
- ``` status    // summary of which files have changes that are staged.```

To revert a branch to a specific commit:
```bash
git reset --hard COMMIT_ID
git push --force
```

