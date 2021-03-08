while True:
    try:
        name = input("Insert file name:\n")
        temp =open(name+".txt","r")
        temp.close()
        break
    except:
        print("There is no such file in the current directory.")
        continue
        
#create a dict - keys:letters values:number of encounters
letters={}
alphabet="ABCDEFGHIJKLMNOPQRSTUVWXYZ"
for i in alphabet:
    letters[i]=0
#save all text characters and make them uppercase
chars=[]
with open(name+".txt","r") as text:
    for i in text.read():
        chars.append(i.upper())
#count each letter
for l in letters.keys():
    for i in chars:
        if l == i:
            letters[l]+=1
#find most and least common letters          
M = max(letters.values())
m = min(letters.values())
for j in letters.keys():
    if letters[j] == m :
        least = j
    if letters[j] == M:
        most = j
#print statistics
for i in alphabet:
    st = letters[i]*100/len(chars)
    print("{:}: {:.2f}%".format(i,st))
#replace least with most common letters and the opposite
for i in range(len(chars)):
    if chars[i] == least:
        chars[i]=most
    if chars[i] == most:
        chars[i]=least
#replace text in file with uppercase
with open(name+".txt","w") as text:
    for i in range(len(chars)):
        text.write(chars[i])
