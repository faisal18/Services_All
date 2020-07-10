﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services_All.DHCCHCPService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DHCCHCPService.HCPServiceSoap")]
    public interface HCPServiceSoap {
        
        // CODEGEN: Generating message contract since message GetProfessionalsRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProfessionals", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Services_All.DHCCHCPService.GetProfessionalsResponse GetProfessionals(Services_All.DHCCHCPService.GetProfessionalsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProfessionals", ReplyAction="*")]
        System.Threading.Tasks.Task<Services_All.DHCCHCPService.GetProfessionalsResponse> GetProfessionalsAsync(Services_All.DHCCHCPService.GetProfessionalsRequest request);
        
        // CODEGEN: Generating message contract since message GetFacilitiesRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetFacilities", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Services_All.DHCCHCPService.GetFacilitiesResponse GetFacilities(Services_All.DHCCHCPService.GetFacilitiesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetFacilities", ReplyAction="*")]
        System.Threading.Tasks.Task<Services_All.DHCCHCPService.GetFacilitiesResponse> GetFacilitiesAsync(Services_All.DHCCHCPService.GetFacilitiesRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Authentication : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string secidField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string secid {
            get {
                return this.secidField;
            }
            set {
                this.secidField = value;
                this.RaisePropertyChanged("secid");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Facility : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string telField;
        
        private string faxField;
        
        private string mobileField;
        
        private string emailField;
        
        private string websiteField;
        
        private string licenseStatusField;
        
        private string legalEntityField;
        
        private string jurisdictionField;
        
        private string streetField;
        
        private string cityField;
        
        private string countryField;
        
        private string[] listActivitiesField;
        
        private string facilityTypeField;
        
        private string licenseToField;
        
        private string licenseFromField;
        
        private string facilityLicenseField;
        
        private string facilityNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Tel {
            get {
                return this.telField;
            }
            set {
                this.telField = value;
                this.RaisePropertyChanged("Tel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Fax {
            get {
                return this.faxField;
            }
            set {
                this.faxField = value;
                this.RaisePropertyChanged("Fax");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Mobile {
            get {
                return this.mobileField;
            }
            set {
                this.mobileField = value;
                this.RaisePropertyChanged("Mobile");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("Email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Website {
            get {
                return this.websiteField;
            }
            set {
                this.websiteField = value;
                this.RaisePropertyChanged("Website");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string LicenseStatus {
            get {
                return this.licenseStatusField;
            }
            set {
                this.licenseStatusField = value;
                this.RaisePropertyChanged("LicenseStatus");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string LegalEntity {
            get {
                return this.legalEntityField;
            }
            set {
                this.legalEntityField = value;
                this.RaisePropertyChanged("LegalEntity");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Jurisdiction {
            get {
                return this.jurisdictionField;
            }
            set {
                this.jurisdictionField = value;
                this.RaisePropertyChanged("Jurisdiction");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Street {
            get {
                return this.streetField;
            }
            set {
                this.streetField = value;
                this.RaisePropertyChanged("Street");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
                this.RaisePropertyChanged("City");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
                this.RaisePropertyChanged("Country");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=11)]
        public string[] listActivities {
            get {
                return this.listActivitiesField;
            }
            set {
                this.listActivitiesField = value;
                this.RaisePropertyChanged("listActivities");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string FacilityType {
            get {
                return this.facilityTypeField;
            }
            set {
                this.facilityTypeField = value;
                this.RaisePropertyChanged("FacilityType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string LicenseTo {
            get {
                return this.licenseToField;
            }
            set {
                this.licenseToField = value;
                this.RaisePropertyChanged("LicenseTo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string LicenseFrom {
            get {
                return this.licenseFromField;
            }
            set {
                this.licenseFromField = value;
                this.RaisePropertyChanged("LicenseFrom");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string FacilityLicense {
            get {
                return this.facilityLicenseField;
            }
            set {
                this.facilityLicenseField = value;
                this.RaisePropertyChanged("FacilityLicense");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string FacilityName {
            get {
                return this.facilityNameField;
            }
            set {
                this.facilityNameField = value;
                this.RaisePropertyChanged("FacilityName");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class HCP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string emiratesIDField;
        
        private string passportNumberField;
        
        private string passportIssuingCountryField;
        
        private string licenseField;
        
        private string fullNameField;
        
        private string usernameField;
        
        private string passwordField;
        
        private string emailField;
        
        private string phoneNumberField;
        
        private string qualificationField;
        
        private string facilityLicenseField;
        
        private string facilityNameField;
        
        private Facility[] facilitiesField;
        
        private string locationField;
        
        private string activeFromField;
        
        private string activeToField;
        
        private string isActiveField;
        
        private string sourceField;
        
        private string specialtyID1Field;
        
        private string specialtyDescriptionField;
        
        private string genderField;
        
        private string nationalityField;
        
        private string specialtyID2Field;
        
        private string specialtyID3Field;
        
        private string hCTypeField;
        
        private string dHCCSpecialty1Field;
        
        private string dHCCSpecialty2Field;
        
        private string dHCCSpecialty3Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string EmiratesID {
            get {
                return this.emiratesIDField;
            }
            set {
                this.emiratesIDField = value;
                this.RaisePropertyChanged("EmiratesID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string PassportNumber {
            get {
                return this.passportNumberField;
            }
            set {
                this.passportNumberField = value;
                this.RaisePropertyChanged("PassportNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string PassportIssuingCountry {
            get {
                return this.passportIssuingCountryField;
            }
            set {
                this.passportIssuingCountryField = value;
                this.RaisePropertyChanged("PassportIssuingCountry");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string License {
            get {
                return this.licenseField;
            }
            set {
                this.licenseField = value;
                this.RaisePropertyChanged("License");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string FullName {
            get {
                return this.fullNameField;
            }
            set {
                this.fullNameField = value;
                this.RaisePropertyChanged("FullName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("Email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string PhoneNumber {
            get {
                return this.phoneNumberField;
            }
            set {
                this.phoneNumberField = value;
                this.RaisePropertyChanged("PhoneNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Qualification {
            get {
                return this.qualificationField;
            }
            set {
                this.qualificationField = value;
                this.RaisePropertyChanged("Qualification");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string FacilityLicense {
            get {
                return this.facilityLicenseField;
            }
            set {
                this.facilityLicenseField = value;
                this.RaisePropertyChanged("FacilityLicense");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string FacilityName {
            get {
                return this.facilityNameField;
            }
            set {
                this.facilityNameField = value;
                this.RaisePropertyChanged("FacilityName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=12)]
        public Facility[] facilities {
            get {
                return this.facilitiesField;
            }
            set {
                this.facilitiesField = value;
                this.RaisePropertyChanged("facilities");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string Location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
                this.RaisePropertyChanged("Location");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string ActiveFrom {
            get {
                return this.activeFromField;
            }
            set {
                this.activeFromField = value;
                this.RaisePropertyChanged("ActiveFrom");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string ActiveTo {
            get {
                return this.activeToField;
            }
            set {
                this.activeToField = value;
                this.RaisePropertyChanged("ActiveTo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string IsActive {
            get {
                return this.isActiveField;
            }
            set {
                this.isActiveField = value;
                this.RaisePropertyChanged("IsActive");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string Source {
            get {
                return this.sourceField;
            }
            set {
                this.sourceField = value;
                this.RaisePropertyChanged("Source");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string SpecialtyID1 {
            get {
                return this.specialtyID1Field;
            }
            set {
                this.specialtyID1Field = value;
                this.RaisePropertyChanged("SpecialtyID1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string SpecialtyDescription {
            get {
                return this.specialtyDescriptionField;
            }
            set {
                this.specialtyDescriptionField = value;
                this.RaisePropertyChanged("SpecialtyDescription");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string Gender {
            get {
                return this.genderField;
            }
            set {
                this.genderField = value;
                this.RaisePropertyChanged("Gender");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string Nationality {
            get {
                return this.nationalityField;
            }
            set {
                this.nationalityField = value;
                this.RaisePropertyChanged("Nationality");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string SpecialtyID2 {
            get {
                return this.specialtyID2Field;
            }
            set {
                this.specialtyID2Field = value;
                this.RaisePropertyChanged("SpecialtyID2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string SpecialtyID3 {
            get {
                return this.specialtyID3Field;
            }
            set {
                this.specialtyID3Field = value;
                this.RaisePropertyChanged("SpecialtyID3");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string HCType {
            get {
                return this.hCTypeField;
            }
            set {
                this.hCTypeField = value;
                this.RaisePropertyChanged("HCType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string DHCCSpecialty1 {
            get {
                return this.dHCCSpecialty1Field;
            }
            set {
                this.dHCCSpecialty1Field = value;
                this.RaisePropertyChanged("DHCCSpecialty1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string DHCCSpecialty2 {
            get {
                return this.dHCCSpecialty2Field;
            }
            set {
                this.dHCCSpecialty2Field = value;
                this.RaisePropertyChanged("DHCCSpecialty2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string DHCCSpecialty3 {
            get {
                return this.dHCCSpecialty3Field;
            }
            set {
                this.dHCCSpecialty3Field = value;
                this.RaisePropertyChanged("DHCCSpecialty3");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class InputParam : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string dateFromField;
        
        private string dateToField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string dateFrom {
            get {
                return this.dateFromField;
            }
            set {
                this.dateFromField = value;
                this.RaisePropertyChanged("dateFrom");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string dateTo {
            get {
                return this.dateToField;
            }
            set {
                this.dateToField = value;
                this.RaisePropertyChanged("dateTo");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetProfessionals", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetProfessionalsRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public Services_All.DHCCHCPService.Authentication Authentication;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Services_All.DHCCHCPService.InputParam parameter;
        
        public GetProfessionalsRequest() {
        }
        
        public GetProfessionalsRequest(Services_All.DHCCHCPService.Authentication Authentication, Services_All.DHCCHCPService.InputParam parameter) {
            this.Authentication = Authentication;
            this.parameter = parameter;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetProfessionalsResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetProfessionalsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Services_All.DHCCHCPService.HCP[] GetProfessionalsResult;
        
        public GetProfessionalsResponse() {
        }
        
        public GetProfessionalsResponse(Services_All.DHCCHCPService.HCP[] GetProfessionalsResult) {
            this.GetProfessionalsResult = GetProfessionalsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetFacilities", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetFacilitiesRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public Services_All.DHCCHCPService.Authentication Authentication;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Services_All.DHCCHCPService.InputParam parameter;
        
        public GetFacilitiesRequest() {
        }
        
        public GetFacilitiesRequest(Services_All.DHCCHCPService.Authentication Authentication, Services_All.DHCCHCPService.InputParam parameter) {
            this.Authentication = Authentication;
            this.parameter = parameter;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetFacilitiesResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetFacilitiesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Services_All.DHCCHCPService.Facility[] GetFacilitiesResult;
        
        public GetFacilitiesResponse() {
        }
        
        public GetFacilitiesResponse(Services_All.DHCCHCPService.Facility[] GetFacilitiesResult) {
            this.GetFacilitiesResult = GetFacilitiesResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HCPServiceSoapChannel : Services_All.DHCCHCPService.HCPServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HCPServiceSoapClient : System.ServiceModel.ClientBase<Services_All.DHCCHCPService.HCPServiceSoap>, Services_All.DHCCHCPService.HCPServiceSoap {
        
        public HCPServiceSoapClient() {
        }
        
        public HCPServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HCPServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HCPServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HCPServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Services_All.DHCCHCPService.GetProfessionalsResponse Services_All.DHCCHCPService.HCPServiceSoap.GetProfessionals(Services_All.DHCCHCPService.GetProfessionalsRequest request) {
            return base.Channel.GetProfessionals(request);
        }
        
        public Services_All.DHCCHCPService.HCP[] GetProfessionals(Services_All.DHCCHCPService.Authentication Authentication, Services_All.DHCCHCPService.InputParam parameter) {
            Services_All.DHCCHCPService.GetProfessionalsRequest inValue = new Services_All.DHCCHCPService.GetProfessionalsRequest();
            inValue.Authentication = Authentication;
            inValue.parameter = parameter;
            Services_All.DHCCHCPService.GetProfessionalsResponse retVal = ((Services_All.DHCCHCPService.HCPServiceSoap)(this)).GetProfessionals(inValue);
            return retVal.GetProfessionalsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Services_All.DHCCHCPService.GetProfessionalsResponse> Services_All.DHCCHCPService.HCPServiceSoap.GetProfessionalsAsync(Services_All.DHCCHCPService.GetProfessionalsRequest request) {
            return base.Channel.GetProfessionalsAsync(request);
        }
        
        public System.Threading.Tasks.Task<Services_All.DHCCHCPService.GetProfessionalsResponse> GetProfessionalsAsync(Services_All.DHCCHCPService.Authentication Authentication, Services_All.DHCCHCPService.InputParam parameter) {
            Services_All.DHCCHCPService.GetProfessionalsRequest inValue = new Services_All.DHCCHCPService.GetProfessionalsRequest();
            inValue.Authentication = Authentication;
            inValue.parameter = parameter;
            return ((Services_All.DHCCHCPService.HCPServiceSoap)(this)).GetProfessionalsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Services_All.DHCCHCPService.GetFacilitiesResponse Services_All.DHCCHCPService.HCPServiceSoap.GetFacilities(Services_All.DHCCHCPService.GetFacilitiesRequest request) {
            return base.Channel.GetFacilities(request);
        }
        
        public Services_All.DHCCHCPService.Facility[] GetFacilities(Services_All.DHCCHCPService.Authentication Authentication, Services_All.DHCCHCPService.InputParam parameter) {
            Services_All.DHCCHCPService.GetFacilitiesRequest inValue = new Services_All.DHCCHCPService.GetFacilitiesRequest();
            inValue.Authentication = Authentication;
            inValue.parameter = parameter;
            Services_All.DHCCHCPService.GetFacilitiesResponse retVal = ((Services_All.DHCCHCPService.HCPServiceSoap)(this)).GetFacilities(inValue);
            return retVal.GetFacilitiesResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Services_All.DHCCHCPService.GetFacilitiesResponse> Services_All.DHCCHCPService.HCPServiceSoap.GetFacilitiesAsync(Services_All.DHCCHCPService.GetFacilitiesRequest request) {
            return base.Channel.GetFacilitiesAsync(request);
        }
        
        public System.Threading.Tasks.Task<Services_All.DHCCHCPService.GetFacilitiesResponse> GetFacilitiesAsync(Services_All.DHCCHCPService.Authentication Authentication, Services_All.DHCCHCPService.InputParam parameter) {
            Services_All.DHCCHCPService.GetFacilitiesRequest inValue = new Services_All.DHCCHCPService.GetFacilitiesRequest();
            inValue.Authentication = Authentication;
            inValue.parameter = parameter;
            return ((Services_All.DHCCHCPService.HCPServiceSoap)(this)).GetFacilitiesAsync(inValue);
        }
    }
}
