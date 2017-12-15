using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class UsuarioEmpresa
    {
        const string  b ="BOLSAEMPLEO";
        const string   p= "PRACTICAS";
        public string UniqueID
        {
            get
            {
                return Id.ToString()+ ((EsUsuarioInterno)?b:p);
            }
          
        }
        public static int DestroyUnique(string id)
        { 
            id = id.Replace(b,"");
               id = id.Replace(p,"");
               return int.Parse(id);
        }
        public static bool Interno(string id)
        {
            return id.Contains(b);
        }
        public int Id { get; set; }
        public int? empId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string  UserName { get; set; }
        public string  Password { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool EsValido { get; set; }
        
        public  bool EsUsuarioInterno
        {
            get
            {
                return !empId.HasValue;
            }
        }
    }
}
