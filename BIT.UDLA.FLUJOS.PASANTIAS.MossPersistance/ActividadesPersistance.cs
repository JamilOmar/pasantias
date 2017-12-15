using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using Microsoft.SharePoint.Linq;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
using Microsoft.SharePoint;
using System.Web;
using Microsoft.SharePoint.WebControls;

namespace BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance
{
    public class ActividadesPersistance
    {
       
        public bool Insertar(Actividades item, out int? id)
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
                    EntityList<ListaDeActividadesPorEstudianteElemento> actividades = context.GetList<ListaDeActividadesPorEstudianteElemento>(Properties.UdlaListDefinitions.Default.Lista_Actividades);
                    var itemBase = MappeoMoss(item);
                    itemBase.Identificador = null;
                    itemBase.IdPasantia = context.ListaPasantias.Where(x => x.Identificador == item.idPasantia).Take(1).ToList().First();
                    actividades.InsertOnSubmit(itemBase);
                    context.SubmitChanges();
                    auxId = itemBase.Identificador;
                    result =  true;
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
        public Actividades Actualizar(Actividades item)
        {
            Actividades actividad = null;
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
                                EntityList<ListaDeActividadesPorEstudianteElemento> actividades = context.GetList<ListaDeActividadesPorEstudianteElemento>(Properties.UdlaListDefinitions.Default.Lista_Actividades);
                                var visitaBase = context.ListaDeActividadesPorEstudiante.Where(x => x.Identificador == item.Id).Take(1).ToList().First(); ;
                                if (visitaBase != null)
                                {
                                    visitaBase = MappeoMoss(item, visitaBase);
                                    context.SubmitChanges();
                                    actividad = MappeoMoss(visitaBase);
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
            return actividad;
        }
        public List<Actividades> SeleccionarPaginado(int startRowIndex, int maximumRows, int idPasantia, out int itemsCount)
        {
            itemsCount = 0;
            using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
            {

                EntityList<ListaDeActividadesPorEstudianteElemento> actividades = context.GetList<ListaDeActividadesPorEstudianteElemento>(Properties.UdlaListDefinitions.Default.Lista_Actividades);

                itemsCount = actividades.Where(x => x.IdPasantia.Identificador == idPasantia).Count();
                var data = actividades.Where(x => x.IdPasantia.Identificador == idPasantia).Skip(startRowIndex).Take(maximumRows);


                if (data != null)
                {
                    List<Actividades> actividadesItem = new List<Actividades>();
                    data.ToList().ForEach(x => actividadesItem.Add(MappeoMoss(x)));
                    return actividadesItem;
                }
            }
            return null;
        }
        public Actividades SeleccionarPorId(int id)
        {

            using (UdlaEntityDataContext context = new UdlaEntityDataContext(Properties.UdlaListDefinitions.Default.Url_Sitio))
            {
                EntityList<ListaDeActividadesPorEstudianteElemento> actividades = context.GetList<ListaDeActividadesPorEstudianteElemento>(Properties.UdlaListDefinitions.Default.Lista_Actividades);
                var data = actividades.Where(x => x.Identificador == id).Take(1).ToList().First(); ;
                if (data != null)
                {

                    return MappeoMoss(data);
                }
            }
            return null;
        }
        public Actividades MappeoMoss(ListaDeActividadesPorEstudianteElemento item)
        {


            Actividades visita = new Actividades();
            visita.Actividad = item.Actividades;
            visita.FechaFin = item.FechaFin;
            visita.FechaInicio = item.FechaInicio;
            visita.Horas = item.Horas;
            visita.Id = item.Identificador.Value;
            visita.Observaciones = item.Observaciones;
            visita.ObservacionesEmpresa = item.ObservacionesEmpresa;
            visita.Titulo = item.Título;
            return visita;

        }
        public ListaDeActividadesPorEstudianteElemento MappeoMoss(Actividades item, ListaDeActividadesPorEstudianteElemento visita)
        {


            visita.Actividades = item.Actividad;
            visita.FechaFin = item.FechaFin;
            visita.FechaInicio = item.FechaInicio;
            visita.Horas = item.Horas;
            visita.Observaciones = item.Observaciones;
            visita.ObservacionesEmpresa = item.ObservacionesEmpresa;
            visita.Título = item.Titulo;
            return visita;

        }
        private ListaDeActividadesPorEstudianteElemento MappeoMoss(Actividades item)
        {
            ListaDeActividadesPorEstudianteElemento visita = new ListaDeActividadesPorEstudianteElemento();

            visita.Actividades = item.Actividad;
            visita.FechaFin = item.FechaFin;
            visita.FechaInicio = item.FechaInicio;
            visita.Horas = item.Horas;
            visita.Identificador = item.Id;
            visita.Observaciones = item.Observaciones;
            visita.ObservacionesEmpresa = item.ObservacionesEmpresa;
            visita.Título = item.Titulo;
            return visita;

        }
    }
}
