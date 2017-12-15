using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using System.Collections.Generic;
using BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts;


namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpActualizarNota
{
    public partial class wpActualizarNotaUserControl:  wpUsrControl
    {
       

        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!PaginaRecargada)
                {
                    ((this.usrCommand1) as usrCommand).MostrarMensaje = true;
                    ((this.usrCommand1) as usrCommand).Mensaje = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.MensajeConfirmacionHorasSaes;
            
                    var id = GetPasantiaQueryString();
                    if (id.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(id.Value);
                        if (itemPasantias == null)
                            itemPasantias = new PasantiasPreProfesionales();
                        if(itemPasantias.TipoPasantiaEnum.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION))
                            CargarHoras();
                        MapToControl(itemPasantias);
                    }
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        void CargarHoras()
        {
            itemPasantias.HorasActualesEnElSistemaSAES = ObtenerHorasActuales(itemPasantias);
            itemPasantias.MaximoHorasMateria = ObtenerMaximoHoras(itemPasantias);
            if(itemPasantias.TipoPasantiaEnum == BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION)
               lblMaximoHoras.Text =(itemPasantias.MaximoHorasMateria.HasValue) ? itemPasantias.MaximoHorasMateria.Value.ToString():"0";
            else
            lblMaximoHoras.Text = ((((itemPasantias.MaximoHorasMateria.HasValue) ? itemPasantias.MaximoHorasMateria.Value:0)) -((itemPasantias.HorasActualesEnElSistemaSAES.HasValue)?itemPasantias.HorasActualesEnElSistemaSAES.Value:0)).ToString();
        }

        #endregion

        #region Mappers
        void MapToControl(PasantiasPreProfesionales item)
        {
      
            if(itemPasantias.TipoPasantiaEnum.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_TRABAJO))
            txtNota.Text = (item.HorasAprobadasPorEmpresa.HasValue) ? item.HorasAprobadasPorEmpresa.Value.ToString() : "0";
            else
                txtNota.Text = (item.HorasRevisadasTutor.HasValue) ? item.HorasRevisadasTutor.Value.ToString() : "0";
            if (!string.IsNullOrEmpty(item.CodigoCarrera))
            {
                ddlMateria.DataSource = CargarMateriasAlumno(item.CodigoCarrera, item.PlanAlumno.ToString(), item.CodigoEspecialidad, item.TipoPasantiaEnum,item.Matricula);
                ddlMateria.DataValueField = "ID";
                ddlMateria.DataTextField = "Nombre";
                ddlMateria.DataBind();
                ddlMateria.SelectedValue = "-1";
                if (itemPasantias.TipoPasantiaEnum.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION))
                {
                    ddlMateria.SelectedValue = itemPasantias.CodigoDeMateria;
                }
            }
        }

        PasantiasPreProfesionales MapToEntity()
        {
            itemPasantias.CodigoDeMateria = ddlMateria.SelectedValue;
            itemPasantias.NumeroHorasEjecutadas = int.Parse(txtNota.Text);
            itemPasantias.HorasAprobadasTutor = int.Parse(txtNota.Text);
            itemPasantias.Materia = ddlMateria.SelectedItem.Text;
            itemPasantias.FechaDeIngresoEnElSistemaSAES = DateTime.Now;
            itemPasantias.FechaFinProcesoPractica = DateTime.Now;
            itemPasantias.HorasIngresadasSAES = int.Parse(txtNota.Text);
            itemPasantias.AprobacionTutorIngresoHorasSAES = true;
            itemPasantias.AprobadoPorTutorParaRegistroEnSAES = true;
            itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.FINALIZACION;
            itemPasantias.ObservacionesDeRegistroDeHorasSAES = txtObservacion.Text;
            itemPasantias.FinPractica = true;
            return itemPasantias;
        } 
        #endregion

        #region Methods
        protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMateria.SelectedValue != "-1")
            {
                itemPasantias.CodigoDeMateria = ddlMateria.SelectedValue;
                CargarHoras();
            }
        }
        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "";
                if (!GuardarNota(MapToEntity(), out mensaje)) 
                    throw new Exception(mensaje);

                pasantiasLogic.Actualizar(itemPasantias);

                Ira(Properties.Pages.Default.Finalizada, itemPasantias.Id.Value);
            }
            catch (Exception ex)
            {
                ManejarErrorNoRedirect(ex);
                lblError.Text = ex.Message;
                lblError.Visible = true;
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
                ManejarErrorNoRedirect(ex);

            }
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
        void Limpiar()
        {
            txtNota.Text = string.Empty;
        }
        public List<Materia> CargarMateriasAlumno(string carrera, string plan, string especialidad, string tipo,string matricula)
        {
            MateriaLogic obj = new MateriaLogic();
            var data = obj.SeleccionarListaMaterias(carrera, plan, especialidad, tipo,matricula);
            data.Add(new Materia
            {
                ID = "-1",
                Nombre = "[SELECCIONE UNA MATERIA]"
            });
            return data;
        }

        public bool GuardarNota(PasantiasPreProfesionales item, out string mensaje)
        {
            MateriaLogic obj = new MateriaLogic();
            return obj.GuardarNota(item, out mensaje);
        }

        public int ObtenerMaximoHoras(PasantiasPreProfesionales item)
        {
            MateriaLogic obj = new MateriaLogic();
            Materia materia =(item.TipoPasantiaEnum.Equals(BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION))?obj.SeleccionarPorIdSupervision(item.CodigoDeMateria,item.Matricula): obj.SeleccionarPorId(item.CodigoDeMateria);

            if (materia != null)
                return materia.Horas;

            return 0;
        }

        public int ObtenerHorasActuales(PasantiasPreProfesionales item)
        {
            MateriaLogic obj = new MateriaLogic();
            return obj.ObtenerHorasActuales(item);
        }
        #endregion

       

   
    }
}
