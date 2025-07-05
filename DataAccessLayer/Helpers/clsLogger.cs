using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers
{
    internal class clsLogger
    {
        public delegate void LogAction(Exception ex);
        private LogAction _logAction;
        public clsLogger(LogAction LogAction)
        {
            _logAction = LogAction;
        }
        public void Log(Exception ex)
        {
            _logAction.Invoke(ex);
        }
    }
}
