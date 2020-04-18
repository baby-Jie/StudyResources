using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContextMenu = System.Windows.Forms.ContextMenu;
using MenuItem = System.Windows.Forms.MenuItem;

/// <summary>
/// 
/// </summary>

namespace DeskTopVideo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Fields

        private NotifyIcon _notifyIcon;

        private IntPtr _windowHandle;

        private IntPtr _workerwIntPtr;

        #endregion Fields	


        public MainWindow()
        {
            InitializeComponent();
            CustomInitialization();
        }

        #region LoadAndDispose

        private void CustomInitialization()
        {
            this.Loaded += Window_OnLoaded;
            this.Closing += Window_Closing;

            this.Left = 0;
            this.Top = 0;
            this.Width = SystemParameters.FullPrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;

            InitialMedia();
            LoadNotifyIcon();

            EnumWindowsProc ewp = new EnumWindowsProc(ADA_EnumWindowsProc);
            EnumWindows(ewp, 0);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Dispose();
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadInitialization();
        }

        private void Dispose()
        {
            _notifyIcon?.Dispose();
            _notifyIcon = null;
        }

        private void LoadInitialization()
        {
            _windowHandle = new WindowInteropHelper(this).Handle;

            // 根据名称找到一个window
            IntPtr windowPtr = FindWindow(null, "Program Manager");
            if (windowPtr != IntPtr.Zero)
            {
                int ret = SetParent(_windowHandle, windowPtr);
            }
        }

        /// <summary>
        /// 加载托盘
        /// </summary>
        private void LoadNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = new System.Drawing.Icon("Batman.ico");
            _notifyIcon.Visible = true;
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem();
            menuItem.Text = "Quit";
            menuItem.Click += (sender, args) =>
            {
                this.Close();
                Process.GetCurrentProcess().Kill();
            };

            MenuItem testMenuItem = new MenuItem();
            testMenuItem.Text = "Mute";
            testMenuItem.Click += (sender, args) =>
            {
                VideoPlayer.IsMuted = !VideoPlayer.IsMuted;
            };
            contextMenu.MenuItems.Add(menuItem);
            contextMenu.MenuItems.Add(testMenuItem);
            _notifyIcon.ContextMenu = contextMenu;
        }

        private void InitialMedia()
        {
            VideoPlayer.UnloadedBehavior = MediaState.Manual;
            VideoPlayer.MediaEnded += (sender, args) =>
            {
                VideoPlayer.Position = new TimeSpan(0, 0, 0);
                VideoPlayer.Play();
            };
        }

        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        public bool ADA_EnumWindowsProc(IntPtr hWnd, int lParam)
        {
            IntPtr defView = FindWindowEx(hWnd, IntPtr.Zero, "SHELLDLL_DefView", null);

            if (defView != IntPtr.Zero)
            {
                _workerwIntPtr = FindWindowEx(IntPtr.Zero, hWnd, "WorkerW", null);

                ShowWindow(_workerwIntPtr, 0);
            }
            return true;
        }

        //EnumWindows函数，EnumWindowsProc 为处理函数
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        #endregion LoadAndDispose


        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int cmd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr handle);
    }
}
