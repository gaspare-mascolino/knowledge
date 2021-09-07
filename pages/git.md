# Git

Git is software for tracking changes in any set of files, usually used for coordinating work among programmers collaboratively developing source code during software development. Its goals include speed, data integrity, and support for distributed, non-linear workflows (thousands of parallel branches running on different systems).

#### Setup

```bash
git config      // get and set repository or global options.

git config --global user.name "Gaspare Mascolino"
git config --global user.email EMAIL
git config --global --list
```

Use ``` rm ~/.gitconfig ``` for reset.

#### Comands

- ``` add       // add file contents to the index. ```
- ``` clone     // clone a repository into a new directory ```
- ``` commit    // record changes to the repository.```
- ``` diff      // show changes between commits, commit and working tree, etc.```
- ``` reset     // current HEAD to the specified state ((--hard) CODE push --force).```
- ``` restore   // restore working tree files.```
- ``` rm        // remove files from the working tree and from the index.```
- ``` status    // summary of which files have changes that are staged.```

To revert a branch to a specific commit:
```bash
git reset --hard COMMIT_ID
git push --force
```
