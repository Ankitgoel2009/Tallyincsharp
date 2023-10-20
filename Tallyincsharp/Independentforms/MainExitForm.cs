using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tallyincsharp.helperclasses;
using Tallyincsharp.Borderforms;

namespace Tallyincsharp.Independentforms
{
    public partial class MainExitForm : thinblackborderform
    {
        public MainExitForm()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Enter) || keyData == (Keys.Y))
            {
                timer1.Start();
                return true;
            }
            else if (keyData == (Keys.N) || keyData == (Keys.Escape))
            {
                this.DialogResult = DialogResult.Cancel;   
                return false;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void MainExitForm_Load(object sender, EventArgs e)
        {
            button3.Left = -120;
            button1.TabStop = false;
            button2.TabStop = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.07;
            }
            else
            {
                timer1.Stop();
                Application.ExitThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
