#include <iostream.h>
#include <math.h>


void main()
{
int A[100], kol, kol2=0, s=0, i,j=0;
while(j==0)
{
	cout<<"Vvedite kol. chisel ot 1 do 100\n" ;
	cin>>kol;
	if ((kol>=1)&&(kol<=100))
	{
		j=1;
	}
	else
	 cout<<"Oshubka\n";
	}
	for(i=0;i<kol;i++){
		cout<<"Vvedite "<<i+1<<" element \t";
		cin>>A[i];
		if (A[i]<0)
		{	
			kol2++; 	
			A[i]=0;
		}
		else
			 s=s+A[i];
	}
		cout<<" Otricatrl'nuh "<<kol2;
		cout<<"\n S-Polozhitel'nuh "<<s;
		for (i=0;i<kol;i++)
		{
			cout<<"\n"<<i+1<<" element raven= "<<A[i];
		}
}