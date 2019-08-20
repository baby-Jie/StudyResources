#include<iostream>
#include <cstring> 
#include <vector>
using namespace std;

string originStr;
vector<string> g_v;

void test(int*p, int n, string str)
{
	if (str.length() == originStr.length())
	{
		g_v.push_back(str);
		return;
	}
	
	for (int i = 0; i < n; i++)
	{
		if (p[i] == 0)
		{
			p[i] = 1;
			string temp_str = str;
			temp_str += originStr[i];
			test(p, n, temp_str);
			p[i] = 0;
		}
	}
}

int main()
{
	originStr = "sdfgh";
	int len  = originStr.length();
	int p[len];
	for (int i = 0; i < len; i++)
	{
		p[i] = 0;
	}
	test(p, len, "");
	
	for (vector<string>::iterator it = g_v.begin(); it != g_v.end(); it++)
	{
		cout << *it << endl;
	}
	
	
	return 0; 
} 