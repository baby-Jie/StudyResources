def foo():
    print("hello i am foo")

def main():
    global foo
    foo()
    foo = lambda x: x + 1
    print(foo(1))

foo()
foo = lambda x: x + 1
print(foo(1))