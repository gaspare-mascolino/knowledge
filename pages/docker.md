# Docker

Docker is an open platform for developing, shipping, and running applications. Docker enables you to separate your applications from your infrastructure so you can deliver software quickly. With Docker, you can manage your infrastructure in the same ways you manage your applications. By taking advantage of Docker’s methodologies for shipping, testing, and deploying code quickly, you can significantly reduce the delay between writing code and running it in production.

Docker provides the ability to package and run an application in a loosely isolated environment called a container. The isolation and security allow you to run many containers simultaneously on a given host. Containers are lightweight and contain everything needed to run the application, so you do not need to rely on what is currently installed on the host. You can easily share containers while you work, and be sure that everyone you share with gets the same container that works in the same way.

Docker provides tooling and a platform to manage the lifecycle of your containers:

- Develop your application and its supporting components using containers.
- The container becomes the unit for distributing and testing your application.
- When you’re ready, deploy your application into your production environment, as a container or an orchestrated service. This works the same whether your production environment is a local data center, a cloud provider, or a hybrid of the two.

#### Comands

##### build
Build a docker image

```bash
build .             // the docker file is into this directory
```

```bash
build -t <NAME>     // tags our image
```

##### run
Run a docker image

```bash
run -d              // run the container in detached mode (in the background)
```

```bash
run -p 80:80        // map port 80 of the host to port 80 in the container
```

#### Notes

##### List images
```bash
docker image ls                    // show the images.
```
##### List containers
```bash
docker ps                          // show the active containers.
```

##### Push containers
```bash
docker push <container-id>         // push the container.
```

##### Remove container
```bash
docker rm <container-id>           // remove container, you can use flag -f to force it.
```

##### Remove container
```bash
docker stop <container-id>         // stop container.
```