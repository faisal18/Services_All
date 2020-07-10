using System;
using System.Web;
using System.Xml;

namespace Services_All
{
    public class Validate_Service
    {
        public void validate(string service)
        {

            string ResultMessageRes;
            string errorMessageRes;
            string error = null;

            try
            {
                Result.Instantce.responsecode = null;
                Result.Instantce.uid = null;
                Result.Instantce.ResMessage = null;
                Result.Instantce.errorMessage = null;
                Result.Instantce.exceptionMessage = null;
                

                switch (service)
                {
                    case "clinician":
                        Clinician_Authentication.ClinicianAuthonticationSoapClient obj_clinician = new Clinician_Authentication.ClinicianAuthonticationSoapClient();
                        Result.Instantce.responsecode = obj_clinician.AuthonticateClinician((xml_reader(service, "username")), (xml_reader(service, "password")), (xml_reader(service, "systemusername")), (xml_reader(service, "systempassword")), out ResultMessageRes).ToString();
                        Result.Instantce.ResMessage = ResultMessageRes;
                        if (Result.Instantce.responsecode == "-1")
                        {
                            Result.Instantce.errorMessage = Result.Instantce.responsecode;
                        }
                        
                        break;

                    case "erx":
                        ERX_ValidateTransactions.eRxValidateTransactionSoapClient obj_erx = new ERX_ValidateTransactions.eRxValidateTransactionSoapClient();
                        Result.Instantce.responsecode = obj_erx.GetNewTransactions((xml_reader(service, "login")), (xml_reader(service, "password")), out ResultMessageRes, out errorMessageRes).ToString();
                        Result.Instantce.ResMessage = ResultMessageRes;
                        error = errorMessageRes;
                        
                        if (Result.Instantce.responsecode == "-1" ||  error !="")
                        {
                            error = errorMessageRes;
                            Result.Instantce.errorMessage += Result.Instantce.responsecode + "  " + error;
                        }

                        break;

                    case "dhpo":
                        DHPO_Valid.ValidateTransactionsSoapClient obj_dhpo = new DHPO_Valid.ValidateTransactionsSoapClient();
                        Result.Instantce.responsecode = obj_dhpo.GetNewTransactions((xml_reader(service, "login")), (xml_reader(service, "password")), out ResultMessageRes, out errorMessageRes).ToString();
                        Result.Instantce.ResMessage = ResultMessageRes;
                        error = errorMessageRes;
                        
                        if (Result.Instantce.responsecode == "-1" || error != "")
                        {
                            error = errorMessageRes;
                            Result.Instantce.errorMessage += Result.Instantce.responsecode + "  " + error;
                        }
                        break;

                    case "pbmswitch":
                        PbmS_Dimension.DimensionsPbmWSClient obj_pbmswitch = new PbmS_Dimension.DimensionsPbmWSClient();
                        Result.Instantce.responsecode = obj_pbmswitch.editProviderType((xml_reader(service, "licenseid")), Convert.ToInt32((xml_reader(service, "switchtype"))), (xml_reader(service, "registrationkey"))).value.ToString();
                        
                        Result.Instantce.ResMessage = obj_pbmswitch.editProviderType((xml_reader(service, "licenseid")), Convert.ToInt32((xml_reader(service, "switchtype"))), (xml_reader(service, "registrationkey"))).MSG.ToString();
                        error = obj_pbmswitch.editProviderType((xml_reader(service, "licenseid")), Convert.ToInt32((xml_reader(service, "switchtype"))), (xml_reader(service, "registrationkey"))).errorDetails;
                        
                        if (error != null || Result.Instantce.ResMessage != "")
                        {
                            
                            Result.Instantce.errorMessage += Result.Instantce.ResMessage + "  " + error;
                        }
                        break;

                    case "pbm_member":
                        PbmS_Member.MemberUpdateWSClient obj_pbm_member = new PbmS_Member.MemberUpdateWSClient();
                        Result.Instantce.ResMessage = obj_pbm_member.getMemberDetails(Convert.ToInt32((xml_reader(service, "payerid"))), (xml_reader(service, "memberid")), (xml_reader(service, "authKey"))).MSG.ToString();
                        break;

                    case "pbm_payer":
                        PbmS_Payer.PayerIntegrationWSClient obj_pbm_payer = new PbmS_Payer.PayerIntegrationWSClient();

                        obj_pbm_payer.getNonDownloadedBatchIDs((xml_reader(service, "payerid")), (xml_reader(service, "payerKey")), Convert.ToInt32((xml_reader(service, "transactiontype"))), Convert.ToInt32((xml_reader(service, "region")))).ToString();
                        Result.Instantce.responsecode = obj_pbm_payer.getNonDownloadedBatchIDs((xml_reader(service, "payerid")), (xml_reader(service, "payerKey")), Convert.ToInt32((xml_reader(service, "transactiontype"))), Convert.ToInt32((xml_reader(service, "region")))).Length.ToString();
                        object synch_object = obj_pbm_payer.getNonDownloadedBatchIDs((xml_reader(service, "payerid")), (xml_reader(service, "payerKey")), Convert.ToInt32((xml_reader(service, "transactiontype"))), Convert.ToInt32((xml_reader(service, "region")))).SyncRoot;

                        break;

                    case "lmu":
                        Lmu_DataSynch.DataSyncServiceClient obj_lmu = new Lmu_DataSynch.DataSyncServiceClient();
                        Lmu_DataSynch.authorizationCode tst = new Lmu_DataSynch.authorizationCode();
                        tst.key = (xml_reader(service, "key"));
                        tst.username = (xml_reader(service, "username"));
                        Result.Instantce.responsecode = obj_lmu.currentVersion(tst, (xml_reader(service, "listName"))).success.ToString();
                        Result.Instantce.ResMessage = obj_lmu.currentVersion(tst, (xml_reader(service, "listName"))).version.ToString();
                        error = obj_lmu.currentVersion(tst, (xml_reader(service, "listName"))).msg;
                        
                        if (Result.Instantce.responsecode != "True" || error != null)
                        {
                            Result.Instantce.errorMessage = Result.Instantce.responsecode + "   " + error;
                        }
                        break;

                    case "ceed":
                        Ceed_Dhceg.GatewaySoapClient obj_ceed = new Ceed_Dhceg.GatewaySoapClient();
                        Result.Instantce.ResMessage = obj_ceed.GetCurVersionService((xml_reader(service, "user")), (xml_reader(service, "password")));
                       
                        if (Result.Instantce.ResMessage != "2.0")
                        {
                            Result.Instantce.errorMessage = Result.Instantce.ResMessage;
                        }
                        break;

                    case "member":
                        Member_Registration.MemberRegistrationClient obj_member = new Member_Registration.MemberRegistrationClient();
                        Result.Instantce.responsecode = obj_member.ValidateMemberUID((xml_reader(service, "payerLogin")), (xml_reader(service, "payerPwd")), Convert.ToInt32((xml_reader(service, "gender"))), (xml_reader(service, "dateofBirth")), (xml_reader(service, "nationality")), (xml_reader(service, "passportNumber")), Convert.ToInt32((xml_reader(service, "viaSource")))).Result.ToString();
                        Result.Instantce.uid = obj_member.ValidateMemberUID((xml_reader(service, "payerLogin")), (xml_reader(service, "payerPwd")), Convert.ToInt32((xml_reader(service, "gender"))), (xml_reader(service, "dateofBirth")), (xml_reader(service, "nationality")), (xml_reader(service, "passportNumber")), Convert.ToInt32((xml_reader(service, "viaSource")))).UID;
                        
                        error = obj_member.ValidateMemberUID((xml_reader(service, "payerLogin")), (xml_reader(service, "payerPwd")), Convert.ToInt32((xml_reader(service, "gender"))), (xml_reader(service, "dateofBirth")), (xml_reader(service, "nationality")), (xml_reader(service, "passportNumber")), Convert.ToInt32((xml_reader(service, "viaSource")))).ErrorMessage;
                        
                        if (error != null || Result.Instantce.responsecode != "0")
                        {
                            Result.Instantce.errorMessage = Result.Instantce.responsecode + "   " + Result.Instantce.errorMessage;
                        }
                        break;

                    case "shafafiya":
                        Shafafiya.WebservicesSoapClient obj_shafa = new Shafafiya.WebservicesSoapClient();
                        Result.Instantce.responsecode = obj_shafa.GetNewTransactions((xml_reader(service, "login")), (xml_reader(service, "pwd")), out ResultMessageRes, out errorMessageRes).ToString();
                        Result.Instantce.ResMessage = ResultMessageRes;
                        error = errorMessageRes;
                        
                        if (Result.Instantce.responsecode != "0" || error != "")
                        {
                            Result.Instantce.errorMessage = Result.Instantce.responsecode + "    " + Result.Instantce.errorMessage;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "PayerId/PayerKey is incorrect" || ex.Message == "Batch transaction type is not valid" || ex.Message == "Region Number is not valid!!")
                { Result.Instantce.errorMessage = ex.Message.ToString(); }
                else { Result.Instantce.exceptionMessage = ex.Message.ToString(); }
            }

        }

        private string xml_reader(string service, string entity)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/services_detail.xml"));
            string query = string.Format("//*[@name='{0}']", service);
            return xdoc.SelectSingleNode(query)[entity].InnerText.ToString();
        }
    }

    public class Result
    {
        private static Result instance;
        private Result() { }
        public static Result Instantce
        {
            get
            {
                if (instance == null)
                {
                    instance = new Result();
                }
                return instance;
            }
        }


        private string _responsecode;
        private string _ResMessage;
        private string _errorMessage;
        private string _exceptionMessage;
        private string _uid;

        public string responsecode
        {
            get { return _responsecode; }
            set { _responsecode = value; }
        }
        public string ResMessage
        {
            get { return _ResMessage; }
            set { _ResMessage = value; }
        }
        public string errorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public string exceptionMessage
        {
            get { return _exceptionMessage; }
            set { _exceptionMessage = value; }
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
    }

}