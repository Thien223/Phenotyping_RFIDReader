using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace SimpleReaderDemo.Win32
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nCode"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

    /// <summary>
    /// Keyboard hook
    /// </summary>
    public class KeyHook
    {
        #region variable

        private static int hHook = 0;
        private HookProc KeyBoardHookProcedure;
        #endregion

        #region event
        /// <summary>
        /// Occurs when the keyboard button is pressed
        /// </summary>
        public event KeyEventHandler KeyDownEvent;
        /// <summary>
        /// Occurs when the keyboard button is raised
        /// </summary>
        public event KeyEventHandler keyUpEvent;
        #endregion

        #region Parameters that trigger the event
        /// <summary>
        /// Fire the KeyDownEvent event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">System.Windows.Forms.KeyEventArgs</param>
        public void OnKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (this.KeyDownEvent != null)
            {
                this.KeyDownEvent(sender, e);
            }
        }

        /// <summary>
        /// KeyUpEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">System.Windows.Forms.KeyEventArgs</param>
        public void OnKeyUpEvent(object sender, KeyEventArgs e)
        {
            if (this.keyUpEvent != null)
            {
                this.keyUpEvent(sender, e);
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Install keyboard hook
        /// </summary>
        public void Install_Hook()
        {
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);
                hHook = NativeMethods.SetWindowsHookEx(
                    HookType.WH_KEYBORARD_LL, 
                    KeyBoardHookProcedure, 
                    NativeMethods.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 
                    0);

                //If setting hook failed
                if (hHook == 0)
                    Uninstall_Hook();
            }

        }

        /// <summary>
        /// Uninstall keyboard hook
        /// </summary>
        public void Uninstall_Hook()
        {
            if (hHook != 0)
            {
                int result = NativeMethods.UnhookWindowsHookEx(hHook);
                hHook = 0;
                if (result == 0)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception("KeyHook.Uninstall_Hook()->" + NativeMethods.GetLastErrorString(errorCode));
                }
            }
        }

        private int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
                Keys key = (Keys)Enum.Parse(typeof(Keys), kbh.vkCode.ToString());
                if (kbh.flags == 0)
                {
                    
                    KeyEventArgs e = new KeyEventArgs(key);
                    this.OnKeyDownEvent(this, e);
                }
                else if (kbh.flags == 128)
                {
                    
                    KeyEventArgs e = new KeyEventArgs(key);
                    this.OnKeyUpEvent(this, e);
                }
                return 1;
            }
            return NativeMethods.CallNextHookEx(hHook, nCode, wParam, lParam);
        }
        #endregion
    }
}
