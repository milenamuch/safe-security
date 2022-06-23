using System;
using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib
{
    public class FieldsRich : Form
    {
        public RichTextBox txtField;
        public Label lblField;

        public FieldsRich(
            string Titulo,
            int X,
            int Y,
            int WidthTextBox,
            int HeightTextBox
        )
        {
            lblField = new Label();
			lblField.Text = Titulo;
            lblField.Location = new Point(X, Y);
            lblField.Size = new Size(WidthTextBox, 20);
           
            txtField = new RichTextBox();
            txtField.Location = new Point(X, Y + 25);
            txtField.Size = new Size(WidthTextBox, HeightTextBox);
        }
    }
}