using System;
using System.Windows.Forms;
using Views;

namespace EncryptMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Login());
            //Console.WriteLine("Hellow");
            try {

                MessageBox.Show(Controllers.UsuarioController.IncluirUsuario("Administrador", "admin@teste.com", "12345678").ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
