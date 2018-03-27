#include <windows.h>
#include <string.h>

/* Deklaracja wyprzedzaj�ca: funkcja obs�ugi okna */
LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);
/* Nazwa klasy okna */
char szClassName[] = "z1-1-1";

int WINAPI WinMain(HINSTANCE hThisInstance, HINSTANCE hPrevInstance,
	LPSTR lpszArgument, int nFunsterStil)
{
	HWND hwnd;               /* Uchwyt okna */
	MSG messages;            /* Komunikaty okna */
	WNDCLASSEX wincl;        /* Struktura klasy okna */

							 /* Klasa okna */
	wincl.hInstance = hThisInstance;
	wincl.lpszClassName = szClassName;
	wincl.lpfnWndProc = WindowProcedure;    // wska�nik na funkcj� 
											// obs�ugi okna  
	wincl.style = CS_DBLCLKS;
	wincl.cbSize = sizeof(WNDCLASSEX);

	/* Domy�lna ikona i wska�nik myszy */
	wincl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wincl.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	wincl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wincl.lpszMenuName = NULL;
	wincl.cbClsExtra = 0;
	wincl.cbWndExtra = 0;
	/* Jasnoszare t�o */
	wincl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);

	/* Rejestruj klas� okna */
	if (!RegisterClassEx(&wincl)) return 0;

	/* Tw�rz okno */
	hwnd = CreateWindowEx(
		0,
		szClassName,
		"z1-1-1",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		512,
		512,
		HWND_DESKTOP,
		NULL,
		hThisInstance,
		NULL
	);

	ShowWindow(hwnd, nFunsterStil);
	/* P�tla obs�ugi komunikat�w */
	while (GetMessage(&messages, NULL, 0, 0))
	{
		/* T�umacz kody rozszerzone */
		TranslateMessage(&messages);
		/* Obs�u� komunikat */
		DispatchMessage(&messages);
	}

	/* Zwr�� parametr podany w PostQuitMessage( ) */
	return messages.wParam;
}

int xSize, ySize, x, y, a;
RECT r;
/* T� funkcj� wo�a DispatchMessage( ) */
LRESULT CALLBACK WindowProcedure(HWND hwnd, UINT message,
	WPARAM wParam, LPARAM lParam)
{
	char sText[] = "z1-1-1";
	HDC         hdc; // kontekst urz�dzenia
	int         i;
	PAINTSTRUCT ps;
	

	HPEN   hPen;
	HBRUSH hBrush;

	switch (message)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_SIZE:
		xSize = LOWORD(lParam);
		ySize = HIWORD(lParam);

		GetClientRect(hwnd, &r);
		InvalidateRect(hwnd, &r, 1);

		break;
	case WM_PAINT:
		hdc = BeginPaint(hwnd, &ps);

           
		hPen = CreatePen(PS_SOLID, 2, RGB(0, 0, 0));
		SelectObject(hdc, hPen);
		MoveToEx(hdc, xSize / 2, 0, NULL);
		LineTo(hdc, xSize / 2, ySize);
		MoveToEx(hdc, 0, ySize / 2, NULL);
		LineTo(hdc, xSize, ySize / 2);
		DeleteObject(hPen);

		hPen = CreatePen(PS_DASH, 1, RGB(0, 232, 0));
		SelectObject(hdc, hPen);
		MoveToEx(hdc, xSize / 2, ySize / 2, NULL);
		x = xSize / 2;
		y = ySize / 2;
		a = 0;
		if (ySize < xSize) {
			LineTo(hdc, xSize / 2 + ySize / 2, 0);
		}
		else {
			LineTo(hdc, xSize, ySize / 2 - xSize / 2);
		}
		MoveToEx(hdc, xSize / 2, ySize / 2, NULL);
		if (ySize < xSize) {
			LineTo(hdc, xSize / 2 - ySize / 2, 0);
		}
		else {
			LineTo(hdc, 0, ySize / 2 - xSize / 2);
		}

		DeleteObject(hPen);

		hPen = CreatePen(PS_DASHDOTDOT, 1, RGB(255, 232, 0));
		SelectObject(hdc, hPen);
		MoveToEx(hdc, xSize / 2, ySize / 2, NULL);
		x = xSize / 2;
		y = ySize / 2;
		a = 0;
		while (y < ySize) {
			y = ySize / 2 - a * a;
			x = a + xSize / 2;
			LineTo(hdc, x, y);
			a += 1;
		}
		MoveToEx(hdc, xSize / 2, ySize / 2, NULL);
		x = xSize / 2;
		y = ySize / 2;
		a = 0;
		while (y < ySize) {
			y = ySize / 2 - a * a;
			x = -a + xSize / 2;
			LineTo(hdc, x, y);
			a += 1;
		}
		DeleteObject(hPen);
		EndPaint(hwnd, &ps);
		break;

	default:
		return DefWindowProc(hwnd, message, wParam, lParam);
	}
	return 0;
}
