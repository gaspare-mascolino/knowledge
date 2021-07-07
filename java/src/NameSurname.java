public class NameSurname {
    
    public static void main(String[] args) {

        String name = "Gaspare Mascolino";
        
        System.out.print("+");

        for(int i = 0; i < name.length(); i++) {
            System.out.print("-");
        }

        System.out.println("+");

        System.out.print("|");
        System.out.print(name);
        System.out.println("|");

        System.out.print("+");

        for(int i = 0; i < name.length(); i++) {
            System.out.print("-");
        }

        System.out.println("+");

    }
}
