#include <iostream>
#include <math.h>
#include <Windows.h>

using namespace std;

void main()
{
	SetConsoleOutputCP(1251);
	int A[10][8] = {};

	int xs,ys;
	cout<<"Введите количество строк матрицы >";
	cin>>xs;
	if(xs>10)
	{
		cout<<"Ошибка: Количество строк не может быть больше 10"<<endl;
	}
	else
	{
		int sum, int nm;
		cout<<"Введите количество столбцов матрицы >";
		cin>>ys;
		if(ys>8)
		{
			cout<<"Ошибка: Количество строк не может быть больше 8"<<endl;
		}
		else
		{
			for(int i=0;i<xs;i++)
			{
				cout<<"Введите строку "<<i<<" >";
				for(int j=0;j<ys;j++)
				{
					cin>>A[i][j];
					if(A[i][j]>=0)
					{
						sum+=A[i][j];
					}
					else
					{
						nm++;
					}
				}

				
			}
		}

		cout<<"Введенная матрица: "<<endl;
		for(int i=0;i<xs;i++)
		{
			for(int j=0;j<ys;j++)
			{
				cout<<A[i][j]<<" ";	
			}
			cout<<endl;
		}

		cout<<"Матрица результат: ";
		for(int 

	}
}