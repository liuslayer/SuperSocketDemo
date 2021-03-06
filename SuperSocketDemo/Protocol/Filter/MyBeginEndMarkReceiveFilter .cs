﻿using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol
{
    public class MyBeginEndMarkReceiveFilter : BeginEndMarkReceiveFilter<StringRequestInfo>
    {
        //开始和结束标记也可以是两个或两个以上的字节
        private readonly static byte[] BeginMark = new byte[] { (byte)'&' };
        private readonly static byte[] EndMark = new byte[] { (byte)'#' };

        public MyBeginEndMarkReceiveFilter()
            : base(BeginMark, EndMark) //传入开始标记和结束标记
        {

        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            string str = Encoding.Default.GetString(readBuffer, offset, length);
            str = str.TrimStart('&').TrimEnd('#');
            string key = str.Split(':')[0];
            string body = str.Split(':')[1];
            string[] parameters = body.Split(',');
            return new StringRequestInfo(key, body, parameters);
        }
    }
}
