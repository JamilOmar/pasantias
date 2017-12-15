using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class usrCurso : wpUsrControl
    {
        CursoLogic cursoLogic = new CursoLogic();
        PaisLogic paisLogic = new PaisLogic();

        public event EventHandler Aceptar;
        public event EventHandler Cancelar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PaginaRecargada)
            {
                var idPersona = GetPersonaQueryString();
                var idCurso = GetCursoQueryString();
                if (idPersona.HasValue && idCurso.HasValue)
                {
                    LoadDatos();
                    MapControls(cursoLogic.Seleccionar(new Curso() { Id = idCurso, IdPersona = idPersona }));
                }
                else
                    LoadDatos();
            }
        }

        void LoadDatos()
        {
            paisDropDownList.DataSource = paisLogic.SeleccionarListaPaises();
            paisDropDownList.DataTextField = "Nombre";
            paisDropDownList.DataValueField = "Id";
            paisDropDownList.DataBind();
            paisDropDownList.SelectedValue = "-1";
        }


        void MapControls(Curso item)
        {
            nombreTextBox.Text = item.Nombre;
            paisDropDownList.SelectedValue = item.IdPais.ToString();
            institucionTextBox.Text = item.Institucion;
            fechaDateTime.SelectedDate = System.Convert.ToDateTime( item.Fecha);
            duracionTextBox.Text = item.Duracion.ToString();
            descipcionTextBox.Text = item.Descripcion;
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            var  newCurso = IsNewCursoQueryString(); 

            if (newCurso.HasValue)
            {
                if (newCurso.Value==true)
                    cursoLogic.Insertar(MapToEntity());
                else
                    cursoLogic.Actualizar(MapToEntity());
                    
            }
            if (Aceptar != null)
            {
                Aceptar(this, e);
            }
            else
                Ira(Properties.Pages.Default.Error, itemPasantias.Id.Value);
        }


        Curso MapToEntity()
        {
            Curso curso = new Curso();
            curso.Id = GetCursoQueryString();
            curso.IdPersona = GetPersonaQueryString();
            curso.IdPais = System.Convert.ToInt32(paisDropDownList.SelectedValue);
            curso.Nombre = nombreTextBox.Text;
            curso.Institucion = institucionTextBox.Text;
            curso.Fecha = fechaDateTime.SelectedDate;
            curso.Duracion = System.Convert.ToInt32(duracionTextBox.Text);
            curso.Descripcion = descipcionTextBox.Text;
       

            return curso;
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

    }
}
