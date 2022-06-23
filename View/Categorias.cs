using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using Controllers;
using Models;
using System.Collections.Generic;


namespace Views
{
    public class Categorias : BaseForm
    {
        public ListView listViewCategorias;
		ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        Form parent;
        public Categorias(Form parent) : base("Categorias", SizeScreen.Medium)
        {
            this.parent = parent;
            this.parent.Hide();
            listViewCategorias = new ListView();
			listViewCategorias.Location = new Point(20, 20);
			listViewCategorias.Size = new Size(560,510);
			listViewCategorias.View = View.Details;
            listViewCategorias.FullRowSelect = true;
			listViewCategorias.GridLines = true;
			listViewCategorias.AllowColumnReorder = true;
			listViewCategorias.Sorting = SortOrder.Descending;
			listViewCategorias.Columns.Add("ID", 40, HorizontalAlignment.Center);
    		listViewCategorias.Columns.Add("Nome", 120, HorizontalAlignment.Center);
            listViewCategorias.Columns.Add("Descrição", 400, HorizontalAlignment.Center);
			

            btnIncluir = new ButtonForm("Incluir", 20, 550, this.handleCadastrarCategoria);
            btnAlterar = new ButtonForm("Alterar",  170, 550, this.handleAlterarCategoria);
            btnExcluir = new ButtonForm("Excluir",325, 550, this.handleExcluirCategoria);
            btnVoltar = new ButtonForm("Voltar",  480,550, this.handleVoltar);

            this.LoadInfo();
            this.Controls.Add(listViewCategorias);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }

        public void LoadInfo() {

            IEnumerable<Categoria> categorias = CategoriaController.GetCategorias();
            this.listViewCategorias.Items.Clear();
            this.Show();
            foreach (Categoria item in categorias)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Nome);
                lvItem.SubItems.Add(item.Descricao);

                this.listViewCategorias.Items.Add(lvItem);
            }
        }

        private void handleCadastrarCategoria(object sender, EventArgs e)
        {
            this.Hide();
            new CadastrarCategoria(this).Show();
        }

        private void handleAlterarCategoria(object sender, EventArgs e)
        {
            
            if (listViewCategorias.SelectedItems.Count > 0) {
                this.Hide();
                new AlterarCategoria(this).Show();
            } else {
                MessageBox.Show("Selecione um item para alterar.");
            }
        }

        private void handleExcluirCategoria(object sender, EventArgs e)
        {
            
            if (listViewCategorias.SelectedItems.Count > 0) {
                ListViewItem item = this.listViewCategorias.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                try {
                CategoriaController.RemoverCategoria(
                    id
                );
                    string message = "Tem certeza que quer excluir esta categoria?";  
                    string title = "Excluir Categoria";  
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;  
                    DialogResult result = MessageBox.Show(message, title, buttons);  
                    if (result == DialogResult.Yes) {  
                        string messageConfirm = "Categoria excluída!";  
                        DialogResult resultConfirm = MessageBox.Show(messageConfirm);
                        this.LoadInfo();    
                    }
                   

                } catch (Exception err) {
                    MessageBox.Show(err.Message);
                }
                }else{
                MessageBox.Show("Selecione uma categoria da lista para excluir.");
            }        
        }
        private void handleVoltar(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}