using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tallyincsharp.Borderforms;
using Tallyincsharp.MasterForms;
using Tallyincsharp.helperclasses;

namespace Tallyincsharp.Independentforms
{
    public partial class Login : thinblackborderform
    {
        public Login()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
                {
                    //mainmaster master = (mainmaster)this.Parent.FindForm();
                    //master.RecreateCenterForm<VoucherParent>();
                    opencloseforms.RecreateCenterForm<VoucherParent>();
                }
                return true;
            }
            else if (keyData == (Keys.Escape))
            {
                opencloseforms.RecreateCenterForm<TDlloading_error>();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void Login_Load(object sender, EventArgs e)
        {
            //CURRENTFORM WAs a label in mainmaster and was made public

           // mainmaster master = (mainmaster)this.Parent.FindForm();
           // master.CurrentForm.Text = "LOGIN";
            Operations.UpdateLabelText("LOGIN");
            label1.Text += "Dummy";
            this.ActiveControl = textBox1;
        }
    }
}
