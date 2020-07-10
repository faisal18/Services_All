using System;


namespace Services_All
{
    public partial class Valdiate_Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                
                
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string service = null;
            lbl_response.Text = null;
            if (rd_erx.Checked == true)
                service = "erx";
            else if (rd_clinician.Checked == true)
                service = "clinician";
            else if (rd_dhpo.Checked == true)
                service = "dhpo";
            else if (rd_pbmswitch_dimensions.Checked == true)
                service = "pbmswitch";
            else if (rd_pbmswitch_member.Checked == true)
                service = "pbm_member";
            else if (rd_pbmswitch_payer.Checked == true)
                service = "pbm_payer";
            else if (rd_lmu.Checked == true)
                service = "lmu";
            else if (rd_ceed_gateway.Checked == true)
                service = "ceed";
            else if (rd_member_registration.Checked == true)
                service = "member";
            else if (rd_shafafiya.Checked == true)
                service = "shafafiya";

            Validate_Service vs = new Validate_Service();
            vs.validate(service);
            string output;
            try
            {
                output =
                //"The Result for the " + service + " Web Service is " + "\n" +
                "Response Code: " + Result.Instantce.responsecode + "\n" +
                "Response UID: " + Result.Instantce.uid + "\n" +
                //"Response Message Code: " + Result.Instantce.str_responsecode + "\n" +
                "Response Message: " + Result.Instantce.ResMessage + "\n" +
                "Response Error Message: " + Result.Instantce.errorMessage + "\n" +
                "Response Exception: " + Result.Instantce.exceptionMessage + "\n";
                txt_richbox.InnerText = output;

                if (Result.Instantce.exceptionMessage == null && Result.Instantce.errorMessage == null)
                    lbl_response.Text = "PASS";
                else if (Result.Instantce.exceptionMessage == null && Result.Instantce.errorMessage != null)
                    lbl_response.Text = "Acceptable";
                else if (Result.Instantce.exceptionMessage != null)
                    lbl_response.Text = "FAIL";

            }
            catch (Exception ex)
            {
                output = "Exception Occured !" + "\n" +
                    "Exception: " + ex.Message.ToString() + "\n" +
                    "Inner Exception: " + ex.InnerException;
                txt_richbox.InnerText = output;

            }
        }

        protected void rd_erx_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = true;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = false;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_dhpo_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = true;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = false;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_pbmswitch_dimensions_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = true;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = false;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_pbmswitch_member_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = true;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = false;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_pbmswitch_payer_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = true;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = false;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_lmu_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = true;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = false;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_ceed_gateway_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = true;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = false;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_member_registration_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = true;
            rd_shafafiya.Checked = false;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_shafafiya_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = true;
            txt_richbox.InnerText = null;
            rd_clinician.Checked = false;
            lbl_response.Text = null;
        }

        protected void rd_clinician_CheckedChanged(object sender, EventArgs e)
        {
            rd_erx.Checked = false;
            rd_dhpo.Checked = false;
            rd_pbmswitch_dimensions.Checked = false;
            rd_pbmswitch_member.Checked = false;
            rd_pbmswitch_payer.Checked = false;
            rd_lmu.Checked = false;
            rd_ceed_gateway.Checked = false;
            rd_member_registration.Checked = false;
            rd_shafafiya.Checked = false;
            rd_clinician.Checked = true;
            txt_richbox.InnerText = null;
            lbl_response.Text = null;
        }
    }
}