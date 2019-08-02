#include <iostream>

using namespace std;

void tranverseArray1(int a[], int len)
{
	for (int i = 0; i < len; i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;
}

void mergeSort(int a[], int len)
{
	if (len <= 1)
	{
		return;
	}

	if (len == 2)
	{
		if (a[0] > a[1])
		{
			a[0] = a[0] + a[1];
			a[1] = a[0] - a[1];
			a[0] = a[0] - a[1];
		}

		return;
	}

	int leftLen = len / 2;

	int rightLen = len - leftLen;

	int* aRight = a + leftLen;

	int* temp = new int[len];

	int leftIndex = 0;
	int rightIndex = 0;

	mergeSort(a, leftLen);

	mergeSort(aRight, rightLen);

	int tempIndex = 0;

	while (leftIndex < leftLen && rightIndex < rightLen)
	{
		if (a[leftIndex] <= aRight[rightIndex])
		{
			temp[tempIndex++] = a[leftIndex++];
		}
		else
		{
			temp[tempIndex++] = aRight[rightIndex++];
		}
	}

	while (leftIndex < leftLen)
	{
		temp[tempIndex++] = a[leftIndex++];
	}

	while (rightIndex < rightLen)
	{
		temp[tempIndex++] = aRight[rightIndex++];
	}

	for (int i = 0; i < len; i++)
	{
		a[i] = temp[i];
	}
}

int main()
{
	int array[] = { 4, 2, 3, 5, 1, 7, 9, 0, 6, 18 };
	mergeSort(array, 10);

	tranverseArray1(array, 10);
	return 0;
}