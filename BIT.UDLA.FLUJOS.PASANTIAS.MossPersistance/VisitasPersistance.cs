using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using Microsoft.SharePoint.Linq;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
using Microsoft.SharePoint;
using System.Web;
using Microsoft.SharePoint.WebControls;

namespace BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance
{
    public class VisitasPersistance : LogicBase<Visitas, ListaVisitasElemento>
    {
        public bool Insertar(Visitas item, out int? id)
        {
            
                bool result = false;
            int? auxId = 0;
             string strUrl = Properties.UdlaListDefinitions.Default.Url_Sitio;
            try
            {
                  if (SPContext.Current != null)
                    HttpContext.Current = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(strUrl))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {

                            HttpRequest httpRequest = new HttpRequest("", oWeb.Url, "");
                            HttpContext.Current = new HttpContext(httpRequest, new HttpResponse(new System.IO.StringWriter()));
                            SPControl.SetContextWeb(HttpContext.Current, oWeb);
                            using (UdlaEntityDataContext context = new UdlaEntityDataContext(oWeb.Url))

                         {
                    EntityList<ListaVisitasElemento> visitas = context.GetList<ListaVisitasElemento>(Properties.UdlaListDefinitions.Default.Lista_Visitas);
                    var itemBase = MappeoMoss(item);
                    itemBase.Identificador = null;
                    itemBase.IdPasantia = context.ListaPasantias.Where(x => x.Identificador == item.idPasantia).Take(1).ToList().First(); ;
                    visitas.InsertOnSubmit(itemBase);
                    context.SubmitChanges();
                    auxId = itemBase.Identificador;
                    result = true;
                         }
                        }
                    }
                }
                  );
            }
            catch (Exception ex)
            {
                auxId = 0;
                Logger.ExLogger(ex);
                throw ex;
            }
            id = auxId;
            return result;
        }
        public Visitas Actualizar(Visitas item)
        {
            Visitas visita = null;
            string strUrl = Properties.UdlaListDefinitions.Default.Url_Sitio;
            try
            {
                if (SPContext.Current != null)
                    HttpContext.Current = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite oSite = new SPSite(strUrl))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {

                            HttpRequest httpRequest = new HttpRequest("", oWeb.Url, "");
                            HttpContext.Current = new HttpContext(httpRequest, new HttpResponse(new System.IO.StringWriter()));
                            SPControl.SetContextWeb(HttpContext.Current, oWeb);
                            using (UdlaEntityDataContext context = new UdlaEntityDataContext(oWeb.Url))
                            {
                                EntityList<ListaVisitasElemento> visitas = context.GetList<ListaVisitasElemento>(Properties.UdlaListDefinitions.Default.Lista_Visitas);
                                var visitaBase = visitas.Where(x => x.Identificador == item.Id).Take(1).ToList().First(); ;
                                if (visitaBase != null)
                                {
                                    visitaBase = MappeoMoss(item, visitaBase);
                                    context.SubmitChanges();
                                    visita = MappeoMoss(visitaBase);
                                }
                            }
                        }
                    }
                }
                  );
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return visita;
        }
        public List<Visitas> SeleccionarPaginado(int startRowIndex, int maximumRows, int idPasantia, out int itemsCount)
        {
            itemsCount = 0;
            using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
            {
                EntityList<ListaVisitasElemento> visitas = context.GetList<ListaVisitasElemento>(Properties.UdlaListDefinitions.Default.Lista_Visitas);
                itemsCount = visitas.Where(x => x.IdPasantia.Identificador == idPasantia).Count();
                var data = visitas.Where(x => x.IdPasantia.Identificador == idPasantia).Skip(startRowIndex).Take(maximumRows);


                if (data != null)
                {
                    List<Visitas> itemVisitas = new List<Visitas>();
                    data.ToList().ForEach(x => itemVisitas.Add(MappeoMoss(x)));
                    return itemVisitas;
                }
            }
            return null;
        }
        public Visitas SeleccionarPorId(int id)
        {

            using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
            {
                EntityList<ListaVisitasElemento> visitas = context.GetList<ListaVisitasElemento>(Properties.UdlaListDefinitions.Default.Lista_Visitas);
                var data = visitas.Where(x => x.Identificador == id).Take(1).ToList().First(); ;


                if (data != null)
                {

                    return MappeoMoss(data);
                }
            }
            return null;
        }

        public Visitas MappeoMoss(ListaVisitasElemento visita)
        {


            Visitas item = new Visitas();
            item.FechaVisita = visita.FechaVisita;
            item.idPasantia = visita.IdPasantia.Identificador.Value;
            item.NombreEstudiante = visita.NombreEstudiante;
            item.Observaciones = visita.Observaciones;
            item.Titulo = visita.Título;
            item.Id = visita.Identificador.Value;
            return item;

        }
        public ListaVisitasElemento MappeoMoss(Visitas item, ListaVisitasElemento visita)
        {


            visita.FechaVisita = item.FechaVisita;

            visita.NombreEstudiante = item.NombreEstudiante;
            visita.Observaciones = item.Observaciones;
            visita.Título = item.Titulo;
            visita.Identificador = item.Id;
            return visita;

        }
        private ListaVisitasElemento MappeoMoss(Visitas item)
        {
            ListaVisitasElemento visita = new ListaVisitasElemento();
            visita.FechaVisita = item.FechaVisita;
            visita.NombreEstudiante = item.NombreEstudiante;
            visita.Observaciones = item.Observaciones;
            visita.Título = item.Titulo;
            visita.Identificador = item.Id;
            return visita;

        }
    }
}
