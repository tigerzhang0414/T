using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace T.Common.Entities
{
    public class XException : Exception
    {
        public new string Message;

        public XException(Exception ex)
        {
            Message = ex.Message;
            var anex = ex as ArgumentNullException;
            if (anex != null) Message += anex.StackTrace;

            var nrex = ex as NullReferenceException;
            if (nrex != null) Message += nrex.StackTrace;

            var evex = ex as DbEntityValidationException;
            if (evex != null && evex.EntityValidationErrors.Any())
            {
                foreach (var res in evex.EntityValidationErrors)
                {
                    foreach (var error in res.ValidationErrors)
                    {
                        Message += string.Format("{0}:{1}", res.Entry.Entity, error.ErrorMessage);
                    }
                }
            }

            var uex = ex as DbUpdateException;
            if (uex != null && uex.InnerException != null)
            {
                var ie = uex.InnerException.InnerException;
                if (ie != null) Message += uex.InnerException.InnerException.Message;
            }
        }
        public XException() : base() { }
        public XException(string message) : base(message) { }
        public XException(string message, Exception inner) : base(message, inner) { }
        public XException(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
    }
}
