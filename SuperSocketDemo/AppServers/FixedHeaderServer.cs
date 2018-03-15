﻿using SuperSocket.SocketBase;
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
    class FixedHeaderServer : AppServer<MyBinarySession,BinaryRequestInfo>
    {
        public FixedHeaderServer()
            : base(new DefaultReceiveFilterFactory<MyFixedHeaderReceiveFilter,BinaryRequestInfo>())
        {

        }

        protected override void OnStarted()
        {
            base.OnStarted();
            Console.WriteLine("服务器启动FixedHeaderServer");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(MyBinarySession session)
        {
            base.OnNewSessionConnected(session);
            //输出客户端IP地址  
            Console.WriteLine("\r\n" + session.RemoteEndPoint.Address.ToString() + ":连接");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(MyBinarySession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.Write("\r\n" + session.RemoteEndPoint.Address.ToString() + ":断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            Console.WriteLine("服务已停止");
        }
    }
}
