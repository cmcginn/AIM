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
    /// The class representing the dbo.aspnet_PersonalizationAllUsers table.
    /// </summary>
    [System.Data.Linq.Mapping.Table(Name="dbo.aspnet_PersonalizationAllUsers")]
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.ComponentModel.DataAnnotations.MetadataType(typeof(AIM.Data.AspnetPersonalizationAllUsers.Metadata))]
    [System.Data.Services.Common.DataServiceKey("PathId")]
    [System.Diagnostics.DebuggerDisplay("PathId: {PathId}")]
    public partial class AspnetPersonalizationAllUsers
        : LinqEntityBase, ICloneable, AIM.Data.IAspnetPersonalizationAllUsers  
    {
        #region Static Constructor
        /// <summary>
        /// Initializes the <see cref="AspnetPersonalizationAllUsers"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static AspnetPersonalizationAllUsers()
        {
            AddSharedRules();
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AspnetPersonalizationAllUsers"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public AspnetPersonalizationAllUsers()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private void Initialize()
        {
            _aspnetPaths = default(System.Data.Linq.EntityRef<AspnetPaths>);
            OnCreated();
        }
        #endregion

        #region Column Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private System.Guid _pathId;

        /// <summary>
        /// Gets or sets the PathId column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "PathId", Storage = "_pathId", DbType = "uniqueidentifier NOT NULL", IsPrimaryKey = true, CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public System.Guid PathId
        {
            get { return _pathId; }
            set
            {
                if (_pathId != value)
                {
                    if (_aspnetPaths.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnPathIdChanging(value);
                    SendPropertyChanging("PathId");
                    _pathId = value;
                    SendPropertyChanged("PathId");
                    OnPathIdChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private System.Data.Linq.Binary _pageSettings;

        /// <summary>
        /// Gets or sets the PageSettings column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "PageSettings", Storage = "_pageSettings", DbType = "image NOT NULL", CanBeNull = false, UpdateCheck = System.Data.Linq.Mapping.UpdateCheck.Never)]
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public System.Data.Linq.Binary PageSettings
        {
            get { return _pageSettings; }
            set
            {
                if (_pageSettings != value)
                {
                    OnPageSettingsChanging(value);
                    SendPropertyChanging("PageSettings");
                    _pageSettings = value;
                    SendPropertyChanged("PageSettings");
                    OnPageSettingsChanged();
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private System.DateTime _lastUpdatedDate;

        /// <summary>
        /// Gets or sets the LastUpdatedDate column value.
        /// </summary>
        [System.Data.Linq.Mapping.Column(Name = "LastUpdatedDate", Storage = "_lastUpdatedDate", DbType = "datetime NOT NULL", CanBeNull = false)]
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public System.DateTime LastUpdatedDate
        {
            get { return _lastUpdatedDate; }
            set
            {
                if (_lastUpdatedDate != value)
                {
                    OnLastUpdatedDateChanging(value);
                    SendPropertyChanging("LastUpdatedDate");
                    _lastUpdatedDate = value;
                    SendPropertyChanged("LastUpdatedDate");
                    OnLastUpdatedDateChanged();
                }
            }
        }
        #endregion

        #region Association Mapped Properties

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        private System.Data.Linq.EntityRef<AspnetPaths> _aspnetPaths;

        /// <summary>
        /// Gets or sets the <see cref="AspnetPaths"/> association.
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "AspnetPaths_AspnetPersonalizationAllUsers", Storage = "_aspnetPaths", ThisKey = "PathId", OtherKey = "PathId", IsForeignKey = true, DeleteOnNull = true)]
        [System.Runtime.Serialization.DataMember(Order = 4, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public AspnetPaths AspnetPaths
        {
            get { return (serializing && !_aspnetPaths.HasLoadedOrAssignedValue) ? null : _aspnetPaths.Entity; }
            set
            {
                AspnetPaths previousValue = _aspnetPaths.Entity;
                if (previousValue != value || _aspnetPaths.HasLoadedOrAssignedValue == false)
                {
                    OnAspnetPathsChanging(value);
                    SendPropertyChanging("AspnetPaths");
                    if (previousValue != null)
                    {
                        _aspnetPaths.Entity = null;
                        previousValue.AspnetPersonalizationAllUsers = null;
                    }
                    _aspnetPaths.Entity = value;
                    if (value != null)
                    {
                        value.AspnetPersonalizationAllUsers = this;
                        _pathId = value.PathId;
                    }
                    else
                    {
                        _pathId = default(System.Guid);
                    }
                    SendPropertyChanged("AspnetPaths");
                    OnAspnetPathsChanged();
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
        /// <summary>Called when <see cref="PathId"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnPathIdChanging(System.Guid value);
        /// <summary>Called after <see cref="PathId"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnPathIdChanged();
        /// <summary>Called when <see cref="PageSettings"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnPageSettingsChanging(System.Data.Linq.Binary value);
        /// <summary>Called after <see cref="PageSettings"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnPageSettingsChanged();
        /// <summary>Called when <see cref="LastUpdatedDate"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnLastUpdatedDateChanging(System.DateTime value);
        /// <summary>Called after <see cref="LastUpdatedDate"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnLastUpdatedDateChanged();
        /// <summary>Called when <see cref="AspnetPaths"/> is changing.</summary>
        /// <param name="value">The new value.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnAspnetPathsChanging(AspnetPaths value);
        /// <summary>Called after <see cref="AspnetPaths"/> has Changed.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnAspnetPathsChanged();

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
        /// Deserializes an instance of <see cref="AspnetPersonalizationAllUsers"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="AspnetPersonalizationAllUsers"/> instance.</param>
        /// <returns>An instance of <see cref="AspnetPersonalizationAllUsers"/> that is deserialized from the XML string.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public static AspnetPersonalizationAllUsers FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(AspnetPersonalizationAllUsers));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as AspnetPersonalizationAllUsers;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="AspnetPersonalizationAllUsers"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="AspnetPersonalizationAllUsers"/> instance.</param>
        /// <returns>An instance of <see cref="AspnetPersonalizationAllUsers"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public static AspnetPersonalizationAllUsers FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(AspnetPersonalizationAllUsers));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as AspnetPersonalizationAllUsers;
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
        public AspnetPersonalizationAllUsers Clone()
        {
            return (AspnetPersonalizationAllUsers)((ICloneable)this).Clone();
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
            _aspnetPaths = Detach(_aspnetPaths);
        }
        #endregion
    }
}
#pragma warning restore 1591
#pragma warning restore 0414

