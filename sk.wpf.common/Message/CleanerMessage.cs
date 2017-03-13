using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sk.wpf.common.Message
{
    public class CleanerMessage
    {
        public enum CleanerMessageOption
        {
            cleanAll,
            cleanByName
        }
        public CleanerMessageOption Option { get; set; }        
        public string CleanerName { get; set; }
    }
}
