ARRAY 
    .indexOf() -> ritorna l'indice dell'elemento
    .slice(start, end (not included)) -> ritorna un sottoarray di quello originale
    .split(start, deleteCount) -> rimuove elemento/i dall'array.
    
CLASS

    class NomeClasse {
    
        // Metodo contratto, migliore per creare una classe
        constructor(
           public readonly nome: type,
          public nome2: type
        ) {
             //
          }
    }

COMPILATION

    tsc nomefile.ts
    node nomefile.js

METHODS

    get nomeFacoltativo(): type {
        return this.nomeVariabile;
    }

    set nomeFacoltativo(): void {

    }
    
TYPE OF DATE

    • number (sia interi che in virgola mobile)
    • string
    • boolean
    • Array (dichiarazione in due modi):

        - tipo[]
        - Array<tipo>
        
    • tuple
    • oggetto {}

PROS RATHER THAN JS

    - variabili tipizzate
    - funzionalità aggiuntive 

        • tuple
        • enum
        • classi e interfacce
        • funzioni tipizzate
