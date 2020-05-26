using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommonServiceLocator;
using EnglishPlans.CommonTool;
using EnglishPlans.Model;
using EnglishPlans.ViewModel;
using Path = System.IO.Path;

namespace EnglishPlans.Views
{
    /// <summary>
    /// EnglishReview.xaml 的交互逻辑
    /// </summary>
    public partial class EnglishReview : Window
    {

        #region Constructors

        public EnglishReview()
        {
            InitializeComponent();

            CustomInitialization();
        }

        #endregion Constructors

        #region  Fields

        private MediaPlayer _mediaPlayer = new MediaPlayer();

        #endregion Fields

        #region Properties

        public EnglishViewModel ViewModel
        {
            get { return this.DataContext as EnglishViewModel; }
        }

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
            var myContext = ServiceLocator.Current.GetInstance<MyContext>();
            if (myContext != null)
            {
                myContext.SaveChanges();
                myContext.Dispose();
            }
        }

        private void LoadInitialization()
        {
            Refresh();
        }

        #endregion LoadAndDispose

        #region Private Methods


        /// <summary>
        /// 刷新页面
        /// </summary>
        private void Refresh()
        {
            ViewModel.UpdateEnglishWords();
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
        #endregion Windows

        /// <summary>
        /// 复习按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReviewBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ReviewWin win = new ReviewWin();
            win.ShowDialog();
        }

        /// <summary>
        /// 添加单词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddWordsWin win = new AddWordsWin();
            var ret = win.ShowDialog();

            if (ret == true)
            {
                Refresh();
            }
        }

        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayAudio_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is string word)
                {
                    AudioUtils.PlayWordAudio(word);
                }
            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion EventHandlers

    }
}
