using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleReaderDemo.Helper
{
    public static class LanguageHelper
    {
        public static int LanguageType = 1;         // 0 中文     1 英文
        static bool isIntit = false;

        public static Dictionary<int, string> WriteResultCode = new Dictionary<int, string>() 
        {
            {0,"0|OK"},
            {1,"1|天线端口参数错误"},        // 天线端口参数错误
            {2,"2|选择参数错误"},            // 选择参数错误
            {3,"3|写入参数错误"},            // 写入参数错误
            {4,"4|CRC校验错误"},             // CRC校验错误
            {5,"5|功率不足"},        // 功率不足
            {6,"6|数据区溢出"},       // 数据区溢出
            {7,"7|数据区被锁定"},       // 数据区被锁定
            {8,"8|访问密码错误"},       // 访问密码错误
            {9,"9|其他标签错误"},       // 其他标签错误
            {10,"10|标签丢失"},       // 标签丢失
            {11,"11|读写器发送指令错误"}       // 读写器发送指令错误
        };
       
        /// <summary>
        /// 返回结果字典
        /// </summary>
        public static Dictionary<int, string> ReadResultCode = new Dictionary<int, string>() 
        {
            {0,"0|OK"},
            {1,"1|天线端口参数错误"},        // 天线端口参数错误
            {2,"2|选择读取参数错误"},        // 选择读取参数错误
            {3,"3|TID读取参数错误"},        // TID读取参数错误
            {4,"4|用户数据区读取参数错误"},        // 用户数据区读取参数错误
            {5,"5|保留区读取参数错误"},        // 保留区读取参数错误
            {6,"6|其他参数错误"}             // 失败
        };


        static void Intit() {
            if (LanguageType == 1)
            {
                for (int i = 1; i < WriteResultCode.Keys.Count; i++)
                {
                    try
                    {
                        WriteResultCode[i] = Properties.Resources.ResourceManager.GetString("Frame_0010_11_" + i);
                    }
                    catch { }
                }
                for (int i = 1; i < ReadResultCode.Keys.Count; i++)
                {
                    try
                    {
                        ReadResultCode[i] = Properties.Resources.ResourceManager.GetString("Frame_0010_10_" + i);
                    }
                    catch { }
                }
            }
            isIntit = true;
        }
        public static string GetResutlCode(int resultType, int key) {
            if (!isIntit)
            {
                Intit();
            }
            string result = "";
            if (key < 0 ) return "-2|TimeOut"; 
            if (resultType == 0) //read
            {
                result = ReadResultCode[key];
            }
            else // write
            {
                result = WriteResultCode[key];
            }
            return result;
        }
    }
}
