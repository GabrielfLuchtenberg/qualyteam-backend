using System;
namespace DocumentsApi.Exceptions
{
    public class NotUniqueKeyException : Exception
    {
        public NotUniqueKeyException(string message) : base(message){}
    }
}