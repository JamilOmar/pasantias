using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.ControlTemplates.BIT.UDLA.FLUJO.PASANTIAS.WebParts
{
    public partial class usrPager : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public int NumeroItemsPorPagina { get; set; }
        public int? MaximoNumeroItems
        {
            set
            {
                ViewState["MaximoNumeroItems"] = value;
            }
            get
            {
                return (int?)ViewState["MaximoNumeroItems"];
            }

        }
        public int PaginaActual
        {
            set
            {
                ViewState["PaginaActual"] = value;
            }
            get
            {
                if (ViewState["PaginaActual"] == null)
                    return 0;
                return (int)ViewState["PaginaActual"];
            }

        }

        public int NumeroTotalPaginas()
        {
            if (MaximoNumeroItems.HasValue)
            {
                if (MaximoNumeroItems > 0)
                {
                    var data = MaximoNumeroItems / NumeroItemsPorPagina;
                    var mod = MaximoNumeroItems % NumeroItemsPorPagina;
                    if (mod > 0)
                        data++;
                    return data.Value;
                }
            }
            return 0;
        }
        public event EventHandler Atras,Adelante;
        
        protected void lnkAtras_Click(object sender, EventArgs e)
        {
            if (PaginaActual != null)
            Atras(this, e);
           
        }
        public void Cargar()
        {
            var pags = NumeroTotalPaginas();
            this.lnkAdelante.Enabled = this.lnkAtras.Enabled = (pags > 0);
            this.lnkAdelante.Enabled = (pags > PaginaActual+1);
            if (pags > 0)
            {
                this.lblPaginas.Text = string.Format("Página {0} de {1}", PaginaActual+1 , pags );
            }
            else
            {
                this.lblPaginas.Text = "No hay Datos";
            }
        }
        protected void lnkAdelante_Click(object sender, EventArgs e)
        {
           if(PaginaActual !=null)
                Adelante(this, e);

        }

    }
}
