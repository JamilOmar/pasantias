using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    public class UsuarioEmpresaEvaluacionEstudiante
    {
        public int  Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Cargo { get; set; }
        public string AreaTrabajo { get; set; }
        public string Funciones { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string HorarioTrabajo { get; set; }
        public string NumeroHorasEjecutadas { get; set; }
    }
}
