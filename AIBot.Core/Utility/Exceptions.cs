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
    public class OverExam : Exception
    {
        public OverExam(string exception) : base(exception)
        {
        }
        public OverExam() : this("record not found")
        {
        }
    }
}
