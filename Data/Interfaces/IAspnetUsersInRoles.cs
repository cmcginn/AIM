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
    /// Interface representing the dbo.aspnet_UsersInRoles table.
    /// </summary>
    public interface IAspnetUsersInRoles
    {
        /// <summary>
        /// Gets or sets the UserId column value.
        /// </summary>
        System.Guid UserId { get; set; }
        /// <summary>
        /// Gets or sets the RoleId column value.
        /// </summary>
        System.Guid RoleId { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetRoles"/> association.
        /// </summary>
        AIM.Data.AspnetRoles AspnetRoles { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetUsers"/> association.
        /// </summary>
        AIM.Data.AspnetUsers AspnetUsers { get; set; }
    }
}
