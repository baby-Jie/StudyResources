#include <iostream>
#include <vector>
#include "Student.h"

using namespace  std;

/**
 * + vector的用法:
 *	0. 构造和初始化。
 *		+ 使用 C c2(c1) 构造函数 等价于 C c2 = c1; notes:容器类型必须一致。
 *		+ 使用 C c{a, b, c...} 初始化 等价于 C c = {a, b, c...};
 *		+ 使用迭代器范围初始化容器 C c1(begin, end); notes:容器类型可以不一致 元素类型也可以不一致，但前提是元素类型之间可以相互转换。
 *		+ 使用个数初始化 C c(5, 99); 使用5个99初始化容器内容。
 *	1. begin end rbegin rend cbegin cend crbegin crend
 *	2. push_back 在末尾增加
 *	3. erase clear
 *	4. 可以使用索引器 结合 size() 方法使用
 */ 


 /**
  * 测试构造和初始化
  */
void test_destructor_and_initial()
{
	// 使用 C c2(c1) 构造函数 等价于 C c2 = c1;
#pragma region 

	vector<int> v1; // 使用默认构造函数
	v1.push_back(1);
	v1.push_back(99);

	vector<int> v2(v1); // 是拷贝值 而不是引用。
	v2[1] = 100;
	//cout << v1[1] << endl; // 并不会改变初始的值 

	vector<Student> students1;
	Student stu1;
	stu1.name = "smx";
	stu1.age = 18;
	students1.push_back(stu1);

	//vector<Student> students2(students1); // 即使容器中使用的是对象，拷贝的也不是引用。
	vector<Student> students2 = students1; // 即使容器中使用的是对象，拷贝的也不是引用。
	students2[0].name = "xyj";
	//cout << students1[0].name << endl;
	          
#pragma endregion 

	// 使用 C c{a, b, c...} 初始化 等价于 C c = {a, b, c...};
#pragma region 
	Student stu2;
	stu2.name = "xyj";
	stu2.age = 25;
	//vector<Student> students3{ stu1, stu2};
	vector<Student> students3 = { stu1, stu2}; // 同上 使用多个元素初始化。

	for (int i = 0; i < students3.size(); i++)
	{
		//cout << students3[i].to_string() << endl;
	}

#pragma endregion

	// 使用迭代器范围初始化容器 C c1(begin, end);
#pragma region

	Student stu3;
	stu3.name = "xpp";
	stu3.age = 19;
	students3.push_back(stu3);
	auto start = students3.begin();
	++start;
	vector<Student> students4(start, students3.end());

	for (int i = 0; i < students4.size(); i++)
	{
		//cout << students4[i].to_string() << endl;
	}

#pragma endregion

	// 使用个数初始化 C c(5, 99); 使用5个99初始化容器内容。
#pragma region

	vector<int> v3(5, 10);
	for (int i = 0; i < v3.size(); i++)
	{
		cout << v3[i] << endl;
	}
#pragma endregion 
}

/**
 * 测试迭代器
 */
void test_iterator()
{
	vector<int> v1;
	v1.push_back(1);
	v1.push_back(2);
	v1.push_back(3);

	// 正向遍历
	//vector<int>::iterator i = v1.begin();
	auto iterator1 = v1.begin(); // 可以使用auto
	while (iterator1 != v1.end())
	{
		cout << *iterator1 << endl;
		++iterator1;
	}

	vector<int>::value_type t = 1; // value_type 就是 元素类型的别名。
	vector<int>::iterator it;

	// 反向遍历
	auto riterator = v1.rbegin();
	while (riterator != v1.rend())
	{
		cout << *riterator << endl;
		++riterator;
	}

	// 随机遍历

	int size = v1.size();
	for (int i = 0; i < size; i++)
	{
		cout << v1[i] << endl;
	}

	cout << "hello" << endl;
}

int main_vector()
{
	test_destructor_and_initial(); // 测试构造和初始化


	return 0;
}