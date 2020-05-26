"""
进程池中的Queue

"""

from multiprocessing import Pool, Manager, Queue
import os, time

def reader(q:Queue):
    print("reader启动(%s),父进程为(%s)" % (os.getpid(), os.getppid()))

    for i in range(q.qsize()):
        print("reader从Queue获取到消息：%s" % q.get(True))

def writer(q:Queue):
    print("writer启动(%s),父进程为(%s)" % (os.getpid(), os.getppid()))
    for i in "itcast":
        q.put(i)

def main():
    print("(%s) start" % os.getpid())

    q = Manager().Queue()

    po = Pool(3)

    po.apply_async(writer, (q,))

    time.sleep(1)

    po.apply_async(reader, (q,))

    po.close()
    po.join()
    print("(%s) End" % os.getpid())

if __name__ == "__main__":
    main()

"""
(20167) start
writer启动(20173),父进程为(20167)
reader启动(20174),父进程为(20167)
reader从Queue获取到消息：i
reader从Queue获取到消息：t
reader从Queue获取到消息：c
reader从Queue获取到消息：a
reader从Queue获取到消息：s
reader从Queue获取到消息：t
(20167) End
"""
