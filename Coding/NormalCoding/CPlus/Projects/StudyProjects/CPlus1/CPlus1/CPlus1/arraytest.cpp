#include <iostream>
#include <array>

using namespace std;

/**
 * ²âÊÔarrayµÄ³õÊ¼»¯
 */
void test_array_initial()
{
	array<int, 10> a1;
	array<int, 10>::size_type i = 10;

	cout << i << endl;
}

int main()
{
	test_array_initial(); // 
	return 0;
}