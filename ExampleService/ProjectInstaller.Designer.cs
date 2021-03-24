namespace ExampleService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerExample = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerExample = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerExample
            // 
            this.serviceProcessInstallerExample.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstallerExample.Password = null;
            this.serviceProcessInstallerExample.Username = null;
            // 
            // serviceInstallerExample
            // 

            this.serviceInstallerExample.DisplayName = "Service Custom";
            this.serviceInstallerExample.ServiceName = "ServiceExample";
            this.serviceInstallerExample.Description = "El servicio ejecuta un procedure en base de datos para validar la existencia de productos";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerExample,
            this.serviceInstallerExample});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerExample;
        private System.ServiceProcess.ServiceInstaller serviceInstallerExample;
    }
}