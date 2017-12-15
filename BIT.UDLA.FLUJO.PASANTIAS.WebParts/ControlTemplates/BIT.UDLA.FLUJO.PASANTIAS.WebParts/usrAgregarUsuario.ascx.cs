using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using Microsoft.SharePoint;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class usrAgregarUsuario : wpUsrControl
    {

        public event EventHandler Aceptar;
        public event EventHandler Cancelar;
        public int? IdEmpresa
        {
            set
            {
                ViewState["IdAsistencia"] = value;
            }
            get
            {
                return (int?)ViewState["IdAsistencia"];
            }
        }
        public UsuarioEmpresa UsuarioEmpresa
        {
            set
            {
                ViewState["UsuarioEmpresa"] = value;
            }
            get
            {
                return (UsuarioEmpresa)ViewState["UsuarioEmpresa"];
            }

        }
        public bool? EsNuevo
        {
            set
            {
                ViewState["EsNuevo"] = value;
            }
            get
            {
                return (bool?)ViewState["EsNuevo"];
            }
        }

        UsuarioEmpresaLogic usuarioEmpresaLogic = new UsuarioEmpresaLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PaginaRecargada)
            {
                UsuarioEmpresa = new FLUJOS.PASANTIAS.Entities.UsuarioEmpresa();
                EsNuevo = IsNewItem();
                  var id = GetPasantiaQueryString();
                  if (id.HasValue)
                  {
                      itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);
                      if (itemPasantias == null)
                          itemPasantias = new PasantiasPreProfesionales();
                      lblNombreOriginal.Text = itemPasantias.NombreSupervisor;
                      lblTelefonoOriginal.Text = itemPasantias.TelefonoSupervisor;
                      lblEmailOriginal.Text = itemPasantias.EmailSupervisor;
                      trInformacion.Visible = true;
                  }
                IdEmpresa = GetDynamicQueryStringIntValue("IdEmpresa");
                if (IdEmpresa.HasValue)
                {
                    if (EsNuevo.HasValue && !EsNuevo.Value)
                    {
                       
                        UsuarioEmpresa = usuarioEmpresaLogic.GetUserbyKey(GetDynamicQueryStringValue("IdUsuario"));
                        if (UsuarioEmpresa != null)
                        {

                            MapToControl(UsuarioEmpresa);
                            if (UsuarioEmpresa.EsUsuarioInterno)
                            {
                                this.chckValido.Enabled = false;
                                this.usrCommand1.Visible = false;
                            }
                            EnableItem(false);
                        }
                        else
                            Ira("", null);
                    }
                    else
                        EnableItem(true);
                  
                }
                else
                    Ira("", null);

            }

        }

        void MapToControl(UsuarioEmpresa item)
        {
            txtApellido.Text = item.Apellido;
            txtNombre.Text = item.Nombre;
            txtPassword.Text = item.Password;
            txtTelefono.Text = item.Telefono;
            txtUserName.Text = item.UserName;
            txtEmail.Text = item.Email;
            chckValido.Checked = UsuarioEmpresa.EsValido;
        }
        UsuarioEmpresa MapToEntity(UsuarioEmpresa item)
        {

            UsuarioEmpresa.Apellido = txtApellido.Text;
            UsuarioEmpresa.Nombre = txtNombre.Text;
            UsuarioEmpresa.Email = txtEmail.Text;
            UsuarioEmpresa.Password = txtPassword.Text;
            UsuarioEmpresa.Telefono = txtTelefono.Text;
            UsuarioEmpresa.UserName = txtUserName.Text;
            UsuarioEmpresa.EsValido = chckValido.Checked;
            if (EsNuevo.Value)
            {
                UsuarioEmpresa.empId = IdEmpresa.Value;
            }

            return item;
        }
        void EnableItem(bool validated)
        {
          
            btnHabilitar.Visible = txtUserName.ReadOnly = txtEmail.ReadOnly = !validated;
    
        }


        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            bool validated=  false; 
            try
            {
                UsuarioEmpresa = MapToEntity(UsuarioEmpresa);
                if (EsNuevo.HasValue &&EsNuevo.Value
                    )
                    {

                        if (ValidarUsuarioAD(UsuarioEmpresa.UserName))
                        {
                            validated = usuarioEmpresaLogic.Insertar(UsuarioEmpresa);
                        }
                        
                    }
                    else
                    {
                        validated = true;
                        usuarioEmpresaLogic.Actualizar(UsuarioEmpresa);
                    }

                

                if (validated)
                    if (Aceptar != null)
                    {
                       
                        Aceptar(this, e);
                    }
                    
                else
                    lblError.Visible = true;

            }
            catch (Exception ex)
            {
                ManejarErrorNoRedirect(ex);
                lblError.Visible = true;
            }
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (Cancelar != null)
                {
                    Cancelar(this, e);
                }
              
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }



        public bool ValidarUsuarioAD(string userName)
        { 
            string mensaje =string.Empty;
            return UsuarioLogic.GetUserID(userName, true,out mensaje) ==-1;
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEmpresa.EsValido = chckValido.Checked;
                usuarioEmpresaLogic.Actualizar(UsuarioEmpresa);
             
                    if (Aceptar != null)
                    {

                        Aceptar(this, e);
                    }
                    else
                        Ira(Properties.Pages.Default.ConSupervision, itemPasantias.Id.Value);

            }
            catch (Exception ex)
            {
                ManejarErrorNoRedirect(ex);
                lblError.Visible = true;
            }
        }

    }
}

