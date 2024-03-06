using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAnagramChecker
{
	/*Sprawdza czy jedno slowo jest anagramem drugiego.
    * Wszystkie niealfanumeryczne znaki są ignorowane.
    * Wielkość liter nie ma znaczenia.
    * word1 - dowolny niepusty string różny od null.
    * word2 - dowolny niepusty string różny od null.
    * Zwraca true wtedy i tylko wtedy gdy word1 jest anagramem word2.
    */
	bool IsAnagram(string word1, string word2);
}
