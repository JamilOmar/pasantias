using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class Curso
    {
        public int? Id { get; set; }
        public int? IdPersona { get; set; }
        public int? IdPais { get; set; }
        public string Nombre { get; set; }
        public string Institucion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Duracion { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

    }
}
