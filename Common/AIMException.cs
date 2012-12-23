using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace AIM.Common
{
    public class AIMException : Exception
    {
        protected string _Message;

        public override string Message
        {
            get
            {
                return _Message;
            }
        }

        public AIMException()
        {
            // Add implementation.
        }
        public AIMException(string message)
        {
            _Message = message;
        }
        public AIMException(string message, Exception inner)
        {
            _Message = message;
        }

        // This constructor is needed for serialization.
        protected AIMException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }

    }
}
