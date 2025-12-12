using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp5
{
    public class Lote
    {
        public int IdLote { get; set; }
        public int IdProducto { get; set; }
        public int CantidadTotal { get; set; }
        public int CantidadDisponible { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdProveedor { get; set; }
        public string Estado { get; set; }

        public Lote() { }
    }
}
