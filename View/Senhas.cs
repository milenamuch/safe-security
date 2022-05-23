using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;

namespace Views
{
    public class Senhas : BaseForm
    {
        ListView listView;
		ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        
        public Senhas() : base("Senhas", SizeScreen.Medium)
        {
            
            listView = new ListView();
			listView.Location = new Point(20, 20);
			listView.Size = new Size(560,510);
			listView.View = View.Details;

			listView.Columns.Add("ID", 40, HorizontalAlignment.Center);
    		listView.Columns.Add("Nome", 120, HorizontalAlignment.Center);
            listView.Columns.Add("Categoria", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Url", 300, HorizontalAlignment.Center);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            btnIncluir = new ButtonForm("Incluir", 20, 550, this.handleConfirm);
            btnAlterar = new ButtonForm("Alterar",  170, 550, this.handleConfirm);
            btnExcluir = new ButtonForm("Excluir",325, 550, this.handleConfirm);
            btnVoltar = new ButtonForm("Voltar",  480,550, this.handleVoltar);

            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }
        private void handleConfirm(object sender, EventArgs e)
        {
            (new FormConfirmGeral()).Show();
        }

        private void handleVoltar(object sender, EventArgs e)
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