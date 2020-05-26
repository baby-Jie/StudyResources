#include <iostream>
#include <stdlib.h>
#include <vector>
#include <string>
#include <sys/types.h>
using namespace std;

class Student
{
public:
	int age;
	inline void testInline()
	{
		int a = 10;
		cout << a << endl;
	}

	void testFun()
	{
		int b = 11;
		cout << b << endl;
	}
};

int main_demo2()
{
	Student stu;
	stu.testInline();
	stu.testFun();
	system("pause");
	return 0;
}
