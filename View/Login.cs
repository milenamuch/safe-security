using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;

namespace Views
{
    public class Login : BaseForm
    {
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public Login() : base("Login",SizeScreen.Small)
        {
            fieldUsuario = new FieldForm("Usuário",60,80,180,20);
            fieldSenha = new FieldForm("Senha",60,140,180,60);
            fieldSenha.txtField.PasswordChar = '⚹';

			btnConfirmar = new ButtonForm("Confirmar", 100, 200, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 100,250, this.handleCancel);

            this.Controls.Add(fieldUsuario.lblField);
            this.Controls.Add(fieldUsuario.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
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
    }
}