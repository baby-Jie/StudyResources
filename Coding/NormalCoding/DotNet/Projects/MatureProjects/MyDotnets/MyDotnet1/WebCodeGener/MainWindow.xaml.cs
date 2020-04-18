using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WebCodeGener.CommonTools;
using WebCodeGener.Models;

namespace WebCodeGener
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

        }

        private void LoadInitialization()
        {
        }

        #endregion LoadAndDispose

        #region Private Methods
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

        #endregion Windows

        /// <summary>
        /// 生成 model 对应代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string code = AppUtils.GenerateModelCode(new ModelCondition()
            {
                Text = InputTbox.Text.Trim(),
                AddApiModelPropertyAttribute = true
            });

            OutputTBox.Text = code;
        }

        #endregion EventHandlers
    }
}
