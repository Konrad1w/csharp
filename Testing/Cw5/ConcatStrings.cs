using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConcatStrings
{
	public string ConcatWithNull(string a, string b)
	{
		if (a == null || b == null)
			return null;
		return a + b;
	}
	public string ConcatWithExepction(string a, string b)
	{
		if (a == null || b == null)
			throw new ArgumentNullException();
		return a + b;
	}
}

