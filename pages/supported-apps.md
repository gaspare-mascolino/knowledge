
# The DevOps onboarded apps

This is the list of the applications that are officially supported by **DevOps at scale** initiative.  
This means that DevOps initive will pay for the onboarding activities, mainly: 
 
* create a **full DevOps pipeline** for non-prod environments
* provide hardware and license for the underlying tools
* pay to enhance the test automation coverage (integration and e2e ui tests) 

Nothing is for free, if your application is in the list you will be asked also to:  

* guarantee **high level of quality** if the code (no Sonar blocker/critical issues)
* **no vulnerabilities** on the external libraries used by the code
* high **coverage of unit tests** (new code >= **60%** coverage)  

Plus the application owner must guarantee a cost saving in RUN costs due to the improved quality of the application.

## The famous list

| APP CODE | DESCRIPTION | STATUS |
| --- | --- | --- |
| AMB | Austria Mobile Banking (backend for frontend app) |done|
| U4A | Uniplatform for Advice |done|
| WEP | PULS new payment integration engine |done|
| PA1 | PSD2 APIs, axway api gateway |done|
| [UB5](supported-apps.md#onboard-journey-with-ub5) | Pre Sales Advisor Tool |done|
| SVG | Identity and Access Management for CEE omnichannel architecture |done|
| ICL | Global Intranet in Cloud O365 (app code tbd) |done|
| COR | A.I.R. Integration layer for a chatbot on GCP (app code tbd) |done|
| HLL | Digital Banking HU |done|
| UB4 | Underwriting Revolution Small Business |done|
| DBN | CEE Digital Banking |done|
| GFB | Global Financial Backbone |done|
| QJN | Securities Processing and Collateral Allocation & Optimization |ongoing|
| WCM | Wealth Contract Management |done|
| GCS | Synthetic Securitization Transactions |done|
| UB1 | Underwriting Revolution Common Business |done|
| UBZ | Underwriting Technical Evaluation Business Module |ongoing|
| THS | Themis - Sales Credit Calculation and Reporting |ongoing|
| DSI | Digital Signature Service Layer and Diagnostic Tool |ongoing|
| COR | ChatBot BuddyBank on GKE |ongoing|
| QAV | Advisory Portal |ongoing|

## How to be in the list

In order to be in the list **ONLY the Application Owner** of the application that wants to be onboarded must get in contact with the DevOps onboarding leaders and industrial planner of the corresponding CIO area, below:

* [CB] <a href="mailto:Oliver.Koziol@unicredit.de">Koziol Oliver (UniCredit Services)</a>, Cristiane Bürstle
* [CIB] <a href="mailto:Marius.Schneider@unicredit.de">Schneider Marius (UniCredit Services)</a>, Cristiane Bürstle
* [GF] <a href="mailto:ANTONIO.CONTE@unicredit.eu">Conte Antonio (UniCredit Services)</a>, Daniele Delledonne
* [CEE] <a href="mailto:Iulian.Moise2@unicredit.at">Iulian MOISE (UniCredit Services - AT)</a>, Massimiliano di Franco


## If your appication cannot be in the list?

If your application isn't and cannot be in the list what you can do?  
There is still one possibility to some of the capabilities that we provide for self-onboarding.  
What do we mean with **self-onboarding**? 
 
* someone pays for the resources that are used, you must provides a PJ code
* you can use part of the capabilities of a DevOps pipeline. The list of the **capabilities is updated [here](self-onboarding.md)**
* the devops team will provide best effort support


## Onboard journey with UB5

The Agile onboard project started in April 2020 by Global ICT Architecture has three main pillars:

* **Enhance quality**, starting for example from the resolution of high and critical Sonar issues 

* **Enhance security**, by upgrading known vulnerable libraries highlighted during OWASP checks

* Introduction of automation and CI/CD pipelines with a particular focus on **test automation** that requires the development of:
    - **Unit** testing for the new code
    - **Integration** testing of services exposed by the application
    - **E2E Selenium** tests that simulate user interaction with the FE of the application


This onboard project follows a roadmap which can be summarized in 3 steps

1. May 2020 - **UB5** “Easy Loan” onboard started alongside the setup of the environments for automation testing and the design of the pipelines and frameworks

2. July 2020 - A second application is onboarded: **UB4** MyCredit Small Business

3. November 2020 -  **UB1**, the common part of MyCredit, conclude the onboard process

!!! note
    You can find in [this PowerPoint](files/20201002_DevOps_in_GRM_GLO_webinar_v4.pptx) a detailed description of the onboard journey with UB5 including the roadmap and the adopted CI/CD pipeline