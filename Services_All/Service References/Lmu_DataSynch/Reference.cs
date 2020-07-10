﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Services_All.Lmu_DataSynch {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://services.lmu.dimensions.com/", ConfigurationName="Lmu_DataSynch.DataSyncService")]
    public interface DataSyncService {
        
        // CODEGEN: Parameter 'RecordsResult' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="RecordsResult")]
        Services_All.Lmu_DataSynch.findRecordsResponse findRecords(Services_All.Lmu_DataSynch.findRecords request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.findRecordsResponse> findRecordsAsync(Services_All.Lmu_DataSynch.findRecords request);
        
        // CODEGEN: Parameter 'VersionResult' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="VersionResult")]
        Services_All.Lmu_DataSynch.currentVersionResponse currentVersion(Services_All.Lmu_DataSynch.currentVersion request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.currentVersionResponse> currentVersionAsync(Services_All.Lmu_DataSynch.currentVersion request);
        
        // CODEGEN: Parameter 'ChangesResult' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="ChangesResult")]
        Services_All.Lmu_DataSynch.findChangesResponse findChanges(Services_All.Lmu_DataSynch.findChanges request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.findChangesResponse> findChangesAsync(Services_All.Lmu_DataSynch.findChanges request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1067.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.lmu.dimensions.com/")]
    public partial class authorizationCode : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string usernameField;
        
        private string keyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
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
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("key");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1067.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.lmu.dimensions.com/")]
    public partial class changesResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool successField;
        
        private string msgField;
        
        private int currentVersionField;
        
        private bool currentVersionFieldSpecified;
        
        private int[] recordsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public bool success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
                this.RaisePropertyChanged("success");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string msg {
            get {
                return this.msgField;
            }
            set {
                this.msgField = value;
                this.RaisePropertyChanged("msg");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int currentVersion {
            get {
                return this.currentVersionField;
            }
            set {
                this.currentVersionField = value;
                this.RaisePropertyChanged("currentVersion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool currentVersionSpecified {
            get {
                return this.currentVersionFieldSpecified;
            }
            set {
                this.currentVersionFieldSpecified = value;
                this.RaisePropertyChanged("currentVersionSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("records", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public int[] records {
            get {
                return this.recordsField;
            }
            set {
                this.recordsField = value;
                this.RaisePropertyChanged("records");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1067.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.lmu.dimensions.com/")]
    public partial class versionResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool successField;
        
        private string msgField;
        
        private int versionField;
        
        private bool versionFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public bool success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
                this.RaisePropertyChanged("success");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string msg {
            get {
                return this.msgField;
            }
            set {
                this.msgField = value;
                this.RaisePropertyChanged("msg");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
                this.RaisePropertyChanged("version");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool versionSpecified {
            get {
                return this.versionFieldSpecified;
            }
            set {
                this.versionFieldSpecified = value;
                this.RaisePropertyChanged("versionSpecified");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1067.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.lmu.dimensions.com/")]
    public partial class recordsResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool successField;
        
        private string msgField;
        
        private string xmlContentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public bool Success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
                this.RaisePropertyChanged("Success");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string msg {
            get {
                return this.msgField;
            }
            set {
                this.msgField = value;
                this.RaisePropertyChanged("msg");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string xmlContent {
            get {
                return this.xmlContentField;
            }
            set {
                this.xmlContentField = value;
                this.RaisePropertyChanged("xmlContent");
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
    [System.ServiceModel.MessageContractAttribute(WrapperName="findRecords", WrapperNamespace="http://services.lmu.dimensions.com/", IsWrapped=true)]
    public partial class findRecords {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Services_All.Lmu_DataSynch.authorizationCode authorizationCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string listName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int targetVersion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("recordsIdsList", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int[] recordsIdsList;
        
        public findRecords() {
        }
        
        public findRecords(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName, int targetVersion, int[] recordsIdsList) {
            this.authorizationCode = authorizationCode;
            this.listName = listName;
            this.targetVersion = targetVersion;
            this.recordsIdsList = recordsIdsList;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findRecordsResponse", WrapperNamespace="http://services.lmu.dimensions.com/", IsWrapped=true)]
    public partial class findRecordsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Services_All.Lmu_DataSynch.recordsResult RecordsResult;
        
        public findRecordsResponse() {
        }
        
        public findRecordsResponse(Services_All.Lmu_DataSynch.recordsResult RecordsResult) {
            this.RecordsResult = RecordsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="currentVersion", WrapperNamespace="http://services.lmu.dimensions.com/", IsWrapped=true)]
    public partial class currentVersion {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Services_All.Lmu_DataSynch.authorizationCode authorizationCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string listName;
        
        public currentVersion() {
        }
        
        public currentVersion(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName) {
            this.authorizationCode = authorizationCode;
            this.listName = listName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="currentVersionResponse", WrapperNamespace="http://services.lmu.dimensions.com/", IsWrapped=true)]
    public partial class currentVersionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Services_All.Lmu_DataSynch.versionResult VersionResult;
        
        public currentVersionResponse() {
        }
        
        public currentVersionResponse(Services_All.Lmu_DataSynch.versionResult VersionResult) {
            this.VersionResult = VersionResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findChanges", WrapperNamespace="http://services.lmu.dimensions.com/", IsWrapped=true)]
    public partial class findChanges {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Services_All.Lmu_DataSynch.authorizationCode authorizationCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string listName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int localVersion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int targetVersion;
        
        public findChanges() {
        }
        
        public findChanges(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName, int localVersion, int targetVersion) {
            this.authorizationCode = authorizationCode;
            this.listName = listName;
            this.localVersion = localVersion;
            this.targetVersion = targetVersion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="findChangesResponse", WrapperNamespace="http://services.lmu.dimensions.com/", IsWrapped=true)]
    public partial class findChangesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.lmu.dimensions.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Services_All.Lmu_DataSynch.changesResult ChangesResult;
        
        public findChangesResponse() {
        }
        
        public findChangesResponse(Services_All.Lmu_DataSynch.changesResult ChangesResult) {
            this.ChangesResult = ChangesResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DataSyncServiceChannel : Services_All.Lmu_DataSynch.DataSyncService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataSyncServiceClient : System.ServiceModel.ClientBase<Services_All.Lmu_DataSynch.DataSyncService>, Services_All.Lmu_DataSynch.DataSyncService {
        
        public DataSyncServiceClient() {
        }
        
        public DataSyncServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataSyncServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataSyncServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataSyncServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Services_All.Lmu_DataSynch.findRecordsResponse Services_All.Lmu_DataSynch.DataSyncService.findRecords(Services_All.Lmu_DataSynch.findRecords request) {
            return base.Channel.findRecords(request);
        }
        
        public Services_All.Lmu_DataSynch.recordsResult findRecords(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName, int targetVersion, int[] recordsIdsList) {
            Services_All.Lmu_DataSynch.findRecords inValue = new Services_All.Lmu_DataSynch.findRecords();
            inValue.authorizationCode = authorizationCode;
            inValue.listName = listName;
            inValue.targetVersion = targetVersion;
            inValue.recordsIdsList = recordsIdsList;
            Services_All.Lmu_DataSynch.findRecordsResponse retVal = ((Services_All.Lmu_DataSynch.DataSyncService)(this)).findRecords(inValue);
            return retVal.RecordsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.findRecordsResponse> Services_All.Lmu_DataSynch.DataSyncService.findRecordsAsync(Services_All.Lmu_DataSynch.findRecords request) {
            return base.Channel.findRecordsAsync(request);
        }
        
        public System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.findRecordsResponse> findRecordsAsync(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName, int targetVersion, int[] recordsIdsList) {
            Services_All.Lmu_DataSynch.findRecords inValue = new Services_All.Lmu_DataSynch.findRecords();
            inValue.authorizationCode = authorizationCode;
            inValue.listName = listName;
            inValue.targetVersion = targetVersion;
            inValue.recordsIdsList = recordsIdsList;
            return ((Services_All.Lmu_DataSynch.DataSyncService)(this)).findRecordsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Services_All.Lmu_DataSynch.currentVersionResponse Services_All.Lmu_DataSynch.DataSyncService.currentVersion(Services_All.Lmu_DataSynch.currentVersion request) {
            return base.Channel.currentVersion(request);
        }
        
        public Services_All.Lmu_DataSynch.versionResult currentVersion(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName) {
            Services_All.Lmu_DataSynch.currentVersion inValue = new Services_All.Lmu_DataSynch.currentVersion();
            inValue.authorizationCode = authorizationCode;
            inValue.listName = listName;
            Services_All.Lmu_DataSynch.currentVersionResponse retVal = ((Services_All.Lmu_DataSynch.DataSyncService)(this)).currentVersion(inValue);
            return retVal.VersionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.currentVersionResponse> Services_All.Lmu_DataSynch.DataSyncService.currentVersionAsync(Services_All.Lmu_DataSynch.currentVersion request) {
            return base.Channel.currentVersionAsync(request);
        }
        
        public System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.currentVersionResponse> currentVersionAsync(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName) {
            Services_All.Lmu_DataSynch.currentVersion inValue = new Services_All.Lmu_DataSynch.currentVersion();
            inValue.authorizationCode = authorizationCode;
            inValue.listName = listName;
            return ((Services_All.Lmu_DataSynch.DataSyncService)(this)).currentVersionAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Services_All.Lmu_DataSynch.findChangesResponse Services_All.Lmu_DataSynch.DataSyncService.findChanges(Services_All.Lmu_DataSynch.findChanges request) {
            return base.Channel.findChanges(request);
        }
        
        public Services_All.Lmu_DataSynch.changesResult findChanges(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName, int localVersion, int targetVersion) {
            Services_All.Lmu_DataSynch.findChanges inValue = new Services_All.Lmu_DataSynch.findChanges();
            inValue.authorizationCode = authorizationCode;
            inValue.listName = listName;
            inValue.localVersion = localVersion;
            inValue.targetVersion = targetVersion;
            Services_All.Lmu_DataSynch.findChangesResponse retVal = ((Services_All.Lmu_DataSynch.DataSyncService)(this)).findChanges(inValue);
            return retVal.ChangesResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.findChangesResponse> Services_All.Lmu_DataSynch.DataSyncService.findChangesAsync(Services_All.Lmu_DataSynch.findChanges request) {
            return base.Channel.findChangesAsync(request);
        }
        
        public System.Threading.Tasks.Task<Services_All.Lmu_DataSynch.findChangesResponse> findChangesAsync(Services_All.Lmu_DataSynch.authorizationCode authorizationCode, string listName, int localVersion, int targetVersion) {
            Services_All.Lmu_DataSynch.findChanges inValue = new Services_All.Lmu_DataSynch.findChanges();
            inValue.authorizationCode = authorizationCode;
            inValue.listName = listName;
            inValue.localVersion = localVersion;
            inValue.targetVersion = targetVersion;
            return ((Services_All.Lmu_DataSynch.DataSyncService)(this)).findChangesAsync(inValue);
        }
    }
}