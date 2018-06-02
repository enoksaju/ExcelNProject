using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContabilidadIntelisisRep_AddIn.Modelos {
	public class perdidaGananciaCambiaria {

		private const string SqlCxc = @"Select Clase='cxc' ,Clave=Cxc.Cliente,Nombre=Cte.Nombre,Tipo=Cte.Tipo,Grupo=Cte.Grupo,Familia=Cte.Familia,Categoria=Cte.Categoria,
Mov=Cxc.Mov,MovId=Cxc.Movid,FechaEmision=Cxc.FechaEmision,Vencimiento=Cxc.Vencimiento,Saldo=Sum(Isnull(aux.Cargo,0)-Isnull(aux.Abono,0)),
Moneda=Aux.moneda,TipoCambio=Cxc.ClienteTipoCambio,Cuenta=Cte.Cuenta,TipoCambioSAT= @TipoCambioSat,
Concepto= cxc.Concepto 
From Auxiliar aux Join MovTipo mt On aux.Aplica=mt.Mov And mt.Modulo='CXC' Join Cxc On aux.Empresa=Cxc.Empresa And aux.Sucursal=Cxc.Sucursal And aux.Aplica=Cxc.Mov And aux.AplicaId=Cxc.MovId And Cxc.Estatus in ('CONCLUIDO','PENDIENTE') Join Cte On Cxc.Cliente=Cte.Cliente 
Where aux.Rama='CXC' And mt.Clave in ('CXC.F','CXC.NC','CXC.A', 'CXC.FA','CXC.CAP') And mt.Mov<>'Retencion' 
And aux.Fecha<=@Fecha and Aux.Moneda=@Moneda
and ((@Tipo='Todos') or (@Tipo= 'Anticipos' and Cxc.Mov in ('Anticipo','Anticipo Electronico','Anticipo CFDi', 'Canc Dev Sdo Cte' )) or (@Tipo= 'SinAnticipos' and Cxc.Mov not in ('Anticipo','Anticipo Electronico','Anticipo CFDi', 'Canc Dev Sdo Cte' )))

Group by Cxc.Cliente,Cte.Nombre,Cte.Cuenta,Cte.Tipo,Cte.Grupo,Cte.Familia,Cte.Categoria,Cxc.Mov,Cxc.MovId,Cxc.FechaEmision,Cxc.Vencimiento,Aux.Moneda,Cxc.ClienteTipoCambio, cxc.Concepto
Having ((Sum(Isnull(aux.Cargo,0)-Isnull(aux.Abono,0)))< -0.01 or (Sum(Isnull(aux.Cargo,0)-Isnull(aux.Abono,0)))> 0.01) 
Order by Aux.Moneda,Cte.Nombre,Cxc.FechaEmision,Cxc.Mov,Cxc.MovId";

		private const string SqlCxp = @"Select Clase=Case When mt.Clave='CXP.A' Then 'Anticipos' Else 'Proveedores/Acreedores' End,Clave=Cxp.Proveedor,Nombre=Prov.Nombre,Tipo=Prov.Tipo,Grupo='cxp',Familia=Prov.Familia,Categoria=Prov.Categoria,Mov=Cxp.Mov,MovId=Cxp.Movid,FechaEmision=Cxp.FechaEmision,Vencimiento=Cxp.Vencimiento,Saldo=Sum(Isnull(aux.Cargo,0)-Isnull(aux.Abono,0)),Moneda=Aux.moneda,TipoCambio=Cxp.ProveedorTipoCambio,Cuenta=Prov.Cuenta,TipoCambioSAT= @TipoCambioSat,Concepto= cxp.Concepto 
From Auxiliar aux Join MovTipo mt On aux.Aplica=mt.Mov And mt.Modulo='CXP' Join Cxp On Aux.Empresa=Cxp.Empresa And Cxp.Sucursal=aux.Sucursal And Cxp.Mov=aux.Aplica And Cxp.MovId=aux.AplicaId And Cxp.Estatus in ('CONCLUIDO','PENDIENTE') Join Prov On Cxp.Proveedor=Prov.Proveedor 
Where aux.Rama='CXP' And mt.Clave in ('CXP.F','CXP.NC','CXP.A','CXP.CAP') And mt.Mov<>'Retencion' 
And aux.Fecha<=@Fecha and Aux.Moneda=@Moneda
and ((@Tipo='Todos') or (@Tipo= 'Anticipos' and Cxp.Mov in ('Anticipo','Anticipo Electronico','Anticipo CFDi' )) or (@Tipo= 'SinAnticipos' and Cxp.Mov not in ('Anticipo','Anticipo Electronico','Anticipo CFDi' )))
Group by Cxp.Proveedor,Prov.Nombre, Prov.Cuenta,Prov.Tipo,Prov.Categoria, Prov.Familia,mt.Clave,Cxp.Mov,Cxp.MovId,Cxp.FechaEmision,Cxp.Vencimiento,Aux.Moneda,Cxp.ProveedorTipoCambio, cxp.Concepto 
Having ((Sum(Isnull(aux.Cargo,0)-Isnull(aux.Abono,0)))< -0.01 or (Sum(Isnull(aux.Cargo,0)-Isnull(aux.Abono,0)))> 0.01) 
Order by mt.Clave, Aux.Moneda,1,Prov.Categoria,Prov.Nombre,Cxp.FechaEmision,Cxp.Mov,Cxp.MovId";


		public string Clase { get; set; }
		public string Clave { get; set; }
		public string Nombre { get; set; }
		public string Tipo { get; set; }
		public string Grupo { get; set; }
		public string Familia { get; set; }
		public string Categoria { get; set; }
		public string Mov { get; set; }
		public string MovId { get; set; }
		public DateTime FechaEmision { get; set; }
		public DateTime Vencimiento { get; set; }
		public decimal Saldo { get; set; }
		public string Moneda { get; set; }
		public double TipoCambio { get; set; }
		public string Cuenta { get; set; }
		public double TipoCambioSat { get; set; }
		public string Concepto { get; set; }


		public double SaldoPesos { get { return TipoCambio * ( double ) Saldo; } }
		public double SaldoPesosTCSAT { get { return TipoCambioSat * ( double ) Saldo; } }
		public double Diferencia { get { return SaldoPesosTCSAT - SaldoPesos; } }


		public static async Task<List<perdidaGananciaCambiaria>> getCxcAsync ( DateTime Fecha , double TipoCambio , string Moneda , Tipos Tipo , Empresas Empresa) {


			try {
				using ( var DB = new Context.dataBaseContext ( ) ) {
					var y = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder ( DB.Database.Connection.ConnectionString );
					y.Database = Empresa.ToString ( );
					DB.Database.Connection.ConnectionString = y.ConnectionString;
					DB.Database.CommandTimeout = 240;
					return await DB.Database.SqlQuery<perdidaGananciaCambiaria> ( SqlCxc , new SqlParameter ( "@Fecha" , Fecha ) , new SqlParameter ( "@TipoCambioSat" , TipoCambio ) , new SqlParameter ( "@Moneda" , Moneda ) , new SqlParameter ( "@Tipo" , Tipo.ToString ( ) ) ).ToListAsync ( );
				}
			} catch ( Exception ex ) {

				MessageBox.Show ( ex.Message );
				return null;
			}


		}
		public static async Task<List<perdidaGananciaCambiaria>> getCxpAsync ( DateTime Fecha , double TipoCambio , string Moneda , Tipos Tipo, Empresas Empresa ) {
			try {
				using ( var DB = new Context.dataBaseContext ( ) ) {
					var y = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder ( DB.Database.Connection.ConnectionString );
					y.Database = Empresa.ToString ( );
					DB.Database.Connection.ConnectionString = y.ConnectionString;
					DB.Database.CommandTimeout = 240;
					return await DB.Database.SqlQuery<perdidaGananciaCambiaria> ( SqlCxp , new SqlParameter ( "@Fecha" , Fecha ) , new SqlParameter ( "@TipoCambioSat" , TipoCambio ) , new SqlParameter ( "@Moneda" , Moneda ) , new SqlParameter ( "@Tipo" , Tipo.ToString ( ) ) ).ToListAsync ( );
				}
			} catch ( Exception ex ) {

				MessageBox.Show ( ex.Message );
				return null;
			}
		}

	}
}
