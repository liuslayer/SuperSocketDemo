using SuperSocketDemo.Common;
using SuperSocket.Facility.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol
{
    public class HLBeginEndMarkReceiveFilter : BeginEndMarkReceiveFilter<HLProtocolRequestInfo>
    {

        private readonly static char strBegin = '&';
        private readonly static char strEnd = '#';
        //开始和结束标记也可以是两个或两个以上的字节
        private readonly static byte[] BeginMark = new byte[] { (byte)strBegin };
        private readonly static byte[] EndMark = new byte[] { (byte)strEnd };

        public HLBeginEndMarkReceiveFilter()
            : base(BeginMark, EndMark)
        {

        }
        protected override HLProtocolRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            //260100194E4A30313101444131313200070000000000003423
            var HLData = new HLData();
            HLData.Head = strBegin;//自己定义开始符号
            HLData.Ping = readBuffer[offset+1];//数据，从第1位起，只有1个字节
            HLData.Lenght = BitConverter.ToUInt16(readBuffer, offset + 2);//数据长度，从第2位开始，2个字节
            HLData.FID = BitConverter.ToUInt32(readBuffer, offset + 4);//本终端ID，从第4位开始，5个字节
            HLData.Type = readBuffer[offset + 9];//目标类型，从第9位开始，1个字节
            HLData.SID = BitConverter.ToUInt32(readBuffer, offset + 10);//转发终端ID，从第10位开始，5个字节
            HLData.SendCount = BitConverter.ToUInt16(readBuffer, offset + 15);//发送包计数，从第15位开始，2个字节
            HLData.Retain = readBuffer.CloneRange(offset + 17, 6);//保留字段，从17位开始，6个字节
            HLData.Check = readBuffer[offset + 23];//异或校验，从23位开始，1个字节
            HLData.End = strEnd;//结束符号，自己定义
            return new HLProtocolRequestInfo(HLData);
        }
    }
}
