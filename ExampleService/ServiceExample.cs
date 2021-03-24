using EmailHandler;
using ExampleService.Procedure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ExampleService
{
    public partial class ServiceExample : ServiceBase
    {

        Timer timer = new Timer();
        private ExecuteProcedure executeProcedure = new ExecuteProcedure();
        private EmailSender _sender = new EmailSender();
        public ServiceExample()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("El servicio se inicio a las " + DateTime.Now.ToString("dd/MM/yyyy H:mm"));
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 1000 * Configuracion.Default.TiempoDeEjecucion; // numero en milisegundos
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("El servicio se detuvo a las " + DateTime.Now.ToString("dd/MM/yyyy H:mm"));
        }

        private async void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("El servicio se volvio a ejecutar a las " + DateTime.Now.ToString("dd/MM/yyyy H:mm"));
            await executeProcedure.ExecuteExistenciaDeProductos(Configuracion.Default.MaximumQuantity);
            _sender.SendEmail("leonardotv.93@gmail.com", "Verificacion del stock", "Se ha verificado la existencia de productos");
        }

        private void WriteToFile(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);   
            }

            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.ToShortDateString().Replace('/','_') + ".txt";

            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(message);
                }
            }


        }

    }
}
