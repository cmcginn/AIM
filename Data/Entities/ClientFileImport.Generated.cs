﻿#pragma warning disable 1591
#pragma warning disable 0414        
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Linq;

namespace AIM.Data
{
    /// <summary>
    /// The class representing the dbo.ClientFileImport table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.ClientFileImport")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(AIM.Data.ClientFileImport.Metadata))]
    [System.Data.Services.Common.DataServiceKey("Id")]
    [System.Diagnostics.DebuggerDisplay("Id: {Id}")]
    public partial class ClientFileImport
        : LinqEntityBase, ICloneable, AIM.Data.IClientFileImport  
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="ClientFileImport"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static ClientFileImport()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientFileImport"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public ClientFileImport()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private void Initialize()
        {
            _client = default(System.Data.Linq.EntityRef<Client>);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private System.Guid _id;

        /// <summary>
        /// Gets or sets the Id column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Id", Storage = "_id", DbType = "uniqueidentifier NOT NULL", IsPrimaryKey = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public System.Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    OnIdChanging(value);
                    SendPropertyChanging("Id");
                    _id = value;
                    SendPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private System.Guid _clientId;

        /// <summary>
        /// Gets or sets the ClientId column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "ClientId", Storage = "_clientId", DbType = "uniqueidentifier NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public System.Guid ClientId
        {
            get { return _clientId; }
            set
            {
                if (_clientId != value)
                {
                    if (_client.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnClientIdChanging(value);
                    SendPropertyChanging("ClientId");
                    _clientId = value;
                    SendPropertyChanged("ClientId");
                    OnClientIdChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private string _uploadFilePath;

        /// <summary>
        /// Gets or sets the UploadFilePath column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "UploadFilePath", Storage = "_uploadFilePath", DbType = "nvarchar(MAX) NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public string UploadFilePath
        {
            get { return _uploadFilePath; }
            set
            {
                if (_uploadFilePath != value)
                {
                    OnUploadFilePathChanging(value);
                    SendPropertyChanging("UploadFilePath");
                    _uploadFilePath = value;
                    SendPropertyChanged("UploadFilePath");
                    OnUploadFilePathChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private string _importedFilePath;

        /// <summary>
        /// Gets or sets the ImportedFilePath column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "ImportedFilePath", Storage = "_importedFilePath", DbType = "nvarchar(MAX) NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public string ImportedFilePath
        {
            get { return _importedFilePath; }
            set
            {
                if (_importedFilePath != value)
                {
                    OnImportedFilePathChanging(value);
                    SendPropertyChanging("ImportedFilePath");
                    _importedFilePath = value;
                    SendPropertyChanged("ImportedFilePath");
                    OnImportedFilePathChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private int _recordsImported;

        /// <summary>
        /// Gets or sets the RecordsImported column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "RecordsImported", Storage = "_recordsImported", DbType = "int NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public int RecordsImported
        {
            get { return _recordsImported; }
            set
            {
                if (_recordsImported != value)
                {
                    OnRecordsImportedChanging(value);
                    SendPropertyChanging("RecordsImported");
                    _recordsImported = value;
                    SendPropertyChanged("RecordsImported");
                    OnRecordsImportedChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private int _recordsFailed;

        /// <summary>
        /// Gets or sets the RecordsFailed column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "RecordsFailed", Storage = "_recordsFailed", DbType = "int NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 6)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public int RecordsFailed
        {
            get { return _recordsFailed; }
            set
            {
                if (_recordsFailed != value)
                {
                    OnRecordsFailedChanging(value);
                    SendPropertyChanging("RecordsFailed");
                    _recordsFailed = value;
                    SendPropertyChanged("RecordsFailed");
                    OnRecordsFailedChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private System.DateTime _lastUpdated;

        /// <summary>
        /// Gets or sets the LastUpdated column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "LastUpdated", Storage = "_lastUpdated", DbType = "datetime NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 7)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public System.DateTime LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                if (_lastUpdated != value)
                {
                    OnLastUpdatedChanging(value);
                    SendPropertyChanging("LastUpdated");
                    _lastUpdated = value;
                    SendPropertyChanged("LastUpdated");
                    OnLastUpdatedChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private Nullable<System.DateTime> _processed;

        /// <summary>
        /// Gets or sets the Processed column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "Processed", Storage = "_processed", DbType = "datetime")]
        [System.Runtime.Serialization.DataMember(Order = 8)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public Nullable<System.DateTime> Processed
        {
            get { return _processed; }
            set
            {
                if (_processed != value)
                {
                    OnProcessedChanging(value);
                    SendPropertyChanging("Processed");
                    _processed = value;
                    SendPropertyChanged("Processed");
                    OnProcessedChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private System.Data.Linq.EntityRef<Client> _client;

        /// <summary>
        /// Gets or sets the <see cref="Client"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "Client_ClientFileImport", Storage = "_client", ThisKey = "ClientId", OtherKey = "Id", IsForeignKey = true, DeleteOnNull = true)]
        [System.Runtime.Serialization.DataMember(Order = 9, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public Client Client
        {
            get { return (serializing && !_client.HasLoadedOrAssignedValue) ? null : _client.Entity; }
            set
            {
                Client previousValue = _client.Entity;
                if (previousValue != value || _client.HasLoadedOrAssignedValue == false)
                {
                    OnClientChanging(value);
                    SendPropertyChanging("Client");
                    if (previousValue != null)
                    {
                        _client.Entity = null;
                        previousValue.ClientFileImportList.Remove(this);
                    }
                    _client.Entity = value;
                    if (value != null)
                    {
                        value.ClientFileImportList.Add(this);
                        _clientId = value.Id;
                    }
                    else
                    {
                        _clientId = default(System.Guid);
                    }
                    SendPropertyChanged("Client");
                    OnClientChanged();
                }
            }
        }
        
        #endregion

        #region Extensibility Method Definitions
        /// <summary>Called by the static constructor to add shared rules.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static partial void AddSharedRules();
        /// <summary>Called when this instance is loaded.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnLoaded();
        /// <summary>Called when this instance is being saved.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        /// <summary>Called when this instance is created.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnCreated();
        /// <summary>Called when <see cref="Id"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnIdChanging(System.Guid value);
        /// <summary>Called after <see cref="Id"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnIdChanged();
        /// <summary>Called when <see cref="ClientId"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnClientIdChanging(System.Guid value);
        /// <summary>Called after <see cref="ClientId"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnClientIdChanged();
        /// <summary>Called when <see cref="UploadFilePath"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnUploadFilePathChanging(string value);
        /// <summary>Called after <see cref="UploadFilePath"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnUploadFilePathChanged();
        /// <summary>Called when <see cref="ImportedFilePath"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnImportedFilePathChanging(string value);
        /// <summary>Called after <see cref="ImportedFilePath"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnImportedFilePathChanged();
        /// <summary>Called when <see cref="RecordsImported"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnRecordsImportedChanging(int value);
        /// <summary>Called after <see cref="RecordsImported"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnRecordsImportedChanged();
        /// <summary>Called when <see cref="RecordsFailed"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnRecordsFailedChanging(int value);
        /// <summary>Called after <see cref="RecordsFailed"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnRecordsFailedChanged();
        /// <summary>Called when <see cref="LastUpdated"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnLastUpdatedChanging(System.DateTime value);
        /// <summary>Called after <see cref="LastUpdated"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnLastUpdatedChanged();
        /// <summary>Called when <see cref="Processed"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnProcessedChanging(Nullable<System.DateTime> value);
        /// <summary>Called after <see cref="Processed"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnProcessedChanged();
        /// <summary>Called when <see cref="Client"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnClientChanging(Client value);
        /// <summary>Called after <see cref="Client"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnClientChanged();

        #endregion

        #region Serialization
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private bool serializing;

        /// <summary>
        /// Called when serializing.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        [System.Runtime.Serialization.OnSerializing]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public void OnSerializing(System.Runtime.Serialization.StreamingContext context) {
            serializing = true;
        }

        /// <summary>
        /// Called when serialized.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        [System.Runtime.Serialization.OnSerialized]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public void OnSerialized(System.Runtime.Serialization.StreamingContext context) {
            serializing = false;
        }

        /// <summary>
        /// Called when deserializing.
        /// </summary>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> for the serialization.</param>
        [System.Runtime.Serialization.OnDeserializing]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public void OnDeserializing(System.Runtime.Serialization.StreamingContext context) {
            Initialize();
        }

        /// <summary>
        /// Deserializes an instance of <see cref="ClientFileImport"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="ClientFileImport"/> instance.</param>
        /// <returns>An instance of <see cref="ClientFileImport"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public static ClientFileImport FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ClientFileImport));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as ClientFileImport;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="ClientFileImport"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="ClientFileImport"/> instance.</param>
        /// <returns>An instance of <see cref="ClientFileImport"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public static ClientFileImport FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(ClientFileImport));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as ClientFileImport;
            }
        }
        
        #endregion

        #region Clone
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        object ICloneable.Clone()
        {
            var serializer = new System.Runtime.Serialization.DataContractSerializer(GetType());
            using (var ms = new System.IO.MemoryStream())
            {
                serializer.WriteObject(ms, this);
                ms.Position = 0;
                return serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <remarks>
        /// Only loaded <see cref="T:System.Data.Linq.EntityRef`1"/> and <see cref="T:System.Data.Linq.EntitySet`1" /> child accessions will be cloned.
        /// </remarks>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public ClientFileImport Clone()
        {
            return (ClientFileImport)((ICloneable)this).Clone();
        }
        #endregion

        #region Detach Methods
        /// <summary>
        /// Detach this instance from the <see cref="System.Data.Linq.DataContext"/>.
        /// </summary>
        /// <remarks>
        /// Detaching the entity will stop all lazy loading and allow it to be added to another <see cref="System.Data.Linq.DataContext"/>.
        /// </remarks>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public override void Detach()
        {
            if (!IsAttached())
                return;

            base.Detach();
            _client = Detach(_client);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414

