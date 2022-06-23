using System;
using System.Windows.Forms;
using Views.Lib;
using Controllers;
using Models;
namespace Views
{
    public class AlterarTag : BaseForm
    {
        FieldForm fieldDescricao;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;
        Tags parent;
        ListViewItem selectedItem;
        int id = 0;

        public AlterarTag(Tags parent) : base("Alterar tag",SizeScreen.Small)
        {

            this.parent = parent;
            this.selectedItem = this.parent.listView.SelectedItems[0];
            this.id = Convert.ToInt32(this.selectedItem.Text);
        
            Tag tag = TagController.GetTag(id);

            fieldDescricao = new FieldForm("Descrição",30,80,240,20);  

			btnConfirmar = new ButtonForm("Confirmar", 30, 210, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170,210, this.handleCancel);

            this.fieldDescricao.txtField.Text = tag.Descricao;

            this.Controls.Add(fieldDescricao.lblField);
            this.Controls.Add(fieldDescricao.txtField);

            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }

        private void handleConfirm(object sender, EventArgs e)
        {
            try{
                TagController.AlterarTag(
                    this.id,
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