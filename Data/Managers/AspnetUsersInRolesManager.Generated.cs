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
    /// The manager class for AspnetUsersInRoles.
    /// </summary>
    public partial class AspnetUsersInRolesManager 
        : CodeSmith.Data.EntityManagerBase<Manager, AIM.Data.AspnetUsersInRoles>
    {
        /// <summary>
        /// Initializes the <see cref="AspnetUsersInRolesManager"/> class.
        /// </summary>
        /// <param name="manager">The current manager.</param>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public AspnetUsersInRolesManager(Manager manager)
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
        protected System.Data.Linq.Table<AIM.Data.AspnetUsersInRoles> Entity
        {
            get { return Manager.Context.AspnetUsersInRoles; }
        }
        
        
        /// <summary>
        /// Creates the key for this entity.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public static CodeSmith.Data.IEntityKey<System.Guid, System.Guid> CreateKey(System.Guid userId, System.Guid roleId)
        {
            return new CodeSmith.Data.EntityKey<System.Guid, System.Guid>(userId, roleId);
        }
        
        /// <summary>
        /// Gets an entity by the primary key.
        /// </summary>
        /// <param name="key">The key for the entity.</param>
        /// <returns>
        /// An instance of the entity or null if not found.
        /// </returns>
        /// <remarks>
        /// This method is expecting key to be of type IEntityKey&lt;System.Guid, System.Guid&gt;.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when key is not of type IEntityKey&lt;System.Guid, System.Guid&gt;.</exception>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public override AIM.Data.AspnetUsersInRoles GetByKey(CodeSmith.Data.IEntityKey key)
        {
            if (key is CodeSmith.Data.IEntityKey<System.Guid, System.Guid>)
            {
                var entityKey = (CodeSmith.Data.IEntityKey<System.Guid, System.Guid>)key;
                return GetByKey(entityKey.Key, entityKey.Key1);
            }
            else
            {
                throw new ArgumentException("Invalid key, expected key to be of type IEntityKey<System.Guid, System.Guid>");
            }
        }
        
        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        /// <returns>An instance of the entity or null if not found.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public AIM.Data.AspnetUsersInRoles GetByKey(System.Guid userId, System.Guid roleId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByKey.Invoke(Context, userId, roleId);
            else
                return Entity.FirstOrDefault(a => a.UserId == userId 
					&& a.RoleId == roleId);
        }
        
        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public int Delete(System.Guid userId, System.Guid roleId)
        {
            return Entity.Delete(a => a.UserId == userId 
					&& a.RoleId == roleId);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public IQueryable<AIM.Data.AspnetUsersInRoles> GetByRoleId(System.Guid roleId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByRoleId.Invoke(Context, roleId);
            else
                return Entity.Where(a => a.RoleId == roleId);
        }
        /// <summary>
        /// Gets a query by an index.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        public IQueryable<AIM.Data.AspnetUsersInRoles> GetByUserId(System.Guid userId)
        {
            if (Context.LoadOptions == null) 
                return Query.GetByUserId.Invoke(Context, userId);
            else
                return Entity.Where(a => a.UserId == userId);
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
            internal static readonly Func<AIM.Data.DomainContext, System.Guid, System.Guid, AIM.Data.AspnetUsersInRoles> GetByKey = 
                System.Data.Linq.CompiledQuery.Compile(
                    (AIM.Data.DomainContext db, System.Guid userId, System.Guid roleId) => 
                        db.AspnetUsersInRoles.FirstOrDefault(a => a.UserId == userId 
							&& a.RoleId == roleId));

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
            internal static readonly Func<AIM.Data.DomainContext, System.Guid, IQueryable<AIM.Data.AspnetUsersInRoles>> GetByRoleId = 
                System.Data.Linq.CompiledQuery.Compile(
                    (AIM.Data.DomainContext db, System.Guid roleId) => 
                        db.AspnetUsersInRoles.Where(a => a.RoleId == roleId));

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
            internal static readonly Func<AIM.Data.DomainContext, System.Guid, IQueryable<AIM.Data.AspnetUsersInRoles>> GetByUserId = 
                System.Data.Linq.CompiledQuery.Compile(
                    (AIM.Data.DomainContext db, System.Guid userId) => 
                        db.AspnetUsersInRoles.Where(a => a.UserId == userId));

        }
        #endregion
    }
}
#pragma warning restore 1591

