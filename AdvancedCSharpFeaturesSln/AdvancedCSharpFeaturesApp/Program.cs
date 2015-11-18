using System;

namespace AdvancedCSharpFeaturesApp
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Test code for indexer implementation

			//// create our test data first
			//var products = new ProductList();
			//products.Add(new Product("AAPL", "IPhone", 199.99M));
			//products.Add(new Product("KRX", "Galaxy", 199.90M));
			//products.Add(new Product("LG", "G4", 189.99M));

			//// access second product using our indexer
			//var product = products[1];
			//Console.WriteLine(product.ToString());

			//// access LG product using our other indexer
			//product = products["LG"];
			//Console.WriteLine(product.ToString());

			#endregion

			#region Test code for operator overloading implementation

			//// create our test data first
			//var products = new ProductList();
			//var p = new Product("AAPL", "IPhone", 199.99M);
			//products += p;

			//p = new Product("KRX", "Galaxy", 199.90M);
			//products += p;

			//p = new Product("LG", "G4", 189.99M);
			//products += p;

			//var product = products[0];
			//Console.WriteLine(product.ToString());

			#endregion

			#region Test code for extension method implementation

			var testString = "This string is here for testing out our awesome, extension method?";
			var i = testString.WordCount();
			Console.WriteLine("Word count for testString is: {0}", i);

			#endregion

			Console.Read();
		}
	}
}
