
# Extending the pipeline 👷‍🛠
Besides the configuration available for the [predefined steps](rabbit-hole.md#available-steps) of the pipelines, 
another way of modify the execution is to add custom step within the execution flow.

## Custom steps
In order to add a custom step to your build add in the root of your `configuration.yaml` file something like this:
```yaml
steps:
  - step:
      after: INIT
      file: my_step.groovy
      method: my_step_function
```
Where

- `after` or `before` is the indication of one of the [available steps](rabbit-hole.md#available-steps) to which attach
  the execution of the custom step
- `file` is the name of the file to look starting from the root of the project
- `method` is the name of the function defined in the `file` to execute

### Example implementation of a custom step
Adding a file named `my_step.groovy` int the `root` folder with the following content
```groovy
def my_step_function() {
    println "I'm the captain of my soul 👻"
}
```
together with the previous configuration will create a step named `my_step`, just after the [Init](rabbit-hole.md#init),
that will just print the statement specified.


!!! warning "A custom step cannot be placed before the [Init](rabbit-hole.md#init) step."