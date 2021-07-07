public class Power {
    public static void main(String[] args) {
        int potenza = 10;
        int result = 1;

        for(int i = 0; i < 9; i++) {
            result *= potenza;
            System.out.println(result);
        }
    }
}
