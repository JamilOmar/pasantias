using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;

namespace WimdowsControls.Web.UI
{
    public class RequiredTextBox : TextBox
    {
        public int MaxLines { get; set; }

        protected override void OnInit(EventArgs e)
        {
            this.TextMode = TextBoxMode.MultiLine;
            string keypress = string.Format(BIT.UDLA.FLUJOS.PASANTIAS.Comun.Properties.Parametros.Default.KeyPress, this.MaxLines, this.MaxLength);
            string paste = string.Format(BIT.UDLA.FLUJOS.PASANTIAS.Comun.Properties.Parametros.Default.Paste, this.MaxLines, this.MaxLength);
            this.Attributes.Add("onkeypress", keypress);
            this.Attributes.Add("onpaste", paste);
        }

        protected override void Render(HtmlTextWriter w)
        {
            base.Render(w);
        }
    }
}
