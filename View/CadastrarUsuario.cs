using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;

namespace Views
{
    public class CadastrarUsuario : BaseForm
    {
        FieldForm fieldNome;
        FieldForm fieldEmail;
        FieldForm fieldSenha;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        Usuarios parent;

        public CadastrarUsuario(Usuarios parent) : base("Cadastrar Usuario", SizeScreen.Small)
        {
            this.parent = parent;

            fieldNome = new FieldForm("Nome", 30, 30, 240, 20);
            fieldEmail = new FieldForm("Email", 30, 90, 240, 20);
            fieldSenha = new FieldForm("Senha", 30, 150, 240, 20);
            fieldSenha.txtField.PasswordChar = '⚹';

            btnConfirmar = new ButtonForm("Confirmar", 30, 230, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170, 230, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldEmail.lblField);
            this.Controls.Add(fieldEmail.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);

            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                UsuarioController.IncluirUsuario(
                    this.fieldNome.txtField.Text,
                    this.fieldEmail.txtField.Text,
                    this.fieldSenha.txtField.Text
                );

                this.parent.LoadInfo();
                handleCancel(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}