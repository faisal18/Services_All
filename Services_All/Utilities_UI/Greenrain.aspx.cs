using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class Greenrain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_ddl();
                nullify_gridsource();
            }
            else
            {
                //bind_gridsource();
                //nullify_gridsource();
            }
        }

        #region User Data 

        void fill_ddl()
        {
            ddl_caller.DataSource = CreateDataSource();
            ddl_caller.DataTextField = "Text";
            ddl_caller.DataValueField = "Value";
            ddl_caller.DataBind();

            txt_UserName.Text = login(ddl_caller.SelectedValue);
            txt_Password.Text = password(ddl_caller.SelectedValue);
        }

        ICollection CreateDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Text", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(string)));

            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/greenrain_users_profile.csv")))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    dt.Rows.Add(CreateRow(values[0], values[1], dt));
                }
            }
            DataView dv = new DataView(dt);
            return dv;
        }

        DataRow CreateRow(string Text, string Value, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr[0] = Value;
            dr[1] = Text;

            return dr;
        }

        string login(string value)
        {
            string login = null;
            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/greenrain_users_profile.csv")))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] == value)
                    {
                        login = values[2];
                    }
                }
            }
            return login;
        }

        string password(string value)
        {
            string password = null;
            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/greenrain_users_profile.csv")))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0] == value)
                    {
                        password = values[3];
                    }
                }
            }
            return password;
        }

        protected void ddl_caller_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_UserName.Text = login(ddl_caller.SelectedValue);
            txt_Password.Text = password(ddl_caller.SelectedValue);
            txt_richbox.InnerText = null;
            nullify_gridsource();
        }

        protected void btn_add_newuser_Click(object sender, EventArgs e)
        {
            btn_add_newuser.Visible = false;
            pnl_add_user.Visible = true;
            nullify_gridsource();
        }

        protected void btn_add_user_submit_Click(object sender, EventArgs e)
        {
            btn_add_newuser.Visible = true;
            int max = 0;
            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/greenrain_users_profile.csv")))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (Convert.ToInt32(values[0]) > max)
                    {
                        max = Convert.ToInt32(values[0]);
                    }
                }
            }
            max = max + 1;
            StringBuilder csv = new StringBuilder();
            var data = string.Format("{0},{1},{2},{3}", max, txt_pnl_add_license.Text.ToString(), txt_pnl_add_username.Text.ToString(), txt_pnl_add_password.Text.ToString());
            csv.AppendLine(data);
            File.AppendAllText(Server.MapPath("~/App_Data/greenrain_users_profile.csv"), csv.ToString());
            fill_ddl();
            pnl_add_user.Visible = false;
        }

        protected void btn_cancel_user_submit_Click(object sender, EventArgs e)
        {
            btn_add_newuser.Visible = true;
            pnl_add_user.Visible = false;
        }

        #endregion

        //METHOD SELECTION
        protected void ddl_selectmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string casei = ddl_selectmethod.SelectedValue;
            nullify_gridsource();
            switch (casei)
            {
                case "1":
                    pnl_AddDrgToEclaim.Visible = true;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    pnl_uploadTransaction.Visible = false;
                    txt_richbox.InnerText = null;
                    pnl_downloadtransactionfile.Visible = false;
                    pnl_getnewtransactions.Visible = false;

                    break;
                case "2":
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = true;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    pnl_uploadTransaction.Visible = false;
                    txt_richbox.InnerText = null;
                    pnl_downloadtransactionfile.Visible = false;
                    pnl_getnewtransactions.Visible = false;

                    break;
                case "3":
                    pnl_GetDrugDetails.Visible = true;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    pnl_uploadTransaction.Visible = false;
                    txt_richbox.InnerText = null;
                    pnl_downloadtransactionfile.Visible = false;
                    pnl_getnewtransactions.Visible = false;

                    break;
                case "4":
                    pnl_getNewPat.Visible = true;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    pnl_uploadTransaction.Visible = false;
                    txt_richbox.InnerText = null;
                    pnl_downloadtransactionfile.Visible = false;
                    pnl_getnewtransactions.Visible = false;

                    break;
                case "5":
                    pnl_getPrescription.Visible = true;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    pnl_uploadTransaction.Visible = false;
                    txt_richbox.InnerText = null;
                    pnl_downloadtransactionfile.Visible = false;
                    pnl_getnewtransactions.Visible = false;

                    break;
                case "6":
                    pnl_searchtransaction.Visible = true;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    pnl_uploadTransaction.Visible = false;
                    txt_richbox.InnerText = null;
                    pnl_downloadtransactionfile.Visible = false;
                    pnl_getnewtransactions.Visible = false;

                    break;
                case "7":
                    pnl_setTranDownloaded.Visible = true;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_uploadTransaction.Visible = false;
                    txt_richbox.InnerText = null;
                    pnl_downloadtransactionfile.Visible = false;
                    pnl_getnewtransactions.Visible = false;

                    break;
                case "8":
                    pnl_uploadTransaction.Visible = true;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    pnl_downloadtransactionfile.Visible = false;
                    pnl_getnewtransactions.Visible = false;
                    txt_richbox.InnerText = null;

                    break;
                case "9":
                    pnl_getnewtransactions.Visible = true;
                    pnl_uploadTransaction.Visible = false;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    pnl_downloadtransactionfile.Visible = false;
                    txt_richbox.InnerText = null;

                    break;
                case "10":
                    pnl_downloadtransactionfile.Visible = true;
                    pnl_getnewtransactions.Visible = false;
                    pnl_uploadTransaction.Visible = false;
                    pnl_AddDrgToEclaim.Visible = false;
                    pnl_CheckForNewPriorAuthourizationTransactions.Visible = false;
                    pnl_GetDrugDetails.Visible = false;
                    pnl_getNewPat.Visible = false;
                    pnl_getPrescription.Visible = false;
                    pnl_searchtransaction.Visible = false;
                    pnl_setTranDownloaded.Visible = false;
                    txt_richbox.InnerText = null;

                    break;
            }
        }

        #region WebService Methods

        //ADD DRUG TO ECLAIM
        protected void btn_pnl1_Submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (pnl1_fileupload.HasFile == true && txt_pnl1_originalfilename.Text != "" && txt_pnl1_baserate.Text != "")
                {
                    if (pnl1_fileupload.PostedFile.ContentType == "XML")
                    {
                        if (pnl1_fileupload.PostedFile.ContentLength <= 102400)
                        {
                            ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                            //string filename = Path.GetFileName(pnl1_fileupload.FileName);

                            //string path = Server.MapPath("~/App_Data/Files/" + pnl1_fileupload.FileName.ToString());
                            string path = ConfigurationManager.AppSettings["misc"] + "Nahdi_" + pnl1_fileupload.FileName.ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");

                            pnl1_fileupload.PostedFile.SaveAs(@path);

                            string response = shaf.AddDrgtoEclaim(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), path, txt_pnl1_originalfilename.Text.ToString(), txt_pnl1_baserate.Text.ToString());
                            txt_richbox.InnerText = "Result: " + response + System.Environment.NewLine +
                            "Response Code: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                            "Drug File Content: " + ExtraClasses.Shafafiya_Result.Instantce.drgFileContent + System.Environment.NewLine +
                            "Drug File Name: " + ExtraClasses.Shafafiya_Result.Instantce.drgFileName + System.Environment.NewLine +
                            "Audit File Content: " + ExtraClasses.Shafafiya_Result.Instantce.AuditFileContent + System.Environment.NewLine +
                            "Report File Content: " + ExtraClasses.Shafafiya_Result.Instantce.ReportFileContent + System.Environment.NewLine +
                            "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                            "Method Error Report: " + ExtraClasses.Shafafiya_Result.Instantce.ErrorReport + System.Environment.NewLine +
                            "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException + System.Environment.NewLine;
                        }
                        else
                        {
                            txt_richbox.InnerText = "Please upload file less than 102400";
                        }
                    }
                    else
                    {
                        txt_richbox.InnerText = "Please uplolad XML file";
                    }
                }
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = "Exception Occured :" + ex;
            }
        }

        //CHECK FOR NEW PRIOR AUTHOURISATION TRANSACTION
        protected void btn_pnl2_submit_Click(object sender, EventArgs e)
        {
            try
            {

                ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                string result = shaf.CheckForNewPAT(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue));
                txt_richbox.InnerText = "Result: " + result + System.Environment.NewLine +
                "Response: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                "Method Error Message " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException + System.Environment.NewLine;

            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        //DOWNLOAD TRANSACTION FILE
        protected void btn_pnl10_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_pnl10_fileid.Text != "")
                {
                    ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                    string result = shaf.DownloadTransactionFile(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), txt_pnl10_fileid.Text.ToString());
                    txt_richbox.InnerText = "Result: " + result + System.Environment.NewLine +
                        "Response Code: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                        "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                        "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException + System.Environment.NewLine;
                    string content = ExtraClasses.Shafafiya_Result.Instantce.file;
                    string filename = ExtraClasses.Shafafiya_Result.Instantce.filename;
                    if (content != null)
                    {
                        download_string(filename, content);
                    }
                }
                else
                {
                    txt_richbox.InnerText = "Please Enter Data";
                }
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        //GET DRUG DETAILS
        protected void btn_pnl3_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_pnl3_fileid.Text.ToString() != "")
                {
                    ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                    string result = shaf.GetDrugDetails(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), txt_pnl3_fileid.Text.ToString());
                    txt_richbox.InnerText = "Result: " + result + System.Environment.NewLine +
                    "Response: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                    "XML Drug Detail: " + ExtraClasses.Shafafiya_Result.Instantce.xmlDrgDetails + System.Environment.NewLine +
                    "Audit File Content: " + ExtraClasses.Shafafiya_Result.Instantce.AuditFileContent + System.Environment.NewLine +
                    "Report File Content: " + ExtraClasses.Shafafiya_Result.Instantce.ReportFileContent + System.Environment.NewLine +
                    "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                    "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException + System.Environment.NewLine;
                }
                else
                {
                    txt_richbox.InnerText = "Please Enter Data";
                }
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        //GET NEW PRIOR AUTHOURISATION TRANSACTION
        protected void btn_pnl4_submit_Click(object sender, EventArgs e)
        {
            try
            {
                ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                string result = shaf.GetNewPAT(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue));
                txt_richbox.InnerText = "Result: " + result + System.Environment.NewLine +
                    "Response: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                    //"XML Transaction: " + ExtraClasses.Shafafiya_Result.Instantce.xmlTransaction + System.Environment.NewLine +
                    "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                    "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException + System.Environment.NewLine;
                grid_view.DataSource = ExtraClasses.Shafafiya_Result.Instantce.dt;
                grid_view.DataBind();

            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        //GET NEW TRANSACTIONS
        protected void btn_pnl9_submit_Click(object sender, EventArgs e)
        {
            try
            {
                ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                string result = shaf.GetNewTransactions(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue));
                txt_richbox.InnerText = "Result: " + result + System.Environment.NewLine +
                "Response: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                //"XML Transaction: " + ExtraClasses.Shafafiya_Result.Instantce.xmlTransaction + System.Environment.NewLine +
                "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException + System.Environment.NewLine;
                if (result != "Fail")
                {
                    grid_view.DataSource = ExtraClasses.Shafafiya_Result.Instantce.dt;
                    grid_view.DataBind();
                }
                else
                {
                    nullify_gridsource();
                }
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        //GET PRESCRIPTION
        protected void btn_pnl5_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (/*txt_pnl5_login.Text.ToString() != "" && txt_pnl5_password.Text.ToString() != "" && */txt_pnl5_payerid.Text.ToString() != "" && txt_pnl5_memberid.Text.ToString() != "")
                {
                    ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                    string result = shaf.GetPrescription(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), txt_pnl5_payerid.Text.ToString(), txt_pnl5_memberid.Text.ToString());
                    txt_richbox.InnerText = "Result: " + result + System.Environment.NewLine +
                    "Response Code: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                    "Prescription: " + ExtraClasses.Shafafiya_Result.Instantce.Prescription + System.Environment.NewLine +
                    "Mehtod Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                    "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException + System.Environment.NewLine;
                }
                else
                {
                    txt_richbox.InnerText = "Please Enter Data";
                }
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        //SEARCH TRANSACTIONS
        protected void btn_pnl6_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_pnl6_minRecCount.Text.ToString() != "" && txt_pnl6_maxRecCount.Text.ToString() != "")
                {
                    ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();

                    string from_Date = string.Format("{0}", txt_pnl6_transFromDate.Text.ToString());
                    string to_Date = string.Format("{0}", txt_pnl6_transToDate.Text.ToString());

                    string result = shaf.SearchTransactions(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), ddl_pnl6_driection.SelectedValue.ToString(), txt_pnl6_callerlicense.Text.ToString(), txt_pnl6_ePartner.Text.ToString(), ddl_pnl6_transID.SelectedValue.ToString(), ddl_pnl6_transStatus.SelectedValue.ToString(), txt_pnl6_transFilename.Text.ToString(), from_Date, to_Date, txt_pnl6_minRecCount.Text.ToString(), txt_pnl6_maxRecCount.Text.ToString());
                    txt_richbox.InnerText = "Result: " + result + System.Environment.NewLine +
                    //"Found Transactions: " + ExtraClasses.Shafafiya_Result.Instantce.foundTransactions + System.Environment.NewLine +
                    "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                    "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException;
                    if (result != "Fail")
                    {
                        grid_view.DataSource = ExtraClasses.Shafafiya_Result.Instantce.dt;
                        grid_view.DataBind();
                    }
                    else
                    {
                        nullify_gridsource();
                    }
                }
                else
                {
                    txt_richbox.InnerText = "Please Enter Data";
                }
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        //SET TRANSACTION DOWNLOADED
        protected void btn_pnl7_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_pnl7_fileid.Text.ToString() != "")
                {
                    ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                    string result = shaf.SetTransactionDownloaded(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), txt_pnl7_fileid.Text.ToString());
                    txt_richbox.InnerText = "Result :" + result + System.Environment.NewLine +
                    "Response: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                    "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                    "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException;
                }
                else
                {
                    txt_richbox.InnerText = "Please Enter Data";
                }
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        //UPLOAD TRANSACTION
        protected void btn_pnl8_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_pnl8_filename.Text.ToString() != "" && pnl8_fileupload.HasFile == true)
                {
                    if (pnl8_fileupload.PostedFile.ContentType == "XML")
                    {
                        if (pnl8_fileupload.PostedFile.ContentLength <= 102400)
                        {
                            ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                            //string filepath = Path.GetFileName(pnl8_fileupload.FileName);
                            string path = ConfigurationManager.AppSettings["misc"] + "Nahdi_" + pnl8_fileupload.FileName.ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            pnl8_fileupload.PostedFile.SaveAs(@path);

                            string result = shaf.UploadTranasaction(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), path, txt_pnl8_filename.Text.ToString());
                            txt_richbox.InnerText = "Result: " + result + System.Environment.NewLine +
                            "Response: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                            "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                            "Method Error Report: " + ExtraClasses.Shafafiya_Result.Instantce.ErrorReport + System.Environment.NewLine +
                            "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException;
                        }
                        else
                        {
                            txt_richbox.InnerText = "Please upload file less than 102400";
                        }
                    }
                    else
                    {
                        txt_richbox.InnerText = "Please upload XML File";
                    }
                }
                else
                {
                    txt_richbox.InnerText = "Please Enter Data";
                }
            }
            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message.ToString();
            }
        }

        #endregion

        #region GridControls

        protected void grid_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_view.PageIndex = e.NewPageIndex;
            bind_gridsource();
        }

        protected void link_download_command(object sender, CommandEventArgs e)
        {
            try
            {
                int row_number = Convert.ToInt32(e.CommandArgument) % grid_view.PageSize;
                GridViewRow row = grid_view.Rows[row_number];
                string filename = string.Empty;
                if(ddl_selectmethod.SelectedValue == "6")
                {
                    filename = row.Cells[3].Text;
                }
                else
                {
                    filename = row.Cells[8].Text;
                }
                if (e.CommandName == "file_download")
                {
                    txt_richbox.InnerText = download_file(filename);
                }
                else if (e.CommandName == "set_downloaded")
                {
                    //call set transaction downloaded.
                    txt_richbox.InnerText =  set_AsDownloaded(filename);
                }
                else if (e.CommandName == "send_email")
                {
                    if (hdn_email.Value != "")
                    {
                        if (send_Email(filename, hdn_email.Value))
                        {
                            txt_richbox.InnerText = "Email Sent Successfully!";
                        }
                        else
                        {
                            txt_richbox.InnerText = "Something went wrong";
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                txt_richbox.InnerText = ex.Message;
            }

        }

        private string set_AsDownloaded(string filename)
        {
            try
            {
                ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                string result = shaf.SetTransactionDownloaded(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), filename);
                txt_richbox.InnerText = "Result :" + result + System.Environment.NewLine +
                "Response: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException;
                return txt_richbox.InnerText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private bool send_Email(string fileid,string email)
        {
            
            try
            {
                ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                ExtraClasses.SendEmail se = new ExtraClasses.SendEmail();

                string result = shaf.DownloadTransactionFile(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), fileid);
                string content = ExtraClasses.Shafafiya_Result.Instantce.file;
                string filename = ExtraClasses.Shafafiya_Result.Instantce.filename;
                string file_ext = Path.GetExtension(filename);
                string filepath = HttpContext.Current.Server.MapPath("~/App_Data/");
                string attch_file = filepath + filename + file_ext;

                using (StreamWriter sw = File.CreateText(attch_file))
                {
                    sw.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(content)));
                }
                return se.send_it("fansari@dimensions-healthcare.com", "cHEmiSTRY18IMS", email, attch_file);

            }
            catch (Exception)
            {

                return false;
            }
        }

        private string download_file(string fileid)
        {
            try
            {
                ExtraClasses.shafafiya_messenger shaf = new ExtraClasses.shafafiya_messenger();
                string result = shaf.DownloadTransactionFile(login(ddl_caller.SelectedValue), password(ddl_caller.SelectedValue), fileid);
                string content = ExtraClasses.Shafafiya_Result.Instantce.file;
                string filename = ExtraClasses.Shafafiya_Result.Instantce.filename;
                string response_result = "Result: " + result + System.Environment.NewLine +
                            "Response Code: " + ExtraClasses.Shafafiya_Result.Instantce.responseCode + System.Environment.NewLine +
                            "Filename: " + filename + System.Environment.NewLine +
                            "Method Error Message: " + ExtraClasses.Shafafiya_Result.Instantce.errorMessage + System.Environment.NewLine +
                            "Application Exception: " + ExtraClasses.Shafafiya_Result.Instantce.ProgramException + System.Environment.NewLine;

                download_string(filename, content);
                return response_result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void download_string(string filename, string filecontent)
        {
            try
            {

                string file_ext = Path.GetExtension(filename);
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();

                if (file_ext == ".xml" || file_ext == ".XML")
                {
                    filecontent = Encoding.UTF8.GetString(Convert.FromBase64String(filecontent));

                    Response.AddHeader("Content-Length", filecontent.Length.ToString());
                    Response.ContentType = "application/xml";
                    Response.AppendHeader("content-disposition", "attachment;filename=" + filename);
                    Response.Write(filecontent);
                }
                else if (file_ext == ".zip" || file_ext == ".ZIP")
                {
                    byte[] file = Convert.FromBase64String(filecontent);

                    Response.ContentType = "application/x-compressed";
                    Response.Charset = string.Empty;
                    Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    Response.BinaryWrite(file);
                    Response.OutputStream.Flush();
                    Response.OutputStream.Close();
                }

            }
            catch (Exception) { }
            finally
            {
                try
                {
                    Response.End();
                }
                catch (Exception) { }
                finally
                {
                    Response.Flush();
                    Response.SuppressContent = true;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    Thread.Sleep(1);
                }
            }
        }

        private void nullify_gridsource()
        {
            grid_view.DataSource = null;
            grid_view.DataBind();
        }

        private void bind_gridsource()
        {
            //grid_view.PageIndex = -1;
            grid_view.DataSource = ExtraClasses.Shafafiya_Result.Instantce.dt;
            grid_view.DataBind();
        }

        #endregion
    }

    public static class foremail
    {
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void sendemaill(string filename, string email)
        {
            Console.Write("you are here");
        }
    }
}