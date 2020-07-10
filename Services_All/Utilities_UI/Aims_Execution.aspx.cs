using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class Aims_Execution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_text.Text = Execute_Batch();
        }

        private string Execute_Batch()
        {
            try
            {
                string path = System.Configuration.ConfigurationManager.AppSettings["Aims_execution_batch_path"];
                Process.Start(path);
                return "Process Completed !";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}