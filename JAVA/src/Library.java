import java.util.ArrayList;
import java.util.HashMap;

public class Library {
    HashMap<String, Book> books;
    String var = "ciao";
    ArrayList<String> loansBook = new ArrayList<String>();

    Library() {
        this.books = new HashMap<String, Book>();
        
    }
    
    Boolean addBook(Book newBook) {
      
        if(!this.books.containsKey(newBook.title)) {
            this.books.put(newBook.title, newBook);
            return true;
        }
        else
            return false;
    }

    Boolean loanBook(Book loanBook) {
        
        try{
            if(!this.books.get(loanBook.title).loan) {

                this.books.get(loanBook.title).loan = true;
                this.loansBook.add(loanBook.title);
                return true;
            }
        }
        catch(Exception ex) {
            ex.printStackTrace();
        }

        return false;

    }

    void returnBook(Book loanBook) {
        try {
            this.books.get(loanBook.title).loan = false;
            this.loansBook.remove(loanBook.title);
        }
        catch(Exception e) {
            System.err.println("Il libro non è stato prestato");
        }
    }

    void printBooks() {
        System.out.println(this.books);
    }

    void printLoans() {
        System.out.println(this.loansBook);
    }
}
