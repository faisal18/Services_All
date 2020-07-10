using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Services_All.Utilities_UI
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        [System.Web.Services.WebMethod]
        public static string GETRANDOM()
        {
            Random yo = new Random();
            return yo.Next(5, 10).ToString();
        }

        [System.Web.Services.WebMethod]
        public static Results[] GetTransactionsCount()
        {
            DataTable dt = ExtraClasses.Monitoring_Transactions.GetTransactionsCount();
            List<Results> list_res = new List<Results>();
            try
            {
                Results res;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        res = new Results();
                        res.TimeStamp = dt.Rows[i]["PBM_Time"].ToString();

                        if (dt.Rows[i]["PBM_Count"] != System.DBNull.Value)
                        {
                            res.PBM_Count = (int)dt.Rows[i]["PBM_Count"];
                        }
                        else
                        {
                            res.PBM_Count = 0;
                        }
                        if (dt.Rows[i]["ERX_Count"] != System.DBNull.Value)
                        {
                            res.ERX_Count = (int)dt.Rows[i]["ERX_Count"];
                        }
                        else
                        {
                            res.ERX_Count = 0;
                        }
                        if (dt.Rows[i]["OIC_Count"] != System.DBNull.Value)
                        {
                            res.OIC_Count = (int)dt.Rows[i]["OIC_Count"];
                        }
                        else
                        {
                            res.OIC_Count = 0;
                        }

                        list_res.Add(res);
                    }
                }
                Results[] ho = list_res.ToArray();
                return ho;
            }
            catch (Exception ex)
            {
                Console.Write("Exception Occured!\n" + ex.Message);
            }

            return null;
        }

        [System.Web.Services.WebMethod]
        public static Status_Results[] GetAppStatuses()
        {
            DataTable dt = ExtraClasses.Monitoring_Transactions.GetAppStatus();
            List<Status_Results> list_res = new List<Status_Results>();
            try
            {
                Status_Results stat_res;
                double[] items = new double[13];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        stat_res = new Status_Results();
                        stat_res.TimeStamp = dt.Rows[i]["ClinicianValidate_Time"].ToString();


                        if (dt.Rows[i]["Claims_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["Claims_Status"].ToString() == "OK")
                            {
                                stat_res.Claims_Count = 1 * 1;
                            }
                            else
                            {
                                stat_res.Claims_Count = -1 * 1;
                            }
                        }
                        else
                        {
                            stat_res.Claims_Count = 0;
                        }

                        if (dt.Rows[i]["Clinician_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["Clinician_Status"].ToString() == "OK")
                            {
                                stat_res.Clinician_Count = 1 * 2;
                            }
                            else
                            {
                                stat_res.Clinician_Count = -1 * 2;
                            }
                        }
                        else
                        {
                            stat_res.Clinician_Count = 0;
                        }

                        if (dt.Rows[i]["ClinicianValidate_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["ClinicianValidate_Status"].ToString() == "OK")
                            {
                                stat_res.Clinician_Validate_Count = 1 * 3;
                            }
                            else
                            {
                                stat_res.Clinician_Validate_Count = -1 * 3;
                            }
                        }
                        else
                        {
                            stat_res.Clinician_Validate_Count = 0;
                        }

                        if (dt.Rows[i]["DHPOValidate_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["DHPOValidate_Status"].ToString() == "OK")
                            {
                                stat_res.DHPO_Validate_Count = 1 * 4;
                            }
                            else
                            {
                                stat_res.DHPO_Validate_Count = -1 * 4;
                            }
                        }
                        else
                        {
                            stat_res.DHPO_Validate_Count = 0;
                        }

                        if (dt.Rows[i]["Eauthorization_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["Eauthorization_Status"].ToString() == "OK")
                            {
                                stat_res.Eauthorization_Count = 1 * 5;
                            }
                            else
                            {
                                stat_res.Eauthorization_Count = -1 * 5;
                            }
                        }
                        else
                        {
                            stat_res.Eauthorization_Count = 0;
                        }

                        if (dt.Rows[i]["ERXValidate_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["ERXValidate_Status"].ToString() == "OK")
                            {
                                stat_res.ERX_Validate_Count = 1 * 6;
                            }
                            else
                            {
                                stat_res.ERX_Validate_Count = -1 * 6;
                            }
                        }
                        else
                        {
                            stat_res.ERX_Validate_Count = 0;
                        }

                        if (dt.Rows[i]["ERXPharmacy_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["ERXPharmacy_Status"].ToString() == "OK")
                            {
                                stat_res.ERX_Pharmacy_Count = 1 * 7;
                            }
                            else
                            {
                                stat_res.ERX_Pharmacy_Count = -1 * 7;
                            }
                        }
                        else
                        {
                            stat_res.ERX_Pharmacy_Count = 0;
                        }

                        if (dt.Rows[i]["LMUValidate_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["LMUValidate_Status"].ToString() == "OK")
                            {
                                stat_res.LMU_Validate_Count = 1 * 8;
                            }
                            else
                            {
                                stat_res.LMU_Validate_Count = -1 * 8;
                            }
                        }
                        else
                        {
                            stat_res.LMU_Validate_Count = 0;
                        }

                        if (dt.Rows[i]["MemberRegistration_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["MemberRegistration_Status"].ToString() == "OK")
                            {
                                stat_res.Member_Registration_Count = 1 * 9;
                            }
                            else
                            {
                                stat_res.Member_Registration_Count = -1 * 9;
                            }
                        }
                        else
                        {
                            stat_res.Member_Registration_Count = 0;
                        }

                        if (dt.Rows[i]["PBMLink_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["PBMLink_Status"].ToString() == "OK")
                            {
                                stat_res.PBMLINK_Count = 1 * 10;
                            }
                            else
                            {
                                stat_res.PBMLINK_Count = -1 * 10;
                            }
                        }
                        else
                        {
                            stat_res.PBMLINK_Count = 0;
                        }

                        if (dt.Rows[i]["PBMSwitchDimensions_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["PBMSwitchDimensions_Status"].ToString() == "OK")
                            {
                                stat_res.PBMSwitch_Dimensions_Count = 1 * 11;
                            }
                            else
                            {
                                stat_res.PBMSwitch_Dimensions_Count = -1 * 11;
                            }
                        }
                        else
                        {
                            stat_res.PBMSwitch_Dimensions_Count = 0;
                        }

                        if (dt.Rows[i]["PBMSwitchPayer_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["PBMSwitchPayer_Status"].ToString() == "OK")
                            {
                                stat_res.PBMSwitch_Pyaer_Count = 1 * 12;
                            }
                            else
                            {
                                stat_res.PBMSwitch_Pyaer_Count = -1 * 12;
                            }
                        }
                        else
                        {
                            stat_res.PBMSwitch_Pyaer_Count = 0;
                        }

                        if (dt.Rows[i]["ShafafiyaValidate_Status"] != DBNull.Value)
                        {
                            if (dt.Rows[i]["ShafafiyaValidate_Status"].ToString() == "OK")
                            {
                                stat_res.Shafafiya_Validate_Count = 1 * 13;
                            }
                            else
                            {
                                stat_res.Shafafiya_Validate_Count = -1 * 13;
                            }
                        }
                        else
                        {
                            stat_res.Shafafiya_Validate_Count = 0;
                        }
                        list_res.Add(stat_res);
                    }
                }

                Status_Results[] stat_dt = list_res.ToArray();
                return stat_dt;
            }
            catch (Exception ex)
            {
                Console.Write("Exception Occured!\n" + ex.Message);
            }
            return null;
        }
        
        //[System.Web.Services.WebMethod]
        //public static int GETPBM2COUNT()
        //{
        //   return ExtraClasses.Monitoring_Transactions.getcount();
        //}

        [System.Web.Services.WebMethod]
        public static Bar_PBMERX_Result[] GetPBMERXCount()
        {
            DataTable dt = ExtraClasses.Monitoring_Transactions.GetPBMERXCount();
            List<Bar_PBMERX_Result> list_pbmErx = new List<Bar_PBMERX_Result>();
            try
            {
                Bar_PBMERX_Result bar_res;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bar_res = new Bar_PBMERX_Result();

                        bar_res.ERX_Total_Count = (int)dt.Rows[i]["ERX_TOTAL"];
                        bar_res.ERX_Total_Processed_Count = (int)dt.Rows[i]["ERX_PROCESSED"];
                        bar_res.ERX_Total_OurPayer_Count = (int)dt.Rows[i]["ERX_PAYER"];

                        bar_res.PBM_Total_Count = (int)dt.Rows[i]["PBMLink_TOTAL"];
                        bar_res.PBM_Total_Processed_Count = (int)dt.Rows[i]["PBMLink_PROCESSED"];
                        bar_res.PBM_Total_OurPayer_Count = (int)dt.Rows[i]["PBMLink_PAYER"];

                        list_pbmErx.Add(bar_res);
                    }
                }
                Bar_PBMERX_Result[] bar = list_pbmErx.ToArray();
                return bar;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        [System.Web.Services.WebMethod]
        public static Bar_DHPO_Result[] GetDHPOCount()
        {
            
            try
            {
                //Task<DataTable> task = new Task<DataTable>(ExtraClasses.Monitoring_Transactions.GetDHPOCount);
                //task.Start();
                //DataTable dt = await task;




                //DataTable dt = await Task.FromResul(ExtraClasses.Monitoring_Transactions.GetDHPOCount());


                DataTable dt = ExtraClasses.Monitoring_Transactions.GetDHPOCount();

                List<Bar_DHPO_Result> list_DHPO = new List<Bar_DHPO_Result>();
                Bar_DHPO_Result obj_DHPO;
                if(dt.Rows.Count>0)
                {
                    obj_DHPO = new Bar_DHPO_Result();
                    obj_DHPO.DHPO_Total_CS = (int)dt.Rows[0]["DHPO_Total_CS"];
                    obj_DHPO.DHPO_CS_Downloaded = (int)dt.Rows[0]["DHPO_CS_Downloaded"];
                    obj_DHPO.DHPO_CS_NotDownloaded = (int)dt.Rows[0]["DHPO_CS_NotDownloaded"];

                    obj_DHPO.DHPO_Total_PA = (int)dt.Rows[0]["DHPO_Total_PA"];
                    obj_DHPO.DHPO_PA_Downloaded = (int)dt.Rows[0]["DHPO_PA_Downloaded"];
                    obj_DHPO.DHPO_PA_NotDownloaded = (int)dt.Rows[0]["DHPO_PA_NotDownloaded"];

                    obj_DHPO.DHPO_Total_PR = (int)dt.Rows[0]["DHPO_Total_PR"];
                    obj_DHPO.DHPO_PR_Downloaded = (int)dt.Rows[0]["DHPO_PR_Downloaded"];
                    obj_DHPO.DHPO_PR_NotDownloaded = (int)dt.Rows[0]["DHPO_PR_NotDownloaded"];

                    list_DHPO.Add(obj_DHPO);
                }
                Bar_DHPO_Result[] barDHPO = list_DHPO.ToArray();
                return barDHPO;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }
    }

    public class Results
    {
        public string TimeStamp { get; set; }
        public int PBM_Count { get; set; }
        public int ERX_Count { get; set; }
        public int OIC_Count { get; set; }
    }

    public class Status_Results
    {
        public string TimeStamp { get; set; }
        public double Claims_Count { get; set; }
        public double Clinician_Validate_Count { get; set; }
        public double Clinician_Count { get; set; }
        public double DHPO_Validate_Count { get; set; }
        public double Eauthorization_Count { get; set; }
        public double ERX_Validate_Count { get; set; }
        public double ERX_Pharmacy_Count { get; set; }
        public double LMU_Validate_Count { get; set; }
        public double Member_Registration_Count { get; set;}
        public double PBMLINK_Count { get; set; }
        public double PBMSwitch_Dimensions_Count { get; set;}
        public double PBMSwitch_Pyaer_Count { get; set; }
        public double Shafafiya_Validate_Count { get; set; }
    }

    public class Bar_PBMERX_Result
    {
        //public string System_Name { get; set; }
        public int ERX_Total_Count { get; set; }
        public int ERX_Total_Processed_Count { get; set; }
        public int ERX_Total_OurPayer_Count { get; set; }
        public int PBM_Total_Count { get; set; }
        public int PBM_Total_Processed_Count { get; set; }
        public int PBM_Total_OurPayer_Count { get; set; }
    }

    public class Bar_DHPO_Result
    {
        public int DHPO_Total_CS { get; set; }
        public int DHPO_CS_Downloaded { get; set; }
        public int DHPO_CS_NotDownloaded { get; set; }

        public int DHPO_Total_PA { get; set; }
        public int DHPO_PA_Downloaded { get; set; }
        public int DHPO_PA_NotDownloaded { get; set; }

        public int DHPO_Total_PR { get; set; }
        public int DHPO_PR_Downloaded { get; set; }
        public int DHPO_PR_NotDownloaded { get; set; }
    }


}