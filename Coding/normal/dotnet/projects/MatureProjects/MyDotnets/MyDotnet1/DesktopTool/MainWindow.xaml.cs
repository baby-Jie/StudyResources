using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopTool.CommonTools;
using DesktopTool.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using WindowLib.Methods;
using WpfLib.WCommonTools;
using Path = System.IO.Path;

namespace DesktopTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            CustomInitialization();
        }

        #endregion Constructors

        #region  Fields

        private bool _isExpanded = true;

        private ObservableCollection<ShortcutModel> _models;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Events
        #endregion Events

        #region Methods

        #region LoadAndDispose

        private void CustomInitialization()
        {
            this.Loaded += Window_OnLoaded;
            this.Closing += Window_Closing;
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
            SaveModels();
        }

        private void LoadInitialization()
        {
            this.Width = AppConstants.WIN_NORMAL_WIDTH;
            this.Height = AppConstants.WIN_NORMAL_HEIGHT;
            this.Left = 30;
            this.Top = 30;
            this.HiddenFromTab();
            LoadModels();
        }

        private void LoadModels()
        {
            if (File.Exists(AppConstants.CONFIG_FILE_NAME))
            {
                string json = File.ReadAllText(AppConstants.CONFIG_FILE_NAME);
                _models =
                    JsonConvert.DeserializeObject<ObservableCollection<ShortcutModel>>(json);
            }
            else
            {
                _models = new ObservableCollection<ShortcutModel>();
                //_models.Add(new ShortcutModel()
                //{
                //    FilePath = @"D:\Files\Work\Projects\Dotnet\JavaCodes\WebCodeGener\WebCodeGener\bin\Debug\WebCodeGener.exe",
                //    IconPath = @"D:\Files\Work\Projects\Dotnet\JavaCodes\WebCodeGener\DesktopTool\bin\Debug\icons\tool.png"
                //});
            }
            ShortcutListBox.ItemsSource = _models;
        }

        #endregion LoadAndDispose

        #region Private Methods

        private void RunProcess(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(fileName);
                    processStartInfo.WorkingDirectory = Path.GetDirectoryName(fileName);
                    Process.Start(processStartInfo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ToggleDesktopIcons()
        {
            IntPtr hWnd = WinMethod.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "SysListView32", null);
            WinMethod.ShowWindow(hWnd, 0);
        }

        private void ToggleExpanded()
        {
            _isExpanded = !_isExpanded;
            if (_isExpanded)
            {
                this.Width = AppConstants.WIN_NORMAL_WIDTH;
                this.Height = AppConstants.WIN_NORMAL_HEIGHT;
            }
            else
            {
                this.Width = AppConstants.WIN_MIN_WIDTH;
                this.Height = AppConstants.WIN_MIN_HEIGHT;
            }
        }

        private void SaveModels()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_models);
                File.WriteAllText(AppConstants.CONFIG_FILE_NAME, json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion Private Methods	

        #region Public Methods
        #endregion Public Methods

        #region Override Methods
        #endregion Override Methods

        #region Native Methods
        #endregion Native Methods

        #endregion Methods

        #region EventHandlers

        #region Windows

        private void MainWindow_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        #endregion Windows

        /// <summary>
        /// 双击title 收缩或者扩展
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleContainer_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ToggleExpanded();
            }
        }

        private void IconsContainer_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var objData = e.Data.GetData(DataFormats.FileDrop);

                if (objData is Array array)
                {
                    foreach (var fileString in array)
                    {
                        FileInfo fileInfo = new FileInfo(fileString.ToString());

                        Console.WriteLine(fileString);
                    }
                }
            }
        }

        private void ToggleDesktopIconsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ToggleDesktopIcons();
        }

        #endregion EventHandlers

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBoxItem listBoxItem)
            {
                var dataContext = listBoxItem.DataContext;
                if (dataContext is ShortcutModel model)
                {
                    RunProcess(model.FilePath);
                }
            }
        }
    }
}
