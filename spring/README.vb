INTRODUCTION

    un framework open source nato con l’intento di gestire la complessità nello 
    sviluppo di applicazioni enterprise.

ACCESSO AI DATI

    Uno degli aspetti fondamentali quando si costruisce un’applicazione è la persistenza dei dati, per realizzare la quale, 
    nel mondo Java, esiste una varietà numerosa di API e framework, come JDBC o Hibernate.

        1. JDBC
        2. Java Persistence API (JPA)
        3. Java Data Objects (JDO)
        4. Hibernate
        5. Common Client Interface (CCI)
        6. iBATIS SQL Maps
        7. Oracle TopLink

AOP (ASPECT ORIENTED PROGRAMMING)

    Grazie all’utilizzo di classi e interfacce e a concetti come ereditarietà, polimorfirsmo e incapsulamento è possibile 
    scrivere del software modulare, facilmente manutenibile e riutilizzabile.
    
    La comprensione di AOP passa attraverso alcuni concetti fondamentali:

        - Crosscutting Concern

            Comportamento trasversale all’applicazione che si ripercuote in più punti dell’object model (caching, logging).

        - Aspect 

            È l’equivalente di una classe in OOP ed è utilizzata nella programmazione ad aspetti per modularizzare i 
            crosscutting concern. Includono:

            - Advice: ne implementano le logiche applicative

                Descrive l’operazione da compiere da parte di un aspetto ad un determinato Join Point. Un advice, a differenza 
                di un metodo che deve essere invocato esplicitamente, viene eseguito automaticamente ogni volta che ad un 
                determinato evento (Join Point) si verifica una particolare condizione (Pointcut). Esistono diversi tipi di 
                Advice:

                    • BeforeAdvice -> prima dell’esecuzione di un Join Point.
                    • AfterReturning -> dopo l’esecuzione di un Join Point in assenza di eccezzioni
                    • AfterThrowing -> dopo l’esecuzione di un Join Point che ha generato un eccezione
                    • AfterAdvice -> dopo l’esecuzione di un Join Point indipendentemente dal suo esito
                    • AroundAdvice -> costituisce l’Advice più versatile in quanto consente di prendere il controllo dell’intero
                                      Join Point. Non solo è possibile specificare le stesse cose degli Advice precedenti ma è 
                                      anche possibile decidere quando e se eseguire il Join Point o addirittura generare 
                                      eccezioni.
                    
            - Pointcut: regolano l’esecuzione, descrive le regole con cui associare l’esecuzione di un Advice ad un determinato 
                        Join Point.

        - Join Point

            Rappresenta un punto preciso nell’esecuzione del programma, come l’invocazione di un metodo o il verificarsi 
            di un eccezione.
        
        - Target: anche chiamato Advised Object rappresenta l’oggetto sul quale agisce l’Advice.

    N.B: l’Aspect Oriented Programming rappresenta, insieme all’Inversion of Control, una delle caratteristiche principali alle 
         quali Spring deve la sua popolarità.
    
    Il suo supporto è garantito da Spring AOP, un modulo nativo del framework che nasce con lo scopo di fornire una completa 
    integrazione con il container di IoC.
    A partire dalla versione 2.x Spring AOP è stato esteso con il supporto alle annotation AspectJ (@AspectJ), portando di fatto 
    un forte cambiamento nel modo di concepire AOP in Spring.
            
DATA ACCESS OBJECT

    Pattern architetturale che ha come scopo quello di separare le logiche di business da quelle di accesso ai dati.
    L’idea alla base di questo pattern è quello di descrivere le operazioni necessarie per la persistenza del modello in 
    un’interfaccia e di implementare la logica specifica di accesso ai dati in apposite classi.

HIBERNATE (SPRING)

    DATASOURCE

        - DriverManagerDataSource: un semplice datasource in grado di aprire una connessione ogni volta che questa viene richiesta.
        - SingleConnectionDataSource:  in ambienti più complessi, si suggerisce l’utilizzo di datasource più efficienti.

    HIBERNATE DAO

        Come per JDBC, Spring ci viene in aiuto fornendo HibernateTemplate: uno specifico template che si fa carico delle 
        operazioni di gestione, tra le quali:

            1. Richiesta della connessione alla factory
            2. Apertura della transazione
            3. Gestione delle eccezioni
            4. Commit/Rollback della transazione
            5. Chiusura della connessione

        N.B: Spring mette a disposizione la classe di supporto HibernateDaoSupport per facilitarne l’injection all’interno dei DAO.

    HIBERNATE MAPPING

        Perché un ORM sia in grado di generare codice SQL è necessario specificare il mapping tra gli oggetti da persistere e le 
        tabelle nel database:

            - XML
            - JPA Annotations -> @Entity, @Table, @Column

    TRANSACTION MANAGER  

        componente in grado di creare e gestire le transazioni attraverso un datasource e al cui utilizzo si affida 
        HibernateTemplate.

    SESSION FACTORY

        Oggetto responsabile dell’apertura delle sessioni verso il database. Tali parametri includono:

            1. Datasource da utilizzare per la connessione con il database
            2. Dialetto SQL utilizzato da Hibernate per l’ottimizzazione delle query
            3. Lista degli eventuali file di mapping
            4. Altre informazioni accessorie
        
IOC CONTAINER

    CONTAINER

        Un modo migliore per poter lavorare con la Dependency Injection è quello di utilizzare come assembler uno IoC Container 
        in grado di compiere operazioni di injection.

        Per definizione un container è un componente esterno che si prende carico di una serie di compiti esonerando così lo 
        sviluppatore dal preoccuparsene. Uno IoC Container non è altro che un container specializzato nella dependency injection, 
        che basandosi su apposite configurazioni definite dall’utente (generalmente attraverso l’utilizzo di un file xml) è in 
        grado di compiere opportune operazioni di injection.
    
    Considerato il cuore di Spring, lo IoC Container fornisce un contesto altamente configurabile per la creazione e 
    risoluzione delle dipendenze di componenti che qui vengono chiamati bean (da non confondere con i JavaBean).

    N.B: In Spring un bean non deve aderire a nessun tipo di contratto e può essere rappresentato da una qualunque classe Java.

    Tecnicamente parlando, lo IoC Container è realizzato da due interfacce:

        1. BeanFactory, che definisce le funzionalità di base per la gestione dei bean
        2. ApplicationContext, che estende queste funzionalità basilari aggiungendone altre tipicamente enterprise come ad 
                               esempio la gestione degli eventi, l’internazionalizzazione e l’integrazione con AOP.

        L’interfaccia BeanFactory rappresenta la forma più semplice di IoC Container in Spring e ha il compito di:

        - creare i bean necessari all’applicazione.
        - inizializzare le loro dipendenze attraverso l’utilizzo dell’injection.
        - gestirne l’intero ciclo di vita.

    In Spring esistono diverse implementazioni di BeanFactory, la più comune delle quali è senza dubbio la XmlBeanFactory che 
    permette di utilizzare uno o più file XML per descrivere la configurazione da utilizzare.

INVERSION OF CONTROL (IOC)

    Basato sul concetto di invertire il controllo del flusso di sistema (Control Flow) rispetto alla programmazione tradizionale. Questo principio è 
    molto utilizzato nei framework e ne rappresenta una delle caratteristiche basilari che li distingue dalle API.

    Dependency Injection (DI) si riferisce ad una specifica implementazione dello IoC rivolta ad invertire il processo di risoluzione delle dipendenze,
    facendo in modo che queste vengano iniettate dall’esterno. Banalmente, nel caso della programmazione Object Oriented, una classe A si dice 
    dipendente dalla classe B se ne usa in qualche punto i servizi offerti.

    L’idea alla base della Dependency Injection è quella di avere un componente esterno (assembler) che si occupi della creazione degli oggetti e delle 
    loro relative dipendenze e di assemblarle mediante l’utilizzo dell’injection. In particolare esistono tre forme di injection:

        1. Constructor Injection, dove la dipendenza viene iniettata tramite l’argomento del costruttore
        2. Setter Injection, dove la dipendenza viene iniettata attraverso un metodo “set”
        3. Interface Injection che si basa sul mapping tra interfaccia e relativa implementazione (non utilizzato in Spring)

ORM

    Un ORM, acronimo di Object Relation Mapping, è una tecnologia che nasce per semplificare la persistenza di oggetti in un 
    database relazionale, generando automaticamente il codice SQL necessario.

    Es. Hibernate, Oracle TopLink, iBATIS SQL Maps, JDO e JPA.

PROS

    - leggero
    - lightweight container
    - serie completa di strumenti generalo
    - testing facile da implementare
    - escludere parti del framework non necessarie all'applicazione.

SPRING JDBC

    La forma primaria di accesso ai dati in Java è senza dubbio JDBC, un’API creata per rendere platform-independent 
    l’interazione con i RDBMS.

        1. Richiesta della connessione al datasource
        2. Creazione del PreparedStatement e valorizzazione dei parametri
        3. Esecuzione del PreparedStatement
        4. Estrazione dei risultati dal ResultSet (in caso di interrogazioni)
        5. Gestione delle eccezioni
        6. Chiusura della connessione

    N.B; Spring offre diverse possibilità per la persistenza dei dati mediante JDBC, la principale delle quali è l’utilizzo 
         della classe JDBCTemplate.
        
STRUCTURE

    • Core Container 

        Rappresenta la parte principale di Spring e sopra di esso è costruito l’intero 
        framework. I moduli di Core e Beans sono responsabili delle funzionalità di 
        Inversion Of Control (IoC) e Dependency Injection ed hanno come compito 
        principale la creazione, gestione e manipolazione di oggetti di qualsiasi 
        natura che, in Spring, vengono detti beans.
    
    • Data Access/Integration Object (DAO)

        Fornisce un livello di astrazione per l’accesso ai dati mediante tecnologie 
        eterogenee tra loro come ad esempio JDBC, Hibernate o JDO. Questo modulo tende 
        a nascondere la complessità delle API di accesso ai dati, semplificando ed 
        uniformando quelle che sono le problematiche legate alla gestione delle 
        connessioni, delle transazioni e delle eccezzioni.

        N.B: Notevole attenzione è stata data all’integrazione del framework con i 
        principali ORM in circolazione compresi JPA, JDO, Hibernate, e iBatis. 
        Oltre a questo il Data Access si occupa di fornire supporto per il Java Message 
        Service e per svariate implementazioni di Object/XML Mapper come JAXB, Castor e 
        XMLBean.
    
    • Spring AOP

        Aggiunge al framework la funzionalità della programmazzione Aspect Oriented. 
        In Spring l’utilizzo di AOP offre il meglio di sé nella gestione delle 
        transazioni, permettendo di evitare l’utilizzo degli EJB per tale scopo.
    
    • Web

        Livello responsabile delle caratteristiche Web del framework. Oltre alle 
        funzionalità basilari, per la creazione di applicazioni Web, questo livello 
        mette a disposizione un’implementazione del pattern MVC realizzando lo Spring 
        MVC Framework (moduli Web-Servlet e Web-Portlet).

        Il framework MVC è ampiamente configurabile attraverso delle Strategy, può 
        operare sia in contesti servlet che portlet e può essere utilizzato con 
        numerose tecnologie di view comprese JSP e Velocity.

    • Testing 

        Un’altra delle caratteristiche per il quale Spring si contraddistingue è il 
        supporto al testing. Questo livello mette a disposizione un ambiente molto 
        potente per il test delle componenti Spring, grazie anche alla sua 
        integrazione con JUnit e TestNG e alla presenza di Mock objects per il testing 
        del codice in isolamento.

        
    
