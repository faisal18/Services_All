using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class Dhpo_archiving : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_transactionids.Text.Length > 1)
                {
                    string process = rd_list.SelectedValue;
                    string input = txt_transactionids.Text.ToString();
                    string[] differences = { ",", "\t", "\n", "\r" };
                    string[] carry = input.Split(differences, StringSplitOptions.RemoveEmptyEntries);
                    ExtraClasses.Dhpo_archiving obj = new ExtraClasses.Dhpo_archiving();
                    txt_richbox.InnerText =  obj.archive(process,carry);
                }
            }
            catch(Exception ex)
            {
                txt_richbox.InnerText = ex.Message;
            }
        }
    }
}