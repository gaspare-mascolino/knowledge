# GitCrypt

## Getting started
[Git-crypt](https://github.com/AGWA/git-crypt) encrypts files and folders, so it can be used to hide sensitive data like passwords.

It relies on GPG and can be used with both _symmetric_ and _asymmetric_ keys.

We chose to work with **asymmetric** keys:
each user that needs to be able to decrypt the files to view/change their content must have a GPG key, and that key must be trusted.

This means that also Jenkins has its own pair of private/public keys, and for it to be able to run pipelines that use encrypted data, 
the Jenkins' public key must be added to your repository's git-crypt gpg users. See the [Trusting Jenkins paragraph](#trusting-jenkins).

Let's see how to use it!

---
## Installation

### Windows
Follow these steps:

1. [Download](https://github.com/oholovko/git-crypt-windows/releases) the latest windows release
1. put the .exe in a folder
1. add that folder to your user's PATH env variable

### *Nix
Follow the instructions you can find in the [install readme](https://github.com/AGWA/git-crypt/blob/master/INSTALL.md) in the git-crypt repo.

---
## Init git-crypt
If your repository doesn't already use git-crypt, and you want to enable it, just move to the repo's root and follow these steps:

1. run ```git-crypt init```
1. add a ```.gitattributes``` file under the root of your repo (if you don't already have one)
1. add the desired content to the ```.gitattributes```, based on your needs:
    - if you need to encrypt a specific file (say ```src/main/resources/my-secret.properties```):

            src/main/resources/my-secret.properties filter=git-crypt diff=git-crypt
    
    - if you need to encrypt an entire folder (say ```src/main/resources```):
        
            src/main/resources/** filter=git-crypt diff=git-crypt
            
    !!! info
        Paths to files and folders to encrypt must be relative to the repo's root.
            
1. to avoid encrypting the ```.gitattributes``` itself, add this as last line:
 
        .gitattributes !filter !diff
        
    !!! example
        To encrypt just the ```src/main/resources/my-secret.properties``` file, your ```.gitattributes``` should look like:
        
            src/main/resources/my-secret.properties filter=git-crypt diff=git-crypt
            .gitattributes !filter !diff

1. commit and push!

---
## Using git-crypt

### How to become a trusted user
If you are a new user in the context of git-crypt, meaning you aren't a trusted one yet, you'll need to run these steps:

- generate a GPG key (if don't already have one): ```gpg --full-generate-key```
- get the **key ID**: ```gpg --list-keys```
- export your public key: ```gpg --armor --output pubkey.gpg --export <key ID>``` 
- send both the **key ID** and the **pubkey.gpg** to an already trusted user

!!! warning
    With the commands above, you created the **pubkey.gpg** file under the root of your repo. Delete it now to avoid pushing it and polluting the repo!

### How to trust a new user
If you are an already trusted user, you can add the identity of others for them to become in turn trusted.
 
You must have the new user's public key (for example in a file named **pubkey.gpg**), the **key ID**, and then follow these steps:

- import the public key: ```gpg --import /path/to/pubkey.gpg``` 
- edit the new key specifying the **key ID**: ```gpg --edit-key <key ID>```. 
    This will open a _repl_ terminal in which you must enter these commands:
    
    - fpr
    - trust
    - 5
    - y
    - quit
    
- add the key to the trusted ones: ```git-crypt add-gpg-user --trusted <key ID>```

The new key is now added to the ```.git-crypt``` folder in your project's root, and a commit was automatically created. Push it!

The new user is now trusted and will be able to decrypt previously encrypted files and folder.

### How to use git-crypt 
If you want to hide the content of files and folder specified in the ```.gitattributes``` file, you must run: 

    git-crypt lock
    
If you want to show their content, run:
    
    git-crypt unlock
    
If you want to see which files are encrypted, run:

    git-crypt status -e



!!! Tip
    Once the files are encrypted, you don't need to hide their content each time: when pushed, they will be automatically hidden.
    This means you can keep those files in clear in your local workspace.
    
---
## Trusting Jenkins and integration in a pipeline
If you need to run pipelines that use data encrypted with git-crypt, you need Jenkins to become a trusted user.
Follow the [steps above](#how-to-trust-a-new-user) to add Jenkins' identity to your repository:

- **Key ID**: B3F107D2614B2501662DADD0DAF24AC3AC735459
- Public key: [pubkey.gpg](files/git-crypt/pubkey.gpg)

If you want to integrate gitcrypt in the pipeline please take a look in the following snippet of the configuration.yaml
    
```yaml
steps:
  - step:
      before: BUILD
      method: gitcryptStep
      params:
          method: unlock
```
