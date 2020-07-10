
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Services_All.Utilities_UI
{
    public partial class TPO_API : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_ddl();
            }
        }

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

            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/tpo_users_profile.csv")))
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
            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/tpo_users_profile.csv")))
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
            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/tpo_users_profile.csv")))
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
        }

        protected void btn_add_newuser_Click(object sender, EventArgs e)
        {
            btn_add_newuser.Visible = false;
            pnl_add_user.Visible = true;
        }

        protected void btn_add_user_submit_Click(object sender, EventArgs e)
        {
            btn_add_newuser.Visible = true;
            int max = 0;
            using (var fs = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/tpo_users_profile.csv")))
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
            File.AppendAllText(Server.MapPath("~/App_Data/tpo_users_profile.csv"), csv.ToString());
            fill_ddl();
            pnl_add_user.Visible = false;
        }

        protected void btn_cancel_user_submit_Click(object sender, EventArgs e)
        {
            btn_add_newuser.Visible = true;
            pnl_add_user.Visible = false;
        }

        #endregion


        #region Methods

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                //ExtraClasses.TPO_API_Call.Claim_XML();
                //ExtraClasses.TPO_API_Call.PR_XML();

                if (txt_sender_username.Text.Length > 0 && txt_sender_password.Text.Length > 0)
                {
                    string username = txt_sender_username.Text;
                    string password = txt_sender_password.Text;
                    string api_address = ddl_Methods_Selection.SelectedValue + "/" + ddl_panel_selection.SelectedValue;
                    bool fileid_increament = chck_fileID.Checked;
                    bool filename_increament = chck_filename.Checked;
                    txt_rich_box.InnerText = null;


                    if(ddl_panel_selection.SelectedValue.ToString() == "GetNew")
                    {
                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.GetNew(api_address, username, password);
                    }

                    else if (ddl_panel_selection.SelectedValue.ToString() == "View")
                    {
                        //Get New
                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.View(api_address, pnl2_FilesSystemID.Text, Convert.ToInt32(pnl2_ddl_direction.SelectedValue), username, password);
                    }
                    else if (ddl_panel_selection.SelectedValue.ToString() == "ViewPharmacyPrescription" || ddl_panel_selection.SelectedValue.ToString() == "ViewLaboratoryOrder" || ddl_panel_selection.SelectedValue.ToString() == "ViewRadiologyOrder")
                    {
                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.View_OrderPrescription(api_address, pnl4_FilesSystemID.Text,pnl4_MemberID.Text, username, password);
                    }

                    else if(ddl_panel_selection.SelectedValue.ToString() == "FindPharmacyPrescriptions" || ddl_panel_selection.SelectedValue.ToString() == "FindLaboratoryOrders" || ddl_panel_selection.SelectedValue.ToString() == "FindRadiologyOrders")
                    {
                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.Find_OrderPrescription(api_address, pnl5_memberID.Text, pnl5_nationalID.Text, username, password);
                    }

                    else if (ddl_panel_selection.SelectedValue.ToString() == "Search")
                    {
                        //Search Files

                        string parameters = "?direction=" + ddl_direction.SelectedValue;
                      
                        if (txt_SenderLicense.Text != string.Empty)
                            parameters += "&license=" + txt_SenderLicense.Text;
                        if (txt_FromDate.Text != string.Empty)
                            parameters += "&fromDate=" + txt_FromDate.Text;
                        if (txt_ToDate.Text != string.Empty)
                            parameters += "&toDate=" + txt_ToDate.Text;
                        if (ddl_download_status.SelectedValue != string.Empty || ddl_download_status.SelectedValue != null)
                            parameters += "&downloaded=" + ddl_download_status.SelectedValue;
                        if (txt_filename.Text != string.Empty)
                            parameters += "&filename=" + txt_filename.Text;
                        if (txt_FilesSystemID.Text != string.Empty)
                            parameters += "&id=" + txt_FilesSystemID.Text;


                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.SearchFiles(api_address, parameters, username, password);
                    }
                    else if (ddl_panel_selection.SelectedValue.ToString() == "PostErxRequest" || ddl_panel_selection.SelectedValue.ToString() == "PostSubmission" || ddl_panel_selection.SelectedValue.ToString() == "PostRequest" || ddl_panel_selection.SelectedValue.ToString() == "PostRadRequest" || ddl_panel_selection.SelectedValue.ToString() == "PostLabRequest" ||
                                ddl_panel_selection.SelectedValue.ToString() == "PostErxAuthorization" || ddl_panel_selection.SelectedValue.ToString() == "PostRemittance" || ddl_panel_selection.SelectedValue.ToString() == "PostAuthorization" || ddl_panel_selection.SelectedValue.ToString() == "PostRadAuthorization" || ddl_panel_selection.SelectedValue.ToString() == "PostLabAuthorization")
                    {
                        //Post Files


                        if (file_uploader.HasFiles || file_uploader.HasFile)
                        {
                            StringBuilder sb = new StringBuilder();

                            foreach (HttpPostedFile file in file_uploader.PostedFiles)
                            {
                                if (file.ContentType == "text/xml")
                                {
                                    using (StreamReader reader = new StreamReader(file.InputStream))
                                    {
                                        string uploaded_file = reader.ReadToEnd();
                                        uploaded_file = ExtraClasses.TPO_API_Call.Transform_File(api_address, uploaded_file, rd_list_transaction_type.SelectedValue);

                                        sb.Append("\nUploading File : " + file.FileName + "\n");
                                        sb.Append(ExtraClasses.TPO_API_Call.PostFile(api_address, uploaded_file, Path.GetFileNameWithoutExtension(file.FileName), filename_increament, fileid_increament, username, password));
                                        sb.Append(System.Environment.NewLine);
                                    }
                                }
                                else if (file.ContentType == "application/octet-stream")
                                {
                                    using (StreamReader reader = new StreamReader(file.InputStream))
                                    {
                                        string file_string = ExtraClasses.TPO_API_Call.Json_ChangeDate(api_address, reader.ReadToEnd());
                                        sb.Append("\nUploading File : " + file.FileName + "\n");
                                        sb.Append(ExtraClasses.TPO_API_Call.PostFile(api_address, file_string, Path.GetFileNameWithoutExtension(file.FileName), filename_increament, fileid_increament, username, password));
                                        sb.Append(System.Environment.NewLine);
                                    }
                                }
                                else
                                {
                                    txt_rich_box.InnerText = "File is not in XML format";
                                }
                            }
                            txt_rich_box.InnerText = sb.ToString();
                        }
                        else
                        {
                            if (ddl_Methods_Selection.SelectedValue == "Claim")
                            {
                                if (!chk_filegenerate.Checked)
                                {
                                    if (Convert.ToInt32(txt_iterationCount.Text) > 1)
                                    {
                                        string file = ExtraClasses.TPO_API_Call.Iterate_File(txt_richbox_postFile.InnerText, Convert.ToInt32(txt_iterationCount.Text));
                                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.PostFile(api_address, file, "", filename_increament, fileid_increament, username, password);
                                    }
                                    else
                                    {
                                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.PostFile(api_address, txt_richbox_postFile.InnerText, "", filename_increament, fileid_increament, username, password);
                                    }
                                }
                                else if (chk_filegenerate.Checked)
                                {
                                    txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.Iterate_File(txt_richbox_postFile.InnerText, Convert.ToInt32(txt_iterationCount.Text));
                                }
                            }
                            else
                            {
                                txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.PostFile(api_address, txt_richbox_postFile.InnerText, "", filename_increament, fileid_increament, username, password);
                            }
                        }
                    }

                    //else if(ddl_panel_selection.SelectedValue.ToString() == "Multiple")
                    //{
                    //    HttpPostedFile file = file_upload_custom.PostedFile;
                    //    StringBuilder sb = new StringBuilder();
                    //    using (StreamReader reader = new StreamReader(file.InputStream))
                    //    {
                    //        string file_string = ExtraClasses.TPO_API_Call.Json_ChangeDate(api_address, reader.ReadToEnd());
                    //        sb.Append(ExtraClasses.TPO_API_Call.Post_Multiple_Submissions(api_address, file_string, Convert.ToInt32(txt_iteration_count.Text), username, password));

                    //        txt_rich_box.InnerText = sb.ToString();
                    //    }
                    //}

                    else if (ddl_panel_selection.SelectedValue.ToString() == "SetDownloaded")
                    {
                        //Download Files
                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.DownloadTransaction(api_address, pnl3_txt_filessystemid.Text, username, password);
                    }
                    else if(ddl_panel_selection.SelectedValue.ToString() == "DownloadAttachment")
                    {
                        if (ExtraClasses.TPO_API_Call.Download_Attachment(api_address, txt_download_file_id.Text, username, password) == "Success")
                        {
                            download_file(Path.GetFileNameWithoutExtension(ExtraClasses.Singleton.Instance.file_name),Path.GetExtension(ExtraClasses.Singleton.Instance.file_name), ExtraClasses.Singleton.Instance.file_content);
                        }

                    }
                    else if (ddl_panel_selection.SelectedValue.ToString() == "UploadAttachment")
                    {
                        if (file_upload_attachment.HasFile)
                        {
                            HttpPostedFile file = file_upload_attachment.PostedFile;
                            using (StreamReader reader = new StreamReader(file.InputStream))
                            {
                                string uploaded_file = reader.ReadToEnd();
                                txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.Upload_Attachment(api_address, uploaded_file,file_upload_attachment.FileName,file_upload_attachment.PostedFile.ContentType, username, password);
                            }
                        }
                    }
                    else if(ddl_panel_selection.SelectedValue.ToString()== "CheckActivityStatus")
                    {
                        txt_rich_box.InnerText = ExtraClasses.TPO_API_Call.Check_ActivityStatus(api_address, pnl6_SystemID.Text, pnl6_ActivityID.Text, username, password);
                    }
                }
                else
                {
                    txt_rich_box.InnerText = "Please enter username and password of the Sender";
                }
            }
            catch (Exception ex)
            {
                txt_rich_box.InnerText = ex.Message;
            }

        }

        protected void ddl_Methods_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rich_box.InnerText = null;
            txt_richbox_postFile.InnerText = null;
            disappear_panels();

            if (ddl_Methods_Selection.SelectedValue.ToString() == "Authorization")
            {
                ddl_panel_selection.Items.Clear();
                ddl_panel_selection.Items.Insert(0, new ListItem("Select Method", "null"));
                ddl_panel_selection.Items.Insert(1, new ListItem("Get New Authorization", "GetNew"));
                ddl_panel_selection.Items.Insert(2, new ListItem("View Transaction", "View"));
                ddl_panel_selection.Items.Insert(3, new ListItem("Set as Downloaded", "SetDownloaded"));
                ddl_panel_selection.Items.Insert(4, new ListItem("Post Request", "PostRequest"));
                ddl_panel_selection.Items.Insert(5, new ListItem("Post Authorization", "PostAuthorization"));
                ddl_panel_selection.Items.Insert(6, new ListItem("Search Authorization", "Search"));
            }
            else if (ddl_Methods_Selection.SelectedValue.ToString() == "Claim")
            {
                ddl_panel_selection.Items.Clear();
                ddl_panel_selection.Items.Insert(0, new ListItem("Select Method", "null"));
                ddl_panel_selection.Items.Insert(1, new ListItem("Get New Claim", "GetNew"));
                ddl_panel_selection.Items.Insert(2, new ListItem("View Transaction", "View"));
                ddl_panel_selection.Items.Insert(3, new ListItem("Set as Downloaded", "SetDownloaded"));
                ddl_panel_selection.Items.Insert(4, new ListItem("Post Submission", "PostSubmission"));
                ddl_panel_selection.Items.Insert(5, new ListItem("Post Remittance", "PostRemittance"));
                ddl_panel_selection.Items.Insert(6, new ListItem("Search Claim", "Search"));

            }
            else if (ddl_Methods_Selection.SelectedValue.ToString() == "ERX")
            {
                ddl_panel_selection.Items.Clear();
                ddl_panel_selection.Items.Insert(0, new ListItem("Select Method", "null"));
                ddl_panel_selection.Items.Insert(1, new ListItem("Get New ERX", "GetNew"));
                ddl_panel_selection.Items.Insert(2, new ListItem("View Transaction", "View"));
                ddl_panel_selection.Items.Insert(3, new ListItem("View Prescription", "ViewPharmacyPrescription"));
                ddl_panel_selection.Items.Insert(4, new ListItem("Set as Downloaded", "SetDownloaded"));
                ddl_panel_selection.Items.Insert(5, new ListItem("Post ERX Request", "PostRequest"));
                ddl_panel_selection.Items.Insert(6, new ListItem("Post ERX Authorization", "PostAuthorization"));
                ddl_panel_selection.Items.Insert(7, new ListItem("Search ERX", "Search"));
                ddl_panel_selection.Items.Insert(8, new ListItem("Find Prescription", "FindPharmacyPrescriptions"));
                ddl_panel_selection.Items.Insert(9, new ListItem("Check Activity Status", "CheckActivityStatus"));
            }
            else if (ddl_Methods_Selection.SelectedValue.ToString() == "Lab")
            {
                ddl_panel_selection.Items.Clear();
                ddl_panel_selection.Items.Insert(0, new ListItem("Select Method", "null"));
                ddl_panel_selection.Items.Insert(1, new ListItem("Get New Lab", "GetNew"));
                ddl_panel_selection.Items.Insert(2, new ListItem("View Transaction", "View"));
                ddl_panel_selection.Items.Insert(3, new ListItem("View Order", "ViewLaboratoryOrder"));
                ddl_panel_selection.Items.Insert(4, new ListItem("Set as Downloaded", "SetDownloaded"));
                ddl_panel_selection.Items.Insert(5, new ListItem("Post Lab Request", "PostRequest"));
                ddl_panel_selection.Items.Insert(6, new ListItem("Post Lab Authorization", "PostAuthorization"));
                ddl_panel_selection.Items.Insert(7, new ListItem("Search LAB", "Search"));
                ddl_panel_selection.Items.Insert(8, new ListItem("Find Orders", "FindLaboratoryOrders"));
                ddl_panel_selection.Items.Insert(9, new ListItem("Check Activity Status", "CheckActivityStatus"));
            }

            else if (ddl_Methods_Selection.SelectedValue.ToString() == "Rad")
            {
                ddl_panel_selection.Items.Clear();
                ddl_panel_selection.Items.Insert(0, new ListItem("Select Method", "null"));
                ddl_panel_selection.Items.Insert(1, new ListItem("Get New Rad", "GetNew"));
                ddl_panel_selection.Items.Insert(2, new ListItem("View Transaction", "View"));
                ddl_panel_selection.Items.Insert(3, new ListItem("View Order", "ViewRadiologyOrder"));
                ddl_panel_selection.Items.Insert(4, new ListItem("Set as Downloaded", "SetDownloaded"));
                ddl_panel_selection.Items.Insert(5, new ListItem("Post Rad Request", "PostRequest"));
                ddl_panel_selection.Items.Insert(6, new ListItem("Post Rad Authorization", "PostAuthorization"));
                ddl_panel_selection.Items.Insert(7, new ListItem("Search RAD", "Search"));
                ddl_panel_selection.Items.Insert(8, new ListItem("Find Orders", "FindRadiologyOrders"));
                ddl_panel_selection.Items.Insert(9, new ListItem("Check Activity Status", "CheckActivityStatus"));
            }

            else if(ddl_Methods_Selection.SelectedValue.ToString() == "Attachments")
            {
                ddl_panel_selection.Items.Clear();
                ddl_panel_selection.Items.Insert(0, new ListItem("Select Methods", "null"));
                ddl_panel_selection.Items.Insert(1, new ListItem("Upload File", "UploadAttachment"));
                ddl_panel_selection.Items.Insert(2, new ListItem("Download File", "DownloadAttachment"));
            }

            else if (ddl_Methods_Selection.SelectedValue.ToString() == "Custom")
            {
                ddl_panel_selection.Items.Clear();
                ddl_panel_selection.Items.Insert(0, new ListItem("Select Method", "null"));
                ddl_panel_selection.Items.Insert(1, new ListItem("Send a Big file", "Multiple"));
            }

            else if (ddl_Methods_Selection.SelectedValue.ToString() == "null")
            {
                ddl_panel_selection.Items.Clear();
            }
           
        }

        protected void ddl_panel_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rich_box.InnerText = null;
            txt_richbox_postFile.InnerText = null;
            disappear_panels();

            if (ddl_panel_selection.SelectedValue.ToString() == "GetNew")
            {
                pnl_GetNew.Visible = true;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;
            }

            else if (ddl_panel_selection.SelectedValue.ToString() == "View")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = true;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;
            }

            else if (ddl_panel_selection.SelectedValue.ToString() == "Search")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = true;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;
            }

            else if (ddl_panel_selection.SelectedValue.ToString() == "PostRequest" || ddl_panel_selection.SelectedValue.ToString() == "PostSubmission")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = true;
                if (ddl_Methods_Selection.SelectedValue.ToString() == "Claim" && ddl_panel_selection.SelectedValue.ToString() == "PostSubmission")
                {
                    div_rdbox.Style.Value = "display: block;";

                    if(rd_list_transaction_type.SelectedValue == "Submission")
                    {
                        div_iterationBOX.Style.Value = "display: block;";
                    }
                    else
                    {
                        div_iterationBOX.Style.Value = "display: none;";
                    }
                }
                else
                {
                    div_rdbox.Style.Value = "display: none;";
                    div_iterationBOX.Style.Value = "display: none;";
                }
                LoadFile(ddl_Methods_Selection.SelectedValue + ddl_panel_selection.SelectedValue);
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;

            }
            else if (ddl_panel_selection.SelectedValue.ToString() == "PostAuthorization" || ddl_panel_selection.SelectedValue.ToString() == "PostRemittance")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = true;
                LoadFile(ddl_Methods_Selection.SelectedValue+ddl_panel_selection.SelectedValue);
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;
            }
            else if (ddl_panel_selection.SelectedValue.ToString() == "SetDownloaded")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = true;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;
            }
            else if (ddl_panel_selection.SelectedValue == "FindRadiologyOrders" || ddl_panel_selection.SelectedValue == "FindLaboratoryOrders" || ddl_panel_selection.SelectedValue == "FindPharmacyPrescriptions")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = true;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;
            }

            else if (ddl_panel_selection.SelectedValue == "ViewRadiologyOrder" || ddl_panel_selection.SelectedValue == "ViewLaboratoryOrder" || ddl_panel_selection.SelectedValue == "ViewPharmacyPrescription")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = true;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;
            }
            else if(ddl_panel_selection.SelectedValue == "UploadAttachment")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = true;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = false;
            }
            else if(ddl_panel_selection.SelectedValue == "DownloadAttachment")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = true;
                pnl_CheckActivityStatus.Visible = false;
            }
            else if(ddl_panel_selection.SelectedValue == "CheckActivityStatus")
            {
                pnl_GetNew.Visible = false;
                pnl_View.Visible = false;
                pnl_Search.Visible = false;
                pnl_PostFile.Visible = false;
                pnl_SetDownloaded.Visible = false;
                pnl_Find_PrescriptionOrder.Visible = false;
                pnl_View_PrescriptionOrder.Visible = false;
                pnl_Upload_Attachment.Visible = false;
                pnl_Download_Attachment.Visible = false;
                pnl_CheckActivityStatus.Visible = true;
            }

            //else if(ddl_panel_selection.SelectedValue == "Multiple")
            //{
            //    pnl_GetNew.Visible = false;
            //    pnl_View.Visible = false;
            //    pnl_Search.Visible = false;
            //    pnl_PostFile.Visible = false;
            //    pnl_SetDownloaded.Visible = false;
            //    pnl_Find_PrescriptionOrder.Visible = false;
            //    pnl_View_PrescriptionOrder.Visible = false;
            //    pnl_Upload_Attachment.Visible = false;
            //    pnl_Download_Attachment.Visible = false;
            //    pnl_custom.Visible = true;
            //}
        }

        private void LoadFile(string method)
        {
            try
            {
                JObject json = JObject.Parse(File.ReadAllText(ConfigurationManager.AppSettings["TPO_IDOL_Folder"] + method + ".json"));
                method = method.Substring(4);
                JToken token = json.Last;
                token = token.First;
                token["Header"]["TransactionDate"] = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                txt_richbox_postFile.InnerText = json.ToString();

            }
            catch (Exception ex)
            {
                txt_rich_box.InnerText = ex.Message;
            }
        }

        private void disappear_panels()
        {
            pnl_GetNew.Visible = false;
            pnl_View.Visible = false;
            pnl_Search.Visible = false;
            pnl_PostFile.Visible = false;
            pnl_SetDownloaded.Visible = false;
            pnl_Find_PrescriptionOrder.Visible = false;
            pnl_View_PrescriptionOrder.Visible = false;
            pnl_Upload_Attachment.Visible = false;
            pnl_Download_Attachment.Visible = false;
            pnl_CheckActivityStatus.Visible = false;
            //pnl_custom.Visible = false;
        }

        protected void rd_list_transaction_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(rd_list_transaction_type.SelectedValue)
            {
                case "Submission":
                    LoadFile("ClaimPostSubmission");
                    div_iterationBOX.Style.Value = "display: block;";
                    break;
                case "Resubmission":
                    LoadFile("ClaimPostSubmission - Resubmission");
                    div_iterationBOX.Style.Value = "display: none;";
                    break;
                case "Prescription-Dispense":
                    LoadFile("ClaimPostSubmission - Prescription-Dispense");
                    div_iterationBOX.Style.Value = "display: none;";
                    break;
                case "Laboratory-Dispense":
                    LoadFile("ClaimPostSubmission - Laboratory-Dispense");
                    div_iterationBOX.Style.Value = "display: none;";
                    break;
                case "Radiology-Dispense":
                    LoadFile("ClaimPostSubmission - Radiology-Dispense");
                    div_iterationBOX.Style.Value = "display: none;";
                    break;
                
            }
        }

        private void download_file(string filename,string file_ext, string filecontent)
        {
            try
            {
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

                else if (file_ext.ToLower() == ".pdf")
                {
                    byte[] file = Convert.FromBase64String(filecontent);
                    Response.ContentType = "application/pdf";
                    Response.Charset = string.Empty;
                    Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                    Response.AppendHeader("Content-Dispostion", "attachment; filename=" + filename);
                    Response.BinaryWrite(file);
                    Response.OutputStream.Flush();
                    Response.OutputStream.Close();

                }

                else if(file_ext.ToLower() == ".txt")
                {
                    byte[] file = Convert.FromBase64String(filecontent);
                    Response.ContentType = "text/html";
                    Response.Charset = string.Empty;
                    Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                    Response.AppendHeader("Content-Dispostion", "attachment; filename=" + filename);
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

        #endregion
    }
}