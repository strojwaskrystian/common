using System;
using System.Collections.Generic;
using System.Text;

namespace sk.common.ExceptionModel
{
    public class ResponseModelMessage
    {
        public ResponseModelStatusEnum ResponseStatus { set; get; }
        public string Key { set; get; }
        public string Message { set; get; }
    }
}
