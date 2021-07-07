print("Benvenuto nella calcolatrice 2.0. Digita l’operazione che intendi eseguire e successivamente i due operandi:")
continuare='1'
while (continuare=='1'):
    print("a) Addizione\t\t\tb) Sottrazione") 
    print("c) Moltiplicazione\t\td) Divisione") 
    scelta=input();
    a= int(input("Indica il primo numero: "))
    b= int(input("Indica il secondo numero: ")) 
    if (scelta=='a'):
        print("La somma di a + b = ",a+b) 
    elif (scelta=='b'):
        print("La sottrazione di a - b = ",a-b) 
    elif (scelta=='c'):
        print("La moltiplicazine di a * b = ",a*b) 
    elif (scelta=='d'):
        print("La divisione di a / b = ",a/b) 
    else:
        print("Hai digitato una scelta sbagliata")
    continuare = input("Se vuoi continuare digita 1, altrimenti qualunque altro tasto")