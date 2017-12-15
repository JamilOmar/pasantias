using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class usrCommand : UserControl
    {
        #region Propiedades

        public string BotonAceptarTexto { get { return btnGuardar.Text; } set { btnGuardar.Text = value; } }
        public string BotonCancelarTexto { get { return btnCancelar.Text; } set { btnCancelar.Text = value; } }
        public bool EliminarVisible { get { return this.tdEliminar.Visible; } set { this.tdEliminar.Visible = value; } }
        public bool MostrarMensaje { get; set; }
        public bool MostrarGuardar { get { return btnGuardar.Visible; } set { btnGuardar.Visible = value; } }
        public string Mensaje { get; set; }

        #endregion

        #region Eventos Publicos
        public event EventHandler OnGuardar;
        public event EventHandler OnCancelar;
        public event EventHandler OnEliminar;
        
        #endregion

        #region Eventos Privados

        protected void Page_Load(object sender, EventArgs e)
        {
            if(MostrarMensaje)
            btnGuardar.Attributes.Add("onclick", "javascript:if(confirm('"+ Mensaje +"')== false) return false;");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (OnGuardar != null)
                OnGuardar(this, e);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (OnCancelar != null)
                OnCancelar(this, e);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (OnEliminar != null)
                OnEliminar(this, e);
        } 
        #endregion
    }
}
