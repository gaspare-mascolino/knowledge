# Dato un numero in notazione esadecimale da parte dell’utente eseguire e mostrare la conversione in decimale
numero=input("Inserisci un numero esadecimale da convertire in decimale: ") 
numero = numero.upper()
lung = len(numero)
conv = 0
i=0
for k in range(lung):
    c=numero[-k-1]
    dec = ord(c)
    if (65 <= dec <=70):
        conv += (16**i)*(dec-55) 
    elif (48 <= dec <= 57):
        conv += (16**i)*(dec-48) 
    i += 1
print("risultato:", conv)