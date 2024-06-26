﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services_All.DHPO_Archive {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.eClaimLink.ae/", ConfigurationName="DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap")]
    public interface ClaimsAndAuthorizationsArchiveSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eClaimLink.ae/DownloadTransactionFile", ReplyAction="*")]
        Services_All.DHPO_Archive.DownloadTransactionFileResponse DownloadTransactionFile(Services_All.DHPO_Archive.DownloadTransactionFileRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eClaimLink.ae/DownloadTransactionFile", ReplyAction="*")]
        System.Threading.Tasks.Task<Services_All.DHPO_Archive.DownloadTransactionFileResponse> DownloadTransactionFileAsync(Services_All.DHPO_Archive.DownloadTransactionFileRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eClaimLink.ae/SearchTransactions", ReplyAction="*")]
        Services_All.DHPO_Archive.SearchTransactionsResponse SearchTransactions(Services_All.DHPO_Archive.SearchTransactionsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.eClaimLink.ae/SearchTransactions", ReplyAction="*")]
        System.Threading.Tasks.Task<Services_All.DHPO_Archive.SearchTransactionsResponse> SearchTransactionsAsync(Services_All.DHPO_Archive.SearchTransactionsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DownloadTransactionFileRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DownloadTransactionFile", Namespace="http://www.eClaimLink.ae/", Order=0)]
        public Services_All.DHPO_Archive.DownloadTransactionFileRequestBody Body;
        
        public DownloadTransactionFileRequest() {
        }
        
        public DownloadTransactionFileRequest(Services_All.DHPO_Archive.DownloadTransactionFileRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.eClaimLink.ae/")]
    public partial class DownloadTransactionFileRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string login;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string pwd;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string fileId;
        
        public DownloadTransactionFileRequestBody() {
        }
        
        public DownloadTransactionFileRequestBody(string login, string pwd, string fileId) {
            this.login = login;
            this.pwd = pwd;
            this.fileId = fileId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class DownloadTransactionFileResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="DownloadTransactionFileResponse", Namespace="http://www.eClaimLink.ae/", Order=0)]
        public Services_All.DHPO_Archive.DownloadTransactionFileResponseBody Body;
        
        public DownloadTransactionFileResponse() {
        }
        
        public DownloadTransactionFileResponse(Services_All.DHPO_Archive.DownloadTransactionFileResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.eClaimLink.ae/")]
    public partial class DownloadTransactionFileResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int DownloadTransactionFileResult;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string fileName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public byte[] file;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string errorMessage;
        
        public DownloadTransactionFileResponseBody() {
        }
        
        public DownloadTransactionFileResponseBody(int DownloadTransactionFileResult, string fileName, byte[] file, string errorMessage) {
            this.DownloadTransactionFileResult = DownloadTransactionFileResult;
            this.fileName = fileName;
            this.file = file;
            this.errorMessage = errorMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SearchTransactionsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SearchTransactions", Namespace="http://www.eClaimLink.ae/", Order=0)]
        public Services_All.DHPO_Archive.SearchTransactionsRequestBody Body;
        
        public SearchTransactionsRequest() {
        }
        
        public SearchTransactionsRequest(Services_All.DHPO_Archive.SearchTransactionsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.eClaimLink.ae/")]
    public partial class SearchTransactionsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string login;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string pwd;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int direction;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string callerLicense;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string ePartner;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public int transactionID;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public int TransactionStatus;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string transactionFileName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string transactionFromDate;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string transactionToDate;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=10)]
        public int minRecordCount;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=11)]
        public int maxRecordCount;
        
        public SearchTransactionsRequestBody() {
        }
        
        public SearchTransactionsRequestBody(string login, string pwd, int direction, string callerLicense, string ePartner, int transactionID, int TransactionStatus, string transactionFileName, string transactionFromDate, string transactionToDate, int minRecordCount, int maxRecordCount) {
            this.login = login;
            this.pwd = pwd;
            this.direction = direction;
            this.callerLicense = callerLicense;
            this.ePartner = ePartner;
            this.transactionID = transactionID;
            this.TransactionStatus = TransactionStatus;
            this.transactionFileName = transactionFileName;
            this.transactionFromDate = transactionFromDate;
            this.transactionToDate = transactionToDate;
            this.minRecordCount = minRecordCount;
            this.maxRecordCount = maxRecordCount;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SearchTransactionsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SearchTransactionsResponse", Namespace="http://www.eClaimLink.ae/", Order=0)]
        public Services_All.DHPO_Archive.SearchTransactionsResponseBody Body;
        
        public SearchTransactionsResponse() {
        }
        
        public SearchTransactionsResponse(Services_All.DHPO_Archive.SearchTransactionsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.eClaimLink.ae/")]
    public partial class SearchTransactionsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int SearchTransactionsResult;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string foundTransactions;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string errorMessage;
        
        public SearchTransactionsResponseBody() {
        }
        
        public SearchTransactionsResponseBody(int SearchTransactionsResult, string foundTransactions, string errorMessage) {
            this.SearchTransactionsResult = SearchTransactionsResult;
            this.foundTransactions = foundTransactions;
            this.errorMessage = errorMessage;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ClaimsAndAuthorizationsArchiveSoapChannel : Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClaimsAndAuthorizationsArchiveSoapClient : System.ServiceModel.ClientBase<Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap>, Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap {
        
        public ClaimsAndAuthorizationsArchiveSoapClient() {
        }
        
        public ClaimsAndAuthorizationsArchiveSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClaimsAndAuthorizationsArchiveSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClaimsAndAuthorizationsArchiveSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClaimsAndAuthorizationsArchiveSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Services_All.DHPO_Archive.DownloadTransactionFileResponse Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap.DownloadTransactionFile(Services_All.DHPO_Archive.DownloadTransactionFileRequest request) {
            return base.Channel.DownloadTransactionFile(request);
        }
        
        public int DownloadTransactionFile(string login, string pwd, string fileId, out string fileName, out byte[] file, out string errorMessage) {
            Services_All.DHPO_Archive.DownloadTransactionFileRequest inValue = new Services_All.DHPO_Archive.DownloadTransactionFileRequest();
            inValue.Body = new Services_All.DHPO_Archive.DownloadTransactionFileRequestBody();
            inValue.Body.login = login;
            inValue.Body.pwd = pwd;
            inValue.Body.fileId = fileId;
            Services_All.DHPO_Archive.DownloadTransactionFileResponse retVal = ((Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap)(this)).DownloadTransactionFile(inValue);
            fileName = retVal.Body.fileName;
            file = retVal.Body.file;
            errorMessage = retVal.Body.errorMessage;
            return retVal.Body.DownloadTransactionFileResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Services_All.DHPO_Archive.DownloadTransactionFileResponse> Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap.DownloadTransactionFileAsync(Services_All.DHPO_Archive.DownloadTransactionFileRequest request) {
            return base.Channel.DownloadTransactionFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<Services_All.DHPO_Archive.DownloadTransactionFileResponse> DownloadTransactionFileAsync(string login, string pwd, string fileId) {
            Services_All.DHPO_Archive.DownloadTransactionFileRequest inValue = new Services_All.DHPO_Archive.DownloadTransactionFileRequest();
            inValue.Body = new Services_All.DHPO_Archive.DownloadTransactionFileRequestBody();
            inValue.Body.login = login;
            inValue.Body.pwd = pwd;
            inValue.Body.fileId = fileId;
            return ((Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap)(this)).DownloadTransactionFileAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Services_All.DHPO_Archive.SearchTransactionsResponse Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap.SearchTransactions(Services_All.DHPO_Archive.SearchTransactionsRequest request) {
            return base.Channel.SearchTransactions(request);
        }
        
        public int SearchTransactions(string login, string pwd, int direction, string callerLicense, string ePartner, int transactionID, int TransactionStatus, string transactionFileName, string transactionFromDate, string transactionToDate, int minRecordCount, int maxRecordCount, out string foundTransactions, out string errorMessage) {
            Services_All.DHPO_Archive.SearchTransactionsRequest inValue = new Services_All.DHPO_Archive.SearchTransactionsRequest();
            inValue.Body = new Services_All.DHPO_Archive.SearchTransactionsRequestBody();
            inValue.Body.login = login;
            inValue.Body.pwd = pwd;
            inValue.Body.direction = direction;
            inValue.Body.callerLicense = callerLicense;
            inValue.Body.ePartner = ePartner;
            inValue.Body.transactionID = transactionID;
            inValue.Body.TransactionStatus = TransactionStatus;
            inValue.Body.transactionFileName = transactionFileName;
            inValue.Body.transactionFromDate = transactionFromDate;
            inValue.Body.transactionToDate = transactionToDate;
            inValue.Body.minRecordCount = minRecordCount;
            inValue.Body.maxRecordCount = maxRecordCount;
            Services_All.DHPO_Archive.SearchTransactionsResponse retVal = ((Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap)(this)).SearchTransactions(inValue);
            foundTransactions = retVal.Body.foundTransactions;
            errorMessage = retVal.Body.errorMessage;
            return retVal.Body.SearchTransactionsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Services_All.DHPO_Archive.SearchTransactionsResponse> Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap.SearchTransactionsAsync(Services_All.DHPO_Archive.SearchTransactionsRequest request) {
            return base.Channel.SearchTransactionsAsync(request);
        }
        
        public System.Threading.Tasks.Task<Services_All.DHPO_Archive.SearchTransactionsResponse> SearchTransactionsAsync(string login, string pwd, int direction, string callerLicense, string ePartner, int transactionID, int TransactionStatus, string transactionFileName, string transactionFromDate, string transactionToDate, int minRecordCount, int maxRecordCount) {
            Services_All.DHPO_Archive.SearchTransactionsRequest inValue = new Services_All.DHPO_Archive.SearchTransactionsRequest();
            inValue.Body = new Services_All.DHPO_Archive.SearchTransactionsRequestBody();
            inValue.Body.login = login;
            inValue.Body.pwd = pwd;
            inValue.Body.direction = direction;
            inValue.Body.callerLicense = callerLicense;
            inValue.Body.ePartner = ePartner;
            inValue.Body.transactionID = transactionID;
            inValue.Body.TransactionStatus = TransactionStatus;
            inValue.Body.transactionFileName = transactionFileName;
            inValue.Body.transactionFromDate = transactionFromDate;
            inValue.Body.transactionToDate = transactionToDate;
            inValue.Body.minRecordCount = minRecordCount;
            inValue.Body.maxRecordCount = maxRecordCount;
            return ((Services_All.DHPO_Archive.ClaimsAndAuthorizationsArchiveSoap)(this)).SearchTransactionsAsync(inValue);
        }
    }
}
