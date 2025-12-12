using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace WpfApp5
    {
        public class Tramite
        {
            public int IdTramite { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            public string Responsable { get; set; }

            public Tramite() { }

            public Tramite(int id, string descripcion, DateTime fecha, string responsable)
            {
                IdTramite = id;
                Descripcion = descripcion;
                Fecha = fecha;
                Responsable = responsable;
            }
        }
    }

