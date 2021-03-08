name = input("Insert the commented file name\n")

name2 = input("Insert a name for the new file\n")

file = open(name + ".txt" , mode="r")

newfile = open(name2+ ".txt", mode="w")

for line in file:
    if "#" not in line:
        newfile.write(line)
file.close()

newfile.close()

print("All done")
