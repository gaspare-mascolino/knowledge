INTRODUCTIONS
    1. Fondamenti di Linux e scripting
        Sono finiti quei giorni in cui le aziende si preoccupavano dei sistemi operativi proprietari. Ora siamo nell'era di Linux. La 
        maggior parte delle aziende preferisce ospitare le proprie applicazioni su Linux. Pertanto, le competenze nella gestione di un 
        sistema operativo Linux sono molto cruciali per un DevOps Engineer.

        Inoltre, la maggior parte degli strumenti di gestione della configurazione come Puppet, Chef e Ansible ha i propri nodi master in 
        esecuzione su Linux. DevOps è una forma di automazione e include l'automazione per il provisioning dell'infrastruttura. Ulteriori 
        informazioni sugli strumenti DevOps.
        Quindi, un DevOps Engineer deve essere in grado di gestire qualsiasi linguaggio di scripting e deve essere esperto di almeno un linguaggio di scripting (preferibilmente Python). Quindi l'inevitabile set di competenze DevOps sarebbe lo scripting basato su Linux e Linux. 

    2. Conoscenza su vari strumenti e tecnologie DevOps
        Le pratiche DevOps vengono eseguite in varie fasi e ogni fase dispone di strumenti che possono facilitare quella fase. 
        Le fasi principali sono:

        - Gestione del codice sorgente
            Gli sviluppatori creano e modificano regolarmente i codici software. Il software di gestione del codice sorgente viene 
            utilizzato per memorizzare il codice, unire il nuovo codice a quello vecchio, controllare le versioni del codice, ecc. 
            Aiuta anche a collaborare con il codice sorgente tra i membri del team. Strumenti come Git, Github, Gitlab sono i più comuni per 
            questo scopo. 

        - Gestione della configurazione
            La gestione della configurazione viene utilizzata per tenere traccia delle configurazioni del software e del sistema operativo. 
            Aiuta anche a gestire le configurazioni su migliaia di server. Viene eseguito tramite un clic di un pulsante o l'esecuzione di 
            un singolo comando sul server di gestione. Gli strumenti di gestione della configurazione prendono una connessione remota ai 
            server di destinazione e spingono le modifiche alla configurazione rendendo la vita facile e semplice. Puppet, Chef e Ansible 
            sono i migliori giocatori per la gestione della configurazione.

        - Integrazione continua
            L'integrazione continua, abbreviata in CI, è il processo di automazione delle integrazioni del codice di diversi sviluppatori in 
            un unico software. Jenkins e Bamboo sono gli strumenti principali per l'integrazione continua.

        - Test continui
            Il test continuo è il processo per ridurre il tempo di attesa del feedback dopo i test del codice. Il codice viene testato 
            nell'ambiente di sviluppo stesso utilizzando strumenti di test di automazione. Selenium, TestComplete e TestingWhiz sono 
            gli strumenti più comuni per i test continui. 

        - Monitoraggio continuo
            Il monitoraggio continuo viene utilizzato per monitorare le prestazioni delle applicazioni, i tempi di inattività, i registri 
            degli errori, ecc. Gli strumenti principali utilizzati sono Nagios, Zabbix, Splunk, ecc.

        - Containerizzazione
            La containerizzazione è il processo di virtualizzazione di un sistema operativo in modo che diversi contenitori che eseguono 
            applicazioni diverse possano condividere il sistema operativo e le risorse di sistema. Questo si oppone al modo tradizionale 
            di virtualizzazione dell'hardware in cui l'hardware del sistema è condiviso tra diverse macchine virtuali. Docker, Kubernetes e 
            Vagrant sono i principali fornitori di containerizzazione.

    3. Integrazione continua e consegna continua
        Integrazione continua e consegna continua o abbreviato come CI/CD è l'essenza di DevOps. È la pratica di integrare continuamente 
        tutto il codice di diversi sviluppatori, testarli continuamente e distribuire il codice di successo in produzione. 
        La distribuzione in produzione richiederà principalmente la creazione di nuovi contenitori, che è ancora una volta automatizzato 
        tramite script. 


    4. Infrastruttura come codice
        In precedenza, il provisioning dell'infrastruttura IT era un processo lungo, noioso e manuale. Con la nascita del cloud computing e 
        delle tecnologie di containerizzazione, l'infrastruttura necessaria agli sviluppatori può essere fornita tramite uno script 
        automatizzato. Lo script esegue i comandi richiesti ed esegue la gestione della configurazione utilizzando uno degli strumenti 
        di gestione della configurazione. La piattaforma applicativa o l'infrastruttura richiesta viene fornita in pochi secondi. 

    5. Concetti chiave di DevOps 
        DevOps, a differenza di ciò che pensa la gente, non è né una tecnologia né uno strumento. È una metodologia che non ha una struttura 
        rigida. Quindi le aziende possono adottare la metodologia adattando il quadro secondo i loro standard. L'obiettivo principale della 
        metodologia DevOps è riunire i team di sviluppo e operativi per ridurre il divario tra loro in modo che il lavoro venga eseguito più 
        velocemente. Utilizzando la metodologia DevOps, le aziende sono in grado di fornire software di qualità molto più velocemente. 
        Tutti gli strumenti e le tecniche di cui abbiamo discusso sopra vengono utilizzati per implementare questa metodologia e fornire 
        prodotti software in tempo. 

    6. Competenze trasversali
        Le competenze trasversali svolgono un ruolo importante nel settore IT con l'adozione della metodologia DevOps. La maggior parte delle aziende preferisce un modo di lavorare Agile utilizzando le metodologie DevOps in modo che i team lavorino ad alta velocità e producano risultati più rapidamente per soddisfare le aspettative dei clienti. Quindi le competenze trasversali sono sempre più richieste quando si lavora nel mondo DevOps.

DEVOPS
    - Waterfall model
        Requirements
        Design
        Implementation
        Verification
        Maintenance

TOOLS

    - Cloud
        • Azure
            Piattaforma cloud pubblica di Microsoft, che offre servizi di cloud computing. Il cloud computing è la distribuzione di servizi 
            di calcolo, come server, risorse di archiviazione, database, rete, software, analisi e intelligence, tramite Internet 
            ("il cloud"), per offrire innovazione rapida, risorse flessibili ed economie di scala.

    - Code Repository
        
        • Bitbucket
            Uno strumento di gestione del codice Git: Bitbucket mette a disposizione dei team uno spazio in cui pianificare i progetti, 
            collaborare su codici, effettuare test e implementarne i risultati.
    
    - Build System

        • Jenkins
            Jenkins è un server open source di CI/CD (Continuous Integration, integrazione continua, e Continuous Deployment, 
            implementazione continua) scritto in Java. Si tratta di uno strumento multipiattaforma, infatti include pacchetti per Linux, 
            Mac OS X, Windows, FreeBSD e OpenBSD.
            Jenkins consente di automatizzare le diverse fasi del ciclo di vita del software, dalla compilazione al test alla distribuzione. 
            È possibile programmare l'esecuzione di determinate attività con la pianificazione simile a cron o utilizzando trigger, 
            ad esempio per fare il commit del proprio codice all’interno di una repository, lanciare test ed analizzarne i risultati per 
            avere un feedback immediato sulla sua qualità. Le funzionalità di Jenkins sono poi potenziate dal grande numero di plug-in 
            compatibili, sviluppati e diffusi dalla comunità di utenti e developer che lo usa.

            Gestione della pipeline.
        
        • nodeJS
            Node.js è un’applicazione, per la precisione un framework, che viene usata per scrivere applicazioni in Javascript lato server.
            Il codice su Node.js, infatti, viene fatto girare da V8. Sto parlando del motore JavaScript open source di Google, scritto in 
            C ++ e utilizzato in Google Chrome. Questo, insieme alle capacità umane, permette di creare delle applicazioni web con 
            caratteristiche chiare in termini velocità e scalabilità.
            Si tratta di una soluzione lato server basata su un modello di I/O asincrono che opera sugli eventi.
        
        • npm
            npm è un gestore di pacchetti per il linguaggio di programmazione JavaScript. È il gestore di pacchetti predefinito per 
            l'ambiente di runtime JavaScript Node.js. Consiste in un client da linea di comando, chiamato anch'esso npm, e un database 
            online di pacchetti pubblici e privati, chiamato npm registry.
    
    - Unit & Component Test

        • Maven
            Strumento di build automation utilizzato prevalentemente nella gestione di progetti Java. Con questo strumento infatti non è più 
            necessaria la compilazione totale del codice, ma viene fatto uso di una struttura di progetto standardizzata su template 
            definita archetype.

            Il vantaggio derivante dall’utilizzo di questo tool è da subito evidente: se generalmente per sviluppare un software sono 
            necessarie numerose fasi, con la build automation l’intero processo viene automatizzato, riducendo il carico di lavoro del 
            programmatore e diminuendo le possibilità di errore da parte dello stesso. Alcune delle fasi fondamentali che vengono 
            automatizzate dal tool sono la compilazione in codice binario, il packaging dei binari, l’esecuzione di test per garantire 
            il funzionamento del software, il deployment sui sistemi ed infine la documentazione relativa al progetto portato a termine.
        
        • Gradle
            Gradle è un sistema open source per l'automazione dello sviluppo fondato sulle idee di Apache Ant e Apache Maven, che introduce 
            un domain-specific language (DSL) basato su Groovy[2], al posto della modalità XML usata da Apache Maven per dichiarare la 
            configurazione del progetto. Gli script Gradle possono essere eseguiti direttamente, in contrasto con le definizioni dei 
            progetti Apache Maven (pom.xml).
            
            Al contrario di Apache Maven, che definisce il ciclo di vita di un processo, e di Apache Ant, dove l'ordine dei compiti 
            (detti target) è determinato dalle dipendenze (depends on), Gradle utilizza un grafo aciclico diretto (DAG) per determinare 
            l'ordine in cui i processi possono essere eseguiti.
            Gradle è stato progettato per sviluppi multi-progetto che possono crescere fino a divenire abbastanza grandi e supporta sviluppi 
            incrementali determinando in modo intelligente quali parti del build tree sono aggiornate ("up-to-date"), in modo che tutti i 
            processi che dipendono solo da quelle parti non avranno bisogno di essere ri-eseguiti; così facendo, il software riduce 
            significativamente il tempo di costruzione del progetto, in quanto, durante il nuovo tentativo di costruzione, verranno eseguite 
            solo le attività il cui codice è effettivamente stato alterato a partire dall'ultima costruzione completata. Gradle supporta 
            anche la costruzione del progetto per processi concorrenti, il che consente di svolgere alcuni compiti durante la costruzione 
            (ad esempio, i test automatizzati attraverso gli unit test), eseguiti in parallelo su più core della medesima CPU, su più CPU o 
            su più computer.

            I plugin iniziali sono concentrati soprattutto sullo sviluppo e implementazione di Java, Groovy, Scala e C++, ma l'intenzione 
            è quella di estendere il progetto anche ad altri linguaggi.







