using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class Eclaim_Add_MissingDrug : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ScientificCode.Text.Length > 1)
                {
                    string[] differences = { ",", "\t", "\n", "\r" };
                    string[] carry = txt_ScientificCode.Text.Split(differences, StringSplitOptions.RemoveEmptyEntries);
                    ExtraClasses.Eclaim_Add_MissingDrug obj = new ExtraClasses.Eclaim_Add_MissingDrug();
                    foreach (string data in carry)
                    {
                        lbl_message.InnerText =lbl_message.InnerText + obj.execute(data);
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_message.InnerText = ex.Message;
            }
        }
    }
}