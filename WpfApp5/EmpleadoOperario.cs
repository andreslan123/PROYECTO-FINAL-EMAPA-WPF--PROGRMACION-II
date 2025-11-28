using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
   public class EmpleadoOperario
    {
        //PROPIEDADES 
        public int CodEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public int Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public string Turno { get; set; }
        //CONSTRUCTORES
        public EmpleadoOperario()
        {
            CodEmpleado = 0;
            Nombre = "no definido";
            ApePaterno = "no definido";
            ApeMaterno = "no definido";
            Telefono = 0;
            FechaNacimiento = "no definido";
        }
        public EmpleadoOperario(int codEm, string nomemp,string apepat,string apemate, string fechaa, string turn)
        {
            CodEmpleado = codEm;
            Nombre = nomemp;
            ApePaterno = apepat;
            ApeMaterno = apemate;
            FechaNacimiento = fechaa;
            Turno = turn;
        }
    }
}
