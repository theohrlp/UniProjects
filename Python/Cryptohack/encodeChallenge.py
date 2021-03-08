from pwn import * # pip install pwntools
import json
from Crypto.Util.number import bytes_to_long, long_to_bytes
import base64
import codecs
import random
from binascii import unhexlify

r = remote('socket.cryptohack.org', 13377, level = 'debug')

def json_recv():
    line = r.recvline()
    return json.loads(line.decode())

def json_send(hsh):
    request = json.dumps(hsh).encode()
    r.sendline(request)

def toStr(s):
    output = ""
    return(output.join(s))

while 1==1:
    received = json_recv()
    if "flag" in received: # If what we receive contains flag it means we got the flag
        print("\n[*] FLAG: {}".format(received["flag"]))
        break #If this if is true break the for loop
    word = received["encoded"]
    enc = received["type"]
    # Check all the available encodings
    if enc == "base64":
        decoded = base64.b64decode(word).decode('utf8').replace("'", '"')
    elif enc == "hex":
        decoded = (unhexlify(word)).decode('utf8').replace("'", '"')
    elif enc == "rot13":
        decoded = codecs.decode(word, 'rot_13')
    elif enc == "bigint":
        decoded = unhexlify(word.replace("0x", "")).decode('utf8').replace("'", '"')
    elif enc == "utf-8":
        decoded = toStr([chr(b) for b in word])
    toSend = {"decoded": decoded}
    json_send(toSend)

