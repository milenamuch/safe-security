using System;

using System.Windows.Forms;
namespace Views.Lib
{
    public class ComboBoxGeneric : Form
    {
        public ComboBox comboBox;

        public ComboBoxGeneric(
            string Titulo,
            int X,
            int Y,
            int WidthComboBox
        )
        {
            comboBox = new ComboBox();
			comboBox.Name = Titulo;
            comboBox.Location = new System.Drawing.Point(X, Y);
            comboBox.Size = new System.Drawing.Size(WidthComboBox, 20);
        }
    }
}


