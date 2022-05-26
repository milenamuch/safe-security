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
    public class Tags : BaseForm
    {
        ListView listView;
		ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        
        public Tags() : base("Tags", SizeScreen.Medium)
        {
            
            listView = new ListView();
			listView.Location = new Point(20, 20);
			listView.Size = new Size(560,510);
			listView.View = View.Details;

			listView.Columns.Add("ID", 60, HorizontalAlignment.Center);
            listView.Columns.Add("Descrição", 500, HorizontalAlignment.Center);
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            btnIncluir = new ButtonForm("Incluir", 20, 550, this.handleCadastrarTag);
            btnAlterar = new ButtonForm("Alterar",  170, 550, this.handleAlterarTag);
            btnExcluir = new ButtonForm("Excluir",325, 550, this.handleExcluirTag);
            btnVoltar = new ButtonForm("Voltar",  480,550, this.handleVoltar);

            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }
        private void handleCadastrarTag(object sender, EventArgs e)
        {
            this.Hide();
            (new CadastrarTag()).Show();
        }

        private void handleAlterarTag(object sender, EventArgs e)
        {
            this.Hide();
            (new AlterarTag()).Show();
        }

        private void handleExcluirTag(object sender, EventArgs e)
        {
            string message = "Tem certeza que quer excluir a tag X ?";  //Incluir Tag
            string title = "Excluir tag";  
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;  
            DialogResult result = MessageBox.Show(message, title, buttons);  
            if (result == DialogResult.Yes) {  
                string messageConfirm = "Tag excluída!";  
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