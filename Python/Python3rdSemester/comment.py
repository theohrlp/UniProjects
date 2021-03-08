while True:     #check if files exists
    try:
        name = input("Insert the name of the C++ file.(including the extention): \n")
        temp = open(name,"r")
        temp.close()
        break
    except:
        print("There is no such file in the current directory.")
        continue

file = open(name, mode="r")

flag = False

for line in file:
    if "//" in line:
        print(line)
    if "/*" in line or flag:
        print(line)
        flag = True
        if "*/" in line:
            flag = False
