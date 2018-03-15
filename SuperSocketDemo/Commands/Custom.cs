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
    public class Custom : CommandBase<CustomSession, StringRequestInfo>
    {
        public override void ExecuteCommand(CustomSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine(requestInfo.Body);
            session.Send(requestInfo.Body);
        }
    }
}
