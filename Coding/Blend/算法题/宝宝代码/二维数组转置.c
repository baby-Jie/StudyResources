/*
二维数组转置
*/
#include<stdio.h>

int main()
{

	int i,j,temp;
	int m[3][3];
	for (i=0;i<3;i++)
	{
		for(j=0;j<3;j++) 
		{
			scanf("%d",&m[i][j]);
			printf("%d ",m[i][j]);
		}
		printf("\n");
	}
	
	for (i=0;i<3;i++)
	{
		for(j=0;j<i+1;j++) 
		{
			temp=m[i][j];
			m[i][j]=m[j][i];
			m[j][i]=temp;
		}
		
	} 
	for (i=0;i<3;i++)
	{
		for(j=0;j<3;j++) 
		{
			printf("%d ",m[i][j]);
		}
		printf("\n");
	} 
	return 0;
}

