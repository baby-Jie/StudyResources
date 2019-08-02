#include <iostream>

using namespace std;

void tranverseArray(int a[], int len)
{
	for (int i = 0; i < len; i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;
}

void quickSort(int array[], int len)
{
	if (len <= 1)
	{
		return;
	}

	if (len == 2)
	{
		if (array[0] > array[1])
		{
			array[0] = array[0] + array[1];
			array[1] = array[0] - array[1];
			array[0] = array[0] - array[1];
		}

		return;
	}

	int key_val = array[0];

	int left = 0, right = len - 1;

	while (left < right)
	{
		while (left < right &&  array[right] > key_val)
		{
			right--;
		}

		array[left] = array[right];

		while (left < right && array[left] <= key_val)
		{
			left++;
		}

		array[right] = array[left];
	}

	array[left] = key_val;
	cout << "left is:" << left << " right is:" << right << endl;

	quickSort(array, left);
	quickSort(array + left + 1, len - left - 1);
}



int main()
{
	int array[] = { 4, 2, 3, 5, 1, 7, 9, 0, 6, 18 };
	quickSort(array, 10);
	cout << "quick sort" << endl;

	tranverseArray(array, 10);
	return 0;
}