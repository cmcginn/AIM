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
    /// Interface representing the dbo.aspnet_Paths table.
    /// </summary>
    public interface IAspnetPaths
    {
        /// <summary>
        /// Gets or sets the ApplicationId column value.
        /// </summary>
        System.Guid ApplicationId { get; set; }
        /// <summary>
        /// Gets or sets the PathId column value.
        /// </summary>
        System.Guid PathId { get; set; }
        /// <summary>
        /// Gets or sets the Path column value.
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Gets or sets the LoweredPath column value.
        /// </summary>
        string LoweredPath { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetPersonalizationAllUsers"/> association.
        /// </summary>
        AIM.Data.AspnetPersonalizationAllUsers AspnetPersonalizationAllUsers { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetApplications"/> association.
        /// </summary>
        AIM.Data.AspnetApplications AspnetApplications { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="T:AIM.Data.AspnetPersonalizationPerUser"/> association.
        /// </summary>
        System.Data.Linq.EntitySet<AIM.Data.AspnetPersonalizationPerUser> AspnetPersonalizationPerUserList { get; set; }
    }
}
