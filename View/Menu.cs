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
        ButtonForm btnUsuario;
        ButtonForm btnSair;

        public Menu() : base("Menu", SizeScreen.Small)
        {
      
            btnCategorias = new ButtonForm("Categorias", 100, 30, this.handleCategoria);
            btnSenhas = new ButtonForm("Senhas", 100, 80, this.handleSenha);
            btnTags = new ButtonForm("Tags", 100, 130, this.handleTag);
            btnUsuario = new ButtonForm("Usuário", 100, 180, this.handleUsuario);
            
            btnSair = new ButtonForm("Sair", 100, 230, this.sair);

            this.Controls.Add(btnCategorias);
            this.Controls.Add(btnSenhas);
            this.Controls.Add(btnTags);
            this.Controls.Add(btnUsuario);
            this.Controls.Add(btnSair);
        }

        private void handleCategoria(object sender, EventArgs e)
        {
            // TODO: Criar telas categoria

        }
        private void handleSenha(object sender, EventArgs e)
        {
            // TODO: Criar telas de senha

        }

        private void handleTag(object sender, EventArgs e)
        {
            // TODO: Criar telas de tag

        }

        private void handleUsuario(object sender, EventArgs e)
        {
            // TODO: Criar telas de usuário

        }

        private void sair(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
   
}