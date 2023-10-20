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
using Tallyincsharp.Independentforms;

namespace Tallyincsharp.MasterForms
{
    public partial class mainmaster : Form
    {
        //code for disabling close button 
        private const int NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | NOCLOSE_BUTTON;
                return myCp;
            }
        }

     

        public mainmaster()
        {
            InitializeComponent();
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
           Operations.LabelTextChanged += Operations_LabelTextChanged;
           Operations.PanelAccessChanged += opencloseforms.getinstancevaluehere;
            toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
            )));
            toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            toolStripStatusLabel1.Size = new System.Drawing.Size(246, 20);
            toolStripStatusLabel1.Spring = true;




            toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
           | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
           )));
            toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;


            toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
           | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
           )));
            toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;


            toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
           | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
           )));
            toolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            toolStripStatusLabel4.Size = new System.Drawing.Size(24, 20);
          
         
        }

        private void mainmaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            // prevent the user from closing the from  directly by taksbar 
            e.Cancel = true;
        }

        private void mainmaster_Load(object sender, EventArgs e)
         {
            Timer timer = new Timer();
            timer.Interval = 1000; // Update every second
            timer.Tick += Timer_Tick;
            timer.Start();
            string formattedDate = DateTime.Now.ToString("ddd, d MMM, yyyy");
            toolStripStatusLabel3.Text = formattedDate;
            toolStripStatusLabel2.Text = "\u00A9 Shaifali Solution Pvt Ltd.,2020-2023";
            toolStripStatusLabel1.Text = "Tally MAIN";
            Operations.UpdatePanel(Mainmasterpanel); // ok 
            opencloseforms.RecreateCenterForm<TDlloading_error>();
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        //one time dclaration of this method on this page 
        private void Operations_LabelTextChanged(string text)
        {
            openformname.Text = text;
        }


    }
}

