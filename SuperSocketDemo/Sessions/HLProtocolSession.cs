﻿using SuperSocket.SocketBase;
using SuperSocketDemo.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Sessions
{
    public class HLProtocolSession : AppSession<HLProtocolSession, HLProtocolRequestInfo>
    { /// <summary>  
        /// 新连接  
        /// </summary>  
        protected override void OnSessionStarted()
        {
            //输出客户端IP地址  
            //Console.WriteLine(this.LocalEndPoint.Address.ToString());
            this.Send("Hello User,Welcome to SuperSocket Telnet Server!");
        }

        /// <summary>  
        /// 未知的Command  
        /// </summary>  
        /// <param name="requestInfo"></param>  
        protected override void HandleUnknownRequest(HLProtocolRequestInfo requestInfo)
        {
            this.Send("unknow HLProtocolRequestInfo");
        }

        /// <summary>  
        /// 捕捉异常并输出  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void HandleException(Exception e)
        {
            this.Send("error: {0}", e.Message);
        }

        /// <summary>  
        /// 连接关闭  
        /// </summary>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }
    }
}
