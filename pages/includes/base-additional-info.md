Before using the followings tools the followings steps should be verified:  

* [Open the TUFIN request](/jenkins-bitbucket-integration/#from-jenkins-to-your-servers) to have the network reachability from JXP to your target  
* If necessary, create a technical user to be used  
* Store the credentials in [Jenkins](https://jenkins.devops.internal.unicreditgroup.eu/job/AAM/credentials/store/folder/domain/_/newCredentials) - _( remember to edit the **AAM** code with the right one in the URL)_ and take the **credentialsId** (**`myIdToUseInPipeline`** in the example screen)       
  ![](images/rabbit-hole/jenkins-credentials.png)  
* If you have unencrypted credentials or secrets you need to hide them using [git-crypt](git-crypt.md)  