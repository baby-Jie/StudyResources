#include <iostream>
using namespace std;

int N, M;
int d[101];
int flag[101];
int matrix[101][101];
int maxVal = 999;

void dijk()
{
	flag[1] = 1;
	V[1] = 0;
	int i, j, k, tempV;
	for (i = 2; i <= N; i++)
	{
		d[i] = matrix[1][i];
	}
	for (i = 2; i <= N; i++)
	{
		int temp = maxVal;
		
		for (j = 1; j <=N; j++)
		{
			if (flag[j] != 0 && d[j] < temp)
			{
				temp = d[j];
				tempV = j;
			}
		}
		flags[tempV] = 1;
		
		for (k = 1; k <= N; k++)
		{
			if (flags[k] == 0)
			{
				d[k] = min(d[k], temp + matrix[tempV][k]);
			}
		}
	}
}

int main()
{
	cin >> N >> M;
	
	for (int i = 0; i <= N; i++)
	{
		for (int j = 0; j <= N; j++)
		{
			matrix[i][j] = maxVal;
		}
		d[i] = maxVal;
	}
	
	for (int k = 0; k < N; k++)
	{
		int i, j, d;
		cin >> i >> j >> d;
		
		matrix[i][j] = d;
	}
	
	
	
	return 0;
}
