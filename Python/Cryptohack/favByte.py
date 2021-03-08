from pwn import *

givenHex = "73626960647f6b206821204f21254f7d694f7624662065622127234f726927756d"

key = bytes.fromhex(givenHex)

print(key)

def favByte(enc, k):
    output = b''
    for bit in enc:
        output += bytes([bit ^ k])
    try:
        return output.decode("UTF-8")
    except:
        return ""


flg={}

for i in range(256):
    flg[i]=(favByte(key,i))

flag=""

for char in flg.values():
    if "crypto" in char:
        flag+=char

print(flag)
