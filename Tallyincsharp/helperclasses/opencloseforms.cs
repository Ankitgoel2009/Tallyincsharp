using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tallyincsharp.MasterForms;

namespace Tallyincsharp.helperclasses
{
  public static class opencloseforms
    {       

        // access mainmaster panel 
         public  static Panel mainmasterpanel;
        public static void getinstancevaluehere(Panel param)
        {
            mainmasterpanel = param;
        }
        // method created to return panel everywhere
        public static Panel GetPanelInstance()
        {
            return mainmasterpanel;
        }

        public static void RecreateCenterForm<T>() where T : Form, new()
        {
         
            // suggested by koz6.0
            foreach (Form oldForm in mainmasterpanel.Controls.OfType<Form>().ToArray())
            {
                using (oldForm)
                {
                    oldForm.Close();
                    mainmasterpanel.Controls.Remove(oldForm);
                }
            }

            var newForm = new T
            {
                TopLevel = false

            };

            if (newForm.Name ==  "VoucherParent")
            {
                newForm.WindowState = FormWindowState.Maximized;
              
            }
            else if(newForm.Name != "VoucherParent")
            {
                // Calculate the X and Y coordinates for centering the form
                int x = (mainmasterpanel.Width - newForm.Width) / 2;
                int y = (mainmasterpanel.Height - newForm.Height) / 2;
                //// Set the location of the form
                newForm.Location = new Point(x, y);
                newForm.StartPosition = FormStartPosition.CenterParent;
                newForm.Anchor = AnchorStyles.None;
            }
            newForm.FormBorderStyle = FormBorderStyle.None;            
            newForm.ControlBox = false;
            newForm.ShowInTaskbar = false;
            //   newForm.BringToFront();

            mainmasterpanel.Controls.Add(newForm);
            newForm.Show();
            newForm.Focus(); // sets the focus to newly form 

        }


    }
}
