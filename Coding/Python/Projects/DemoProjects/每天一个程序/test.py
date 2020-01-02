import multiprocessing 
import time

def sing():
    for i in range(3):
        print("i am sing")
        time.sleep(1)

pro1 = multiprocessing.Process(target = sing)
pro1.start()


print("hello python")