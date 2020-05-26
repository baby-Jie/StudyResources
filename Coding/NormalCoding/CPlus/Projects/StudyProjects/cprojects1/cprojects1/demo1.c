#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main_demo1()
{
	int a, b, c;
	__asm
	{
		mov a, 3
		mov b, 4
		mov eax, a
		add eax, b
		mov c, eax
	}

	printf("a = %d\n", a);
	printf("b = %d\n", b);
	printf("c = %d\n", c);
	int d = c + a;

	FILE* fp = NULL;
	fp = fopen("1.txt", "r");

	if (fp)
	{
		char buffer[2048];
		fgets(buffer, 2047, fp);
		printf("buffer:%s\n", buffer);
		fclose(fp);
	}
	else
	{
		printf("Hello");
	}

	

	printf("hello\n");
	printf("\n");
	system("pause");
	return 0;
}
