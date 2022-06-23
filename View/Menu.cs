using System;
using Views.Lib;
using System.Windows.Forms;

namespace Views
{
    public class Menu : BaseForm
    {
		ButtonForm btnCategorias;
        ButtonForm btnSenhas;
        ButtonForm btnTags;
        ButtonForm btnUsusario;
        ButtonForm btnSair;

        Form parent;
        
        public Menu(Form parent) : base("Menu", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();
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
            (new Categorias(this)).Show();
        }

        private void handleSenhas(object sender, EventArgs e)
        {
            (new Senhas(this)).Show();
        }

        private void handleTags(object sender, EventArgs e)
        {
            (new Tags(this)).Show();
        }

        private void handleUsuario(object sender, EventArgs e)
        {
            (new Usuarios(this)).Show();
        }

        private void handleSair(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}