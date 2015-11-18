using System;

namespace GenericsApp.DotNetGenericInterfaces
{
	public class Product : /*IProduct,*/ IComparable<Product>
	{
		#region Properties

		public string Code { get; private set; }

		public string Description { get; private set; }

		public decimal Price { get; private set; }

		#endregion

		#region Constructors

		private Product() { }

		public Product(string code, string description, decimal price)
		{
			Code = code;
			Description = description;
			Price = price;
		}

		#endregion

		public override string ToString()
		{
			//return this.Description;
			return this.Description + ": $" + this.Price;
		}

		public int CompareTo(Product other)
		{
			return this.Price.CompareTo(other.Price);
		}
	}
}
