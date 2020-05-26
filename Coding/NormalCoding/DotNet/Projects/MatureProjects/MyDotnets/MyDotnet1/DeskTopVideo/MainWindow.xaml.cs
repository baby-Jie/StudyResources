using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Interop;
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

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            CustomInitialization();
        }

        #endregion Constructors	

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
            if (_workerwIntPtr != IntPtr.Zero)
            {
                int ret = SetParent(_windowHandle, _workerwIntPtr);
            }

            // 根据名称找到一个window
            //IntPtr windowPtr = FindWindow(null, "Program Manager");
            //if (windowPtr != IntPtr.Zero)
            //{
            //    int ret = SetParent(_windowHandle, windowPtr);
            //}
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

            MenuItem muteItem = new MenuItem();
            muteItem.Text = "Mute";
            muteItem.Click += (sender, args) =>
            {
                VideoPlayer.IsMuted = !VideoPlayer.IsMuted;
            };

            MenuItem loadItem = new MenuItem();
            loadItem.Text = "加载";
            loadItem.Click += (sender, args) =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "mp4|*.mp4";
                var ret = dialog.ShowDialog();

                if (ret == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    VideoPlayer.Stop();
                    VideoPlayer.Source = new Uri(filePath, UriKind.Absolute);
                    VideoPlayer.Position = new TimeSpan(0, 0, 0);
                    VideoPlayer.Play();
                }
            };

            contextMenu.MenuItems.Add(menuItem);
            contextMenu.MenuItems.Add(muteItem);
            contextMenu.MenuItems.Add(loadItem);
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

        #endregion LoadAndDispose

        #region Methods

        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        public bool ADA_EnumWindowsProc(IntPtr hWnd, int lParam)
        {
            IntPtr defView = FindWindowEx(hWnd, IntPtr.Zero, "SHELLDLL_DefView", null);

            if (defView != IntPtr.Zero)
            {
                _workerwIntPtr = FindWindowEx(IntPtr.Zero, hWnd, "WorkerW", null);

                if (_workerwIntPtr != IntPtr.Zero)
                {
                    ShowWindow(_workerwIntPtr, 0);
                }
            }
            return true;
        }

        //EnumWindows函数，EnumWindowsProc 为处理函数
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        #endregion Methods	

        #region Native Methods

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

        #endregion Native Methods	

    }
}
