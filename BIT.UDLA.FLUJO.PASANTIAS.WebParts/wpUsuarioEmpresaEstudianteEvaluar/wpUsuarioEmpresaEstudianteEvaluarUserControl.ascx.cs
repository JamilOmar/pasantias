using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Constants;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpUsuarioEmpresaEstudianteEvaluar
{
    public partial class wpUsuarioEmpresaEstudianteEvaluarUserControl : wpUsrControl
    {
    

        #region load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!PaginaRecargada)
                {
                    fechaFinCalendar.SelectedDate = DateTime.Now;
                        fechaInicioCalendar.SelectedDate = DateTime.Now;

                    var id = GetPasantiaQueryString();
                    if (id.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);
                        if (itemPasantias == null)
                            itemPasantias = new PasantiasPreProfesionales();
                        MapToControl(itemPasantias);
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

        private bool Validar()
        {
            return !fechaFinCalendar.IsDateEmpty && !fechaInicioCalendar.IsDateEmpty
                 & fechaInicioCalendar.SelectedDate <= fechaFinCalendar.SelectedDate;

        }

        protected void btnCancelarFlujo_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemPasantias != null)
                {
                    CancelarFlujo(true, BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.MensajeCanceladoTutor);
                    Ira(Properties.Pages.Default.Finalizada, itemPasantias.Id.Value);
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    if (ValidarConfirmacion())
                    {
                        pasantiasLogic.Actualizar(MapToEntity());
                        if (itemPasantias.Estado == BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REGISTRO_TUTOR)
                            Ira(Properties.Pages.Default.EvaluacionEstudiante, itemPasantias.Id.Value);
                        else
                            Ira(Properties.Pages.Default.MensajePageName, itemPasantias.Id.Value);
                    }
                    else
                        lblErrorRegistro.Visible = true;
                }
                else
                {
                    lblError.Visible = true;
                    
                }
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
                Ira(Properties.Pages.Default.Home, null);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        void Limpiar()
        {
            cargoTextBox.Text = areaTrabajoTextBox.Text = funcionesTextBox.Text = txtNumeroHorasEjecutadasEmpresa.Text=
            txtNumeroHorasEjecutarTutor.Text= string.Empty;
        } 
        #endregion

        #region Mappers
        void MapToControl(PasantiasPreProfesionales item)
        {
          
            cargoTextBox.Text = item.Cargo;
            areaTrabajoTextBox.Text = item.AreaTrabajo;
            funcionesTextBox.Text = item.Funciones;
            if (item.FechaInicio.HasValue)
                fechaInicioCalendar.SelectedDate = (DateTime)item.FechaInicio;
            if (item.FechaFin.HasValue)
                fechaFinCalendar.SelectedDate = (DateTime)item.FechaFin;
            if (item.HorarioTrabajo.HasValue)
                horarioTrabajoDropDownList.SelectedIndex = (item.HorarioTrabajo.Value == HorarioTrabajo.MedioTiempo) ? 0 : 1;
            txtNumeroHorasEjecutadasEmpresa.Text = item.HorasAprobadasPorEmpresa.ToString();
            txtNumeroHorasEjecutarTutor.Text = item.HorasAprobadasTutor.ToString();
            ((this.procesarUsrCommand) as usrCommand).MostrarMensaje = true;
            if (itemPasantias.Estado.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ASIGNACION_EMPRESA))
            {
                pnlEmpresasUno.Visible = true;
                pnlEmpresasDos.Visible = false;
                pnlTutoresUno.Visible = false;
                ((this.procesarUsrCommand) as usrCommand).Mensaje = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.MensajeConfirmacionFichaEmpresa;
            }else
                if (itemPasantias.Estado.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REVISION_TUTOR))
            {

                pnlEmpresasUno.Enabled = false;
                pnlEmpresasDos.Visible = false;
                pnlTutoresUno.Visible = true;
                ((this.procesarUsrCommand) as usrCommand).EliminarVisible = true;
                ((this.procesarUsrCommand) as usrCommand).Mensaje = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.MensajeConfirmacionFichaTutor;
            }else
                    if (itemPasantias.Estado.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CONFIRMACION_EMPRESA))
            {
                pnlEmpresasUno.Enabled = false;
                pnlEmpresasDos.Visible = true;
                pnlTutoresUno.Visible = false;
                ((this.procesarUsrCommand) as usrCommand).Mensaje = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.MensajeConfirmacionFichaEmpresaConfirmar;
            }

        }

        PasantiasPreProfesionales MapToEntity()
        {

            if (itemPasantias.Estado.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ASIGNACION_EMPRESA))
            {
                itemPasantias.FichaDeInscripcionAprobadaPorEmpresa = true;
                itemPasantias.Cargo = cargoTextBox.Text;
                itemPasantias.AreaTrabajo = areaTrabajoTextBox.Text;
                itemPasantias.Funciones = funcionesTextBox.Text;
                itemPasantias.FechaInicio = fechaInicioCalendar.SelectedDate;
                itemPasantias.FechaFin = fechaFinCalendar.SelectedDate;
                itemPasantias.HorarioTrabajo = (horarioTrabajoDropDownList.SelectedIndex == 0) ? HorarioTrabajo.MedioTiempo : HorarioTrabajo.TiempoCompleto;
                itemPasantias.HorasAprobadasPorEmpresa = double.Parse(txtNumeroHorasEjecutadasEmpresa.Text);
                itemPasantias.Estado = (itemPasantias.TipoPasantiaEnum == FlujoConstantes.CON_TRABAJO) ? BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REGISTRO_TUTOR : BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REVISION_TUTOR;
                itemPasantias.FechaAprobacionEmpresa = DateTime.Now;
            }else
                if (itemPasantias.Estado.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REVISION_TUTOR))
            {


                itemPasantias.FichaDeInscripcionAprobadaPorTutor = true;
                itemPasantias.FechaAprobacionTutor = DateTime.Now;
                itemPasantias.HorasRevisadasTutor = double.Parse(txtNumeroHorasEjecutarTutor.Text);
                itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CONFIRMACION_EMPRESA;

            }else
                    if (itemPasantias.Estado.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CONFIRMACION_EMPRESA))
            {
              
                itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.REGISTRO_TUTOR;
                itemPasantias.FechaFin = DateTime.Now;
            }



            return itemPasantias;
        }

        bool ValidarConfirmacion()
        {
            if (!itemPasantias.Estado.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.CONFIRMACION_EMPRESA))
            {
                return true;
            }
            else
                return chckConfirmacion.Checked;
        }
        #endregion

        
    }
}
