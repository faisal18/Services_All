using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

            bool detailed = false;

            if(rdbtn_detailed.Checked == true)
            {
                detailed = true;
            }

            try
            {
                token = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(token));

                if (txt_license.Text.Length > 1)
                {
                    string[] differences = { ",", "\t", "\n", "\r" };
                    string[] carry = txt_license.Text.Split(differences, StringSplitOptions.RemoveEmptyEntries);
                    StringBuilder sb = new StringBuilder();
                    string result1 = "License, name, Username, Password, Facility License, Facility Name, area, Active From, Active To,is active, source, " +
                       "Specialty ID 1,Specialty,Gender,Nationality,Email,Phone,Specialty ID 2,Specialty ID 3,type,Old License\n";

                    foreach (string data in carry)
                    {
                        string license = ApplyReverseClinicianFormula(data);
                        string data1 = "{\r\n  \"ProfessionalID\": \"" + license + "\"\r\n}";
                       
                        string result = PostCall_ByBody(URL, data1, token);

                        if(detailed)
                        {
                            result1 = result1 + ParseAsDHCC_Professional(result);
                            sb.Append(result1 + "\n");
                        }
                        else
                        {
                            sb.Append("Result for Professional " + data + "\n======================================\n" + result + "\n");
                        }
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

        public string ParseAsDHCC_Professional(string data)
        {
            string baseDir = "";
            string result = "";


            //if (!File.Exists(baseDir + "\\" + filename))
            //{
            //    using (StreamWriter writer = File.CreateText(baseDir + "\\" + filename))
            //    {
            //        writer.Write("License, name, Username, Password, Facility License, Facility Name, area, Active From, Active To,is active, source, " +
            //            "Specialty ID 1,Specialty,Gender,Nationality,Email,Phone,Specialty ID 2,Specialty ID 3,type,Old License\n");
            //    }
            //}


            try
            {



                if (data != null)
                    if (data.Length > 0)
                    {
                        JObject yo = JObject.Parse(data);
                        if (yo["ReturnCode"] != null)
                            if (yo["ReturnCode"].ToString() == "00")
                            {
                                JArray Professional = (JArray)yo["Professionals"];

                                for (int i = 0; i < Professional.Count; i++)
                                {
                                    Console.WriteLine("Line number: " + i);
                                    LMU_Professional lmu_prof = new LMU_Professional();
                                    StringBuilder Insert_LMU = new StringBuilder();



                                    try
                                    {


                                        if (yo["Professionals"][i]["Professional"].HasValues)
                                        {


                                            JObject PProfessional = JObject.Parse(yo["Professionals"][i]["Professional"].ToString());



                                            lmu_prof.ClinicianLicene = LimitString(CheckComma(PProfessional["unique_id"].ToString()), 20);
                                            lmu_prof.ClinicianIdOld = CheckComma(PProfessional["unique_id_old"].ToString());
                                            lmu_prof.ClinicianName = CheckComma(PProfessional["first_name_en"].ToString()) + " " + CheckComma(PProfessional["last_name_en"].ToString());
                                            //lmu_prof.Username = CheckComma(PProfessional["user_name"].ToString());
                                            lmu_prof.Username = "";
                                            lmu_prof.Gender = CheckComma(CheckGender(PProfessional["gender_code"].ToString()));
                                            lmu_prof.Nationality = CheckComma(PProfessional["passport_nationality_desc_en"].ToString());
                                            lmu_prof.Phone = CheckComma(PProfessional["contact_personal_phone"].ToString());
                                            lmu_prof.Email = CheckComma(PProfessional["contact_personal_email"].ToString());
                                            lmu_prof.Active = CheckActive(CheckComma(PProfessional["is_practice_allowed"].ToString()));

                                        }


                                        if (yo["Professionals"][i]["ProfessionalExperience"].HasValues)
                                        {
                                            JArray PPExperience_Array = (JArray)yo["Professionals"][i]["ProfessionalExperience"];
                                            string workenddate = PPExperience_Array[0]["work_end_date"].ToString();

                                            foreach (JObject PPExperience in PPExperience_Array)
                                            {
                                                if (PPExperience_Array.Count > 1)
                                                {
                                                    string newworkenddate = PPExperience["work_end_date"].ToString();
                                                    if (newworkenddate != null && workenddate != null)
                                                        if (newworkenddate != string.Empty && workenddate != string.Empty)
                                                            if (Convert.ToDateTime(workenddate) < Convert.ToDateTime(newworkenddate))
                                                            {
                                                                workenddate = newworkenddate;
                                                                lmu_prof.FacilityLicense = LimitString(CheckComma(PPExperience["facility_license_number"].ToString()), 20);
                                                                lmu_prof.FacilityName = CheckComma(PPExperience["work_name_en"].ToString());
                                                                lmu_prof.Location = LimitString(CheckComma(PPExperience["work_location_city_desc_en"].ToString()), 255);
                                                            }

                                                    //if (PPExperience["license_type_code"].ToString().ToLower() == "ftl")
                                                    //{
                                                    //    lmu_prof.FacilityLicense = LimitString(CheckComma(PPExperience["facility_license_number"].ToString()), 20);
                                                    //    lmu_prof.FacilityName = CheckComma(PPExperience["work_name_en"].ToString());
                                                    //    lmu_prof.Location = LimitString(CheckComma(PPExperience["work_location_city_desc_en"].ToString()), 255);
                                                    //}
                                                }
                                                else
                                                {
                                                    lmu_prof.FacilityLicense = LimitString(CheckComma(PPExperience["facility_license_number"].ToString()), 20);
                                                    lmu_prof.FacilityName = CheckComma(PPExperience["work_name_en"].ToString());
                                                    lmu_prof.Location = LimitString(CheckComma(PPExperience["work_location_city_desc_en"].ToString()), 255);
                                                }
                                            }

                                            //lmu_prof.FacilityLicense = LimitString(CheckComma(PPExperience_Array[0]["facility_license_number"].ToString()), 20);
                                            //lmu_prof.FacilityName = CheckComma(PPExperience_Array[0]["work_name_en"].ToString());
                                            //lmu_prof.Location = LimitString(CheckComma(PPExperience_Array[0]["work_location_city_desc_en"].ToString()), 255);
                                        }



                                        if (yo["Professionals"][i]["ProfessionalLicense"].HasValues)
                                        {
                                            JArray PPLicense_Array = (JArray)yo["Professionals"][i]["ProfessionalLicense"];
                                            int PPCounter = PPLicense_Array.Count;
                                            int count = 0;
                                            List<string> Expired_List = new List<string>();


                                            foreach (JObject PPLicense in PPLicense_Array)
                                            {
                                                Expired_List.Add(CheckComma(ConvertDate(PPLicense["license_expiry_date"].ToString())));
                                                //if (count < PPCounter)
                                                //{
                                                //    if (PPCounter > 1)
                                                //    {
                                                //        if (PPLicense["license_type_code"].ToString().ToLower() == "ftl")
                                                //        {
                                                //            if (PPLicense["license_status_code"].ToString().ToUpper() == "ACT_LICP" || PPLicense["license_status_code"].ToString().ToUpper() == "ACT_AEX_LICP")
                                                //            {
                                                //                lmu_prof.ActiveFrom = CheckComma(ConvertDate(PPLicense["license_last_renewed_date"].ToString()));
                                                //                //lmu_prof.ActiveTo = CheckComma(ConvertDate(PPLicense["license_expiry_date"].ToString()));
                                                //                Expired_List.Add(CheckComma(ConvertDate(PPLicense["license_expiry_date"].ToString())));
                                                //                lmu_prof.SpecialityDescription = CheckComma(PPLicense["primary_position_speciality_desc_en"].ToString());
                                                //            }
                                                //        }
                                                //    }
                                                //    else
                                                //    {
                                                //        lmu_prof.ActiveFrom = CheckComma(ConvertDate(PPLicense["license_last_renewed_date"].ToString()));
                                                //        //lmu_prof.ActiveTo = CheckComma(ConvertDate(PPLicense["license_expiry_date"].ToString()));
                                                //        Expired_List.Add(CheckComma(ConvertDate(PPLicense["license_expiry_date"].ToString())));
                                                //        lmu_prof.SpecialityDescription = CheckComma(PPLicense["primary_position_speciality_desc_en"].ToString());
                                                //    }
                                                //    count++;
                                                //}
                                            }

                                            lmu_prof.ActiveFrom = CheckComma(ConvertDate(PPLicense_Array[0]["license_last_renewed_date"].ToString()));
                                            lmu_prof.ActiveTo = CheckComma(ConvertDate(GetMaxExpiryDate(Expired_List)));
                                            lmu_prof.SpecialityDescription = CheckComma(PPLicense_Array[0]["primary_position_speciality_desc_en"].ToString());


                                        }

                                        if (yo["Professionals"][i]["ProfessionalPositions"].HasValues)
                                        {
                                            JArray PPPostions_Array = (JArray)yo["Professionals"][i]["ProfessionalPositions"];
                                            int PPCounter = PPPostions_Array.Count;
                                            int count = 0;
                                            bool isprimary_set = false;
                                            bool secondary_set = false;
                                            bool tertiary_set = false;
                                            foreach (JObject PPPositions in PPPostions_Array)
                                            {

                                                if (PPCounter > 1)
                                                {
                                                    if (PPPositions["is_primary"].ToString() == "1")
                                                    {
                                                        lmu_prof.SpecialityId1 = LimitString(CheckComma(PPPositions["eclaim_code"].ToString()), 255);
                                                        isprimary_set = true;
                                                    }

                                                    else if (isprimary_set == false && secondary_set == false)
                                                    {
                                                        lmu_prof.SpecialityId2 = LimitString(CheckComma(PPPositions["eclaim_code"].ToString()), 255);
                                                        secondary_set = true;
                                                    }

                                                    else if (isprimary_set == false && tertiary_set == false && secondary_set == true)
                                                    {
                                                        lmu_prof.SpecialityId3 = LimitString(CheckComma(PPPositions["eclaim_code"].ToString()), 255);
                                                        tertiary_set = true;
                                                    }
                                                    count++;
                                                }

                                                else
                                                {
                                                    lmu_prof.SpecialityId1 = LimitString(CheckComma(PPPositions["eclaim_code"].ToString()), 255);
                                                }
                                            }
                                        }

                                        lmu_prof.Password = "";
                                        lmu_prof.Source = "DHA";
                                        lmu_prof.Type = "HRD";

                                    }
                                    catch (Exception ex)
                                    {
                                        //CustomLog.Info("Inner loop exception at iteration " + i + " Message:" + ex.Message);
                                        Insert_LMU.Append("Inner loop exception at iteration " + i + " Message:" + ex.Message + ex.InnerException);
                                    }

                                    string seperator = ",";
                                    Insert_LMU.Append(

                                            //ConvertDate(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")) + seperator +
                                            //ConvertDate(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")) + seperator +
                                            ApplyClinicianFormula(CheckNull(lmu_prof.ClinicianLicene)) + seperator +
                                            CheckNull(lmu_prof.ClinicianName) + seperator +
                                            CheckNull(lmu_prof.Username) + seperator +
                                            CheckNull(lmu_prof.Password) + seperator +
                                            ApplyFacilityFormula(CheckNull(lmu_prof.FacilityLicense)) + seperator +
                                            CheckNull(lmu_prof.FacilityName) + seperator +
                                            CheckNull(lmu_prof.Location) + seperator +
                                            CheckNull(lmu_prof.ActiveFrom) + seperator +
                                            CheckNull(lmu_prof.ActiveTo) + seperator +
                                            CheckNull(lmu_prof.Active) + seperator +
                                            CheckNull(lmu_prof.Source) + seperator +
                                            CheckNull(lmu_prof.SpecialityId1) + seperator +
                                            CheckNull(lmu_prof.SpecialityDescription) + seperator +
                                            CheckNull(lmu_prof.Gender) + seperator +
                                            CheckNull(lmu_prof.Nationality) + seperator +
                                            CheckNull(lmu_prof.Email) + seperator +
                                            CheckNull(lmu_prof.Phone) + seperator +
                                            CheckNull(lmu_prof.SpecialityId2) + seperator +
                                            CheckNull(lmu_prof.SpecialityId3) + seperator +
                                            CheckNull(lmu_prof.Type) + seperator +
                                            CheckNull(lmu_prof.ClinicianIdOld) +
                                            "\n");


                                    //File.AppendAllText(baseDir + "\\" + filename, Insert_LMU.ToString());
                                    result = Insert_LMU.ToString();
                                }

                            }
                    }
            }
            catch (Exception ex)
            {
                result = "Exception occured in function ParseAsDHCC !!\n" + ex.Message;
            }
            return result ;
        }

        public static string ApplyReverseClinicianFormula(string data)
        {

            data = data.Replace("DHA-P-", "");

            if (data != "NULL" && data != "\\n" && data != string.Empty)
            {
                if (data[0].ToString() == "0")
                {
                    data = "0" + data;
                }
                else
                {
                    data = data;
                }
            }
            return data;
        }
        public static string ApplyClinicianFormula(string data)
        {
            if (data != "NULL" && data != "\\n" && data != string.Empty)
            {
                if (data[0].ToString() == "0")
                {
                    data = "DHA-P-" + data.Substring(1);
                }
                else
                {
                    data = "DHA-P-" + data;
                }
            }
            return data;
        }
        public static string CheckNull(string data)
        {
            string result = string.Empty;
            if (data == null || data == "\n" || data == string.Empty || data == "\\n      " || data == "--")
            {
                result = string.Empty;
            }
            else
            {
                result = data;
            }
            return result;

        }
        public static string ApplyFacilityFormula(string data)
        {
            //if (data[0].ToString() == "0")
            //{
            //    data = "DHA-F-" + data.Substring(1);
            //}
            //else
            //{
            //    data = "DHA-F-" + data;
            //}
            if (data != "NULL" && data != "\\n" && data != string.Empty)
            {
                data = "DHA-F-" + data;
            }


            return data;
        }
        private static string CheckComma(string data)
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
                    if (result.Contains("|"))
                    {
                        result = result.Replace("|", "");
                    }
                    if (result.Contains("\t"))
                    {
                        result = result.Replace("\t", "\\t");
                    }
                    if (result.Contains("\""))
                    {
                        result = result.Replace("\"", "");
                    }

                }
                else
                {
                    result = "NULL";
                }
            }
            else
            {
                result = data;
            }
            return result;
        }
        public string CheckGender(string data)
        {
            string result = string.Empty;
            try
            {
                if (data != null)
                {
                    if (data.ToLower() == "male")
                    {
                        result = "Male";
                    }
                    else if (data.ToLower() == "female")
                    {
                        result = "Female";
                    }
                    else
                    {
                        result = "";
                    }

                }

            }
            catch (Exception ex)
            {
                //Console.Write(ex.Message);
                //CustomLog.Info(ex.Message);
                result = ex.Message;
            }

            return result;
        }
        public int GetMAXList(List<LicenseActive> list_license)
        {
            int chosen = 1;
            DateTime date = new DateTime();

            foreach (var obj in list_license)
            {
                if (date < Convert.ToDateTime(obj.ActiveTo))
                {
                    date = Convert.ToDateTime(obj.ActiveTo);
                    chosen = obj.counter;
                }
            }

            return chosen;
        }
        public string GetMaxExpiryDate(List<string> list)
        {
            string result = string.Empty;
            DateTime date = new DateTime();
            try
            {
                foreach (string dates in list)
                {
                    if (date < Convert.ToDateTime(dates))
                    {
                        date = Convert.ToDateTime(dates);
                        result = date.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public string LimitString(string data, int size)
        {

            try
            {
                if (data.Length > size)
                    data = data.Substring(0, size);
            }
            catch (Exception ex)
            {
                data = "cannot limit this " + data;
            }
            return data;
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
                     ,  "yyyy-MM-dd HH:mm:ss.SSS"
              };

            //Logger.Info("Transforming date " + Rdate);
            string activetoDatedata = string.Empty;
            bool isconverted = false;
            DateTime getDatefromString = DateTime.Now;

            try
            {
                //CustomLog.Info("Converting Date: " + Rdate);
                if (DateTime.TryParseExact(Rdate, formats, new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out getDatefromString))
                {
                    //Logger.Info("Converted '" + Rdate + "' to " + getDatefromString + ".");
                    //CustomLog.Info("Converted Date: " + Rdate + " to date: " + getDatefromString);
                    isconverted = true;
                }
                else
                {
                    //Logger.Info("Unable to convert '" + Rdate + "' to a date.");
                    //CustomLog.Info("Not able to parse date: " + Rdate);
                }

                if (isconverted)
                {
                    activetoDatedata = getDatefromString.ToString("MM/dd/yyyy hh:mm:ss");
                }
                else
                {
                    DateTime tmpDate = DateTime.Now;
                    DateTime dtNeedParsing = DateTime.TryParse(Rdate, out tmpDate) == true ? DateTime.Parse(Rdate) : tmpDate;

                    if (tmpDate == dtNeedParsing)
                    {
                        //Logger.Info(" ~~~~~~~~ not able to parse the date correctly ~~~~~~~~~~~~ ");
                        //CustomLog.Info("Not able to parse date: " + Rdate);
                        activetoDatedata = tmpDate.ToString();
                    }
                    else
                    {
                        activetoDatedata = dtNeedParsing.ToString("MM/dd/yyyy hh:mm:ss");
                    }
                }
                //CustomLog.Info("Final Date: " + activetoDatedata);
                return activetoDatedata;
            }

            catch (Exception ex)
            {
                //CustomLog.Info(ex.Message);
                return null;
            }
        }
        public static string CheckActive(string data)
        {
            string active = string.Empty;

            if (data.ToString() == "0")
                active = "Deactivated";
            if (data.ToString() == "1")
                active = "Active";

            //if (data.ToString() == "0")
            //    active = "FALSE";
            //if (data.ToString() == "1")
            //    active = "TRUE";


            return active;
        }
    }

    public struct LMU_Professional
    {
        public string ClinicianLicene;
        public string ClinicianIdOld;
        public string ClinicianName;
        public string Username;
        public string Password;
        public string FacilityLicense;
        public string FacilityName;
        public string Location;
        public string ActiveFrom;
        public string ActiveTo;
        public string Active;
        public string Source;
        public string SpecialityId1;
        public string SpecialityDescription;
        public string Gender;
        public string Nationality;
        public string Email;
        public string Phone;
        public string SpecialityId2;
        public string SpecialityId3;
        public string Type;
    }

    public struct LicenseActive
    {
        public int counter { get; set; }
        public string ActiveFrom { get; set; }
        public string ActiveTo { get; set; }
        public string SpecialityDesc { get; set; }
    }
}