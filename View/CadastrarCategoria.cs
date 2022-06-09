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

        public CadastrarCategoria() : base("Cadastrar categoria",SizeScreen.Small)
        {
            fieldNome = new FieldForm("Nome",30,50,240,20);
            fieldDescricao = new FieldForm("Descrição",30,120,240,20);  

			btnConfirmar = new ButtonForm("Confirmar", 30, 210, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170,210, this.handleCancel);

            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);

            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                CategoriaController.IncluirCategoria(
                    this.fieldNome.txtField.Text,
                    this.fieldDescricao.txtField.Text
                );
                (new Categorias()).Show();
                (new Categorias()).LoadInfo();
                this.Hide();
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.Hide();
            (new Categorias()).Show();
        }
    }
}