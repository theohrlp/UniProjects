import sys
import os
import io
from PIL import Image


# tempVar = open("flag_7ae18c704272532658c10b5faad06d74.png", 'rb')

# flagImg = tempVar.read()

# tempVar.close()

# flagImg = bytearray(flagImg)

# tempVar2 = open("lemur_ed66878c338e662d3473f0d98eedbd0d.png", 'rb')

# lemurImg = tempVar2.read()

# tempVar2.close()

# lemurImg = bytearray(lemurImg)

flagImg = bytearray(open("flag_7ae18c704272532658c10b5faad06d74.png", "rb").read())


lemurImg = bytearray(open("lemur_ed66878c338e662d3473f0d98eedbd0d.png", "rb").read())

size = len(flagImg)
# size = len(lemurImg) if len(lemurImg) < len(flagImg) else len(flagImg)

xord_byte_array = bytearray(size)

print(size)

for i in range(size):
	xord_byte_array[i] = lemurImg[i] ^ flagImg[i]


# byteObj = bytes(xord_byte_array)

# print(byteObj)

# temp = bytes(xord_byte_array)

stream = io.BytesIO(xord_byte_array)

print(stream)

image = Image.open(stream)

image.show()

# result = open("result.png", 'wb')

# result.write(xord_byte_array)

# result.close()

# open("hallo.png", 'wb').write(xord_byte_array)

