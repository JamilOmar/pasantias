using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class Actividades
    {
        public System.Nullable<System.DateTime> FechaInicio { get; set; }
        public System.Nullable<System.DateTime> FechaFin { get; set; }
        public string Actividad { get; set; }
        public System.Nullable<double> Horas { get; set; }
        public string Observaciones { get; set; }
        public string ObservacionesEmpresa { get; set; }
        public string Titulo { get; set; }
        public int Id { get; set; }
        public int idPasantia { get; set; }
    }
}
