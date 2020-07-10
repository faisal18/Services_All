using System;
using System.Configuration;

namespace Services_All.Utilities_UI
{
    public partial class NahdiVPN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            ExtraClasses.NahdiVpn obj = new ExtraClasses.NahdiVpn();
            //string path = ConfigurationManager.AppSettings["misc"] + "Nahdi_" + file_upload.FileName.ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            //file_upload.PostedFile.SaveAs(@path);
            string path = input_richbox.InnerText.ToString();
            string process = null;
            if (rd_bupa.Checked == true)
                process = "bupa";
            else if (rd_waseel.Checked == true)
                process = "waseel";
            else if (rd_waseel_submission.Checked == true)
                process = "waseelsub";
            string result = obj.getelig(process, path);
            txt_rich_box.InnerText = Convert.ToString(result);
        }

        protected void rd_bupa_CheckedChanged(object sender, EventArgs e)
        {
            rd_bupa.Checked = true;
            rd_waseel.Checked = false;
            rd_waseel_submission.Checked = false;
        }

        protected void rd_waseel_CheckedChanged(object sender, EventArgs e)
        {
            rd_waseel.Checked = true;
            rd_bupa.Checked = false;
            rd_waseel_submission.Checked = false;
        }

        protected void rd_waseel_submission_CheckedChanged(object sender, EventArgs e)
        {
            rd_waseel.Checked = false;
            rd_bupa.Checked = false;
            rd_waseel_submission.Checked = true;
        }
    }
}