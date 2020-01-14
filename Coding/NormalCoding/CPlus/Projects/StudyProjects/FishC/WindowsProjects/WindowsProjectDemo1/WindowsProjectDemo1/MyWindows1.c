#include <windows.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPWSTR    lpCmdLine,
	_In_ int       nCmdShow)
{
	static TCHAR szAppName[] = L"MyWindows";
	HWND hwnd;
	MSG msg;
	WNDCLASS wndclass;

	wndclass.style = CS_HREDRAW | CS_VREDRAW; // CS_HREDRAW 当调整宽度的时候重绘窗口 CS_VREDRAW 当调整高度色时候重绘窗口
	wndclass.lpfnWndProc = WndProc; // 指定窗口过程(必须是回调函数)
	wndclass.cbClsExtra = 0; // 预留的额外空间，一般为0
	wndclass.cbWndExtra = 0; // 预留的额外空间，一般为0
	wndclass.hInstance = hInstance; // 应用程序的实例句柄
	wndclass.hIcon = LoadIcon(NULL, IDI_APPLICATION); // 为所有基于该窗口类的窗口设定一个图标
	wndclass.hCursor = LoadCursor(NULL, IDC_ARROW); // 为所有基于该窗口类的窗口设定一个鼠标指针
	wndclass.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); // 指定窗口背景色
	wndclass.lpszMenuName = NULL; // 指定窗口菜单
	wndclass.lpszClassName = szAppName; // 指定窗口类名

	if (!RegisterClass(&wndclass))
	{
		MessageBox(NULL, L"这个程序需要在Windows NT 下才能执行", szAppName, MB_ICONERROR);
		return 0;
	}

	hwnd = CreateWindow(szAppName, L"明星工作室", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInstance, NULL);

}

 