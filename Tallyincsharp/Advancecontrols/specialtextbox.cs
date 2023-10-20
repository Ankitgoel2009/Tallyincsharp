using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tallyincsharp.Advancecontrols
{
    public partial class specialtextbox : TextBox
    {
        public specialtextbox()
        {

            this.ContextMenuStrip = new ContextMenuStrip();
            // trick to fix the height when you 
            base.AutoSize = false;    
            this.BorderStyle = BorderStyle.None;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region blocks default cut , copy and paste and change paste keys to alt+ctrl+v
        public const int WM_PASTE = 0x0302;
        public const int WM_CUT = 0x0300;
        public const int WM_COPY = 0x0301;

        // blocks the default cut , copy , paste
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPY || m.Msg == WM_CUT || m.Msg == WM_PASTE)
            {
                // DO NOTHING 
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            if ((msg.Msg == WM_KEYDOWN || msg.Msg == WM_SYSKEYDOWN) && keyData == (Keys.V | Keys.Alt | Keys.Control))
            {
                // Custom paste logic here               
                SelectedText = Clipboard.GetText();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // BELOW IS SUGGESTED BY CASTORIX BUT MINE ABOVE IS ALSO WORKING 
        // SO I HAVE NOT TRIED BELOW 
        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    if (e.KeyCode == Keys.V
        //        && (Control.ModifierKeys & Keys.Control) == Keys.Control
        //        && (Control.ModifierKeys & Keys.Alt) == Keys.Alt)
        //    {
        //        this.Paste(Clipboard.GetText());
        //    }
        //}
        #endregion

        #region changes backcolour according to parent form
        protected override void OnParentChanged(EventArgs e)
        {        
            if (this.Parent != null)
            {
                this.BackColor = this.Parent.BackColor;
            }
            base.OnParentChanged(e);
        }
        #endregion

        #region changes backcolor when entered and revert it back when lost focus 
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            // this.Select(0, 0);// code for dont selecting text 
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.ForeColor = Color.Black;
            this.BackColor = this.Parent.BackColor;
       
        }
        #endregion





    }
}
