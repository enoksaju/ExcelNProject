﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstacionPesaje.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UpgradeRequired {
            get {
                return ((bool)(this["UpgradeRequired"]));
            }
            set {
                this["UpgradeRequired"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ActivarEnvio {
            get {
                return ((bool)(this["ActivarEnvio"]));
            }
            set {
                this["ActivarEnvio"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9600")]
        public int BasculaBaudRate {
            get {
                return ((int)(this["BasculaBaudRate"]));
            }
            set {
                this["BasculaBaudRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public string BasculaCaracterFinLinea {
            get {
                return ((string)(this["BasculaCaracterFinLinea"]));
            }
            set {
                this["BasculaCaracterFinLinea"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool BasculaConectarAlIniciar {
            get {
                return ((bool)(this["BasculaConectarAlIniciar"]));
            }
            set {
                this["BasculaConectarAlIniciar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6")]
        public int BasculaFin {
            get {
                return ((int)(this["BasculaFin"]));
            }
            set {
                this["BasculaFin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int BasculaInicio {
            get {
                return ((int)(this["BasculaInicio"]));
            }
            set {
                this["BasculaInicio"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500")]
        public int BasculaIntervalo {
            get {
                return ((int)(this["BasculaIntervalo"]));
            }
            set {
                this["BasculaIntervalo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM3")]
        public global::libBascula.Puertos BasculaPuerto {
            get {
                return ((global::libBascula.Puertos)(this["BasculaPuerto"]));
            }
            set {
                this["BasculaPuerto"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("500")]
        public int BasculaReadTimeOut {
            get {
                return ((int)(this["BasculaReadTimeOut"]));
            }
            set {
                this["BasculaReadTimeOut"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool BasculaShowUnidad {
            get {
                return ((bool)(this["BasculaShowUnidad"]));
            }
            set {
                this["BasculaShowUnidad"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BasculaTextoAEnviar {
            get {
                return ((string)(this["BasculaTextoAEnviar"]));
            }
            set {
                this["BasculaTextoAEnviar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("kg")]
        public global::libBascula.Unidad BasculaUnidad {
            get {
                return ((global::libBascula.Unidad)(this["BasculaUnidad"]));
            }
            set {
                this["BasculaUnidad"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ImpresoraEtiquetas {
            get {
                return ((string)(this["ImpresoraEtiquetas"]));
            }
            set {
                this["ImpresoraEtiquetas"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool enabledImpresionMultiple {
            get {
                return ((bool)(this["enabledImpresionMultiple"]));
            }
            set {
                this["enabledImpresionMultiple"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Optional1 {
            get {
                return ((string)(this["Optional1"]));
            }
            set {
                this["Optional1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Optional2 {
            get {
                return ((string)(this["Optional2"]));
            }
            set {
                this["Optional2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Optional3 {
            get {
                return ((string)(this["Optional3"]));
            }
            set {
                this["Optional3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Optional4 {
            get {
                return ((string)(this["Optional4"]));
            }
            set {
                this["Optional4"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Optional5 {
            get {
                return ((string)(this["Optional5"]));
            }
            set {
                this["Optional5"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ItemOptional {
            get {
                return ((string)(this["ItemOptional"]));
            }
            set {
                this["ItemOptional"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Optional6 {
            get {
                return ((string)(this["Optional6"]));
            }
            set {
                this["Optional6"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int EstableDelay {
            get {
                return ((int)(this["EstableDelay"]));
            }
            set {
                this["EstableDelay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int FiltroProduccion {
            get {
                return ((int)(this["FiltroProduccion"]));
            }
            set {
                this["FiltroProduccion"] = value;
            }
        }
    }
}
