using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sk.common.ExceptionModel
{
    public class ResponseModelStatus
    {
        private const bool isModelStatusException = true;


        public bool IsModelStatusException => isModelStatusException;

        private List<ResponseModelMessage> _messages;

        public ResponseMainModelStatusEnum ResponseStatus { set; get; }

        public List<ResponseModelMessage> Messages
        {
            get { return _messages ?? (_messages = new List<ResponseModelMessage>()); }
            set
            {
                _messages = value;
            }
        }

        public bool CheakMessageForError()
        {
            if (Messages == null) return false;
            if (Messages.Any(a => a.ResponseStatus == ResponseModelStatusEnum.Error))
            {
                ResponseStatus = ResponseMainModelStatusEnum.Error;
                return true;
            }
            if (Messages.Any(a => a.ResponseStatus == ResponseModelStatusEnum.Warning))
            {
                ResponseStatus = ResponseMainModelStatusEnum.Warning;
                return true;
            }

            return false;
        }
    }
}
