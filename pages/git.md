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

- ``` clone     // clone a repository into a new directory ```
- ``` commit    // record changes to the repository.```
- ``` config      // get and set repository or global options ```
- ``` diff      // show changes between commits, commit and working tree, etc.```
-fetch
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

