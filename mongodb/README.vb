INTRODUCTIONS

    database: modo strutturato per archiviare e accedere ai dati. Nello specifico
              MongoDB è un NoSQL database, ovvero che non utilizza l'approccio legacy.
              I dati in MongoDB sono salvati in documenti che sono salvati in collezioni.

    MongoDB: database di documenti NoSQL (Simili a file JSON, non ci sono tabelle)

AGGREGATION FRAMEWORK

    un altro modo per eseguire query su MongoDB:

    .aggregate() -> al posto di .find()

    N.B: funziona come una pipeline, tiene conto dell'ordine. Vari steps

    aggregate([{$project: {<field>:1,"_id":0}},{$group : {_id: "$<field>"}}])
    $match -> verifica la condizione
    $project -> proietta i risultatti desiderati
    $group -> raggruppa in base ad un valore (necessita _id:"valore")
    $group + $sum 


ATLAS

    database completamente gestico con un'ampia gamma di applicazioni MongoDB. Continene
    molti servizi e tool per l'archiviazione e il recupero dati.

    Clusters: gruppi di server che memorizzano i dati.
    Replica Sets: set di alcune istanze MongoDB.
    Instance: una singola macchina locale o cloud che runna uno specifico software.

    N.B: se succede qualche errore a una macchina del set di repliche i dati rimarranno 
         intatti. Ogni volta che modifichiamo i dati vengono replicati nei set.

    Atlas gestisce:

        - dettagli della creazione di cluster
        - mantenimento di una distribuzione di database
        - distribuzione tra provider di servizi cloud e regioni
        - sperimentare nuove funzionalità di MongoDB

    I DB e le collezioni vengono utilizzate quando vengono usate, si possono dichiarare
    implicitamemte.

COLLECTION

    è l'insieme dei documenti che costituiscono il MongoDB

DATA EXPLORER

    Atlas UI: è possibile interrogare la Atlas UI attraverso query

    Indixes -> gestione indici, consulenza utilizzo.

    aggregation -> mostra il processo della pipeline. Si trova il bottono export to language

DATA MODELING

    modellare i dati per migliorare le prestaizioni e le query capabilities

    N.B: I dati che sono utilizzati insime devono essere salvati insieme.

DOCUMENT

    Un modello per organizzare e salvare dati. Un documento è costituito dai "campi":

        - non si possono avere campi duplicati
        - ogni campo deve avere un valore associato
    
    Quando visualizzi o aggiorni i documenti nella shell Mongo DB sono in formato:

    • JSON (JavaScript Standard Object Notation)

        - racchiuso in {}
        - tra una key e un value si mettono i :
        - separare ogni key:value (fields) con una ,
        - le "keys" devono essere racchiuse tra le ""

        Pros
        1. Friedly (Intuitivo)
        2. Readble (leggibile)
        3. Familiar (familiare)

        Cons
        1. Text-based (basato sul testo quindi analisi molto lenta)
        2. Space-consuming (non efficiente in termini di spazio)

    MongoDb ha deciso di affrontare questi inconvenienti utilizzando BSON (Binary JSON):

    - Rappresentazione binaria per memorizzare i dati in formato JSON

    Pros
        1. Speed
        2. Space
        3. Flexibility
    
    • BSON è stato esteso rispetto JSON per aggiungere alcuni dati nativi non JSON 
        facoltativi: 

        Encoding: Binary

        Tipi

        - String
        - Boolean
        - Number(Integer, Long, Float,...)
        - Array
        - Date 
        - Raw Binary

FUNCTIONS

    (<query>)

    .drop() -> elimina l'intera collezione.
    .find() -> trova elemnto/i in base alla query (se non specifica ritorna 20 random dc)
    .findOne() -> ritorna il primo documento trovato
    .updateOne() -> aggiorna il primo file che soddisfa la query
    .updateMany({},{"$<method>": {"valuetomodify": value}}) -> aggiorna tutti i file che soddisfano 
                la query.

                <method>
                    $inc -> incrementa
                    $set -> setta un valore
                    $unset -> rimuove un valore
                    $push -> aggiunge un elemento ad un Array
    
    Cursor method -> non viene applicato ai dati ma ai risultati del set

        .pretty() -> ritorna gli elemnti ricercati in formato JSON.
        .count() -> conta il numero di elementi che verificano la condizione precedente
        .sort() -> ordina in base al field passato (field: 1 / -1) (cres/decres)
        .limit(n) -> ritorna i primi n documenti

INDIXES

    struttura dati speciale, non per forza alfabetica. Memorizza un set di dati per
    raggiungerli più facilmente.

    .createIndex() -> rende più facili le ricerche per non cercare nell'intero dataset
IT
    comando che serve per iterare all'interno di una collezzione attraverso un cursore:

    cursore -> puntatore al risultato di una query set.
    pointer -> un diretto indirizzo di memoria.

OPERATIONS

    IMPORT AND EXPORT DATA

        JSON
        - mongoimport -> (Import to the DB)
        - mongoexport -> memorizza il JSON degli stessi dati (Exports to the app)
    
        BSON
        - mongorestore -> (Import to the DB)
        - mongodump -> permette di ottenere i dati (Exports to the app)

        N.B: bisogna utilizzare le URI per le import e le export
    
    INSERT DOCUMENTS
    
        _id -> deve essere unico. E' generato automaticamente come ObjectId ma si puo' definire
           la propria chiave. Se non viene definito allora Mongo lo generà automaticamente.

        2 modi: 

        - Atlas UI -> new document
        - Mongo -> .insert(<document>)
    
        N.B: Per inserire più documenti da terminale all'interno dell'insert bisogna seguire
         questa sintassi ([{},{},{}])

        esplicitando ,{"ordered": false} indichiamo che bisogna riportare gli errori solamente
        dei documenti con _id duplicato.

    UPDATE DOCUMENTS

    - Atlas UI: pencil button
    - Mongo Shell -> .updateOne() e .updateMany()

    DELETE DOCUMENTS

    - Atlas UI: trash button
    - Mongo Shell -> .deleteOne() e deleteMany() (deleteOne utile solo su _id)

QUERY OPERATORS

    $ ha diversi usi:

        - precede gli operatori MQL
        - precede le Aggregation pipeline stages
        - permette l'accesso ai campi

    COMPARISON

        { <field>: { <operator>: <value> }} 

        $eq = EQual to
        $neq = Not EQual to
        $gt > Greater Than
        $lt < Less Than
        $gte > Greater Than or Equal to
        $lte < Less Than or Equal to the

    LOGIC

        {<operator> : [{statement1}, {statement2}]}

        $and -> utile quando bisogna usare un operatore più di una volta ("field")
        $or -> (field)
        $nor -> che non corrispondono ad entrambe
        $not 

        {"$and": lo stesso campo + volte} => {"campo": {"op1": value, "op2": value}}
    
    EXPRESSIVE

        {$expr: {<operator>: [$fiel1, $field2]} 

        $expr -> permette di utilizzare variabili e conditional statements

    ARRAY 

        $push -> aggiunge un elemento alla fine dell'array / trasforma un campo
        $all -> ritorna gli elemnti dove trova almeno un match
        $elemMatch -> almeno un elemtno che corrisponde alla query e stampa il resto
    
    PROJECTION

        {query}, {projection}

        1 - include il campo
        0 - esclude il campo

        N.B: Non si possono mesolare 1 e 0 in una proiezione, si può mescolare solo se 
             si esclude il campo id.

SUBDOCUMENTS

    per accedere ai campi MongoDb utilizza la dot notation.

    "field 1" : {
                        "some field" : "some number"
                        "other field" : {
                                            "also a field": "value",
                                            "field here": "val too"

                                        }
    }

    {"field 1.other field.also a field": "value"}

TERMINAL

    - show dbs -> mostra i database presenti nel Clusters.
    - use nome_database -> selezion il database.
    - show collections -> mostra la collezione dei documenti.
    - db.<colletion>.find(<query>) -> ricerca la query all'interno del database

    - it -> itera 20 elementi dopo all'interno di una collection
    - drop -> carica tutta la collection

UPSERT

    db.collection.updateOne({<query to locate}, {<update>}, <optional>{"upsert":false})

        upsert: true

            MATCH OK -> update
            MATCH NO -> insert
        

URI

    Uniform Resource Identifier

    srv - stabilisce unca connesione sicura tra la app e l'istanza

    mongodb+srv://user:password@clusterURI.mongodb.net/database

    