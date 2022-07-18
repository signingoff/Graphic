using FastColoredTextBoxNS;
using System.Drawing;
using System.Windows.Forms;

namespace GEdit
{
    public class CustomText: FastColoredTextBox
    {
        public CustomText(){
            this.Dock = DockStyle.Fill;
            this.Name = "textbox";
            this.LineNumberColor = Color.White;
            this.BackColor = Color.FromArgb(51,51,51);
            this.BorderStyle = BorderStyle.None;
            this.ForeColor = Color.White;
        }
    }
}
