using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIM.Common.Types
{
    public class Enumerations
    {
        public enum WebformType
        {
            None,
            ActiveCustomer,
            NewCustomer,
            InactiveCustomer,
            Lead,
            LeadToCustomer,
            AutoNotification,
            AppointmentReminder
        }
        public enum ContactType
        {
            Customer,
            InactiveCustomer,
            Lead
        }

        public enum LogCategory
        {
            None,
            General,
            Workflows,
            PreConditions,
            Process,
            PostConditions

        }
    }
}
