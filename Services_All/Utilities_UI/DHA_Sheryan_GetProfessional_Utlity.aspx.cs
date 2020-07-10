using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Net;
using System.Text;

namespace Services_All.Utilities_UI
{
    public partial class DHA_Sheryan_GetProfessional_Utlity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

            string system_username = ConfigurationManager.AppSettings.Get("DHAProfessional_Username");
            string system_password = ConfigurationManager.AppSettings.Get("DHAProfessional_Password");
            string URL = ConfigurationManager.AppSettings.Get("DHAProfessional_URL");
            URL = URL + ConfigurationManager.AppSettings.Get("DHAProfessioanl_URL_Link");
            string token = system_username + ":" + system_password;
            //string data = string.Empty;

            try
            {
                token = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(token));

                if (txt_license.Text.Length > 1)
                {
                    string[] differences = { ",", "\t", "\n", "\r" };
                    string[] carry = txt_license.Text.Split(differences, StringSplitOptions.RemoveEmptyEntries);
                    StringBuilder sb = new StringBuilder();

                    foreach (string data in carry)
                    {
                        string data1 = "{\r\n  \"ProfessionalID\": \"" + data + "\"\r\n}";
                        string result1 = PostCall_ByBody(URL, data1, token);

                        sb.Append("Result for Professional " + data + "\n======================================\n" + result1 + "\n");
                    }

                    txt_rich_box.InnerText = sb.ToString();
                }

            }
            catch (Exception ex)
            {
                txt_rich_box.InnerText = ex.Message;
            }

        }

        public string PostCall_ByBody(string URL, string postdata, string staticToken)
        {
            string result = string.Empty;
            bool OKAY = false;
            int counter = 0;
            int counter_limit = int.Parse(ConfigurationManager.AppSettings.Get("counter_limit"));
            try
            {
                while (!OKAY)
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                            wc.Headers[HttpRequestHeader.Authorization] = staticToken;
                            Logger.Info("Sheryan called at " + DateTime.Now);
                            result = wc.UploadString(URL, postdata);
                            //CustomLog.Info(result);
                            if (result != null)
                                if (result.Length > 0)
                                {
                                    JObject yo = JObject.Parse(result);
                                    if (yo["ReturnCode"] != null)
                                    {
                                        Console.WriteLine("Return Code: " + yo["ReturnCode"].ToString());
                                        if (yo["ReturnCode"].ToString() == "00")
                                        {
                                            OKAY = true;
                                            result = yo.ToString();
                                        }
                                        if (yo["ReturnCode"].ToString() == "10" || yo["ReturnCode"].ToString() == "07")
                                        {
                                            OKAY = true;
                                            result = yo.ToString();

                                            //("Results found for data: " + postdata);
                                            //CustomLog.Info(yo["ReturnMessage"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        result = yo.ToString();
                                        Logger.Info(yo.ToString());
                                    }
                                }
                                else if (counter > counter_limit)
                                {
                                    OKAY = true;
                                    result = "Tried hitting the service " + counter_limit + " times but no results found";
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured in PostCall_ByBody !\n" + result);
                return ex.Message;
            }
        }
    }
}