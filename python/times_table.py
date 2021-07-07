# Stampare a video la tabellina di un numero da 1 a 10 fornito dall’utente
a= int(input("Indica il numero della tabellina: ")) 
for i in range(1,11):
    print(str(a)+' x '+ str(i)+' = ',a*i)

print("Stampa di tutte le tabelline: ") 
for i in range(1,11):
    print("Stampa della tabellina del numero: ",i) 
    k=1
    for j in range(1,11):
        print(str(i)+' x '+ str(j)+' = ',i*j) 
        print("----------------------")