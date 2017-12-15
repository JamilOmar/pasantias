using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpInformacionValidador
{
    public partial class wpInformacionValidadorUserControl :wpUsrControl
    {
        public wpInformacionValidador WebPart { set; get; }

        #region Load

        /// <summary>
        /// Metodo de validacion de pagina segun credencial de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!PaginaRecargada)
                {
                    var estado = !String.IsNullOrEmpty(this.WebPart.Estado)? this.WebPart.Estado.Replace(" ", "_"):string.Empty;
                    var id = GetPasantiaQueryString();
                    if (id.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);
                        if (itemPasantias == null)
                            Ira(Properties.Pages.Default.EnProceso, id);
                        else
                        {
                            var habilitarTodo = this.WebPart.AllowTodos;
                            var esAlumno = ValidarUsuario(itemPasantias, this.WebPart.AllowAlumno, false, false, false);
                            var esDocente = ValidarUsuario(itemPasantias, false, this.WebPart.AllowDocente, false, false);
                            var esTutor = ValidarUsuario(itemPasantias, false, false, this.WebPart.AllowTutor, false);
                            var esEmpresa = ValidarUsuario(itemPasantias, false, false, false, this.WebPart.AllowEmpresa);
                            var Acceso = esAlumno || esDocente || esTutor || esEmpresa || habilitarTodo;
                            if (!Acceso)
                            {
                                Ira(Properties.Pages.Default.EnProceso, id);
                            }
                            else
                                if (!itemPasantias.Estado.Equals(estado) && !this.WebPart.AllowTutorEspecial
                                    && !habilitarTodo)
                                {
                                    Ira(Properties.Pages.Default.EnProceso, id);
                                }
                                else
                                {
                                    txtAlumno.Text = itemPasantias.NombreSaes;
                                    txtEmpresa.Text = itemPasantias.Empresa;
                                    txtTipoPasantia.Text = itemPasantias.TipoPasantiaEnum;
                                    txtCedula.Text = itemPasantias.CedulaIdentidad;
                                }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        #endregion
      
    }
}
