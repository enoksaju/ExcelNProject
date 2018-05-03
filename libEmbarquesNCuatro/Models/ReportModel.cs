using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Tablas;

namespace libEmbarquesNCuatro.Models {
	public class ReportModel {
		public int Id_Tarima { get; set; }
		public DateTime FechaCapturaTarima { get; set; }
		public DateTime FechaExtrusion { get; set; }
		public string Usuario { get; set; }
		public double Ancho { get; set; }
		public double Calibre { get; set; }
		public string OT { get; set; }
		public int Id_Item { get; set; }
		public int Id_Produccion { get; set; }
		public string Proceso { get; set; }
		public int Numero { get; set; }
		public double PesoBruto { get; set; }
		public double PesoCore { get; set; }
		public double PesoNeto { get { return PesoBruto - PesoCore; } }
		public double Piezas { get; set; }
		public string Maquina { get; set; }
		public string Operador { get; set; }
		public DateTime FechaCapturaItem { get; set; }
		public string Extrusion_Id { get; set; }
		public string Cliente { get; set; }
		public string Producto { get; set; }
		public string CodeBarImage {
			get {
				using ( MemoryStream ms = new MemoryStream ( ) ) {

					// Convert Image to byte[]
					using ( var barcode = new BarcodeLib.Barcode ( ) ) {
						barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
						barcode.IncludeLabel = true;
						barcode.BarWidth = 2;
						barcode
							.Encode ( BarcodeLib.TYPE.CODE39 , this.Id_Tarima.ToString ( "*000000000000*" ) , 300 , 70 )
							.Save ( ms , System.Drawing.Imaging.ImageFormat.Bmp );
					}					
					byte [ ] imageBytes = ms.ToArray ( );
					// Convert byte[] to Base64 String
					string base64String = Convert.ToBase64String ( imageBytes );
					return base64String;
				}
			}
		}

		public static IEnumerable<ReportModel> fromTempCapt ( NaveCuatro_Tarima obj ) {
			var ret = from itm in obj.Items
					  select new ReportModel ( ) {
						  OT = itm.Tarima.OT ,
						  Cliente = itm.Tarima.OrdenTrabajo.CLIENTE ,
						  Producto = itm.Tarima.OrdenTrabajo.PRODUCTO ,
						  Id_Tarima = itm.Tarima.Id ,
						  Id_Item = itm.Id ,
						  Id_Produccion = itm.Item.Id ,
						  Ancho = itm.Tarima.Ancho ,
						  Calibre = itm.Tarima.Calibre ,
						  FechaCapturaTarima = itm.Tarima.FechaCaptura ,
						  FechaExtrusion = itm.Tarima.FechaExtrusion ,
						  Extrusion_Id = itm.Item.EXTRUSION_ID ,
						  FechaCapturaItem = itm.Item.FECHA ,
						  Numero = itm.Item.NUMERO ,
						  PesoBruto = itm.Item.PESOBRUTO ,
						  PesoCore = itm.Item.PESOCORE ,
						  //PesoNeto = itm.Item.PESONETO ,
						  Maquina = itm.Item.Maquina_.NombreMaquina ,
						  Operador = itm.Item.OPERADOR ,
						  Piezas = itm.Item.PIEZAS ,
						  Proceso = itm.Item.Proceso_.NombreProceso ,
						  Usuario = itm.Item.USUARIO
					  };
			return ret;
		}
		public static IEnumerable<ReportModel> fromContext ( libProduccionDataBase.Contexto.DataBaseContexto DB , int idTarima ) {

			var ret = from tar in DB.NCuatro_Tarimas
					  where tar.Id == idTarima
					  from itm in tar.Items
						  // obj.Items
					  select new ReportModel ( ) {
						  OT = itm.Tarima.OT ,
						  Cliente = itm.Tarima.OrdenTrabajo.CLIENTE ,
						  Producto = itm.Tarima.OrdenTrabajo.PRODUCTO ,
						  Id_Tarima = itm.Tarima.Id ,
						  Id_Item = itm.Id ,
						  Id_Produccion = itm.Item.Id ,
						  Ancho = itm.Tarima.Ancho ,
						  Calibre = itm.Tarima.Calibre ,
						  FechaCapturaTarima = itm.Tarima.FechaCaptura ,
						  FechaExtrusion = itm.Tarima.FechaExtrusion ,
						  Extrusion_Id = itm.Item.EXTRUSION_ID ,
						  FechaCapturaItem = itm.Item.FECHA ,
						  Numero = itm.Item.NUMERO ,
						  PesoBruto = itm.Item.PESOBRUTO ,
						  PesoCore = itm.Item.PESOCORE ,
						  // PesoNeto = itm.Item.PESONETO ,
						  Maquina = itm.Item.Maquina_.NombreMaquina ,
						  Operador = itm.Item.OPERADOR ,
						  Piezas = itm.Item.PIEZAS ,
						  Proceso = itm.Item.Proceso_.NombreProceso ,
						  Usuario = itm.Item.USUARIO
					  };
			return ret;
		}

	}
}
