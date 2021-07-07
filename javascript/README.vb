ARRAY 

    .filter(condizione) -> nuovo array contentente tutti gli elementi che passano il test 
                           implementato dalla funzione. 
    .indexOf() -> ritorna l'indice dell'elemento
    .map -> crea un nuovo array con i risultati della chiamata di una funzione fornita su ogni 
            elemento dell'array chiamante.
    .reduce -> fornice una funzione reducer su ogni element orisultante in un unico output
    .reverse() -> inverte l'ordine dell'array
    .slice(start, end (not included)) -> ritorna un sottoarray di quello originale
    .split(start, deleteCount) -> rimuove elemento/i dalla stringa e crea un array.
    

CYCLE

    - for(type n of nameCollection)
    
COMMENTS

    // Questo è un commento

FUNCTIONS

    function fn() {

    }

    const fun = function f() {

    };

NPM

    repository globale di codice risolti in javascript
    
NUMBERS

   .toString -> trasforma il numero in una stringa
   .toString(2) -> trasforma il numero in una stringa binaria

    
METHODS

    - clearInterval(interval) -> interrompe un intervallo

    - setInterval(function, milliseconds) -> metodo continuerà richiamo della funzione ogni x millisecondi fino a quando 
                                             clearInterval() non è chiamato, o la finestra è chiusa.

OPERATORS

   • == (abstract equality) -> effettua un conversione dei valori non considerando il tipo.
   • === (strict equality) -> confronta sia i valori che il tipo. 

   • != (not equal)
   • !== (not equal value or not equal type)

STRINGS

    N.B: l'indice della stringa parte da 0

    .join('') -> serve per compattare array di sotostringhe in un unica stringa.
    .split('') -> serve per splittare una stringa in array di sottostringhe.
    .substring(x, y) -> sottostringa da indice x a y non compreso. substring(x) da x in poi
    .toLowerCase() -> stringa minuscola.
    .toUpperCase() -> stringa maiuscola.

TYPE OF DATE

    i tipi di dato sono numeri, stringhe, booleani, null e undefined:
    N.B: Non c'è bisogno di specificare il tipo su JS

    var -> variabile globalmente in uno script o localmente in una funzione a prescindere dal blocco di codice. Se dichiarata
           all'interno di un blocco è accessibile anche all'esterno.  (NON HA BLOCK SCOPE)
            
    let -> permette di dichiarare variabili limitandone la visibilità ad un blocco di codice, o ad un'espressione in cui è 
           usata. Se dichiarata all'interno di un blocco non è accessibile all'esterno (HA BLOCK SCOPE).

    const -> non possono essere riassegnate

    N.B: Le variabili dichiarate con let non sono accessibili tramite l'oggetto window.
    N.B: Le variabili non dichiarate sono UNDEFINED.