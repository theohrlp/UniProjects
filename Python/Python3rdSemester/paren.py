while True:     #validate that the user enters something
    UserInp = input("Enter your line of code: \n")
    tmp = list(UserInp)
    if len(tmp) == 0:
        print("Please enter a line of code: \n")
        continue
    else:
        break
s = []
flag1 = True
flag2 = True
counter1 = 0
counter2 = 0
for i in tmp: 
    if i == '(':
        s.append(i)
        counter1 += 1
    if i == ')':
        try:
            x = s.pop()
            counter2 += 1
        except:
            flag2 = False
            break
if (len(s) == 0):
    flag1 = True

if flag1 and flag2 and counter1 == counter2:
    if counter1 == 0:
        print("You didnt insert any parentheses...")
    else:
        print("Valid.")
else:
    print("Not valid.")

