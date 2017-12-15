using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpEmpresas
{
    public partial class wpEmpresasUserControl : wpUsrControl
    {
        #region Properties
        EmpresaLogic empresaLogic = new EmpresaLogic();
        OfertaLogic ofertaLogic = new OfertaLogic();
        public bool EsOferta
        {
            set
            {
                ViewState["EsOferta"] = value;
            }
            get
            {
                return ViewState["EsOferta"] == null ? true : Convert.ToBoolean(ViewState["EsOferta"]);
            }
        }
        public int? IdPeticion
        {
            set
            {
                ViewState["IdPeticion"] = value;
            }
            get
            {
                return (int?)ViewState["IdPeticion"];
            }
        }
        public int? IdOferta
        {
            set
            {
                ViewState["IdOferta"] = value;
            }
            get
            {
                return (int?)ViewState["IdOferta"];
            }
        }
        public Empresa empresa
        {
            set
            {
                ViewState["empresa"] = value;
            }
            get
            {
                return (Empresa)ViewState["empresa"];
            }

        } 
        #endregion

        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int idEmpresa = System.Convert.ToInt32(Request["ide"]);
                IdOferta = (Request["ofertaID"] == null) ? 0 : int.Parse(Request["ofertaID"].ToString());
                EsOferta = (Request["oferta"] == null) ? false : bool.Parse(Request["oferta"].ToString());
                string accion = Request["modo"] == null ? string.Empty : System.Convert.ToString(Request["modo"]);
                IdPeticion = GetPasantiaQueryString();

                if ((idEmpresa > 0)
                    && (accion.Length > 0)
                    && !PaginaRecargada)
                {
                    empresa = empresaLogic.SeleccionarPorId(idEmpresa);
                    if (empresa == null)
                        empresa = new Empresa();

                    MapEmpresaToControl(empresa);
                    SwitchModo(accion);

                    if (IdPeticion.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(IdPeticion.Value);
                        MapPeticionToControl(itemPasantias);

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
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                itemPasantias = MapControltoPeticion(System.Convert.ToInt64(Request["ide"]));
                if (EsOferta)
                {
                    itemPasantias.IDOfertaLaboral = IdOferta;
                    itemPasantias = ofertaLogic.Insertar(itemPasantias);
                }
                pasantiasLogic.Actualizar(itemPasantias);
                Ira(Properties.Pages.Default.MensajePageName, IdPeticion.Value);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        PasantiasPreProfesionales MapControltoPeticion(long? idEmpresa)
        {
            itemPasantias.Empresa = nombreComercialTextBox.Text;
            itemPasantias.IdEmpresa = idEmpresa;
            itemPasantias.AreaTrabajo = areaTextBox.Text;
            itemPasantias.NombreSupervisor = nombreSupervisorTextBox.Text;
            itemPasantias.TelefonoSupervisor = telefonoSupervisorTextBox.Text;
            itemPasantias.EmailSupervisor = emailSupervisorTextBox.Text;
            itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.EMPRESA_SELECCIONADA;
            itemPasantias.TelefonoEmpresa = empresa.Telefono;
            itemPasantias.DireccionEmpresa = empresa.Direccion;
            return itemPasantias;
        }
        Empresa MapControlToEmpresa()
        {
            return new Empresa()
            {
                NombreComercial = nombreComercialTextBox.Text
            };
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
           //if (itemPasantias.TipoPasantiaEnum == BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_TRABAJO)
                Ira(Properties.Pages.Default.Empresas, itemPasantias.Id);
           // else
            //    Ira(Properties.Pages.Default.RutaEmpresaOfertas, itemPasantias.Id);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        void SwitchModo(string modo)
        {
            switch (modo.ToLower())
            {

                default:
                    SoloLecturaEmpresa(true);
                    SoloLecturaSupervisor(false);

                    break;
            }
        }

        void SoloLecturaEmpresa(bool readOnly)
        {
            nombreComercialTextBox.Enabled = readOnly;
        }

        void SoloLecturaSupervisor(bool readOnly)
        {
            nombreSupervisorTextBox.ReadOnly = readOnly;
            telefonoSupervisorTextBox.ReadOnly = readOnly;
            emailSupervisorTextBox.ReadOnly = readOnly;
        }

        void Limpiar()
        {
            nombreComercialTextBox.Text =
            nombreSupervisorTextBox.Text =
            telefonoSupervisorTextBox.Text = emailSupervisorTextBox.Text = string.Empty;
        }

        void MapEmpresaToControl(Empresa item)
        {
            nombreComercialTextBox.Text = item.RazonSocial;
            if (EsOferta)
            {
                var val = IdOferta.Value;
                if (val == 0)
                    throw new Exception("Oferta no puede ser 0");
                isOferta(val);
            }
        }

        void MapPeticionToControl(PasantiasPreProfesionales item)
        {
            areaTextBox.Text = item.AreaTrabajo;
            nombreSupervisorTextBox.Text = item.NombreSupervisor;
            telefonoSupervisorTextBox.Text = item.TelefonoSupervisor;
            emailSupervisorTextBox.Text = item.EmailSupervisor;
        }

        void isOferta(int idOferta)
        {
            trOfertas.Visible = true;
            var oferta = ofertaLogic.SeleccionarPorId(idOferta);
            lblOferta.Text = oferta.Titulo;
            lblDescripcion.Text = oferta.Descripcion;
            lblModalidad.Text = oferta.NombreModalidad;
            lblCiudad.Text = oferta.NombreCiudad;
            nombreSupervisorTextBox.Text = oferta.Contacto;
            telefonoSupervisorTextBox.Text = oferta.Telefono;
            emailSupervisorTextBox.Text = oferta.Email;
            areaTextBox.Text = oferta.Titulo;
        }
        
        #endregion
       
    }
}