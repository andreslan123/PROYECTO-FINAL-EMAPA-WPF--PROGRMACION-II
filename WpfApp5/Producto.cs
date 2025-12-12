using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class Producto
    {
        public int IdProd { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string Fecha { get; set; }

        public Producto()
        {
            IdProd = 0;
            Nombre = "no definido";
            Cantidad = 0;
            Precio = 0;
            Fecha = "no definido";
        }

        public Producto(int idpro, string nompro, int canti, double pre, string fechaa)
        {
            IdProd = idpro;
            Nombre = nompro;
            Cantidad = canti;
            Precio = pre;
            Fecha = fechaa;
        }
    }
}
