using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocketDemo.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Commands
{
    public class Hello : CommandBase<MySession, StringRequestInfo>
    {

        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            session.Send(string.Format("Hello {0}:{1}   {2}", session.Config.Ip, session.Config.Port, requestInfo.Body));
        }
    }
}
