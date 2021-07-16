# SVN to Git migration

There are several way to migrate an SVN repository to a git repository. The easiest way is to take a snapshot of the latest svn revision, initialize a git repository and push it. But wath if I want to migrate also others branches and especially the repository history? In the following paragraphs we will see how to fully migrate an SVN repository to a Git repository.

## Prerequisites

Download the atlassian [svn-migration-script](https://bitbucket.org/atlassian/svn-migration-scripts/downloads/ "svn-migration-script.jar")

verify the script to make sure you have the Java Runtime Environment, Git, Subversion, and the git-svn utility installed.

```sh
java -jar ~/svn-migration-scripts.jar verify
```

Note that due to this [issue](https://github.com/git-for-windows/git/issues/2649 "issue.jar"), the ```git-bash 2.27.0.windows.1``` version fails on git-svn.

You can use a previows version like [2.26.2.windows1](https://github.com/git-for-windows/git/releases/tag/v2.26.2.windows.1 "2.26.2.windows1") or a newer version (at the moment of writing this document an RC version 2.28.0-rc2 exists that seems fix the problem)

[git bash releases](https://github.com/git-for-windows/git/releases "git bash releases")

## Generate authors file

Authors file will be used to map the svn committer to the git committer. Because of the git policy that assume a committer in the format:

```properties
user.name=CXXXXXX
user.email=CXXXXXX
```

we need to generate the authors file and fix it with the expected format.

Generate the file with the command

```sh
java -jar ~/svn-migration-scripts.jar authors <svn_url> > authors.txt <registration_number> <password>
```

fix the author file with the format

```properties
CCXXXXX = CCXXXXX <CCXXXXX>
```

You can modify the authors file manually or if you prefer you can run a *sed* command
E.g. we are replacing all the @mycompany.com with an empty string.

```bash
sed -i 's/@mycompany.com//g' authors.txt
```

this will map the svn commiter (on the left) to the git committer (on the right).

### Configure git user config accordingly

```sh
git config --global user.name CXXXXXX
git config --global user.email CXXXXXX
```

## Clone the SVN repository

```sh
git svn clone --stdlayout [--authors-file=authors.txt] <svn-repo>/<project> <git-repo-name>
```

Where:

* ```<svn-repo>``` is the URI of the SVN repository that you want to migrate
* ```<project>``` is the name of the project that you want to import
* ```<git-repo-name>``` is the directory name of the new Git repository.

The ```--stdlayout``` flag should be used when your SVN repository use a standard layout.

If for some reason the svn repo use a custom format you must use the following flags to describe the directories structure:

* ```--trunk```
* ```--branches```
* ```--tags```

These flags accept also wild card so if your directories structure use subfolders you can configure it.

e.g.

```sh
git svn clone --authors-file=authors.txt --trunk=/trunk/development/sources --branches=/branches/development/sources/*/* --tags=/tags/development/sources/*/* <svn_repo>
```

from Windows

```sh
git svn clone --authors-file=authors.txt --trunk=trunk/development/sources --branches=branches/development/sources/*/* --tags=tags/development/sources/*/* <svn_repo>
```

In this example we are saying that the source code of the trunk is under the development/sources directory and the branches are under development/sources directory in the format of parent/child directory (even for the tags).

**You can specify more than one --tags and/or --branches options, in case your Subversion repository places tags or branches under multiple paths.**

## Sync git repo with SVN changes

If you need to syncronize an already migrated svn repository with new commits these are the steps you need to performe in order to update your git repo:

Inside the git migrated project run:

```sh
git svn fetch
```
## Push to remote

<details>
  <summary>Deprecated solution</summary>

  We discoverd that svn-migration-script it's a very old solution. It is a Scala project that worked well until git 1.9.x.


  https://bitbucket.org/atlassian/svn-migration-scripts/src/master/


  You can deep dive into following these urls:


  https://bitbucket.org/atlassian/svn-migration-scripts/pull-requests/36/adding-prefix-option/diff


  https://bitbucket.org/atlassian/svn-migration-scripts/issues/20/clean-git-no-longer-works

  ## clean-git script

  The clean-git script included in svn-migration-scripts.jar turns the SVN branches into local Git branches and the SVN tags into full-fledged Git tags.

  ```sh
  java -Dfile.encoding=utf-8 -jar ~/svn-migration-scripts.jar clean-git
  ```

  This will output all of the changes the script wants to make, but it won’t actually make any of them. To execute these changes, you need to use the --force option

  ```sh
  java -Dfile.encoding=utf-8 -jar ~/svn-migration-scripts.jar clean-git --force
  ```

  To apply the downloaded commits to the repository, run the following command:

  ```sh
  java -Dfile.encoding=utf-8 -jar ~/svn-migration-scripts.jar sync-rebase
  ```

  You should now be able to see the new commits in your git log output.

  It’s also a good idea to run the git-clean script again to remove any obsolete tags or branches that were deleted from the original SVN repository since the last sync:

  ```sh
  java -Dfile.encoding=utf-8 -jar ~/svn-migration-scripts.jar clean-git --force
  ```
</details>

Once the clone and/or the fetch are done then you can run the following scripts in order to create local branches and tags. (Thank you Ciro Cardone)

*convert svn tags to git tags*
```bash
git for-each-ref --format="%(refname:short) %(objectname)" refs/remotes/origin/tags \
| while read BRANCH REF
  do
        TAG_NAME=${BRANCH#*/}
        BODY="$(git log -1 --format=format:%B $REF)"

        echo "ref=$REF parent=$(git rev-parse $REF^) tagname=$TAG_NAME body=$BODY" >&2

        git tag -a -m "$BODY" $TAG_NAME $REF^  &&\
        git branch -r -d $BRANCH
  done
```

*checkout all svn branch to local*
```bash
git for-each-ref --format="%(refname:short) %(objectname)" refs/remotes/origin \
| while read BRANCH REF
  do
        LOCAL_BRANCH=${BRANCH#*/}
        if [ $LOCAL_BRANCH != 'trunk' ] 
        then
           git branch $LOCAL_BRANCH $BRANCH
        fi
  done
```

*then you can push all the code*
```bash
# required only first time
git remote add <origin_name> <bitbucket repo>
git push -u <origin_name> --all
git push <origin_name> --tags
```

Your local Git repository should now be synchronized with your SVN repository.

!!! tip
    Take a look also at the official documentation:<br>
    - [Atlassian Official resource](https://www.atlassian.com/git/tutorials/svn-to-git-prepping-your-team-migration "Atlassian Git tutorial")        
    - [Git SVN reference](https://git-scm.com/docs/git-svn "Git docs")

