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

	hwnd = CreateWindow(szAppName, L"���ǹ�����", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInstance, NULL);

	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);

	// ����Ϣѭ��:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return 0;
}

//
//  ����: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  Ŀ��: ���������ڵ���Ϣ��
//
//  WM_COMMAND  - ����Ӧ�ó���˵�
//  WM_PAINT    - ����������
//  WM_DESTROY  - �����˳���Ϣ������
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
    {
        //int wmId = LOWORD(wParam);
        //// �����˵�ѡ��:
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
        // TODO: �ڴ˴����ʹ�� hdc ���κλ�ͼ����...
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

    wndclass.style = CS_HREDRAW | CS_VREDRAW; // CS_HREDRAW ��������ȵ�ʱ���ػ洰�� CS_VREDRAW �������߶�ɫʱ���ػ洰��
    wndclass.lpfnWndProc = WndProc; // ָ�����ڹ���(�����ǻص�����)
    wndclass.cbClsExtra = 0; // Ԥ���Ķ���ռ䣬һ��Ϊ0
    wndclass.cbWndExtra = 0; // Ԥ���Ķ���ռ䣬һ��Ϊ0
    wndclass.hInstance = hInstance; // Ӧ�ó����ʵ�����
    wndclass.hIcon = LoadIcon(NULL, IDI_APPLICATION); // Ϊ���л��ڸô�����Ĵ����趨һ��ͼ��
    wndclass.hCursor = LoadCursor(NULL, IDC_ARROW); // Ϊ���л��ڸô�����Ĵ����趨һ�����ָ��
    wndclass.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); // ָ�����ڱ���ɫ
    wndclass.lpszMenuName = NULL; // ָ�����ڲ˵�
    wndclass.lpszClassName = szAppName; // ָ����������

    if (!RegisterClass(&wndclass))
    {
        MessageBox(NULL, L"���������Ҫ��Windows NT �²���ִ��", szAppName, MB_ICONERROR);
        exit(-1);
    }
}



 