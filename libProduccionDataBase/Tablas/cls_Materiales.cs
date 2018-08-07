using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace libProduccionDataBase.Tablas
{
	[Table ( "FamiliasMaterial" )]
	public class FamiliaMateriales
	{
		private ObservableListSource<Material> _Materiales = new ObservableListSource<Material> ( );
		public int Id { get; set; }
		[MaxLength ( 250 )]
		public string NombreFamilia { get; set; }
		public ObservableListSource<Material> Materiales => _Materiales;
		public virtual ObservableListSource<MovimientoPrecio> Movimientos { get; set; }
		public override string ToString () => this.NombreFamilia;
	}
	[Table ( "MovPrec_Fam_Mat" )]
	public class MovimientoPrecio
	{
		[Key]
		public int MovimientoPrecioId { get; set; }
		public int FamiliaId { get; set; }
		[Required]
		public double Valor { get; set; }
		[Required]
		public DateTime FechaRegistro { get; set; }
		[Required]
		public DateTime FechaOperacion { get; set; }
	}

	[Table ( "Material" )]
	public class Material
	{
		public enum UnidadesMaterial { Micras, CI }
		public int Id { get; set; }

		[ForeignKey ( "Familia" )]
		public int FamiliaMateriales_Id { get; set; }
		[Required]
		public string Apariencia { get; set; }
		public string Caracteristicas { get; set; }
		public UnidadesMaterial Unidad { get; set; }
		[Required]
		public double FactorDensidad { get; set; }
		[Required]
		public double PrecioInicial { get; set; }
		[Required]
		public double CostoInicial { get; set; }
		public bool? Metalizado { get; set; }
		public bool? Convenio { get; set; }

		[Required]
		public DateTime FechaRegistro { get; set; }

		[Required]
		public DateTime FechaOperacion { get; set; }

		public virtual ObservableListSource<Calibre> Calibres { get; set; }
		public virtual FamiliaMateriales Familia { get; set; }
		
		public double IncrementoDecremento
		{
			get
			{
				try
				{
					double inc = 0;
					if ( this.Familia != null )
					{
						inc = ( from prec in this.Familia.Movimientos
								where prec.FechaOperacion >= this.FechaOperacion
								select prec.Valor ).Sum ( );
					}
					return inc;
				}
				catch
				{
					return 0;
				}
				
			}
		}

		public double PrecioActual => this.PrecioInicial + this.IncrementoDecremento;
		public double CostoActual => this.CostoInicial + this.IncrementoDecremento;

		public string NombreFamilia => this.Familia == null ? "" : this.Familia.ToString ( );
		public override string ToString () => this.NombreFamilia + this.Apariencia + this.Caracteristicas;
	}

	[Table ( "mat_calibres" )]
	public class Calibre
	{
		[Key, Column ( Order = 0 )]
		public int MaterialId { get; set; }
		[Key, Column ( Order = 1 )]
		public int Valor { get; set; }
	}
}
