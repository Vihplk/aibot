using System;
namespace AIBot.Core.Utility
{
    public class RecordNotFound : Exception
    {
        public RecordNotFound(string exception):base(exception)
        {
        }
        public RecordNotFound() : this("record not found")
        {
        }
    }
    public class OverExamException : Exception
    {
        public OverExamException(string exception) : base(exception)
        {
        }
        public OverExamException() : this("record not found")
        {
        }
    }
}
