using System;
using System.Runtime.Serialization;

namespace Base
{
    [Serializable]
    public class GameDKException : Exception
    {
        public GameDKException() : base() { }
        public GameDKException(string message) : base(message) { }
        public GameDKException(string message, Exception innerException) : base(message, innerException) { }
        protected GameDKException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}