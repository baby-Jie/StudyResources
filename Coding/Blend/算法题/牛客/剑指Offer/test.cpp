#include <iostream>
#include <stdlib.h>
#include <cmath>
using namespace std;

int compare(const void *pa, const void *pb)
{
    int a = *((int *)pa);
    int b = *((int *)pb);
    return a - b;
}

int testFun(int *a, int N, int middleIndex)
{

    int startIndex = 0;
    if (N % 2 == 0)
    {
        startIndex = middleIndex - N / 2 + 1;
    }
    else
    {
        startIndex = middleIndex - N / 2;
    }

    int sum = 0;
    for (int i = 0; i < N; i++)
    {
        sum += abs(a[i] - startIndex);
        startIndex++;
    }
    return sum;
}

int main()
{
    int L, N;

    cin >> L;
    cin >> N;

    int a[N];
    int b[N];
    int c[N];
    for (int i = 0; i < N; i++)
    {
        cin >> a[i];
        if (a[i] > L / 2)
        {
            b[i] = a[i] - L;
        }
        else
        {
            b[i] = a[i];
        }
    }
    qsort(a, N, sizeof(int), compare);
    qsort(b, N, sizeof(int), compare);

    int maxDiff1 = a[N - 1] - a[0];
    int maxDiff2 = b[N - 1] - b[0];

    //  cout << maxDiff1 << endl;
    //   cout << maxDiff2 << endl;

    int maxDiff = 0;

    if (maxDiff1 > maxDiff2)
    {
        maxDiff = maxDiff2;
        for (int i = 0; i < N; i++)
        {
            c[i] = b[i];
        }
    }
    else
    {
        maxDiff = maxDiff1;
        for (int i = 0; i < N; i++)
        {
            c[i] = a[i];
        }
    }

    int middleIndex = maxDiff / 2 + c[0];

    int sum1= testFun(c, N, middleIndex);
    int sum2= testFun(c, N, middleIndex+ 1);

    int sum = min(sum1, sum2);
    cout << sum;
    return 0;
}
