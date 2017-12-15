using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    public class Academico
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string  Matricula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Ciudad { get; set; }
        public string Genero { get; set; }
        public string FechaNacimiento { get; set; }
        public string Estado { get; set; }
        public string Modalidad { get; set; }
        public string Disponibilidad { get; set; }
        public string FormacionAcademica { get; set; }
        public string Carrera { get; set; }
        public string Nivel { get; set; }
        public string Email { get; set; }

        public string Carrera1 { get; set; }

        public string NivelCarrera1 { get; set; }

        public string Carrera2 { get; set; }

        public string NivelCarrera2 { get; set; }
    }
}
