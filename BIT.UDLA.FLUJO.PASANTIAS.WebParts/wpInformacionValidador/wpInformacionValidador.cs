using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpInformacionValidador
{
    [ToolboxItemAttribute(false)]
    public class wpInformacionValidador : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/BIT.UDLA.FLUJO.PASANTIAS.WebParts/wpInformacionValidador/wpInformacionValidadorUserControl.ascx";

        [WebBrowsable(true), Category("Avanzado UDLA"), WebDisplayName("Acceso Estudiante/Alumno"), WebDescription("Indica si la página actual puede Ser Accedida por Estudiante/Alumno"), Personalizable(PersonalizationScope.Shared)]
        public bool AllowAlumno { get; set; }
        [WebBrowsable(true), Category("Avanzado UDLA"), WebDisplayName("Acceso Todos"), WebDescription("Indica si la página actual puede Ser Accedida por Todos"), Personalizable(PersonalizationScope.Shared)]
        public bool AllowTodos { get; set; }

        [WebBrowsable(true), Category("Avanzado UDLA"), WebDisplayName("Acceso Docente"), WebDescription("Indica si la página actual puede Ser Accedida por el Docente"), Personalizable(PersonalizationScope.Shared)]
        public bool AllowDocente { get; set; }
        [WebBrowsable(true), Category("Avanzado UDLA"), WebDisplayName("Acceso Tutor"), WebDescription("Indica si la página actual puede Ser Accedida por el Tutor"), Personalizable(PersonalizationScope.Shared)]
        public bool AllowTutor { get; set; }
        [WebBrowsable(true), Category("Avanzado UDLA"), WebDisplayName("Acceso Empresa"), WebDescription("Indica si la página actual puede Ser Accedida por el Supervisor de la Empresa"), Personalizable(PersonalizationScope.Shared)]
        public bool AllowEmpresa { get; set; }
        [WebBrowsable(true), Category("Avanzado UDLA"), WebDisplayName("Acceso Tutor Especial"), WebDescription("Indica si la página actual puede Ser Accedida por el Tutor aun si no el estado es diferente al original"), Personalizable(PersonalizationScope.Shared)]
        public bool AllowTutorEspecial { get; set; }
        [WebBrowsable(true), Category("Avanzado UDLA"), WebDisplayName("Estado"), WebDescription("Estado para el Ingreso"), Personalizable(PersonalizationScope.Shared)]
        public string Estado { get; set; }
        protected override void CreateChildControls()
        {
            wpInformacionValidadorUserControl control = Page.LoadControl(_ascxPath) as wpInformacionValidadorUserControl;
            if (control != null)
            {
                control.WebPart = this;
            }
            Controls.Add(control);
        }
    }
}
