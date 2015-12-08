using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConnectedLayerInventoryDAL
{
	public class InventoryDAL
	{
		private SqlConnection connection = null;

		public void OpenConnection(string connectionString)
		{
			connection = new SqlConnection();
			connection.ConnectionString = connectionString;
			connection.Open();
		}

		public void CloseConnection()
		{
			connection.Close();
		}

		public void InsertCar(Car newCar)
		{
			// format and execute SQL statement
			string sql = string.Format("Insert Into Inventory" +
				"(CarID, Make, Color, PetName) Values" + 
				"('{0}', '{1}', '{2}', '{3}')", newCar.CarID, newCar.Make, newCar.Color, newCar.PetName);

			// execute this insert statement using our connection
			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				command.ExecuteNonQuery();
			}
		}

		public void InsertCarParameterized(Car newCar)
		{
			// format and execute SQL statement
			string sql = string.Format("Insert Into Inventory" +
				"(CarID, Make, Color, PetName) Values" +
				"(@CarID, @Make, @Color, @PetName)");

			// execute this insert statement using our connection
			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				// fill the params collection
				var param = new SqlParameter();
				param.ParameterName = "@CarID";
				param.Value = newCar.CarID;
				param.SqlDbType = SqlDbType.Int;
				command.Parameters.Add(param);

				param = new SqlParameter();
				param.ParameterName = "@Make";
				param.Value = newCar.Make;
				param.SqlDbType = SqlDbType.VarChar;
				param.Size = 50;
				command.Parameters.Add(param);

				param = new SqlParameter();
				param.ParameterName = "@Color";
				param.Value = newCar.Color;
				param.SqlDbType = SqlDbType.VarChar;
				param.Size = 50;
				command.Parameters.Add(param);

				param = new SqlParameter();
				param.ParameterName = "@PetName";
				param.Value = newCar.PetName;
				param.SqlDbType = SqlDbType.VarChar;
				param.Size = 50;
				command.Parameters.Add(param);

				command.ExecuteNonQuery();
			}
		}


		public void DeleteCar(int id)
		{
			// get ID of the car to delete, then try
			string sql = string.Format("Delete from Inventory where CarID = '{0}'", id);

			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				try
				{
					command.ExecuteNonQuery();
				}
				catch (SqlException e)
				{
					Console.WriteLine("Sql related exception occurred. Exception details: {0}", e.Message);
				}
				catch (Exception e)
				{
					Console.WriteLine("A generic exception occurred. Exception details: {0}", e.Message);
				}
			}
		}

		public void UpdateCarPetName(int id, string newPetName)
		{
			string sql = string.Format("Update Inventory Set PetName = '{0}' Where CarID = '{1}'",
				newPetName, id);

			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				command.ExecuteNonQuery();
			}
		}

		public List<Car> GetAllInventory()
		{
			var inventory = new List<Car>();

			string sql = "Select * From Inventory";
			using (SqlCommand command = new SqlCommand(sql, connection))
			{
				SqlDataReader dr = command.ExecuteReader();
				while (dr.Read())
				{
					inventory.Add(new Car
					{
						CarID = (int)dr["CarID"],
						Color = (string)dr["Color"],
            Make = (string)dr["Make"],
            PetName = (string)dr["PetName"]
					});
				}
				dr.Close();
			}

			return inventory;
		}
	}
}
