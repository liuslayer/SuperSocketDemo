using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocketDemo.Common;
using SuperSocketDemo.Sessions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Commands
{
    public class File:CommandBase<FileSession, StringRequestInfo>
    {
        public override void ExecuteCommand(FileSession session, StringRequestInfo requestInfo)
        {
            string input = requestInfo.Body;
            ProtocolHelper helper = new ProtocolHelper(input);
            FileProtocol protocol = helper.GetProtocol();
            if (protocol.Mode == FileRequestMode.Send)
            {
                ReceiveFile(session, protocol);
            }
            else if (protocol.Mode == FileRequestMode.Receive)
            {
                SendFile(protocol);
            }
        }

        private void SendFile(FileProtocol protocol)
        {
            throw new NotImplementedException();
        }

        private void ReceiveFile(FileSession fileSession,FileProtocol protocol)
        {
            IPEndPoint endPoint = fileSession.RemoteEndPoint as IPEndPoint;
            IPAddress ip = endPoint.Address;
            endPoint = new IPEndPoint(ip, protocol.Port);
            TcpClient localClient;
            try
            {
                localClient = new TcpClient();
                localClient.Connect(endPoint);
            }
            catch
            {
                Console.WriteLine("无法连接到客户端-->{0}", endPoint);
                return;
            }

            NetworkStream streamToClient = localClient.GetStream();
            string path = Environment.CurrentDirectory + "/" + GernerateFileName(protocol.FileName);
            byte[] fileBuffer = new byte[1024];
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            int bytesRead;
            int totalBytes = 0;
            int bufferSize = 65535;
            byte[] buffer = new byte[bufferSize];
            try
            {
                do
                {
                    bytesRead = streamToClient.Read(buffer, 0, bufferSize);
                    fs.Write(buffer, 0, bytesRead);
                    totalBytes += bytesRead;
                    Console.WriteLine("Receiving {0} bytes...", totalBytes);
                } while (bytesRead > 0);
                Console.WriteLine("Total {0} bytes received,Done!", totalBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                streamToClient.Dispose();
                fs.Dispose();
                localClient.Close();
            }
        }

        private string GernerateFileName(string fileName)
        {
            DateTime now = DateTime.Now;
            return string.Format("{0}_{1}_{2}_{3}", now.Minute, now.Second, now.Millisecond, fileName);
        }
    }
}
