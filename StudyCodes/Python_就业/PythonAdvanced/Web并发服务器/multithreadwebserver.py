import threading
import os
import socket
import re

class ThreadWSGIServer(object):
    def __init__(self, server_address:tuple):
        self.server_address = server_address
        self.listen_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.listen_socket.getsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

        self.listen_socket.bind(server_address)
        self.listen_socket.listen(128)

        pass

    def run(self):
        while True:

            client_socket, client_addr = self.listen_socket.accept()
            th = threading.Thread(target=self.client_handler, args=(client_socket,))
            th.start()

    def client_handler(self, client_socket:socket.socket):

        recv_data = client_socket.recv(1024)

        recv_data_str = recv_data.decode("utf-8")

        recv_lines = recv_data_str.splitlines()

        for line in recv_lines:
            print(line)

        request_header = recv_lines[0]

        file_name = re.match("[^/]*(/[^ ]*)", request_header).group(1)

        if file_name == "/":
            file_name = "index.html"
        else:
            if file_name.startswith("/"):
                file_name = file_name[1:]

        dirPath = os.path.dirname(__file__)

        file_name = os.path.join(dirPath, file_name)
        print("file_name is:", file_name)

        file_context  = self.readFile(file_name)

        response = None

        if file_context == None:
            response_header = "http/1.1 404 not found\r\n\r\n"
            response_body = ""

        else:
            response_header = "http/1.1 200 ok\r\n\r\n"
            response_body = file_context

        response = response_header + response_body

        client_socket.send(response.encode("utf-8"))

        client_socket.close()

    def readFile(self, fileName):

        if os.path.exists(fileName) and os.path.isfile(fileName):

            with open(fileName, "r+") as f:
                content = f.read(1024)
            return content
        else:
            return None


def main():

    server = ThreadWSGIServer(("", 8081))

    server.run()

if __name__ == "__main__":

    main()
