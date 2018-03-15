using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Common
{
    public static class CommonUtils
    {
        public static byte[] CloneRange(this byte[] srcByte, int offset, int length)
        {
            byte[] desByte = new byte[length];
            Buffer.BlockCopy(srcByte, offset, desByte, 0, length);
            return desByte;
        }
    }
}
