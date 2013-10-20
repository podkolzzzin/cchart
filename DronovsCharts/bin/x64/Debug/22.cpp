#include <iostream>
#include <Windows.h>

using namespace std;
/*
У. Умножение
Д. Деление
С. Сложение
В. Вычитание
З. Завершить программу.
*/

void main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	char c=0;
	while (c!='з')
	{
		system("cls");
		cout<<"У. Умножение\n";
		cout<<"Д. Деление\n";
		cout<<"С. Сложение\n";
		cout<<"В. Вычитание\n";
		cout<<"З. Завершить программу.\n";
		c = getchar();
		getchar();
		system("cls");
		c = (c=='У' || c=='E' || c=='e')?'у':c;
		c = (c=='Д' || c=='L' || c=='l')?'д':c;
		c = (c=='С' || c=='C' || c=='c')?'с':c;
		c = (c=='В' || c=='D' || c=='d')?'в':c;
		c = (c=='З' || c=='P' || c=='p')?'з':c;	
		switch (c)
		{
		case 'у':
			cout<<"У. Умножение\n";
			break;
		case 'д':
			cout<<"Д. Деление\n";
			break;
		case 'с':
			cout<<"С. Сложение\n";
			break;
		case 'в':
			cout<<"В. Вычитание\n";
			break;
		}
		if(c!='з') 
		{
			cout<<"Что бы вернутся в меню нажмите любую кнопку";
			c = getchar();
		}
	}
}