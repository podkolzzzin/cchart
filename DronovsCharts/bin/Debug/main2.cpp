#include <iostream>
#include <Windows.h>
#include <math.h>

using namespace std;

void main()
{
	SetConsoleOutputCP(1251);
	int b,c,a;
	cout<<"input b c >";
	cin>>b>>c;
	
	if(c>=3 && c<=15)
	{
		a=11;
		b-=16;
	}
	else 
	{
		a=b+c;
		}

	printf("a=%d\nb=%d\nc=%d\n",a,b,c);
}