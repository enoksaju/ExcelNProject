using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Identity;
using System.Data.Entity;

namespace libProduccionDataBase.Tablas.Cotizador
{
	public enum UnidadesPedido
	{
		Kg,
		Millares,
		Piezas
	}

	public enum ProductosPedidos
	{
		PeliculaSinImpresion
	}

	[Table ( "cotizaciones" )]
	public class Cotizacion
	{
		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		public int CotizacionId { get; set; }

		[ForeignKey ( "Cliente" )]
		public int ClienteId { get; set; }
		[ForeignKey ( "Agente" )]
		public int AgenteId { get; set; }
		public int DiasVigencia { get; set; }
		public virtual Cliente Cliente { get; set; }
		public virtual ApplicationUser Agente { get; set; }
		public DateTime FechaCreacion { get; set; } = DateTime.Now.Date;
		public virtual ObservableListSource<CotizacionDetalle> Items { get; set; } = new ObservableListSource<CotizacionDetalle> ( );

		public Cotizacion ()
		{
			Items.CollectionChanged += Items_CollectionChanged;
		}

		private void Items_CollectionChanged ( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e )
		{
			foreach ( var itm in Items )
			{
				itm.FechaCotizacion = this.FechaCreacion;
			}
		}
	}

	[Table ( "cotizaciones_detalle" )]
	public abstract class CotizacionDetalle
	{
		public DateTime FechaCotizacion;
		public enum TiposProductosCotizacion
		{
			PeliculaSinImpresion
		}
		public enum unidadesCotizaion
		{
			Kg, Millares
		}

		[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
		public int CotizacionDetalleId { get; set; }
		[Required, Range ( 0, double.MaxValue, ErrorMessage = "EL valor debe ser positivo" )]
		public double? Cantidad { get; set; }
		public unidadesCotizaion Unidad { get; set; }
		public double? Cotizamos { get; set; } = 0;
		[Required]
		public virtual TiposProductosCotizacion Tipo { get; set; }
		public virtual ObservableListSource<Pelicula> Peliculas { get; set; } = new ObservableListSource<Pelicula> ( );
		public virtual ObservableListSource<Decks> Decks { get; set; } = new ObservableListSource<Decks> ( );

		#region Impresora

		[ForeignKey ( "Impresora" )]
		public int? Maquina_Id { get; set; }
		public virtual Maquina Impresora { get; set; }

		[ForeignKey ( "Rodillo" )]
		public int? Rodillo_Id { get; set; }
		public virtual Rodillo Rodillo { get; set; }
		#endregion

		#region Diseño
		[Column ( "AnchoDisenio" )]
		public double AnchoDiseño { get; set; }
		[Column ( "AltoDisenio" )]
		public double? AltoDiseño { get; set; }
		public double RepeticionesEje { get; set; } = 1;
		public double? RepeticionesDesarrollo { get; set; }
		[Required]
		public string NombreProducto { get; set; }
		#endregion

		[NotMapped]
		public abstract IResultadosCotizacion Resultados { get; }
	}

	[Table ( "cotizaciones_detalle_peliculas" )]
	public class Pelicula
	{
		public enum Usos
		{
			Base,
			Laminacion,
			Trilaminacion,
			Tetralaminacion
		}

		[Key, Column ( Order = 1 )]
		public int CotizacionDetalleId { get; set; }

		[EnumDataType ( typeof ( Usos ) )]
		[Key, Column ( Order = 2 )]
		public Usos Uso { get; set; }

		[ForeignKey ( "Material" )]
		[Required]
		public int? Material_Id { get; set; }

		public virtual Material Material { get; set; }

		[Required]
		public double? Calibre { get; set; }

		[NotMapped]
		public double? pesoM2 => this.Calibre * this.Material.FactorDensidad;
		public Pelicula ( Usos Uso, int Material_Id, double Calibre )
		{
			try
			{
				using ( libProduccionDataBase.Contexto.DataBaseContexto DB = new Contexto.DataBaseContexto ( ) )
				{
					DB.Configuration.LazyLoadingEnabled = false;
#if DEBUG
					DB.Database.Log = ( string a ) => { System.Diagnostics.Debug.Write ( a ); };
#endif

					if ( !DB.Materiales.Any ( y => y.Id == Material_Id ) ) throw new Exception ( "Material no encontrado" );
					libProduccionDataBase.Tablas.Material mat = DB.Materiales
						.Include ( m => m.Familia.Movimientos ).Include ( m => m.Calibres )
						.FirstOrDefault ( y => y.Id == Material_Id );


					this.Material = mat;
					this.Uso = Uso;
					this.Material_Id = Material_Id;
					this.Calibre = Calibre;
				}
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}
		public Pelicula ( Usos Uso, Material Material, double Calibre )
		{
			try
			{
				using ( libProduccionDataBase.Contexto.DataBaseContexto DB = new Contexto.DataBaseContexto ( ) )
				{
					DB.Configuration.LazyLoadingEnabled = false;
#if DEBUG
					DB.Database.Log = ( string a ) => { System.Diagnostics.Debug.Write ( a ); };
#endif
					if ( !DB.Materiales.Any ( y => y.Id == Material.Id ) ) throw new Exception ( "Material no encontrado" );
					libProduccionDataBase.Tablas.Material mat = DB.Materiales
						.Include ( m => m.Familia.Movimientos ).Include ( m => m.Calibres )
						.FirstOrDefault ( y => y.Id == Material.Id );

					this.Material = mat;
					this.Uso = Uso;
					this.Material_Id = Material_Id;
					this.Calibre = Calibre;
				}
			}
			catch ( Exception ex )
			{
				throw ex;
			}

		}
	}

	[Table ( "cotizaciones_detalle_decks" )]
	public class Decks
	{
		public enum DecksDiponibles
		{
			unidad1 = 1,
			unidad2,
			unidad3,
			unidad4,
			unidad5,
			unidad6,
			unidad7,
			unidad8,
			unidad9,
			unidad10
		}
		[Key, Column ( Order = 1 )]
		public int CotizacionDetalleId { get; set; }

		[Key, Column ( Order = 2 )]
		public DecksDiponibles Deck { get; set; }

		[Required]
		[ForeignKey ( "Tinta" )]
		public int? TintaId { get; set; }
		public virtual Tinta Tinta { get; set; }
		public double PorcentajeCobertura { get; set; }
		public double GR_MT { get; set; } = 1;
		public double PORC_SOLID { get; set; } = 0.33;
		public string Color { get; set; } = "Sin Asignar";

		[NotMapped]
		public double PrecioTinta => Tinta.Precio;
		[NotMapped]
		public double CostoAplicacion => PrecioTinta * PorcentajeCobertura * GR_MT / PORC_SOLID / 1000;


		Decks ( int TintaId, DecksDiponibles Deck, double porcCobertura = 0.05 )
		{
			try
			{
				using ( libProduccionDataBase.Contexto.DataBaseContexto DB = new Contexto.DataBaseContexto ( ) )
				{
					if ( !DB.Tintas.Any ( y => y.TintaId == TintaId ) ) throw new Exception ( "Tinta no encontrada" );

					initialiceDecks ( DB.Tintas.FirstOrDefault ( y => y.TintaId == TintaId ), Deck, porcCobertura );
				}
			}
			catch ( Exception ex )
			{
				throw ex;
			}
		}

		Decks ( Tinta Tinta, DecksDiponibles Deck, double porcCobertura = 0.05 )
		{
			initialiceDecks ( Tinta, Deck, porcCobertura );
		}

		private void initialiceDecks ( Tinta Tinta, DecksDiponibles Deck, double porcCobertura )
		{
			this.Tinta = Tinta;
			this.Deck = Deck;
		}
	}

	public interface IResultadosResumen
	{
		double CostoPelicula { get; }
		double CostoArranque { get; }
		double CostoTinta { get; }
		double CostoSolvente { get; }
		double TintaResidual { get; }
		double PMaqu { get; }
		double CostoDesperdicio { get; }
		double CostoSticky { get; }
		double CostoTotal { get; }
	}

	public class ResultadosResumenM2 : IResultadosResumen
	{
		private IResultadosResumen Res;
		private double gt_mt;
		public ResultadosResumenM2 ( IResultadosResumen ResultadosKg, double gt_mt )
		{
			this.Res = ResultadosKg;
			this.gt_mt = gt_mt;
		}

		public double CostoPelicula => Res.CostoPelicula / 1000 * gt_mt;
		public double CostoArranque => Res.CostoArranque / 1000 * gt_mt;
		public double CostoTinta => Res.CostoTinta / 1000 * gt_mt;
		public double CostoSolvente => Res.CostoSolvente / 1000 * gt_mt;
		public double TintaResidual => Res.TintaResidual / 1000 * gt_mt;
		public double PMaqu => Res.PMaqu / 1000 * gt_mt;
		public double CostoDesperdicio => Res.CostoDesperdicio / 1000 * gt_mt;
		public double CostoSticky => Res.CostoSticky / 1000 * gt_mt;
		public double CostoTotal => Res.CostoTotal / 1000 * gt_mt;
	}

	public abstract class ResultadosResumenBaseKg : IResultadosResumen
	{
		private double PorcDesperdicio = 0.02;
		public abstract double CostoPelicula { get; }
		public abstract double CostoArranque { get; }
		public abstract double CostoTinta { get; }
		public abstract double CostoSolvente { get; }
		public abstract double TintaResidual { get; }
		public abstract double PMaqu { get; }
		public virtual double CostoDesperdicio => ( CostoPelicula + CostoArranque + CostoTinta + CostoSolvente + TintaResidual + PMaqu ) * PorcDesperdicio;
		public abstract double CostoSticky { get; }
		public virtual double CostoTotal => CostoPelicula + CostoArranque + CostoTinta + CostoSolvente + TintaResidual + PMaqu + CostoDesperdicio + CostoSticky;

		public ResultadosResumenBaseKg ( double PorcDesperdicio = 0.02 )
		{
			this.PorcDesperdicio = PorcDesperdicio;
		}
	}

	public interface IResultadosCotizacion
	{
		IResultadosResumen ResumenM2 { get; }
		IResultadosResumen Resumen_Kg { get; }
		IResultadosResumen zResumenBasico_Kg { get; }
		IResultadosResumen zResumenBasicoM2 { get; }

		double PrecioUltimo { get; }
		double PrecioObjetivo { get; }
		double PrecioMillar { get; }
		double ComisionKg { get; }
		double ComisionTotal { get; }
		double ComisionEquivalente { get; }
		string GetResumen ();
	}

	public abstract class ResultadosCotizacionBase<T> : IResultadosCotizacion
		where T : CotizacionDetalle

	{
		protected T parent;
		protected double getRealCotizamos => ( (double)parent.Cotizamos > 0 ? (double)parent.Cotizamos : PrecioObjetivo );

		public ResultadosCotizacionBase ( T parent, IResultadosResumen ResultKg, IResultadosResumen ResultBasicosKg )
		{
			this.parent = parent;
			this.Resumen_Kg = ResultKg;
			this.ResumenM2 = new ResultadosResumenM2 ( this.Resumen_Kg, this.pesoM2 );
			this.zResumenBasico_Kg = ResultBasicosKg;
			this.zResumenBasicoM2 = new ResultadosResumenM2 ( this.zResumenBasico_Kg, this.pesoM2 );
		}

		public virtual double pesoM2 => (double)this.parent.Peliculas[ 0 ].pesoM2 + grTinta;
		public virtual double grTinta => (double)this.parent.Decks.Sum ( y => y.PorcentajeCobertura );
		public abstract double ComisionEquivalente { get; }
		public abstract double ComisionKg { get; }
		public abstract double ComisionTotal { get; }
		public abstract double PrecioMillar { get; }
		public virtual double PrecioObjetivo => this.PrecioUltimo * 1.05;
		public abstract double PrecioUltimo { get; }
		public virtual IResultadosResumen ResumenM2 { get; protected set; }
		public virtual IResultadosResumen Resumen_Kg { get; protected set; }
		public virtual IResultadosResumen zResumenBasicoM2 { get; protected set; }
		public virtual IResultadosResumen zResumenBasico_Kg { get; protected set; }
		public virtual string GetResumen ()
		{
			StringBuilder st = new StringBuilder ( );
			st.AppendFormat ( "\n {0} RESUMEN {0}░", new string ( '░', 31 ) );
			st.AppendFormat ( "\n ┌{0}{0}{0}┬{0}{0}┬{0}{0}┬{0}{0}┬{0}{0}┐", new string ( '─', 6 ) );

			st.Append ( $"\n │{" ",18}│{ "M2     ",12}│{ "Kg     ",12}│{ "Bas M2   ",12}│{ "Bas Kg   ",12}│" );
			st.Append ( $"\n ├{new string ( '─', 18 ),18}┼{ new string ( '─', 12 ),12}┼{ new string ( '─', 12 ),12}┼{ new string ( '─', 12 ),12}┼{ new string ( '─', 12 ),12}┤" );

			st.Append ( $"\n │{"Costo Pelicula",18}│{ this.ResumenM2.CostoPelicula,12:N3}│{ this.Resumen_Kg.CostoPelicula,12:N3}│{ this.zResumenBasicoM2.CostoPelicula,12:N3}│{ this.zResumenBasico_Kg.CostoPelicula,12:N3}│" );
			st.Append ( $"\n │{"Costo Arranque",18}│{ this.ResumenM2.CostoArranque,12:N3}│{ this.Resumen_Kg.CostoArranque,12:N3}│{ this.zResumenBasicoM2.CostoArranque,12:N3}│{ this.zResumenBasico_Kg.CostoArranque,12:N3}│" );
			st.Append ( $"\n │{"Costo Tinta",18}│{ this.ResumenM2.CostoTinta,12:N3}│{ this.Resumen_Kg.CostoTinta,12:N3}│{ this.zResumenBasicoM2.CostoTinta,12:N3}│{ this.zResumenBasico_Kg.CostoTinta,12:N3}│" );
			st.Append ( $"\n │{"Costo Solvente",18}│{ this.ResumenM2.CostoSolvente,12:N3}│{ this.Resumen_Kg.CostoSolvente,12:N3}│{ this.zResumenBasicoM2.CostoSolvente,12:N3}│{ this.zResumenBasico_Kg.CostoSolvente,12:N3}│" );
			st.Append ( $"\n │{"Tinta Residual",18}│{ this.ResumenM2.TintaResidual,12:N3}│{ this.Resumen_Kg.TintaResidual,12:N3}│{ this.zResumenBasicoM2.TintaResidual,12:N3}│{ this.zResumenBasico_Kg.TintaResidual,12:N3}│" );
			st.Append ( $"\n │{"P Maq",18}│{ this.ResumenM2.PMaqu,12:N3}│{ this.Resumen_Kg.PMaqu,12:N3}│{ this.zResumenBasicoM2.PMaqu,12:N3}│{ this.zResumenBasico_Kg.PMaqu,12:N3}│" );
			st.Append ( $"\n │{"Costo Desperdicio",18}│{ this.ResumenM2.CostoDesperdicio,12:N3}│{ this.Resumen_Kg.CostoDesperdicio,12:N3}│{ this.zResumenBasicoM2.CostoDesperdicio,12:N3}│{ this.zResumenBasico_Kg.CostoDesperdicio,12:N3}│" );
			st.Append ( $"\n │{"Costo Stiky",18}│{ this.ResumenM2.CostoSticky,12:N3}│{ this.Resumen_Kg.CostoSticky,12:N3}│{ this.zResumenBasicoM2.CostoSticky,12:N3}│{ this.zResumenBasico_Kg.CostoSticky,12:N3}│" );
			st.Append ( $"\n │{"Costo Total",18}│{ this.ResumenM2.CostoTotal,12:N3}│{ this.Resumen_Kg.CostoTotal,12:N3}│{ this.zResumenBasicoM2.CostoTotal,12:N3}│{ this.zResumenBasico_Kg.CostoTotal,12:N3}│" );
			st.AppendFormat ( "\n └{0}{0}{0}┴{0}{0}┴{0}{0}┴{0}{0}┴{0}{0}┘", new string ( '─', 6 ) );
			return st.ToString ( );
		}
	}

}
