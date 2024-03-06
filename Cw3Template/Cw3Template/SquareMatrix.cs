using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3Template
{
	class SquareMatrix<T> : Matrix<T> where T : IComparable, IFormattable
	{
		int size;
		public SquareMatrix(int _size) : base(_size, _size) { size = _size; }

		public bool IsDiagonal()
		{
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					if (i != j && CompareToZero(GetValue(i, j), 0))
						return false;
			return true;
		}
	}
}
