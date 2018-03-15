using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.AppServers
{
    public interface IDespatchServer
    {
        void DispatchMessage(string sessionKey, string message);
    }
}
