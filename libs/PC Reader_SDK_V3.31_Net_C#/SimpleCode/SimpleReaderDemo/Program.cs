using SimpleReader.Resource;
using RFIDReaderAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace SimpleReaderDemo
{
    static class Program
    {
        public static RFIDReaderAPI.RFID_Option RFID_OPTION = new RFIDReaderAPI.RFID_Option();
        public static RFIDReaderAPI.Param_Option PARAM_SET = new RFIDReaderAPI.Param_Option();
        public static RFIDReaderAPI.Test_Option TEST_OPTION = new RFIDReaderAPI.Test_Option();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //处理未捕获的异常  
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常  
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常  
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                string strLanguage = System.Configuration.ConfigurationSettings.AppSettings["Language"].ToString();
                if (strLanguage.Trim().Equals("en"))
                {
                    _RC.SetCurrentCulture("en-US");
                    Helper.LanguageHelper.LanguageType = 1;
                    RFIDReader.SetAPILanguageType(eAPILanguage.English);            // 设置API英文
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    SingleMainForm.IsEnglish = true;
                }
                else 
                {
                    _RC.SetCurrentCulture("zh-CN");
                    Helper.LanguageHelper.LanguageType = 0;
                    RFIDReader.SetAPILanguageType(0);            // 设置API中文
                }
                Application.Run(new SingleMainForm());
            }
            catch (Exception ex)
            {
                string str = "";
                string strDateInfo = "Unprocessed Exception：" + DateTime.Now.ToString() + "\r\n";
                if (ex != null)
                {
                    str = string.Format(strDateInfo + "Exception Type：{0}\r\nException Message：{1}\r\nException Message：{2}\r\n",
                       ex.GetType().Name, ex.Message, ex.StackTrace);
                }
                else
                {
                    str = string.Format("Application Thread Error:{0}", ex);
                }

                writeLog(str);
                MessageBox.Show("Fatal Error,Please contact after sales personnel！", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            string str = "";
            string strDateInfo = "Unprocessed Exception：" + DateTime.Now.ToString() + "\r\n";
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "Exception Type：{0}\r\nException Message：{1}\r\nException Message：{2}\r\n",
                   error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("Application Thread Error:{0}", e);
            }
            writeLog(str);
            MessageBox.Show("Fatal Error,Please contact after sales personnel！", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = "";
            Exception error = e.ExceptionObject as Exception;
            string strDateInfo = "Unprocessed Exception：" + DateTime.Now.ToString() + "\r\n";
            if (error != null)
            {
                str = string.Format(strDateInfo + "Application UnhandledException:{0};\n\rStack Message:{1}", error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("Application UnhandledError:{0}", e);
            }
            writeLog(str);
            MessageBox.Show("Fatal Error,Please contact after sales personnel！", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void writeLog(string str)
        {
            if (!Directory.Exists("ErrLog"))
            {
                Directory.CreateDirectory("ErrLog");
            }
            using (StreamWriter sw = new StreamWriter(@"ErrLog\ErrLog.txt", true))
            {
                sw.WriteLine(str);
                sw.WriteLine("---------------------------------------------------------");
                sw.Close();
            }
        }
    }
}
