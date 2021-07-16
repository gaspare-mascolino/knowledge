
# Pipelines onboarding documentation

This few lines are to explain how to write new documentation and to deploy it.

## Write and see documentation locally
```shell script
make serve
```

And you should end up with a server running on the port `8000` serving your documentation.

## Deploy documentation changes

If you want to try the build of the documentation locally just run a
```shell script
make build
```
To have it deployed in qa/prod env go update the image in the repository [helm_charts](https://bitbucket.internal.unicreditgroup.eu/projects/JXP/repos/helm_charts/browse) after having pushed and run the pipeline building the new image from this repo (you can change the hardcoded tag from `devops/configuration.yaml` > `docker.imageTag`).