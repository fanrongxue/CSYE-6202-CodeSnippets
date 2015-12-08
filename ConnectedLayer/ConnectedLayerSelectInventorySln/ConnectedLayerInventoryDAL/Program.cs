using System;
using System.Data.SqlClient;

namespace ConnectedLayerInventoryDAL
{
	class Program
	{
		static void Main(string[] args)
		{
			var inventoryDAL = new InventoryDAL();

			//SqlConnection connection = new SqlConnection();
			//connection.ConnectionString = @"Data Source=HAGAR\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=CarDB";
			//connection.Open();


			SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
			connectionStringBuilder.InitialCatalog = "CarDB";
			connectionStringBuilder.DataSource = @"HAGAR\SQLEXPRESS";
			connectionStringBuilder.ConnectTimeout = 30;
			connectionStringBuilder.IntegratedSecurity = true;

			inventoryDAL.OpenConnection(connectionStringBuilder.ConnectionString);
			var inventory = inventoryDAL.GetAllInventory();

			foreach (var item in inventory)
			{
				Console.WriteLine("CarID: {0}, Color: {1}, Make: {2}, PetName: {3}", item.CarID, item.Color, item.Make, item.PetName);
			}

			Console.WriteLine("\n");
			var car = new Car()
			{
				CarID = 102,
				Make = "Nissan",
				Color = "Blue",
				PetName = "Nizmo"
			};

			inventoryDAL.InsertCar(car);
			//inventoryDAL.InsertCarParameterized(car);
			inventory = inventoryDAL.GetAllInventory();

			foreach (var item in inventory)
			{
				Console.WriteLine("CarID: {0}, Color: {1}, Make: {2}, PetName: {3}", item.CarID, item.Color, item.Make, item.PetName);
			}


			inventoryDAL.CloseConnection();


			Console.Read();
		}
	}
}
