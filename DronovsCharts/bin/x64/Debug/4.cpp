#include <iostream>
#include <Windows.h>

using namespace std;
int i;
long double eps, cEps; // eps - погрешнсть, cEps - текущая погрешность, i - счетчик повторений
long double sum, element, x;//sum - накопленная сумму, element - последний вычисленный элемент, x - аргумент функции
//j - счетчик цикла при подсчете факториала
void main()
{
	SetConsoleOutputCP(1251);
	cout<<"Введите необходимую точность> ";
	cin>>eps;
	cout<<"Введите х > ";
	cin>>x;
	i=0;
	cEps = eps+1;
	sum = 0;

	while(cEps>eps)
	{
		element = pow(-1, i) * pow(x, i+1);
		for(int j=1;j<i+1;j++)
		{
			element /= j;
		}
		i++;

		sum+=element;
		cEps = abs(element / sum);
	}

	cout<<"Накопленная сумма = "<<sum;

}