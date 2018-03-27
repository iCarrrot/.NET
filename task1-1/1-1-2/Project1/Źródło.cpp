#include <windows.h>
#include <string.h>

/* Deklaracja wyprzedzaj¹ca: funkcja obs³ugi okna */
LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);
/* Nazwa klasy okna */
char szClassName[] = "z1.1.2";

int WINAPI WinMain(HINSTANCE hThisInstance, HINSTANCE hPrevInstance,
	LPSTR lpszArgument, int nFunsterStil)
{
	HWND hwnd;               /* Uchwyt okna */
	MSG messages;            /* Komunikaty okna */
	WNDCLASSEX wincl;        /* Struktura klasy okna */

							 /* Klasa okna */
	wincl.hInstance = hThisInstance;
	wincl.lpszClassName = szClassName;
	wincl.lpfnWndProc = WindowProcedure;    // wskaŸnik na funkcjê 
											// obs³ugi okna  
	wincl.style = CS_DBLCLKS;
	wincl.cbSize = sizeof(WNDCLASSEX);

	/* Domyœlna ikona i wskaŸnik myszy */
	wincl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wincl.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	wincl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wincl.lpszMenuName = NULL;
	wincl.cbClsExtra = 0;
	wincl.cbWndExtra = 0;
	/* Jasnoszare t³o */
	wincl.hbrBackground = (HBRUSH)GetStockObject(LTGRAY_BRUSH);

	/* Rejestruj klasê okna */
	if (!RegisterClassEx(&wincl)) return 0;

	/* Twórz okno */
	hwnd = CreateWindowEx(
		0,
		szClassName,
		"z1.1.2",
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
	/* Pêtla obs³ugi komunikatów */
	SetTimer(hwnd, 1, 25, NULL);
	while (GetMessage(&messages, NULL, 0, 0))
	{
		/* T³umacz kody rozszerzone */
		TranslateMessage(&messages);
		/* Obs³u¿ komunikat */
		DispatchMessage(&messages);
	}

	/* Zwróæ parametr podany w PostQuitMessage( ) */
	return messages.wParam;
}

int xSize, ySize, xPos=20, yPos=20, yDir=1, xDir=1, radius=10;
RECT r;

/* Tê funkcjê wo³a DispatchMessage( ) */
LRESULT CALLBACK WindowProcedure(HWND hwnd, UINT message,
	WPARAM wParam, LPARAM lParam)
{
	char sText[] = "Kó³ko";
	HDC         hdc; // kontekst urz¹dzenia
	int         i;
	PAINTSTRUCT ps;

	HPEN   hPen;
	HBRUSH hBrush;

	switch (message)
	{
	case WM_TIMER:///*
		if (xPos - radius <= 0) xDir = 1;
		if (xPos + radius >= xSize) xDir = -1;
		if (yPos - radius <= 0) yDir = 1;
		if (yPos + radius >= ySize) yDir = -1;
		xPos += xDir * 2;
		yPos += yDir * 2;
		hdc = GetDC(hwnd);
		FillRect(hdc, &r, (HBRUSH)GetStockObject(WHITE_BRUSH));

		hPen = CreatePen(PS_SOLID, 2, RGB(255, 0, 0));
		SelectObject(hdc, hPen);
		Ellipse(hdc, xPos - radius, yPos - radius, xPos + radius, yPos + radius);
		ReleaseDC(hwnd, hdc);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_SIZE:
		xSize = LOWORD(lParam);
		ySize = HIWORD(lParam);

		GetClientRect(hwnd, &r);
		InvalidateRect(hwnd, &r, 1);

		break;


	default:
		return DefWindowProc(hwnd, message, wParam, lParam);
	}
	return 0;
}
