from sense_hat import SenseHat
import socket

def function(heatingLevel):

        sense = SenseHat()

        temp = sense.get_temperature()
        humid = sense.get_humidity()
        pres = sense.get_pressure()
        print(temp)
        print(humid)
        print(pres)

        msgFromClient = str(temp) + "," + str(humid) + "," + str(pres) + "," +  str(heatingLevel)
        bytesToSend = str.encode(msgFromClient)

        #Broadcast
        serverAddressPort = ("255.255.255.255", 65000)

        UDPClientSocket = socket.socket(family=socket.AF_INET, type=socket.SOCK_DGRAM)
        UDPClientSocket.setsockopt(socket.SOL_SOCKET, socket.SO_BROADCAST, 1)
        UDPClientSocket.sendto(bytesToSend, serverAddressPort)

        print("Data sent")