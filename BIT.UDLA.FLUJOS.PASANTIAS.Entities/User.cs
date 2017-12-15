using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class User
    {
        public string ID { get; set; }
        public string DV { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public int Nivel { get; set; }
        public string Jornada { get; set; }
        public string MatriculaID { get; set; }
        public string CarreraID { get; set; }
        public string Carrera { get; set; }
        public string PlanID { get; set; }
        public string EspecialidadID { get; set; }

        public string Tutor { get; set; }
        public string TutorID { get; set; }
        public string TutorUsername { get; set; }
        public int TutorMOSSID { get; set; }
    }
}
