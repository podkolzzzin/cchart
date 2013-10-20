#include <iostream>
#include <math.h>

using namespace std;

void main()
{
	int a,b,c;
	cout<<"Input a b c > ";
	cin>>a>>b>>c;
	
	cout<<"max = "<<max(max(a,b),c)<<endl;
	cout<<"min = "<<min(min(a,b),c)<<endl;
}