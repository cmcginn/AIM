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
    /// The manager class for ClientFileImport.
    /// </summary>
    public partial class ClientFileImportManager 
        : CodeSmith.Data.EntityManagerBase<Manager, AIM.Data.ClientFileImport>
    {
        /// <summary>
        /// Initializes the <see cref="ClientFileImportManager"/> class.
        /// </summary>
        /// <param name="manager">The current manager.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public ClientFileImportManager(Manager manager)
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
        protected System.Data.Linq.Table<AIM.Data.ClientFileImport> Entity
        {
            get { return Manager.Context.ClientFileImport; }
        }
        
        
        /// <summary>
        /// Creates the key for this entity.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public static CodeSmith.Data.IEntityKey<System.Guid> CreateKey(System.Guid id)
        {
            return new CodeSmith.Data.EntityKey<System.Guid>(id);
        }
        
        /// <summary>
        /// Gets an entity by the primary key.
        /// </summary>
        /// <param name="key">The key for the entity.</param>
        /// <returns>
        /// An instance of the entity or null if not found.
        /// </returns>
        /// <remarks>
        /// This method is expecting key to be of type IEntityKey&lt;System.Guid&gt;.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when key is not of type IEntityKey&lt;System.Guid&gt;.</exception>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public override AIM.Data.ClientFileImport GetByKey(CodeSmith.Data.IEntityKey key)
        {
            if (key is CodeSmith.Data.IEntityKey<System.Guid>)
            {
                var entityKey = (CodeSmith.Data.IEntityKey<System.Guid>)key;
                return GetByKey(entityKey.Key);
            }
            else
            {
                throw new ArgumentException("Invalid key, expected key to be of type IEntityKey<System.Guid>");
            }
        }
        
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public AIM.Data.ClientFileImport GetByKey(System.Guid id)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByKey.Invoke(Context, id);
            else
                return Entity.FirstOrDefault(c => c.Id == id);
        }
        
        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public int Delete(System.Guid id)
        {
            return Entity.Delete(c => c.Id == id);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public IQueryable<AIM.Data.ClientFileImport> GetByClientId(System.Guid clientId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByClientId.Invoke(Context, clientId);
            else
                return Entity.Where(c => c.ClientId == clientId);
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
            internal static readonly Func<AIM.Data.DomainContext, System.Guid, AIM.Data.ClientFileImport> GetByKey = 
                System.Data.Linq.CompiledQuery.Compile(
                    (AIM.Data.DomainContext db, System.Guid id) => 
                        db.ClientFileImport.FirstOrDefault(c => c.Id == id));

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
            internal static readonly Func<AIM.Data.DomainContext, System.Guid, IQueryable<AIM.Data.ClientFileImport>> GetByClientId = 
                System.Data.Linq.CompiledQuery.Compile(
                    (AIM.Data.DomainContext db, System.Guid clientId) => 
                        db.ClientFileImport.Where(c => c.ClientId == clientId));

        }
        #endregion
    }
}
#pragma warning restore 1591

