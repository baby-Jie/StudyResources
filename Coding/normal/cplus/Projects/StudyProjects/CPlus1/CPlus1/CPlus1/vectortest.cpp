#include <iostream>
#include <vector>
#include "Student.h"

using namespace  std;

/**
 * + vector���÷�:
 *	0. ����ͳ�ʼ����
 *		+ ʹ�� C c2(c1) ���캯�� �ȼ��� C c2 = c1; notes:�������ͱ���һ�¡�
 *		+ ʹ�� C c{a, b, c...} ��ʼ�� �ȼ��� C c = {a, b, c...};
 *		+ ʹ�õ�������Χ��ʼ������ C c1(begin, end); notes:�������Ϳ��Բ�һ�� Ԫ������Ҳ���Բ�һ�£���ǰ����Ԫ������֮������໥ת����
 *		+ ʹ�ø�����ʼ�� C c(5, 99); ʹ��5��99��ʼ���������ݡ�
 *	1. begin end rbegin rend cbegin cend crbegin crend
 *	2. push_back ��ĩβ����
 *	3. erase clear
 *	4. ����ʹ�������� ��� size() ����ʹ��
 */ 


 /**
  * ���Թ���ͳ�ʼ��
  */
void test_destructor_and_initial()
{
	// ʹ�� C c2(c1) ���캯�� �ȼ��� C c2 = c1;
#pragma region 

	vector<int> v1; // ʹ��Ĭ�Ϲ��캯��
	v1.push_back(1);
	v1.push_back(99);

	vector<int> v2(v1); // �ǿ���ֵ ���������á�
	v2[1] = 100;
	//cout << v1[1] << endl; // ������ı��ʼ��ֵ 

	vector<Student> students1;
	Student stu1;
	stu1.name = "smx";
	stu1.age = 18;
	students1.push_back(stu1);

	//vector<Student> students2(students1); // ��ʹ������ʹ�õ��Ƕ��󣬿�����Ҳ�������á�
	vector<Student> students2 = students1; // ��ʹ������ʹ�õ��Ƕ��󣬿�����Ҳ�������á�
	students2[0].name = "xyj";
	//cout << students1[0].name << endl;
	          
#pragma endregion 

	// ʹ�� C c{a, b, c...} ��ʼ�� �ȼ��� C c = {a, b, c...};
#pragma region 
	Student stu2;
	stu2.name = "xyj";
	stu2.age = 25;
	//vector<Student> students3{ stu1, stu2};
	vector<Student> students3 = { stu1, stu2}; // ͬ�� ʹ�ö��Ԫ�س�ʼ����

	for (int i = 0; i < students3.size(); i++)
	{
		//cout << students3[i].to_string() << endl;
	}

#pragma endregion

	// ʹ�õ�������Χ��ʼ������ C c1(begin, end);
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

	// ʹ�ø�����ʼ�� C c(5, 99); ʹ��5��99��ʼ���������ݡ�
#pragma region

	vector<int> v3(5, 10);
	for (int i = 0; i < v3.size(); i++)
	{
		cout << v3[i] << endl;
	}
#pragma endregion 
}

/**
 * ���Ե�����
 */
void test_iterator()
{
	vector<int> v1;
	v1.push_back(1);
	v1.push_back(2);
	v1.push_back(3);

	// �������
	//vector<int>::iterator i = v1.begin();
	auto iterator1 = v1.begin(); // ����ʹ��auto
	while (iterator1 != v1.end())
	{
		cout << *iterator1 << endl;
		++iterator1;
	}

	vector<int>::value_type t = 1; // value_type ���� Ԫ�����͵ı�����
	vector<int>::iterator it;

	// �������
	auto riterator = v1.rbegin();
	while (riterator != v1.rend())
	{
		cout << *riterator << endl;
		++riterator;
	}

	// �������

	int size = v1.size();
	for (int i = 0; i < size; i++)
	{
		cout << v1[i] << endl;
	}

	cout << "hello" << endl;
}

int main_vector()
{
	test_destructor_and_initial(); // ���Թ���ͳ�ʼ��


	return 0;
}