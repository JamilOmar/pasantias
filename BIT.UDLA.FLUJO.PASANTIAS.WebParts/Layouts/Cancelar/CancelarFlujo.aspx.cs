﻿using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.Layouts.Dialogs
{
    public partial class CancelarFlujo : DialogLayoutsPageBage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Cancelar(object sender, EventArgs e)
        {

            Web.Update(); EndOperation(1, "null");

        }
        public void Aceptar(object sender, EventArgs e)
        {
            if (IsValid)
            {
                {
                    Web.Update(); EndOperation(1);
                }
            }
        }
    }
}
