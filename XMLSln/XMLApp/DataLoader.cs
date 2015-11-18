using System.Collections.Generic;
using System.Xml;

namespace XMLApp
{
	public static class DataLoader<T> where T: Product, new()
	{
		private const string path = @".\Products.xml";

		public static IList<T> LoadData()
		{
			IList<T> products = new List<T>();

			// setup xml reader settings first
			var xmlReaderSettings = new XmlReaderSettings();
			xmlReaderSettings.IgnoreWhitespace = true;
			xmlReaderSettings.IgnoreComments = true;

			// init xml reader
			var xmlReader = XmlReader.Create(path, xmlReaderSettings);

			// read past all nodes down to the first "Product" node
			
			if (xmlReader.ReadToDescendant("Product"))
			{
				do
				{
					T product = new T();
					xmlReader.ReadStartElement("Product");
					product.Code = xmlReader.ReadElementContentAsString();
					product.Description = xmlReader.ReadElementContentAsString();
					product.Price = xmlReader.ReadElementContentAsDecimal();

					products.Add(product);

				}
				while (xmlReader.ReadToNextSibling("Product"));
			}

			// always close your file handlers once you are done - otherwise this will cause a memory leak
			xmlReader.Close();
			return products;
		}
	}
}
