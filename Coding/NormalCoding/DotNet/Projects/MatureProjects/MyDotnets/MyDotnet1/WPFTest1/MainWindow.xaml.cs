using System;
using System.Collections.Generic;
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
using WPFTest1.Models;

namespace WPFTest1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataObject.AddPastingHandler(TestRichTextBox, (sender, e) =>
            {
                var isText = e.SourceDataObject.GetDataPresent(DataFormats.Text, true);
                if (isText)
                {
                    e.FormatToApply = DataFormats.Text;
                }
                else
                {
                    e.CancelCommand();
                }
            });
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            //{
            //    IDataObject dataObj = Clipboard.GetDataObject();
            //    if (dataObj.GetDataPresent(DataFormats.Text))
            //    {
            //        e.Handled = true; //去掉格式文本的格式 
            //        var txt = (string)Clipboard.GetData(DataFormats.Text);
            //        if (txt != null)
            //        {
            //            Clipboard.Clear();
            //            Clipboard.SetData(DataFormats.StringFormat, txt);
            //            TestRichTextBox.Paste();
            //        }
            //    }
            //}
        }

        private void TestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Name = "smx";
            person.Age = 18;

            Student student = (Student) person;

            Console.WriteLine(student.Address);
        }
    }
}
