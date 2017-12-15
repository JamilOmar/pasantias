﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    public sealed partial class Mensajes : global::System.Configuration.ApplicationSettingsBase {
        
        private static Mensajes defaultInstance = ((Mensajes)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Mensajes())));
        
        public static Mensajes Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Se ha producido un error")]
        public string Excepcion {
            get {
                return ((string)(this["Excepcion"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No existe tutor")]
        public string SeleccionarTutor {
            get {
                return ((string)(this["SeleccionarTutor"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Error al obtener informacion del tutor")]
        public string ErrorADUsername {
            get {
                return ((string)(this["ErrorADUsername"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Error al obtener tutor ID")]
        public string ObtenerMOSSID {
            get {
                return ((string)(this["ObtenerMOSSID"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Materia Invalida")]
        public string ObtenerMateria {
            get {
                return ((string)(this["ObtenerMateria"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Error al obtener horas")]
        public string ObtenerHoras {
            get {
                return ((string)(this["ObtenerHoras"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("El numero de horas ingresadas supera las horas necesarias para la materia")]
        public string MaxHoras {
            get {
                return ((string)(this["MaxHoras"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Por favor acércate al departamento de financiamiento UDLA")]
        public string ValidarDeudas {
            get {
                return ((string)(this["ValidarDeudas"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ACCIÓN")]
        public string LinkPractica {
            get {
                return ((string)(this["LinkPractica"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public string NumeroMaximoLineas {
            get {
                return ((string)(this["NumeroMaximoLineas"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PRÁCTICA-{0}")]
        public string NombrePractica {
            get {
                return ((string)(this["NombrePractica"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Está seguro/a que desea ingresar el número de horas ejecutadas?")]
        public string MensajeConfirmacionFichaEmpresa {
            get {
                return ((string)(this["MensajeConfirmacionFichaEmpresa"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Deseas dar por finalizada la práctica?")]
        public string MensajeConfirmacionFichaEmpresaConfirmar {
            get {
                return ((string)(this["MensajeConfirmacionFichaEmpresaConfirmar"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Usuario InActivo, seleccione o cree otro usuario")]
        public string MensajeUsuarioInactivo {
            get {
                return ((string)(this["MensajeUsuarioInactivo"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CANCELADO POR EMPRESA")]
        public string MensajeCanceladoEmpresa {
            get {
                return ((string)(this["MensajeCanceladoEmpresa"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CANCELADO POR DOCENTE")]
        public string MensajeCanceladoDocente {
            get {
                return ((string)(this["MensajeCanceladoDocente"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CANCELADO  POR TUTOR")]
        public string MensajeCanceladoTutor {
            get {
                return ((string)(this["MensajeCanceladoTutor"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Ir a Listado de  Prácticas Asignadas")]
        public string TextoIrADocente {
            get {
                return ((string)(this["TextoIrADocente"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Ir a Listado de Prácticas Asignadas")]
        public string TextoIrAEmpresa {
            get {
                return ((string)(this["TextoIrAEmpresa"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Has agotado el número de matrículas permitidas.")]
        public string ValidarCuartaMatricula {
            get {
                return ((string)(this["ValidarCuartaMatricula"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No te encuentras vigente en el período académico actual.")]
        public string ValidarResolucionRetiro {
            get {
                return ((string)(this["ValidarResolucionRetiro"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No te encuentras vigente en el periodo académico actual.")]
        public string SeleccionarAlumno {
            get {
                return ((string)(this["SeleccionarAlumno"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No te encuentras en el nivel para iniciar la práctica.")]
        public string ValidarNivel {
            get {
                return ((string)(this["ValidarNivel"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Ha existido un problema.")]
        public string ErrorValidacion {
            get {
                return ((string)(this["ErrorValidacion"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("No te encuentras vigente en el período académico actual.")]
        public string SeleccionarNivel {
            get {
                return ((string)(this["SeleccionarNivel"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Está seguro/a que desea ingresar el número de horas?")]
        public string MensajeConfirmacionFichaTutor {
            get {
                return ((string)(this["MensajeConfirmacionFichaTutor"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Estas seguro de registrar las horas en el sistema académico?")]
        public string MensajeConfirmacionHorasSaes {
            get {
                return ((string)(this["MensajeConfirmacionHorasSaes"]));
            }
        }
    }
}
