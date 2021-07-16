# Build with Npm
In order to be able to run the pipeline using npm,
some prerequisites should be matched:  

* add sonarqube-scanner dependency
  
  ```npm i --save-dev sonarqube-scanner```
      
* For the unit test coverage you can use [jest-sonar-reporter](https://www.npmjs.com/package/jest-sonar-reporter) or [karma-sonarqube-unit-reporter](https://github.com/tornaia/karma-sonarqube-unit-reporter) as documented in [Sonar docs](https://docs.sonarqube.org/latest/analysis/coverage/)  
    
* In the **script** section of the **package.json** pay attention to the highlighted entries -> <- .“full-prod” is the script used in the devops/configuration.yaml
    
```json5
"scripts": {
  "half-prod": "npm run build-prod && node maven.js && npm run test",
  "->full-prod<-": "npm i && npm run half-prod",
  "->sonar-scanner<-": "sonar-scanner",
  "ng": "ng",
  "start": "ng serve",
  "build": "ng build",
  "test": "ng test",
  "lint": "ng lint",
  "e2e": "ng e2e",
  "start-local": "ng serve --proxy-config proxy.conf.local.json --base-href /",
  "build-test": "ng build",
  "build-prod": "ng build --prod --env=prod --aot"
}
```    

  
* In case you need to package the result of the build as **war/ear** you can use the module **maven-deploy** :  
```npm install –save-dev maven-deploy```   
and the following javascript snippet (maven.js used in the previous script section of the package.json):
```javascript
const warConfig = require('./maven-war-config.json');
const earConfig = require('./maven-ear-config.json');
const maven = require('maven-deploy');
const copy = require('recursive-copy');

const overwriteOptions = {
    overwrite: true,
    debug: false
};

const war = () => {

    return copy('../webapp/', './dist', overwriteOptions)
        .then(function (results) {
            results.forEach(result => console.log('copied ', result.src, ' to ', result.dest))
            maven.config(warConfig);
            let warArtifact = maven.package();
            console.log('artifact created', warArtifact);
            return warArtifact;
        })
        .catch(function (error) {
            console.error('Copy failed: ' + error);
        });
};

const ear = (warArtifact) => {

    const options = {
        overwrite: true,
        debug: true,
        filter: [
            '*.war'
        ]
    };

    copy('./dist', './ear-package/', options)
        .then(function (copyWarResult) {
            copyWarResult.forEach(path => console.log('copied ', path.src, ' to ', path.dest))
            copy('../../../../UB4-EFA-EAR/src/main/application/', './ear-package/', overwriteOptions)
                .then(function (results) {
                    results.forEach(result => console.log('copied ', result.src, ' to ', result.dest))
                    maven.config(earConfig);
                    maven.package();
                })
                .catch(function (error) {
                    console.error('Copy failed: ' + error);
                });
        });
};

war().then(ear);
```
Following an example of the pipeline configuration:
```yaml
build:
  npm:
    command: run full-prod
    packageJsonPath: src/main/angular

publish_artifact:
  artifact: src/main/angular/ear-package/myear.ear
  tool: MAVEN # To use in case of EAR/WAR
  pomPath: pom.xml # To use in case of EAR/WAR
```