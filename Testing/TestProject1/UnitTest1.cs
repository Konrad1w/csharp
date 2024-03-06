namespace TestProject1
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			SimpleCalculator simpleCalculator = new SimpleCalculator();
			int result = simpleCalculator.Add(1, 2);
			Assert.AreEqual(3, result);
		}
		[Test]
		public void Test2()
		{
			ConcatStrings concatStrings = new ConcatStrings();
			string result = concatStrings.ConcatWithNull("bbb", "aaaa");
			Assert.AreEqual("bbbaaaa", result);
		}
		[Test]
		public void Test3()
		{
			ConcatStrings concatStrings = new ConcatStrings();
			string result = concatStrings.ConcatWithNull(null, "aaaa");
			Assert.AreEqual(null, result);
		}
		[Test]
		public void Test4()
		{
			ConcatStrings concatStrings = new ConcatStrings();
			try
			{
				string result = concatStrings.ConcatWithExepction(null, "aaaa");
			}
			catch (ArgumentException ex)
			{
				Assert.True(true);
			}
			catch (Exception ex)
			{
				Assert.True(false);
			}
			Assert.Pass();
		}
		[Test]
		public void Test5()
		{
			IAnagramChecker anagram = new Anagram();
			bool result = anagram.IsAnagram("kot", "pot");
			Assert.AreEqual(result, false);
		}
		[Test]
		public void Test6()
		{
			IAnagramChecker anagram = new Anagram();
			bool result = anagram.IsAnagram("top", "pot");
			Assert.AreEqual(result, true);
		}
		[Test]
		public void Test7()
		{
			IAnagramChecker anagram = new Anagram();
			bool result = anagram.IsAnagram(" t  o p     ", "     p o t ");
			Assert.AreEqual(result, true);
		}
		[Test]
		public void Test8()
		{
			IAnagramChecker anagram = new Anagram();
			bool result = anagram.IsAnagram("TOP", "pot");
			Assert.AreEqual(result, true);
		}
		[Test]
		public void Test9()
		{
			IAnagramChecker anagram = new Anagram();
			bool result = anagram.IsAnagram(" ", "  ");
			Assert.AreEqual(result, true);
		}
		[Test]
		public void Test10()
		{
			IAnagramChecker anagram = new Anagram();
			bool result = anagram.IsAnagram("*&$p%%$o   %t%", "%#t$#o  %p!");
			Assert.AreEqual(result, true);
		}
		[Test]
		public void Test11()
		{
			IAnagramChecker anagram = new Anagram();
			bool result = anagram.IsAnagram("pies", "kot");
			Assert.AreEqual(result, false);
		}

	}


}
