﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services_All.Member_Registration {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UploadResponse", Namespace="http://schemas.datacontract.org/2004/07/MemberRegistration")]
    [System.SerializableAttribute()]
    public partial class UploadResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ResultField;
        
        private string FileIdField;
        
        private string ErrorMessageField;
        
        private byte[] ErrorReportField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public string FileId {
            get {
                return this.FileIdField;
            }
            set {
                if ((object.ReferenceEquals(this.FileIdField, value) != true)) {
                    this.FileIdField = value;
                    this.RaisePropertyChanged("FileId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public byte[] ErrorReport {
            get {
                return this.ErrorReportField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorReportField, value) != true)) {
                    this.ErrorReportField = value;
                    this.RaisePropertyChanged("ErrorReport");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ValidateMemberResponse", Namespace="http://schemas.datacontract.org/2004/07/MemberRegistration")]
    [System.SerializableAttribute()]
    public partial class ValidateMemberResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ResultField;
        
        private string UIDField;
        
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string UID {
            get {
                return this.UIDField;
            }
            set {
                if ((object.ReferenceEquals(this.UIDField, value) != true)) {
                    this.UIDField = value;
                    this.RaisePropertyChanged("UID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MemberInsuranceResponse", Namespace="http://schemas.datacontract.org/2004/07/MemberRegistration")]
    [System.SerializableAttribute()]
    public partial class MemberInsuranceResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ResultField;
        
        private string memberInformationField;
        
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string memberInformation {
            get {
                return this.memberInformationField;
            }
            set {
                if ((object.ReferenceEquals(this.memberInformationField, value) != true)) {
                    this.memberInformationField = value;
                    this.RaisePropertyChanged("memberInformation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DownloadResponse", Namespace="http://schemas.datacontract.org/2004/07/MemberRegistration")]
    [System.SerializableAttribute()]
    public partial class DownloadResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ResultField;
        
        private string ErrorMessageField;
        
        private byte[] FileContnetField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public byte[] FileContnet {
            get {
                return this.FileContnetField;
            }
            set {
                if ((object.ReferenceEquals(this.FileContnetField, value) != true)) {
                    this.FileContnetField = value;
                    this.RaisePropertyChanged("FileContnet");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DownloadReportResponse", Namespace="http://schemas.datacontract.org/2004/07/MemberRegistration")]
    [System.SerializableAttribute()]
    public partial class DownloadReportResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ResultField;
        
        private string ErrorMessageField;
        
        private string ReportContentField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string ReportContent {
            get {
                return this.ReportContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ReportContentField, value) != true)) {
                    this.ReportContentField = value;
                    this.RaisePropertyChanged("ReportContent");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Member_Registration.IMemberRegistration")]
    public interface IMemberRegistration {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/UploadMemberRegistration", ReplyAction="http://tempuri.org/IMemberRegistration/UploadMemberRegistrationResponse")]
        Services_All.Member_Registration.UploadResponse UploadMemberRegistration(string login, string pwd, byte[] fileContent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/UploadMemberRegistration", ReplyAction="http://tempuri.org/IMemberRegistration/UploadMemberRegistrationResponse")]
        System.Threading.Tasks.Task<Services_All.Member_Registration.UploadResponse> UploadMemberRegistrationAsync(string login, string pwd, byte[] fileContent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/UploadBulkMemberRegistration", ReplyAction="http://tempuri.org/IMemberRegistration/UploadBulkMemberRegistrationResponse")]
        Services_All.Member_Registration.UploadResponse UploadBulkMemberRegistration(string login, string pwd, byte[] fileContent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/UploadBulkMemberRegistration", ReplyAction="http://tempuri.org/IMemberRegistration/UploadBulkMemberRegistrationResponse")]
        System.Threading.Tasks.Task<Services_All.Member_Registration.UploadResponse> UploadBulkMemberRegistrationAsync(string login, string pwd, byte[] fileContent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/ValidateMemberUID", ReplyAction="http://tempuri.org/IMemberRegistration/ValidateMemberUIDResponse")]
        Services_All.Member_Registration.ValidateMemberResponse ValidateMemberUID(string payerLogin, string payerPwd, int gender, string dateOfBirth, string nationality, string passportNumber, int visaSource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/ValidateMemberUID", ReplyAction="http://tempuri.org/IMemberRegistration/ValidateMemberUIDResponse")]
        System.Threading.Tasks.Task<Services_All.Member_Registration.ValidateMemberResponse> ValidateMemberUIDAsync(string payerLogin, string payerPwd, int gender, string dateOfBirth, string nationality, string passportNumber, int visaSource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/GetMemberInsuranceInformation", ReplyAction="http://tempuri.org/IMemberRegistration/GetMemberInsuranceInformationResponse")]
        Services_All.Member_Registration.MemberInsuranceResponse GetMemberInsuranceInformation(string login, string pwd, string UID, string dateOfBirth, int gender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/GetMemberInsuranceInformation", ReplyAction="http://tempuri.org/IMemberRegistration/GetMemberInsuranceInformationResponse")]
        System.Threading.Tasks.Task<Services_All.Member_Registration.MemberInsuranceResponse> GetMemberInsuranceInformationAsync(string login, string pwd, string UID, string dateOfBirth, int gender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/DownloadTransactionFile", ReplyAction="http://tempuri.org/IMemberRegistration/DownloadTransactionFileResponse")]
        Services_All.Member_Registration.DownloadResponse DownloadTransactionFile(string login, string pwd, string fileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/DownloadTransactionFile", ReplyAction="http://tempuri.org/IMemberRegistration/DownloadTransactionFileResponse")]
        System.Threading.Tasks.Task<Services_All.Member_Registration.DownloadResponse> DownloadTransactionFileAsync(string login, string pwd, string fileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/DownloadReport", ReplyAction="http://tempuri.org/IMemberRegistration/DownloadReportResponse")]
        Services_All.Member_Registration.DownloadReportResponse DownloadReport(string login, string pwd, string fileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberRegistration/DownloadReport", ReplyAction="http://tempuri.org/IMemberRegistration/DownloadReportResponse")]
        System.Threading.Tasks.Task<Services_All.Member_Registration.DownloadReportResponse> DownloadReportAsync(string login, string pwd, string fileId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMemberRegistrationChannel : Services_All.Member_Registration.IMemberRegistration, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MemberRegistrationClient : System.ServiceModel.ClientBase<Services_All.Member_Registration.IMemberRegistration>, Services_All.Member_Registration.IMemberRegistration {
        
        public MemberRegistrationClient() {
        }
        
        public MemberRegistrationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MemberRegistrationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MemberRegistrationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MemberRegistrationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Services_All.Member_Registration.UploadResponse UploadMemberRegistration(string login, string pwd, byte[] fileContent) {
            return base.Channel.UploadMemberRegistration(login, pwd, fileContent);
        }
        
        public System.Threading.Tasks.Task<Services_All.Member_Registration.UploadResponse> UploadMemberRegistrationAsync(string login, string pwd, byte[] fileContent) {
            return base.Channel.UploadMemberRegistrationAsync(login, pwd, fileContent);
        }
        
        public Services_All.Member_Registration.UploadResponse UploadBulkMemberRegistration(string login, string pwd, byte[] fileContent) {
            return base.Channel.UploadBulkMemberRegistration(login, pwd, fileContent);
        }
        
        public System.Threading.Tasks.Task<Services_All.Member_Registration.UploadResponse> UploadBulkMemberRegistrationAsync(string login, string pwd, byte[] fileContent) {
            return base.Channel.UploadBulkMemberRegistrationAsync(login, pwd, fileContent);
        }
        
        public Services_All.Member_Registration.ValidateMemberResponse ValidateMemberUID(string payerLogin, string payerPwd, int gender, string dateOfBirth, string nationality, string passportNumber, int visaSource) {
            return base.Channel.ValidateMemberUID(payerLogin, payerPwd, gender, dateOfBirth, nationality, passportNumber, visaSource);
        }
        
        public System.Threading.Tasks.Task<Services_All.Member_Registration.ValidateMemberResponse> ValidateMemberUIDAsync(string payerLogin, string payerPwd, int gender, string dateOfBirth, string nationality, string passportNumber, int visaSource) {
            return base.Channel.ValidateMemberUIDAsync(payerLogin, payerPwd, gender, dateOfBirth, nationality, passportNumber, visaSource);
        }
        
        public Services_All.Member_Registration.MemberInsuranceResponse GetMemberInsuranceInformation(string login, string pwd, string UID, string dateOfBirth, int gender) {
            return base.Channel.GetMemberInsuranceInformation(login, pwd, UID, dateOfBirth, gender);
        }
        
        public System.Threading.Tasks.Task<Services_All.Member_Registration.MemberInsuranceResponse> GetMemberInsuranceInformationAsync(string login, string pwd, string UID, string dateOfBirth, int gender) {
            return base.Channel.GetMemberInsuranceInformationAsync(login, pwd, UID, dateOfBirth, gender);
        }
        
        public Services_All.Member_Registration.DownloadResponse DownloadTransactionFile(string login, string pwd, string fileId) {
            return base.Channel.DownloadTransactionFile(login, pwd, fileId);
        }
        
        public System.Threading.Tasks.Task<Services_All.Member_Registration.DownloadResponse> DownloadTransactionFileAsync(string login, string pwd, string fileId) {
            return base.Channel.DownloadTransactionFileAsync(login, pwd, fileId);
        }
        
        public Services_All.Member_Registration.DownloadReportResponse DownloadReport(string login, string pwd, string fileId) {
            return base.Channel.DownloadReport(login, pwd, fileId);
        }
        
        public System.Threading.Tasks.Task<Services_All.Member_Registration.DownloadReportResponse> DownloadReportAsync(string login, string pwd, string fileId) {
            return base.Channel.DownloadReportAsync(login, pwd, fileId);
        }
    }
}