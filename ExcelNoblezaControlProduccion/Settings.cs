﻿using System;
using System.Diagnostics;

namespace ExcelNoblezaControlProduccion.Properties {
    
    
    // Esta clase le permite controlar eventos específicos en la clase de configuración:
    //  El evento SettingChanging se desencadena antes de cambiar un valor de configuración.
    //  El evento PropertyChanged se desencadena después de cambiar el valor de configuración.
    //  El evento SettingsLoaded se desencadena después de cargar los valores de configuración.
    //  El evento SettingsSaving se desencadena antes de guardar los valores de configuración.
    internal sealed partial class Settings {

        public static bool onload = false;

        public Settings() {

            this.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged( object sender, System.ComponentModel.PropertyChangedEventArgs e )
        {
            try
            {
                var newValue = System.Text.RegularExpressions.Regex.Replace(e.PropertyName, "([A-Z])([a-z]*)", " $1$2");

                Debug.WriteLine( "Changed {2}: {0,20} => {1}", newValue, Default[e.PropertyName], onload ? " Load" : "" );

                if (!onload)
                {
                    this.Save();
                    return;
                };

                Program.splashScreen.message = newValue;
                System.Threading.Thread.Sleep( 150 );
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public void Set_OnLoad( bool val )
        {
            onload = val;
            Debug.WriteLine( "OnLoad: {0}", val );
        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Agregar código para administrar aquí el evento SettingChangingEvent.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Agregar código para administrar aquí el evento SettingsSaving.
        }
    }
}


