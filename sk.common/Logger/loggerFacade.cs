using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace sk.common.Logger
{
    public class loggerFacade : IloggerFacade
    {
        private ILogger _logger;

        public ILogger Logger { get => _logger;}

        public loggerFacade(ILogger<loggerFacade> logger)
        {
            _logger = logger;
            
        }

        public string LogException(Exception ex, string extrainfo = "", dynamic paraminfo = null)
        {
            var msgExp = new List<string>();
            var prepareStringException = string.Empty;

            var info = "Processed {@SensorInput} ";


            if (paraminfo != null)
            {
                var sb = new StringBuilder();
                foreach (PropertyInfo pi in paraminfo.GetType().GetProperties())
                {
                    sb.AppendFormat("{0}: {1} ", pi.Name, pi.GetValue(paraminfo, null));
                }

                info += sb.ToString();
            }

            _logger.LogInformation(info, extrainfo);

            if (ex.InnerException != null)
            {
                var exception = ex.InnerException;

                while (exception != null)
                {
                    msgExp.Add(exception.Message);
                    exception = exception.InnerException;
                }

                if (msgExp.Count > 0)
                {
                    foreach (var item in msgExp)
                    {
                        _logger.LogError("inerException: " + item);

                        if (prepareStringException.Length > 0)
                        {
                            prepareStringException += Environment.NewLine;
                        }
                        prepareStringException += item;
                    }
                }
            }
            else
            {
                prepareStringException = ex.Message;
                _logger.LogError(ex.Message);
            }

            return prepareStringException;
        }

        public string LogExceptionStack(Exception ex, string extrainfo = "", dynamic paraminfo = null)
        {
            var msgExp = new List<string>();
            var prepareStringException = string.Empty;

            var info = "Processed {@SensorInput} ";


            if (paraminfo != null)
            {
                var sb = new StringBuilder();
                foreach (PropertyInfo pi in paraminfo.GetType().GetProperties())
                {
                    sb.AppendFormat("{0}: {1} ", pi.Name, pi.GetValue(paraminfo, null));
                }

                info += sb.ToString();
            }

            _logger.LogInformation(info, extrainfo);

            if (ex.InnerException != null)
            {
                var exception = ex.InnerException;

                while (exception != null)
                {
                    msgExp.Add(exception.Message);
                    exception = exception.InnerException;
                }

                if (msgExp.Count > 0)
                {
                    foreach (var item in msgExp)
                    {
                        if (prepareStringException.Length > 0)
                        {
                            prepareStringException += Environment.NewLine;
                        }
                        prepareStringException += item;
                    }
                }
            }
            else
            {
                prepareStringException = ex.Message;
            }

            _logger.LogError(new EventId(1), ex, ex.Message);
            return prepareStringException;
        }

        public void LogInfo(string info, string extrainfo = "", dynamic paraminfo = null)
        {
            _logger.LogInformation(info, extrainfo);
        }

        public void LogError(string info, string extrainfo = "", dynamic paraminfo = null)
        {
            _logger.LogError(info, extrainfo);
        }


    }
}
