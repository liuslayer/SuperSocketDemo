using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocketDemo.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol
{
    public class HLReceiveFilterFactory : IReceiveFilterFactory<HLProtocolRequestInfo>
    {

        public IReceiveFilter<HLProtocolRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return new HLBeginEndMarkReceiveFilter();
        }
    }
}
