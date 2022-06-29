using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using Controllers;
using Models;
using System.Collections.Generic;
namespace Views
{
    public class Tags : BaseForm
    {
        Title tags;
        public ListView listView;
        ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        Form parent;

        public Tags(Form parent) : base("Tags", SizeScreen.Medium)
        {
            this.parent = parent;
            this.parent.Hide();

            tags = new Title("Tags", SizeScreen.Medium);
            tags.Padding = new Padding(20, 10, 0, 0);

            listView = new ListView();
            listView.Location = new Point(20, 50);
            listView.Size = new Size(560, 480);
            listView.View = View.Details;
            listView.Columns.Add("ID", 60, HorizontalAlignment.Center);
            listView.Columns.Add("Descrição", 500, HorizontalAlignment.Center);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            btnIncluir = new ButtonForm("Incluir", 20, 550, this.handleCadastrarTag);
            btnAlterar = new ButtonForm("Alterar", 170, 550, this.handleAlterarTag);
            btnExcluir = new ButtonForm("Excluir", 325, 550, this.handleExcluirTag);
            btnVoltar = new ButtonForm("Voltar", 480, 550, this.handleVoltar);

            this.LoadInfo();
            this.Controls.Add(tags);
            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }

        public void LoadInfo()
        {
            IEnumerable<Tag> Tags = TagController.GetTags();

            this.listView.Items.Clear();
            foreach (Tag item in Tags)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Descricao);
                this.listView.Items.Add(lvItem);
            }
        }
        private void handleCadastrarTag(object sender, EventArgs e)
        {
            this.Hide();
            (new CadastrarTag(this)).Show();
        }

        private void handleAlterarTag(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                this.Hide();
                (new AlterarTag(this)).Show();
            }
            else
            {
                MessageBox.Show("Selecione um item para alterar.");
            }
        }

        private void handleExcluirTag(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                try
                {
                    TagController.RemoverTag(
                        id
                    );
                    string message = "Tem certeza que quer excluir esta tag?";
                    string title = "Excluir Tag";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        string messageConfirm = "Tag excluída!";
                        DialogResult resultConfirm = MessageBox.Show(messageConfirm);

                        this.LoadInfo();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
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