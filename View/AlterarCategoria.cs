using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;
using Models;

namespace Views
{
    public class AlterarCategoria : BaseForm
    {
        FieldForm fieldNome;
        FieldForm fieldDescricao;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        Categorias parent;
        ListViewItem selectedItem;
        int id = 0;

        public AlterarCategoria(Categorias parent) : base("Alterar categoria", SizeScreen.Small)
        {
            this.parent = parent;
            this.selectedItem = this.parent.listViewCategorias.SelectedItems[0];
            this.id = Convert.ToInt32(this.selectedItem.Text);

            Categoria categoria = CategoriaController.GetCategoria(id);

            fieldNome = new FieldForm("Nome", 30, 50, 240, 20);
            fieldDescricao = new FieldForm("Descrição", 30, 120, 240, 20);

            btnConfirmar = new ButtonForm("Confirmar", 30, 210, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170, 210, this.handleCancel);

            this.fieldNome.txtField.Text = categoria.Nome;
            this.fieldDescricao.txtField.Text = categoria.Descricao;

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);

            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try
            {
                CategoriaController.AlterarCategoria(
                    this.id,
                    this.fieldNome.txtField.Text,
                    this.fieldDescricao.txtField.Text
                );
                this.parent.LoadInfo();
                handleCancel(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}