using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace tryService
{
    public partial class Service1 : ServiceBase
    {
        Server.WebsocketServer websocketServer;

        public Service1()
        {
            InitializeComponent();            

            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";

            websocketServer = new Server.WebsocketServer();
            websocketServer.LogMessage += WebsocketServer_LogMessage;

            websocketServer.Start("http://localhost:2645/service/");
        }

        private void WebsocketServer_LogMessage(object sender, Server.WebsocketServer.LogMessageEventArgs e)
        {
            eventLog1.WriteEntry(e.Message);
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Iniciando: http://localhost:2645/service/ ");
            //websocketServer.Start("http://localhost:2645/service/");
        }

        protected override void OnStop()
        {
            //websocketServer.Stop();
        }
        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }

    }
}
