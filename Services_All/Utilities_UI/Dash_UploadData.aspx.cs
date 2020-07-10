using System;
using System.Threading.Tasks;

namespace Services_All.Utilities_UI
{
    public partial class Dash_UploadData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Run_Processes();
                //Run_ProcessesAsync();
                lbl_result.Text = "Faisal has stopped uploading data";
            }
        }

        private void Run_Processes()
        {
            bool[] result = new bool[3];
            try
            {
                lbl_result.Text = "Process started at:"+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                result[0] =  ExtraClasses.Monitoring_UploadData.InsertFrom_PBM();
                result[1] =  ExtraClasses.Monitoring_UploadData.InsertFrom_ERX();
                result[2] =  ExtraClasses.Monitoring_UploadData.InsertFrom_DHPO();
                lbl_result.Text += "<br />Process finished at:" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch(Exception ex)
            {
                lbl_result.Text += "<br />Error Occured: "+ex.Message;
            }
            lbl_result.Text += "<br />PBM:" + result[0] + "<br />ERX:" +result[1] + "<br />DHPO:" + result[2];
        }
        private void Run_ProcessesAsync()
        {
            var PBMresult = InsertPBM();
            var ERXresult = InsertERX();
            var DHPOresult = InsertDHPO();
            // x.Wait(10);
            lbl_result.Text = "PBM:" + PBMresult.Result + "<br/>ERX:" + ERXresult.Result + "<br/>DHPO:" + ERXresult.Result;
        }

        public static async Task<bool> InsertPBM()
        {
            try
            {
                bool result = ExtraClasses.Monitoring_UploadData.InsertFrom_PBM();
                await Task.Delay(10);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }
        public static async Task<bool> InsertERX()
        {
            try
            {
                bool result = ExtraClasses.Monitoring_UploadData.InsertFrom_ERX();
                await Task.Delay(10);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }
        public static async Task<bool> InsertDHPO()
        {
            try
            {
                bool result = ExtraClasses.Monitoring_UploadData.InsertFrom_DHPO();
                await Task.Delay(10);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //   Run_Processes();
            TextBox1.Text = DateTime.Now.ToString();
            Run_ProcessesAsync();
            TextBox1.Text = TextBox1.Text +Environment.NewLine + DateTime.Now.ToString();
        }
    }
}