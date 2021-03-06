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
    /// Interface representing the dbo.aspnet_WebEvent_Events table.
    /// </summary>
    public interface IAspnetWebEventEvents
    {
        /// <summary>
        /// Gets or sets the EventId column value.
        /// </summary>
        string EventId { get; set; }
        /// <summary>
        /// Gets or sets the EventTimeUtc column value.
        /// </summary>
        System.DateTime EventTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets the EventTime column value.
        /// </summary>
        System.DateTime EventTime { get; set; }
        /// <summary>
        /// Gets or sets the EventType column value.
        /// </summary>
        string EventType { get; set; }
        /// <summary>
        /// Gets or sets the EventSequence column value.
        /// </summary>
        decimal EventSequence { get; set; }
        /// <summary>
        /// Gets or sets the EventOccurrence column value.
        /// </summary>
        decimal EventOccurrence { get; set; }
        /// <summary>
        /// Gets or sets the EventCode column value.
        /// </summary>
        int EventCode { get; set; }
        /// <summary>
        /// Gets or sets the EventDetailCode column value.
        /// </summary>
        int EventDetailCode { get; set; }
        /// <summary>
        /// Gets or sets the Message column value.
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// Gets or sets the ApplicationPath column value.
        /// </summary>
        string ApplicationPath { get; set; }
        /// <summary>
        /// Gets or sets the ApplicationVirtualPath column value.
        /// </summary>
        string ApplicationVirtualPath { get; set; }
        /// <summary>
        /// Gets or sets the MachineName column value.
        /// </summary>
        string MachineName { get; set; }
        /// <summary>
        /// Gets or sets the RequestUrl column value.
        /// </summary>
        string RequestUrl { get; set; }
        /// <summary>
        /// Gets or sets the ExceptionType column value.
        /// </summary>
        string ExceptionType { get; set; }
        /// <summary>
        /// Gets or sets the Details column value.
        /// </summary>
        string Details { get; set; }
    }
}
