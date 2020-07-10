using System;

namespace Services_All.Utilities_UI
{
    public partial class DHCC_Client_AutoUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_text.Text = Run_Process();
            }
        }

        private static string Run_Process()
        {
            string result;
            bool is_QA = false;
            try
            {
                int NoofDaysFromDate = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NoofDaysFromDate"]);
                DateTime start = DateTime.Now;
                string date_start = start.AddDays(-(NoofDaysFromDate)).ToString("dd-MM-yyyy");
                string date_end = start.ToString("dd-MM-yyyy");
                Logger.Info("DHCC AUTO Process started for dates:" + date_start + " to " + date_end);

                is_QA =  Convert.ToBoolean(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Enviorment_isQA"]));
                Logger.Info("DHCC Process isQA :" + is_QA);
                result =  DHCC_Client.Control_Unit(false, true, date_start, date_end, "", is_QA);
                Logger.Info("DHCC AUTO process completed");
                return "DHCC AUTO process result \n" + result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ex.Message;
            }
        }
    }
}