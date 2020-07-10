using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Services_All.Utilities_UI
{
    public partial class DHPO_WebService : System.Web.UI.Page
    {
        private static DataTable dt;

        #region User Data 

        void fill_ddl()
        {
            ddl_caller.DataSource = CreateDataSource();
            ddl_caller.DataTextField = "Text";
            ddl_caller.DataValueField = "Value";
            ddl_caller.DataBind();

            txt_sender_username.Text = login(ddl_caller.SelectedValue);
            txt_sender_password.Text = password(ddl_caller.SelectedValue);
        }

        ICollection CreateDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Text", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(string)));

            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/dhpo_users_profile.csv")))
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
            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/dhpo_users_profile.csv")))
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
            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/dhpo_users_profile.csv")))
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
            txt_sender_username.Text = login(ddl_caller.SelectedValue);
            txt_sender_password.Text = password(ddl_caller.SelectedValue);
            txt_rich_box.InnerText = null;
            nullify_gridsource("");
        }

        protected void btn_add_newuser_Click(object sender, EventArgs e)
        {
            btn_add_newuser.Visible = false;
            pnl_add_user.Visible = true;
            nullify_gridsource("");
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

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_rich_box.Visible = true;
            txt_rich_box.InnerText = null;
            if (!IsPostBack)
            {
                fill_ddl();
                nullify_gridsource("");
            }
            else
            {
                //bind_gridsource();
                //nullify_gridsource();
            }
            //nullify_gridsource("");
        }

        #region DropDownlists and Submission Function

        protected void ddl_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pnl1_fileID.Visible = false;
                pnl2_uploadfiles.Visible = false;

                nullify_gridsource("");

                if (ddl_method.SelectedValue == "DownloadTransactionFile" || ddl_method.SelectedValue == "SetTransactionDownloaded")
                {
                    pnl1_fileID.Visible = true;
                    txt_rich_box.Visible = false;

                }
                else if (ddl_method.SelectedValue == "UploadTransaction")
                {
                    pnl2_uploadfiles.Visible = true;
                }
                else if(ddl_method.SelectedValue == "GetNewPriorAuthorizationTransactions" || ddl_method.SelectedValue == "GetNewTransactions")
                {
                    txt_rich_box.Visible = false;
                }

            }
            catch (Exception ex)
            {
                txt_rich_box.InnerText = ex.Message;
            }

        }

        protected void ddl_uploadfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (ddl_uploadfile.SelectedValue)
                {
                    case "claim":
                        LoadFile("DHPO_Claim_Submission",true);
                        break;
                    case "remittance":
                        LoadFile("DHPO_Remittance_Advice", true);
                        break;
                    case "priorrequest":
                        LoadFile("DHPO_Prior_Request", false);
                        break;
                    case "priorauthorization":
                        LoadFile("DHPO_Prior_Authorization", false);
                        break;
                    case "erxrequest":
                        LoadFile("DHPO_Erx_Request", false);
                        break;
                    case "erxauhtorization":
                        LoadFile("DHPO_Erx_Auhtorization", false);
                        break;
                }
            }
            catch (Exception ex)
            {
                txt_rich_box.InnerText = ex.Message;
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            txt_rich_box.InnerText = null;
            bool is_prod = false;
            string result = string.Empty;

            try
            {
                if(rd_enviorment.SelectedValue == "rd_prod")
                {
                    is_prod = true;
                }
                else
                {
                    is_prod = false;
                }


                if (txt_sender_username.Text.Length>0 && txt_sender_password.Text.Length>0)
                {

                    switch (ddl_method.SelectedValue)
                    {
                        case "CheckForNewPriorAuthorizationTransactions":
                            string yo = txt_sender_password.Text;
                            txt_rich_box.InnerText = ExtraClasses.DHPO_WebService.CheckForNewPriorAuthorizationTrasnactions(txt_sender_username.Text, txt_sender_password.Text, is_prod);
                            break;
                        case "DownloadTransactionFile":
                            if (txt_fileID.Text != null)
                            {
                                txt_rich_box.InnerText = ExtraClasses.DHPO_WebService.DownloadTransactionFile(txt_sender_username.Text, txt_sender_password.Text, txt_fileID.Text, is_prod);
                                if(ExtraClasses.DHPO_RESULT.Instantce.filename != null)
                                {
                                    download_string(ExtraClasses.DHPO_RESULT.Instantce.filename, ExtraClasses.DHPO_RESULT.Instantce.file);
                                }
                            }
                            else
                            {
                                txt_rich_box.InnerText = "File ID field is empty";
                            }
                            break;
                        case "GetNewPriorAuthorizationTransactions":
                            result = ExtraClasses.DHPO_WebService.GetNewPriorAuthorizationTrasnactions(txt_sender_username.Text, txt_sender_password.Text, is_prod);
                            dt = ExtraClasses.DHPO_RESULT.Instantce.dt;
                            if (dt != null)
                                bind_gridsource(dt);
                            else
                                nullify_gridsource(result);
                            break;

                        case "GetNewTransactions":
                            result = ExtraClasses.DHPO_WebService.GetNewTransactions(txt_sender_username.Text, txt_sender_password.Text, is_prod);
                            dt = ExtraClasses.DHPO_RESULT.Instantce.dt;
                            if (dt != null)
                                bind_gridsource(dt);
                            else
                                nullify_gridsource(result);
                            break;

                        case "SearchTransactions":
                            txt_rich_box.InnerText = ExtraClasses.DHPO_WebService.SearchTransaction(txt_sender_username.Text, txt_sender_password.Text, is_prod);
                            break;
                        case "SetTransactionDownloaded":
                            if (txt_fileID.Text != null)
                            {
                                txt_rich_box.InnerText = ExtraClasses.DHPO_WebService.SetTransactionDownloaded(txt_sender_username.Text, txt_sender_password.Text, txt_fileID.Text, is_prod);
                            }
                            else
                            {
                                txt_rich_box.InnerText = "File ID field is empty";
                            }
                            break;
                        case "UploadTransaction":
                            if (file_upload.HasFile || file_upload.HasFiles)
                            {
                                foreach (HttpPostedFile file in file_upload.PostedFiles)
                                {
                                    if (file.ContentType == "text/xml")
                                    {
                                        using (StreamReader reader = new StreamReader(file.InputStream))
                                        {
                                            string uploaded_file = reader.ReadToEnd();
                                            string filename = file.FileName;


                                            if (chk_fileDate.Checked)
                                                uploaded_file = ConvertDate(uploaded_file);
                                            if (chk_fileID.Checked)
                                                uploaded_file = ConvertFileID(uploaded_file);
                                            if (chk_fileName.Checked)
                                                filename = ConvertFileName(file.FileName);


                                            byte[] file_bytes = Encoding.ASCII.GetBytes(uploaded_file);
                                            txt_rich_box.InnerText += ExtraClasses.DHPO_WebService.UploadTransaction(txt_sender_username.Text, txt_sender_password.Text, file_bytes, filename, is_prod);

                                        }
                                    }
                                }
                            }
                            else if (txt_richbox_postFile.InnerText != null)
                            {
                                if (chk_sendmultiple.Checked == true && txt_file_iterationcount.Text != null)
                                {
                                    string iter_count = txt_file_iterationcount.Text;
                                    for (int i = 0; i < Convert.ToInt32(iter_count); i++)
                                    {
                                        string file_content = txt_richbox_postFile.InnerText;
                                        file_content = ConvertDate(file_content);
                                        file_content = ConvertFileID(file_content);
                                        string filename = ConvertFileName("");

                                        byte[] file_bytes = Encoding.ASCII.GetBytes(file_content);
                                        txt_rich_box.InnerText += ExtraClasses.DHPO_WebService.UploadTransaction(txt_sender_username.Text, txt_sender_password.Text, file_bytes, filename, is_prod) + "\n\n";

                                    }

                                }
                                else
                                {
                                    if (txt_filename.Text.Length>0)
                                    {

                                        byte[] file_bytes = Encoding.ASCII.GetBytes(txt_richbox_postFile.InnerText);
                                        txt_rich_box.InnerText = ExtraClasses.DHPO_WebService.UploadTransaction(txt_sender_username.Text, txt_sender_password.Text, file_bytes, txt_filename.Text, is_prod);
                                    }
                                    else
                                    {
                                        txt_rich_box.InnerText = "Please enter filename";
                                    }
                                }
                            }
                            break;
                    }
                }
                else
                {
                    txt_rich_box.InnerText = "Username or Password fields are empty";
                }

            }
            catch (Exception ex)
            {
                txt_rich_box.InnerText = ex.Message;
            }
        }

        #endregion


        #region Upload File Functions and Converters
        private static string ConvertDate(string file)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(file);

                //Change Date to current date
                XmlNode node_date = xdoc.SelectSingleNode("//Header//TransactionDate");
                node_date.InnerText = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                XDocument docX = XDocument.Parse(xdoc.OuterXml);
                return docX.ToString();
            }
            catch(Exception)
            {
                return null;
            }
        }
        private static string ConvertFileID(string file)
        {
            //bool is_ID_Multiple = false;
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(file);

                //Change Date to current date

                if (xdoc.FirstChild.LocalName != "Claim.Submission" && xdoc.FirstChild.LocalName != "Remittance.Advice")
                {
                    XmlNode node_authorization = xdoc.SelectSingleNode("//Authorization//ID");
                    string newid = xdoc.SelectSingleNode("//Header//SenderID").InnerText + "-FA-" + System.DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    node_authorization.InnerText = newid;
                }
                else 
                {
                    XmlNodeList nodelist_authorization = xdoc.SelectNodes("//Claim/ID");
                    foreach (XmlNode node_Auth in nodelist_authorization)
                    {
                        string newid = xdoc.SelectSingleNode("//Header//SenderID").InnerText + "-FA-" + System.DateTime.Now.ToString("yyyyMMddhhmmssfff");
                        node_Auth.InnerText = newid;
                    }
                }

                XDocument docX = XDocument.Parse(xdoc.OuterXml);
                return docX.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static string ConvertFileName(string filename)
        {
            try
            {
                return "FA-" + Guid.NewGuid() + ".xml";
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void LoadFile(string filename, bool is_ID_Multiple)
        {
            string file = File.ReadAllText(ConfigurationManager.AppSettings["DHPO_Idol_Folder"] + filename + ".xml");
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(file);

            //Change Date to current date
            XmlNode node_date = xdoc.SelectSingleNode("//Header//TransactionDate");
            node_date.InnerText = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm");


            //Check for XML structure if it is claim or remittance
            if (!is_ID_Multiple)
            {
                XmlNode node_authorization = xdoc.SelectSingleNode("//Authorization/ID");
                if (node_authorization != null)
                {
                    string newid = xdoc.SelectSingleNode("//Header//SenderID").InnerText + "-FA-" + System.DateTime.Now.ToString("yyyyMMddhhmmss");
                    node_authorization.InnerText = newid;
                }
                else
                {
                    XmlNode node_erx_authorization = xdoc.SelectSingleNode("//Prescription/ID");
                    string newid = xdoc.SelectSingleNode("//Header//SenderID").InnerText + "-FA-" + System.DateTime.Now.ToString("yyyyMMddhhmmss");
                    node_erx_authorization.InnerText = newid;

                }
            }
            else if (is_ID_Multiple)
            {
                XmlNodeList nodelist_authorization = xdoc.SelectNodes("//Claim/ID");
                foreach (XmlNode node_Auth in nodelist_authorization)
                {
                    string newid = xdoc.SelectSingleNode("//Header//SenderID").InnerText + "-FA-" + System.DateTime.Now.ToString("yyyyMMddhhmmss");
                    node_Auth.InnerText = newid;
                }
            }

            XDocument docX = XDocument.Parse(xdoc.OuterXml);
            txt_richbox_postFile.InnerText = docX.ToString();
        }
        protected void chk_sendmultiple_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sendmultiple.Checked)
            {
                txt_file_iterationcount.Visible = true;
                txt_filename.Visible = false;
                lbl_filename.Visible = false;
            }
            else
            {
                txt_file_iterationcount.Visible = false;
                txt_filename.Visible = true;
                lbl_filename.Visible = true;
            }
        }
        #endregion


        #region GridView Functions

        protected void link_download_Command(object sender, CommandEventArgs e)
        {
            bool is_prod = false;

            int row_number = Convert.ToInt32(e.CommandArgument) % grid_view.PageSize;
            GridViewRow row = grid_view.Rows[row_number];
            string filename = row.Cells[2].Text;
            if (rd_enviorment.SelectedValue == "rd_prod")
                is_prod = true;
            else
                is_prod = false;
            ExtraClasses.DHPO_WebService.DownloadTransactionFile(txt_sender_username.Text, txt_sender_password.Text, filename, is_prod);

            string file = ExtraClasses.DHPO_RESULT.Instantce.file;
            string filename_res = ExtraClasses.DHPO_RESULT.Instantce.filename;
            if (file.Length > 0)
            {
                download_string(filename_res, file);
            }
        }
        protected void link_setdownloaded_Command(object sender, CommandEventArgs e)
        {
            bool is_prod = false;
            int row_number = Convert.ToInt32(e.CommandArgument) % grid_view.PageSize;
            GridViewRow row = grid_view.Rows[row_number];
            string filename = row.Cells[2].Text;
            if (rd_enviorment.SelectedValue == "rd_prod")
                is_prod = true;
            else
                is_prod = false;
            ExtraClasses.DHPO_WebService.SetTransactionDownloaded(txt_sender_username.Text, txt_sender_password.Text, filename, is_prod);

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

        protected void grid_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_view.PageIndex = e.NewPageIndex;
            bind_gridsource(dt);
        }
        private void nullify_gridsource(string result)
        {
            grid_view.DataSource = null;
            grid_view.DataBind();
            txt_rich_box.InnerText = result;
        }
        private void bind_gridsource(DataTable dt)
        {
            grid_view.DataSource = dt;
            grid_view.DataBind();
            txt_rich_box.Visible = false;
        }

        #endregion

        
    }
}