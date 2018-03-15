using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol
{
    public class CustomReceiveFilter : IReceiveFilter<StringRequestInfo>
    {
        private string temp = string.Empty;//尚未处理的临时数据
        public StringRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            rest = 0;
            string input = Encoding.UTF8.GetString(readBuffer, offset, length);
            if (!string.IsNullOrEmpty(temp))
            {
                input = temp + input;
            }
            string pattern = @"(?<=^\[length=)(\d+)(?=\])";
            if (Regex.IsMatch(input, pattern))//协议头完整
            {
                Match m = Regex.Match(input, pattern);
                int outputLen = Convert.ToInt32(m.Groups[0].Value);
                int startIndex = input.IndexOf(']') + 1;
                string output = input.Substring(startIndex);

                if (outputLen == output.Length)//如果output的长度与消息字符串的应有长度相等，说明刚好是完整的一条信息
                {
                    string key = output.Split(' ')[0];
                    string body = output.Split(' ')[1];
                    string[] parameters = body.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    temp = string.Empty;
                    rest = 0;
                    return new StringRequestInfo(key, body, parameters);
                }
                else if (output.Length > outputLen)//如果output的长度大于消息字符串的应有长度，说明消息发完整了，但是有多余的数据，多余的数据可能是截断消息，也可能是多条完整消息
                {
                    string oneMsgContent = output.Substring(0, outputLen);
                    string key = oneMsgContent.Split(' ')[0];
                    string body = oneMsgContent.Split(' ')[1];
                    string[] parameters = body.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    rest = length - startIndex - outputLen;
                    return new StringRequestInfo(key, body, parameters);
                }
                else//如果output的长度小于消息字符串的应有长度，说明没有发完整，则应将整条信息，包括元数据，全部缓存，与下一条数据合并起来再进行处理
                {
                    temp = input;
                    return null;
                }
            }
            else//协议头不完整
            {
                temp = input;
                return null;
            }
        }


        public int LeftBufferSize
        {
            get;
            set;
        }

        public IReceiveFilter<StringRequestInfo> NextReceiveFilter
        {
            get;
            set;
        }

        public void Reset()
        {

        }

        public FilterState State
        {
            get;
            set;
        }
    }
}
