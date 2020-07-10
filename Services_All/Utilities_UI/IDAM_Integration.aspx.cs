using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class IDAM_Integration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_result.Text = ExtraClasses.IDAM_Integration.run(txt_StartDate.Text, txt_username.Text, txt_password.Text, false);
            }
            catch(Exception ex)
            {
                lbl_result.Text = ex.Message;
            }
        }
    }
}