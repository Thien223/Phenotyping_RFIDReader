using System;
using System.Text;

namespace SimpleReaderDemo.Win32
{
    /// <summary>
    /// Windows Message list
    /// </summary>
    public enum WindowsMessage : int
    {
        /// <summary>
        /// 
        /// </summary>
        WM_NULL = 0x0000,
        /// <summary>
        /// Application creates a window
        /// </summary>
        WM_CREATE = 0x0001,
        /// <summary>
        /// A window is destroyed 
        /// </summary>
        WM_DESTROY = 0x0002,
        /// <summary>
        /// Move a window
        /// </summary>
        WM_MOVE = 0x0003,
        /// <summary>
        /// Change the size of a window
        /// </summary>
        WM_SIZE = 0x0005,
        /// <summary>
        /// A window is activated or deactivated；
        /// </summary>
        WM_ACTIVATE = 0x0006,
        /// <summary>
        /// After getting the focus 
        /// </summary>
        WM_SETFOCUS = 0x0007,
        /// <summary>
        /// lose focus
        /// </summary>
        WM_KILLFOCUS = 0x0008,
        /// <summary>
        /// Change the enable state
        /// </summary>
        WM_ENABLE = 0x000A,
        /// <summary>
        /// Set whether the window can be redrawn
        /// </summary>
        WM_SETREDRAW = 0x000B,
        /// <summary>
        /// The application sends this message to set the text of a window
        /// </summary>
        WM_SETTEXT = 0x000C,
        /// <summary>
        /// The application sends this message to copy the text of the corresponding window to the buffer
        /// </summary>
        WM_GETTEXT = 0x000D,
        /// <summary>
        /// Get the length of the text associated with a window (without null characters)
        /// </summary>
        WM_GETTEXTLENGTH = 0x000E,
        /// <summary>
        /// Ask a window to redraw yourself
        /// </summary>
        WM_PAINT = 0x000F,
        /// <summary>
        /// Send a signal when a window or application is about to close
        /// </summary>
        WM_CLOSE = 0x0010,
        /// <summary>
        /// When the user chooses to end the dialog or the program calls the ExitWindows function itself
        /// </summary>
        WM_QUERYENDSESSION = 0x0011,
        /// <summary>
        /// Used to end the program run or when the program calls the postquitmessage function
        /// </summary>
        WM_QUIT = 0x0012,
        /// <summary>
        /// Send this message to an icon when the user window restores the previous size position
        /// </summary>
        WM_QUERYOPEN = 0x0013,
        /// <summary>
        /// When the window background must be erased (for example, when the window changes size)
        /// </summary>
        WM_ERASEBKGND = 0x0014,
        /// <summary>
        /// Send this message to all top-level windows when the system color changes
        /// </summary>
        WM_SYSCOLORCHANGE = 0x0015,
        /// <summary>
        /// When the system process issues a WM_QUERYENDSESSION message, this message is sent to the application to inform it if the conversation is over. 
        /// </summary>
        WM_ENDSESSION = 0x0016,
        /// <summary>
        /// 
        /// </summary>
        WM_SYSTEMERROR = 0x0017,
        /// <summary>
        /// When hiding or displaying a window is sending this message to this window
        /// </summary>
        WM_SHOWWINDOW = 0x0018,
        /// <summary>
        /// Send this message to the application which window is active and which is inactive;
        /// </summary>
        WM_ACTIVATEAPP = 0x001C,
        /// <summary>
        /// Send this message to all top-level windows when the system's font repository changes 
        /// </summary>
        WM_FONTCHANGE = 0x001D,
        /// <summary>
        /// Send this message to all top-level windows when the system's time changes
        /// </summary>
        WM_TIMECHANGE = 0x001E,
        /// <summary>
        /// Send this message to cancel some ongoing gesture (operation) 
        /// </summary>
        WM_CANCELMODE = 0x001F,
        /// <summary>
        /// Send a message to a window if the mouse causes the cursor to move in a window and the mouse input is not captured
        /// </summary>
        WM_SETCURSOR = 0x0020,
        /// <summary>
        /// When the cursor is in an inactive window and the user is pressing a key of the mouse to send this message to the current window
        /// </summary>
        WM_MOUSEACTIVATE = 0x0021,
        /// <summary>
        /// Send this message to the MDI child window when the user clicks on the title bar of this window, or when the window is activated, moves, resizes 
        /// </summary>
        WM_CHILDACTIVATE = 0x0022,
        /// <summary>
        /// This message is sent by the computer-based training program, and the user input message is separated by the hook program of WH_JOURNALPALYBACK.
        /// </summary>
        WM_QUEUESYNC = 0x0023,
        /// <summary>
        /// This message is sent to the window when it will change size or position;
        /// </summary>
        WM_GETMINMAXINFO = 0x0024,
        /// <summary>
        /// Sent to the minimized window when its icon is about to be redrawn 
        /// </summary>
        WM_PAINTICON = 0x0026,
        /// <summary>
        /// This message is sent to a minimized window, and its background must be redrawn only before it draws the icon.
        /// </summary>
        WM_ICONERASEBKGND = 0x0027,
        /// <summary>
        /// Send this message to a dialog program to change the focus position
        /// </summary>
        WM_NEXTDLGCTL = 0x0028,
        /// <summary>
        /// This message is sent whenever a print management queue increases or decreases a job 
        /// </summary>
        WM_SPOOLERSTATUS = 0x002A,
        /// <summary>
        /// Send this message to the owner of these empty pieces when the visual appearance of the button, combobox, listbox, menu changes
        /// </summary>
        WM_DRAWITEM = 0x002B,
        /// <summary>
        /// When button, combo box, list box, list view control, or menu item is created
        /// Send this message to the owner of the control
        /// </summary>
        WM_MEASUREITEM = 0x002C,
        /// <summary>
        /// When the list box or combo box is destroyed or when certain items are deleted via LB_DELETESTRING, LB_RESETCONTENT,
        /// CB_DELETESTRING, or CB_RESETCONTENT 消息 
        /// </summary>
        WM_DELETEITEM = 0x002D,
        /// <summary>
        /// This message has an LBS_WANTKEYBOARDINPUT style issued to its owner to respond to the WM_KEYDOWN message. 
        /// </summary>
        WM_VKEYTOITEM = 0x002E,
        /// <summary>
        /// This message is sent to his owner by a LBS_WANTKEYBOARDINPUT style list box in response to the WM_CHAR message.
        /// </summary>
        WM_CHARTOITEM = 0x002F,
        /// <summary>
        /// When the text is drawn, the program sends this message to get the color to be used by the control.
        /// </summary>
        WM_SETFONT = 0x0030,
        /// <summary>
        /// The application sends this message to get the font of the current control drawing text 
        /// </summary>
        WM_GETFONT = 0x0031,
        /// <summary>
        /// The application sends this message to associate a window with a hotkey 
        /// </summary>
        WM_SETHOTKEY = 0x0032,
        /// <summary>
        /// The application sends this message to determine if the hotkey is associated with a window
        /// </summary>
        WM_GETHOTKEY = 0x0033,
        /// <summary>
        /// This message is sent to the minimized window. When this window is about to be dragged and dropped and no icon is defined in its class, the application can
        /// Returns an icon or cursor handle that is displayed when the user drags and drops the icon 
        /// </summary>
        WM_QUERYDRAGICON = 0x0037,
        /// <summary>
        /// Send this message to determine the relative position of the newly added item in the combobox or listbox 
        /// </summary>
        WM_COMPAREITEM = 0x0039,
        /// <summary>
        /// 
        /// </summary>
        WM_GETOBJECT = 0x003D,
        /// <summary>
        /// Display memory is very small
        /// </summary>
        WM_COMPACTING = 0x0041,
        /// <summary>
        /// Send this message to the setwindowpos function or other window management function when the size and position of that window will be changed.
        /// </summary>
        WM_WINDOWPOSCHANGING = 0x0046,
        /// <summary>
        /// Call this to the setwindowpos function or other window management function when sending this message to the size and position of that window has been changed.
        /// </summary>
        WM_WINDOWPOSCHANGED = 0x0047,
        /// <summary>
        /// This message is sent when the system is about to enter a pause state (for 16-bit windows)
        /// </summary>
        WM_POWER = 0x0048,
        /// <summary>
        /// Send this message when one application passes data to another application
        /// </summary>
        WM_COPYDATA = 0x004A,
        /// <summary>
        /// When a user cancels the program log activation status, submit this message to the program.
        /// </summary>
        WM_CANCELJOURNAL = 0x004B,
        /// <summary>
        /// Send this message to its parent window when an event of a control has occurred or the control needs to get some information. 
        /// </summary>
        WM_NOTIFY = 0x004E,
        /// <summary>
        /// When the user selects an input language, or the hotkey of the input language changes
        /// </summary>
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        /// <summary>
        /// Send this message to the affected top-level window when the platform site has been changed
        /// </summary>
        WM_INPUTLANGCHANGE = 0x0051,
        /// <summary>
        /// Send this message to the application when the program has initialized the windows help routine
        /// </summary>
        WM_TCARD = 0x0052,
        /// <summary>
        /// This message shows that the user pressed F1. If a menu is active, this message is sent to the menu associated with this window, otherwise 
        /// Send to the window with focus, if there is no focus at present, send this message to the currently active window
        /// </summary>
        WM_HELP = 0x0053,
        /// <summary>
        /// This message is sent to all windows when the user has logged in or logged out. When the user logs in or quits, the system updates the user's specificity. 
        /// Set the information, the system will send this message immediately when the user updates the settings;
        /// </summary>
        WM_USERCHANGED = 0x0054,
        /// <summary>
        /// Common controls, custom controls, and their parent windows use this message to determine if the control is using an ANSI or UNI CODE structure. 
        /// In the WM_NOTIFY message, use this control to enable a control to communicate with its parent control 
        /// </summary>
        WM_NOTIFYformAT = 0x0055,
        /// <summary>
        /// Send this message to this window when the user clicks the right button in a window. 
        /// </summary>
        WM_CONTEXTMENU = 0x007B,
        /// <summary>
        /// Send this message to that window when the SETWINDOWLONG function is called to change the style of one or more windows
        /// </summary>
        WM_styleCHANGING = 0x007C,
        /// <summary>
        /// Send this message to that window when the style of one or more windows of the SETWINDOWLONG function is called.
        /// </summary>
        WM_styleCHANGED = 0x007D,
        /// <summary>
        /// Send this message to all windows when the resolution of the display changes 
        /// </summary>
        WM_DISPLAYCHANGE = 0x007E,
        /// <summary>
        /// This message is sent to a window to return the handle of a large or small icon associated with a window; 
        /// </summary>
        WM_GETICON = 0x007F,
        /// <summary>
        /// The program sends this message to associate a new large icon or small icon with a window; 
        /// </summary>
        WM_SETICON = 0x0080,
        /// <summary>
        /// When a window is first created, this message is sent before the WM_CREATE message is sent;
        /// </summary>
        WM_NCCREATE = 0x0081,
        /// <summary>
        /// This message informs a window that the non-client area is being destroyed
        /// </summary>
        WM_NCDESTROY = 0x0082,
        /// <summary>
        ///  This message is sent when the client area of a window must be accounted for 
        /// </summary>
        WM_NCCALCSIZE = 0x0083,
        /// <summary>
        /// Occurs when you move the mouse, hold or release the mouse 
        /// </summary>
        WM_NCHITTEST = 0x0084,
        /// <summary>
        /// The program sends this message to a window when its (window) frame must be drawn;
        /// </summary>
        WM_NCPAINT = 0x0085,
        /// <summary>
        /// This message is sent to a window only if its non-client area needs to be changed to show whether it is active or inactive;
        /// </summary>
        WM_NCACTIVATE = 0x0086,
        /// <summary>
        /// Send this message to a control associated with the dialog program. Widdows controls the orientation key and TAB key to make the input into this control. 
        /// By responding to the WM_GETDLGCODE message, the application can treat it as a special input control and handle it.
        /// </summary>
        WM_GETDLGCODE = 0x0087,
        /// <summary>
        /// This message is sent to this window when the cursor moves within the non-client area of a window (non-client area: the title bar of the form and the border of the window)
        /// </summary>
        WM_NCMOUSEMOVE = 0x00A0,
        /// <summary>
        /// Submit this message when the cursor is pressed at the same time in the non-client area of a window
        /// </summary>
        WM_NCLBUTTONDOWN = 0x00A1,
        /// <summary>
        /// This message is sent when the user releases the left mouse button while the cursor is in a non-client area.； 
        /// </summary>
        WM_NCLBUTTONUP = 0x00A2,
        /// <summary>
        /// This message is sent when the user double-clicks the left mouse button while the cursor is in a non-client area. 
        /// </summary>
        WM_NCLBUTTONDBLCLK = 0x00A3,
        /// <summary>
        /// This message is sent when the user presses the right mouse button and the cursor is again in the non-client area of the window. 
        /// </summary>
        WM_NCRBUTTONDOWN = 0x00A4,
        /// <summary>
        /// This message is sent when the user releases the right mouse button and the cursor is again in the non-client area of the window. 
        /// </summary>
        WM_NCRBUTTONUP = 0x00A5,
        /// <summary>
        /// This message is sent when the user double-clicks the right mouse button while the cursor is in a non-client area. 
        /// </summary>
        WM_NCRBUTTONDBLCLK = 0x00A6,
        /// <summary>
        /// This message is sent when the user releases the middle mouse button while the cursor is again in the non-client area of the window. 
        /// </summary>
        WM_NCMBUTTONDOWN = 0x00A7,
        /// <summary>
        /// This message is sent when the user releases the middle mouse button while the cursor is again in the non-client area of the window. 
        /// </summary>
        WM_NCMBUTTONUP = 0x00A8,
        /// <summary>
        /// This message is sent when the user double-clicks the middle mouse button while the cursor is again in the non-client area of the window. 
        /// </summary>
        WM_NCMBUTTONDBLCLK = 0x00A9,
        /// <summary>
        /// 
        /// </summary>
        WM_KEYFIRST = 0x0100,
        /// <summary>
        /// Press a button 
        /// </summary>
        WM_KEYDOWN = 0x0100,
        /// <summary>
        /// Release a key
        /// </summary>
        WM_KEYUP = 0x0101,
        /// <summary>
        /// Press a key and have issued WM_KEYDOWN, WM_KEYUP message
        /// </summary>
        WM_CHAR = 0x0102,
        /// <summary>
        /// Send this message to the window with focus when translating the WM_KEYUP message with the translatemessage function 
        /// </summary>
        WM_DEADCHAR = 0x0103,
        /// <summary>
        /// Submit this message to the window with focus when the user holds down the ALT key while pressing other keys; 
        /// </summary>
        WM_SYSKEYDOWN = 0x0104,
        /// <summary>
        /// Submit this message to the window with focus when the user releases a key and the ALT key is still pressed
        /// </summary>
        WM_SYSKEYUP = 0x0105,
        /// <summary>
        /// Submit this message to the window with focus when the WM_SYSKEYDOWN message is translated by the TRANSLATEMESSAGE function
        /// </summary>
        WM_SYSCHAR = 0x0106,
        /// <summary>
        /// Send this message to the window with focus when the WM_SYSKEYDOWN message is translated by the TRANSLATEMESSAGE function 
        /// </summary>
        WM_SYSDEADCHAR = 0x0107,
        /// <summary>
        /// 
        /// </summary>
        WM_KEYLAST = 0x0108,
        /// <summary>
        /// Send this message to a dialog box before it is displayed. This message is usually used to initialize controls and perform other tasks.
        /// </summary>
        WM_INITDIALOG = 0x0110,
        /// <summary>
        /// When a user selects a menu command item or when a control sends a message to its parent window, a shortcut is translated
        /// </summary>
        WM_COMMAND = 0x0111,
        /// <summary>
        /// The window will receive this message when the user selects a command from the window menu or when the user chooses to maximize or minimize
        /// </summary>
        WM_SYSCOMMAND = 0x0112,
        /// <summary>
        /// Timer event has occurred
        /// </summary>
        WM_TIMER = 0x0113,
        /// <summary>
        /// Sends this message to that window when a window's standard horizontal scrollbar produces a scrolling event, and also sends it to the control that owns it.
        /// </summary>
        WM_HSCROLL = 0x0114,
        /// <summary>
        /// Sends this message to that window when a window's standard vertical scrollbar produces a scrolling event, and sends it to the control that owns it.
        /// </summary>
        WM_VSCROLL = 0x0115,
        /// <summary>
        /// This message is sent when a menu is about to be activated, it occurs in an item in the user's menu bar or a menu button is pressed, which allows the program to change the menu before it is displayed.
        /// </summary>
        wm_initmenu = 0x0116,
        /// <summary>
        /// This message is sent when a drop-down menu or submenu is about to be activated, which allows the program to change the menu before it is displayed, without changing all
        /// </summary>
        WM_INITMENUPOPUP = 0x0117,
        /// <summary>
        /// Send this message to the owner of the menu (usually the window) when the user selects a menu item 
        /// </summary>
        WM_MENUSELECT = 0x011F,
        /// <summary>
        /// When the menu has been activated, the user presses a key (unlike the accelerator) and sends this message to the owner of the menu;
        /// </summary>
        WM_MENUCHAR = 0x0120,
        /// <summary>
        /// Send this message to its owner when a modal dialog or menu enters the no-load state, a modal dialog or menu enters no load
        /// The state is that there is no message waiting in the queue after processing one or several previous messages.
        /// </summary>
        WM_ENTERIDLE = 0x0121,
        /// <summary>
        /// 
        /// </summary>
        WM_MENURBUTTONUP = 0x0122,
        /// <summary>
        /// 
        /// </summary>
        WM_MENUDRAG = 0x0123,
        /// <summary>
        /// 
        /// </summary>
        WM_MENUGETOBJECT = 0x0124,
        /// <summary>
        /// 
        /// </summary>
        WM_UNINITMENUPOPUP = 0x0125,
        /// <summary>
        /// 
        /// </summary>
        WM_MENUCOMMAND = 0x0126,
        /// <summary>
        /// 
        /// </summary>
        WM_CHANGEUISTATE = 0x0127,
        /// <summary>
        /// 
        /// </summary>
        WM_UPDATEUISTATE = 0x0128,
        /// <summary>
        /// 
        /// </summary>
        WM_QUERYUISTATE = 0x0129,
        /// <summary>
        /// Send this message to the owner window of the message box before the window draws the message box. By responding to this message, the owner window can 
        /// Set the text and background color of the message box by using the handle of the given associated display device 
        /// </summary>
        WM_CTLCOLORMSGBOX = 0x0132,
        /// <summary>
        /// Send this message to its parent window when an edit control is about to be drawn; by responding to this message, the owner window can 
        /// Set the text and background color of the edit box by using the handle of the given related display device
        /// </summary>
        WM_CTLCOLOREDIT = 0x0133,
        /// <summary>
        /// Send this message to its parent window before a list box control is about to be drawn; by responding to this message, the owner window can 
        /// Set the text and background color of the list box by using the handle of the given related display device
        /// </summary>
        WM_CTLCOLORLISTBOX = 0x0134,
        /// <summary>
        /// Send this message to its parent window when a button control is about to be drawn; by responding to this message, the owner window can 
        /// Set the text and background color of the button by using the handle of the given associated display device 
        /// </summary>
        WM_CTLCOLORBTN = 0x0135,
        /// <summary>
        /// Send this message to its parent window before a dialog control is about to be drawn; by responding to this message, the owner window can 
        /// Set the text background color of the dialog by using the handle of the given related display device
        /// </summary>
        WM_CTLCOLORDLG = 0x0136,
        /// <summary>
        /// Send this message to its parent window when a scrollbar control is about to be drawn; by responding to this message, the owner window can 
        /// Set the background color of the scrollbar by using the handle of the given associated display device
        /// </summary>
        WM_CTLCOLORSCROLLBAR = 0x0137,
        /// <summary>
        /// Send this message to its parent window when a static control is about to be drawn; by responding to this message, the owner window can
        /// Set the text and background color of a static control by using the handle of the given related display device 
        /// </summary>
        WM_CTLCOLORSTATIC = 0x0138,
        /// <summary>
        /// 
        /// </summary>
        WM_MOUSEFIRST = 0x0200,
        /// <summary>
        /// Moving the mouse
        /// </summary>
        WM_MOUSEMOVE = 0x0200,
        /// <summary>
        /// Press the left mouse button
        /// </summary>
        WM_LBUTTONDOWN = 0x0201,
        /// <summary>
        /// Release the left mouse button 
        /// </summary>
        WM_LBUTTONUP = 0x0202,
        /// <summary>
        /// Double click the left mouse button 
        /// </summary>
        WM_LBUTTONDBLCLK = 0x0203,
        /// <summary>
        /// Press the right mouse button 
        /// </summary>
        WM_RBUTTONDOWN = 0x0204,
        /// <summary>
        /// Release the right mouse button
        /// </summary>
        WM_RBUTTONUP = 0x0205,
        /// <summary>
        /// Double click the right mouse button
        /// </summary>
        WM_RBUTTONDBLCLK = 0x0206,
        /// <summary>
        /// Press the middle mouse button
        /// </summary>
        WM_MBUTTONDOWN = 0x0207,
        /// <summary>
        /// Release the middle mouse button 
        /// </summary>
        WM_MBUTTONUP = 0x0208,
        /// <summary>
        /// Double click the middle mouse button 
        /// </summary>
        WM_MBUTTONDBLCLK = 0x0209,
        /// <summary>
        /// Send this message to the currently focused control when the mouse wheel is rotated 
        /// </summary>
        WM_MOUSEWHEEL = 0x020A,
        /// <summary>
        /// 
        /// </summary>
        WM_MOUSELAST = 0x020A,
        /// <summary>
        /// Send this message to its parent window when the MDI child window is created or destroyed, or when the user presses the mouse button and the cursor is over the child window 
        /// </summary>
        WM_PARENTNOTIFY = 0x0210,
        /// <summary>
        /// Send this message to inform the application's main window that it has entered the menu loop mode 
        /// </summary>
        WM_ENTERMENULOOP = 0x0211,
        /// <summary>
        /// Send this message to notify the application's main window that the menu loop mode has been exited 
        /// </summary>
        WM_EXITMENULOOP = 0x0212,
        /// <summary>
        /// 
        /// </summary>
        WM_NEXTMENU = 0x0213,
        /// <summary>
        /// Send this message to the window when the user is resizing the window; this message allows the application to monitor the window size and position and also modify them 
        /// </summary>
        WM_SIZING = 0x0214,
        /// <summary>
        /// Send this message to the window when it loses the captured mouse;
        /// </summary>
        WM_CAPTURECHANGED = 0x0215,
        /// <summary>
        /// When the user sends this message while moving the window, the application can monitor the size and position of the window and modify them;
        /// </summary>
        WM_MOVING = 0x0216,
        /// <summary>
        /// This message is sent to the application to notify it about power management events; 
        /// </summary>
        WM_POWERBROADCAST = 0x0218,
        /// <summary>
        /// Send this message to the application or device driver when the device's hardware configuration changes
        /// </summary>
        WM_DEVICECHANGE = 0x0219,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_STARTCOMPOSITION = 0x010D,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_ENDCOMPOSITION = 0x010E,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_COMPOSITION = 0x010F,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_KEYLAST = 0x010F,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_SETCONTEXT = 0x0281,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_NOTIFY = 0x0282,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_CONTROL = 0x0283,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_COMPOSITIONFULL = 0x0284,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_SELECT = 0x0285,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_CHAR = 0x0286,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_REQUEST = 0x0288,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_KEYDOWN = 0x0290,
        /// <summary>
        /// 
        /// </summary>
        WM_IME_KEYUP = 0x0291,
        /// <summary>
        /// The application sends this message to the multi-document client window to create an MDI child window 
        /// </summary>
        WM_MDICREATE = 0x0220,
        /// <summary>
        /// The application sends this message to the multi-document client window to close an MDI child window
        /// </summary>
        WM_MDIDESTROY = 0x0221,
        /// <summary>
        /// The application sends this message to the multi-document client window to notify the client window to activate another MDI child window when the client window receives
        /// After this message, it issues a WM_MDIACTIVE message to the MDI child window (not activated) to activate it; 
        /// </summary>
        WM_MDIACTIVATE = 0x0222,
        /// <summary>
        /// The program sends this message to the MDI client window to restore the child window from maximum minimized to its original size.
        /// </summary>
        WM_MDIRESTORE = 0x0223,
        /// <summary>
        /// Program Send this message to the MDI client window to activate the next or previous window 
        /// </summary>
        WM_MDINEXT = 0x0224,
        /// <summary>
        /// The program sends this message to the MDI client window to maximize an MDI child window; 
        /// </summary>
        WM_MDIMAXIMIZE = 0x0225,
        /// <summary>
        /// Program Send this message to the MDI client window to rearrange all MDI child windows in a cascading manner 
        /// </summary>
        WM_MDITILE = 0x0226,
        /// <summary>
        /// Program Send this message to the MDI client window to rearrange all MDI child windows in a cascading manner
        /// </summary>
        WM_MDICASCADE = 0x0227,
        /// <summary>
        /// Program Send this message to the MDI client window to rearrange all minimized MDI child windows 
        /// </summary>
        WM_MDIICONARRANGE = 0x0228,
        /// <summary>
        /// The program sends this message to the MDI client window to find the handle of the active child window. 
        /// </summary>
        WM_MDIGETACTIVE = 0x0229,
        /// <summary>
        /// Program Send this message to the MDI client window to replace the sub-window menu with the MDI menu.
        /// </summary>
        WM_MDISETMENU = 0x0230,
        /// <summary>
        /// 
        /// </summary>
        WM_ENTERSIZEMOVE = 0x0231,
        /// <summary>
        /// 
        /// </summary>
        WM_EXITSIZEMOVE = 0x0232,
        /// <summary>
        /// 
        /// </summary>
        WM_DROPFILES = 0x0233,
        /// <summary>
        /// 
        /// </summary>
        WM_MDIREFRESHMENU = 0x0234,
        /// <summary>
        /// 
        /// </summary>
        WM_MOUSEHOVER = 0x02A1,
        /// <summary>
        /// 
        /// </summary>
        WM_MOUSELEAVE = 0x02A3,
        /// <summary>
        /// The program sends this message to an edit box or combobox to delete the currently selected text.
        /// </summary>
        WM_CUT = 0x0300,
        /// <summary>
        /// The program sends this message to an edit box or combobox to copy the currently selected text to the clipboard.
        /// </summary>
        WM_COPY = 0x0301,
        /// <summary>
        /// The program sends this message to editcontrol or combobox to get the data from the clipboard. 
        /// </summary>
        WM_PASTE = 0x0302,
        /// <summary>
        /// The program sends this message to editcontrol or combobox to clear the currently selected content;
        /// </summary>
        WM_CLEAR = 0x0303,
        /// <summary>
        /// The program sends this message to editcontrol or combobox to undo the last operation
        /// </summary>
        WM_UNDO = 0x0304,
        /// <summary>
        /// 
        /// </summary>
        WM_RENDERformAT = 0x0305,
        /// <summary>
        /// 
        /// </summary>
        WM_RENDERALLformATS = 0x0306,
        /// <summary>
        /// Send this message to the owner of the clipboard when calling the ENPTYCLIPBOARD function 
        /// </summary>
        WM_DESTROYCLIPBOARD = 0x0307,
        /// <summary>
        /// Send this message to the first window of the clipboard watch chain when the contents of the clipboard change; it allows the clipboard to view the window to display the new contents of the clipboard;
        /// </summary>
        WM_DRAWCLIPBOARD = 0x0308,
        /// <summary>
        /// When the clipboard contains data in CF_OWNERDIPLAY format and the client area of the clipboard watch window needs to be redrawn;
        /// </summary>
        WM_PAINTCLIPBOARD = 0x0309,
        /// <summary>
        /// 
        /// </summary>
        WM_VSCROLLCLIPBOARD = 0x030A,
        /// <summary>
        /// When the clipboard contains data in CF_OWNERDIPLAY format and the size of the client area of the clipboard watch window has changed, this message is cut by
        /// The owner of the clipboard sent to the clipboard;
        /// </summary>
        WM_SIZECLIPBOARD = 0x030B,
        /// <summary>
        /// Send this message to the owner of the clipboard via the clipboard watch window to request the name of the clipboard in CF_OWNERDISPLAY format
        /// </summary>
        WM_ASKCBformATNAME = 0x030C,
        /// <summary>
        /// Send this message to the first window of the clipboard observation chain when a window is removed from the clipboard observation chain;
        /// </summary>
        WM_CHANGECBCHAIN = 0x030D,
        /// <summary>
        /// This message is sent to the owner of the clipboard via a clipboard watch window; it occurs when the clipboard contains data in CFOWNERDISPALY format
        /// And there is an event on the horizontal scroll bar of the clipboard view window; the owner should scroll the clipboard image and update the value of the scroll bar;
        /// </summary>
        WM_HSCROLLCLIPBOARD = 0x030E,
        /// <summary>
        /// This message is sent to the window that will receive the focus, which will give the window a chance to implement his logical palette when it receives the focus. 
        /// </summary>
        WM_QUERYNEWPALETTE = 0x030F,
        /// <summary>
        /// Send this message to notify all applications when an application is about to implement its logical palette 
        /// </summary>
        WM_PALETTEISCHANGING = 0x0310,
        /// <summary>
        /// This message changes the system palette by sending this message to all top-level and overlapping windows after a logically focused window implements its logical palette.
        /// </summary>
        WM_PALETTECHANGED = 0x0311,
        /// <summary>
        /// Submit this message when the user presses the hotkey registered by the REGISTERHOTKEY function 
        /// </summary>
        WM_HOTKEY = 0x0312,
        /// <summary>
        /// The application sends this message only when WINDOWS or other application issues a request to draw a portion of an application;
        /// </summary>
        WM_PRINT = 0x0317,
        /// <summary>
        /// 
        /// </summary>
        WM_PRINTCLIENT = 0x0318,
        /// <summary>
        /// 
        /// </summary>
        WM_HANDHELDFIRST = 0x0358,
        /// <summary>
        /// 
        /// </summary>
        WM_HANDHELDLAST = 0x035F,
        /// <summary>
        /// 
        /// </summary>
        WM_PENWINFIRST = 0x0380,
        /// <summary>
        /// 
        /// </summary>
        WM_PENWINLAST = 0x038F,
        /// <summary>
        /// 
        /// </summary>
        WM_COALESCE_FIRST = 0x0390,
        /// <summary>
        /// 
        /// </summary>
        WM_COALESCE_LAST = 0x039F,
        /// <summary>
        /// 
        /// </summary>
        WM_DDE_FIRST = 0x03E0,
        /// <summary>
        /// 
        /// </summary>
        WM_THEMECHNAGED = 0x31A
    }

    /// <summary>
    /// Window style
    /// </summary>
    [Flags]
    public enum WindowStyle : int
    {
        /// <summary>
        /// 
        /// </summary>
        WS_OVERLAPPED = 0x00000000,
        /// <summary>
        /// 
        /// </summary>
        WS_POPUP = unchecked((int)0x80000000),
        /// <summary>
        /// 
        /// </summary>
        WS_CHILD = 0x40000000,
        /// <summary>
        /// 
        /// </summary>
        WS_MINIMIZE = 0x20000000,
        /// <summary>
        /// 
        /// </summary>
        WS_VISIBLE = 0x10000000,
        /// <summary>
        /// 
        /// </summary>
        WS_DISABLED = 0x08000000,
        /// <summary>
        /// 
        /// </summary>
        WS_CLIPSIBLINGS = 0x04000000,
        /// <summary>
        /// 
        /// </summary>
        WS_CLIPCHILDREN = 0x02000000,
        /// <summary>
        /// 
        /// </summary>
        WS_MAXIMIZE = 0x01000000,
        /// <summary>
        /// 
        /// </summary>
        WS_CAPTION = 0x00C00000,
        /// <summary>
        /// 
        /// </summary>
        WS_BORDER = 0x00800000,
        /// <summary>
        /// 
        /// </summary>
        WS_DLGFRAME = 0x00400000,
        /// <summary>
        /// 
        /// </summary>
        WS_VSCROLL = 0x00200000,
        /// <summary>
        /// 
        /// </summary>
        WS_HSCROLL = 0x00100000,
        /// <summary>
        /// 
        /// </summary>
        WS_SYSMENU = 0x00080000,
        /// <summary>
        /// 
        /// </summary>
        WS_THICKFRAME = 0x00040000,
        /// <summary>
        /// 
        /// </summary>
        WS_GROUP = 0x00020000,
        /// <summary>
        /// 
        /// </summary>
        WS_TABSTOP = 0x00010000,
        /// <summary>
        /// 
        /// </summary>
        WS_MINIMIZEBOX = 0x00020000,
        /// <summary>
        /// 
        /// </summary>
        WS_MAXIMIZEBOX = 0x00010000,
        /// <summary>
        /// 
        /// </summary>
        WS_TILED = WS_OVERLAPPED,
        /// <summary>
        /// 
        /// </summary>
        WS_ICONIC = WS_MINIMIZE,
        /// <summary>
        /// 
        /// </summary>
        WS_SIZEBOX = WS_THICKFRAME,
        /// <summary>
        /// 
        /// </summary>
        WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,
        /// <summary>
        /// 
        /// </summary>
        WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU |
                                WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),
        /// <summary>
        /// 
        /// </summary>
        WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU),
        /// <summary>
        /// 
        /// </summary>
        WS_CHILDWINDOW = (WS_CHILD)
    }

    /// <summary>
    /// Defines the name of the auxiliary key (converts the number to a character for memory, and removes the enumeration using values)
    /// </summary>
    [Flags]
    public enum KeyModifiers : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,
        /// <summary>
        /// 
        /// </summary>
        Alt = 1,
        /// <summary>
        /// 
        /// </summary>
        Ctrl = 2,
        /// <summary>
        /// 
        /// </summary>
        Shift = 4,
        /// <summary>
        /// 
        /// </summary>
        WindowsKey = 8
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum ImageListDrawFlags : int
    {
        /// <summary>
        /// 
        /// </summary>
        ILD_NORMAL = 0x00000000,
        /// <summary>
        /// 
        /// </summary>
        ILD_TRANSPARENT = 0x00000001,
        /// <summary>
        /// 
        /// </summary>
        ILD_BLEND25 = 0x00000002,
        /// <summary>
        /// 
        /// </summary>
        ILD_FOCUS = 0x00000002,
        /// <summary>
        /// 
        /// </summary>
        ILD_BLEND50 = 0x00000004,
        /// <summary>
        /// 
        /// </summary>
        ILD_SELECTED = 0x00000004,
        /// <summary>
        /// 
        /// </summary>
        ILD_BLEND = 0x00000004,
        /// <summary>
        /// 
        /// </summary>
        ILD_MASK = 0x00000010,
        /// <summary>
        /// 
        /// </summary>
        ILD_IMAGE = 0x00000020,
        /// <summary>
        /// 
        /// </summary>
        ILD_ROP = 0x00000040,
        /// <summary>
        /// 
        /// </summary>
        ILD_OVERLAYMASK = 0x00000F00,
        /// <summary>
        /// 
        /// </summary>
        ILD_PRESERVEALPHA = 0x00001000,
        /// <summary>
        /// 
        /// </summary>
        ILD_SCALE = 0x00002000,
        /// <summary>
        /// 
        /// </summary>
        ILD_DPISCALE = 0x00004000,
        /// <summary>
        /// 
        /// </summary>
        ILD_ASYNC = 0x00008000
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ImageListColorFlags : uint
    {
        /// <summary>
        /// 
        /// </summary>
        CLR_NONE = 0xFFFFFFFF,
        /// <summary>
        /// 
        /// </summary>
        CLR_DEFAULT = 0xFF000000,
        /// <summary>
        /// 
        /// </summary>
        CLR_HILIGHT = CLR_DEFAULT,
    }

    /// <summary>
    /// Type of hook processing
    /// </summary>
    public enum HookType
    {
        /// <summary>
        /// Install a hook process to monitor messages raised by input events in dialog boxes, message boxes, menu bars, or scroll bars
        /// </summary>
        WH_MSGFILTER = -1,
        /// <summary>
        /// Install a hook process to record incoming messages sent to the system message queue
        /// </summary>
        WH_JOURNALRECORD = 0,
        /// <summary>
        /// Install a hook process to send messages previously recorded by the WH_JOURNALRECORD hook process
        /// </summary>
        WH_JOURNALPLAYBACK = 1,
        /// <summary>
        /// Install a hook process to monitor keystroke messages
        /// </summary>
        WH_KEYBORARD = 2,
        /// <summary>
        /// Install a hook process to monitor messages sent to the message queue
        /// </summary>
        WH_GETMESSAGE = 3,
        /// <summary>
        /// Install a hook process that monitors the message before it is sent to the target window process
        /// </summary>
        WH_CALLWNDPROC = 4,
        /// <summary>
        /// Install a hook process that accepts useful messages for CBT applications
        /// </summary>
        WH_CBT = 5,
        /// <summary>
        /// 
        /// </summary>
        WH_SYSMSGFILTER = 6,
        /// <summary>
        /// Install a hook process to monitor mouse messages
        /// </summary>
        WH_MOUSE = 7,
        /// <summary>
        /// Install a hook process to debug other hook processes
        /// </summary>
        WH_DEBUG = 9,
        /// <summary>
        /// Install a hook process to accept notifications useful to the shell application
        /// </summary>
        WH_SHELL = 10,
        /// <summary>
        /// <para></para>
        /// <para></para>
        /// </summary>
        WH_FOREGROUNDIDLE = 11,
        /// <summary>
        /// Install a hook process that monitors messages that have been processed by the target window process
        /// </summary>
        WH_CALLWNDPROCRET = 12,
        /// <summary>
        /// This hook can only be installed in Windows NT to monitor the underlying keyboard input events.
        /// </summary>
        WH_KEYBORARD_LL = 13,
        /// <summary>
        /// This hook can only be installed in Windows NT to monitor underlying mouse input events
        /// </summary>
        WH_MOUSE_LL = 14,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SHGFI
    {
        /// <summary>
        /// Get icon
        /// </summary>
        SHGFI_ICON = 0x000000100,
        /// <summary>
        /// Get the display name
        /// </summary>
        SHGFI_DISPLAYNAM = 0x000000200,
        /// <summary>
        /// Get the type name
        /// </summary>
        SHGFI_TYPENAME = 0x000000400,
        /// <summary>
        /// Get attribute
        /// </summary>
        SHGFI_ATTRIBUTES = 0x000000800,
        /// <summary>
        /// Get icon location
        /// </summary>
        SHGFI_ICONLOCATION = 0x000001000,
        /// <summary>
        /// Return the type of executable
        /// </summary>
        SHGFI_EXETYPE = 0x000002000,
        /// <summary>
        /// Get system icon index
        /// </summary>
        SHGFI_SYSICONINDEX = 0x000004000,
        /// <summary>
        /// Overwrite a link in the icon
        /// </summary>
        SHGFI_LINKOVERLAY = 0x000008000,
        /// <summary>
        /// Show the status of the icon when it is selected
        /// </summary>
        SHGFI_SELECTED = 0x000010000,
        /// <summary>
        /// Can only specify attributes
        /// </summary>
        SHGFI_ATTR_SPECIFIED = 0x000020000,
        /// <summary>
        /// Get big icon
        /// </summary>
        SHGFI_LARGEICON = 0x000000000,
        /// <summary>
        /// Get small icon
        /// </summary>
        SHGFI_SMALLICON = 0x000000001,
        /// <summary>
        /// Modify SHGFI_ICON to cause the function to retrieve the open icon of the file
        /// </summary>
        SHGFI_OPENICON = 0x000000002,
        /// <summary>
        /// Modify SHGFI_ICON to cause the function to retrieve a shell-sized icon. If this flag is not specified, the function size icon is based on the system metric.
        /// Note: This logo does not support Windows Phone devices.
        /// </summary>
        SHGFI_SHELLICONSIZE = 0x000000004,
        /// <summary>
        /// 
        /// </summary>
        SHGFI_PIDL = 0x000000008,
        /// <summary>
        /// by using dwFileAttributes
        /// </summary>
        SHGFI_USEFILEATTRIBUTES = 0x000000010,
        /// <summary>
        /// Apply appropriate coverage
        /// </summary>
        SHGFI_ADDOVERLAYS = 0x000000020,
        /// <summary>
        /// Get the superposition of the index
        /// </summary>
        SHGFI_OVERLAYINDEX = 0x000000040,
    }

    /// <summary>
    /// Send to a window to determine which part of the window the mouse corresponds to a particular screen coordinate
    /// </summary>
    public enum WM_NCHITTEST : int
    {
        /// <summary>
        /// The dividing line between the screen background or window
        /// </summary>
        HTERROR = -2,
        /// <summary>
        /// In the current window, other windows are overwritten in the same thread
        /// (The message will be sent to the relevant thread in the same thread until one of them returns a code that is not HTTRANSPARENT)
        /// </summary>
        HTTRANSPARENT = -1,
        /// <summary>
        /// On the dividing line between the screen background or window
        /// </summary>
        HTNOWHERE = 0,
        /// <summary>
        /// In the client area
        /// </summary>
        HTCLIENT = 1,
        /// <summary>
        /// In the title bar
        /// </summary>
        HTCAPTION = 2,
        /// <summary>
        /// In the window menu, or in the close button of a child window
        /// </summary>
        HTSYSMENU = 3,
        /// <summary>
        /// In the size box (same as HTGROWBO)
        /// </summary>
        HTSIZE = 4,
        /// <summary>
        /// In the size box (same as HTSIZE)
        /// </summary>
        HTGROWBOX = 4,
        /// <summary>
        /// In a menu
        /// </summary>
        HTMENU = 5,
        /// <summary>
        /// Horizontal scroll bar
        /// </summary>
        HTHSCROLL = 6,
        /// <summary>
        /// Vertical scroll bar
        /// </summary>
        HTVSCROLL = 7,
        /// <summary>
        /// Minimize button
        /// </summary>
        HTREDUCE = 8,
        /// <summary>
        /// Minimize button
        /// </summary>
        HTMINBUTTON = 8,
        /// <summary>
        /// Maximize button
        /// </summary>
        HTMAXBUTTON = 9,
        /// <summary>
        /// Maximize button
        /// </summary>
        HTZOOM = 9,
        /// <summary>
        /// Resizable window in the left border
        /// </summary>
        HTLEFT = 10,
        /// <summary>
        /// Right border in a resizable window
        /// </summary>
        HTRIGHT = 11,
        /// <summary>
        /// On the top border of the window
        /// </summary>
        HTTOP = 12,
        /// <summary>
        /// In the upper left border of the window
        /// </summary>
        HTTOPLEFT = 13,
        /// <summary>
        /// In the upper right border of the window
        /// </summary>
        HTTOPRIGHT = 14,
        /// <summary>
        /// (Users can click on the resizable window at a lower horizontal boundary to change the vertical size of the window)
        /// </summary>
        HTBOTTOM = 15,
        /// <summary>
        /// The window in the lower left corner can be resized (the user can adjust the size of the window by clicking the mouse, diagonally)
        /// </summary>
        HTBOTTOMLEFT = 16,
        /// <summary>
        /// The resizable window in the lower right corner of the border (the user can adjust the size of the window by clicking the mouse, diagonally)
        /// </summary>
        HTBOTTOMRIGHT = 17,
        /// <summary>
        /// In a window without a zoom border
        /// </summary>
        HTBORDER = 18,
        /// <summary>
        /// On the close button
        /// </summary>
        HTCLOSE = 20,
        /// <summary>
        /// At the help button
        /// </summary>
        HTHELP = 21,
    }

    /// <summary>
    /// Windows 256 virtual key codes used
    /// </summary>
    public enum KEYS
    {
        /// <summary>
        /// 
        /// </summary>
        VK_LBUTTON = 0x1,
        /// <summary>
        /// 
        /// </summary>
        VK_RBUTTON = 0x2,
        /// <summary>
        /// 
        /// </summary>
        VK_CANCEL = 0x3,
        /// <summary>
        /// 
        /// </summary>
        VK_MBUTTON = 0x4,
        /// <summary>
        /// 
        /// </summary>
        VK_BACK = 0x8,
        /// <summary>
        /// 
        /// </summary>
        VK_TAB = 0x9,
        /// <summary>
        /// 
        /// </summary>
        VK_CLEAR = 0xC,
        /// <summary>
        /// 
        /// </summary>
        VK_RETURN = 0xD,
        /// <summary>
        /// 
        /// </summary>
        VK_SHIFT = 0x10,
        /// <summary>
        /// 
        /// </summary>
        VK_CONTROL = 0x11,
        /// <summary>
        /// 
        /// </summary>
        VK_MENU = 0x12,
        /// <summary>
        /// 
        /// </summary>
        VK_PAUSE = 0x13,
        /// <summary>
        /// 
        /// </summary>
        VK_CAPITAL = 0x14,
        /// <summary>
        /// 
        /// </summary>
        VK_ESCAPE = 0x1B,
        /// <summary>
        /// 
        /// </summary>
        VK_SPACE = 0x20,
        /// <summary>
        /// 
        /// </summary>
        VK_PRIOR = 0x21,
        /// <summary>
        /// 
        /// </summary>
        VK_NEXT = 0x22,
        /// <summary>
        /// 
        /// </summary>
        VK_END = 0x23,
        /// <summary>
        /// 
        /// </summary>
        VK_HOME = 0x24,
        /// <summary>
        /// 
        /// </summary>
        VK_LEFT = 0x25,
        /// <summary>
        /// 
        /// </summary>
        VK_UP = 0x26,
        /// <summary>
        /// 
        /// </summary>
        VK_RIGHT = 0x27,
        /// <summary>
        /// 
        /// </summary>
        VK_DOWN = 0x28,
        /// <summary>
        /// 
        /// </summary>
        VK_Select = 0x29,
        /// <summary>
        /// 
        /// </summary>
        VK_PRINT = 0x2A,
        /// <summary>
        /// 
        /// </summary>
        VK_EXECUTE = 0x2B,
        /// <summary>
        /// 
        /// </summary>
        VK_SNAPSHOT = 0x2C,
        /// <summary>
        /// 
        /// </summary>
        VK_Insert = 0x2D,
        /// <summary>
        /// 
        /// </summary>
        VK_Delete = 0x2E,
        /// <summary>
        /// 
        /// </summary>
        VK_HELP = 0x2F,
        /// <summary>
        /// 
        /// </summary>
        VK_0 = 0x30,
        /// <summary>
        /// 
        /// </summary>
        VK_1 = 0x31,
        /// <summary>
        /// 
        /// </summary>
        VK_2 = 0x32,
        /// <summary>
        /// 
        /// </summary>
        VK_3 = 0x33,
        /// <summary>
        /// 
        /// </summary>
        VK_4 = 0x34,
        /// <summary>
        /// 
        /// </summary>
        VK_5 = 0x35,
        /// <summary>
        /// 
        /// </summary>
        VK_6 = 0x36,
        /// <summary>
        /// 
        /// </summary>
        VK_7 = 0x37,
        /// <summary>
        /// 
        /// </summary>
        VK_8 = 0x38,
        /// <summary>
        /// 
        /// </summary>
        VK_9 = 0x39,
        /// <summary>
        /// 
        /// </summary>
        VK_A = 0x41,
        /// <summary>
        /// 
        /// </summary>
        VK_B = 0x42,
        /// <summary>
        /// 
        /// </summary>
        VK_C = 0x43,
        /// <summary>
        /// 
        /// </summary>
        VK_D = 0x44,
        /// <summary>
        /// 
        /// </summary>
        VK_E = 0x45,
        /// <summary>
        /// 
        /// </summary>
        VK_F = 0x46,
        /// <summary>
        /// 
        /// </summary>
        VK_G = 0x47,
        /// <summary>
        /// 
        /// </summary>
        VK_H = 0x48,
        /// <summary>
        /// 
        /// </summary>
        VK_I = 0x49,
        /// <summary>
        /// 
        /// </summary>
        VK_J = 0x4A,
        /// <summary>
        /// 
        /// </summary>
        VK_K = 0x4B,
        /// <summary>
        /// 
        /// </summary>
        VK_L = 0x4C,
        /// <summary>
        /// 
        /// </summary>
        VK_M = 0x4D,
        /// <summary>
        /// 
        /// </summary>
        VK_N = 0x4E,
        /// <summary>
        /// 
        /// </summary>
        VK_O = 0x4F,
        /// <summary>
        /// 
        /// </summary>
        VK_P = 0x50,
        /// <summary>
        /// 
        /// </summary>
        VK_Q = 0x51,
        /// <summary>
        /// 
        /// </summary>
        VK_R = 0x52,
        /// <summary>
        /// 
        /// </summary>
        VK_S = 0x53,
        /// <summary>
        /// 
        /// </summary>
        VK_T = 0x54,
        /// <summary>
        /// 
        /// </summary>
        VK_U = 0x55,
        /// <summary>
        /// 
        /// </summary>
        VK_V = 0x56,
        /// <summary>
        /// 
        /// </summary>
        VK_W = 0x57,
        /// <summary>
        /// 
        /// </summary>
        VK_X = 0x58,
        /// <summary>
        /// 
        /// </summary>
        VK_Y = 0x59,
        /// <summary>
        /// 
        /// </summary>
        VK_Z = 0x5A,
        /// <summary>
        /// 
        /// </summary>
        VK_STARTKEY = 0x5B,
        /// <summary>
        /// 
        /// </summary>
        VK_CONTEXTKEY = 0x5D,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD0 = 0x60,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD1 = 0x61,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD2 = 0x62,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD3 = 0x63,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD4 = 0x64,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD5 = 0x65,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD6 = 0x66,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD7 = 0x67,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD8 = 0x68,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMPAD9 = 0x69,
        /// <summary>
        /// 
        /// </summary>
        VK_MULTIPLY = 0x6A,
        /// <summary>
        /// 
        /// </summary>
        VK_ADD = 0x6B,
        /// <summary>
        /// 
        /// </summary>
        VK_SEPARATOR = 0x6C,
        /// <summary>
        /// 
        /// </summary>
        VK_SUBTRACT = 0x6D,
        /// <summary>
        /// 
        /// </summary>
        VK_DECIMAL = 0x6E,
        /// <summary>
        /// 
        /// </summary>
        VK_DIVIDE = 0x6F,
        /// <summary>
        /// 
        /// </summary>
        VK_F1 = 0x70,
        /// <summary>
        /// 
        /// </summary>
        VK_F2 = 0x71,
        /// <summary>
        /// 
        /// </summary>
        VK_F3 = 0x72,
        /// <summary>
        /// 
        /// </summary>
        VK_F4 = 0x73,
        /// <summary>
        /// 
        /// </summary>
        VK_F5 = 0x74,
        /// <summary>
        /// 
        /// </summary>
        VK_F6 = 0x75,
        /// <summary>
        /// 
        /// </summary>
        VK_F7 = 0x76,
        /// <summary>
        /// 
        /// </summary>
        VK_F8 = 0x77,
        /// <summary>
        /// 
        /// </summary>
        VK_F9 = 0x78,
        /// <summary>
        /// 
        /// </summary>
        VK_F10 = 0x79,
        /// <summary>
        /// 
        /// </summary>
        VK_F11 = 0x7A,
        /// <summary>
        /// 
        /// </summary>
        VK_F12 = 0x7B,
        /// <summary>
        /// 
        /// </summary>
        VK_F13 = 0x7C,
        /// <summary>
        /// 
        /// </summary>
        VK_F14 = 0x7D,
        /// <summary>
        /// 
        /// </summary>
        VK_F15 = 0x7E,
        /// <summary>
        /// 
        /// </summary>
        VK_F16 = 0x7F,
        /// <summary>
        /// 
        /// </summary>
        VK_F17 = 0x80,
        /// <summary>
        /// 
        /// </summary>
        VK_F18 = 0x81,
        /// <summary>
        /// 
        /// </summary>
        VK_F19 = 0x82,
        /// <summary>
        /// 
        /// </summary>
        VK_F20 = 0x83,
        /// <summary>
        /// 
        /// </summary>
        VK_F21 = 0x84,
        /// <summary>
        /// 
        /// </summary>
        VK_F22 = 0x85,
        /// <summary>
        /// 
        /// </summary>
        VK_F23 = 0x86,
        /// <summary>
        /// 
        /// </summary>
        VK_F24 = 0x87,
        /// <summary>
        /// 
        /// </summary>
        VK_NUMLOCK = 0x90,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_SCROLL = 0x91,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_1 = 0xBA,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_PLUS = 0xBB,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_COMMA = 0xBC,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_MINUS = 0xBD,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_PERIOD = 0xBE,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_2 = 0xBF,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_3 = 0xC0,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_4 = 0xDB,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_5 = 0xDC,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_6 = 0xDD,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_7 = 0xDE,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_8 = 0xDF,
        /// <summary>
        /// 
        /// </summary>
        VK_ICO_F17 = 0xE0,
        /// <summary>
        /// 
        /// </summary>
        VK_ICO_F18 = 0xE1,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM102 = 0xE2,
        /// <summary>
        /// 
        /// </summary>
        VK_ICO_HELP = 0xE3,
        /// <summary>
        /// 
        /// </summary>
        VK_ICO_00 = 0xE4,
        /// <summary>
        /// 
        /// </summary>
        VK_ICO_CLEAR = 0xE6,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_RESET = 0xE9,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_JUMP = 0xEA,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_PA1 = 0xEB,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_PA2 = 0xEC,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_PA3 = 0xED,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_WSCTRL = 0xEE,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_CUSEL = 0xEF,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_ATTN = 0xF0,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_FINNISH = 0xF1,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_COPY = 0xF2,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_AUTO = 0xF3,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_ENLW = 0xF4,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_BACKTAB = 0xF5,
        /// <summary>
        /// 
        /// </summary>
        VK_ATTN = 0xF6,
        /// <summary>
        /// 
        /// </summary>
        VK_CRSEL = 0xF7,
        /// <summary>
        /// 
        /// </summary>
        VK_EXSEL = 0xF8,
        /// <summary>
        /// 
        /// </summary>
        VK_EREOF = 0xF9,
        /// <summary>
        /// 
        /// </summary>
        VK_PLAY = 0xFA,
        /// <summary>
        /// 
        /// </summary>
        VK_ZOOM = 0xFB,
        /// <summary>
        /// 
        /// </summary>
        VK_NONAME = 0xFC,
        /// <summary>
        /// 
        /// </summary>
        VK_PA1 = 0xFD,
        /// <summary>
        /// 
        /// </summary>
        VK_OEM_CLEAR = 0xFE,
    }
}
