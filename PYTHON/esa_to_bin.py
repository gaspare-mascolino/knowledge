# Dato un numero in notazione esadecimale da parte dell’utente eseguire e mostrare la conversione in binario
numero=input("Inserisci un numero esadecimale da convertire in binario: ") 
numero = numero.upper()
lung = len(numero)
conv = ""
i=0
for k in range(lung):
    c=numero[-k-1] 
    if ( c == '0'):
        conv = "0000"+conv 
    elif (c == '1'):
        conv = "0001"+conv 
    elif (c == '2'):
        conv = "0010"+conv 
    elif (c == '3'):
        conv = "0011"+conv 
    elif (c == '4'):
        conv = "0100"+conv 
    elif (c == '5'):
        conv = "0101"+conv 
    elif (c == '6'):
        conv = "0110"+conv 
    elif (c == '7'):
        conv = "0111"+conv 
    elif (c == '8'):
        conv = "1000"+conv 
    elif (c == '9'):
        conv = "1001"+conv 
    elif (c == 'A'):
        conv = "1010"+conv 
    elif (c == 'B'):
        conv = "1011"+conv 
    elif (c == 'C'):
        conv = "1100"+conv 
    elif (c == 'D'):
        conv = "1101"+conv 
    elif (c == 'E'):
        conv = "1110"+conv 
    elif (c == 'F'):
        conv = "1111"+conv 
    i += 1
print("risultato:", conv)