ARRAY

    gli array sono degli oggetti,  possono essere di tipi primitivi o di oggetti

    <Tipo> nome[]

    .length -> restituisce la lunghezza

CLASS

  le <classi> implementano il principio dell'incapsulazione, i <campi> rappresentano lo stato interno di un oggetto.
  Il <costruttore> inizializzano l'oggetto in uno stato noto, mentre i <metodi> permettono di cambiare lo stato in modo 
  controllato.

  i campi possono essere:

    • primitivi

    • riferiti ad altri oggetti

COMAND

  I comandi contengono espressioni e possono essere semplici o composti.

  • semplici e blocchi

    - espressione;

  • condizionali: if-else, switch

    - if(<condizione>) -> (Espressione booleana)
          <comando>
      else -> (Si riferisce all'if più vicino)
          <comando>
    
    - switch (<condizione>) {
        
        case <val1>:
              <comando>
              break;
        case <val2>:
              <comando>
              break;
        default:
              <comando>
              break;


      }

  • cicli: while, do-while, for, for-each

    - while(<condizione>) {
        <comando>
      }

      • Il comando viene eseguito finché è vera la condizione
      • Il comando può anche essere eseguito 0 volte
    
    - do {
        <comando>
      }while(<condizione>);

      • Il comando viene eseguito finché è vera la condizione
      • Verrà sempre eseguito almeno una volta
    
    - for(<inizio>; <condizione>; <incremento>) {
        <comando>
      }

      1. Espressione di <inizio> 
      2. Valutata la <condizione>
      3. Viene eseguito il <comando>
      4. Viene eseguita l'espressione di <incremento>
      
    - for( <Type item : itemCollection> ) {
        <comando>
      }

  • interruzione: break, continue 

      all'inizio dei cicli e possibile apporre una label

      <nome_label>:
       <ciclo>

      in questo modo è possibile apporre a break e continue una specifica label per riferirsi ad un determinato ciclo.

  • ritorno: return

      ritorno di un main o di un metodo
      
  • eccezione: try-catch-finally

    le chiamate di metodi possono generare eccezioni, Le eccezioni si propagano causando la terminazione del programma con 
    un messaggio di errore se non vengono gestite.

    try {
      <comando−che−genera−eccezione>
    } catch (Exception ex) { ex.printStackTrace(); }

    Quando si dichiara un metodo che può sollevare eccezioni (generalmente chiamando altri metodi), si può "lasciar passare"
    le eccezioni aggiungendo throws Exception nella dichiarazione del metodo

COMMENTS

  /* Questo è un commento */
  /** Questo è un commento javadoc il quale crea automaticamente la documentazione delle sorgenti */

COSTANTS (NUMERICS)

    - decimali
    - esadecimali: cifre 0-9, A-F (0x in testa)
    - ottali: cifre 0-8 (0 in testa)

DECLARATIONS

  {TIPO} nomeVariabile;
  {TIPO} nomeVariabile = {INIZIALIZZAZIONE};

HEREDITARIETY

  L'ereditarietà consente di riutilizzare il codice esistente.

  Conversione -> <classe> a = new <sottoclasse>(); 

EXPRESSIONs

  Le espressioni sono suddivise in:

  • Costanti 
  • Operatori
  • Variabili

METHOD

  {TIPO} nomeMetodo({PARAMETRI}) {
    // Corpo metodo
  }

NUMBERS

  + -> in senso unario trasfroma il numero in una stringa +var
  .parseInt() -> restituisce la stringa
  
OPERATORS

    - relazionali:  > >= < <= | = ==
    - aritmetici:   + - * / %
    - binari:       & | ^ >> << <<<
    - logici:       && || ?:
    - incremento:   ++ --
    - assegnamento: = += -= *= /=
    
TYPE OF CHARATHER

    - backslash                  \\
    - continuazione              \
    - spazio indietro            \b
    - ritorno carrello           \r
    - salto pagina               \f
    - tabulazione orizzontale    \t
    - nuova linea                \n
    - virgoletta semplice        \'
    - doppia virgoletta          \*
    - carattere ottale           \ddd###
    - carattere unicode          \udddd####

TYPE OF DATE

  • Primitivi:

    - byte    8 bit
    - short   16 bit
    - int     32 bit
    - long    64 bit

    - boolean 1 bit

    - char    16 bit (carattere UNICODE)

    - float   32 bit (IEEE)
    - double  64 bit (IEEE)
  
  • Oggetti -> Una istanza di un oggetto è generata dal costruttore, una variabile che riferisce un oggetto è un PUNTATORE.

STRINGS

    sono degli oggetti formati da tipi primitivi e sono immutabili, per questo motivo possono essere condivise tra diversi
    thread senza recare problemi.

    .length -> restituisce la lunghezza

VISIBILITY
                                  PUBBLICO        PROTETTO        PACKAGE       PRIVATO
                                                                 (DEFAULT)

  STESSA CLASSE                      X               X               X             X
  STESSO PACKAGE                     X               X               X
  SOTTOCLASSE (NO PKG)               X               X
  NON SOTTOCLASSE (NO PKG)           X







