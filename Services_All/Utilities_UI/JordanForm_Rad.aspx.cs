using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class JordanForm_Rad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] data_array = { txt_facilitylogin.Text.ToString(), txt_facilitypassword.Text.ToString(), txt_clinicianlogin.Text.ToString(), txt_clinicianpassword.Text.ToString() };
                txt_rich_box.InnerText = ExtraClasses.JordanCS_RAD.upload_rad_request(data_array, input_richbox.InnerText);
            }
            catch (Exception ex)
            {
                txt_rich_box.InnerText = ex.Message;
            }
        }
    }
}