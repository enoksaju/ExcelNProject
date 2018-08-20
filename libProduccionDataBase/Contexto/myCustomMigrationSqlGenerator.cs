using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;

namespace libProduccionDataBase.Contexto
{
	/// <summary>
	/// Inherit from MySqlMigrationSqlGenerator by fixing the Index generation method, set the default type in BTREE 
	/// <para>(the MySql manual says that in the SQL script syntax it is not necessary to specify it for the innoDB engine)</para>
	/// </summary>
	public class MyCustomMigrationSQLGenerator : MySqlMigrationSqlGenerator
	{
		private string TrimSchemaPrefix ( string table )
		{
			if ( table.StartsWith ( "dbo." ) )
				return table.Replace ( "dbo.", "" );
			return table;
		}

		protected override MigrationStatement Generate ( CreateIndexOperation op )
		{
			StringBuilder sb = new StringBuilder ( );

			sb = sb.Append ( "CREATE " );

			if ( op.IsUnique )
			{
				sb.Append ( "UNIQUE " );
			}

			object sort;
			op.AnonymousArguments.TryGetValue ( "Sort", out sort );
			var sortOrder = sort != null && sort.ToString ( ) == "Ascending" ?
							"ASC" : "DESC";

			sb.AppendFormat ( "index  `{0}` on `{1}` (", op.Name, TrimSchemaPrefix ( op.Table ) );
			sb.Append ( string.Join ( ",", op.Columns.Select ( c => "`" + c + "` " + sortOrder ) ) + ") " );

			return new MigrationStatement ( ) { Sql = sb.ToString ( ) };
		}
	}

	/// <summary>
	/// Inherit from DbConfiguration to set the new QSL script generator and set the conditions to work with MySQL
	/// </summary>
	public class MyCustomEFConfiguration : DbConfiguration
	{
		public MyCustomEFConfiguration ()
		{
			AddDependencyResolver ( new MySqlDependencyResolver ( ) );
			SetProviderFactory ( MySqlProviderInvariantName.ProviderName, new MySqlClientFactory ( ) );
			SetProviderServices ( MySqlProviderInvariantName.ProviderName, new MySqlProviderServices ( ) );
			SetDefaultConnectionFactory ( new MySqlConnectionFactory ( ) );
			SetMigrationSqlGenerator ( MySqlProviderInvariantName.ProviderName, () => new MyCustomMigrationSQLGenerator ( ) );
			SetManifestTokenResolver ( new MySqlManifestTokenResolver ( ) );
			SetHistoryContext ( MySqlProviderInvariantName.ProviderName, 
				( existingConnection, defaultSchema ) => new MyCustomHistoryContext ( existingConnection, defaultSchema ) );
		}
	}

	/// <summary>
	/// Read and write the migration history of the database during the first code migrations. This class must be in the same assembly as the EF configuration
	/// </summary>
	public class MyCustomHistoryContext : HistoryContext
	{
		public MyCustomHistoryContext ( DbConnection existingConnection, string defaultSchema ) : base ( existingConnection, defaultSchema ) { }

		protected override void OnModelCreating ( System.Data.Entity.DbModelBuilder modelBuilder )
		{
			base.OnModelCreating ( modelBuilder );
			modelBuilder.Entity<HistoryRow> ( ).HasKey ( h => new { h.MigrationId } );
		}
	}

}
