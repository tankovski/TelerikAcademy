namespace CoolBlog.WebApi.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name = "Error")]
    public class ServerErrorException : Exception
    {
        public ServerErrorException()
            : base()
        {
        }

        public ServerErrorException(string msg)
            : base(msg)
        {
        }

        public ServerErrorException(string msg, string errCode)
            : base(msg)
        {
            this.ErrorCode = errCode;
        }

        //[DataMember(Name="message")]
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }

        //[DataMember(Name = "errCode")]
        public string ErrorCode { get; set; }
    }
}