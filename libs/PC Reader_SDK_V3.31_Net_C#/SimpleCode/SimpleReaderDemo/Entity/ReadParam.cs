using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleReaderDemo.Entity
{
    public class ReadParam
    {
        #region 匹配读参数
        /// <summary>
        /// 匹配类型 EPC||TID
        /// </summary>
        public int MatchType { get; set; }
        /// <summary>
        /// 匹配起始索引
        /// </summary>
        public int MatchIndex { get; set; }
        /// <summary>
        /// 匹配编码
        /// </summary>
        public string MatchCode { get; set; } 
        #endregion

        #region TID参数
        /// <summary>
        /// 读取模式
        /// </summary>
        public int TIDReadType { get; set; }
        /// <summary>
        /// 读取长度
        /// </summary>
        public int TIDReadLen { get; set; }
        #endregion

        #region 用户区参数
        /// <summary>
        /// 起始地址
        /// </summary>
        public int UserDataStartIndex { get; set; }
        /// <summary>
        /// 读取长度
        /// </summary>
        public int UserDataLen { get; set; }
        #endregion
        #region 用户区参数
        /// <summary>
        /// 起始地址
        /// </summary>
        public int ReserveStartIndex { get; set; }
        /// <summary>
        /// 读取长度
        /// </summary>
        public int ReserveDataLen { get; set; }
        #endregion
        #region EPCData参数
          /// <summary>
        /// 起始地址
        /// </summary>
        public int EPCDataStartIndex { get; set; }
        /// <summary>
        /// 读取长度
        /// </summary>
        public int EPCDataLen { get; set; }
        #endregion
        #region 访问密码
        public string pwd { get; set; }
        #endregion
    }
}
