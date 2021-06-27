class Person(object):
    def __init__(self, name):
        self.__name = name

    def set_name(self, val):
        self.__name = val

    def get_name(self):
        return self.__name

    def delete_name(self):
        print("delete name")
        del self.__name

    def __call__(self, *args, **kwargs):
        print("call function")
        pass

    name = property(get_name, set_name, delete_name, "name_doc")


p = Person("smx")
p()