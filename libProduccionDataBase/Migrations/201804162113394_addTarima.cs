//namespace libProduccionDataBase.Migrations {
//	using System;
//	using System.Data.Entity.Migrations;

//	public partial class addTarima : DbMigration {
//		public override void Up ( ) {
//			CreateTable (
//				"dbo.ncuatro_tarimas" ,
//				c => new {
//					Id = c.Int ( nullable: false , identity: true ) ,
//					FechaCaptura = c.DateTime ( nullable: false , precision: 0 ) ,
//					FechaExtrusion = c.DateTime ( nullable: false , precision: 0 ) ,
//					Usuario = c.String ( unicode: false ) ,
//					Ancho = c.Double ( nullable: false ) ,
//					Calibre = c.Double ( nullable: false ) ,
//					OT = c.String ( nullable: false , maxLength: 128 , storeType: "nvarchar" ) ,
//				} )
//				.PrimaryKey ( t => t.Id )
//				.ForeignKey ( "dbo.TORDENTRABAJO" , t => t.OT , cascadeDelete: true )
//				.Index ( t => t.OT );

//			CreateTable (
//				"dbo.ncuatro_tarimas_items" ,
//				c => new {
//					Id = c.Int ( nullable: false , identity: true ) ,
//					Item_Id = c.Int ( nullable: false ) ,
//					Tarima_Id = c.Int ( nullable: false ) ,
//				} )
//				.PrimaryKey ( t => t.Id )
//				.ForeignKey ( "dbo.TPRODUCCION" , t => t.Item_Id , cascadeDelete: true )
//				.ForeignKey ( "dbo.ncuatro_tarimas" , t => t.Tarima_Id , cascadeDelete: true )
//				.Index ( t => t.Item_Id )
//				.Index ( t => t.Tarima_Id );

//		}

//		public override void Down ( ) {
//			DropForeignKey ( "dbo.ncuatro_tarimas" , "OT" , "dbo.TORDENTRABAJO" );
//			DropForeignKey ( "dbo.ncuatro_tarimas_items" , "Tarima_Id" , "dbo.ncuatro_tarimas" );
//			DropForeignKey ( "dbo.ncuatro_tarimas_items" , "Item_Id" , "dbo.TPRODUCCION" );
//			DropIndex ( "dbo.ncuatro_tarimas_items" , new [ ] { "Tarima_Id" } );
//			DropIndex ( "dbo.ncuatro_tarimas_items" , new [ ] { "Item_Id" } );
//			DropIndex ( "dbo.ncuatro_tarimas" , new [ ] { "OT" } );
//			DropTable ( "dbo.ncuatro_tarimas_items" );
//			DropTable ( "dbo.ncuatro_tarimas" );
//		}
//	}
//}
