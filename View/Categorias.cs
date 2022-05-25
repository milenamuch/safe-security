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

            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }

        private void handleCadastrarCategoria(object sender, EventArgs e)
        {
            this.Hide();
            (new CadastrarCategoria()).Show();
        }

        private void handleAlterarCategoria(object sender, EventArgs e)
        {
            this.Hide();
            (new AlterarCategoria()).Show();
        }

        private void handleExcluirCategoria(object sender, EventArgs e)
        {
            string message = "Tem certeza que quer excluir a categoria X ?";  //Incluir Categoria
            string title = "Excluir Categoria";  
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;  
            DialogResult result = MessageBox.Show(message, title, buttons);  
            if (result == DialogResult.Yes) {  
                string messageConfirm = "Categoria excluída!";  
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