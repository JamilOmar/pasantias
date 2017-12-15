using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;

using Microsoft.SharePoint;
using System.Linq;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class usrRegistroActividades : wpUsrControl
    {

        public event EventHandler Aceptar;
        public event EventHandler Cancelar;
        public int? IdAsistencia
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
        public Actividades itemActividades
        {
            set
            {
                ViewState["itemActividades"] = value;
            }
            get
            {
                return (Actividades)ViewState["itemActividades"];
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

        ActividadesLogic actividadesLogic = new ActividadesLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PaginaRecargada)
            {
                var id = GetPasantiaQueryString();

                if (id.HasValue)
                {
                    itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);
                    EsNuevo = IsNewItem();
                    if (EsNuevo.HasValue && !EsNuevo.Value)
                    {
                        IdAsistencia = GetDynamicQueryStringIntValue("IdActividad");
                        itemActividades = actividadesLogic.SeleccionarPorId(IdAsistencia.Value);

                        if (itemActividades != null)
                        {

                            MapToControl(itemActividades);
                            EnableItem(false);
                        }
                        else
                            Ira("", null);
                    }else
                    EnableItem(true);


                }

            }
        }
        void MapToControl(Actividades item)
        {
            if (item.FechaFin.HasValue)
                fechaFinCalendar.SelectedDate = item.FechaFin.Value;
            if (item.FechaInicio.HasValue)
                fechaInicioCalendar.SelectedDate = item.FechaInicio.Value;
            ActividadesTextBox.Text = item.Actividad;
            numeroHorasEjecutadasTextBox.Text = item.Horas.ToString();
            DescripcionDocenteTextbox.Text = item.Observaciones;
            DescripcionEmpresaTextBox.Text = item.ObservacionesEmpresa;
        }
        Actividades MapToEntity(Actividades item)
        {

            item.Titulo = string.Format("Tarea de {0} a {1} ", fechaInicioCalendar.SelectedDate.ToShortDateString(), fechaFinCalendar.SelectedDate.ToShortDateString());
            item.FechaFin = fechaFinCalendar.SelectedDate;
            item.FechaInicio = fechaInicioCalendar.SelectedDate;
            item.Actividad = ActividadesTextBox.Text;
            item.Horas = double.Parse(numeroHorasEjecutadasTextBox.Text);
            item.Observaciones = DescripcionDocenteTextbox.Text;
            item.idPasantia = itemPasantias.Id.Value;
            item.ObservacionesEmpresa = DescripcionEmpresaTextBox.Text;
            return item;
        }
        void EnableItem(bool validated)
        {
            procesarUsrCommand.Visible = validated;
            trEmpresa.Visible = false;
            trDocente.Visible = false;
            fechaFinCalendar.Enabled =
            fechaInicioCalendar.Enabled =
        ActividadesTextBox.Enabled =
        numeroHorasEjecutadasTextBox.Enabled = validated;
            var docente = ValidarUsuario(itemPasantias, false, true, false, false);
            var empresa = ValidarUsuario(itemPasantias, false, false, false, true);
            var tutor = ValidarUsuario(itemPasantias, false, false, true, false);
            if (empresa)
            {
                procesarUsrCommand.Visible = true;
                trEmpresa.Visible = true;
            }else
            if (docente)
            {
                procesarUsrCommand.Visible = true;
                trEmpresa.Visible = true;
                DescripcionEmpresaTextBox.Enabled = false;
                trDocente.Visible = true;
             
            }else
            if (tutor)
            {
            
                trEmpresa.Visible = true;
                DescripcionEmpresaTextBox.Enabled = false;
                trDocente.Visible = true;
                procesarUsrCommand.Visible = false;
            }
        }
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
                            itemActividades = new Actividades();
                            int? id = 0;
                            actividadesLogic.Insertar(MapToEntity(itemActividades), out id);
                        }
                        else
                        {
                            actividadesLogic.Actualizar(MapToEntity(itemActividades));
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
                }else
                    Ira(Properties.Pages.Default.Error, itemPasantias.Id.Value);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }
        private bool Validar()
        {
            return !fechaFinCalendar.IsDateEmpty && !fechaInicioCalendar.IsDateEmpty
                 & fechaInicioCalendar.SelectedDate <= fechaFinCalendar.SelectedDate;

        }
     
     
    }
}
