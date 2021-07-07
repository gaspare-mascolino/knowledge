# Dato un numero in notazione decimale da parte dell’utente eseguire e mostrare la conversione in esadecimale
numero=int(input("Inserisci un numero decimale da convertire in binario: ")) 
conv = ""
c="";
while (numero>0):
    ris = numero%16
    if (0 <= ris) and (ris <= 9):
        c = chr(ris + 48)
    elif (10 <= ris) and (ris <= 15):
        c = chr(ris + 55) 
    conv = str(c) + conv; 
    c = ""
    numero //= 16
print("risultato:", conv)