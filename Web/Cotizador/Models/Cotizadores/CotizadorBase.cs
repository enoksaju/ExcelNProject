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
	public abstract class CotizadorBase<T> : ICalc where T : IResultados, new()
	{
		private double _cotizamos;

		public virtual int? Id { get; set; }
		public virtual ProductosPedidos Tipo_Producto_Id { get; set; }
		public virtual double Cantidad { get; set; } = 0;
		public virtual UnidadesPedido UnidadPedido { get; set; }

		public virtual double AnchoDiseño { get; set; } = 0;
		public virtual double AltoDiseño { get; set; } = 0;
		public virtual int RepDes { get; set; } = 0;
		public virtual int RepEje { get; set; } = 0;

		public abstract string Descripcion { get; }
		public virtual IResultados Resultados { get; private set; }
		public virtual Material MaterialBase { get; set; } = null;
		public virtual Material MaterialLaminacion { get; set; } = null;
		public virtual Material MaterialTrilaminacion { get; set; } = null;
		public virtual Material MaterialTretralaminacion { get; set; } = null;

		public virtual double CalibreMaterialBase { get; set; } = 0;
		public virtual double CalibreMaterialLaminacion { get; set; } = 0;
		public virtual double CalibreMaterialTrilaminacion { get; set; } = 0;
		public virtual double CalibreMaterialTretralaminacion { get; set; } = 0;

		public double Cotizamos
		{
			get
			{
				return _cotizamos;
			}

			set
			{
				_cotizamos = value > 0 ? value : Resultados.PrecioObjetivo;
			}
		}

		public DateTime FechaCreacion { get; set; } = DateTime.Now.Date;

		public string NombreProducto { get; set; }

		public CotizadorBase ()
		{
			this.Resultados = new T ( );
			this.Resultados.Parent = this;
		}

		public abstract CotizacionDetalle toCotizacionDetalle ( DataBaseContexto Contexto );
		public abstract ICalcType fromCotizacionDetalle<ICalcType> ( DataBaseContexto Contexto, int Id ) where ICalcType : ICalc;
		public abstract CotizacionDetalle toCotizacionDetalle ();
	}

	public abstract class ResultadosBase<ICalcType> : IResultados where ICalcType : ICalc, new()
	{
		public abstract double Comision_Equivalente { get; }

		public abstract double Comision_Kg { get; }

		public abstract double Comision_Total { get; }

		public abstract double CostoReal_Desperdicio { get; }

		public abstract double CostoReal_Total { get; }

		public ICalc Parent { get; set; }

		public abstract double PorcentDesperdicio { get; }
		public abstract double PrecioDesperdicio { get; }
		public abstract double PrecioObjetivo { get; }
		public abstract double PrecioUltimo { get; }

		public ICalcType GetInstance ()
		{
			return (ICalcType)Parent;
		}
	}



}