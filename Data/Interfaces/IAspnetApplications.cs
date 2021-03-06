﻿//------------------------------------------------------------------------------
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
    /// Interface representing the dbo.aspnet_Applications table.
    /// </summary>
    public interface IAspnetApplications
    {
        /// <summary>
        /// Gets or sets the ApplicationName column value.
        /// </summary>
        string ApplicationName { get; set; }
        /// <summary>
        /// Gets or sets the LoweredApplicationName column value.
        /// </summary>
        string LoweredApplicationName { get; set; }
        /// <summary>
        /// Gets or sets the ApplicationId column value.
        /// </summary>
        System.Guid ApplicationId { get; set; }
        /// <summary>
        /// Gets or sets the Description column value.
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetMembership"/> association.
        /// </summary>
        System.Data.Linq.EntitySet<AIM.Data.AspnetMembership> AspnetMembershipList { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetPaths"/> association.
        /// </summary>
        System.Data.Linq.EntitySet<AIM.Data.AspnetPaths> AspnetPathsList { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetRoles"/> association.
        /// </summary>
        System.Data.Linq.EntitySet<AIM.Data.AspnetRoles> AspnetRolesList { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetUsers"/> association.
        /// </summary>
        System.Data.Linq.EntitySet<AIM.Data.AspnetUsers> AspnetUsersList { get; set; }
    }
}
