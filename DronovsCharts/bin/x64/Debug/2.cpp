#include <iostream>
#include <Windows.h>
#include <time.h>
#include  <math.h>

using namespace std;

void main()
{
	SetConsoleOutputCP(1251);

	char r;
	int A[10][8];
	int xs,ys;
	cout<<"Введите количество строк матрицы >";
	cin>>xs;
	if(xs>10)
	{
		cout<<"Ошибка: Количество строк не может быть больше 10"<<endl;
	}
	else
	{
		int sum =0, nm = 0;
		cout<<"Введите количество столбцов матрицы >";
		cin>>ys;
		if(ys>8)
		{
			cout<<"Ошибка: Количество строк не может быть больше 8"<<endl;
		}
		else
		{
			cout<<"Заполнить матрицу автоматически (y/n) >";
			cin>>r;

			if(r=='y' || r=='Y')
			{
				for(int i=0;i<xs;i++)
				{
					for(int j=0;j<ys;j++)
					{
						A[i][j]=rand()%10;
					}
				}
			}
			else
			{
				for(int i=0;i<xs;i++)
				{
					cout<<"Введите строку "<<i<<" >";
					for(int j=0;j<ys;j++)
					{
						cin>>A[i][j];
					}	
				}
			}

			cout<<"Введенная матрица: "<<endl;
				int minI,maxI,maxJ;
				minI=maxI=maxJ=0;
				for(int i=0;i<xs;i++)
				{
					for(int j=0;j<ys;j++)
					{
						cout<<A[i][j]<<" ";	
						if(A[i][j]>A[maxI][maxJ])
						{
							maxI=i;
							maxJ=j;
						}
					}
					cout<<endl;
				}

				cout<<"Максимальный элемент массива: "<<A[maxI][maxJ]<<" строка="<<maxI+1<<" столбец = "<<maxJ+1<<endl;

				for(int j=0;j<ys;j++)
				{
					for(int i=0;i<xs;i++)
					{
						if(A[i][j]<A[minI][j])
							minI = i;
					}
					cout<<"Минимальный элемент столбца "<<j+1<<": "<<A[minI][j]<< " строка="<<minI+1<<endl;
					minI=0;
				}
		}
	}
}