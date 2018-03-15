using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol.Filter
{
    public class FileReceiveFilter : BeginEndMarkReceiveFilter<StringRequestInfo>
    {
        private readonly static byte[] BeginMark = Encoding.UTF8.GetBytes("<protocol>");
        private readonly static byte[] EndMark = Encoding.UTF8.GetBytes("</protocol>");
        public FileReceiveFilter()
            : base(BeginMark, EndMark)
        {

        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            string input = Encoding.UTF8.GetString(readBuffer, offset, length);
            return new StringRequestInfo("File", input, null);
        }
    }
}
