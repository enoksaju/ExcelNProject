using System;

namespace excelnobleza.shared.Enums
{
	public class DataBaseEnums
	{
		/// <summary>
		/// Unidades para asignar el calibre a un sustrato
		/// </summary>
		public enum Unidades_Calibre { NA, Um, CI }

		/// <summary>
		/// Tamaños de Core disponibles
		/// </summary>
		public enum Cores { Tres = 3, Seis = 6 }

		/// <summary>
		/// Tipos de Productos Disponibles en Planta
		/// </summary>
		public enum TiposProductos
		{
			Pelicula,
			PeliculaLaminada,
			PeliculaTrilaminada,
			FlowpackLaminada,
			FlowpackTrilaminada,
			SelloLateralNoImpresa,
			SelloLateralImpresa,
			SelloLateralLaminadaNoImpresa,
			SelloLateralLaminadaImpresa,
			SelloLateralTrilaminada,
			Otro,
			Etiqueta,
			PVC,
			Prototipos,
			Piezas,
			EtiquetaTipoManga,
			BolsaTubular
		}

		/// <summary>
		/// Flags de los procesos involucrados en la fabricacion de un producto
		/// </summary>
		[Flags]
		public enum TiposProcesoProduccion
		{
			Impresion = 1 << 0,
			Laminacion = 1 << 1,
			Refinado = 1 << 2,
			Doblado = 1 << 3,
			Corte = 1 << 4,
			Embobinado = 1 << 5,
			Mangas = 1 << 6,
			Sellado = 1 << 7,
			Extrusion = 1 << 8,
			Trilaminacion = 1 << 9,
			Tetralaminacion = 1 << 10,
			Desmetalizar = 1 << 11,
			Microperforado = 1 << 12,
			Troquelar = 1 << 13
		}

		/// <summary>
		/// Flags del estatus del plan de produccion de una orden de trabajo 
		/// </summary>
		[Flags]
		public enum EstatusPlaneacion
		{
			PedidoNuevo = 1 << 0,
			PedidoEnPrograma = 1 << 1,
			PedidoTerminado = 1 << 2,
			PedidoReposicion = 1 << 3,
			PedidoReprogramado = 1 << 4
		}

		/// <summary>
		/// Flags del estatus de un diseño
		/// </summary>
		public enum EstatusDiseño
		{
			NoAsignado = 0,
			EnRevision = 1,
			Autorizado = 2,
			Repetido = 4
		}
	}
}
