INTRODUCTION

    un framework Node.js progressivo basato su TypeScript per la creazione di applicazioni lato server efficienti, 
    affidabili e scalabili di livello aziendale.

CONTROLLER 

    Il file di ingresso dell'applicazione che utilizza la funzione principale NestFactoryper creare un'istanza dell'applicazione Nest.
    Il meccanismo di routing controlla quale controller riceve quali richieste. Spesso, ogni controller ha più di un percorso e percorsi 
    diversi possono eseguire azioni diverse.

    @Controller('name') -> raggruppa tutti i percorsi cn prefisso name, serve per non ripetere il prefisso del percorso.

        @Get() ->  concatenando il prefisso (facoltativo) dichiarato per il controller e qualsiasi percorso specificato nel decoratore della 
                   richiesta. GET /name
        
        @Post('concat') -> POST name/concat 

PROVIDERS    

     Un provider può iniettare dipendenze; Ciò significa che gli oggetti possono creare varie relazioni tra 
     loro e la funzione di "cablaggio" delle istanze degli oggetti può essere ampiamente delegata al sistema 
     runtime Nest.

     I controller gestiscono le richieste HTTP e le attività più complesse vengono delegate ai providers.
     Ex: archiviazione e recupero dati.

     @Injectable() -> nel servizio
     constructor(private Service: service) -> nel controller

STRUCTURE

    src
        app.controller.ts -> Un controller di base con un unico percorso.
        app.controller.spec.ts -> I test unitari per il controller.
        app.module.ts -> Il modulo radice dell'applicazione.
        app.service.ts -> Un servizio base con un unico metodo.
        main.ts -> Il file di ingresso dell'applicazione che utilizza la funzione principale NestFactoryper creare un'istanza dell'
                   applicazione Nest. 

TERMINAL

    npm run start
    nest g resource [name] -> realizzazione rapida di un controller CRUD con la convalida incorporato, è possibile utilizzare il CLI 
                              generatore CRUD.
    nest g controller [name] -> per creare un controller utilizzando la CLI.

    nest g module [name] -> per generare un modulo