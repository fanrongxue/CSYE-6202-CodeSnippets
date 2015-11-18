using System;
using System.Collections.Generic;

namespace XMLApp
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Test code for loading products

			//Console.WriteLine("Loading products..");

			//var products = DataLoader<Product>.LoadData();

			//foreach (var item in products)
			//{
			//	Console.WriteLine(item.ToString());
			//}

			#endregion

			#region Test code for loading products

			Console.WriteLine("Saving products..");

			var products = new List<Product>
			{
				new Product("AAPL", "IPhone", 199.99M),
				new Product("KRX", "Galaxy", 199.90M),
				new Product("LG", "G4", 189.99M),
			};

			DataSaver<Product>.SaveData(products);

			#endregion

			Console.Read();
		}
	}
}
