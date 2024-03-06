using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3Template
{
	class Matrix<T> where T : IComparable, IFormattable
	{
		public T[,] matrixArray;
		int row;
		int column;

		public Matrix(int _row, int _column)
		{
			row = _row;
			column = _column;
			matrixArray = new T[row, column];
		}

		public void Multiply(T value)
		{

			for (int i = 0; i < row; i++)
				for (int j = 0; j < column; j++)
					matrixArray[i, j] *= (dynamic)value;
		}

		public void Multiply(Matrix<T> otherMatrix)
		{
			if (this.column == otherMatrix.row)
			{
				Matrix<T> result = new Matrix<T>(this.row, otherMatrix.column);
				for (int k = 0; k < otherMatrix.column; k++)
				{
					for (int i = 0; i < this.row; i++)
					{
						for (int j = 0; j < this.column; j++)
						{
							dynamic val1 = this.matrixArray[i, j];
							dynamic val2 = otherMatrix.matrixArray[j, k];
							result.matrixArray[i, k] += val1 * val2;
						}
					}
				}
				matrixArray = result.matrixArray;
			}
			else
				throw new ArgumentException("Zły wymiar macierzy, operacja niedostepna");
		}

		public void Add(Matrix<T> otherMatrix)
		{
			if (this.row == otherMatrix.row && this.column == otherMatrix.column)
			{
				Matrix<T> result = new Matrix<T>(this.row, this.column);
				for (int i = 0; i < this.row; i++)
					for (int j = 0; j < this.column; j++)
						matrixArray[i, j] += (dynamic)otherMatrix.matrixArray[i, j];
			}
			else
				throw new ArgumentException("Zły wymiar macierzy, operacja niedostepna");
		}

		public T GetValue(int row, int column)
		{
			return this.matrixArray[row, column];
		}

		public bool CompareToZero(T a, int b)
		{
			if ((dynamic)a == b)
				return true;
			return false;
		}

		public void WriteMyMatrix()
		{
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < column; j++)
				{
					Console.Write(matrixArray[i, j]);
					Console.Write(" ");
				}
				Console.WriteLine();
			}
		}
	}
}
