using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIM.Data;
using System.Runtime.Serialization;
namespace AIM.Common
{
    public class AccountSetupException:AIMException
    {

        public AccountSetupException()
        {
            // Add implementation.
        }
        public AccountSetupException(string message)
        {
            _Message = message;
        }
        public AccountSetupException(string message, Exception inner)
        {
            _Message = message;
        }
        public AccountSetupException(string message, Exception inner,IClient client)
        {
            _Message = message;
        }
        // This constructor is needed for serialization.
        protected AccountSetupException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }
    }
}
