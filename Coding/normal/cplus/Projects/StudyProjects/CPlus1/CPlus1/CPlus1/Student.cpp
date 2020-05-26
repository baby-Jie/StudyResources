#include "Student.h"


//ostream& Student::operator<<(ostream& out)
//{
//	return out << this->name << std::endl;
//}

string Student::to_string()
{
	return "name:" + this->name;
}