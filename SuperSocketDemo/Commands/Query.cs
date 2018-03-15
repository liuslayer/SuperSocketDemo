using SuperSocket.SocketBase.Command;
using SuperSocketDemo.CommandFilter;
using SuperSocketDemo.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperSocketDemo.Commands
{
    public class Query : StringCommandBase<MySession>
    {
        public override void ExecuteCommand(MySession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            Thread.Sleep(6000);
            session.Send("Test CommandFilter!");
        }
    }
}
