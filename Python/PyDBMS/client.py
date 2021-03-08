import socket
import ast


query = input(
    "What is the query you would like to execute ?\n Examples: select('classroom','*')\nInput: ")
nextQuery = None  # At first it will be empty to trigger the question on the client if he wishes to execute more than one query but if it sets a value it won't be asked again

HOST = '127.0.0.1'  # The server's hostname or IP address
PORT = 65432        # The port used by the server

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    while True:
        if nextQuery is None: # For first run 
            s.connect((HOST, PORT))
            s.sendall(query.encode())
            data = s.recv(1024)
            print('Received response from server\n', data.decode('utf8', 'strict'))
            nextQuery = input("Enter your query\n")
            query = nextQuery
        else:
            pass
        if query != "":
            s.sendall(query.encode())
            data = s.recv(1024)
            print('Received response from server\n', data.decode('utf8', 'strict'))
            query = input("Enter your query\n")
            continue
        else:
            print(
                "Something2 wrong with your input!\n Please check the provided examples and try again :)")
            s.close()
            exit()
        