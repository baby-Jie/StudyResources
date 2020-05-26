import socket

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

dst_address = ("127.0.0.1", 8080)

send_data = input("请输入要发送的数据：")

sock.sendto(send_data.encode("utf-8"), dst_address)

sock.close()