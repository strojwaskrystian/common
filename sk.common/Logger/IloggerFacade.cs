using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace sk.common.Logger
{
    public interface IloggerFacade
    {
        string LogException(Exception ex, string extrainfo = "", dynamic paraminfo = null);
        string LogExceptionStack(Exception ex, string extrainfo = "", dynamic paraminfo = null);
        void LogInfo(string info, string extrainfo = "", dynamic paraminfo = null);
        void LogError(string info, string extrainfo = "", dynamic paraminfo = null);

        ILogger Logger { get; }
    }
}
