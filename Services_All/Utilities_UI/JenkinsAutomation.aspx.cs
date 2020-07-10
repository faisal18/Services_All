using System;

namespace Services_All.Utilities_UI
{
    public partial class JenkinsAutomation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            ExtraClasses.JenkinsAutomation jenk_obj = new ExtraClasses.JenkinsAutomation();
            try
            {
                string result = jenk_obj.run_batch();
                txt_richbox.InnerText = result;
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = "Exception Occured: " + ex.Message.ToString();
            }
        }
    }
}