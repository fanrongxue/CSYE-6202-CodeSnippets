#region Using Directives

using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace SimpleDataAdapterDataSetExample
{
	class Program
	{
		static void Main(string[] args)
		{
			// first build the connection string
			var connectionStringBuilder = new SqlConnectionStringBuilder();
			connectionStringBuilder.InitialCatalog = "CarDB";
			connectionStringBuilder.DataSource = @"HAGAR\SQLEXPRESS";
			connectionStringBuilder.ConnectTimeout = 30;
			connectionStringBuilder.IntegratedSecurity = true;

			// create dataset by passing in the DB name that is of interest
			var dataSet = new DataSet("CarDB");

			// now inform the adapter of the select command text as well as the connection string
			var adapter = new SqlDataAdapter("Select * From Inventory", connectionStringBuilder.ConnectionString);

			// fill our dataset with a new table, named Inv
			adapter.Fill(dataSet, "Inv");

			// display contents of dataset with the help of the method below
			PrintDataSet(dataSet);

			Console.Read();
		}

		static void PrintDataSet(DataSet dataSet)
		{
			Console.WriteLine("DataSet is named: {0}", dataSet.DataSetName);

			// print out each table
			foreach (DataTable dt in dataSet.Tables)
			{
				Console.WriteLine("Table is named: {0}", dt.TableName);

				// print out all the column names
				for (int curCol = 0; curCol < dt.Columns.Count; ++curCol)
				{
					Console.Write(dt.Columns[curCol].ColumnName + "\t");
				}
				Console.WriteLine("\n=================================");

				// print the rows/records now
				for (int curRow = 0; curRow < dt.Rows.Count; ++curRow)
				{
					for (int curCol = 0; curCol < dt.Columns.Count; ++curCol)
					{
						Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
					}
					Console.WriteLine();
				}
			}
		}
	}
}
