class Student(object):
    def __init__(self, name, age, score):
        self.name = name
        self.__age = age
        self.__score = score
        pass

    @property
    def age(self):
        return self.__age

    @property
    def score(self):
        return self.__score

    @score.setter
    def score(self, value):
        self.__score = value

    @score.deleter
    def score(self):
        print("delete sore")

    
stu = Student('smx', 18, 99)
print(stu.score)
stu.score = 100
print(stu.score)
del stu.score
# print(stu._Student__age)
