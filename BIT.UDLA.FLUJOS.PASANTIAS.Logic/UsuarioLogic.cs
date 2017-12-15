using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class UsuarioLogic
    {
        public static int GetUserID(string loginName, bool dominio, out string mensaje)
        {
            return BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance.UserPersistence.GetUserID(loginName,dominio,out mensaje);
             
        }
        public User ObtenerDatos(string id, out string mensaje)
        {
            AlumnoPersistance obj = new AlumnoPersistance();
            User usuario = obj.SeleccionarPorId(id, out mensaje);

            if (usuario != null)
            {
                usuario.Nivel = obj.ObtenerNivel(usuario.MatriculaID, usuario.CarreraID, usuario.PlanID, usuario.EspecialidadID, out mensaje);

                if (usuario.Nivel > 0)
                {
                    string[] tutor = obj.ObtenerTutor(usuario.ID, out mensaje);

                    if (tutor != null)
                    {
                        usuario.Tutor = tutor[0];
                        usuario.TutorID = tutor[1];
                        usuario.TutorUsername = Comun.Utils.ObtenerUsernameAD(tutor[1], out mensaje);
                        usuario.TutorUsername = "usrbit02";
                        if (usuario.TutorUsername != "")
                            usuario.TutorMOSSID = MossPersistance.UserPersistence.GetUserID(usuario.TutorUsername,true, out mensaje);
                    }
                }
            }

            return usuario;
        }

        public bool AlumnoEsValido(User usuario, out string mensaje)
        {
            AlumnoPersistance obj = new AlumnoPersistance();
            return obj.EsValido(usuario, out mensaje);
        }

        public bool ActualizarMateria(string id, string materia, float nota)
        {
            AlumnoPersistance obj = new AlumnoPersistance();
            return obj.ActualizarMateria(id, materia, nota);
        }



    }
}
