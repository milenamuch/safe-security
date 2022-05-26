using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Views.Lib;

namespace Views
{
    public class AlterarUsuario : BaseForm 
    {
        FieldForm fieldNome;
        FieldForm fieldEmail;
        FieldForm fieldSenha;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public AlterarUsuario() : base("Alterar Usuario",SizeScreen.Small)
        {
            fieldNome = new FieldForm("Nome",30,30,240,20);
            fieldEmail = new FieldForm("Email",30,90,240,20);
            fieldSenha = new FieldForm("Senha",30,150,240,20);
            fieldSenha.txtField.PasswordChar = '*';

			btnConfirmar = new ButtonForm("Confirmar", 30, 230, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170,230, this.handleCancel);

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
            //Inserir Usuario
        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.Hide();
            (new Usuarios()).Show();
        }
    }
}