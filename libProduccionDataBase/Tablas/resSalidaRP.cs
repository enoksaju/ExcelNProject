using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace libProduccionDataBase.Tablas
{
  [Table("res_TiposRP")]
  [Serializable]
  public class TipoRP
  {
    public enum Riesgos { Corrosivo, Reactivo, Toxico, Inflamable }
    public enum Unidades { Tambo, Caja }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaveRP { get; set; }
    public string Descripcion { get; set; }
    public Riesgos Riesgo { get; set; }
    public Unidades Unidad { get; set; }
  }

  [Table("res_Proved")]
  [Serializable]
  public class Proveedor
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaveP { get; set; }
    public string Denominacion { get; set; }
    public string Domicilio { get; set; }
    public string Municipio { get; set; }
    public int CP { get; set; }
    public string Estado { get; set; }
    public string AutSEMARNAT { get; set; }

    public virtual ObservableListSource<Manifiesto> Manifiestos { get; set; }
  }

  [Table("res_Transp")]
  [Serializable]
  public class Transportista
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaveT { get; set; }
    public string Denominacion { get; set; }
    public string Domicilio { get; set; }
    public string Municipio { get; set; }
    public int CP { get; set; }
    public string Estado { get; set; }
    public string AutSEMARNAT { get; set; }
    public string RegSCT { get; set; }
    public string Telefono { get; set; }

    public virtual ObservableListSource<Manifiesto> Manifiestos { get; set; }
  }

  [Table("res_SalidaRP")]
  [Serializable]
  public class SalidaRP
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FolioRP { get; set; }
    public int ClaveRP { get; set; }
    public int ClaveL { get; set; }
    public double Cantidad { get; set; }
    public DateTime FechaEnvasado { get; set; }
    public DateTime FechaIngreso { get; set; }

    [ForeignKey("ManifiestoDetalle")]
    public int? FolioDM { get; set; }
    public virtual ManifiestoDetalle ManifiestoDetalle { get; set; }

    [ForeignKey("ClaveRP")]
    public virtual TipoRP TipoRP { get; set; }

    [ForeignKey("ClaveL")]
    public virtual Linea Linea { get; set; }
  }

  [Table("res_Manif")]
  [Serializable]
  public class Manifiesto
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required(ErrorMessage ="El numero de manifiesto es requerido y debe ser unico")]
    public string NoManifiesto { get; set; }
    [Required(ErrorMessage ="El proveedor es requerido")]
    public int ClaveP { get; set; }
    [Required(ErrorMessage ="El transportista es requerido")]
    public int ClaveT { get; set; }
    [Required(ErrorMessage ="El nombre del Chofer es Requerido")]
    public string NombreChofer { get; set; }
    public string CargoChofer { get; set; }
    [Required(ErrorMessage ="El nombre del Receptor es requerido")]
    public string NombreReceptor { get; set; }
    public string CargoReceptor { get; set; }

    [Required(ErrorMessage ="La fecha es Requerida")]
    public DateTime Fecha { get; set; }

    [ForeignKey("ClaveP")]
    public virtual Proveedor Proveedor { get; set; }

    [ForeignKey("ClaveT")]
    public virtual Transportista Transportista { get; set; }

    public virtual ObservableListSource<ManifiestoDetalle> ManifiestoDetalle { get; set; }
  }

  [Table("res_dmanif")]
  [Serializable]
  public class ManifiestoDetalle
  {
    public int Id { get; set; }
    [ForeignKey("Manifiesto")]
    public string NoManifiesto { get; set; }
    public Manifiesto Manifiesto { get; set; }

    [ForeignKey("TipoRP")]
    public int ClaveRP { get; set; }
    public virtual TipoRP TipoRP { get; set; }

    public virtual ObservableListSource<SalidaRP> SalidaResiduosPeligrosos { get; set; }

    public double Peso => this.SalidaResiduosPeligrosos.Sum(o => o.Cantidad);
    public int Count => this.SalidaResiduosPeligrosos.Count();
    public string NombreRP => this.TipoRP.Descripcion;
    public string UnidadRP => this.TipoRP.Unidad.ToString();
  }
}
