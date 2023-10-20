using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tallyincsharp.helperclasses;

namespace Tallyincsharp.helperclasses
{
    internal class Operations
    {
       static  Operations()
        {
            PanelAccessChanged += opencloseforms.getinstancevaluehere;
        }
        //  label delegate part
        public delegate void LabelTextDelegate(string name);
        public static event LabelTextDelegate LabelTextChanged;

        public static void UpdateLabelText(string newlabelname)
        {
            LabelTextChanged?.Invoke(newlabelname);
        }
        //paneldelegate part 


        
        public delegate void PanelAccessDelegate(Panel panel);

        public static event PanelAccessDelegate PanelAccessChanged;

        
        public static void UpdatePanel(Panel panel)
        {
            PanelAccessChanged?.Invoke(panel);
        }
       


    }
}
