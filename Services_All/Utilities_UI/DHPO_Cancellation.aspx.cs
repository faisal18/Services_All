using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class DHPO_Cancellation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_transID.Text.Length > 1)
                {
                    string[] differences = { ",", "\t", "\n", "\r" };
                    string[] carry = txt_transID.Text.Split(differences, StringSplitOptions.RemoveEmptyEntries);

                    ExtraClasses.DHPO_Cancellation obj = new ExtraClasses.DHPO_Cancellation();

                    foreach (string data in carry)
                    {
                        lbl_message.InnerText = obj.Execute(data,false);
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