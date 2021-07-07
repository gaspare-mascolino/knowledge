num = 64;
sum = 0;

for i in range(8):
    for j in range(8):
        #print(num, end=" ");
        if(j%2 == 0):
            sum+=num;
            print(sum);
        num-=1;
    num+=4;
    print("\n");

print("La somma delle colonne pari è: ",sum);