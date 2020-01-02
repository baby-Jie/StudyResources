# 装饰器  其实装饰器 就是 ret = login_check(test)    ret()

def login_check(fun):

    def before_login():
        print('检查网络连接')
        fun()

    return before_login


@login_check  
def test():
    print("login")

test()