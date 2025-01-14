from socket import * 
from threading import * 
import json

class data:
    def __init__(self, name, url):
        self.name = name
        self.url = url

PORT = 727

serverSocket = socket(AF_INET, SOCK_DGRAM) # UDP
serverSocket.bind(('localhost', PORT))

received_data = list()


print("socket is ready to receive some data!")

def DoOneClient(message, clientAddress):
    message = message.decode(encoding="utf-8")
    newData = json.loads(message)
    newObj = data(newData["Name"], newData["URL"])
    print(message)
    received_data.append(message)
    serverSocket.sendto(json.dumps(received_data).encode("utf-8"), clientAddress) # Husk addressen for modtageren

while True:
    message, clientAddress = serverSocket.recvfrom(2048)
    Thread(target=DoOneClient(message=message, clientAddress = clientAddress))
