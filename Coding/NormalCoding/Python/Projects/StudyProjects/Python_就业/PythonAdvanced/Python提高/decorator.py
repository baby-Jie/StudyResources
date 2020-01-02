def test(func):
    def test_inner():
        print("检查网络连接")
        print("检查与服务器是否连接正常")
        func()

    return test_inner

@test
def login():

    print("登录操作")

def main():
    login()

if __name__ == "__main__":
    main()
