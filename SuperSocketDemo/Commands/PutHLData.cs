using SuperSocket.SocketBase.Command;
using SuperSocketDemo.Protocol;
using SuperSocketDemo.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Commands
{
    public class PutHLData : CommandBase<HLProtocolSession, HLProtocolRequestInfo>
    {
        public override void ExecuteCommand(HLProtocolSession session, HLProtocolRequestInfo requestInfo)
        {
            Console.WriteLine(requestInfo.Body.ToString());
            session.Send(requestInfo.Body.ToString());
        }
    }
}
