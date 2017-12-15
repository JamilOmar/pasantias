using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using System.Linq;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class usrRegistroVisitas: wpUsrControl
    {

        #region Items
        public event EventHandler Aceptar;
        public event EventHandler Cancelar;
        public VisitasLogic visitasLogic = new VisitasLogic();
        public Visitas itemVisitas
        {
            set
            {
                ViewState["itemVisitas"] = value;
            }
            get
            {
                return (Visitas)ViewState["itemVisitas"];
            }

        }
        public int? IdActividad
        {
            set
            {
                ViewState["IdActividad"] = value;
            }
            get
            {
                return (int?)ViewState["IdActividad"];
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
        #endregion

        #region Mappers
        void MapToControl(Visitas item)
        {


            if (item.FechaVisita.HasValue)
                fechaFinCalendar.SelectedDate = item.FechaVisita.Value;
            lblUsuario.Text = itemPasantias.NombreSaes;
            cargoTextBox.Text = item.Observaciones;
        }
        Visitas MapToEntity(Visitas item)
        {

            item.Titulo = "Visita  " + fechaFinCalendar.SelectedDate.ToShortDateString();
            item.FechaVisita = fechaFinCalendar.SelectedDate;
            item.NombreEstudiante = itemPasantias.NombreSaes;
            item.Observaciones = cargoTextBox.Text;
            item.idPasantia = itemPasantias.Id.Value;
            return item;
        } 
        #endregion

        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!PaginaRecargada)
                {
                    var id = GetPasantiaQueryString();

                    if (id.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);
                        lblUsuario.Text = itemPasantias.NombreSaes;
                        EsNuevo = IsNewItem();
                        if (EsNuevo.HasValue && !EsNuevo.Value)
                        {
                            EnableItems(false);
                            IdActividad = GetDynamicQueryStringIntValue("IdActividad");
                            if (IdActividad.HasValue)
                            {
                                itemVisitas = visitasLogic.SeleccionarPorId(IdActividad.Value);
                                if (itemVisitas == null) Ira("", null);
                                MapToControl(itemVisitas);
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

        #region Events
        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    if (EsNuevo.HasValue)
                    {
                        if (EsNuevo.Value)
                        {
                            int? id = 0;
                            itemVisitas = new Visitas();
                            visitasLogic.Insertar(MapToEntity(itemVisitas), out id);
                        }
                        else
                        {
                            visitasLogic.Actualizar(MapToEntity(itemVisitas));
                        }

                    }
                    if (Aceptar != null)
                    {
                        Aceptar(this, e);
                    }
                    else
                        Ira(Properties.Pages.Default.Error, itemPasantias.Id.Value);
                }
                else
                    lblError.Visible = true;
            }
            catch (Exception ex)
            {
                ManejarError(ex);

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
                else
                    Ira(Properties.Pages.Default.Error, itemPasantias.Id.Value);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        void EnableItems(bool enable)
        {
            procesarUsrCommand.Visible = enable;
            this.fechaFinCalendar.Enabled =
                cargoTextBox.Enabled = enable;
        }
        bool Validar()
        {
            return !fechaFinCalendar.IsDateEmpty;
        }
        #endregion    

     
    }
}
