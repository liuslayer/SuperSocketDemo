using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol
{
    class MyFixedSizeReceiveFilter : FixedSizeReceiveFilter<StringRequestInfo>
    {
        public MyFixedSizeReceiveFilter()
            : base(7) //传入固定的请求大小
        {

        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] buffer, int offset, int length, bool toBeCopied)
        {
            string str = Encoding.Default.GetString(buffer, offset, length);
            string key = str.Split(':')[0];
            string body = str.Split(':')[1];
            string[] parameters = body.Split(',');
            return new StringRequestInfo(key, body, parameters);
        }
    }
}
