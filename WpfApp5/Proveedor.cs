using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
     public class Proveedor
    {
        public int IdProv { get; set; }
        public string NomProv { get; set; }
        public int CiProv { get; set; }

        public List<Producto> LstPro { get; set; }

        public Proveedor()
        {
            LstPro = new List<Producto>();
        }

        public Proveedor(int id, string nombre, int ci)
        {
            IdProv = id;
            NomProv = nombre;
            CiProv = ci;
            LstPro = new List<Producto>();
        }


    }
}
