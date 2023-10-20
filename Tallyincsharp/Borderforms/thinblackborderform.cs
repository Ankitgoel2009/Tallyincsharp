using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tallyincsharp.Borderforms
{
    public partial class thinblackborderform : Form
    {
        public thinblackborderform()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle borderRect = new Rectangle(0, 0, Width, Height);
            ControlPaint.DrawBorder(e.Graphics, borderRect, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid);
        }
        private void thinblackborderform_Load(object sender, EventArgs e)
        {

        }
    }
}
