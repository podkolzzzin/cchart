#include <iostream>
#include <math.h>
#include <Windows.h>

using namespace std;

void main()
{

	SetConsoleOutputCP(1251);

	int a,b,c,a1,b1,c1;
	cout<<"Введите a b c >";
	cin>>a>>b>>c;
	if(a+b > c && a+c>b && c+b>a)
	{
		cout<<"Треугольник существует"<<endl;
		c1 = max(max(a,b),c);
		if(c1==b)
		{
			a1=a;
			b1=c;
		}
		else if(c1==a)
		{
			a1=c;
			b1=b;
		}
		else
		{
			b1=c;
			a1=a;
		}

		cout<<"Треугольник ";

		if(a==b && b==c)
		{
			cout<<"равносторонний";
		}
		else if(a==b || b==c || a==c)
		{
			cout<<"равнобедренный";
		}
		else
		{
			cout<<"разносторонний";
		}

		cout<<" и ";
		if(c1*c1 == b1*b1 + a1*a1)
		{
			cout<<"прямоугольный"<<endl;
		}
		else if(c1*c1 > b1*b1 + a1*a1)
		{
			cout<<"тупоугольный"<<endl;
		}
		else 
		{
			cout<<"остроугольный"<<endl;
		}
	}
	else
		cout<<"Треугольник не существует"<<endl;
}