num = 1;
d1 = 0;
d2 = 0;

for i in range(8):
    for j in range(8):
        print(num, end=" ");
        
        if(i==j):
            d1 = d1 + num;
        if(i==7-j):
            d2 = d2 + num;
        
        num = num + 3;
    print("\n");

print("La somma della diagonale principale è:", d1);
print("La somma della diagonale secondaria è:", d2);