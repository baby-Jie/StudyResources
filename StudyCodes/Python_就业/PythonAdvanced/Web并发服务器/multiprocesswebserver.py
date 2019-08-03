import socket
import re
import multiprocessing
import os


class WSGIServer(object):

    def __init__(self, server_address):
        """多进程web静态服务器类"""

        self.server_address = server_address
        self.listen_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

        # 允许立即使用上次绑定的port
        self.listen_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

        # 绑定address
        self.listen_socket.bind(self.server_address)

        self.listen_socket.listen(128)

    def run(self):

        while True:
            client_socket, client_address = self.listen_socket.accept()

            print("client address:", client_address)
            new_process = multiprocessing.Process(target=self.handle_client, args=(client_socket,))
            new_process.start()

            client_socket.close()  # why? if not call this, web client will wait 

        pass

    def handle_client(self, client_socket: socket.socket):

        recv_data = client_socket.recv(1024).decode("utf-8")
        request_header_lines = recv_data.splitlines()

        for line in request_header_lines:
            print(line)

        http_request_line = request_header_lines[0]

        get_file_name = re.match("[^/]+(/[^ ]*)", http_request_line).group(1)

        if get_file_name == '/':
            get_file_name = "index.html"

        if get_file_name.startswith('/'):
            get_file_name = get_file_name[1:]

        dir_path = os.path.dirname(__file__)

        get_file_name = os.path.join(dir_path, get_file_name)

        print("file_name is ", get_file_name)

        response = None

        if os.path.exists(get_file_name) and os.path.isfile(get_file_name):
            print("exists file")

            response_headers = "HTTP/1.1 200 OK\r\n"  # 200表示找到这个资源
            response_headers += "\r\n"  # 用一个空的行与body进行隔开

            # 组织 内容主体
            response_body = self.readFile(get_file_name)

            response = response_headers + response_body

        else:
            response_headers = "HTTP/1.1 404 Not Found\r\n"  # 404表示没有找到这个资源
            response_headers += "\r\n"  # 用一个空的行与body进行隔开

            # 组织 内容主体
            response_body = "not found"

            response = response_headers + response_body

        client_socket.send(response.encode("utf-8"))
        client_socket.close()

    def readFile(self, filename):
        ret = None

        if os.path.exists(filename) and os.path.isfile(filename):
            with open(filename, "r+") as f:
                ret = f.read(1024)

        return ret


def main():
    server = WSGIServer(("", 8080))
    server.run()
    pass


if __name__ == "__main__":
    main()


