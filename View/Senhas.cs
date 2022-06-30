using System;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using System.Collections.Generic;
using Controllers;
using Models;

namespace Views
{
    public class Senhas : BaseForm
    {
        Title senhas;
        public ListView listView;
        ButtonForm btnIncluir;
        ButtonForm btnAlterar;
        ButtonForm btnExcluir;
        ButtonForm btnVoltar;
        Form parent;

        public Senhas(Form parent) : base("Senhas", SizeScreen.Medium)
        {

            this.parent = parent;
            this.parent.Hide();

            senhas = new Title("Senhas", SizeScreen.Medium);
            senhas.Padding = new Padding(20, 10, 0, 0);

            listView = new ListView();
            listView.Location = new Point(20, 50);
            listView.Size = new Size(560, 480);
            listView.View = View.Details;

            listView.Columns.Add("ID", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Nome", 120, HorizontalAlignment.Center);
            listView.Columns.Add("Categoria", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Url", 300, HorizontalAlignment.Center);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            btnIncluir = new ButtonForm("Incluir", 20, 550, this.handleCadastrarSenha);
            btnAlterar = new ButtonForm("Alterar", 170, 550, this.handleAlterarSenha);
            btnExcluir = new ButtonForm("Excluir", 325, 550, this.handleExcluirSenha);
            btnVoltar = new ButtonForm("Voltar", 480, 550, this.handleVoltar);

            this.LoadInfo();
            this.Controls.Add(senhas);
            this.Controls.Add(listView);
            this.Controls.Add(btnIncluir);
            this.Controls.Add(btnAlterar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnVoltar);
        }

        public void LoadInfo()
        {
            IEnumerable<Senha> senhas = SenhaController.GetSenhas();

            this.listView.Items.Clear();
            foreach (Senha item in senhas)
            {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString());
                lvItem.SubItems.Add(item.Nome);
                lvItem.SubItems.Add(item.Categoria.Nome);
                lvItem.SubItems.Add(item.Url);

                this.listView.Items.Add(lvItem);
            }
        }

        private void handleCadastrarSenha(object sender, EventArgs e)
        {
            this.Hide();
            (new CadastrarSenha(this)).Show();
        }

        private void handleAlterarSenha(object sender, EventArgs e)
        {

            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                try
                {
                    this.Hide();
                    (new AlterarSenha(this)).Show();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma senha da lista para alterar.");
            }
        }

        private void handleExcluirSenha(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                try
                {
                    SenhaController.RemoverSenha(
                        id
                    );
                    string message = "Tem certeza que quer excluir esta senha?";
                    string title = "Excluir Senha";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        string messageConfirm = "Senha excluída!";
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
                MessageBox.Show("Selecione uma senha da lista para excluir.");
            }
        }

        private void handleVoltar(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
    }
}