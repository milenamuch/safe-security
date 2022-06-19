using System;
using System.Windows.Forms;
using System.Drawing;

namespace Views.Lib
{
    public class CheckedListBoxGeneric : Form
    {
        public CheckedListBox checkedListBox;

        public CheckedListBoxGeneric(
            int X,
            int Y,
            int WidthCheckedListBox,
            int HeighCheckedListBox
        )
        {
            checkedListBox = new CheckedListBox();
            checkedListBox.Location = new System.Drawing.Point(X, Y);
            checkedListBox.Size = new System.Drawing.Size(WidthCheckedListBox, HeighCheckedListBox);
			checkedListBox.CheckOnClick = true;
            checkedListBox.SelectionMode = SelectionMode.One;
        }
    }
}


