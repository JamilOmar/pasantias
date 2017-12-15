using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class Visitas
    {
        public string NombreEstudiante { get; set; }
        public System.Nullable<System.DateTime> FechaVisita { get; set; }
        public string Observaciones { get; set; }
        public int idPasantia { get; set; }
        public string Titulo { get; set; }
        public int Id { get; set; }
		
    }
}
