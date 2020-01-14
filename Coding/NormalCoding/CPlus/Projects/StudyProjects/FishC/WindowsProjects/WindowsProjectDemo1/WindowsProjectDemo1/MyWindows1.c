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
		return 0;
	}

	hwnd = CreateWindow(szAppName, L"���ǹ�����", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInstance, NULL);

}

 