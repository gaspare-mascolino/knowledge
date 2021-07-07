import java.util.Random; 

public class Dice {
    private int side = 6;
    private Random result;

    /** Costruttore che crea l’oggetto gen.*/
    public Dice() {
    
        this.result = new Random(); 
    }


    public static void main(String[] args) {
        Dice dado = new Dice();

        System.out.println(dado.result.nextInt(dado.side+1));
    }
}
