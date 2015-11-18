using System.Collections.Generic;
using GenericsApp.DotNetGenericInterfaces;

namespace GenericsApp.CustomListClass.Constraints
{
	public class CustomListWithConstraints<T> where T: Product//, IProduct
	{
		private IList<T> genericsList = new List<T>();

		// read-only indexer
		public T this[int i]
		{
			get { return genericsList[i]; }
		}

		public void Add(T item)
		{
			genericsList.Add(item);
		}

		public int Count
		{
			get
			{
				return genericsList.Count;
			}
		}

		public override string ToString()
		{
			string arrayListString = string.Empty;

			foreach (var item in genericsList)
			{
				arrayListString += item.ToString() + "\t";
			}

			return arrayListString;
		}
	}
}
