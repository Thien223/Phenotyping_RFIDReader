using System;
using System.Text;

namespace SimpleReaderDemo.Win32
{
    /// <summary>
    /// Win32 API constant
    /// </summary>
    public class Consts
    {
        #region Result
        /// <summary>
        /// 1 true
        /// </summary>
        public static readonly IntPtr TRUE = new IntPtr(1);
        /// <summary>
        /// 0 false
        /// </summary>
        public static readonly IntPtr FALSE = new IntPtr(0);
        #endregion

        #region mouse_event
        /// <summary>
        /// Moving the mouse
        /// </summary>
        public const int MOUSEEVENTF_MOVE = 0x0001;
        /// <summary>
        /// Press the left mouse button
        /// </summary>
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        /// <summary>
        /// Release the left mouse button
        /// </summary>
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        /// <summary>
        /// Press the right mouse button
        /// </summary>
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        /// <summary>
        /// Release the left mouse button
        /// </summary>
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        /// <summary>
        /// Press the middle mouse button
        /// </summary>
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        /// <summary>
        /// Release the middle mouse button
        /// </summary>
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        /// <summary>
        /// Indicate whether absolute coordinates are used 
        /// </summary>
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        #endregion

        #region keybd_event
        /// <summary>
        /// Lift button
        /// </summary>
        public const int KEYEVENTF_KEYUP = 0x0002;
        /// <summary>
        /// Press the button
        /// </summary>
        public const int KEYEVENTF_KEYDOWN = 0x0000;

        #endregion

        #region OpenProcess
        /// <summary>
        /// Access to all possible process objects
        /// </summary>
        public const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        /// <summary>
        /// Need to read the process in memory should use ReadProcessMemory
        /// </summary>
        public const int PROCESS_VM_READ = 0x0010;
        /// <summary>
        /// Need to write process in memory, you should use WriteProcessMemory
        /// </summary>
        public const int PROCESS_VM_WRITE = 0x0020;
        #endregion

        #region ULW
        /// <summary>
        /// 
        /// </summary>
        public const Int32 ULW_COLORKEY = 0x00000001;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 ULW_ALPHA = 0x00000002;
        /// <summary>
        /// 
        /// </summary>
        public const Int32 ULW_OPAQUE = 0x00000004;
        #endregion

        #region AC_SRC
        /// <summary>
        /// 
        /// </summary>
        public const byte AC_SRC_OVER = 0x00;
        /// <summary>
        /// 
        /// </summary>
        public const byte AC_SRC_ALPHA = 0x01;
        #endregion
    }
}
