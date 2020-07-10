using System;
using System.Web.UI;

namespace Services_All
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_name.Text.Length > 0)
                {
                    //lbl_response.Text = Automation.Processes.Processes.run_process(txt_text.Text, txt_name.Text);
                }
                else if (txt_name.Text.Length == 0)
                {
                    //lbl_response.Text = Automation.Processes.Static_processes.run_process(txt_text.Text);
                }
            }
            catch (Exception ex)
            {
                lbl_response.Text = ex.Message;
            }
        }
    }
}