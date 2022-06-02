using System;
using Views.Lib;

namespace Views
{
    public class AlterarTag : BaseForm
    {
        FieldForm fieldDescricao;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        public AlterarTag() : base("Alterar tag",SizeScreen.Small)
        {
            fieldDescricao = new FieldForm("Descrição",30,80,240,20);  

			btnConfirmar = new ButtonForm("Confirmar", 30, 210, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170,210, this.handleCancel);

            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);

            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {

        }
        private void handleCancel(object sender, EventArgs e)
        {
            this.Hide();
            (new Tags()).Show();
        }

    }
}