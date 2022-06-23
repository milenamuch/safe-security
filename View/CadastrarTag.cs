using System;
using Views.Lib;
using Controllers;
using System.Windows.Forms;

namespace Views
{
    public class CadastrarTag : BaseForm
    {
        FieldForm fieldDescricao;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        Tags parent;

        public CadastrarTag(Tags parent) : base("Cadastrar Tag",SizeScreen.Small)
        {

            this.parent = parent;
            fieldDescricao = new FieldForm("Descrição",30,80,240,20);

			btnConfirmar = new ButtonForm("Confirmar", 30,210, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170,210, this.handleCancel);

            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);

            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
           try {
                TagController.IncluirTag(
                    this.fieldDescricao.txtField.Text
                );
                this.parent.LoadInfo();
                handleCancel(sender, e);
            } catch (Exception err) {
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