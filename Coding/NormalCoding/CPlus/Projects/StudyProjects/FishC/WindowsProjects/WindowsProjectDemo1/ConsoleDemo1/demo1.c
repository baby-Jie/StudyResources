#include <stdio.h>
#include <wchar.h>
#include <locale.h>

int main()
{
	wchar_t c[] = L"��";
	setlocale(LC_ALL, "chs");
	wprintf(c);
	return 0;
}