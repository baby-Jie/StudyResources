#include <windows.h>

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

void MyRegisterClass(HINSTANCE hInstance, TCHAR szAppName[]);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
	_In_opt_ HINSTANCE hPrevInstance,
	_In_ LPWSTR    lpCmdLine,
	_In_ int       nCmdShow)
{
	//MessageBox(NULL, L"message", L"caption", MB_OKCANCEL);
	static TCHAR szAppName[] = L"MyWindows";
	HWND hwnd;
	MSG msg;
    MyRegisterClass(hInstance, szAppName);

	hwnd = CreateWindow(szAppName, L"明星工作室", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInstance, NULL);

	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);

	// 主消息循环:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return 0;
}

//
//  函数: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  目标: 处理主窗口的消息。
//
//  WM_COMMAND  - 处理应用程序菜单
//  WM_PAINT    - 绘制主窗口
//  WM_DESTROY  - 发送退出消息并返回
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
    {
        //int wmId = LOWORD(wParam);
        //// 分析菜单选择:
        //switch (wmId)
        //{
        //case IDM_ABOUT:
        //    DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
        //    break;
        //case IDM_EXIT:
        //    DestroyWindow(hWnd);
        //    break;
        //default:
        //    return DefWindowProc(hWnd, message, wParam, lParam);
        //}
    }
    break;
    case WM_PAINT:
    {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);
        // TODO: 在此处添加使用 hdc 的任何绘图代码...
        EndPaint(hWnd, &ps);
    }
    break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

void MyRegisterClass(HINSTANCE hInstance, TCHAR szAppName[])
{
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
        exit(-1);
    }
}



 