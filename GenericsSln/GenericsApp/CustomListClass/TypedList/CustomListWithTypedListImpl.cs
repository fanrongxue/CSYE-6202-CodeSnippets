using System.Collections.Generic;

namespace GenericsApp.CustomListClass.TypedList
{
	public class CustomListWithTypedListImpl : ICustomListWithTypedListImpl
	{
		//private List<int> typedList = new List<int>();
		private IList<int> typedList = new List<int>();

		// read-only indexer
		public int this[int i]
		{
			get { return typedList[i]; }
		}

		public void Add(int item)
		{
			typedList.Add(item);
		}

		public int Count
		{
			get { return typedList.Count; }
		}

		public override string ToString()
		{
			string arrayListString = string.Empty;

			foreach (var item in typedList)
			{
				arrayListString += item.ToString() + "\t";
			}

			return arrayListString;
		}
	}
}
