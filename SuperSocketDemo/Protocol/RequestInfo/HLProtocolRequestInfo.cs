using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol
{
    public class HLProtocolRequestInfo : RequestInfo<HLData>
    {
        public HLProtocolRequestInfo(HLData hlData)
            : base("PutHLData", hlData)
        {
            //如果需要使用命令行协议的话，那么命令类名称HLData相同
            //Initialize("PutHLData", hlData);
        }
    }
}
