using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class Materia
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Nivel { get; set; }
        public int Horas { get; set; }
        public string Docente { get; set; }
        public string DocenteID { get; set; }
    }
}
