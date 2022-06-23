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
        Form parent;
        
        public Usuarios(Form parent) : base("Usuarios", SizeScreen.Medium)
        {
            this.parent = parent;
            this.parent.Hide();
            
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
            this.Show();
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
            new CadastrarUsuario(this).Show();
        }

        private void handleAlterarUsuario(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0) {
                this.Hide();
                new AlterarUsuario(this).Show();
                
            } else {
                MessageBox.Show("Selecione um usuário da lista para alterar.");
            }
        }

        private void handleExcluirUsuario(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0) {
                ListViewItem item = this.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                try {
                UsuarioController.RemoverUsuario(
                    id
                );
                    string message = "Tem certeza que quer excluir este usuário?";  
                    string title = "Excluir Usuário";  
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;  
                    DialogResult result = MessageBox.Show(message, title, buttons);  
                    if (result == DialogResult.Yes) {  
                        string messageConfirm = "Usuário excluído!";  
                        DialogResult resultConfirm = MessageBox.Show(messageConfirm);
                        this.LoadInfo();    
                    }
                   

                } catch (Exception err) {
                    MessageBox.Show(err.Message);
                }
                }else{
                MessageBox.Show("Selecione uma tag da lista para excluir.");
            }        
        }
        
        private void handleVoltar(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}