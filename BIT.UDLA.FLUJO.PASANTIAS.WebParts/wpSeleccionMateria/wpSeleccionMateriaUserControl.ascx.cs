using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpSeleccionMateria
{
    public partial class wpSeleccionMateriaUserControl : wpUsrControl
    {
       

        #region Load

        public List<Materia> Materias { get {
            if (ViewState["Materias"] != null)
                return ViewState["Materias"] as List<Materia>;
            else {
                return new List<Materia>();
            }
        } set {

            ViewState["Materias"] = value;
        }
        
        }

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

        #region Mappers
        void MapToControl(PasantiasPreProfesionales item)
        {
          
            if (!string.IsNullOrEmpty(item.CodigoCarrera))
            {
                Materias = CargarMateriasAlumno(item.CodigoCarrera, item.PlanAlumno.ToString(), item.CodigoEspecialidad, item.TipoPasantiaEnum,item.Matricula);
                Materias.Add(new Materia
                {
                    ID = "-1",
                    Nombre = "[SELECCIONE UNA MATERIA]"
                });
                ddlMateria.DataSource = Materias;
                ddlMateria.DataValueField = "ID";
                ddlMateria.DataTextField = "Nombre";
                ddlMateria.DataBind();
                ddlMateria.SelectedValue = "-1";
            }
        }
        PasantiasPreProfesionales MapToEntity()
        {
            itemPasantias.Materia = ddlMateria.SelectedItem.Text;
            itemPasantias.CodigoDeMateria = ddlMateria.SelectedItem.Value;
            itemPasantias.Estado = BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_PRACTICA;  //BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.SELECCION_USUARIO_DOCENTE;
            MateriaLogic obj = new MateriaLogic();
            Materia materia = obj.SeleccionarPorId(ddlMateria.SelectedValue);
            string mensaje = string.Empty;
            itemPasantias.NombreDocenteSAES = materia.Docente;
            itemPasantias.DocenteIdentificador = obj.ObtenerDocenteMOSSID(materia.DocenteID, out mensaje);
            itemPasantias.CedulaDocente = materia.DocenteID;
            if (itemPasantias.DocenteIdentificador < 0)
                ManejarError(new Exception(mensaje));

            return itemPasantias;
        }
        #endregion

        #region Metodos


        protected void btnCancelarFlujo_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemPasantias != null)
                {
                    CancelarFlujo(true,BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Mensajes.Default.MensajeCanceladoTutor);
                    Ira(Properties.Pages.Default.Finalizada, itemPasantias.Id.Value);
                }
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMateria.SelectedValue != "-1")
                {
                    lblMateriaName.Text = Materias.FirstOrDefault(x => x.ID == ddlMateria.SelectedValue).Docente;
                }
            }
            catch (Exception ex)
            {
                ManejarErrorNoRedirect(ex);

            }
        }
        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            try
            {
                pasantiasLogic.Actualizar(MapToEntity());
                Ira(Properties.Pages.Default.HojaDeVida, itemPasantias.Id.Value);
                //Ira(Properties.Pages.Default.MensajePageName, itemPasantias.Id.Value);
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
                Ira(Properties.Pages.Default.Home, null);
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }
        void Limpiar()
        {
           lblMateriaName.Text = string.Empty;
        }
        public List<Materia> CargarMateriasAlumno(string carrera, string plan, string especialidad, string tipo,string matricula)
        {
            MateriaLogic obj = new MateriaLogic();
            return obj.SeleccionarListaMaterias(carrera, plan, especialidad, tipo,matricula);
        }
        #endregion

      

     
    }
}
