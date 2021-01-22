using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelNobleza.Shared.Models
{
	public enum ColorType
	{
		Pantone,
		Cyan,
		Magenta,
		Amarillo,
		Negro,
		Blanco
	}

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
	public enum TiposProducto
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
	public enum ProcesosProduccion
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
}
