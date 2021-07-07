BINDING

    4 modi:

        - Interpolazione : componente -> template

            {{nomevariabile}}   (nome nel ts)   

        - Event Binding -> Dal figlio al padre, 
            
            <selettore (evento)="handler()"></selettore>    (evento=nomevariabileevento, handler=netodopadre)
                                                             @Output nomevariabileevento;
        - Property Binding -> Dal padre al figlio

            <app-figlio [nomeProprietà] ="valore"></app-figlio>

        - Two way Data Binding: utilizzato per i form, bidirezionale template <--> componente. Se
                                si cambia qualcosa nel template si cambia anche nel componente e
                                viceversa.
        
        [(ngModel)] = "nomevariabile"  (nel ts)

CICLE
        
    -  *ngFor
        <selettore *ngFor= "type n of nameCollection"></selettore>

CONDITION
    - *ngIf -> mostra l'elemento solo se la condizione è verificata
    <selettore *ngIf= "condizione"></selettore>

COMPONENTS 

    - stateless -> il padre gestisce gli stati degli elementi più bassi.

CLASS

    class NomeClasse {
    
        // Metodo contratto, migliore per istanziare una classe
        constructor(
           public readonly nome: type,
          public nome2: type
        ) {
             //
          }
    }

DIRECTIVE

    <elemento direttiva><\elemento> -> solo in questo caso. Non si può interpretare come tag
    
    Possiamo considerarlo come un componente senza un template, sono catalogate in due tipi:

        1. strutturale -> (raro) alterano fisicamente la struttura del DOM (ngFor/ngIf) 
        2. attributo -> non alterano il dom aggiungendo/rimuovendo elementi ma modificano gli 
                        attributi sull'elemento dove abbiamo posto la direttiva.
    
    AppDecoratorName -> Si usa come un attributo, su qualcosa che già esiste.

    @HostListener(evento) -> sopra il metodo si posiziona il decorator, ascolta un evento ed 
                             esegue il metodo ad esso assoiato quando si verifica l'evento per 
                             cui è in ascolto.
     
EVENTS

    Figlio -> Padre (Event Binding)

        1. Creare una proprietà che detenga l'istanza di un emettitore di eventi. 
        
            @Output() nomeEvento: EventEmitter<interfaccia> = new EventEmitter()  (Angular core)

        2.  Lanciare l'evento dal figlio 
        
            nomeevento.emit({oggettoInterfaccia})
    
        3.  Catturare l'evento dal padre
            
            <app-figlio (nomeEvento) ="metodo($event)"></app-figlio> // per mandare il payload

        4.  Gestire evento dal padre

            metodo(p: tipo/interfaccia): void

    Padre -> Figlio (Property Binding)

        1. Creare una proprietà che detenga l'istanza di una variabile che si vuole passare.

            @Input() nomeVariabile; 

        2. <app-figlio [nomeProprietà] ="valore"></app-figlio>

GERARCHY

    sx: figlio
    dx: padre

    N.B: Vale sia per Event.B che per Property.B

LIFECYCLE

    ngOnChanges -> Viene scatenato più volte, anche durante l'esecuzione dell'applicativo. Ogni 
                   volta che avviene un cambiamento di stato delle proprietà "@Input" (non tutte!).
                   Viene scatenato prima di ngOnInit perchè considera anche l'inizializzazione.
    ngOnInit -> Viene eseguito al termine dell'eleaborazion di tutte le direttive di uno specifico
                selettore, serve per comunicare con i servzi esterni, chiamate ad un backend. 
                (Eseguito solo una volta)
    ngDoCheck -> Permette di eseguire controlli al termine del digest cycle di Angular, raro 
                 insieme a ngOnChanges.
        ngAfterContentInit
        ngAfterContentChecked
        ngAfterViewInit -> Informazione precisa nel momento in cui il template del componente viene
                           elaborato (Fine HTML). Utile perchè attraverso decorator possiamo
                           individuare i vari tag inizializzati. (ViewChildren)

                           @ViewChildren ->
        ngAfterViewChecked -> Viene scatenato ogni qualvolta la view viene rielaborata.
    ngOnDestroy

PROS RATHER THAN ANGULAR JS

    • istanzia automaticamente un web server
    • è diviso in più mouduli e non in un unico file JS
    
ROUTING 

    .forRoot -> ogni volta che viene chiamato sovrascrive la configurazione precedente.

    1. Per ciascun componente bisogna associare un percorso di navigazione.

        routes: Routes = [{
            component: NomeComponente,
            path: 'percorso'
            },
            
    2. Non bisogna utilizzare href (NON SAREBBE UNA SINGLE PAGE APP), bensì: 
        
        <a routerLink="/nome">

    3a. Se si vuole inserire un parametro bisogna utilizzare i due punti(:)

    3b. Successivamente importare nel costruttore ActivatedRoute

    N.B: Per fare un routing innestato bisogna creare un nuovo module e un nuovo routing-module.

    4. all'interno di una root si possono definire più children.
    
    Guard -> Servizio per limitare l'accesso a personale non autorizzato.
    
SERVICE 

    Per richiedere l'iniezione di una istanza bisogna posizionarsi nel costruttore di una qualsiasi
    classe decorata.
    All'interno del costruttore:

    constructor(nameService: NameService);

    Posto in cui si gestisce la Business Logic, l'interazione viene gestita dai componenti.

    Dopo che la DI istanzia la prima volta il servizio, non si distugge anche se l'istanza termina.
    Rimane in memoria. Bisogna iscriversi e discriversi .subscribe e .unsubscribe

    N.B: Il servizio fa da ponte, utile per componenti distanti gerarchicamente.

    import {HttpClientModule} from '@angular/common/http' -> Servizio http.

    N.B: Tra diversi module i servizi non comunicano

STRUCTURE

    cartella principale src:

        • index.html
            <app-root></app-root>

        • main.ts
            viene tradotta in JS, 

            if (environment.production) -> indica se l'applicazione è in un ambiente di sviluppo o 
                                           di produzione limitandone gli output all'interno della 
                                           console del browser.
            
            platformBrowserDynamic()... -> serve per far partire angular all'interno di un browser.

        • app.module.ts
            @NgModule({Object literal}) -> decorator
                declarations -> chiave (array), indica i componenti, le direttieve e le pipe che 
                                fanno parte dell'applicazione.
                imports -> chiave, importa i vari ,moduli.
                providers -> chiave, declinazione dei servizi
                bootstrap -> chiave, prende le componenti da mostrare in prima battuta
        
        • app.component.ts

            app-root -> attraverso il modulo è la chiave della pagina html.

TERMINAL

    node -v -> versione di node
    npm -v -> versione npm

    npm install -g @angular/cli -> aggiornare e installare angular CLI
    ng -v / ng version -> versione angular CLI (ng contrazione di angular)

    ng serve -> serve l'applicazione, parte dal file angular.json

    NOTAZIONI

        camelCase
        PascalCase
        snake_case
        dash-case / kebab-case -> notazione di Angular

    ng new nome-del-progetto

        1. Implementare i meccanismi di routing? (y)
        2. Quale CSS utilizzare? (SCSS)

    ng generate component components/nome (in dash-case) -> creare un nuovo componente, 
                                                            viene aggiunto nell'array declarations 
                                                            e viene creato il selettore.

    ng generate directive directives/nome -> creare una nuova direttiva, viene aggiunta all'array 
                                             declarations.

    ng generate service services/nome-servizio

    ng generate guard guards/nome-guard
    
    ng generate pipe pipes/nome-pipe
    
    npm install --save bootstrap
    
    ng build

