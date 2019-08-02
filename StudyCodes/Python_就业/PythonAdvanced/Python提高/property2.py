class Student(object):
    def __init__(self,name):
        self.__name = name
        pass

    def get_name(self):
        return self.__name

    def set_name(self, value):
        self.__name = value

    def delete_name(self):
        print("delete name")


    name = property(get_name, set_name, delete_name, "name_doc")

stu = Student("smx")
stu.name = "hello"
print(stu.name.__doc__) # 没有打印

print(stu.name)

del stu.name