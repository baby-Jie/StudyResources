import socket

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

bind_address = ("127.0.0.1", 8080)
sock.bind(bind_address)

print("aleady to receive data")

recv_data = sock.recvfrom(1024)

print(recv_data[0].decode('gbk'))
print(recv_data[1])

sock.close()