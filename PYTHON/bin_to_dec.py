# Dato un numero in notazione binario da parte dell’utente eseguire e mostrare la conversione in decimale


numero=input("Inserisci un numero binario da convertire in decimale: ") 
numero = numero.upper()
lung = len(numero)
conv = 0
i=0
for k in range(lung):
    c=int(numero[-k-1]) 
    conv += (2**i)*c
    i += 1
print("risultato:", conv)