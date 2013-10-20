#include <iostream>
#include <math.h>

using namespace std;

void main()
{
	int y,m, num;
	int n[12]={31,28,31,30,31,30,31,31,30,31,30,31};
	cout<<"Input year month > ";
	cin>>y>>m;
	
	if(m==2)
	{
		if(y%100!=0 && y%4==0)
		{
			num=29;
		}
		else if(y%400==0)
		{
			num=29;
		}
		else num=28;
	}

	cout<<"num of days = "<<num<<endl;
}