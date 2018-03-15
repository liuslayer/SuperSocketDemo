using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocketDemo.Protocol.Factory;
using SuperSocketDemo.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.AppServers
{
    public class FileServer : AppServer<FileSession, StringRequestInfo>
    {
         /// <summary>
        /// 使用自定义协议工厂
        /// </summary>
        public FileServer()
            : base(new FileReceiveFilterFactory())
        {

        }


        protected override void OnStarted()
        {
            base.OnStarted();
            Console.WriteLine("服务器启动FileServer");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(FileSession session)
        {
            base.OnNewSessionConnected(session);
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(FileSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.Write("\r\n" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            Console.WriteLine("服务已停止");
        }
    }
}
