#pragma once
#include <string>
#include <iostream>
#include "Student.h"
using namespace std;

class Student
{
public:
	int age;
	string name;
	//ostream& operator<<(ostream& out);
	string to_string();
};



