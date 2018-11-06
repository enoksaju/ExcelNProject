using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libProduccionDataBase.Tablas.Cotizador
{
	public class PeliculaSinImpresion : CotizacionDetalle
	{
		public override IResultadosCotizacion Resultados { get; }
		public PeliculaSinImpresion ( Material material, double Calibre, double Ancho, double Cantidad )
		{
			this.AnchoDiseño = Ancho;
			this.Tipo = TiposProductosCotizacion.PeliculaSinImpresion;
			this.Cantidad = Cantidad;
			this.Peliculas.Add ( new Pelicula ( Pelicula.Usos.Base, material, Calibre ) );
			Resultados = new ResultadosCotizacion ( this );
		}
		public PeliculaSinImpresion ( int material_Id, double Calibre, double Ancho, double Cantidad )
		{
			this.AnchoDiseño = Ancho;
			this.Tipo = TiposProductosCotizacion.PeliculaSinImpresion;
			this.Cantidad = Cantidad;
			this.Peliculas.Add ( new Pelicula ( Pelicula.Usos.Base, material_Id, Calibre ) );
			Resultados = new ResultadosCotizacion ( this );
		}

		public class ResultadosCotizacion : ResultadosCotizacionBase<PeliculaSinImpresion>, IResultadosCotizacion
		{
			const double CM_DESPERDICIO = 3;
			const double PRECIO_REFINADO = 1.5;
			const double COSTO_REFINADO = PRECIO_REFINADO / 2;
			public ResultadosCotizacion ( PeliculaSinImpresion parent ) : base ( parent, new ResultadosKg ( parent ), new ResultadosBasicosKg ( parent ) ) { }
			public override double ComisionEquivalente => ComisionKg / getRealCotizamos;
			public override double ComisionKg => (
				getRealCotizamos -
				( zResumenBasico_Kg.CostoTotal + ( zResumenBasico_Kg.CostoTotal * ( CM_DESPERDICIO / parent.AnchoDiseño ) ) + COSTO_REFINADO ) //CostoTotalBasico
				) * 0.08;
			public override double ComisionTotal => this.ComisionKg * (double)parent.Cantidad;
			public override double PrecioMillar => 0;
			public override double PrecioObjetivo => PrecioUltimo * 1.05;
			public override double PrecioUltimo => this.Resumen_Kg.CostoTotal + ( this.Resumen_Kg.CostoTotal * ( CM_DESPERDICIO / parent.AnchoDiseño ) ) + PRECIO_REFINADO;

		}

		public class ResultadosKg : ResultadosResumenBaseKg, IResultadosResumen
		{
			protected PeliculaSinImpresion parent;
			public ResultadosKg ( PeliculaSinImpresion parent ) : base ( 0 )
			{
				this.parent = parent;
			}
			public override double CostoArranque => 0;
			public override double CostoPelicula => parent.Peliculas.FirstOrDefault ( i => i.Uso == Pelicula.Usos.Base ).Material.PrecioAFecha ( parent.FechaCotizacion );
			public override double CostoSolvente => 0;
			public override double CostoSticky => 0;
			public override double CostoTinta => 0;
			public override double PMaqu => 0;
			public override double TintaResidual => 0;
		}

		public class ResultadosBasicosKg : ResultadosKg, IResultadosResumen
		{
			public ResultadosBasicosKg ( PeliculaSinImpresion parent ) : base ( parent )
			{
				this.parent = parent;
			}
			public override double CostoPelicula => parent.Peliculas.FirstOrDefault ( i => i.Uso == Pelicula.Usos.Base ).Material.CostoAFecha ( parent.FechaCotizacion );
		}
	}
}
