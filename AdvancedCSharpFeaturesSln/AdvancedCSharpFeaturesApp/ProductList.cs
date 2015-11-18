using System.Collections.Generic;

namespace AdvancedCSharpFeaturesApp
{
	public class ProductList
	{
		private List<Product> products = new List<Product>();

		#region Indexers

		// Note:	An "indexer" is a special type of property that lets a user of the class
		//				access individual items within the class by specifying an index value.
		//				Indexers are used for classes that represent collections of objects.
		public Product this[int i]
		{
			get { return products[i]; }
			//set { products[i] = value;  }
		}

		// read-only string based indexer
		public Product this[string code]
		{
			get
			{
				foreach (var item in products)
				{
					if (item.Code == code)
					{
						return item;
					}
				}
				return null;
			}
		}

		#endregion

		public void Add(Product product)
		{
			products.Add(product);
		}

		// operator overloading example here
		public static ProductList operator +(
			ProductList productList, 
			Product product)
		{
			productList.Add(product);
			return productList;
		}
	}
}
