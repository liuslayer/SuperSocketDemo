using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocketDemo.CommandFilter;
using SuperSocketDemo.Sessions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.AppServers
{
    [LogTimeCommandFilter]
    class MyServerB : AppServer<MySession>,IDespatchServer
    {
        public MyServerB()
            : base(new CommandLineReceiveFilterFactory(Encoding.Default, new BasicRequestInfoParser(":", ",")))
        { 
        
        }

        protected override void OnStarted()
        {
            base.OnStarted();
            Console.WriteLine("服务器启动MyServerB");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(MySession session)
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
        protected override void OnSessionClosed(MySession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.Write("\r\n" + session.RemoteEndPoint.Address.ToString() + ":断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            Console.WriteLine("服务已停止");
        }

        public void DispatchMessage(string sessionKey, string message)
        {
            //var session = this.GetSessionByID(sessionKey);
            //if (session == null)
            //    return;

            //session.Send(message);
            foreach (var session in this.GetAllSessions())
            {
                session.Send(message);
            }
        }

        //private string m_PolicyFile;

        //protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        //{
        //    m_PolicyFile = config.Options.GetValue("policyFile");

        //    if (string.IsNullOrEmpty(m_PolicyFile))
        //    {
        //        if (Logger.IsErrorEnabled)
        //            Logger.Error("Configuration option policyFile is required!");
        //        return false;
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// SubProtocol configuration
        ///// </summary>
        //public class SubProtocolConfig : ConfigurationElement
        //{
        //    //Configuration attributes
        //}
        ///// <summary>
        ///// SubProtocol configuation collection
        ///// </summary>
        //[ConfigurationCollection(typeof(SubProtocolConfig))]
        //public class SubProtocolConfigCollection : ConfigurationElementCollection
        //{
        //    //Configuration attributes
        //    protected override ConfigurationElement CreateNewElement()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    protected override object GetElementKey(ConfigurationElement element)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //private SubProtocolConfigCollection m_SubProtocols;

        //protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        //{
        //    m_SubProtocols = config.GetChildConfig<SubProtocolConfigCollection>("subProtocols");

        //    if (m_SubProtocols == null)
        //    {
        //        if (Logger.IsErrorEnabled)
        //            Logger.Error("The child configuration node 'subProtocols' is required!");
        //        return false;
        //    }
        //    return true;
        //}

        private int m_Interval;

        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            RegisterConfigHandler(config, "policyFile", (value) =>
            {
                // the code in this scope will be executed automatically
                // after the configuration attribute "pushInterval" is changed

                var interval = 0;
                int.TryParse(value, out interval);

                if (interval <= 0)
                    interval = 60;// 60 seconds by default

                m_Interval = interval * 1000;
                return true;
            });

            return true;
        }
    }
}
