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
    public class TestBinary : CommandBase<MyBinarySession, BinaryRequestInfo>
    {
        public override void ExecuteCommand(MyBinarySession session, BinaryRequestInfo requestInfo)
        {
            session.Send(requestInfo.Body.ToString());
        }
    }
}
