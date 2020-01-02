"""
进程池

"""

from multiprocessing import Pool
import os, time, random


def worker(msg):
    start_time = time.time()

    print("%s开始执行,进程号为%d" % (msg, os.getpid()))

    # random.random()随机生成0~1之间的浮点数
    time.sleep(random.random() * 2)

    end_time = time.time()

    print(msg,"执行完毕，耗时%0.2f" % (start_time-end_time))


po = Pool(3)

for i in range(10):

    # Pool().apply_async(要调用的目标,(传递给目标的参数元祖,))
    # 每次循环将会用空闲出来的子进程去调用目标
    po.apply_async(worker, (i,))

print("----start----")
po.close()  # 关闭进程池，关闭后po不再接收新的请求
po.join()  # 等待po中所有子进程执行完成，必须放在close语句之后
print("-----end-----")

"""
----start----
0开始执行,进程号为18905
1开始执行,进程号为18906
2开始执行,进程号为18907
1 执行完毕，耗时-0.25
3开始执行,进程号为18906
2 执行完毕，耗时-0.57
4开始执行,进程号为18907
0 执行完毕，耗时-1.44
5开始执行,进程号为18905
4 执行完毕，耗时-1.49
6开始执行,进程号为18907
3 执行完毕，耗时-1.89
7开始执行,进程号为18906
6 执行完毕，耗时-0.35
8开始执行,进程号为18907
7 执行完毕，耗时-0.43
9开始执行,进程号为18906
5 执行完毕，耗时-1.34
8 执行完毕，耗时-0.61
9 执行完毕，耗时-1.17
-----end-----
"""

