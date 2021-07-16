# Branch aware configurations

It is possibile to have a branch specific **application.yaml** and **configuration.yaml**

To use this feature just create a file with the following naming scheme in the same directory as application.yaml (/devops)

```
configuration-[branch name].yaml
application-[branch name].yaml
```

This new files will be **merged** with the default configuration replacing or adding steps in the pipeline


## Nested branches

If a branch name is nested, as in **feature/xyz**:
It is possibile to have a configuration valid for all 'feature' branch:
```
configuration-feature.yaml
```
and one specific to the branch:
```
configuration-feature-xyz.yaml
```
If both files are present they will be merged in this order:
```
configuration.yaml -> configuration-feature.yaml -> configuration-feature-xyz.yaml
```
