using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVendas
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login frmlogin = new Login();

            frmlogin.ShowDialog();

            if(frmlogin.logado)
            {
                Application.Run(new Formulários.frmMenu());
            }
        }
    }
}
