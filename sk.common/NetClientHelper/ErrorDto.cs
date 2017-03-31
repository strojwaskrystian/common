using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace sk.common.NetClientHelper
{
    public class ErrorDto
    {
        public string Message { get; set; }

        // other fields

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
