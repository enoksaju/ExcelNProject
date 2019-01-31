using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioControlTry.Models
{
	//public class Almacen
	//{
	//	[Column ( "almacen" ), Key]
	//	public string AlmacenId { get; set; }
	//	public string Descripcion { get; set; }
	//	public virtual ICollection<Movimiento> Movimientos { get; set; }
	//	public Almacen ()
	//	{
	//		Movimientos = new HashSet<Movimiento> ( );
	//	}
	//}
	//public abstract class Movimiento
	//{
	//	public enum UnidadMovimiento { Kg, Millares, Piezas }
	//	[Key, DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
	//	public int MovimientoId { get; set; }
	//	public DateTime FechaGenerado { get; set; }
	//	public DateTime FechaConcluido { get; set; }
	//	public string Usuario { get; set; }
	//	public string Terminal { get; set; }

	//	[Column ( "alm_origen" ), ForeignKey ( "AlmacenOrigen" )]
	//	public string AlmacenOrigenId { get; set; }
	//	[Column ( "alm_destino" ), ForeignKey ( "AlmacenDestino" )]
	//	public string AlamcenDestinoId { get; set; }

	//	[Column ( "cantidad" )]
	//	public double Cantidad { get; set; }

	//	[NotMapped]
	//	public UnidadMovimiento Unidad { get; set; }
	//	[Column ( "unidad" )]
	//	public string UnidadString
	//	{
	//		get
	//		{
	//			return Unidad.ToString ( );
	//		}
	//		private set
	//		{
	//			UnidadMovimiento unit;
	//			if ( Enum.TryParse ( value, out unit ) )
	//			{
	//				Unidad = unit;
	//			}
	//			else
	//			{
	//				Unidad = UnidadMovimiento.Kg;
	//			}
	//		}
	//	}

	//	public double Factor { get; set; }

	//	#region Navigation Properties
	//	public virtual Almacen AlmacenOrigen { get; set; }
	//	public virtual Almacen AlmacenDestino { get; set; }
	//	#endregion

	//}

	//public class Entrada : Movimiento
	//{
	//	public DateTime FechaEntrada { get; set; }
	//	[Column("ubicacion_destino"), MaxLength (128)]
	//	public string Ubicacion { get; set; }
	//}

	//public class Transferencia : Movimiento
	//{
	//	[Column ( "ubicacion_origen" ), MaxLength ( 128 )]
	//	public string UbicacionOrigen { get; set; }
	//	[Column ( "ubicacion_destino" ), MaxLength ( 128 )]
	//	public string UbicacionDestino { get; set; }
	//}

	public class MPEstructura
	{
		public string Code { get; set; }
		public double Gramaje { get; set; }
		public double Porcentaje { get; set; }
		public MPEstructura ( string Code, double Gramaje, double Porcentaje )
		{
			this.Code = Code;
			this.Gramaje = Gramaje;
			this.Porcentaje = Porcentaje;
		}
	}



	[Table ( "rolls" )]
	public abstract class Rollo
	{
		public int RolloId { get; set; }
		[Required, Index ( IsUnique = false ), MaxLength ( 128 )]
		public string OT { get; set; }
		public DateTime FechaRegistro { get; set; }

		[NotMapped]
		public string RollType { get; set; }

		[Column ( "add_g" )]
		public double gramajeToAdd { get; set; }

		[InverseProperty ( "Rollo" )]
		public virtual ICollection<OrigenRollo> Origen { get; private set; }
		[NotMapped]
		public virtual Rollo[] RollosOrigenList
		{
			get
			{
				return this.Origen.Select ( u => u.RolloOrigen ).ToArray ( );
			}
		}

		[NotMapped]
		public virtual MPEstructura[] Estructura
		{
			get
			{
				return getEstructura ( this ).ToArray ( );
			}
		}



		private List<MPEstructura> getEstructura ( Rollo roll, bool inicial = true )
		{
			List<MPEstructura> toRet = new List<MPEstructura> ( );
			Action<Rollo, List<MPEstructura>> checkAndAdd_toAdd = ( a, b ) =>
			{
				if ( a.gramajeToAdd > 0 )
				{
					var cd = "";
					switch ( a.RollType )
					{
						case "PI":
							cd = "Ink";
							break;
						case "PL":
							cd = "Adh";
							break;
						case "PP":
							cd = "Pro";
							break;
						default:
							break;
					}

					b.Add ( new MPEstructura ( cd, a.gramajeToAdd, a.gramajeToAdd / this.gramaje ) );
				}
			};

			foreach ( var r in roll.RollosOrigenList )
			{
				var mp = r as RolloAlmacen;

				if ( mp != null )
				{
					toRet.Add ( new MPEstructura ( r.code, r.gramaje, r.gramaje / this.gramaje ) );
				}
				else
				{
					toRet.AddRange ( getEstructura ( r, false ) );
				}
			}
			checkAndAdd_toAdd ( roll, toRet );
			return toRet;
		}

		public Rollo ( string type )
		{
			RollType = type;
			Origen = new HashSet<OrigenRollo> ( );
			gramajeToAdd = 0;
		}

		public virtual string code
		{
			get
			{
				return RolloId.ToString ( "00000000" ) + "-" + RollType + "0";
			}
		}
		[NotMapped]
		public virtual double gramaje
		{
			get
			{
				var mt = this as RolloAlmacen;
				if ( mt != null )
				{
					return getFamiliaDensidad ( mt.FamiliaMateriales ) * mt.Calibre;
				}
				else
				{
					return RollosOrigenList.Sum ( t => t.gramaje ) + gramajeToAdd;
				}
			}
		}

		protected double getFamiliaDensidad ( string fam )
		{
			switch ( fam.Trim ( ) )
			{
				case "PE":
				case "PEBD":
					return 0.925;
				case "PET":
					return 1.38;
				case "BOPP":
				case "PP":
				case "OPP":
				case "CAST":
					return 0.905;
				default:
					return 0;
			}
		}
	}

	[Table ( "roll_roll_orgs" )]
	public class OrigenRollo
	{
		[Key, Column ( Order = 1 ), ForeignKey ( "Rollo" )]
		public int RolloId { get; set; }
		[Key, Column ( Order = 2 ), ForeignKey ( "RolloOrigen" )]
		public int RolloOrigenId { get; set; }
		public virtual Rollo Rollo { get; set; }
		public virtual Rollo RolloOrigen { get; set; }
	}


	public class RolloImpresion : Rollo
	{
		[ForeignKey ( "RollProduccion" )]
		[Column ( "TProd" )]
		public int TproduccionID { get; set; }
		public virtual TempProduccion RollProduccion { get; set; }
		public RolloImpresion () : base ( "PI" ) { }
	}
	public class RolloLaminacion : Rollo
	{
		[ForeignKey ( "RollProduccion" )]
		[Column ( "TProd" )]
		public int TproduccionID { get; set; }
		public int TipoLaminacion { get; set; }
		public virtual TempProduccion RollProduccion { get; set; }
		public RolloLaminacion () : base ( "PL" )
		{
			TipoLaminacion = 1;
		}
		public override string code
		{
			get
			{
				return RolloId.ToString ( "00000000" ) + "-" + RollType + TipoLaminacion;
			}
		}

	}


	public class RolloRefinado : Rollo
	{
		[ForeignKey ( "RollProduccion" )]
		[Column ( "TProd" )]
		public int TproduccionID { get; set; }
		public virtual TempProduccion RollProduccion { get; set; }
		public RolloRefinado () : base ( "PR" ) { }
	}

	public class RolloProceso : Rollo
	{
		[ForeignKey ( "RollProduccion" )]
		[Column ( "TProd" )]
		public int TproduccionID { get; set; }
		public virtual TempProduccion RollProduccion { get; set; }
		public RolloProceso () : base ( "PP" ) { }
	}

	public abstract class RolloAlmacen : Rollo
	{
		public double PesoBruto { get; set; }
		public double Ancho { get; set; }
		public double Calibre { get; set; }
		public string FamiliaMateriales { get; set; }
		public string Apariencia { get; set; }

		[Required]
		public string ToProcess { get; set; }
		[NotMapped]
		public double densidad
		{
			get
			{
				return getFamiliaDensidad ( this.FamiliaMateriales );
			}
		}
		[NotMapped]
		public string MaterialName
		{
			get
			{
				return $"{FamiliaMateriales} {Apariencia } {Ancho.ToString ( "0.0" )}/{Calibre.ToString ( "0" )}";
			}
		}
		public RolloAlmacen ( string name ) : base ( name )
		{

		}
	}


	public class RolloMatPrima : RolloAlmacen
	{
		public RolloMatPrima () : base ( "MP" )
		{

		}
	}
	public class RolloRetorno : RolloAlmacen
	{
		public RolloRetorno () : base ( "MR" )
		{

		}
	}


	[Table ( "TProd" )]
	public class TempProduccion
	{

		[Key]
		public int Id { get; set; }

		[Required ( ErrorMessage = "El numero de orden de trabajo es requerido" )]
		public string OT { get; set; }


		[Required ( ErrorMessage = "El tipo de proceso es requerido" )]
		public int TIPOPROCESO { get; set; }

		[Index]
		public int NUMERO { get; set; }

		public double PESOBRUTO { get; set; }

		[NotMapped]
		public double PESONETO { get { try { return PESOBRUTO - PESOCORE; } catch { return 0; } } }

		public double PESOCORE { get; set; }

		public int PIEZAS { get; set; }

		public int BANDERAS { get; set; }

		public int MAQUINA { get; set; }

		public string ORIGEN { get; set; }

		public string OPERADOR { get; set; }

		public int TURNO { get; set; }

		public DateTime FECHA { get; set; }
	}

}
