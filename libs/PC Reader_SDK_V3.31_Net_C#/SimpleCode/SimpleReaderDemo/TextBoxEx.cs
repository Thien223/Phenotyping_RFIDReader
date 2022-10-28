using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SimpleReaderDemo
{
    public class TextBoxEx : System.Windows.Forms.TextBox
    {
        /// <summary>
        /// Input box to shield right button, copy, paste
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 0x007B && m.Msg != 0x0301 && m.Msg != 0x0302)
            {
                base.WndProc(ref m);
            }
        }
    }
}
