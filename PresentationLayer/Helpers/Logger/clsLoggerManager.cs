using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
namespace PresentationLayer.Helpers.Logs
{
    internal class clsLoggerManager
    {
        //public delegate void LogAction(Exception ex);
        //LogAction _LogAction;
        Action<Exception> _LogAction;
        public clsLoggerManager(Action<Exception> LogMethod)
        {
            _LogAction = LogMethod;
        }
        public void Log(Exception ex)
        {
            _LogAction?.Invoke(ex);
        }

    }
}
