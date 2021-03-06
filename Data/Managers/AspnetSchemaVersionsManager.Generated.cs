﻿
#pragma warning disable 1591
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CodeSmith.Data.Linq;
using CodeSmith.Data.Linq.Dynamic;

namespace AIM.Data
{
    /// <summary>
    /// The manager class for AspnetSchemaVersions.
    /// </summary>
    public partial class AspnetSchemaVersionsManager 
        : CodeSmith.Data.EntityManagerBase<Manager, AIM.Data.AspnetSchemaVersions>
    {
        /// <summary>
        /// Initializes the <see cref="AspnetSchemaVersionsManager"/> class.
        /// </summary>
        /// <param name="manager">The current manager.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public AspnetSchemaVersionsManager(Manager manager)
            : base(manager)
        {
            OnCreated();
        }

        /// <summary>
        /// Gets the current context.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        protected AIM.Data.DomainContext Context
        {
            get { return Manager.Context; }
        }
        
        /// <summary>
        /// Gets the entity for this manager.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        protected System.Data.Linq.Table<AIM.Data.AspnetSchemaVersions> Entity
        {
            get { return Manager.Context.AspnetSchemaVersions; }
        }
        
        
        /// <summary>
        /// Creates the key for this entity.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public static CodeSmith.Data.IEntityKey<string, string> CreateKey(string feature, string compatibleSchemaVersion)
        {
            return new CodeSmith.Data.EntityKey<string, string>(feature, compatibleSchemaVersion);
        }
        
        /// <summary>
        /// Gets an entity by the primary key.
        /// </summary>
        /// <param name="key">The key for the entity.</param>
        /// <returns>
        /// An instance of the entity or null if not found.
        /// </returns>
        /// <remarks>
        /// This method is expecting key to be of type IEntityKey&lt;string, string&gt;.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when key is not of type IEntityKey&lt;string, string&gt;.</exception>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public override AIM.Data.AspnetSchemaVersions GetByKey(CodeSmith.Data.IEntityKey key)
        {
            if (key is CodeSmith.Data.IEntityKey<string, string>)
            {
                var entityKey = (CodeSmith.Data.IEntityKey<string, string>)key;
                return GetByKey(entityKey.Key, entityKey.Key1);
            }
            else
            {
                throw new ArgumentException("Invalid key, expected key to be of type IEntityKey<string, string>");
            }
        }
        
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public AIM.Data.AspnetSchemaVersions GetByKey(string feature, string compatibleSchemaVersion)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByKey.Invoke(Context, feature, compatibleSchemaVersion);
            else
                return Entity.FirstOrDefault(a => a.Feature == feature 
					&& a.CompatibleSchemaVersion == compatibleSchemaVersion);
        }
        
        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public int Delete(string feature, string compatibleSchemaVersion)
        {
            return Entity.Delete(a => a.Feature == feature 
					&& a.CompatibleSchemaVersion == compatibleSchemaVersion);
        }

        #region Extensibility Method Definitions
        /// <summary>Called when the class is created.</summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        partial void OnCreated();
        #endregion
        
        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
            internal static readonly Func<AIM.Data.DomainContext, string, string, AIM.Data.AspnetSchemaVersions> GetByKey = 
                System.Data.Linq.CompiledQuery.Compile(
                    (AIM.Data.DomainContext db, string feature, string compatibleSchemaVersion) => 
                        db.AspnetSchemaVersions.FirstOrDefault(a => a.Feature == feature 
							&& a.CompatibleSchemaVersion == compatibleSchemaVersion));

        }
        #endregion
    }
}
#pragma warning restore 1591

