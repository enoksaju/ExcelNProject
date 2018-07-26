using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libProduccionDataBase.Tablas;

namespace ControlResiduosPeligrosos.Reportes.Vistas
{
  public class VstSalidaRP
  {
    public int FolioRP { get; set; }

    public string Linea { get; set; }
    public string ResponsableLinea { get; set; }

    public string TipoRP { get; set; }
    public string RiesgoRP { get; set; }
    public string UnidadRP { get; set; }

    public int valRiesgoRP { get; set; }

    public double Cantidad { get; set; }
    public DateTime FechaEnvasado { get; set; }
    public DateTime FechaIngreso { get; set; }

    // Datos desde el manifiesto
    public DateTime? FechaSalida { get; set; }
    public string ManejoSalida {
			get
			{
				return "Transferencia";
			}
		}
    public string NombreTransportista { get; set; }
    public string NumeroSEMARNAT { get; set; }
    public string ResponsableBitacora { get { return "DNTM"; } }
    public string Manifiesto { get; set; }
  }
}
