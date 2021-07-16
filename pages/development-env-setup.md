
# Development environment setup

## node.js  

In order to have a fully working development environment in UCS the following properties have to be configured.

- .npmrc
    - registry - 
<https://nexus3.internal.unicreditgroup.eu/repository/npm-group/> 
    - proxy
    - https-proxy
    - strict-ssl -> false
    - _auth -> base64 of nexus3 username:password

- .gitconfig
    - http.proxy
    - http.sslVeriy -> false
    - https.proxy
    - url.insteadof - because connections to port 22 are closed convert url like ssh://git@github.com to <https://github.com>

!!! todo
    A script will be provided to help during dev environment configuration.