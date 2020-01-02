/*
输入一个整数数组，实现一个函数来调整该数组中数字的顺序，使得所有的奇数位于数组的前半部分，所有的偶数位于数组的后半部分，并保证奇数和奇数，偶数和偶数之间的相对位置不变。
*/

#include<iostream>
#include<vector>

using namespace std;


void reOrderArray(vector<int> &array) 
{
    vector<int>::iterator it;
    vector<int>::iterator it2;
    vector<int> v1;
    vector<int> v2;
    for (it = array.begin(); it != array.end(); it++)
    {
        if (*it % 2 == 1)
        {
            v1.push_back(*it);
        }
        else
        {
            v2.push_back(*it);
        }
    }

    it = array.begin();

    for (it2 = v1.begin(); it2 != v1.end(); it2++)
    {
        *it = *it2;
        it++;
    }

    for (it2 = v2.begin(); it2 != v2.end(); it2++)
    {
        *it = *it2;
        *it++;
    }
}

int main()
{
    vector<int> v1;
    v1.push_back(1);
    v1.push_back(2);
    v1.push_back(3);
    v1.push_back(4);
    reOrderArray(v1);
    cout << "hello" << endl;
    vector<int>::iterator it;
    for (it = v1.begin(); it != v1.end(); it++)
    {
        cout << *it << " ";
    }
    return 0;
}