public class Rectangle {

    int height = 0;
    int weight = 0;

    public Rectangle(int height, int weight) {
        this.height = height;
        this.weight = weight;
    }

    public void show() {
    
        
        if((this.height == this.weight || this.height < 1 || this.weight < 1)) {
            System.out.println("Errore!");
        }
        else{
            System.out.print("+");

            for(int i = 0; i < this.weight; i++) {
                System.out.print("-");
            }

            System.out.println("+");
            
            for(int i = 0; i < this.height; i++) {
                System.out.print("|");

                for(int j = 0; j < this.weight; j++) {
                    System.out.print(" ");
                }

                System.out.println("|");
                
                
            }
            
            System.out.print("+");

            for(int i = 0; i < this.weight; i++) {
                System.out.print("-");
            }
    
            System.out.print("+");
            System.out.println(" "+this.height+"X"+this.weight);



            

        }
    }
    public int perimetro() {
        return (this.height+this.weight)*2;
    }
    public int area() {
        return this.height*this.weight;
    }


    public static void main(String[] args) {

        int height = 15;
        int weight = 5;
        Rectangle figure = new Rectangle(height, weight);

        figure.show();

        System.out.println("Il Perimetro del rettangolo è: "+figure.perimetro());
        System.out.println("L'Area del rettangolo è: "+figure.area());
        
        
    }
}
