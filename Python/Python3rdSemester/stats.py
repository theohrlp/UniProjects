while True:     #check if files exists
    try:
        name = input("Insert the name of the file(including the extention): \n")
        temp = open(name,"r")
        temp.close()
        break
    except:
        print("There is no such file in the current directory.")
        continue

while True:
    userInp = input("GIve me the two ASCII characters: ")  #validate user input
    chars = list(userInp)
    temp = 2
    if int(len(chars)) != 2:
        print("I need exactrly 2 ASCII characters. \n")
        continue
    else:
        break

inverted = userInp[::-1]

sum1 = 0

sum2 = 0

allChars = []

with open(name) as f:
    content = f.readlines()

content = [x.replace("\n", "") for x in content]  # sanitize text

str1 = ''.join(content)

allChars = list(str1)

file = open(name, mode="r")

for line in file:
    if userInp in line:
        sum1 += 1
    if inverted in line:
        sum2 += 1
total = sum1 + sum2

stats = total*100/len(allChars)

print(str(stats) + "%" )



