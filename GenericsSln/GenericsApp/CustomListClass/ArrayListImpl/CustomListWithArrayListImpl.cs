using System;
using System.Collections;

namespace GenericsApp.CustomListClass.ArrayListImpl
{
	public class CustomListWithArrayListImpl : ICustomListWithArrayListImpl
	{
		private ArrayList arrayList = new ArrayList();

		// read-only indexer
		public int this[int i]
		{
			get { return (int)arrayList.IndexOf(i); }
		}

		public void Add(int item)
		{
			arrayList.Add(item);
		}

		public int Count
		{
			get { return arrayList.Count; }
		}

		public override string ToString()
		{
			string arrayListString = string.Empty;

			foreach (var item in arrayList)
			{
				arrayListString += item.ToString() + "\t";
			}

			return arrayListString;
		}
	}
}
