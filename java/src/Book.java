import java.util.Scanner;

public class Book {
    String title;
    Boolean loan;

    Book(String title) {
        this.title = title;
        this.loan = false;
    }

    public static void main(String[] args) {
        Library library = new Library();
        int choise = 0;
        Scanner in = new Scanner(System.in);

       

        do{
            System.out.print("\033[H\033[2J");  
            System.out.flush(); 

            System.out.println("Scegli una operazione");
            System.out.println("1. Aggiungi libro");
            System.out.println("2. Chiedi in prestito libro");
            System.out.println("3. Restituisci Libro");
            System.out.println("4. Stampa libri in magazzino");
            System.out.println("5. Stampa libri in prestito");
            System.out.println("6. Esci");

            choise = in.nextInt();

            System.out.print("\033[H\033[2J");  
            System.out.flush(); 

            switch(choise) {

                case 1:
                    System.out.println("Inserisci il nome del libro:");
                    library.addBook(new Book(in.next()));
                    break;
                case 2:
                    System.out.println("Inserisci il nome del libro:");
                    library.loanBook(new Book(in.next()));
                    break;
                case 3:
                    System.out.println("Inserisci il nome del libro:");
                    library.returnBook(new Book(in.next()));
                    break;
                case 4:
                    System.out.println("Libri in magazzino");
                    library.printBooks();
                    break;
                case 5:
                    System.out.println("Libri in prestito");
                    library.printLoans();
                    break;
                case 6:
                    System.out.println("Chiudo applicazione");
                    break;
                default:
                    System.out.println("Inserisci valore valido");
                
            }

            System.out.println("Premi qualsiasi valore per continuare...");
            in.next();

        }while(choise != 6);

        in.close();
    }
}
