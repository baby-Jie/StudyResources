"""
用来接受静态页面的请求 并返回 hello world字符串
运行之后使用浏览器  输入网址： localhost:8080
"""

import socket 

class StaticWebServer(object):
    def __init__(self, bind_addr:tuple):
        self.addr = bind_addr
        pass

    def run(self):
        server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        server_socket.bind(self.addr)

        server_socket.listen(128)

        while True:

            client_socket, client_addr = server_socket.accept()
            self.handle_client(client_socket)


    def handle_client(self, client_socket:socket.socket):

        recv_data = client_socket.recv(1024).decode("utf-8")
        request_header_lines = recv_data.splitlines()

        for line in request_header_lines:
            print(line)

        response_headers = "HTTP/1.1 200 OK\r\n"  # 200表示找到这个资源
        response_headers += "\r\n" # 用一个空的行与body进行隔开
        
        # 组织 内容主体

        response_body = "hello world"

        response = response_headers + response_body

        client_socket.send(response.encode("utf-8"))
        client_socket.close()

def main():

    web_server = StaticWebServer(("", 8080))
    web_server.run()



if __name__ == "__main__":
    main()