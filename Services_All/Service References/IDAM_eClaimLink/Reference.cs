﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services_All.IDAM_eClaimLink {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseWCF", Namespace="http://schemas.datacontract.org/2004/07/IntegrationService.Entities")]
    [System.SerializableAttribute()]
    public partial class ResponseWCF : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Services_All.IDAM_eClaimLink.Facility[] FacilitiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Services_All.IDAM_eClaimLink.Professional[] ProfessionalsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResultMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long ResultValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Services_All.IDAM_eClaimLink.Facility[] Facilities {
            get {
                return this.FacilitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.FacilitiesField, value) != true)) {
                    this.FacilitiesField = value;
                    this.RaisePropertyChanged("Facilities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Services_All.IDAM_eClaimLink.Professional[] Professionals {
            get {
                return this.ProfessionalsField;
            }
            set {
                if ((object.ReferenceEquals(this.ProfessionalsField, value) != true)) {
                    this.ProfessionalsField = value;
                    this.RaisePropertyChanged("Professionals");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResultMessage {
            get {
                return this.ResultMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultMessageField, value) != true)) {
                    this.ResultMessageField = value;
                    this.RaisePropertyChanged("ResultMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ResultValue {
            get {
                return this.ResultValueField;
            }
            set {
                if ((this.ResultValueField.Equals(value) != true)) {
                    this.ResultValueField = value;
                    this.RaisePropertyChanged("ResultValue");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Facility", Namespace="http://schemas.datacontract.org/2004/07/IntegrationService.Entities")]
    [System.SerializableAttribute()]
    public partial class Facility : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AreaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrentLicenseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FacilityNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FacilitySubCategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LicenseFromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LicenseStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LicenseToField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Phone1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Phone2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PreviousLicensesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid RowIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UniqueIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Area {
            get {
                return this.AreaField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaField, value) != true)) {
                    this.AreaField = value;
                    this.RaisePropertyChanged("Area");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CurrentLicense {
            get {
                return this.CurrentLicenseField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrentLicenseField, value) != true)) {
                    this.CurrentLicenseField = value;
                    this.RaisePropertyChanged("CurrentLicense");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FacilityName {
            get {
                return this.FacilityNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FacilityNameField, value) != true)) {
                    this.FacilityNameField = value;
                    this.RaisePropertyChanged("FacilityName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FacilitySubCategory {
            get {
                return this.FacilitySubCategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.FacilitySubCategoryField, value) != true)) {
                    this.FacilitySubCategoryField = value;
                    this.RaisePropertyChanged("FacilitySubCategory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LicenseFrom {
            get {
                return this.LicenseFromField;
            }
            set {
                if ((this.LicenseFromField.Equals(value) != true)) {
                    this.LicenseFromField = value;
                    this.RaisePropertyChanged("LicenseFrom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LicenseStatus {
            get {
                return this.LicenseStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.LicenseStatusField, value) != true)) {
                    this.LicenseStatusField = value;
                    this.RaisePropertyChanged("LicenseStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LicenseTo {
            get {
                return this.LicenseToField;
            }
            set {
                if ((this.LicenseToField.Equals(value) != true)) {
                    this.LicenseToField = value;
                    this.RaisePropertyChanged("LicenseTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone1 {
            get {
                return this.Phone1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Phone1Field, value) != true)) {
                    this.Phone1Field = value;
                    this.RaisePropertyChanged("Phone1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone2 {
            get {
                return this.Phone2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Phone2Field, value) != true)) {
                    this.Phone2Field = value;
                    this.RaisePropertyChanged("Phone2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PreviousLicenses {
            get {
                return this.PreviousLicensesField;
            }
            set {
                if ((object.ReferenceEquals(this.PreviousLicensesField, value) != true)) {
                    this.PreviousLicensesField = value;
                    this.RaisePropertyChanged("PreviousLicenses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid RowId {
            get {
                return this.RowIdField;
            }
            set {
                if ((this.RowIdField.Equals(value) != true)) {
                    this.RowIdField = value;
                    this.RaisePropertyChanged("RowId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UniqueID {
            get {
                return this.UniqueIDField;
            }
            set {
                if ((object.ReferenceEquals(this.UniqueIDField, value) != true)) {
                    this.UniqueIDField = value;
                    this.RaisePropertyChanged("UniqueID");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Professional", Namespace="http://schemas.datacontract.org/2004/07/IntegrationService.Entities")]
    [System.SerializableAttribute()]
    public partial class Professional : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AreaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LicenseFromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LicenseNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LicenseStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LicenseToField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MainFacilityNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MainFacilityUniqueIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParttimeFacility1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParttimeFacility1LicenseStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParttimeFacility2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParttimeFacility2LicenseStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParttimeFacility3Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParttimeFacility3LicenseStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParttimeFacility4Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParttimeFacility4LicenseStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PreviousLicensesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProfessionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProfessionalNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid RowIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UniqueIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Area {
            get {
                return this.AreaField;
            }
            set {
                if ((object.ReferenceEquals(this.AreaField, value) != true)) {
                    this.AreaField = value;
                    this.RaisePropertyChanged("Area");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LicenseFrom {
            get {
                return this.LicenseFromField;
            }
            set {
                if ((this.LicenseFromField.Equals(value) != true)) {
                    this.LicenseFromField = value;
                    this.RaisePropertyChanged("LicenseFrom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LicenseNo {
            get {
                return this.LicenseNoField;
            }
            set {
                if ((object.ReferenceEquals(this.LicenseNoField, value) != true)) {
                    this.LicenseNoField = value;
                    this.RaisePropertyChanged("LicenseNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LicenseStatus {
            get {
                return this.LicenseStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.LicenseStatusField, value) != true)) {
                    this.LicenseStatusField = value;
                    this.RaisePropertyChanged("LicenseStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LicenseTo {
            get {
                return this.LicenseToField;
            }
            set {
                if ((this.LicenseToField.Equals(value) != true)) {
                    this.LicenseToField = value;
                    this.RaisePropertyChanged("LicenseTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MainFacilityName {
            get {
                return this.MainFacilityNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MainFacilityNameField, value) != true)) {
                    this.MainFacilityNameField = value;
                    this.RaisePropertyChanged("MainFacilityName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MainFacilityUniqueID {
            get {
                return this.MainFacilityUniqueIDField;
            }
            set {
                if ((object.ReferenceEquals(this.MainFacilityUniqueIDField, value) != true)) {
                    this.MainFacilityUniqueIDField = value;
                    this.RaisePropertyChanged("MainFacilityUniqueID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParttimeFacility1 {
            get {
                return this.ParttimeFacility1Field;
            }
            set {
                if ((object.ReferenceEquals(this.ParttimeFacility1Field, value) != true)) {
                    this.ParttimeFacility1Field = value;
                    this.RaisePropertyChanged("ParttimeFacility1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParttimeFacility1LicenseStatus {
            get {
                return this.ParttimeFacility1LicenseStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.ParttimeFacility1LicenseStatusField, value) != true)) {
                    this.ParttimeFacility1LicenseStatusField = value;
                    this.RaisePropertyChanged("ParttimeFacility1LicenseStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParttimeFacility2 {
            get {
                return this.ParttimeFacility2Field;
            }
            set {
                if ((object.ReferenceEquals(this.ParttimeFacility2Field, value) != true)) {
                    this.ParttimeFacility2Field = value;
                    this.RaisePropertyChanged("ParttimeFacility2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParttimeFacility2LicenseStatus {
            get {
                return this.ParttimeFacility2LicenseStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.ParttimeFacility2LicenseStatusField, value) != true)) {
                    this.ParttimeFacility2LicenseStatusField = value;
                    this.RaisePropertyChanged("ParttimeFacility2LicenseStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParttimeFacility3 {
            get {
                return this.ParttimeFacility3Field;
            }
            set {
                if ((object.ReferenceEquals(this.ParttimeFacility3Field, value) != true)) {
                    this.ParttimeFacility3Field = value;
                    this.RaisePropertyChanged("ParttimeFacility3");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParttimeFacility3LicenseStatus {
            get {
                return this.ParttimeFacility3LicenseStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.ParttimeFacility3LicenseStatusField, value) != true)) {
                    this.ParttimeFacility3LicenseStatusField = value;
                    this.RaisePropertyChanged("ParttimeFacility3LicenseStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParttimeFacility4 {
            get {
                return this.ParttimeFacility4Field;
            }
            set {
                if ((object.ReferenceEquals(this.ParttimeFacility4Field, value) != true)) {
                    this.ParttimeFacility4Field = value;
                    this.RaisePropertyChanged("ParttimeFacility4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParttimeFacility4LicenseStatus {
            get {
                return this.ParttimeFacility4LicenseStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.ParttimeFacility4LicenseStatusField, value) != true)) {
                    this.ParttimeFacility4LicenseStatusField = value;
                    this.RaisePropertyChanged("ParttimeFacility4LicenseStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PreviousLicenses {
            get {
                return this.PreviousLicensesField;
            }
            set {
                if ((object.ReferenceEquals(this.PreviousLicensesField, value) != true)) {
                    this.PreviousLicensesField = value;
                    this.RaisePropertyChanged("PreviousLicenses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Profession {
            get {
                return this.ProfessionField;
            }
            set {
                if ((object.ReferenceEquals(this.ProfessionField, value) != true)) {
                    this.ProfessionField = value;
                    this.RaisePropertyChanged("Profession");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProfessionalName {
            get {
                return this.ProfessionalNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProfessionalNameField, value) != true)) {
                    this.ProfessionalNameField = value;
                    this.RaisePropertyChanged("ProfessionalName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid RowId {
            get {
                return this.RowIdField;
            }
            set {
                if ((this.RowIdField.Equals(value) != true)) {
                    this.RowIdField = value;
                    this.RaisePropertyChanged("RowId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UniqueID {
            get {
                return this.UniqueIDField;
            }
            set {
                if ((object.ReferenceEquals(this.UniqueIDField, value) != true)) {
                    this.UniqueIDField = value;
                    this.RaisePropertyChanged("UniqueID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IDAM_eClaimLink.IeClaimLink")]
    public interface IeClaimLink {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/GetNewClinicians", ReplyAction="http://tempuri.org/IeClaimLink/GetNewCliniciansResponse")]
        Services_All.IDAM_eClaimLink.ResponseWCF GetNewClinicians(string fromDateString, string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/GetNewClinicians", ReplyAction="http://tempuri.org/IeClaimLink/GetNewCliniciansResponse")]
        System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> GetNewCliniciansAsync(string fromDateString, string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/AuthenticateClinician", ReplyAction="http://tempuri.org/IeClaimLink/AuthenticateClinicianResponse")]
        Services_All.IDAM_eClaimLink.ResponseWCF AuthenticateClinician(string clinicianUserName, string clinicianpassword, string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/AuthenticateClinician", ReplyAction="http://tempuri.org/IeClaimLink/AuthenticateClinicianResponse")]
        System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> AuthenticateClinicianAsync(string clinicianUserName, string clinicianpassword, string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/GetNewCliniciansNew", ReplyAction="http://tempuri.org/IeClaimLink/GetNewCliniciansNewResponse")]
        Services_All.IDAM_eClaimLink.ResponseWCF GetNewCliniciansNew(string fromDateString, string toDateString, string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/GetNewCliniciansNew", ReplyAction="http://tempuri.org/IeClaimLink/GetNewCliniciansNewResponse")]
        System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> GetNewCliniciansNewAsync(string fromDateString, string toDateString, string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/AuthenticateFacility", ReplyAction="http://tempuri.org/IeClaimLink/AuthenticateFacilityResponse")]
        Services_All.IDAM_eClaimLink.ResponseWCF AuthenticateFacility(string userName, string password, string facilityUserName, string facilityPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/AuthenticateFacility", ReplyAction="http://tempuri.org/IeClaimLink/AuthenticateFacilityResponse")]
        System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> AuthenticateFacilityAsync(string userName, string password, string facilityUserName, string facilityPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/GetNewFacility", ReplyAction="http://tempuri.org/IeClaimLink/GetNewFacilityResponse")]
        Services_All.IDAM_eClaimLink.ResponseWCF GetNewFacility(string fromDateString, string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IeClaimLink/GetNewFacility", ReplyAction="http://tempuri.org/IeClaimLink/GetNewFacilityResponse")]
        System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> GetNewFacilityAsync(string fromDateString, string userName, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IeClaimLinkChannel : Services_All.IDAM_eClaimLink.IeClaimLink, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IeClaimLinkClient : System.ServiceModel.ClientBase<Services_All.IDAM_eClaimLink.IeClaimLink>, Services_All.IDAM_eClaimLink.IeClaimLink {
        
        public IeClaimLinkClient() {
        }
        
        public IeClaimLinkClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IeClaimLinkClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IeClaimLinkClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IeClaimLinkClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Services_All.IDAM_eClaimLink.ResponseWCF GetNewClinicians(string fromDateString, string userName, string password) {
            return base.Channel.GetNewClinicians(fromDateString, userName, password);
        }
        
        public System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> GetNewCliniciansAsync(string fromDateString, string userName, string password) {
            return base.Channel.GetNewCliniciansAsync(fromDateString, userName, password);
        }
        
        public Services_All.IDAM_eClaimLink.ResponseWCF AuthenticateClinician(string clinicianUserName, string clinicianpassword, string userName, string password) {
            return base.Channel.AuthenticateClinician(clinicianUserName, clinicianpassword, userName, password);
        }
        
        public System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> AuthenticateClinicianAsync(string clinicianUserName, string clinicianpassword, string userName, string password) {
            return base.Channel.AuthenticateClinicianAsync(clinicianUserName, clinicianpassword, userName, password);
        }
        
        public Services_All.IDAM_eClaimLink.ResponseWCF GetNewCliniciansNew(string fromDateString, string toDateString, string userName, string password) {
            return base.Channel.GetNewCliniciansNew(fromDateString, toDateString, userName, password);
        }
        
        public System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> GetNewCliniciansNewAsync(string fromDateString, string toDateString, string userName, string password) {
            return base.Channel.GetNewCliniciansNewAsync(fromDateString, toDateString, userName, password);
        }
        
        public Services_All.IDAM_eClaimLink.ResponseWCF AuthenticateFacility(string userName, string password, string facilityUserName, string facilityPassword) {
            return base.Channel.AuthenticateFacility(userName, password, facilityUserName, facilityPassword);
        }
        
        public System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> AuthenticateFacilityAsync(string userName, string password, string facilityUserName, string facilityPassword) {
            return base.Channel.AuthenticateFacilityAsync(userName, password, facilityUserName, facilityPassword);
        }
        
        public Services_All.IDAM_eClaimLink.ResponseWCF GetNewFacility(string fromDateString, string userName, string password) {
            return base.Channel.GetNewFacility(fromDateString, userName, password);
        }
        
        public System.Threading.Tasks.Task<Services_All.IDAM_eClaimLink.ResponseWCF> GetNewFacilityAsync(string fromDateString, string userName, string password) {
            return base.Channel.GetNewFacilityAsync(fromDateString, userName, password);
        }
    }
}
