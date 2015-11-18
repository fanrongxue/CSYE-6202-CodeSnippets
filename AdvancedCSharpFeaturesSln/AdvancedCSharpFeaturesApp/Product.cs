namespace AdvancedCSharpFeaturesApp
{
	public class Product
	{
		#region Properties

		public string Code { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		#endregion

		#region Constructors

		public Product() { }

		public Product(string code, string description, decimal price)
		{
			Code = code;
			Description = description;
			Price = price;
		}

		#endregion

		public override string ToString()
		{
			return "Code: " + Code + "\tDescription: " + Description + "\tPrice: " + Price;
		}
	}
}
