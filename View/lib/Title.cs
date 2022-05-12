using System;
using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib
{
    public class Title : Label
    {

        public Title(string Titulo, SizeScreen W)
        {

			this.Text = Titulo;
            switch (W)
            {
                case SizeScreen.Large:
                    this.Size = new Size(900, 30);
                    break;
                case SizeScreen.Medium:
                    this.Size = new Size(500, 30);
                    break;
                default:
                    this.Size = new Size(300, 30);
                    break;
            }
            this.BackColor = Color.LightBlue;
            this.Location = new Point(0, 0);
            this.Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);

        }       
    }
     
}
