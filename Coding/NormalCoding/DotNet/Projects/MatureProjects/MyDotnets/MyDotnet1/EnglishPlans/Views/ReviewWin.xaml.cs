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
using System.Windows.Shapes;
using CommonServiceLocator;
using EnglishPlans.CommonTool;
using EnglishPlans.Model;
using EnglishPlans.ViewModel;

namespace EnglishPlans.Views
{
    /// <summary>
    /// ReviewWin.xaml 的交互逻辑
    /// </summary>
    public partial class ReviewWin : Window
    {
        public ReviewWin()
        {
            InitializeComponent();
            CustomInitialization();
        }

        #region Properties

        public ReviewViewModel ViewModel => this.DataContext as ReviewViewModel;


        #endregion Properties	

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
            // 保存
            var englishModels = ViewModel.EnglishWords;
            var changedModels = from model in englishModels where model.IsReviewed select model;
            foreach (var model in changedModels)
            {
                english english = model.English;
                if (english == null)
                {
                    continue;
                }
                // 改变时间
                english.last_review_time = DateTime.Today;
                int addDays = 0;
                int nextTurn = (int)model.ReviewTurn;
                DateTime time = DateTime.Today;
                switch (model.ReviewTurn)
                {
                    case ReviewTurn.FIRST:
                        time = time.AddDays(2);
                        break;
                    case ReviewTurn.SECOND:
                        time = time.AddDays(4);
                        break;
                    case ReviewTurn.THIRD:
                        time = time.AddDays(7);
                        break;
                    case ReviewTurn.FOURTH:
                        time = time.AddDays(7);
                        break;
                    case ReviewTurn.FIFTH:
                        time = time.AddDays(39);
                        break;
                    case ReviewTurn.SIXTH:
                        time = time.AddDays(300);
                        break;
                    case ReviewTurn.SEVENTH:
                        time = time.AddDays(365);
                        break;
                    case ReviewTurn.OVER:
                        break;
                    default:
                        break;
                }

                nextTurn++;
                if (nextTurn > (int) ReviewTurn.OVER)
                {
                    nextTurn = (int) ReviewTurn.OVER;
                }

                english.review_turn = nextTurn;
                english.next_review_time = time;

            }

            var context = ServiceLocator.Current.GetInstance<MyContext>();
            context.SaveChanges();

        }

        private void LoadInitialization()
        {
            ViewModel.UpdateEnglishWords();
        }

        #endregion LoadAndDispose


        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
