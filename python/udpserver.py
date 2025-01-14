from socket import *
from threading import *
import json

serverPort = 727
serverSocket = socket(AF_INET, SOCK_DGRAM) # UDP
serverSocket.bind(('localhost', serverPort))

class pair: 
    def __init__(self, name, url):
        self.name = name
        self.url = url
pair_list = list()


print("The UDP server is ready to receive")

def DoOneClient(socket_data, clientAddress): #handle one client on a separate thread
    json_dict = json.loads(socket_data.decode(encoding="utf-8"))
    new_pair = pair(json_dict["name"], json_dict["url"]) # instantiate new pair from json_dict
    pair_list.append(new_pair) # append to pair_list
    print(socket_data.decode(encoding="utf-8"))
    serverSocket.sendto(json.dumps(pair_list), clientAddress) # Husk addressen for modtageren

while True:
    bytes, clientAddress = serverSocket.recvfrom(512)
    Thread(target=DoOneClient(socket_data=bytes, clientAddress = clientAddress))
    
