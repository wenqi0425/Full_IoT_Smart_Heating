import socket
import allScript

UDP_IP = "0.0.0.0"
UDP_PORT = 5005
heatingLevel = 0

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.bind((UDP_IP, UDP_PORT))

while True:
        data, addr = sock.recvfrom(1024)
        data = data.decode("utf-8")
        data = data.split()
        command = int(data[0])
        heatingLevel = int(data[1])
        if command == 0:
                heatingLevel = 0
                allScript.function(heatingLevel)
        elif command == 1:
                allScript.function(heatingLevel)
        elif command == 2:
                allScript.function(-1)
        print("Received command: %s" % command)
        print("Received heating level: %s" % heatingLevel)