# Dato un numero in notazione decimale da parte dell’utente eseguire e mostrare la conversione in binario

numero=int(input("Inserisci un numero decimale da convertire in binario: ")) 
conv = ""
while (numero>0):
    conv = str(numero%2) + conv
    numero //= 2 
print("risultato:", conv)