INTRODUCTIONS

    Tecnologia che permettere di utilizzare JavaScript lato server. Vantaggi per sviluppo
    Backend, REST API(App mobile), Real-time, Software, Robotica(come Arduino).

ASYNC PROGRAMMATION 

    Node.js fornisce una serie di primitive I / O asincrone nella sua libreria standard che impediscono il blocco del codice 
    JavaScript e, in generale, le librerie in Node.js sono scritte utilizzando paradigmi non bloccanti, rendendo il 
    comportamento di blocco l'eccezione piuttosto che la norma.

    Tutta la Api della libreria di NodeJS è asincrona, non bloccano il flusso principale.

    -  call-back -> funzione che viene dichiarata ma eseguita in ritardo

    fread(file, N, function(error, data)) -> esempio

    console.log('Start')
    $.get('ajax.html, function(data)) {
        console.log('Middle:', data)
    }
    console.log('End');

    Output:
        Start
        End
        Middle

METHODS

    console

        .log
        .count -> conta quante volte viene stampata la stringa
        .time() -> segna il tempo di inizio
        .timeEnd() -> segna il tempo di fine
        
MODULE

    http

        .createServer() -> crea un nuovo server HTTP e lo restituisce.
        
        Ogni volta che viene ricevuta una nuova richiesta, l' requestevento viene chiamato, fornendo due oggetti: una richiesta 
        (un http.IncomingMessageoggetto) e una risposta (un http.ServerResponseoggetto).

    chalk

        .color -> per colorare
    
    progress

        new ProgressBar -> barra di caricamento

STRUCTURE

    terminare un programma

        Il processmodulo di base fornisce un metodo pratico che permette di programmazione uscita da un programma Node.js: 
        process.exit().

        Un programma uscirà normalmente quando tutta l'elaborazione è terminata.

        In questo caso è necessario inviare al comando un segnale SIGTERM e gestirlo con il gestore del segnale di processo:

        SIGKILL è il segnale che indica a un processo di terminare immediatamente e idealmente si comporterebbe come 
        process.exit().

        SIGTERM è il segnale che dice a un processo di terminare con grazia. È il segnale inviato da gestori di processo come 
        upstarto supervisorde molti altri.

        process.kill(process.pid, 'SIGTERM')

TERMINAL

    npm init -> per creare il progetto

        - entry point -> app.js
    
    node -> lo shell diventa interattivo, modalità REPL.

    N.B: È possibile passare un numero qualsiasi di argomenti quando si richiama un'applicazione Node.js.

        Espone una argv proprietà, che è un array che contiene tutti gli argomenti di chiamata della riga di comando.

        Il primo elemento è il percorso completo del nodecomando.

        Il secondo elemento è il percorso completo del file in esecuzione.

        Tutti gli argomenti aggiuntivi sono presenti dalla terza posizione andando avanti.

        Puoi iterare su tutti gli argomenti (incluso il percorso del nodo e il percorso del file) usando un ciclo:

            process.argv.forEach((val, index) => {
            console.log(`${index}: ${val}`)
            })



