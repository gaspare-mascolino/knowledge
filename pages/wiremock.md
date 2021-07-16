# Wiremock: how to mock your external request in the pipeline process

Wiremock official docs can be found [here](http://wiremock.org/docs/).

## TL;DR: What is wiremock?

WireMock is an HTTP mock server, it can be used for:

* stubbing: serving defined responsed to specific requests
* verification: capturing requests to be checked later
* fault injection
* simultation of stateful behaviours

Can be run as a standalone process and configured via JSON APIs or as a library for JVM based languagues.

## Server url

Wiremock's production instance can be reached at [wiremock.devops.internal.unicreditgroup.eu]()

## Wiremock functionality 

Wiremock's instance offered by the DevOps team offers the following functionalities:

* stubbing: loading HTTP responses to specific requests via JSON APIs, see the [docs](http://wiremock.org/docs/stubbing/) for more details and [here](http://wiremock.org/docs/response-templating/) to read about response templating based on requests' headers, bodies or URLs.
* stateful behaviours: in case you need to mock a stateful service you can find [here](http://wiremock.org/docs/stateful-behaviour/) the documentation regarding how to use wiremocks' scenarios. 

Following functionalities are not supported / disabled:

* proxying and recording: for performance and resource usage reasons you must not use our instance of wiremock to perform recodings, you should use a local wiremock instance on your machine, export it and then load it on the central Wiremock. See [here](http://wiremock.org/docs/running-standalone/) to know how to run it locally and [here](http://wiremock.org/docs/record-playback/) to know how to export the recordings.
* flags: for performance and resource usage issues we are running wiremock with the following flags: `--disable-request-logging` and `--no-request-journal` which respectively disable server side request logging and disable the request journal, which records incoming requests for later verification.
* admin APIs: in order to avoid concurrents users deleting each other's stubs while pipelines are running we also disabled the "delete all mappings" [endpoint](http://wiremock.org/docs/api/#tag/Stub-Mappings/paths/~1__admin~1mappings/delete)
