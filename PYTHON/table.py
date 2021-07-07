l = []
j=0
for i in range(11):
    l.append([])
    for k in range(8):
        j=j+1
        l[i].append(j)
for i in range(11):
    for k in range(8): 
        print(l[i][k], end="\t")
    print()

