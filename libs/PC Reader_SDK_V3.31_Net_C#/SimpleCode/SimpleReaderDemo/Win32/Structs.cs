using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Drawing;

namespace SimpleReaderDemo.Win32
{
    /// <summary>
    /// An ordered pair representing the integer X and Y coordinates of a point defined in a two-dimensional plane.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        /// <summary>
        /// X 
        /// </summary>
        public int X;
        /// <summary>
        /// Y 
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the Paway.Windows.Win32.POINT structure.
        /// </summary>
        /// <param name="x">x </param>
        /// <param name="y">y </param>
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    /// <summary>
    /// Stores a set of integers, a total of four, representing the position and size of a rectangle
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        #region variable
        
        public int Left;
        
        public int Top;
        
        public int Right;
        
        public int Bottom;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the Paway.Windows.Win32.RECT structure.
        /// </summary>
        public RECT(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        /// <summary>
        /// Initializes a new instance of the Paway.Windows.Win32.RECT structure.
        /// </summary>
        public RECT(Rectangle rect)
        {
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Right = rect.Right;
            this.Bottom = rect.Bottom;
        }

        #endregion

        #region Attributes

        /// <summary>
        /// Gets or sets the area of this System.Drawing.Rectangle .
        /// </summary>
        public Rectangle Rect
        {
            get { return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top); }
        }

        /// <summary>
        /// Gets or sets the size of this RECT.
        /// </summary>
        public Size Size
        {
            get { return new Size(this.Right - this.Left, this.Bottom - this.Top); }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyBoardHookStruct
    {
        /// <summary>
        /// 
        /// </summary>
        public int vkCode;
        /// <summary>
        /// 
        /// </summary>
        public int scanCode;
        /// <summary>
        /// 
        /// </summary>
        public int flags;
        /// <summary>
        /// 
        /// </summary>
        public int time;
        /// <summary>
        /// 
        /// </summary>
        public int dwExtraInfo;
    }

    /// <summary>
    /// Mouse hook related information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseHookStruct
    {
        /// <summary>
        /// Mouse screen coordinates
        /// </summary>
        public POINT Point;

        /// <summary>
        /// The button pressed by the mouse
        /// </summary>
        public int MouseData;

        /// <summary>
        /// Specified event injection flag
        /// </summary>
        public int Flags;

        /// <summary>
        /// Message timestamp
        /// </summary>
        public int Time;

        /// <summary>
        /// Additional information associated with the message
        /// </summary>
        public int ExtraInfo;
    }

    /// <summary>
    /// Stores an ordered pair of integers, usually the width and height of the rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        #region variable


        public int Width;

        public int Height;

        #endregion

        #region constructor
        
        /// <summary>
        /// Initializes a new instance of the Paway.Windows.Win32.SIZE structure.
        /// </summary>
        /// <param name="width">The horizontal component of this SIZE</param>
        /// <param name="height">The vertical component of this SIZE.</param>
        public SIZE(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        /// <summary>
        /// Icon handle of the file
        /// </summary>
        public IntPtr hIcon;
        /// <summary>
        /// System index number of the icon
        /// </summary>
        public int iIcon;
        /// <summary>
        /// File attribute value
        /// </summary>
        public int dwAttributes;
        /// <summary>
        /// Display name of the file
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        /// <summary>
        /// Type name of the file
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {
        /// <summary>
        /// 
        /// </summary>
        public byte BlendOp;
        /// <summary>
        /// 
        /// </summary>
        public byte BlendFlags;
        /// <summary>
        /// 
        /// </summary>
        public byte SourceConstantAlpha;
        /// <summary>
        /// 
        /// </summary>
        public byte AlphaFormat;
    }

    /// <summary>
    /// ARGB 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ARGB
    {
        /// <summary>
        /// 
        /// </summary>
        public byte Blue;
        /// <summary>
        /// 
        /// </summary>
        public byte Green;
        /// <summary>
        /// 
        /// </summary>
        public byte Red;
        /// <summary>
        /// transparency
        /// </summary>
        public byte Alpha;
    }

    /// <summary>
    /// CPU information structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CPU_INFO
    {
        /// <summary>
        /// 
        /// </summary>
        public uint dwOemId;
        /// <summary>
        /// 
        /// </summary>
        public uint dwPageSize;
        /// <summary>
        /// 
        /// </summary>
        public uint lpMinimumApplicationAddress;
        /// <summary>
        /// 
        /// </summary>
        public uint lpMaximumApplicationAddress;
        /// <summary>
        /// 
        /// </summary>
        public uint dwActiveProcessorMask;
        /// <summary>
        /// 
        /// </summary>
        public uint dwNumberOfProcessors;
        /// <summary>
        /// 
        /// </summary>
        public uint dwProcessorType;
        /// <summary>
        /// 
        /// </summary>
        public uint dwAllocationGranularity;
        /// <summary>
        /// 
        /// </summary>
        public uint dwProcessorLevel;
        /// <summary>
        /// 
        /// </summary>
        public uint dwProcessorRevision;
    }

    /// <summary>
    /// Memory information structure 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_INFO
    {
        /// <summary>
        /// 
        /// </summary>
        public uint dwLength;
        /// <summary>
        /// 
        /// </summary>
        public uint dwMemoryLoad;
        /// <summary>
        /// 
        /// </summary>
        public uint dwTotalPhys;
        /// <summary>
        /// 
        /// </summary>
        public uint dwAvailPhys;
        /// <summary>
        /// 
        /// </summary>
        public uint dwTotalPageFile;
        /// <summary>
        /// 
        /// </summary>
        public uint dwAvailPageFile;
        /// <summary>
        /// 
        /// </summary>
        public uint dwTotalVirtual;
        /// <summary>
        /// 
        /// </summary>
        public uint dwAvailVirtual;
    }

    /// <summary>
    /// System time information structure 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME_INFO
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort wYear;
        /// <summary>
        /// 
        /// </summary>
        public ushort wMonth;
        /// <summary>
        /// 
        /// </summary>
        public ushort wDayOfWeek;
        /// <summary>
        /// 
        /// </summary>
        public ushort wDay;
        /// <summary>
        /// 
        /// </summary>
        public ushort wHour;
        /// <summary>
        /// 
        /// </summary>
        public ushort wMinute;
        /// <summary>
        /// 
        /// </summary>
        public ushort wSecond;
        /// <summary>
        /// 
        /// </summary>
        public ushort wMilliseconds;
    }
}
