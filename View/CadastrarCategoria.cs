using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;

namespace Views
{
    public class CadastrarCategoria : BaseForm
    {
        FieldForm fieldNome;
        FieldForm fieldDescricao;
        ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        Categorias parent;

        public CadastrarCategoria(Categorias parent) : base("Cadastrar categoria", SizeScreen.Small)
        {
            this.parent = parent;

            fieldNome = new FieldForm("Nome", 30, 50, 240, 20);
            fieldDescricao = new FieldForm("Descrição", 30, 120, 240, 20);

            btnConfirmar = new ButtonForm("Confirmar", 30, 210, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170, 210, this.handleCancel);

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
                CategoriaController.IncluirCategoria(
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