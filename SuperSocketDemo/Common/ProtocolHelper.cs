using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SuperSocketDemo.Common
{
    public class ProtocolHelper
    {
        private XmlNode fileNode;
        private XmlNode root;

        public ProtocolHelper(string protocol)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(protocol);
            root = doc.DocumentElement;
            fileNode = root.SelectSingleNode("file");
        }

        private FileRequestMode GetFileMode()
        {
            string mode = fileNode.Attributes["mode"].Value;
            mode = mode.ToLower();
            if (mode == "send")
            {
                return FileRequestMode.Send;
            }
            else
            {
                return FileRequestMode.Receive;
            }
        }

        public FileProtocol GetProtocol()
        {
            FileRequestMode mode = GetFileMode();
            int port = Convert.ToInt32(fileNode.Attributes["port"].Value);
            string fileName = fileNode.Attributes["name"].Value;
            return new FileProtocol(mode, port, fileName);
        }

    }

    public enum FileRequestMode
    {
        Send = 0,
        Receive = 1
    }

    public struct FileProtocol
    {
        private readonly FileRequestMode mode;
        private readonly int port;
        private readonly string fileName;

        public FileProtocol(FileRequestMode mode, int port, string fileName)
        {
            this.mode = mode;
            this.port = port;
            this.fileName = fileName;
        }

        public FileRequestMode Mode { get { return mode; } }
        public int Port { get { return port; } }
        public string FileName { get { return fileName; } }
        public override string ToString()
        {
            return string.Format("<protocol><file mode=\"{0}\" port=\"{1}\" name=\"{2}\" /></protocol>", mode, port, fileName);
        }
    }
}
