using System;
using System.Collections.Generic;

namespace GenericsApp.CustomListClass.Generics
{
	public class CustomListWithGenericsImpl<T> : ICustomListWithGenericsImpl<T>
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

		//public T Count
		//{
		//	get
		//	{
		//		//return genericsList.Count;
		//		return (T)(object)genericsList.Count;
		//	}
		//}

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
