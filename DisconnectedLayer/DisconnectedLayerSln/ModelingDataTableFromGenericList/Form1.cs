#region Using Directives

using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

#endregion

namespace ModelingDataTableFromGenericList
{
	public partial class Form1 : Form
	{
		private List<Car> cars;
		private DataTable carInventory = new DataTable();

		public Form1()
		{
			InitializeComponent();

			// fill the cars list
			cars = new List<Car>
			{
				new Car { ID = 100, PetName = "Chucky", Make= "Chevy", Color = "Black" },
				new Car { ID = 101, PetName = "Tiny", Make= "Yugo", Color = "Green" },
				new Car { ID = 102, PetName = "Mini", Make= "Mini", Color = "Blue" },
				new Car { ID = 103, PetName = "Headache", Make= "Jeep", Color = "Red" },
				new Car { ID = 104, PetName = "Muscle", Make= "Pontiac", Color = "White" }
			};

			CreateDataTable();
    }

		private void CreateDataTable()
		{
			// create table schema
			var carIDColumn = new DataColumn("ID", typeof(int));
			var carMakeColumn = new DataColumn("Make", typeof(string));
			var carColorColumn = new DataColumn("Color", typeof(string));
			var carPetNameColumn = new DataColumn("PetName", typeof(string));

			carPetNameColumn.Caption = "Pet Name";
			carInventory.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });

			// now that our table schema is complete, iterate over our List<T> to create rows
			foreach (var car in cars)
			{
				DataRow newRow = carInventory.NewRow();
				newRow["ID"] = car.ID;
				newRow["Make"] = car.Make;
				newRow["Color"] = car.Color;
				newRow["PetName"] = car.PetName;
				carInventory.Rows.Add(newRow);
			}

			// finally bind the DataTable to the gridView
			carInventoryGridView.DataSource = carInventory;
    }
	}
}
