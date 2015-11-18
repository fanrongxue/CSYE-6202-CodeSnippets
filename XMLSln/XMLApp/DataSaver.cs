using System;
using System.Collections.Generic;
using System.Xml;

namespace XMLApp
{
	public static class DataSaver<T> where T : Product, new()
	{
		private const string path = @".\SavedProducts.xml";

		public static void SaveData(List<T> products)
		{
			// setup xml writer settings first
			var xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = ("	");

			// init xml reader
			var xmlWriter = XmlWriter.Create(path, xmlWriterSettings);

			// write the start of the document first
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("Products");

			// loop through each product and write it to the specified XML file
			foreach (var product in products)
			{				
				xmlWriter.WriteStartElement("Product");
				xmlWriter.WriteElementString("Code", product.Code);
				xmlWriter.WriteElementString("Description", product.Description);
				xmlWriter.WriteElementString("Price", Convert.ToString(product.Price));
				xmlWriter.WriteEndElement();
			}

			// write the end tag for the root element which is Products
			xmlWriter.WriteEndElement();

			// always close your file handlers once you are done - otherwise this will cause a memory leak
			xmlWriter.Close();
		}
	}
}
