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
    /// Interface representing the dbo.aspnet_SchemaVersions table.
    /// </summary>
    public interface IAspnetSchemaVersions
    {
        /// <summary>
        /// Gets or sets the Feature column value.
        /// </summary>
        string Feature { get; set; }
        /// <summary>
        /// Gets or sets the CompatibleSchemaVersion column value.
        /// </summary>
        string CompatibleSchemaVersion { get; set; }
        /// <summary>
        /// Gets or sets the IsCurrentVersion column value.
        /// </summary>
        bool IsCurrentVersion { get; set; }
    }
}
