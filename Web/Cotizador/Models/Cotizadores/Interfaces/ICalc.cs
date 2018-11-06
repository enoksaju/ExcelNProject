using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cotizador.Models.Cotizadores;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas.Cotizador;

namespace Cotizador.Models.Cotizadores.Interfaces
{
	public interface ICalc
	{
		int? Id { get; set; }
		libProduccionDataBase.Tablas.Cotizador.ProductosPedidos Tipo_Producto_Id { get; set; }
		string NombreProducto { get; }
		double Cantidad { get; set; }
		UnidadesPedido UnidadPedido { get; set; }
		string Descripcion { get; }

		DateTime FechaCreacion { get; set; }

		double AnchoDiseño { get; }
		double AltoDiseño { get; }

		double Cotizamos { get; set; }

		int RepDes { get; }
		int RepEje { get; }

		libProduccionDataBase.Tablas.Material MaterialBase { get; }
		double CalibreMaterialBase { get; }
		libProduccionDataBase.Tablas.Material MaterialLaminacion { get; }
		double CalibreMaterialLaminacion { get; }
		libProduccionDataBase.Tablas.Material MaterialTrilaminacion { get; }
		double CalibreMaterialTrilaminacion { get; }
		libProduccionDataBase.Tablas.Material MaterialTretralaminacion { get; }
		double CalibreMaterialTretralaminacion { get; }

		IResultados Resultados { get; }
		CotizacionDetalle toCotizacionDetalle ( libProduccionDataBase.Contexto.DataBaseContexto Contexto );
		CotizacionDetalle toCotizacionDetalle ();
		ICalcType fromCotizacionDetalle<ICalcType> ( DataBaseContexto Contexto, int Id ) where ICalcType : ICalc;
	}
}
