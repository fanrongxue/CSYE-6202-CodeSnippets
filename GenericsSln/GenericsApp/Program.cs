#region Using Directives

using System;
using GenericsApp.CustomListClass.ArrayListImpl;
using GenericsApp.CustomListClass.Constraints;
using GenericsApp.CustomListClass.Generics;
using GenericsApp.CustomListClass.TypedList;
using GenericsApp.DotNetGenericInterfaces;

#endregion

namespace GenericsApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			#region Test code that uses CustomListWithArrayListImpl

			//var item1 = 11;
			//var item2 = 5;
			//var item3 = 8;

			//ICustomListWithArrayListImpl arrayList = new CustomListWithArrayListImpl();
			//arrayList.Add(item1);
			//arrayList.Add(item2);
			//arrayList.Add(item3);

			//Console.WriteLine("List count: " + arrayList.Count);
			//Console.WriteLine(arrayList.ToString());

			#endregion

			#region Test code that uses TypedList

			//var item1 = 11;
			//var item2 = 5;
			//var item3 = 8;

			//ICustomListWithTypedListImpl typedList = new CustomListWithTypedListImpl();
			//typedList.Add(item1);
			//typedList.Add(item2);
			//typedList.Add(item3);

			//Console.WriteLine("List count: " + typedList.Count);
			//Console.WriteLine(typedList.ToString());

			#endregion

			#region Test code that uses Generics with Primitive Types

			//var item1 = 11;
			//var item2 = 5;
			//var item3 = 8;

			//ICustomListWithGenericsImpl<int> genericsList = new CustomListWithGenericsImpl<int>();
			//genericsList.Add(item1);
			//genericsList.Add(item2);
			//genericsList.Add(item3);

			//Console.WriteLine("List count: " + genericsList.Count);
			//Console.WriteLine(genericsList.ToString());

			#endregion

			#region Test code that uses Generics with Reference Types

			//var product1 = new Product("AAPL", "IPhone", 199.99M);
			//var product2 = new Product("KRX", "Galaxy", 199.90M);
			//var product3 = new Product("LG", "G4", 189.99M);

			//ICustomListWithGenericsImpl<Product> genericsList = new CustomListWithGenericsImpl<Product>();
			//genericsList.Add(product1);
			//genericsList.Add(product2);
			//genericsList.Add(product3);

			//Console.WriteLine("List count: " + genericsList.Count);
			//Console.WriteLine(genericsList.ToString());

			#endregion

			#region Test code that uses DotNet Generic Interfaces (i.e. IComparable<> interface)

			var product1 = new Product("AAPL", "IPhone", 199.99M);
			var product2 = new Product("KRX", "Galaxy", 199.90M);
			var product3 = new Product("LG", "G4", 189.99M);

			ICustomListWithGenericsImpl<Product> genericsList = new CustomListWithGenericsImpl<Product>();
			genericsList.Add(product1);
			genericsList.Add(product2);
			genericsList.Add(product3);

			Console.WriteLine("List count: " + genericsList.Count);
			Console.WriteLine(genericsList.ToString());

			var compareToValue = product1.CompareTo(product2);
			switch (compareToValue)
			{
				case 1:
					Console.WriteLine(product1.Description + " is more expensive than " + product2.Description);
					break;
				case 0:
					Console.WriteLine(product1.Description + " is the same price with " + product2.Description);
					break;
				case -1:
					Console.WriteLine(product1.Description + " is more cheaper than " + product2.Description);
					break;
			}

			#endregion

			#region Test code that uses Generics with Constraints

			//var product1 = new Product("AAPL", "IPhone", 199.99M);
			//var product2 = new Product("KRX", "Galaxy", 199.90M);
			//var product3 = new Product("LG", "G4", 189.99M);

			//var genericsList = new CustomListWithConstraints<Product>();
			//genericsList.Add(product1);
			//genericsList.Add(product2);
			//genericsList.Add(product3);

			//Console.WriteLine("List count: " + genericsList.Count);
			//Console.WriteLine(genericsList.ToString());

			//var compareToValue = product1.CompareTo(product2);
			//switch (compareToValue)
			//{
			//	case 1:
			//		Console.WriteLine(product1.Description + " is more expensive than " + product2.Description);
			//		break;
			//	case 0:
			//		Console.WriteLine(product1.Description + " is the same price with " + product2.Description);
			//		break;
			//	case -1:
			//		Console.WriteLine(product1.Description + " is more cheaper than " + product2.Description);
			//		break;
			//}

			#endregion

			Console.Read();
		}
	}
}
