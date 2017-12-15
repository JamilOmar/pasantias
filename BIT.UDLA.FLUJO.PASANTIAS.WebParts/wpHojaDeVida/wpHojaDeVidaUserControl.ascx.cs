using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using System.Linq;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
namespace BIT.UDLA.FLUJO.PASANTIAS.WebParts.wpHojaDeVida
{
    public partial class wpHojaDeVidaUserControl : wpUsrControl
    {
        #region Properties
        CatalogoValorLogic catalogoValorLogic = new CatalogoValorLogic();
        CarreraLogic carreraLogic = new CarreraLogic();
        CiudadLogic ciudadLogic = new CiudadLogic();
        HojaVidaLogic hojaVidaLogic = new HojaVidaLogic();
        AcademicoLogic academicoLogic = new AcademicoLogic();
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
        public int? PER_ID
        {
            set
            {
                ViewState["PER_ID"] = value;
            }
            get
            {
                return (int?)ViewState["PER_ID"];
            }
        }
        [Serializable]
        public class CarreraHelper
        {
            public int id { get; set; }
            public string nombre { get; set; }
        }
        public CarreraHelper Carrera
        {
            set
            {
                ViewState["Carrera"] = value;
            }
            get
            {
                return (CarreraHelper)ViewState["Carrera"];
            }
        }
        #endregion

        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PaginaRecargada)
            {
                Carrera = new CarreraHelper();
                IdPeticion = GetPasantiaQueryString();
                if (IdPeticion.HasValue)
                {

                    itemPasantias = pasantiasLogic.SeleccionarPorId(IdPeticion.Value);
                    if (itemPasantias != null)
                    {

                        string matricula = itemPasantias.Matricula;
                        LoadValores(7, nivel1Carreradrp, nivel2Carreradrp);
                        LoadValores(3, ddlGenero);
                        LoadValoresCiudad();
                        LoadValores(6, modalidadDropDownList);
                        LoadValores(5, disponibilidadDropDownList);
                        LoadValores(18, interesDropDownList);
                        LoadValores(1, nivelEmpleoDropDownList);
                        LoadValores(15, aspiracionDropDownList);
                        LoadValores(17, otrosEstudiosCarreraDropDownList);
                        LoadValores(10, aniosEstudiosDropDownList);
                        LoadValores(11, espaniolDropDownList, inglesDropDownList, francesDropDownList, alemanDropDownList, otroIdiomaDropDownList);
                        LoadDatosPersonales(itemPasantias);
                        LoadCamposNoDisponibles();
                        MapeoHojaVidaCamposEditablesAControl(hojaVidaLogic.SeleccionarCamposEditablesPorMatricula(matricula));

                    }
                }
            }
        } 
        #endregion

        #region Methods
        void LoadDatosPersonales(PasantiasPreProfesionales item)
        {
            nombresLabel.Text = item.NombreAlumno;
            apellidosLabel.Text = item.ApellidoAlumno;
            cedulaLabel.Text = item.CedulaIdentidad;
            matriculaLabel.Text = item.Matricula;
            direccionLabel.Text = item.DireccionAlumno;
            telefonoLabel.Text = item.TelefonoAlumno;
            celularLabel.Text = item.TelefonoCelularAlumno;
            ddlCiudad.SelectedValue = obtenerValor(item.CiudadNacimientoAlumno, ddlCiudad.Items);
            ddlGenero.SelectedValue = obtenerValor(item.SexoAlumno, ddlGenero.Items);
            fechaNacimientoLabel.Text = (item.FechaNacimientoAlumno != null) ? System.Convert.ToDateTime(item.FechaNacimientoAlumno.ToString()).ToShortDateString() : string.Empty;
            emailLabel.Text = item.EmailAlumno;


        }
        string obtenerValor(string texto, ListItemCollection items)
        {
            foreach (ListItem item in items)
            {
                if (item.Text.ToUpper().Contains(texto.ToUpper().Trim()))
                {
                    return item.Value;
                }
            }
            return null;
        }
        void LoadValores(int tipo, params DropDownList[] listas)
        {
            foreach (var item in listas)
            {
                item.DataSource = catalogoValorLogic.Seleccionar(tipo);
                item.DataTextField = "Nombre";
                item.DataValueField = "IdTipo";
                item.DataBind();
                item.SelectedValue = "-1";
            }

        }
        
        void LoadValoresCiudad()
        {

            ddlCiudad.DataSource = ciudadLogic.SeleccionarListaCiudades().OrderBy(x => x.Nombre);
            ddlCiudad.DataTextField = "Nombre";
            ddlCiudad.DataValueField = "ID";
            ddlCiudad.DataBind();
            ddlCiudad.SelectedValue = "-1";

        }
        protected void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                string matricula = itemPasantias.Matricula;
                if (hojaVidaLogic.ExisteHojaVida(matricula))
                {
                    HojaVida temp = MapeoControlAEntity();
                    hojaVidaLogic.Actualizar(temp);
                    if (!PER_ID.HasValue)
                        throw new Exception("PER_ID no puede ser nulo");
                    itemPasantias.PERID = PER_ID.Value;
                }
                else
                    itemPasantias.PERID = hojaVidaLogic.Insertar(MapeoControlAEntity());
                pasantiasLogic.Actualizar(itemPasantias);
                Ira(Properties.Pages.Default.Cursos, IdPeticion);
            }
            catch (Exception ex)
            {
                ManejarErrorNoRedirect(ex);
            }
        }

        void MapeoHojaVidaCamposEditablesAControl(HojaVida item)
        {
            if (item != null)
            {
                PER_ID = item.Id;
                direccionLabel.Text = Utils.TrimText(item.Direccion);
                telefonoLabel.Text = Utils.TrimText(item.Telefono);
                celularLabel.Text = Utils.TrimText(item.Celular);
                if (!String.IsNullOrEmpty(item.Espanol))
                    espaniolDropDownList.SelectedValue = item.Espanol;
                if (!String.IsNullOrEmpty(item.Ingles))
                    inglesDropDownList.SelectedValue = item.Ingles;
                if (!String.IsNullOrEmpty(item.Frances))
                    francesDropDownList.SelectedValue = item.Frances;
                if (!String.IsNullOrEmpty(item.Aleman))
                    alemanDropDownList.SelectedValue = item.Aleman;
                if (!string.IsNullOrEmpty(item.OtroIdiomaValor))
                    otroIdiomaDropDownList.SelectedValue = item.OtroIdiomaValor;
                if (!string.IsNullOrEmpty(item.Modalidad))
                    modalidadDropDownList.SelectedValue = item.Modalidad;
                if (!string.IsNullOrEmpty(item.Disponibilidad))
                    disponibilidadDropDownList.SelectedValue = item.Disponibilidad;

                if (!string.IsNullOrEmpty(item.NivelEmpleo))
                    nivelEmpleoDropDownList.SelectedValue = item.NivelEmpleo;

                if (!string.IsNullOrEmpty(item.AspiracionSalarial.ToString()))
                    aspiracionDropDownList.SelectedValue = item.AspiracionSalarial.ToString();

                if (!string.IsNullOrEmpty(item.Interesado.ToString()))
                    interesDropDownList.SelectedValue = item.Interesado.ToString();


                if (!string.IsNullOrEmpty(item.Estudios.ToString()))
                    otrosEstudiosCarreraDropDownList.SelectedValue = item.Estudios.ToString();

                if (!string.IsNullOrEmpty(item.NivelEstudios.ToString()))
                    otrosEstudiosCarreraDropDownList.SelectedValue = item.NivelEstudios.ToString();

                estudiosEnTextBox.Text = Utils.TrimText(item.EstudiosEn);
                institucionTextBox.Text = Utils.TrimText(item.Institucion);
                objetivoTextBox.Text = Utils.TrimText(item.Objetivo);
                otrasActividadesTextBox.Text = Utils.TrimText(item.OtrasActividades);
                meritosTextBox.Text = Utils.TrimText(item.Meritos);
                if (!string.IsNullOrEmpty(item.Ciudad))
                    ddlCiudad.SelectedValue = item.Ciudad;
                if (!string.IsNullOrEmpty(item.Genero))
                    ddlGenero.SelectedValue = item.Genero;
                txtOtroIdioma.Text = Utils.TrimText(item.OtroIdioma);
                empresa1Label.Text = Utils.TrimText(item.Empresa1);
                cargo1Label.Text = Utils.TrimText(item.Cargo1);
                jefe1Label.Text = Utils.TrimText(item.JefeInmediato1);
                telefono1Label.Text = Utils.TrimText(item.Telefono1);
                if (ConvertDate(item.FechaInicio1).HasValue)
                    fechaInicio1Label.SelectedDate = ConvertDate(item.FechaInicio1).Value;
                if (ConvertDate(item.FechaSalida1).HasValue)
                    FechaSalida1Label.SelectedDate = ConvertDate(item.FechaSalida1).Value;
                responsabilidades1Label.Text = Utils.TrimText(item.Responsabilidades1);
                empresa2Label.Text = Utils.TrimText(item.Empresa2);
                cargo2Label.Text = Utils.TrimText(item.Cargo2);
                jefe2Label.Text = Utils.TrimText(item.JefeInmediato2);
                telefono2Label.Text = Utils.TrimText(item.Telefono2);
                if (ConvertDate(item.FechaInicio2).HasValue)
                    fechaInicio2Label.SelectedDate = ConvertDate(item.FechaInicio2).Value;
                if (ConvertDate(item.FechaSalida2).HasValue)
                    FechaSalida2Label.SelectedDate = ConvertDate(item.FechaSalida2).Value;
                responsabilidades2Label.Text = Utils.TrimText(item.Responsabilidades2);
                empresa3Label.Text = Utils.TrimText(item.Empresa3);
                cargo3Label.Text = Utils.TrimText(item.Cargo3);
                jefe3Label.Text = Utils.TrimText(item.JefeInmediato3);
                telefono3Label.Text = Utils.TrimText(item.Telefono3);
                if (ConvertDate(item.FechaInicio3).HasValue)
                    fechaInicio3Label.SelectedDate = ConvertDate(item.FechaInicio3).Value;
                if (ConvertDate(item.FechaSalida3).HasValue)
                    FechaSalida3Label.SelectedDate = ConvertDate(item.FechaSalida3).Value;
                responsabilidades3Label.Text = Utils.TrimText(item.Responsabilidades3);
              
                if (!string.IsNullOrEmpty(item.Carrera2))
                    txtOtraCarrera.Text = Utils.TrimText(item.Carrera2);
                if (!string.IsNullOrEmpty(item.NivelCarrera2))
                    nivel2Carreradrp.SelectedValue = item.NivelCarrera2;
                emailLabel.Text = Utils.TrimText(item.Email);
            }
        }

        void LoadCamposNoDisponibles()
        {
            var data = hojaVidaLogic.ObtenerCarreraSegunSAES(itemPasantias.CodigoCarrera);
            Carrera.id = data.Key;
            Carrera.nombre = data.Value;
            lblCarrera.Text = Utils.TrimText(Carrera.nombre);
        
            nivel1Carreradrp.SelectedValue = itemPasantias.Nivel.ToString();
            nivel1Carreradrp.Enabled = false;
        }

        HojaVida MapeoControlAEntity()
        {
            HojaVida item = new HojaVida();
            item.Nombres = nombresLabel.Text;
            item.Apellidos = apellidosLabel.Text;
            item.Cedula = cedulaLabel.Text;
            item.Matricula = matriculaLabel.Text;
            item.Direccion = direccionLabel.Text;
            item.Telefono = telefonoLabel.Text;
            item.Celular = celularLabel.Text;
            item.Ciudad = ddlCiudad.SelectedValue;
            item.Genero = ddlGenero.SelectedValue;
            item.FechaNacimiento = fechaNacimientoLabel.Text;
            item.Modalidad = modalidadDropDownList.SelectedValue;
            item.Disponibilidad = disponibilidadDropDownList.SelectedValue;

            item.NivelEmpleo = nivelEmpleoDropDownList.SelectedValue;
            item.AspiracionSalarial = System.Convert.ToInt32(aspiracionDropDownList.SelectedValue);

            item.Estudios = System.Convert.ToInt32(otrosEstudiosCarreraDropDownList.SelectedValue);
            item.NivelEstudios = System.Convert.ToInt32(aniosEstudiosDropDownList.SelectedValue);
            item.EstudiosEn = estudiosEnTextBox.Text;
            item.Institucion = institucionTextBox.Text;

            item.Interesado = System.Convert.ToInt32(interesDropDownList.SelectedValue);

            item.Objetivo = objetivoTextBox.Text;
            item.OtrasActividades = otrasActividadesTextBox.Text;
            item.Meritos = meritosTextBox.Text;
            item.Carrera1 = Carrera.id.ToString();
            item.NivelCarrera1 = nivel1Carreradrp.SelectedValue;
            item.Carrera2 = txtOtraCarrera.Text;
            item.NivelCarrera2 = nivel2Carreradrp.SelectedValue;
            item.Email = emailLabel.Text;
            item.Espanol = espaniolDropDownList.SelectedValue;
            item.Ingles = inglesDropDownList.SelectedValue;
            item.Frances = francesDropDownList.SelectedValue;
            item.Aleman = alemanDropDownList.SelectedValue;
            item.OtroIdioma = txtOtroIdioma.Text;
            item.OtroIdiomaValor = otroIdiomaDropDownList.SelectedValue;

            item.Empresa1 = empresa1Label.Text;
            item.Cargo1 = cargo1Label.Text;
            item.JefeInmediato1 = jefe1Label.Text;
            item.Telefono1 = telefono1Label.Text;
            item.FechaInicio1 = fechaInicio1Label.SelectedDate.ToShortDateString();
            item.FechaSalida1 = FechaSalida1Label.SelectedDate.ToShortDateString();
            item.Responsabilidades1 = responsabilidades1Label.Text;

            item.Empresa2 = empresa2Label.Text;
            item.Cargo2 = cargo2Label.Text;
            item.JefeInmediato2 = jefe2Label.Text;
            item.Telefono2 = telefono2Label.Text;
            item.FechaInicio2 = fechaInicio2Label.SelectedDate.ToShortDateString();
            item.FechaSalida2 = FechaSalida2Label.SelectedDate.ToShortDateString();
            item.Responsabilidades2 = responsabilidades2Label.Text;

            item.Empresa3 = empresa3Label.Text;
            item.Cargo3 = cargo3Label.Text;
            item.JefeInmediato3 = jefe3Label.Text;
            item.Telefono3 = telefono3Label.Text;
            item.FechaInicio3 = fechaInicio3Label.SelectedDate.ToShortDateString();
            item.FechaSalida3 = FechaSalida3Label.SelectedDate.ToShortDateString();
            item.Responsabilidades3 = responsabilidades3Label.Text;
            return item;
        }

        private DateTime? ConvertDate(string value)
        {
            DateTime fecha;
            if (DateTime.TryParse(value, out fecha))
                return fecha;
            return null;
        } 
        #endregion

      

      
    }
}
