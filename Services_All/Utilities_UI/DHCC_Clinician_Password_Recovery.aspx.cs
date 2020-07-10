using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;

namespace Services_All.Utilities_UI
{
    public partial class DhccClinician_Password_Recovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txt_submit_Click(object sender, EventArgs e)
        {
            string dhcc_decrypted_pass = string.Empty;
            txt_rich_box.InnerText = null;
            try
            {
                if (rd_function.SelectedValue == "decryptbydhcc")
                {

                    ExtraClasses.EncryptionDecryptionHelper encryptionHelper = new ExtraClasses.EncryptionDecryptionHelper();
                    dhcc_decrypted_pass = encryptionHelper.DecryptMain(txt_password.Text, "CERTNAME_PROD");
                    txt_rich_box.InnerText = "DHCC Decrypted\n" + dhcc_decrypted_pass;
                }
                else if (rd_function.SelectedValue == "encryptbylocalkey")
                {
                    txt_rich_box.InnerText = "Local Encrypted\n" + DHCC_Client.Encrypt(txt_password.Text);
                }
                else if (rd_function.SelectedValue == "decryptbylocalkey")
                {
                    txt_rich_box.InnerText = "Local Decrypted\n" + DHCC_Client.Decrypt(txt_password.Text);
                }
                else if (rd_function.SelectedValue == "getboth")
                {
                    ExtraClasses.EncryptionDecryptionHelper encryptionHelper = new ExtraClasses.EncryptionDecryptionHelper();
                    dhcc_decrypted_pass = encryptionHelper.DecryptMain(txt_password.Text, "CERTNAME_PROD");
                    string local_encrypt = DHCC_Client.Encrypt(dhcc_decrypted_pass);
                    string local_decrypt = DHCC_Client.Decrypt(local_encrypt);

                    txt_rich_box.InnerText = "DHCC Decryption:\n" + dhcc_decrypted_pass +
                        "\nLocal Encrypted:\n" + local_encrypt +
                        "\nLocal Decrypted:\n" + local_decrypt;

                }
                else if (rd_function.SelectedValue == "upload_file")
                {
                    try
                    {
                        if (file_upload_dhcc.HasFile)
                        {
                            if (file_upload_dhcc.FileContent.Length > 0)
                            {
                                if (file_upload_dhcc.PostedFile.ContentType == "application/vnd.ms-excel")
                                {
                                    StringBuilder sb = new StringBuilder();
                                    ExtraClasses.EncryptionDecryptionHelper encryptionHelper = new ExtraClasses.EncryptionDecryptionHelper();

                                    string query = "Update [Clinicians]\nset [ClinicianLicense] = '@1', [UserName] = '@3' , [Password] = '@4'\nwhere [ClinicianLicense] = '@1'\n" +

                                        "if @@ROWCOUNT=0\nBegin\nInsert INTO @OUTPUTTABLE(ID) values ('@1')\n" +
                                        "Insert into Clinicians \n" +
                                        "([ClinicianLicense],[ClinicianName],[UserName],[Password],\n" +
                                        "[FacilityName],[Location],\n" +
                                        "[LicenseStartDate],[LicenseEndDate],[IsActive],\n" +
                                        "[Source])\n" +
                                        "values \n('@1','@2','@3','@4',\n" +
                                        "'@5','@6',\n" +
                                        "'@7','@8',@9,\n" +
                                        "'#10')\n" +
                                        "End \n" +
                                        "\nPRINT('***********************************************************')\n";

                                    string FileName = Path.GetFileNameWithoutExtension(file_upload_dhcc.PostedFile.FileName);
                                    string FileExt = Path.GetExtension(file_upload_dhcc.PostedFile.FileName);
                                    string filepath = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/" + FileName + FileExt);

                                    file_upload_dhcc.SaveAs(filepath);

                                    string[] rows = File.ReadAllLines(filepath);

                                    for (int i = 1; i < rows.Length; i++)
                                    {
                                        string[] values = rows[i].Split('|');
                                        sb.Append(CheckEmpty(values[2]) + "," + CheckEmpty(values[3]) + "," + CheckEmpty(values[4]) + "," + CheckEmpty(DHCC_Client.Decrypt(values[5])) +"," +
                                            CheckEmpty(values[7]) + "," + CheckEmpty(values[8]) + "," + 
                                            CheckEmpty(values[9]) + "," + CheckEmpty(values[10]) + "," + CheckActive(values[11]) + "," +
                                            CheckEmpty(values[12])  + "\n");
                                    }

                                    string response = create_custom(sb.ToString(), query);
                                    string new_response = "DECLARE @OUTPUTTABLE TABLE (ID NVARCHAR(50))\nUSE DHPO\n" + response + "\n\n\nSelect * from @OUTPUTTABLE";
                                    File.Delete(filepath);

                                    download_string(FileName + ".sql", new_response);
                                    txt_rich_box.InnerText = "File: " + FileName + " successfully downloaded";
                                }
                            }
                        }
                         
                    }
                    catch (Exception ex)
                    {
                        txt_rich_box.InnerText = ex.Message;
                    }
                }
            }
            catch(Exception ex)
            {
                txt_rich_box.InnerText = ex.Message;
            }
        }

        private string create_custom(string input, string query)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                string[] differences = { "\t", "\n", "\r" };
                string[] carry = input.Split(differences, StringSplitOptions.RemoveEmptyEntries);

                foreach (string parameters in carry)
                {
                    string dummy_query = query;
                    string[] diff = { "," };
                    string[] parameters_array = parameters.Split(diff, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 1; i < parameters_array.Length + 1; i++)
                    { 

                        if (i <= 9)
                            dummy_query = dummy_query.Replace("@" + i, parameters_array[i - 1]);
                        else if (i > 9 && i < 19)
                            dummy_query = dummy_query.Replace("#" + i, parameters_array[i - 1]);


                        dummy_query = dummy_query.Replace("'NULL'", "NULL");

                    }

                    sb.Append("\n\n");
                    sb.Append(dummy_query);
                }
                return sb.ToString();
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
                else if (file_ext == ".csv" || file_ext == ".CSV")
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(filecontent.ToString());

                    Response.ContentType = "text/csv";
                    Response.AddHeader("Content-Length", bytes.Length.ToString());
                    Response.AppendHeader("content-disposition", "attachment;filename=" + filename);
                    Response.BinaryWrite(bytes);
                }

                else if (file_ext == ".sql" || file_ext == ".SQL")
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(filecontent.ToString());

                    Response.ContentType = "text/sql";
                    Response.AddHeader("Content-Length", bytes.Length.ToString());
                    Response.AppendHeader("content-disposition", "attachment;filename=" + filename);
                    Response.BinaryWrite(bytes);
                   
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

        private string CheckEmpty(string data)
        {
            string result = string.Empty;
            if(data != null)
            {
                if (data.Length > 0)
                {
                    if (data.Contains(","))
                    {
                        data = data.Replace(',',' ');
                    }
                    if (data.Contains("\'"))
                    {
                        data = data.Replace("\'", string.Empty);
                    }

                    result = data;
                }
                else if(data.Length == 0)
                {
                    result = "NULL";
                }
                    
            }
            else if(data == null)
            {
                result = "NULL";
            }

            return result;
        }

        private int CheckActive(string data)
        {
            if(data.ToLower() =="active")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        protected void rd_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rd_function.SelectedValue == "upload_file")
                pnl_fileupload.Visible = true;
            else
                pnl_fileupload.Visible = false;
        }
    }
}