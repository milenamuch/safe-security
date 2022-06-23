using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Views.Lib;
using Controllers;
using Models;

namespace Views
{
    public class AlterarSenha : BaseForm
    {
       
        FieldForm fieldNome;
        FieldForm fieldCategoria;
        FieldForm fieldUrl;
        FieldForm fieldUsuario;
        FieldForm fieldSenha;
        FieldForm fieldTag;
        CheckedListBox checkedList;
        FieldsRich fieldProcedimento;
        ComboBox comboBox;
		ButtonForm btnConfirmar;
        ButtonForm btnCancelar;

        Senhas parent;

        public AlterarSenha(Senhas parent) : base("Alterar Senha",SizeScreen.Long)
        {
            this.parent = parent;
            this.parent.Hide();

            fieldNome = new FieldForm("Nome",30,30,240,20);
            fieldCategoria = new FieldForm("Categoria",30,90,260,60);
            fieldUrl = new FieldForm("Url",30,150,240,20);
            fieldSenha = new FieldForm("Senha",30,210,240,20);
            fieldUsuario = new FieldForm("Usuário",30,270,240,20);
            fieldProcedimento = new FieldsRich("Procedimento",30,330,240,120);
            fieldTag = new FieldForm("Tag",30,480,260,60);

            IEnumerable<Tag> tags = TagController.GetTags();
            checkedList = new CheckedListBox();
			this.checkedList.Location = new System.Drawing.Point(30, 510);
            this.checkedList.Size = new System.Drawing.Size(240, 80);
            this.checkedList.TabIndex = 0;
            checkedList.CheckOnClick = true;
            foreach (Tag item in tags)
            {
                checkedList.Items.Add("ID: " + item.Id + " | Descrição: " + item.Descricao);
            }

            IEnumerable<Categoria> categorias = CategoriaController.GetCategorias();
            comboBox = new ComboBox(); 
            comboBox.Location = new System.Drawing.Point(30, 110);
            comboBox.Name = "Categoria";
            comboBox.Size = new System.Drawing.Size(240, 15); 
            foreach (Categoria item in categorias)
            {
                comboBox.Items.Add("ID: " + item.Id + " | Nome: " + item.Nome);
            }
       
			btnConfirmar = new ButtonForm("Confirmar", 30, 620, this.handleConfirm);
            btnCancelar = new ButtonForm("Cancelar", 170, 620, this.handleCancel);

            this.Controls.Add(checkedList);
            this.Controls.Add(comboBox);
            this.Controls.Add(fieldNome.lblField);
            this.Controls.Add(fieldNome.txtField);
            this.Controls.Add(fieldCategoria.lblField); 
            this.Controls.Add(fieldUrl.lblField);
            this.Controls.Add(fieldUrl.txtField);
            this.Controls.Add(fieldUsuario.lblField);
            this.Controls.Add(fieldUsuario.txtField);
            this.Controls.Add(fieldSenha.lblField);
            this.Controls.Add(fieldSenha.txtField);
            this.Controls.Add(fieldProcedimento.lblField);
            this.Controls.Add(fieldProcedimento.txtField);
            this.Controls.Add(fieldTag.lblField);
            this.Controls.Add(btnConfirmar);
            this.Controls.Add(btnCancelar);
        }
        private void handleConfirm(object sender, EventArgs e)
        {
            try {
                if (checkedList.CheckedItems.Count == 0) 
                {
                    MessageBox.Show("Selecione um item da lista");
                    return;
                }

                string comboBoxValue = this.comboBox.Text; 
                string[] destructComboBoxValue = comboBoxValue.Split('-'); 
                string idCategoria = destructComboBoxValue[0].Trim(); 
                ListViewItem item = this.parent.listView.SelectedItems[0];
                int id = Convert.ToInt32(item.Text);
                SenhaController.AlterarSenha(
                    id,
                    this.fieldNome.txtField.Text,
                    Convert.ToInt32(idCategoria),
                    this.fieldUrl.txtField.Text,
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text,
                    this.fieldProcedimento.txtField.Text
                    //TAG??
                );
                
                IEnumerable<Tag> tags = TagController.GetTags();
                foreach (Tag tag in tags)
                {
                    SenhaTag senhaTag = SenhaTagController.GetSenhaTag(id, tag.Id);
                    bool checkedSenhaTag = checkedList.CheckedItems.Contains(tag.ToString());
                    if (checkedSenhaTag && senhaTag == null) {
                        SenhaTagController.InserirSenhaTag(id, tag.Id);
                    }
                    if (!checkedSenhaTag && senhaTag != null) {
                        SenhaTagController.ExcluirSenhaTag(senhaTag.Id);
                    }
                }

                this.parent.LoadInfo();
                this.parent.Show();
                this.Close();
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
                 this.parent.Show();
                this.Close();
        }
    }
}