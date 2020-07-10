using Services_All.ExtraClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Services_All.Utilities_UI
{
    public partial class DHCC_Client : System.Web.UI.Page
    {

        #region Variables
        private static string clin_path;
        private static string facil_path;
        private static string reference_absloute;
        private static string[] global_start;
        private static string[] global_end;
        private static string Queue_dir = System.Configuration.ConfigurationManager.AppSettings["EmailQueue"];
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {

                bool to_iterate = false;
                bool is_QA = false;
                string strFrom = txt_FromDate.Text.ToString();
                string strTo = txt_EndDate.Text.ToString();
                string Days = string.Empty;
                string enviorment = rd_list_enviorment.SelectedValue;

                if (enviorment.ToLower() == "qa")
                {
                    is_QA = true;
                }
                else if (enviorment.ToLower() == "production")
                {
                    is_QA = false;
                }



                if (chk_iterate.Checked)
                {
                    to_iterate = true;
                }
                if (txt_daysinterval.Text.Length > 0)
                {
                    Days = txt_daysinterval.Text;
                }

                txt_rich_box.InnerText = Control_Unit(to_iterate, false, strFrom, strTo, Days, is_QA);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                txt_rich_box.InnerText = ex.Message;
            }
        }

        public static string Control_Unit(bool to_iterate, bool to_upload, string strFrom, string strTo, string Days, bool is_QA)
        {

            string local_path = @"C:\tmp\DHCC\";
            string result = string.Empty;


            clin_path = local_path + "techsupport_clinician_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            facil_path = local_path + "techsupport_facility_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            reference_absloute = local_path + "techsupport_Reference_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            Logger.Info("DHCC Process started");
            Logger.Info("Clinician file path " + clin_path);
            Logger.Info("Facilities file path " + facil_path);

            try
            {


                if (strFrom.Length > 1)
                {
                    if (File.Exists(clin_path) == false || File.Exists(facil_path) == false)
                    {
                        if (Create_Files(clin_path, true) == true && Create_Files(facil_path, false) == true)
                        {
                            if (to_iterate == false)
                            {
                                if (!is_QA)
                                {
                                    result = Run_Process(strFrom, strTo);
                                }
                                else if (is_QA)
                                {
                                    result = Run_Process_QA(strFrom, strTo);
                                }


                                if (to_upload)
                                {
                                    Upload_File(clin_path);
                                    Upload_data(clin_path);
                                    move_files(clin_path);
                                }
                                else
                                {
                                    move_files(clin_path);
                                    move_files(facil_path);
                                    Directory.Delete(local_path, true);
                                }
                            }
                            else if (to_iterate == true)
                            {
                                result = Run_Iterative(Days, strFrom, is_QA);
                                if (to_upload)
                                {
                                    Upload_File(clin_path);
                                    Upload_data(clin_path);
                                }
                                else
                                {
                                    move_files(clin_path);
                                    move_files(facil_path);
                                    move_files(reference_absloute);
                                    Directory.Delete(local_path, true);
                                }
                            }
                        }
                    }
                }
                else
                {
                    result = "Please select dates";
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ex.Message;
            }
        }

        private static string Run_Iterative(string Days, string strFrom, bool is_QA)
        {
            Logger.Info("Process Controller started");

            try
            {
                get_DateRanges(Days, strFrom);
                string result_builder = string.Empty;
                for (int i = 0; i < global_start.Length; i++)
                {
                    if (!is_QA)
                    {
                        result_builder += Run_Process(global_start[i], global_end[i]);
                    }
                    else if (is_QA)
                    {
                        result_builder += Run_Process_QA(global_start[i], global_end[i]);
                    }
                }
                using (StreamWriter resulter = new StreamWriter(reference_absloute))
                {
                    resulter.Write(result_builder);
                }
                Logger.Info("Process Controller completed");
                return "Process completed for " + global_start.Length + " sub set of dates";
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ex.Message;
            }
        }

        private static string Run_Process(string strFrom, string strTo)
        {
            Logger.Info("Process Excecution started");
            string result = string.Empty;
            string password_HCP = string.Empty;
            string password_local = string.Empty;
            string calculatedtoken = "DHCC-" + DateTime.Now.ToString("ddMMyyyy");

            try
            {

                ExtraClasses.EncryptionDecryptionHelper encryptionHelper = new ExtraClasses.EncryptionDecryptionHelper();
                DHCCHCPService.HCPServiceSoapClient hcpClient = new DHCCHCPService.HCPServiceSoapClient();
                DHCCHCPService.Authentication authentication = new DHCCHCPService.Authentication();
                DHCCHCPService.InputParam inputParam = new DHCCHCPService.InputParam();


                string encodeid = encryptionHelper.EncryptMain(calculatedtoken, "CERTNAME_PROD");
                Logger.Info("Encoded id :" + encodeid);
                authentication.secid = encodeid;
                inputParam.dateFrom = strFrom;
                inputParam.dateTo = strTo;

                Logger.Info("Get Professtionals called");
                DHCCHCPService.HCP[] listHCP = hcpClient.GetProfessionals(authentication, inputParam);


               
                StringBuilder sb = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();

                


                if (listHCP != null)
                {
                    Logger.Info("ListHCP is not NULL");
                    if (listHCP.Length > 0)
                    {
                        Logger.Info("Get Professtionals returned with " + listHCP.Length + " records for date range Start:" + strFrom + " End:" + strTo);

                        //StringBuilder sb_new1 = new StringBuilder();
                        //StringBuilder sb_new2 = new StringBuilder();



                        //using (StreamWriter clinician1 = File.AppendText(clin_path))
                        //{
                        //    using (StreamWriter facility1 = File.AppendText(facil_path))
                        //    {
                        //        clinician1.AutoFlush = true;
                        //        facility1.AutoFlush = true;

                        //        for (int i = 0; i < listHCP.Length; i++)
                        //        {
                        //            //password_HCP = encryptionHelper.DecryptMain(listHCP[i].password, "CERTNAME_PROD");
                        //            //password_local = Encrypt(password_HCP);

                        //            sb_new1.Append(strFrom + "|" + strTo + "|" + listHCP[i].License + "|" + listHCP[i].FullName + "|" + listHCP[i].username + "|" + listHCP[i].password + "|" + listHCP[i].FacilityLicense
                        //                + "|" + listHCP[i].FacilityName + "|" + listHCP[i].Location + "|" + listHCP[i].ActiveFrom + "|" + listHCP[i].ActiveTo + "|" + listHCP[i].IsActive + "|" + listHCP[i].Source
                        //                 + "|" + listHCP[i].SpecialtyID1 + "|" + listHCP[i].SpecialtyDescription + "|" + listHCP[i].Gender + "|" + listHCP[i].Nationality + "|" + listHCP[i].Email
                        //                 + "|" + listHCP[i].PhoneNumber + "|" + listHCP[i].SpecialtyID2 + "|" + listHCP[i].SpecialtyID3 + "|" + listHCP[i].HCType + "\n");

                        //            if (listHCP[i].facilities != null)
                        //            {
                        //                DHCCHCPService.Facility[] listFacility = listHCP[i].facilities;
                        //                if (listFacility.Length > 0)
                        //                {
                        //                    Logger.Info("Facilites records found. Records:" + listFacility.Length);

                        //                    for (int j = 0; j < listFacility.Length; j++)
                        //                    {
                        //                        sb_new2.Append(strFrom + "|" + strTo + "|" + listHCP[i].License + "|" + listHCP[i].FullName + "|" + listFacility[j].FacilityLicense + "|" + listFacility[j].FacilityName + "\n");
                        //                    }
                        //                    Logger.Info("Appending records to facilities file");
                        //                    facility1.Write(sb_new2);
                        //                }
                        //            }

                        //        }
                        //    }
                        //    clinician1.Write(sb_new1);
                        //}
                        //move_files(clin_path);


                        //string local_path = @"C:\tmp\DHCC\";
                        //clin_path = local_path + "techsupport_clinician_Transformed_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                        //facil_path = local_path + "techsupport_facility_Transformed_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";

                        //Create_Files(clin_path, true);
                        //Create_Files(facil_path, false);



                        using (StreamWriter clinician = File.AppendText(clin_path))
                        {
                            using (StreamWriter facility = File.AppendText(facil_path))
                            {
                                facility.AutoFlush = true;
                                clinician.AutoFlush = true;


                                for (int i = 0; i < listHCP.Length; i++)
                                {
                                    password_HCP = encryptionHelper.DecryptMain(listHCP[i].password, "CERTNAME_PROD");
                                    password_local = Encrypt(password_HCP);
                                    Logger.Info("Row No:" + i);
                                    Logger.Info(strFrom + "|" + strTo + "|" + listHCP[i].License + "|" + listHCP[i].FullName + "|" + listHCP[i].username + "|" + password_local + "|" + listHCP[i].FacilityLicense
                                           + "|" + listHCP[i].FacilityName + "|" + listHCP[i].Location + "|" + listHCP[i].ActiveFrom + "|" + listHCP[i].ActiveTo + "|" + listHCP[i].IsActive + "|" + listHCP[i].Source
                                           + "|" + listHCP[i].SpecialtyID1 + "|" + listHCP[i].SpecialtyDescription + "|" + listHCP[i].Gender + "|" + listHCP[i].Nationality + "|" + listHCP[i].Email
                                           + "|" + listHCP[i].PhoneNumber + "|" + listHCP[i].SpecialtyID2 + "|" + listHCP[i].SpecialtyID3 + "|" + listHCP[i].HCType);


                                    //Logger.Info("Iteration Number: " + i);
                                    //Logger.Info(ConvertDate(strFrom) + "|" + ConvertDate(strTo) + "|" + listHCP[i].License + "|" + listHCP[i].FullName + "|" + listHCP[i].username + "|" + password_local + "|" + listHCP[i].FacilityLicense
                                    //        + "|" + listHCP[i].FacilityName + "|" + listHCP[i].Location + "|" + ConvertDate(listHCP[i].ActiveFrom) + "|" + ConvertDate(listHCP[i].ActiveTo) + "|" + listHCP[i].IsActive + "|" + listHCP[i].Source
                                    //        + "|" + listHCP[i].SpecialtyID1 + "|" + listHCP[i].SpecialtyDescription + "|" + listHCP[i].Gender + "|" + listHCP[i].Nationality + "|" + listHCP[i].Email
                                    //        + "|" + listHCP[i].PhoneNumber + "|" + listHCP[i].SpecialtyID2 + "|" + listHCP[i].SpecialtyID3 + "|" + listHCP[i].HCType + "\n");
                                    //Logger.Info("*************************************************************************************************************************");

                                    if (listHCP[i].License != null && listHCP[i].FullName != null && listHCP[i].IsActive != null && listHCP[i].Source != null
                                        && listHCP[i].HCType != null)
                                    {
                                        if (listHCP[i].License.Trim().Length > 0 && listHCP[i].FullName.Trim().Length > 0 && listHCP[i].IsActive.Trim().Length > 0
                                            && listHCP[i].Source.Trim().Length > 0 && listHCP[i].HCType.Trim().Length > 0)
                                        {
                                            sb.Append(
                                                ConvertDate(strFrom) + "|" +
                                                ConvertDate(strTo) + "|" +

                                                CheckComma(listHCP[i].License) + "|" +
                                                CheckComma(listHCP[i].FullName) + "|" +
                                                CheckComma(listHCP[i].username) + "|" +

                                                password_local + "|" +

                                                CheckComma(listHCP[i].FacilityLicense) + "|" +
                                                CheckComma(listHCP[i].FacilityName) + "|" +
                                                CheckComma(listHCP[i].Location) + "|" +

                                                ConvertDate(listHCP[i].ActiveFrom) + "|" +
                                                ConvertDate(listHCP[i].ActiveTo) + "|" +

                                                CheckComma(listHCP[i].IsActive) + "|" +
                                                CheckComma(listHCP[i].Source) + "|" +
                                                CheckComma(listHCP[i].SpecialtyID1) + "|" +
                                                CheckComma(listHCP[i].SpecialtyDescription) + "|" +
                                                CheckComma(listHCP[i].Gender) + "|" +
                                                CheckComma(listHCP[i].Nationality) + "|" +
                                                CheckComma(listHCP[i].Email) + "|" +
                                                CheckComma(listHCP[i].PhoneNumber) + "|" +
                                                CheckComma(listHCP[i].SpecialtyID2) + "|" +
                                                CheckComma(listHCP[i].SpecialtyID3) + "|" +
                                                CheckComma(listHCP[i].HCType) + "|" +
                                                "" + "\n"
                                                );
                                        }
                                    }
                                    else
                                    {
                                        Logger.Info("Null value found");
                                        Logger.Info("License: " + listHCP[i].License + " Fullname: " + listHCP[i].FullName + " IsActive: " + listHCP[i].IsActive + " Source: " + listHCP[i].Source
                                            + " HCP Type: " + listHCP[i].HCType);
                                    }

                                    //if (listHCP[i].facilities != null)
                                    //{
                                    //    DHCCHCPService.Facility[] listFacility = listHCP[i].facilities;
                                    //    if (listFacility.Length > 0)
                                    //    {
                                    //        Logger.Info("Facilites records found. Records:" + listFacility.Length);

                                    //        for (int j = 0; j < listFacility.Length; j++)
                                    //        {
                                    //            sb2.Append(strFrom + "|" + strTo + "|" + listHCP[i].License + "|" + listHCP[i].FullName + "|" + listFacility[j].FacilityLicense + "|" + listFacility[j].FacilityName + "\n");
                                    //        }
                                    //        Logger.Info("Appending records to facilities file");
                                    //        facility.Write(sb2);
                                    //    }
                                    //}
                                }
                            }
                            Logger.Info("Appending records to Clinician file");
                            clinician.Write(sb);
                        }
                        Logger.Info("\nRecords Found:" + listHCP.Length + " Date From: " + strFrom + " To: " + strTo);
                        result = "\nRecords Found:" + listHCP.Length + " Date From: " + strFrom + " To: " + strTo;
                    }
                    else
                    {
                        Logger.Info("\nNo records found in date From: " + strFrom + " To: " + strTo);
                        result = "\nNo records found in date From: " + strFrom + " To: " + strTo;
                    }
                }
                else
                {
                    Logger.Info("\nLIST HCP returned NULL date From: " + strFrom + " To: " + strTo);
                    result = "\nLIST HCP returned NULL date From: " + strFrom + " To: " + strTo;
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return "\nException Occured in date from: " + strFrom + " to: " + strTo + "\nError: " + ex.Message;
            }
        }

        private static string Run_Process_QA(string strFrom, string strTo)
        {
            Logger.Info("Process Excecution started");
            string result = string.Empty;
            string password_HCP = string.Empty;
            string password_local = string.Empty;
            string calculatedtoken = "DHCC-" + DateTime.Now.ToString("ddMMyyyy");

            try
            {

                ExtraClasses.EncryptionDecryptionHelper encryptionHelper = new ExtraClasses.EncryptionDecryptionHelper();
                DHCCHCPService_QA.HCPServiceSoapClient hcpClient = new DHCCHCPService_QA.HCPServiceSoapClient();
                DHCCHCPService_QA.Authentication authentication = new DHCCHCPService_QA.Authentication();
                DHCCHCPService_QA.InputParam inputParam = new DHCCHCPService_QA.InputParam();


                string encodeid = encryptionHelper.EncryptMain(calculatedtoken, "CERTNAME_QA");
                Logger.Info("Encoded id :" + encodeid);
                authentication.secid = encodeid;
                inputParam.dateFrom = strFrom;
                inputParam.dateTo = strTo;

                Logger.Info("Get Professtionals called");
                DHCCHCPService_QA.HCP[] listHCP = hcpClient.GetProfessionals(authentication, inputParam);


                StringBuilder sb = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();


                if (listHCP != null)
                {
                    Logger.Info("ListHCP is not NULL");
                    if (listHCP.Length > 0)
                    {
                        foreach (var item in listHCP)
                        {
                            Logger.Info(item.ActiveFrom + "," + item.ActiveTo + "," + item.DHCCSpecialty1 + "," + item.DHCCSpecialty2 + "," + item.DHCCSpecialty3 + "," + item.Email + "," + item.EmiratesID + "," + item.facilities + "," + item.FacilityLicense + "," + item.FacilityName + "," + item.FullName + "," + item.Gender + "," + item.HCType + "," + item.IsActive + "," + item.License + "," + item.Location + "," + item.Nationality + "," + item.PassportIssuingCountry + "," + item.PassportNumber + "," + item.password + "," + item.PhoneNumber + "," + item.Qualification + "," + item.Source + "," + item.SpecialtyDescription + "," + item.SpecialtyID1 + "," + item.SpecialtyID2 + "," + item.SpecialtyID3 + "," + item.username);

                        }

                        Logger.Info("Get Professtionals returned with " + listHCP.Length + " records for date range Start:" + strFrom + " End:" + strTo);

                        using (StreamWriter clinician = File.AppendText(clin_path))
                        {
                            using (StreamWriter facility = File.AppendText(facil_path))
                            {
                                facility.AutoFlush = true;
                                clinician.AutoFlush = true;


                                for (int i = 0; i < listHCP.Length; i++)
                                {

                                    password_HCP = encryptionHelper.DecryptMain(listHCP[i].password, "CERTNAME_QA");
                                    password_local = Encrypt(password_HCP);
                                    //string password_local_decrypt = Decrypt(password_local);

                                    //DateTime startd = DateTime.ParseExact(strFrom, "dd-MM-yyyy", null);
                                    //string strFrom_New = startd.ToString("MM/dd/yyyy hh:mm:ss");

                                    //DateTime endd = DateTime.ParseExact(strTo, "dd-MM-yyyy", null);
                                    //string strTo_New = endd.ToString("MM/dd/yyy hh:mm:ss");

                                    //string activefromDatedata = string.Empty;
                                    //string activetoDatedata = string.Empty;

                                    //DateTime mydate = Convert.ToDateTime(listHCP[i].ActiveFrom);
                                    //activefromDatedata = mydate.ToString("MM/dd/yyyy hh:mm:ss");

                                    //DateTime ActiveTo = Convert.ToDateTime(listHCP[i].ActiveTo);
                                    //activetoDatedata = ActiveTo.ToString("MM/dd/yyyy hh:mm:ss");

                                    //sb.Append(strFrom_New + "|" + strTo_New + "|" + listHCP[i].License + "|" + listHCP[i].FullName + "|" + listHCP[i].username + "|" + password_local + "|" + listHCP[i].FacilityLicense
                                    //    + "|" + listHCP[i].FacilityName + "|" + listHCP[i].Location + "|" + activefromDatedata + "|" + activetoDatedata + "|" + listHCP[i].IsActive + "|" + listHCP[i].Source
                                    //     + "|" + listHCP[i].SpecialtyID1 + "|" + listHCP[i].SpecialtyDescription + "|" + listHCP[i].Gender + "|" + listHCP[i].Nationality + "|" + listHCP[i].Email
                                    //     + "|" + listHCP[i].PhoneNumber + "|" + listHCP[i].SpecialtyID2 + "|" + listHCP[i].SpecialtyID3 + "|" + listHCP[i].HCType + "\n");

                                    //if (listHCP[i].facilities != null)
                                    //{
                                    //    DHCCHCPService_QA.Facility[] listFacility = listHCP[i].facilities;
                                    //    if (listFacility.Length > 0)
                                    //    {
                                    //        Logger.Info("Facilites records found. Records:" + listFacility.Length);

                                    //        for (int j = 0; j < listFacility.Length; j++)
                                    //        {
                                    //            sb2.Append(strFrom + "|" + strTo + "|" + listHCP[i].License + "|" + listHCP[i].FullName + "|" + listFacility[j].FacilityLicense + "|" + listFacility[j].FacilityName + "\n");
                                    //        }
                                    //        Logger.Info("Appending records to facilities file");
                                    //        facility.Write(sb2);
                                    //    }
                                    //}

                                    if (listHCP[i].License != null && listHCP[i].FullName != null && listHCP[i].IsActive != null && listHCP[i].Source != null
                                        && listHCP[i].HCType != null)
                                    {
                                        if (listHCP[i].License.Trim().Length > 0 && listHCP[i].FullName.Trim().Length > 0 && listHCP[i].IsActive.Trim().Length > 0
                                            && listHCP[i].Source.Trim().Length > 0 && listHCP[i].HCType.Trim().Length > 0)
                                        {
                                            sb.Append(
                                                ConvertDate(strFrom) + "|" +
                                                ConvertDate(strTo) + "|" +

                                                CheckComma(listHCP[i].License) + "|" +
                                                CheckComma(listHCP[i].FullName) + "|" +
                                                CheckComma(listHCP[i].username) + "|" +

                                                password_local + "|" +

                                                CheckComma(listHCP[i].FacilityLicense) + "|" +
                                                CheckComma(listHCP[i].FacilityName) + "|" +
                                                CheckComma(listHCP[i].Location) + "|" +

                                                ConvertDate(listHCP[i].ActiveFrom) + "|" +
                                                ConvertDate(listHCP[i].ActiveTo) + "|" +

                                                CheckComma(listHCP[i].IsActive) + "|" +
                                                CheckComma(listHCP[i].Source) + "|" +
                                                CheckComma(listHCP[i].SpecialtyID1) + "|" +
                                                CheckComma(listHCP[i].SpecialtyDescription) + "|" +
                                                CheckComma(listHCP[i].Gender) + "|" +
                                                CheckComma(listHCP[i].Nationality) + "|" +
                                                CheckComma(listHCP[i].Email) + "|" +
                                                CheckComma(listHCP[i].PhoneNumber) + "|" +
                                                CheckComma(listHCP[i].SpecialtyID2) + "|" +
                                                CheckComma(listHCP[i].SpecialtyID3) + "|" +
                                                CheckComma(listHCP[i].HCType) + "\n"
                                                );
                                        }
                                    }
                                    else
                                    {
                                        Logger.Info("Null value found");
                                        Logger.Info("License: " + listHCP[i].License + " Fullname: " + listHCP[i].FullName + " IsActive: " + listHCP[i].IsActive + " Source: " + listHCP[i].Source
                                            + " HCP Type: " + listHCP[i].HCType);
                                    }

                                }
                            }
                            Logger.Info("Appending records to Clinician file");
                            clinician.Write(sb);
                        }
                        Logger.Info("\nRecords Found:" + listHCP.Length + " Date From: " + strFrom + " To: " + strTo);
                        result = "\nRecords Found:" + listHCP.Length + " Date From: " + strFrom + " To: " + strTo;
                    }
                    else
                    {
                        Logger.Info("\nNo records found in date From: " + strFrom + " To: " + strTo);
                        result = "\nNo records found in date From: " + strFrom + " To: " + strTo;
                    }
                }
                else
                {
                    Logger.Info("\nLIST HCP returned NULL date From: " + strFrom + " To: " + strTo);
                    result = "\nLIST HCP returned NULL date From: " + strFrom + " To: " + strTo;
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return "\nException Occured in date from: " + strFrom + " to: " + strTo + "\nError: " + ex.Message;
            }
        }



        #region helper_functions

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "dhcc_client";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "dhcc_client";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static string ConvertDate(string Rdate)
        {

            string[] formats = {
                        "dd/MM/yyyy hh:mm:ss tt"
                     ,  "dd/MM/yyyy hh:mm:ss"
                     ,  "dd/MM/yyyy hh:mm:ss t"
                     ,  "dd/MM/yyyy h:m:s t"
                     ,  "dd/MM/yyyy HH:mm:ss"
                     ,  "dd/MM/yyyy HH:mm:ss tt"
                     ,  "dd/MM/yyyy H:m:s t"
                     ,  "dd/MM/yyyy"
                     ,  "d/M/yy hh:mm:ss tt"
                     ,  "M/d/yyyy h:mm:ss tt"
                     ,  "M/d/yyyy h:mm tt"
                     ,  "MM/dd/yyyy hh:mm:ss"
                     ,  "M/d/yyyy h:mm:ss"
                     ,  "M/d/yyyy hh:mm tt"
                     ,  "M/d/yyyy hh tt"
                     ,  "M/d/yyyy h:mm"
                     ,  "M/d/yyyy h:mm"
                     ,  "MM/dd/yyyy hh:mm"
                     ,  "M/dd/yyyy hh:mm"
                     ,  "dd-MM-yyyy"
                     ,  "dd-MM-yyyy HH:mm:ss"
              };

            Logger.Info("Transforming date " + Rdate);
            string activetoDatedata = string.Empty;
            bool isParsed = false;
            DateTime getDatefromString = DateTime.Now;

            try
            {

                if (DateTime.TryParseExact(Rdate, formats, new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out getDatefromString))
                {
                    //Logger.Info("Converted '" + Rdate + "' to " + getDatefromString + ".");
                    isParsed = true;
                }
                else
                {
                    Logger.Info("Unable to parse '"+ Rdate + "' to a date.");
                }

                if (isParsed)
                {
                    activetoDatedata = getDatefromString.ToString("MM/dd/yyyy hh:mm:ss");
                }
                else
                {
                    DateTime tmpDate = DateTime.Now;
                    DateTime dtNeedParsing = DateTime.TryParse(Rdate, out tmpDate) == true ? DateTime.Parse(Rdate) : tmpDate;

                    if (tmpDate == dtNeedParsing)
                    {
                        Logger.Info(" ~~~~~~~~ not able to parse the date correctly ~~~~~~~~~~~~ ");
                    }
                    else
                    {
                        activetoDatedata = dtNeedParsing.ToString("MM/dd/yyyy hh:mm:ss");
                    }
                }
                Logger.Info("Converted '" + Rdate + "' to " + activetoDatedata + ".");
                return activetoDatedata;
            }

            catch (Exception ex)
            {
                Logger.Info(ex.Message);
                return null;
            }
        }
        private static string CheckComma(string data)
        {
            string result = string.Empty;
            if (data != null)
            {
                if (data.Length > 0)
                {
                    if (data.Contains(","))
                    {
                        result = data.Replace(',', ' ');
                    }
                    else
                    {
                        result = data;
                    }
                }
            }
            else
            {
                result = data;
            }
            return data;
        }
        private static string CheckComma2(string data)
        {
            string result = string.Empty;
            result = data;
            if (data != null)
            {
                if (data.Length > 0)
                {
                    if (data.Contains(","))
                    {
                        result = data.Replace(",", " ");
                    }
                    if (result.Contains("\n"))
                    {
                        result = result.Replace("\n", "\\n");
                    }
                    if (result.Contains("\r"))
                    {
                        result = result.Replace("\r", " ");
                    }
                    if (result.Contains("'"))
                    {
                        result = result.Replace("'", "''");
                    }

                }
                else
                {
                    result = string.Empty;
                }
            }
            else
            {
                result = data;
            }
            return result;
        }

        public static string Upload_File(string local_file_path)
        {
            string ftpUserName = System.Configuration.ConfigurationManager.AppSettings["FTPUsername"];
            string ftpPassword = System.Configuration.ConfigurationManager.AppSettings["FTPPassword"];
            string FTPServerPath = System.Configuration.ConfigurationManager.AppSettings["FTPLocalPath"];
            string ftpServerIP = System.Configuration.ConfigurationManager.AppSettings["FTPHost"];
            FileInfo localFileInfo = new FileInfo(local_file_path);
            Logger.Info("Uploading file " + Path.GetFileName(local_file_path) + " to address " + ftpServerIP + "/Pending/" + Path.GetFileName(local_file_path));
            FileStream fs = null;
            Stream uploadStream = null;
            Logger.Info("Uploading File " + local_file_path + " to server");
            try
            {

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpServerIP + "//Pending/" + Path.GetFileName(local_file_path));
                Logger.Info("Create WebRequest - Success");
                request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.UseBinary = false;
                request.UsePassive = false;

                request.ContentLength = localFileInfo.Length;
                // The buffer size is set to 2kb
                int bufferrLength = 2048;
                byte[] _Buffer = new byte[bufferrLength];
                int contentLength;

                fs = localFileInfo.OpenRead();
                uploadStream = request.GetRequestStream();
                if (uploadStream != null)
                {
                    Logger.Info("Get FTPWebRequest - Success");
                    contentLength = fs.Read(_Buffer, 0, bufferrLength);

                    while (contentLength != 0)
                    {

                        uploadStream.Write(_Buffer, 0, contentLength);
                        contentLength = fs.Read(_Buffer, 0, bufferrLength);
                    }
                }
                uploadStream.Close();
                fs.Close();

                return "";
            }

            catch (Exception ex)
            {
                Logger.Error(ex);
                return ex.Message;
            }
            finally
            {
                uploadStream.Close();
                fs.Close();
            }

        }
        private static void Upload_data(string file)
        {
            try
            {
                string[] file_text = File.ReadAllLines(file);
                Console.WriteLine("Working on file: " + Path.GetFileNameWithoutExtension(file));
                if (file_text.Length > 1)
                {
                    StringBuilder sb = new StringBuilder();
                    string query = string.Empty;
                    for (int i = 1; i < file_text.Length; i++)
                    {
                        string[] rows = file_text[i].Split(new char[] { '|' });
                        if (rows.Length > 1)
                        {
                            Console.WriteLine("Working on line number: " + i);
                            //sb.Append
                            //(
                            query += "INSERT INTO [FS_WS_WSCTFW].[dbo].[DHCC_Clinician]([FileName],[Start_Date],[End_Date],[Clinician_License],[Clinician_Name],[Username],[Password],[Password_Encoded],[Facility_License],[Facility_Name],[Location],[Active_From],[Active_To],[Active],[Source],[SpecialityId1],[Speciality_Description],[Gender],[Nationality],[Email],[Phone],[SpecialityId2],[SpecialityId3],[type]) VALUES " +

                            "('" +
                            Path.GetFileNameWithoutExtension(file.ToString()) + "','" +
                            CheckComma2(rows[0]) + "','" +

                            CheckComma2(rows[1]) + "','" +
                            CheckComma2(rows[2]) + "','" +
                            CheckComma2(rows[3]) + "','" +
                            CheckComma2(rows[4]) + "','" +
                            "','" +
                            CheckComma2(rows[5]) + "','" +
                            CheckComma2(rows[6]) + "','" +
                            CheckComma2(rows[7]) + "','" +
                            CheckComma2(rows[8]) + "','" +
                            CheckComma2(rows[9]) + "','" +
                            CheckComma2(rows[10]) + "','" +
                            CheckComma2(rows[11]) + "','" +
                            CheckComma2(rows[12]) + "','" +
                            CheckComma2(rows[13]) + "','" +
                            CheckComma2(rows[14]) + "','" +
                            CheckComma2(rows[15]) + "','" +
                            CheckComma2(rows[16]) + "','" +
                            CheckComma2(rows[17]) + "','" +
                            CheckComma2(rows[18]) + "','" +
                            CheckComma2(rows[19]) + "','" +
                            CheckComma2(rows[20]) + "','" +
                            //CheckComma(rows[21]) + "'),";

                            CheckComma2(rows[21]) + "')\n";

                            //);
                        }

                        //Console.WriteLine("your query: " + query);
                    }

                    //query = query + sb.ToString().Remove(sb.Length - 1, 1);
                    Insert_toDB(query, "");
                }
            }
            catch (Exception ex)
            {
                Logger.Info("Failed to upload file to DB");
                Logger.Error(ex);
            }
        }

        private static bool Create_Files(string file_path, bool is_Clin)
        {
            bool result = false;
            Logger.Info("Creating files started");
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(file_path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(file_path));
                }
                using (StreamWriter sw = new StreamWriter(file_path))
                {
                    if (is_Clin)
                    {
                        sw.Write("Start Date|End Date|Clinician License|Clinician Name|Username|Password|Facility License|Facility Name|Location|Active From|Active To|active|source|" +
                                "Specilaity ID 1|Speciality Description|Gender|Nationality|Email|Phone|Speciality ID 2|Speciality ID 3|type|Clinician Id Old\n");
                        result = true;
                    }
                    else if (!is_Clin)
                    {
                        sw.Write("Start Date|End Date|Clinician License|Clinician Name|FacilityLicense|FacilityName\n");
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                result = false;
            }
            Logger.Info("Creating files completed");

            return result;
        }
        private static bool Move_Directory(string Local_DIR, string Queue_DIR)
        {
            Logger.Info("Process Move to Queue started");
            bool result = false;
            try
            {
                Directory.Move(Local_DIR, Queue_DIR + "techsupport_DHCC");
                Logger.Info("Process Move to Queue completed");
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
        }
        private static void get_DateRanges(string Days_str, string Date)
        {
            Logger.Info("Process DATE Ranges started");
            try
            {
                List<string> start_dates = new List<string>();
                List<string> end_dates = new List<string>();
                int Days;


                if (Days_str.Length > 0)
                {
                    Days = Convert.ToInt32(Days_str);
                }
                else { Days = 5; }

                DateTime start = DateTime.ParseExact(Date, "dd-MM-yyyy", null);
                //DateTime end = Convert.ToDateTime(txt_EndDate.Text);
                DateTime end = start.AddDays(Days);


                while (start < DateTime.Now)
                {
                    start_dates.Add(start.ToString("dd-MM-yyyy"));
                    end_dates.Add(end.ToString("dd-MM-yyyy"));

                    start = start.AddDays(Days + 1);
                    end = start.AddDays(Days);
                }
                global_start = start_dates.ToArray();
                global_end = end_dates.ToArray();
                Logger.Info("Process DATE Ranges completed");

            }

            catch (Exception ex)
            {
                Logger.Error(ex);
            }

        }
        private static void move_files(string file_absloute)
        {
            Logger.Info("Moving File " + file_absloute);
            try
            {
                File.Move(file_absloute, Queue_dir + Path.GetFileName(file_absloute));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        protected void chk_iterate_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_iterate.Checked == true)
            {
                pnl_interval.Visible = true;
                pnl_toDate.Visible = false;
            }
            else
            {
                pnl_interval.Visible = false;
                pnl_toDate.Visible = true;
            }
        }
        public static void Insert_toDB(string query, string connection)
        {
            connection = "Data Source=" + Connections.run_singlevalue("Automation", "server") + ";Initial Catalog=" + Connections.run_singlevalue("Automation", "database") + ";User ID=" + Connections.run_singlevalue("Automation", "username") + ";Password=" + Connections.run_singlevalue("Automation", "password");
            //connection = "Data Source=10.11.13.183 ;Initial Catalog=FS_WS_WSCTFW ;User ID=fshaikh ;Password=Dell@900 ;Connection Timeout=30;";
            Logger.Info("Inserting records to FS DB");
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        con.Open();
                        if (command.ExecuteNonQuery() > 0)
                        {
                            Logger.Info(command.ExecuteNonQuery() + " Records added successfully");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Info("Insert To DB failed");
                Logger.Error(ex);
            }
        }
        #endregion
    }
}