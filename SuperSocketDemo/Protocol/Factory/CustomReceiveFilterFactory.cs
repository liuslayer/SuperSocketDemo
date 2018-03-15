using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol
{
    public class CustomReceiveFilterFactory : IReceiveFilterFactory<StringRequestInfo>
    {

        public IReceiveFilter<StringRequestInfo> CreateFilter(SuperSocket.SocketBase.IAppServer appServer, SuperSocket.SocketBase.IAppSession appSession, System.Net.IPEndPoint remoteEndPoint)
        {
            return new CustomReceiveFilter();
        }
    }
}
