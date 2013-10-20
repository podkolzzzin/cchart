#include <iostream.h>
#include <math.h>
#include <conio.h>
void main()
{ 
	int a;
	cout<<"Введите число ->";
	cin>>a;
	switch (a)
	{
		case 1:cout<<"один";break;
		case 2:cout<<"два";break;
		case 3:cout<<"три";break;
		case 4:cout<<"четыре";break;
 		case 5:cout<<"пять";break;
  		default:
			cout<<"значение находитсЯ в неконтролируемом диапазоне";
	}
}