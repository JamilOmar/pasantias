using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Linq;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionCreacionUsuariosEmpresas
{
    public partial class wpSeleccionCreacionUsuariosEmpresasUserControl : wpUsrControl
    {
        #region Properties
        UsuarioEmpresaLogic usuariosLogic = new UsuarioEmpresaLogic();

        public List<UsuarioEmpresa> Usuarios
        {
            get
            { return ViewState["Usuarios"] as List<UsuarioEmpresa>; }
            set { ViewState["Usuarios"] = value; }
        }


        public string Key
        {
            get
            { return ViewState["key"].ToString(); }
            set { ViewState["key"] = value; }
        }

        private UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager PaginadorActividades
        {
            get
            {
                return (usrPagerActividades as UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts.usrPager);
            }
        }
        
        #endregion

        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var id = GetPasantiaQueryString();
                    if (id.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);

                        Recargar();
                        CrearLinks();
                    }
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }

        } 
        #endregion


        #region Methods
        public void CrearLinks()
        {
            try
            {
                this.hlNuevaAsistencia.Attributes.Add("onClick", string.Format("javascript:OpenDialog('{0}','{1}' );", string.Format("{0}?IdEmpresa={1}&IdPasantia={2}&New=true", FormUrl(Properties.Pages.Default.RegistroUsuarios),
                    itemPasantias.IdEmpresa.Value, itemPasantias.Id.Value), FormUrl(Properties.Pages.Default.SeleccionUsuarioEmpresa) + "?IdPasantia=" + itemPasantias.Id.ToString()));
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }


        public string ObtenerLink(object id)
        {
            try
            {
                var s = string.Format("javascript:OpenDialog('{0}','{1}');", string.Format("{0}?IdEmpresa={1}&IdUsuario={2}&New=false", FormUrl(Properties.Pages.Default.RegistroUsuarios),
                    itemPasantias.IdEmpresa.Value, id),FormUrl(Properties.Pages.Default.SeleccionUsuarioEmpresa) + "?IdPasantia=" + itemPasantias.Id.ToString());
                return s;
            }
            catch (Exception ex)
            {
                ManejarError(ex);
                return null;
            }
        }

        public void SeleccionUsuarios(string id, string nombre, string apellido, string Username)
        {
            try
            {
                lblNombre.Text = string.Format("{0} {1}", nombre, apellido);
                lblUsername.Text = Username;
                Key = id;
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }


        protected void lnkAtras_Click(object sender, EventArgs e)
        {
            try
            {
                if (PaginadorActividades.PaginaActual > 0)
                {
                    PaginadorActividades.PaginaActual -= 1;
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        protected void lnkAdelante_Click(object sender, EventArgs e)
        {
            try
            {
                PaginadorActividades.PaginaActual += 1;
                Cargar();
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        public void Cargar()
        {
            try
            {
                var aux = 0;

                this.grdUsuarios.DataSource = Usuarios = usuariosLogic.GetUsersbyEmpresa((int)itemPasantias.IdEmpresa.Value, PaginadorActividades.PaginaActual, PaginadorActividades.NumeroItemsPorPagina, out aux);
                this.grdUsuarios.DataBind();
                PaginadorActividades.MaximoNumeroItems = aux;
                PaginadorActividades.Cargar();
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        public void Recargar()
        {
            try
            {
                PaginadorActividades.PaginaActual = 0;
                PaginadorActividades.MaximoNumeroItems = 0;
                Cargar();
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }

        }


        #region Events
        protected void aceptarButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (!String.IsNullOrEmpty(Key))
                {

                    pasantiasLogic.Actualizar(MapToEntity());
                    Ira(Properties.Pages.Default.MensajePageName, itemPasantias.Id.Value);
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorAsignacion.Visible = true;
                ManejarErrorNoRedirect(ex);

            }


        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Ira(Properties.Pages.Default.Home, null);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }
        #endregion

        #region Mappers



        PasantiasPreProfesionales MapToEntity()
        {

            //if (itemPasantias.TipoPasantiaEnum == BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_TRABAJO)
            //    itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ASIGNACION_EMPRESA;
            //if (itemPasantias.TipoPasantiaEnum == BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION)
            //    itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CARTA_DE_COMPROMISO;
            //if (itemPasantias.TipoPasantiaEnum == BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.SIN_SUPERVISION)
            //    itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ACEPTACION_ESTUDIANTE_EMPRESA;
            UsuarioEmpresa user = Usuarios.First(x => x.UniqueID == Key);
            itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.NOTIFICAR_USUARIO_EMPRESA;
            string mensaje = string.Empty;
              user =   usuariosLogic.GetUser(user.UserName);
            if(!user.EsValido)
                throw new Exception("Usuario No Activo, seleccione o cree otro usuario");
            int userID = UsuarioLogic.GetUserID(user.UserName, false, out mensaje);

            if (userID > -1)
                itemPasantias.SupervisorDeEmpresaIdentificador = userID;
            else
                throw new Exception(mensaje);
            itemPasantias.NombreSupervisor = user.Nombre + " " + user.Apellido;
            itemPasantias.EmailSupervisor = user.Email;
            itemPasantias.TelefonoSupervisor = user.Telefono;
            itemPasantias.SupervisorDeEmpresaIdentificador = userID;
            return itemPasantias;
        }
        #endregion

        protected void lnkbtnSeleccion_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var val = e.CommandArgument.ToString();
                var user = Usuarios.First(x => x.UniqueID == val);
                SeleccionUsuarios(user.UniqueID, user.Nombre, user.Apellido, user.UserName);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        
        #endregion
       
    }
}
