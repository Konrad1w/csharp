using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3Template
{
	class Complex<T> : IComparable, IFormattable where T : IComparable, IFormattable
	{
		T realNumber;
		T imaginaryNumber;


		public Complex(T _realNumber, T _imaginaryNumber)
		{
			realNumber = _realNumber;
			imaginaryNumber = _imaginaryNumber;
		}

		public T GetRealNumber()
		{
			return realNumber;
		}

		public T GetImaginaryNumber()
		{
			return imaginaryNumber;
		}

		public static Complex<T> operator +(Complex<T> a, Complex<T> b)
		{
			return new Complex<T>((dynamic)a.realNumber + b.realNumber, (dynamic)a.imaginaryNumber + b.imaginaryNumber);
		}

		public static bool operator ==(Complex<T> a, Complex<T> b)
		{
			if (a.CompareTo(b) == 0)
				return true;
			return false;
		}

		public static bool operator !=(Complex<T> a, Complex<T> b)
		{
			if (a.CompareTo(b) == 0)
				return false;
			return true;
		}

		public static Complex<T> operator *(Complex<T> a, Complex<T> b)
		{
			dynamic val1 = (dynamic)a.realNumber * b.realNumber;
			dynamic val4 = (dynamic)a.imaginaryNumber * b.imaginaryNumber;
			dynamic val2 = (dynamic)a.realNumber * b.imaginaryNumber;
			dynamic val3 = (dynamic)a.imaginaryNumber * b.realNumber;
			return new Complex<T>(val1 - val4, val2 + val3);
		}

		public int CompareTo(object obj)
		{
			if (obj is Complex<T> other)
			{
				int realComparison = realNumber.CompareTo(other.realNumber);

				return realComparison != 0 ? realComparison : imaginaryNumber.CompareTo(other.imaginaryNumber);
			}
			else
				throw new ArgumentException("Object nie jest Complex");
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return realNumber.ToString(format, formatProvider) + " " + imaginaryNumber.ToString(format, formatProvider) + "i";
		}
	}
}
