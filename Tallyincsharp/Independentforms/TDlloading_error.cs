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
using Tallyincsharp.Independentforms;

namespace Tallyincsharp.Independentforms
{
    public partial class TDlloading_error : thinblackborderform
    {
       
        public TDlloading_error()
        {
            InitializeComponent();           

        }
      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // if the user presses escape , a mainexit form should open asking for exit 
            if (keyData == (Keys.Escape))
            {
               
                formbackground formBackground = new formbackground(this);
                //commented due to using delegate 
                // mainmaster main = (mainmaster)this.Parent.FindForm();
                // Panel mainmasterpanel = main.Mainmasterpanel;

                // get refernce of main panel 
                Panel masterpanelrefernece = opencloseforms.GetPanelInstance();
                Rectangle bounds = masterpanelrefernece.Parent.RectangleToScreen(masterpanelrefernece.Bounds);
                Point panelLocation = masterpanelrefernece.Location;
                Point screenLocation = masterpanelrefernece.PointToScreen(panelLocation);
                formBackground.Location = screenLocation;
                formBackground.Bounds = bounds;
                formBackground.Show(this);
                using (MainExitForm mx = new MainExitForm())
                {
                    mx.StartPosition = FormStartPosition.CenterParent;
                    mx.ShowInTaskbar = false;
                    mx.ShowDialog(formBackground);
                    if (mx.DialogResult == DialogResult.Cancel)
                    {                        
                        mx.Close();   
                    }
                }
                formBackground.Close();
                formBackground = null;
                return true;
            }
            else if (keyData == (Keys.Enter))
            {
                opencloseforms.RecreateCenterForm<Login>();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void TDlloading_error_Load(object sender, EventArgs e)
        {
            HideButtonsInParentFormTableLayoutPanel();
            //  this class will send 
           Operations.UpdateLabelText("Account TDL Loading ");    //ok     
            mainmaster parentForm =(mainmaster) this.Parent.FindForm();
            parentForm.toolStripStatusLabel1.Text += " --> Account TDL Loading";


        }
      
        private void HideButtonsInParentFormTableLayoutPanel()
        {
            // Access the parent form
            Form parentForm = this.Parent.FindForm();

            // Check if the parent form exists and contains a TableLayoutPanel
            if (parentForm != null && parentForm.Controls.ContainsKey("sideLayoutPanel"))
            {
                TableLayoutPanel tableLayoutPanel = parentForm.Controls["sideLayoutPanel"] as TableLayoutPanel;

                // Hide the buttons in the TableLayoutPanel
                if (tableLayoutPanel != null)
                {
                    foreach (Control control in tableLayoutPanel.Controls)
                    {
                        if (control is Button button)
                        {
                            button.Visible = false;
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TDlloading_error_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainmaster parentForm = (mainmaster)this.Parent.FindForm();
            string currentText = parentForm.toolStripStatusLabel1.Text;
            string textToRemove = " --> Account TDL Loading";
            string updatedText = currentText.Replace(textToRemove, "");
            parentForm.toolStripStatusLabel1.Text = updatedText;
        }
    }
}
