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
	public class customMigrationSQLGenerator : MySqlMigrationSqlGenerator
	{
		private string TrimSchemaPrefix ( string table )
		{
			if ( table.StartsWith ( "dbo." ) )
				return table.Replace ( "dbo.", "" );
			return table;
		}

		private string PrepareSql ( string sql, bool removeNonMySqlChars )
		{
			var sqlResult = sql;
			if ( removeNonMySqlChars )
			{
				sqlResult = sql.Replace ( "[", "" ).Replace ( "]", "" ).Replace ( "@", "" );
			}
			sqlResult = sqlResult.Replace ( "dbo.", "" );
			return sqlResult;
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
		protected override MigrationStatement Generate ( DropForeignKeyOperation op )
		{
			StringBuilder sb = new StringBuilder ( );
			sb = sb.AppendFormat ( "ALTER TABLE `{0}` DROP FOREIGN KEY `{1}`", TrimSchemaPrefix ( op.DependentTable ), op.Name.Replace("_dbo.","_") );
			return new MigrationStatement { Sql = sb.ToString ( ) };
		}


	}

	/// <summary>
	/// Inherit from DbConfiguration to set the new QSL script generator and set the conditions to work with MySQL
	/// </summary>
	public class customEFConfiguration : DbConfiguration
	{
		public customEFConfiguration ()
		{
			AddDependencyResolver ( new MySqlDependencyResolver ( ) );
			SetProviderFactory ( MySqlProviderInvariantName.ProviderName, new MySqlClientFactory ( ) );
			SetProviderServices ( MySqlProviderInvariantName.ProviderName, new MySqlProviderServices ( ) );
			SetDefaultConnectionFactory ( new MySqlConnectionFactory ( ) );
			SetMigrationSqlGenerator ( MySqlProviderInvariantName.ProviderName, () => new customMigrationSQLGenerator ( ) );
			SetManifestTokenResolver ( new MySqlManifestTokenResolver ( ) );
			SetHistoryContext ( MySqlProviderInvariantName.ProviderName,
				( existingConnection, defaultSchema ) => new customHistoryContext ( existingConnection, defaultSchema ) );
		}
	}

	/// <summary>
	/// Read and write the migration history of the database during the first code migrations. This class must be in the same assembly as the EF configuration
	/// </summary>
	public class customHistoryContext : HistoryContext
	{
		public customHistoryContext ( DbConnection existingConnection, string defaultSchema ) : base ( existingConnection, defaultSchema ) { }

		protected override void OnModelCreating ( System.Data.Entity.DbModelBuilder modelBuilder )
		{
			base.OnModelCreating ( modelBuilder );
			modelBuilder.Entity<HistoryRow> ( ).HasKey ( h => new { h.MigrationId } );
		}
	}

}
