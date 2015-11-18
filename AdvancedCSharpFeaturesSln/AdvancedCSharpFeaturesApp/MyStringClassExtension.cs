using System;

namespace AdvancedCSharpFeaturesApp
{
	// Note:	Extension methods are defined as static methods but they are called by using instance method syntax.
	//				Their first parameter specifies which type the method operates on, and the parameter is preceded 
	//				by the "this" modifier. Extension methods are only in scope when you explicitly import the namespace
	//				into your source code with a "using" directive.
	public static class MyStringClassExtension
	{
		public static int WordCount(this String str)
		{
			return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
		}
	}
}
