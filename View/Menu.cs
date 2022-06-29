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
        Title menu;
        ButtonForm btnUsusario;
        ButtonForm btnSair;

        Form parent;
        
        public Menu(Form parent) : base("Menu", SizeScreen.Small)
        {
            this.parent = parent;
            this.parent.Hide();

            menu = new Title ("Menu", SizeScreen.Small);
            menu.Padding = new Padding (125,10,0,0);
            btnCategorias = new ButtonForm("Categorias", 40, 80, this.handleCategorias);
            btnSenhas = new ButtonForm("Senhas", 160, 80, this.handleSenhas);
            btnTags = new ButtonForm("Tags", 40, 150, this.handleTags);
            btnUsusario = new ButtonForm("Usuário", 160, 150, this.handleUsuario);
            btnSair = new ButtonForm("Sair", 100, 230, this.handleSair);

            
            this.Controls.Add(menu);
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