#include <iostream>
#include <vector>
#include <iterator>
#include <iomanip>  //不要忘了头文件
using namespace std;

int main()
{
	cout<<setiosflags(ios::fixed)<<setprecision(2);
	double salaries[] = {9000, 9000, 7425, 7425, 7425, 7425, 7425, 7425, 12667.82, 11900, 12200, 10700, 10000, 10300};
 	double totalSalary = 0.0;
 	for (int i = 0; i < 14; i++)
 	{
 		totalSalary +=  salaries[i]; 
	}
	cout << "totalSalary:" <<  totalSalary << endl;  // 130317.82
	
	double taxes[] = {72.75, 72.75, 72.75, 72.75, 72.75, 72.75, 72.75, 72.75, 182.61, 154.50, 163.50, 118.50, 300, 106.50};
	
	double totalTax = 0.0;
	for (int i = 0; i < 14; i++)
	{
		totalTax += taxes[i];
	}
	cout << "totalTax:" << totalTax << endl; // 1607.61
	
	double test = 12667.82 + 7425;
	cout << test << endl;
	 
	return 0;
}

// 
