using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class OfertaLaboral
    {
        public int OFE_ID { get; set; }
        public int? EMP_ID { get; set; }
        public string Titulo { get; set; }
        public string Modalidad { get; set; }
        public string Descripcion { get; set; }
        public string Perfil { get; set; }
        public string Empresa { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? Salario { get; set; }
        public int? Confidencial { get; set; }
        public int? Estado { get; set; }
        public string NombreModalidad { get; set; }
        public string NombreCiudad { get; set; }


        public string NombreSalario { get; set; }
    }
}
