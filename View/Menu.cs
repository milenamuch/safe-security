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
    public class Menu : BaseForm
    {
		ButtonForm btnCategorias;
        ButtonForm btnSenhas;
        ButtonForm btnTags;
        ButtonForm btnUsusario;
        ButtonForm btnSair;

        public Menu() : base("Menu", SizeScreen.Small)
        {
            btnCategorias = new ButtonForm("Categorias", 100, 30, this.handleCategorias);
            btnSenhas = new ButtonForm("Senhas", 100, 80, this.handleSenhas);
            btnTags = new ButtonForm("Tags", 100, 130, this.handleTags);
            btnUsusario = new ButtonForm("Usuário", 100, 180, this.handleUsuario);
            btnSair = new ButtonForm("Sair", 100, 230, this.handleSair);

            this.Controls.Add(btnCategorias);
            this.Controls.Add(btnSenhas);
            this.Controls.Add(btnTags);
            this.Controls.Add(btnUsusario);
            this.Controls.Add(btnSair);
        }
        
        private void handleCategorias(object sender, EventArgs e)
        {
            this.Hide();
            (new Categorias()).Show();
        }

        private void handleSenhas(object sender, EventArgs e)
        {
            //(new Senhas()).Show();
        }

        private void handleTags(object sender, EventArgs e)
        {
            this.Hide();
            (new Tags()).Show();
        }

        private void handleUsuario(object sender, EventArgs e)
        {
            this.Hide();
            (new Usuarios()).Show();
        }

        private void handleSair(object sender, EventArgs e)
        {
            this.Hide();
        }
                public class FormConfirmGeral: Form
        {
            public FormConfirmGeral()
            {
      
            }     
        }
    }
}