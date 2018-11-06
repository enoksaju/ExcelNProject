using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cotizador.Models.Cotizadores.Interfaces;
using libProduccionDataBase.Contexto;
using libProduccionDataBase.Tablas;
using libProduccionDataBase.Tablas.Cotizador;

namespace Cotizador.Models.Cotizadores
{
	public class PeliculaSinImpresion : CotizadorBase<ResultadosPeliculaSinImpresion>, ICalc
	{
		public const double CM_DESP = 3;
		public const double PRECIO_REFINADO = 1;
		public const double COSTO_REFINADO = 0.5;

		public override string Descripcion => String.Format(
			@"
{0}
	• Cantidad:      {1,10:N2} Kg
	• Precio por Kg: {2,10:C2}	
", 
			$"{NombreProducto.ToUpper()}, {MaterialBase.NombreFamilia.ToUpper()} {MaterialBase.Apariencia.ToUpper()} {MaterialBase.Caracteristicas.ToUpper()} CALIBRE {this.CalibreMaterialBase, 3:N2} Um SIN IMPRESIÓN, CON {AnchoDiseño, 4:N2} cm. DE ANCHO.",
			this.Cantidad,
			this.Cotizamos);

		public override ICalcType fromCotizacionDetalle<ICalcType> ( DataBaseContexto Contexto, int Id )
		{
			throw new NotImplementedException ( );
		}
		public override CotizacionDetalle toCotizacionDetalle ( DataBaseContexto Contexto )
		{
			throw new NotImplementedException ( );
		}
		public override CotizacionDetalle toCotizacionDetalle ()
		{
			return new CotizacionDetalle ( )
			{
				Cantidad = this.Cantidad,
				CalibreMaterialBase = this.CalibreMaterialBase,
				TipoProducto = ProductosPedidos.PeliculaSinImpresion,
				MaterialBase = this.MaterialBase,
				UnidadPedido = this.UnidadPedido,
				NombreProducto = this.NombreProducto,
				AnchoDiseño = this.AnchoDiseño
			};
		}
	}

	public class ResultadosPeliculaSinImpresion : ResultadosBase<PeliculaSinImpresion>, IResultados
	{
		public override double Comision_Equivalente => Comision_Kg / Parent.Cotizamos;

		public override double Comision_Kg => ( Parent.Cotizamos - CostoReal_Total ) * 0.08;

		public override double Comision_Total => Comision_Kg * Parent.Cantidad;

		public override double CostoReal_Desperdicio => PorcentDesperdicio * ( Parent.MaterialBase.PrecioAFecha ( Parent.FechaCreacion ) - 5 );

		public override double CostoReal_Total => ( Parent.MaterialBase.PrecioAFecha ( Parent.FechaCreacion ) - 5 ) + CostoReal_Desperdicio + PeliculaSinImpresion.COSTO_REFINADO;

		public override double PorcentDesperdicio => PeliculaSinImpresion.CM_DESP / Parent.AnchoDiseño;

		public override double PrecioDesperdicio => PorcentDesperdicio * Parent.MaterialBase.PrecioAFecha ( Parent.FechaCreacion );

		public override double PrecioObjetivo => PrecioUltimo * 1.05;

		public override double PrecioUltimo => Parent.MaterialBase.PrecioAFecha ( Parent.FechaCreacion ) + PrecioDesperdicio + PeliculaSinImpresion.PRECIO_REFINADO;
	}


}