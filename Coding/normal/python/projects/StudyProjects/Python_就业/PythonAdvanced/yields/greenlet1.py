"""为了更好使用协程来完成多任务，python中的greenlet模块对其封装，从而使得切换任务变的更加简单"""

from  greenlet import greenlet
import time

def work1():
    while True:
        print("work1")
        # yield 
        gr2.switch()
        time.sleep(0.5)

def work2():
    while True:
        print("work2")
        # yield 
        gr1.switch()
        time.sleep(0.5)

gr1 = greenlet(work1)

gr2 = greenlet(work2)

#切换到gr1中运行
gr1.switch()