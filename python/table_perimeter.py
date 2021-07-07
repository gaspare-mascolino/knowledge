num = 1;
sum = 0;

for i in range(8):
    for j in range(8):

        #print(num, end=" ");

        if(i == 0 or j == 0 or i == 7 or j == 7):
            sum+= num;
            print(sum);

        if(num == 1):
            num += 1.5;
        else:
            num+= 3;
    print("\n");

print("La somma del perimetro è:",sum);