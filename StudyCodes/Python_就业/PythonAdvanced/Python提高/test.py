class Bass(object):
    def __init__(self, name):
        print("bass init")
        self.name = name


class Son1(Bass):
    def __init__(self, name, age):
        super().__init__( name)
        self.age = age

son = Son1("smx", 18)

print("son name:", son.name)
print("son name:", son.age)