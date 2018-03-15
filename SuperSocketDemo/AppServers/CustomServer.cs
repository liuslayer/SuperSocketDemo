using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocketDemo.Protocol;
using SuperSocketDemo.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.AppServers
{
    public class CustomServer : AppServer<CustomSession, StringRequestInfo>
    {
         /// <summary>
        /// 使用自定义协议工厂
        /// </summary>
        public CustomServer()
            : base(new CustomReceiveFilterFactory())
        {
        }

        protected override void OnStarted()
        {
            base.OnStarted();
            Console.WriteLine("服务器启动CustomServer");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(CustomSession session)
        {
            base.OnNewSessionConnected(session);
            //输出客户端IP地址  
            Console.WriteLine("\r\n" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":连接");
            foreach (CustomSession customSession in this.GetAllSessions())
            {
                customSession.Send(string.Format("当前在线用户数：{0}\n", this.SessionCount.ToString()));
            }
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(CustomSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.Write("\r\n" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":断开连接");
            foreach (CustomSession customSession in this.GetAllSessions())
            {
                customSession.Send(string.Format("当前在线用户数：{0}\n", this.SessionCount.ToString()));
            }
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            Console.WriteLine("服务已停止");
        }
    }
}
