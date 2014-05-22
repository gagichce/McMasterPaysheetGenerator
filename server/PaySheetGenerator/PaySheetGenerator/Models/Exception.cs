using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaySheetGenerator.Models
{
    public class BaseException : HttpException
    {
        public enum Fault
        {
            Server, User
        }
        public enum Cause
        {
            Unknown, Unspecified, UnsupportAction, NotFound
        }
        private static string FormatMessage(Fault fault, string msg, Cause cause = Cause.Unknown, string param = "")
        {
            var faultName = System.Enum.GetName(typeof(Fault), fault);
            faultName = faultName.Replace("|", "||");
            msg = msg.Replace("|", "||");
            param = param.Replace("|", "||");
            var causeName = System.Enum.GetName(typeof(Cause), cause);
            return String.Format("{0}|{1}|{2}|{3}", faultName, msg, causeName, param);
        }
        public BaseException(int httpStatusCode, Fault fault, string msg, Cause cause = Cause.Unknown)
            : base(httpStatusCode, FormatMessage(fault, msg, cause)) { }
    }
    public class ServerException : BaseException
    {
        public ServerException(string msg, int httpStatusCode = 500, Cause cause = Cause.Unknown)
            : base(httpStatusCode, BaseException.Fault.Server, msg, cause) { }
    }
    public class UserException : BaseException
    {
        public UserException(string msg, int httpStatusCode = 400, Cause cause = Cause.Unknown)
            : base(httpStatusCode, BaseException.Fault.User, msg, cause) { }
    }
}