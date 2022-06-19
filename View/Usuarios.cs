using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using Controllers;
using Models;

namespace Views
{
    public class Usuarios : BaseForm
    {
        public ListView listView;
		ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        
        public Usuarios() : base("Usuarios", SizeScreen.Medium)
        {
            
            listView = new ListView();
			listView.Location = new Point(20, 20);
			listView.Size = new Size(560,510);
			listView.View = View.Details;

			listView.Columns.Add("ID", 40, HorizontalAlignment.Center);
    		listView.Columns.Add("Nome", 120, HorizontalAlignment.Center);
            listView.Columns.Add("E-mail", 400, HorizontalAlignment.Center);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            btnIncluir = new ButtonForm("Incluir", 20, 550, this.handleCadastrarUsuario);
            btnAlterar = new ButtonForm("Alterar",  170, 550, this.handleAlterarUsuario);
            btnExcluir = new ButtonForm("Excluir",325, 550, this.handleExcluirUsuario);
            btnVoltar = new ButtonForm("Voltar",  480,550, this.handleVoltar);

            this.LoadInfo();
            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }
        public void LoadInfo() {
            IEnumerable<Usuario> usuarios = UsuarioController.GetUsuarios();

            this.listView.Items.Clear();
            foreach (Usuario item in usuarios)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Nome);
                lvItem.SubItems.Add(item.Email);
                lvItem.SubItems.Add(item.Senha);

                this.listView.Items.Add(lvItem);
            }
        }

        private void handleCadastrarUsuario(object sender, EventArgs e)
        {
            this.Hide();
            (new CadastrarUsuario()).Show();
        }

        private void handleAlterarUsuario(object sender, EventArgs e)
        {
            this.Hide();
            (new AlterarUsuario()).Show();
        }

        private void handleExcluirUsuario(object sender, EventArgs e)
        {
            string message = "Tem certeza que quer excluir a Usuario X ?";  //Incluir Usuario
            string title = "Excluir Usuario";  
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;  
            DialogResult result = MessageBox.Show(message, title, buttons);  
            if (result == DialogResult.Yes) {  
                string messageConfirm = "Usuario excluída!";  
                string titleConfirm = "";
                DialogResult resultConfirm = MessageBox.Show(messageConfirm, titleConfirm);    
            }
        }
        
        private void handleVoltar(object sender, EventArgs e)
        {
            this.Hide();
            (new Menu()).Show();
        }
    }
}