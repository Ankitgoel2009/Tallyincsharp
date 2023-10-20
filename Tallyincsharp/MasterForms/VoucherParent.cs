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

namespace Tallyincsharp.MasterForms
{
    public partial class VoucherParent :thinblackborderform
    {
        public VoucherParent()
        {
            InitializeComponent();
        }

        private void VoucherParent_Load(object sender, EventArgs e)
        {
            Operations.UpdateLabelText("Accounting Voucher Creation");
        }
    }
}
