using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpAcuerdo
{
    public partial class wpAcuerdoUserControl : wpUsrControl
    {


        #region Properties
        UsuarioLogic usuarioLogic = new UsuarioLogic();
        #endregion

        #region Load
    

        protected void Page_Load(object sender, EventArgs e)
        {
        } 
        #endregion

        #region Methods
        private void Cerrar()
        {

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "CloseWaitDialog", @"
<script language='javascript'>
	var parentObject = window.frameElement;
	if (parentObject != null) {
		var waitDialog = parentObject.waitDialog;
		if (waitDialog != null) {
			waitDialog.close();
		}
	}
</script>");
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
         
            if (chckAceptar.Checked)
            {
                string mensaje = string.Empty;
                User usuario = usuarioLogic.ObtenerDatos(UserID, out mensaje);

                bool valido = false;

                if (usuario != null && mensaje == "")
                    valido = usuarioLogic.AlumnoEsValido(usuario, out mensaje);

                if (valido)
                {
                    PasantiasPreprofesionalesLogic pasantiasLogic = new PasantiasPreprofesionalesLogic();
                    PasantiasPreProfesionales pasantia = new PasantiasPreProfesionales();
                    pasantia.AlumnoIdentificador = UserMossID;
                    pasantia.Accion = FormUrl(Properties.Pages.Default.Accion +
                            "?IdPasantia={0}, ") + BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.LinkPractica;
                    pasantia.Titulo = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.NombrePractica;
                    pasantia.AceptoConvenio = true;
                    pasantia.NombreSaes = usuario.Apellidos + " " + usuario.Nombres;
                    pasantia.NombreAlumno = usuario.Nombres;
                    pasantia.ApellidoAlumno = usuario.Apellidos;
                    pasantia.CiudadNacimientoAlumno = usuario.Ciudad;
                    pasantia.DireccionAlumno = usuario.Direccion;
                    pasantia.TelefonoAlumno = usuario.Telefono;
                    pasantia.TelefonoCelularAlumno = usuario.Celular;
                    pasantia.EmailAlumno = usuario.Email;
                    pasantia.SexoAlumno = usuario.Sexo;
                    pasantia.CedulaIdentidad = usuario.Cedula;
                    pasantia.EstadoCivilAlumno = usuario.EstadoCivil;
                    pasantia.FechaNacimientoAlumno = usuario.FechaNacimiento;
                    pasantia.Nivel = usuario.Nivel;
                    pasantia.JornadaAlumno = usuario.Jornada;
                    pasantia.Matricula = usuario.MatriculaID;
                    pasantia.Carrera = usuario.Carrera;
                    pasantia.CodigoCarrera = usuario.CarreraID;
                    pasantia.PlanAlumno = double.Parse(usuario.PlanID);
                    pasantia.CodigoEspecialidad = usuario.EspecialidadID;
                    pasantia.FechaInicioProceso = DateTime.Now;
                    pasantia.NombreTutorSAES = usuario.Tutor;
                    pasantia.CedulaTutor = usuario.TutorID;
                    pasantia.TutorIdentificador = usuario.TutorMOSSID;
                    int? id = 0;
                    pasantiasLogic.Insertar(pasantia, out id);
                    Ira(Properties.Pages.Default.SeleccionPractica, id);
                }
                else
                    lblMensaje.Text = mensaje;
            }
            else {
                Ira(Properties.Pages.Default.Home, null);
            }
            Cerrar();
        }
        
        #endregion

    }
}
