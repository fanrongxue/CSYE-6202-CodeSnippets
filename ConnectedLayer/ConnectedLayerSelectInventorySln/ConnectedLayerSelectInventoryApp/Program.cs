#region Using Directives

using System;
using System.Data.SqlClient;

#endregion

namespace ConnectedLayerSelectInventoryApp
{
	class Program
	{
		#region Simple Use Case

		//	static void Main(string[] args)
		//	{
		//		// create & open a connection first
		//		using (SqlConnection sqlConnection = new SqlConnection())
		//		{
		//			// IMPORTANT - .NET connection objects are provided with a formatted connection string like the one below
		//			//						 This string contains a number of name/value pairs, separated by semicolons. You use this information
		//			//						 to identify the name of the machine you want to connect to, required security settings, the name of
		//			//						 the database on that machine, and other data provider -- specific information

		//			// Initial Catalog - Refers to the database you want to establish a session with. 
		//			// Data Source - Identifies the name of the machine that maintains the database. Here, HAGAR is the name of the 
		//			//							 machine that hosts the SQLEXPRESS instance that is simply named as SQLEXPRESS
		//			// Integrated Security - Specifies the security credentials. Here SSPI forces to use the current Windows account
		//			//											 credentials for user authentication.
		//			sqlConnection.ConnectionString = @"Data Source=HAGAR\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=CarDB";
		//			sqlConnection.Open();

		//			// create a SQL command object
		//			string sqlString = "SELECT * FROM Inventory";
		//			SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);

		//			// next obtain a data reader via ExecuteReader() method
		//			using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
		//			{
		//				// now we can loop over our results
		//				while (sqlDataReader.Read())
		//				{
		//					Console.WriteLine("ID: {0} --> Make: {1}, PetName: {2}, Color: {3}",
		//						sqlDataReader["CarID"].ToString(),
		//						sqlDataReader["Make"].ToString(),
		//						sqlDataReader["PetName"].ToString(),
		//						sqlDataReader["Color"].ToString());
		//				}
		//			}
		//		}
		//		Console.Read();
		//	}
		//}

		#endregion

		#region Working with ConnectionStringBuilder Objects

		// PURPOSE - Working with conenction strings programmatically can be cumbersome because
		//					 they are often represented as string literals, which are difficult to maintain
		//					 and error-prone at best. Microsoft-supplied ADO.NET data providers support 
		//					 connection string builder objects, which allow you to establish name/value
		//					 pairs using strongly typed properties.
		static void Main(string[] args)
		{
			// updated section here
			SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
			connectionStringBuilder.InitialCatalog = "CarDB";
			connectionStringBuilder.DataSource = @"HAGAR\SQLEXPRESS";
			connectionStringBuilder.ConnectTimeout = 30;
			connectionStringBuilder.IntegratedSecurity = true;

			// create & open a connection first
			using (SqlConnection sqlConnection = new SqlConnection())
			{

				sqlConnection.ConnectionString = connectionStringBuilder.ConnectionString;
				sqlConnection.Open();

				// create a SQL command object
				// SqlCommand type (which derives from DbCommand) is an OO representation of
				// a SQL query, table name, or stored procedure.
				string sqlString = "SELECT * FROM Inventory";
				SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);

				// next obtain a data reader via ExecuteReader() method
				using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
				{
					// now we can loop over our results
					while (sqlDataReader.Read())
					{
						Console.WriteLine("ID: {0} --> Make: {1}, PetName: {2}, Color: {3}",
							sqlDataReader["CarID"].ToString(),
							sqlDataReader["Make"].ToString(),
							sqlDataReader["PetName"].ToString(),
							sqlDataReader["Color"].ToString());
					}
				}
			}
			Console.Read();
		}

		#endregion
	}
}
