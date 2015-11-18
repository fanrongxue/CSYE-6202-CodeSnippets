namespace GenericsApp.CustomListClass.Generics
{
	//	Note: To define a generic collection, you code angle brackets after the name of the interface
	//	and you specify the "type parameter" within these brackets.

	//	Note: By convention, most programmers use the letter T as the type parameter, however you can
	//	use any parameter name here.

	//	Note: Think of T as a placeholder that will be filled in later.
	public interface ICustomListWithGenericsImpl<T>
	{
		void Add(T item);
		//T Count { get; }
		int Count { get; }
	}
}
