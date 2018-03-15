using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketDemo.Protocol
{
    public class HLData
    {
        /// <summary>
        /// 开始符号
        /// </summary>
        public char Head { get; set; }
        /// <summary>
        /// 协议包数据
        /// </summary>
        public byte Ping { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public ushort Lenght { get; set; }
        /// <summary>
        /// 终端ID
        /// </summary>
        public uint FID { get; set; }
        /// <summary>
        /// 目标类型
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 转发终端ID
        /// </summary>
        public uint SID { get; set; }
        /// <summary>
        /// 发送计数
        /// </summary>
        public ushort SendCount { get; set; }
        /// <summary>
        /// 保留字段
        /// </summary>
        public byte[] Retain { get; set; }
        /// <summary>
        /// 异或校验
        /// </summary>
        public byte Check { get; set; }
        /// <summary>
        /// 结束符号
        /// </summary>
        public char End { get; set; }

        public override string ToString()
        {
            return string.Format("开始符号:{0},包数据:{1},数据长度:{2},终端ID:{3},目标类型:{4},转发终端ID:{5},发送包计数：{6},保留字段:{7},异或校验:{8},结束符号:{9}",
                Head, Ping, Lenght, FID, Type, SID, SendCount, Retain, Check, End);
        }
    }
}
