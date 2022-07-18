using System;
using System.Windows.Forms;

namespace GEdit
{
    public class CustomTab : TabPage
    {
       

        public String fileName = "";
 
        public CustomTab()
        {
            this.Text = "New Tab";
            var hor = new SplitContainerX();
            var con = new ConsoleControl.ConsoleControl();
            con.StopProcess();
 

            con.Name = "CON";

            con.Dock = DockStyle.Fill;
             con.BorderStyle = BorderStyle.None;
            con.Padding = new Padding(0);
            con.Margin = new Padding(0);
            con.InternalRichTextBox.BorderStyle = BorderStyle.None;
            this.Controls.Add(hor);
 
            hor.Panel2.Controls.Add(con);
            hor.Panel2Collapsed = true;
        }
    }
}
