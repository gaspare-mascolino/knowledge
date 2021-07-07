import java.util.Scanner;

public class BankAccount {
    
    private int balance;
    private int pin;
    
    public BankAccount(int balance, int pin) {
        this.balance = balance;
        this.pin = pin;
    }

    public void withdraw(int amount) {
        if(balance - amount >= 0) {
            balance -= amount;
        }
        else{
            System.out.println("\nFONDI INSUFFICIENTI!");
        }
    }

    public void deposit(int amount) {
        balance += amount;
      
    }
    
    public void balance() {
        
        System.out.println("\n€"+balance);
    }

    public void setPin(int pin1, int pin2) {
        if(pin1 == pin2) {
            this.pin = pin1;
            System.out.println("\nPIN CAMBIATO CON SUCCESSO");
        }
        else {
            System.out.println("\nI PIN NON COINCIDONO");
        }
    }

    public boolean verify(int pin) {
   
        if(pin == this.pin) {
                System.out.println("\nPIN CORRETO!");
                return true;
            }
        else {
            System.out.println("\nPIN ERRATO!");
            return false;
        }
    }


    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int balance = 0;
        int pin = 0;
        int value = 0;

        System.out.println("\nInserisci saldo attuale");
        balance = in.nextInt();

        System.out.println("\nInserisci PIN");
        pin = in.nextInt();

        BankAccount conto = new BankAccount(balance, pin);

        System.out.print("\033[H\033[2J");  
        System.out.flush(); 
        
        
        do {
             
            System.out.println("\n1. Mostra saldo");
            System.out.println("2. Preleva");
            System.out.println("3. Deposita");
            System.out.println("4. Cambia PIN");
            System.out.println("5. Esci");
        
            value = in.nextInt();

            switch(value) {

                case 1:
                    System.out.println("\nInserisci il tuo PIN:  ");
                    if(conto.verify(in.nextInt())) {
                        conto.balance();
                    }
                    break;

                case 2:
                    System.out.println("\nInserisci il tuo PIN:");
                    if(conto.verify(in.nextInt())) {
                        System.out.println("\nInserisci importo: ");
                        conto.withdraw(in.nextInt());
                    }
                    break;

                case 3:
                System.out.println("\nInserisci il tuo PIN: ");
                if(conto.verify(in.nextInt())) {
                    System.out.println("\nInserisci importo: ");
                    conto.deposit(in.nextInt());
                }
                break;

                case 4:
                System.out.println("\nInserisci il tuo PIN: ");
                if(conto.verify(in.nextInt())) {
                    System.out.println("\nInserisci il nuovo PIN: ");
                    pin = in.nextInt();
                    System.out.println("\nReinserisci il nuovo PIN: ");
                    conto.setPin(pin, in.nextInt());
                }
                break;

                default:
                    System.out.println("\nInserisci un valore valido!");
            }

            if(value !=5) {
                System.out.println("\nPremi quasiasi numero per continuare...");
                in.nextInt();
            }

            System.out.print("\033[H\033[2J");  
            System.out.flush();  

        }while(value != 5);

        in.close();
    }
}

    

