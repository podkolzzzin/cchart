#include <Windows.h>
#include <iostream>
#include <math.h>

using namespace std;

void main()
{
	SetConsoleOutputCP(1251);
	int a=0;
	cout<<"Введите a> ";
	cin>>a;

	switch (a)
	{
	case 1:
		cout<<"один";
		break;
	case 2:
		cout<<"два";
		break;
	case 3:
		cout<<"три";
		break;
	case 4:
		cout<<"четыре";
		break;
	case 5:
		cout<<"пять";
		break;
	default:
		cout<<"Неизвестное значение";
		break;
	}

	cout<<endl;
}