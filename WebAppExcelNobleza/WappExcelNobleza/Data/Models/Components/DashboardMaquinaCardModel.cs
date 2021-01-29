using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WappExcelNobleza.Data.Models.Components
{
    public class DashboardMaquinaCardModel
    {
        public double Kg { get; set; }
        public int Ots { get; set; }
        public int Rolls { get; set; }
        public DateTime Last { get; set; }
        public DateTime Dif { get => new DateTime((DateTime.Now - Last).Ticks); }
        public string NombreMaquina { get; set; }
        public DashboardMaquinaCardModel(List<ConsultaDashMaquinaCardModel> Coll, int Key)
        {
            Kg = Math.Round(Coll.Where(u => u.Maquina == Key).Sum(i => i.TotalPesoNeto), 2);
            Ots = Coll.Where(u => u.Maquina == Key).Select(u => u.OT).Distinct().Count();
            Rolls = Coll.Where(u => u.Maquina == Key).Sum(i => i.TotalBobinas);
            Last = Coll.Where(u => u.Maquina == Key).Max(u => u.Fecha);
            NombreMaquina = Coll.FirstOrDefault(u => u.Maquina == Key).NombreMaquina;
        }

        public static void AddToCollection(List<ConsultaDashMaquinaCardModel> Coll, int Key, List<DashboardMaquinaCardModel> destino)
        {
            if (Coll.Any(u => u.Maquina == Key))
            {
                destino.Add(new DashboardMaquinaCardModel(Coll, Key));
            }
        }
    }

    public class ConsultaDashMaquinaCardModel
    {
        public double TotalPesoNeto { get; set; }
        public int TotalBobinas { get; set; }
        public string OT { get; set; }
        public int Maquina { get; set; }
        public string NombreMaquina { get; set; }
        public DateTime Fecha { get; set; }
    }
}
