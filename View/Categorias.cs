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
        ListView listView;
		ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        
        public Categorias() : base("Categorias", SizeScreen.Medium)
        {
            
            listView = new ListView();
			listView.Location = new Point(20, 20);
			listView.Size = new Size(560,510);
			listView.View = View.Details;

			listView.Columns.Add("ID", 40, HorizontalAlignment.Center);
    		listView.Columns.Add("Nome", 120, HorizontalAlignment.Center);
            listView.Columns.Add("Descrição", 400, HorizontalAlignment.Center);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            btnIncluir = new ButtonForm("Incluir", 20, 550, this.handleCadastrarCategoria);
            btnAlterar = new ButtonForm("Alterar",  170, 550, this.handleAlterarCategoria);
            btnExcluir = new ButtonForm("Excluir",325, 550, this.handleExcluirCategoria);
            btnVoltar = new ButtonForm("Voltar",  480,550, this.handleVoltar);

            this.LoadInfo();
            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }

        public void LoadInfo() {
            IEnumerable<Categoria> categorias = CategoriaController.GetCategorias();

            this.listView.Items.Clear();
            foreach (Categoria item in categorias)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Nome);
                lvItem.SubItems.Add(item.Descricao);

                this.listView.Items.Add(lvItem);
            }
        }

        private void handleCadastrarCategoria(object sender, EventArgs e)
        {
            this.Hide();
            (new CadastrarCategoria()).Show();
        }

        private void handleAlterarCategoria(object sender, EventArgs e)
        {

            if (listView.SelectedItems.Count > 0) {
                (new AlterarCategoria()).Show();
                this.Hide();
            } else {
                MessageBox.Show("Selecione um item para alterar.");
            }
        }

        private void handleExcluirCategoria(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0) {
                ListViewItem item = this.listView.SelectedItems[0];
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

                        this.Hide();
                        (new Categorias()).Show();
                        this.LoadInfo();    
                    }
                   

                } catch (Exception err) {
                    MessageBox.Show(err.Message);
                }
             }else {
                MessageBox.Show("Selecione uma categoria da lista para excluir.");
            }        
        }
        private void handleVoltar(object sender, EventArgs e)
        {
            this.Hide();
            (new Menu()).Show();
        }
    }
}