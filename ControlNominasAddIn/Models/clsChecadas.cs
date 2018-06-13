using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlNominasAddIn.Models {
	public class Checada {
		public string Orden { get; set; }
		public string Id { get; set; }
		public string Nombre { get; set; }
		public DateTime Fecha { get; set; }
		public string FechaC { get; set; }
		public DateTime? Entrada { get; set; }
		public DateTime? Salida { get; set; }
	}
	public class Checadas {
		public enum Tipos_IO { Salida, Entrada, Duplicado }
		private string _Orden;
		private int _Ultimo, i;
		private bool _Agrega;
		public Checadas ( ) {
			Elementos = new List<Checada> ( );
		}

		public List<Checada> Elementos { get; }
		public void Clear ( ) {
			this.Elementos.Clear ( );
		}
		public void Add ( string Clave , string Nombre , DateTime Fecha , DateTime Checada , Tipos_IO Tipo ) {

			var FormatedFecha = String.Format ( "{0:ddMMyyyy}" , Fecha );
			Clave = Clave.PadLeft ( 6 , '0' );

			switch ( Tipo ) {
				case Tipos_IO.Entrada:
					for ( i = 1; i <= 6; i++ ) {
						_Orden = String.Format ( "{0}{1:ddMMyyyy}{2:00}" , Clave , Fecha , i );
						if ( !Elementos.Any ( o => o.Orden == _Orden ) ) {
							Elementos.Add ( new Models.Checada ( ) {
								Orden = _Orden ,
								Id = Clave ,
								Nombre = Nombre ,
								Fecha = Fecha ,
								FechaC = String.Format ( "{0:ddMMyyyy}" , Fecha ) ,
								Entrada = Checada ,
								Salida = null
							} );
							break;
						}
					}
					break;
				case Tipos_IO.Salida:
					_Ultimo = 6;
					_Agrega = false;
					for ( i = 6; i >= 1; i-- ) {
						_Orden = String.Format ( "{0}{1:ddMMyyyy}{2:00}" , Clave , Fecha , i );
						var el = Elementos.FirstOrDefault ( o => o.Orden == _Orden );
						if ( el == null ) {
							_Ultimo = i;
						} else {
							_Ultimo = !el.Salida.HasValue ? i : i + 1;
							_Agrega = !el.Salida.HasValue ? false : true;
							break;
						}
					}


					if ( _Agrega ) {
						for ( i = _Ultimo; i <= 9; i++ ) {
							_Orden = String.Format ( "{0}{1:ddMMyyyy}{2:00}" , Clave , Fecha , i );
							if ( !Elementos.Any ( o => o.Orden == _Orden ) ) {
								Elementos.Add ( new Models.Checada ( ) {
									Orden = _Orden ,
									Id = Clave ,
									Nombre = Nombre ,
									Fecha = Fecha ,
									FechaC = String.Format ( "{0:ddMMyyyy}" , Fecha ) ,
									Entrada = null ,
									Salida = Checada
								} );
								break;
							}
						}
					} else {
						_Orden = String.Format ( "{0}{1:ddMMyyyy}{2:00}" , Clave , Fecha , i );
						var el = Elementos.FirstOrDefault ( o => o.Orden == _Orden );
						if ( el != null ) {
							el.Salida = Checada;
						}
					}

					break;
				default:
					System.Diagnostics.Debug.Fail ( "Valor no Identificado" );
					break;
			}

		}
	}
}
