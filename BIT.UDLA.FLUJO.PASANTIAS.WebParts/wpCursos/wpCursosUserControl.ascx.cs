using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpCursos
{
    public partial class wpCursosUserControl : wpUsrControl
    {
        #region Properties
        public int? idPersona
        {
            get
            {
                return ViewState["idPersona"] as int?;
            }
            set
            {
                ViewState["idPersona"] = value;
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

        CursoLogic cursoLogic = new CursoLogic(); 
        #endregion
        
        #region Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!PaginaRecargada)
                {
                    IdPeticion = GetPasantiaQueryString();
                    if (IdPeticion.HasValue)
                    {
                        itemPasantias = pasantiasLogic.SeleccionarPorId(IdPeticion.Value);
                        idPersona = (int)itemPasantias.PERID.Value;
                        if (idPersona.HasValue)
                        {
                            cursosSPGrid.DataSource = cursoLogic.SeleccionarCursos(idPersona.Value);
                            cursosSPGrid.DataBind();
                            CrearLinks();
                        }
                        else
                        {

                            FormUrl(Properties.Pages.Default.Error);
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

        #region Methods
        public string ObtenerLink(object id)
        {
            try
            {
                var s = string.Format("javascript:OpenDialog('{0}','{1}');", string.Format("{0}?idcurso={1}&idPersona={2}&New=false", FormUrl(Properties.Pages.Default.RegistroCurso),
                  id, idPersona.Value.ToString()), FormUrl(Properties.Pages.Default.Cursos) + "?IdPasantia=" + itemPasantias.Id.Value.ToString());
                return s;
            }
            catch (Exception ex)
            {
                ManejarError(ex);
                return null;
            }
        }

        protected void lnkbtnSeleccion_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var val = System.Convert.ToInt32(e.CommandArgument.ToString());
                cursoLogic.Eliminar(new Curso() { Id = val });
                Ira(Properties.Pages.Default.Cursos, itemPasantias.Id);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        public void CrearLinks()
        {
            try
            {

                this.hlNuevoCurso.Attributes.Add("onClick",
                    string.Format("javascript:OpenDialog('{0}','{1}' );",
                    string.Format("{0}?idpersona={1}&New=true",
                    FormUrl(Properties.Pages.Default.RegistroCurso),
                   idPersona.Value.ToString()),
                   FormUrl(Properties.Pages.Default.Cursos) + "?idPasantia=" + itemPasantias.Id.Value.ToString()));
            }
            catch (Exception ex)
            {
                ManejarError(ex);

            }
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            string matricula = itemPasantias.Matricula;
            pasantiasLogic.CambiarEstado(IdPeticion.Value, BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties.Flujo.Default.ACTUALIZACION_HOJA_DE_VIDA);
             Ira(Properties.Pages.Default.Empresas, itemPasantias.Id);
        
        }
        
        #endregion
    }
}
