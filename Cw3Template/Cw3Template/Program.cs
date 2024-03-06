using Cw3Template;
using System;
using System.Runtime.InteropServices;
class Program
{
	static void Main(string[] args)
	{
		SquareMatrix<Complex<int>> square1 = new SquareMatrix<Complex<int>>(4);
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
				square1.matrixArray[i, j] = new Complex<int>(i, j);
		}
		square1.Multiply(new Complex<int>(1, 1));
		square1.WriteMyMatrix();
		SquareMatrix<int> square2 = new SquareMatrix<int>(3);
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
				square2.matrixArray[i, j] = i;
		}
		square2.Multiply(square2);
		square2.WriteMyMatrix();
	}
}