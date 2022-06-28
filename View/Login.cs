using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;
using System.Drawing;
namespace Views
{
    public class Login : BaseForm
    {
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
        Label primeiroAcesso;
        Title bemVindo;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        ButtonForm btnPrimeiroAcesso;

        public Login() : base("Login",SizeScreen.Small)
        {
            fieldUsuario = new FieldForm("Usuário",60,50,180,20);
            fieldSenha = new FieldForm("Senha",60,110,180,60);
            fieldSenha.txtField.PasswordChar = '⚹';
            bemVindo = new Title ("Bem vindo ao Safe Security!", SizeScreen.Small);
            bemVindo.Padding = new Padding (40,10,0,0);

            primeiroAcesso = new Label();
			primeiroAcesso.Text = "Primeiro Acesso?";
            primeiroAcesso.Location = new Point (100, 205);

			btnConfirmar = new ButtonForm("Confirmar", 40, 170, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 160,170, this.handleCancel);
            btnPrimeiroAcesso = new ButtonForm("Clique aqui", 100, 230, this.handlePrimeiroAcesso);

            this.Controls.Add(fieldUsuario.lblField);
            this.Controls.Add(fieldUsuario.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(bemVindo);
            this.Controls.Add(primeiroAcesso);

            this.Controls.Add(btnPrimeiroAcesso);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }
        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                UsuarioController.Auth(
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text
                );
                (new Menu(this)).Show();
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
            string message = "Tem certeza que quer sair?";  
            string title = "Cancelar";  
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;  
            DialogResult result = MessageBox.Show(message, title, buttons);  
            if (result == DialogResult.Yes) {  
                Application.Exit(); 
            }
        }

        private void handlePrimeiroAcesso(object sender, EventArgs e)
        {
            (new PrimeiroAcesso(this)).Show();
        }
    }
}