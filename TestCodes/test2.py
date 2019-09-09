class Stu:
    
    def __init__(self):
        self.__name = None

    @property
    def name(self):
        return self.__name

    @name.setter
    def name(self, val):
        self.__name = val

    @name.deleter
    def name(self):
        del self.__name
        print("delete name")


stu = Stu() 

stu.name = "smx"
print(stu.name)

del stu.name
print(stu.name)
stu.name = "123"

