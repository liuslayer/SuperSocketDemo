using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketEngine;
using SuperSocketDemo.AppServers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start the server!");

            //Console.ReadKey();
            //Console.WriteLine();

            //var appServer = new CustomServer();

            //IRootConfig rootConfig = new RootConfig()
            //{
            //    MaxWorkingThreads = 5000,
            //    MinWorkingThreads = 10,
            //    MaxCompletionPortThreads = 5000,
            //    MinCompletionPortThreads = 10,
            //    DisablePerformanceDataCollector = true,
            //    PerformanceDataCollectInterval = 60,
            //    LogFactory = "Log4NetLogFactory",
            //    Isolation = IsolationMode.None
            //};

            //IServerConfig serverconfig = new ServerConfig()
            //{

            //    Name = "MyServerA",
            //    ServerType = "SuperSocketDemo.AppServers.CustomServer, SuperSocketDemo",
            //    Ip = "192.168.1.14",
            //    Port = 2012,
            //    ListenBacklog = 10,
            //    Mode = SocketMode.Tcp,
            //    Disabled = false,
            //    //StartupOrder
            //    //SendTimeOut                                    
            //    SendingQueueSize = 5,
            //    MaxConnectionNumber = 5000,
            //    ReceiveBufferSize = 65535,
            //    SendBufferSize = 65535,
            //    SyncSend = false,
            //    LogCommand = false,
            //    LogBasicSessionActivity = true,
            //    LogAllSocketException = false,
            //    ClearIdleSession = true,
            //    ClearIdleSessionInterval = 120,
            //    IdleSessionTimeOut = 300,
            //    //Security                  
            //    MaxRequestLength = 65535,
            //    TextEncoding = "gb2312",
            //    //DefaultCulture            
            //    DisableSessionSnapshot = false,
            //    SessionSnapshotInterval = 5,
            //    KeepAliveTime = 600,
            //    KeepAliveInterval = 60,
            //    //Certificate
            //    //ConnectionFilter
            //    //CommandLoader
            //    //LogFactory
            //    //Listeners
            //    //ReceiveFilterFactory
            //};

            ////Setup the appServer
            //if (!appServer.Setup(rootConfig, serverconfig)) //Setup with listening port
            //{
            //    Console.WriteLine("Failed to setup!");
            //    Console.ReadKey();
            //    return;
            //}

            //Console.WriteLine();

            ////Try to start the appServer
            //if (!appServer.Start())
            //{
            //    Console.WriteLine("Failed to start!");
            //    Console.ReadKey();
            //    return;
            //}

            //Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            //while (Console.ReadKey().KeyChar != 'q')
            //{
            //    Console.WriteLine();
            //    continue;
            //}

            ////Stop the appServer
            //appServer.Stop();

            //Console.WriteLine("The server was stopped!");
            //Console.ReadKey();



            Console.WriteLine("请按任何键进行启动SuperSocket服务!");
            Console.ReadKey();
            Console.WriteLine();
            var bootstrap = BootstrapFactory.CreateBootstrap();

            if (!bootstrap.Initialize())
            {
                Console.WriteLine("初始化失败!");
                Console.ReadKey();
                return;
            }

            var result = bootstrap.Start();

            Console.WriteLine("服务正在启动: {0}!", result);

            if (result == StartResult.Failed)
            {
                Console.WriteLine("服务启动失败!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("服务启动成功，请按'q'停止服务!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            //停止服务
            // appServer.Stop();
            bootstrap.Stop();
            Console.WriteLine("服务已停止!");
            Console.ReadKey();
        }
    }
}
