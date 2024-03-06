using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Anagram : IAnagramChecker
{
	public bool IsAnagram(string a, string b)
	{
		Regex regex = new Regex("[^a-zA-Z0-9]");
		a = regex.Replace(a, "");
		b = regex.Replace(b, "");
		if (a.Length != b.Length) return false;
		char[] aArray = a.ToLower().ToCharArray();
		char[] bArray = b.ToLower().ToCharArray();
		Array.Sort(aArray);
		Array.Sort(bArray);
		for (int i = 0; i < aArray.Length; i++)
			if (aArray[i] != bArray[i]) return false;
		return true;

	}
}
