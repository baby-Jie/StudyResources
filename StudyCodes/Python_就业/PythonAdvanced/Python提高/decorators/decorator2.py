
def makeBold(fn):
    def wrapped():
        return "<b>" + fn() + "</b>"
    return wrapped

def makeItalic(fn):
    def wrapped():
        return "<i>" + fn() + "</i>"
    return wrapped


@makeBold
def test1():
    return "hello world-1"

@makeItalic
def test2():
    return "hello world-2"

@makeItalic
@makeBold
def test3():
    return "hello world-3"

@makeBold
@makeItalic
def test4():
    return "hello world-4"

print(test1())  # <b>hello world-1</b>
print(test2())  # <i>hello world-2</i>
print(test3())  # <i><b>hello world-3</b></i>
print(test4())  # <b><i>hello world-4</i></b>