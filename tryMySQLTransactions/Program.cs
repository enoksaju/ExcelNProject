using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using tryMySQLTransactions.Model;

namespace tryMySQLTransactions
{
	class Program
	{
		static void Main ( string[] args )
		{
			string connectionString = Properties.Settings.Default.defaultConnection;
			using ( MySqlConnection connection = new MySqlConnection ( connectionString ) )
			{
				// Create database if not exists
				using ( DataBaseContext contextDB = new DataBaseContext ( connection, false ) )
				{
					contextDB.Database.CreateIfNotExists ( );
				}

				connection.Open ( );
				MySqlTransaction transaction = connection.BeginTransaction ( );

				try
				{
					using ( DataBaseContext context = new DataBaseContext ( connection, false ) )
					{

						// Interception/SQL logging
						context.Database.Log = ( string message ) => { Console.WriteLine ( message ); };

						// Passing an existing transaction to the context
						context.Database.UseTransaction ( transaction );

						// DbSet.AddRange
						List<Car> cars = new List<Car> ( );

						cars.Add ( new Car { Manufacturer = "Nissan", Model = "370Z", Year = 2012 } );
						cars.Add ( new Car { Manufacturer = "Ford", Model = "Mustang", Year = 2013 } );
						cars.Add ( new Car { Manufacturer = "Chevrolet", Model = "Camaro", Year = 2012 } );
						cars.Add ( new Car { Manufacturer = "Dodge", Model = "Charger", Year = 2013 } );

						context.Cars.AddRange ( cars );
						context.SaveChanges ( );
					}
					transaction.Commit ( );
				}
				catch ( Exception ex )
				{
					transaction.Rollback ( );
					Console.WriteLine ( ex.Message );
				}
				Console.Read ( );
			}
		}
	}
}
