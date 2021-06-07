using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ILoggerManager
    {
        void Info(string msg);
        void Warning(string msg);
        void Debug(string msg);
        void Error(string msg);
    }
}
