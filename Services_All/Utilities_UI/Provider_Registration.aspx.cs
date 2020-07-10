using System;
using System.Configuration;



namespace Services_All.Utilities_UI
{
    public partial class Provider_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void rd_registerprovider_CheckedChanged(object sender, EventArgs e)
        {
            rd_registerprovider.Checked = true;
            rd_editprovider.Checked = false;
            rd_editprovidertype.Checked = false;
            pnl_editprovidertype.Visible = false;
            pnl_registerprovider.Visible = true;
            txt_richbox.InnerText = null; 
            div_region.Style.Add("display", "none");
            rd_editproviderlicense.Checked = false;
            div_old_license.Style.Add("display", "none");

        }

        protected void rd_editprovider_CheckedChanged(object sender, EventArgs e)
        {
            rd_registerprovider.Checked = false;
            rd_editprovider.Checked = true;
            rd_editprovidertype.Checked = false;
            pnl_editprovidertype.Visible = false;
            pnl_registerprovider.Visible = true;
            txt_richbox.InnerText = null;
            div_region.Style.Add("display", "block");

            rd_editproviderlicense.Checked = false;
            div_old_license.Style.Add("display", "none");
        }

        protected void rd_editprovidertype_CheckedChanged(object sender, EventArgs e)
        {
            rd_registerprovider.Checked = false;
            rd_editprovider.Checked = false;
            rd_editprovidertype.Checked = true;
            pnl_editprovidertype.Visible = true;
            pnl_registerprovider.Visible = false;
            txt_richbox.InnerText = null;
            rd_editproviderlicense.Checked = false;
            div_old_license.Style.Add("display", "none");
        }

        protected void rd_editproviderlicense_CheckedChanged(object sender, EventArgs e)
        {
            rd_registerprovider.Checked = false;
            rd_editprovider.Checked = false;
            rd_editprovidertype.Checked = false;

            pnl_editprovidertype.Visible = false;
            pnl_registerprovider.Visible = true;
            txt_richbox.InnerText = null;
            div_region.Style.Add("display", "block");

            rd_editproviderlicense.Checked = true;
            div_old_license.Style.Add("display", "block");
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string process = "";
            if (rd_registerprovider.Checked == true)
                process = "register";
            else if (rd_editprovider.Checked == true)
                process = "editprovider";
            else if (rd_editprovidertype.Checked == true)
                process = "editprovidertype";
            else if (rd_editproviderlicense.Checked == true)
                process = "editproviderlicense";

            switch (process)
            {

                case "register":
                    if (txt_pbmnpicode.Text != "" && txt_providername.Text != "" && txt_licenseid.Text != "")
                    {
                        ExtraClasses.Provider_Registration obj = new ExtraClasses.Provider_Registration();
                        txt_richbox.InnerText = obj.register_provider(txt_pbmnpicode.Text, txt_providername.Text, txt_licenseid.Text, txt_haadusername.Text, txt_haadpassword.Text, ddl_region.SelectedValue, getkey());
                    }
                    else
                    {
                        txt_richbox.InnerText = "Please enter data in the fields";
                    }
                    break;
                case "editprovider":
                    if (txt_pbmnpicode.Text != "" && txt_providername.Text != "" && txt_licenseid.Text != "")
                    {
                        ExtraClasses.Provider_Registration obj = new ExtraClasses.Provider_Registration();
                        txt_richbox.InnerText = obj.edit_provider(txt_pbmnpicode.Text, txt_providername.Text, txt_licenseid.Text, txt_haadusername.Text, txt_haadpassword.Text, ddl_region.SelectedValue, ddl_isactive.SelectedValue, getkey());
                    }
                    else
                    {
                        txt_richbox.InnerText = "Please enter data in the fields";
                    }
                    break;
                case "editprovidertype":
                    if (pnl2_txt_licenseid.Text != "")
                    {
                        ExtraClasses.Provider_Registration obj = new ExtraClasses.Provider_Registration();
                        txt_richbox.InnerText = obj.edit_provider_type(pnl2_txt_licenseid.Text, Convert.ToInt32(pnl2_ddl_switchtype.SelectedValue), getkey());
                    }
                    else
                    {
                        txt_richbox.InnerText = "Please enter data in the fields";
                    }
                    break;

                case "editproviderlicense":
                    if (txt_pbmnpicode.Text != "" && txt_providername.Text != "" && txt_licenseid.Text != "")
                    {
                        ExtraClasses.Provider_Registration obj = new ExtraClasses.Provider_Registration();
                        txt_richbox.InnerText = obj.edit_provider_license(txt_pbmnpicode.Text, txt_providername.Text,txt_old_license.Text,txt_licenseid.Text, ddl_region.SelectedValue, txt_haadusername.Text, txt_haadpassword.Text, ddl_isactive.SelectedValue, getkey());
                    }
                    else
                    {
                        txt_richbox.InnerText = "Please enter data in the fields";
                    }
                    break;
            }
        }

        public string getkey()
        {
            string key = ConfigurationManager.AppSettings["Provider_Reg_Key"].ToString();
            return key;
        }

        
    }
}