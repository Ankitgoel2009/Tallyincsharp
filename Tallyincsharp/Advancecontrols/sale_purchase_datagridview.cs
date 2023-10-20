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

namespace Tallyincsharp.Advancecontrols
{
    public partial class sale_purchase_datagridview : DataGridView
    {
        DataGridView dgv; 
        public sale_purchase_datagridview()
        {
            InitializeComponent();
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold); // HEADER FONT BOLD 
            this.SetCommon();
            dgv = Application.OpenForms["VoucherParent"].Controls["dataGridView1"] as DataGridView;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        //PREVENT EATING OF ARROW KEYS BY TEXTBOX INSIDE DATAGRIDVIEW 
        // important method
        protected override bool ProcessKeyPreview(ref Message m)
        {
             MessageBox.Show("1 ProcessKeyPreview");
            KeyEventArgs args1 = new KeyEventArgs(((Keys)((int)m.WParam)) | Control.ModifierKeys);
            switch (args1.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:


                    return false;
            }
            return base.ProcessKeyPreview(ref m);
        }
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            // only place where it is working 
            e.CellStyle.BackColor = Color.FromArgb(0, 0, 0); // change cell color to black 
            e.CellStyle.ForeColor = Color.FromArgb(255, 255, 255); // change cell color to white  
            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold | FontStyle.Italic);
        }




        }
}
