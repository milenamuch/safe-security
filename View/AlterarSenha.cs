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

        public AlterarSenha() : base("Alterar Senha",SizeScreen.Long)
        {
      

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
                string comboBoxValue = this.comboBox.Text; 
                string[] destructComboBoxValue = comboBoxValue.Split('-'); 
                string idCategoria = destructComboBoxValue[0].Trim(); 
                SenhaController.IncluirSenha(
                    this.fieldNome.txtField.Text,
                    Convert.ToInt32(idCategoria),
                    this.fieldUrl.txtField.Text,
                    this.fieldUsuario.txtField.Text,
                    this.fieldSenha.txtField.Text,
                    this.fieldProcedimento.txtField.Text
                );
                if (checkedList.SelectedItems.Count > 0) {
                    foreach (var item in checkedList.SelectedItems)
                    {
                        //SenhaTagController.InserirSenhaTag(0, item.ToString());
                    }
                    //this.Hide();

                } else {
                    MessageBox.Show("Selecione ao menos uma tag da lista");
                }

                this.Close();
                new Senhas().LoadInfo();
               
                
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }
        }
        private void handleCancel(object sender, EventArgs e)
        {
                new Senhas().Show();
                this.Close();
        }
    }
}